## Wat is room?
Room is een databank in Android
- Abstractielaag voor een SQLite database
## Bouwstenen
Room heeft 3 delen:
- Database
- Data Access Object (DAO)
- Entity
### Entity
Definieert de structuur van een tabel en rij (SQL)
```kotlin
@Entity(tableName = "items")
data class Item {
	@PrimaryKey(autoGenerate = true)
	val id : Int = 0,
	val name: String,
	val price: Double,
	val quantity: Int
}
```
### Data Access Object
De DAO is de mediator tussen de database & het systeem, en voorziet dus een set an instructies
- Insert, update, delete, query
- functies worden gekoppeld aan SQL-queries

```kotlin
@Dao
interface ItemDAO {
	// link query aan functie, Flow is een observable die bij aanpassingen in de 
	// databank een notify krijgt
	@Query("SELECT * FROM X")
	fun getAll(): Flow<List<Item>>
}
```
### Database
- Is het toegangspunt tot de onderliggende databank
- Stelt de databank voor als een soort Proxy -klasse -object
- Is een **abstracte klasse**

```kotlin
@Database
abstract class MyCustomDatabase(entities = [Item::class], version = 1, 
								exportSchema = false) : RoomDatabase() {
	abstract fun Item() : Item;
}
```

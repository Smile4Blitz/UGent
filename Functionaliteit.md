## Event handlers/Listeners
- Luisteren & *trigger* een event als er iets gebeurd of aangepast wordt

```kotlin
@Composable
fun functie() {
	// if result changes, triggers a recompose
	var Result by remember { mutableStateOf(1) }
}
```
## Delegates properties
- Doel is eigenschappen delegeren
- De waarde van de eigenschap wordt niet zelf bijgehouden maar **gedelegeerd**
	- Standaard klasse
	- Lazy loading
	- Remember -functie
### Delegate: standard 
- Laat client toe met getter & setter te werken
- Waarde kan over meerdere componenten gedeeld worden

```kotlin
class Delegate {
	String customVariable = "a";

	operator fun getValue(thisRef: Any?, property: KProperty<*>):String {
		return this.customVariable;
	}

	operator fun setValue(thisRef: Any?, property: KProperty<*>, value: String):String {
		this.customVariable = value;
	}
}
```
### Delegate: lazy
- Waarde wordt pas aangemaakt wanneer nodig
- Bij eerste aanvraag kunnen andere events & functies aangeroepen worden

```kotlin
class Delegate {
	// when first requested, execute println() & then return value
	// after that, return value
	val lazyValue = String by lazy {
		println("loading value...");
		"My lazy loaded value."
	};
}
```
### Delegate: remember
- Wordt veel gebruikt binnen composables
- Laat toe om waardes **dynamisch** te **berekenen**
- Triggered een re-compose
	- Wordt automatisch een event listener aan gekoppeld

```kotlin
@Composable
fun abc() {
	// mutableState -object die maximaal 1 waarde bevat
	// lezen & schrijven wordt geobserveerd door compose (event listener)
	// als de waarde wijzigt => re-compose
	Boolean loaded by remember { mutableStateOf(false) };
}
```
## Extensie functies
- Voegen (extra) functionaliteit toe voor alle leden van een klasse
- **Wordt buiten de klasse gedefinieerd**

```kotlin
package Strings
fun String.MyCustomFunction():String {
	if(last() == '!')
		return "is yelling";
	else
		return "not yelling";
}
```

>[!to-know]
>- Lid-functies krijgen voorrang over extensie-functies
>- Geen dynamic binding
>	- Een extensie-functie kan enkel op de types waarvoor het een extension is uitgevoerd worden, bv.: String-extensie "string.abc()" kan niet gebruikt worden op parent-type Any "any.abc()"
## Infix functies
- Kunnen opgeroepen worden zonder "." of "()"

```kotlin
infix fun Int.euro(cents: Int):Double {
	return (Double) ((Double) cents / (Double) 100);
}

fun Convert(cents:Int):Double {
	// geeft uitkomst van euro (met eerste parameter cents) terug
	return euro cents;
}
```
## State hoisting
- Maak het component statusloos
- Toestand liften (naar boven verplaatsen)
	- Gemakkelijk om met meerdere componenten dezelfde informatie te gebruiken
	- Lift steeds naar de laagst gemeenschappelijke voorouder
- #Note Abstractie, abstractie, abstractie..


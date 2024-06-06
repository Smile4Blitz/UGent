## Constructor
- Geen `{}` nodig
- Geen `new` nodig
- #Note JS approach, anything & everything is allowed since we barely have rules
### Primaire & secundaire constructors
- 1 primaire constructor
- +1 secundair constructors
	- Moeten uiteindelijk altijd de primaire constructor aanroepen

```kotlin
class Person(val name:String,val age:Int) { // primaire constructor
	Person(_name:String) : this(_name, -1) // secundair constructor
}
```

In het voorbeeld zouden standaard waarden beter uitkomen i.p.v. een secundair constructor.
```kotlin
// primaire constructor met standaard waarde & zonder {}
class Person(val name:String,val age:Int = -1)
```
### Init
I.p.v. een constructor zoals in andere talen, maakt men in Kotlin gebruik van `init {}` om code uit te voeren bij het aanmaken van een object.
- Wordt bij elk type constructor opgeroepen

```kotlin
class Person {
	init {
		// code that needs to execute on creation
	}
}
```

>[!to-know]
>Init wordt opgeroepen:
>- Na primaire constructor
>- Voor secundaire constructor
## Functies als object
Een functie kan ook als object gebruikt worden.
```kotlin
fun sum(a:Int,b:Int) = a + b; // functie
val x = (1,2) -> Int = sum;
```
## Getter & setter
```kotlin
class Person {
	// bij opvragen van object return: "abcxyz"
	// kan enkel aangepast worden binnen class
	val abc = "xyz"
		get() = "abc" + abc;
		private set

	// nieuwe waarde die wordt toegekent prefixed met "abc"
	val def = "xyz"
		set(value) {
			field = "abc" + value;
		}
}
```
## Variabele zonder waarde
Laat toe om later een waarde toegekend te krijgen.
```kotlin
class Person {
	// object kan aangemaakt worden zonder abc te initializeren
	lateinit var abc;
	
	fun Setup(someValue:String):String {
		// check of abc als geïnitalizeerd is en ken waarde toe
		if(this::abc.isInitialized)
			throw IllegalStateException;
		else
			abc = someValue;
	}
}
```
## Access control
Standaard is elke klassen `public final`, iedereen kan de klassen zien & aanmaken, geen overerving; opties voor klassen zijn:
- Open
	- Zoals public, maar staat overerving toe
- Private
	- Enkel zichtbaar binnen klassen
- Internal
	- Enkel zichtbaar binnen namespace
- Abstract
	- Abstracte klassen

```kotlin
class abc : base(), ICustomInterface {
	// code
}
```

>[!to-know]
>- Standaard is elke klasse `public final`
>- Standaard is elke bovenklasse `Any`
>	- Gebruik `base()` om bovenliggende klasse constructor op te roepen
## Interfaces
Interfaces zijn eigenlijk abstracte klassen & verwachten dus dezelfde zaken:
- Interface kan variabelen bevatten
- Interface kan functies bevatten
- Overwrite moet worden gebruikt om eigenschappen & methodes bij overerving aan te passen

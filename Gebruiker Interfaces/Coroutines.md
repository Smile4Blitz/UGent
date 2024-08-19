Coroutines zijn de async functies van Kotlin.
## Technieken
- Threads
- Callbacks
- Promises
- Reactive programming
## Fouten
### Exceptions
- Exceptions stoppen alle coroutines:
	- In de scope
	- En de omliggende coroutine

```kotlin
fun main() {
	try {
		Operation();
	} catch(Exception ex) { ... }
}

// zowel one, two & Operation stoppen bij de Exception & geeft de exception terug
suspend fun Operation() {
	val one = async<Int> {
		...
	}

	val two = async<Int> {
		...
		throw new Exception();
	}
}
```
### Tijd
Het systeem zal een "not responding" bericht tonen als:
- Een methode op de UI thread niet binnen 5 seconden terugkeert
- BroadcastReceiver's onReceive niet binnen 10 seconden terugkeert
## Thread regels
>[!to-know]
>- Blokkeer de UI-thread niet, zie [[#Tijd]]
>- Geen toegang to de UI-toolkit buiten de UI-thread, zie [[#Tijd]]
## Syntax
- `runBlocking {}` als brug tussen sync & async
	- Blokkeert de huidige thread tot de coroutine(s) zijn afgerond
- `launch {}` om coroutines te starten.
- `suspend` is de async functie benaming van Kotlin

- `LaunchedEffect(varA, varB) { ... }` stopt & herstart indien één van de argumenten veranderd
	- Als `varA` tijdens het uitvoeren van de coroutines binnen `LaunchedEffect` veranderd, dan zullen de coroutines stoppen, & opnieuw starten

```kotlin
fun main() {
	val varA by remember { ... };
	val varB by remember { ... };

	// als varA | varB veranderd, stop & start funcA & funcB
	LaunchedEffect(varA, varB) {
		launch { funcA };
		launch { funcB };
	}
}
```

- `coroutineScope {}` staat toe meerdere coroutines te starten

```kotlin
// uitkomst is "Hello World"
fun main() = runBlocking {
	launch {
		RandomFunction();
	}
	println("Hello");
}

// suspend duid aan dit een async function is
suspend fun RandomFunction() {
	println("World");
}
```

- `async` kan je gebruiken i.p.v. launch { ... }

```kotlin
fun main() {
	runBlocking {
		RandomFunction();
	}
}

suspend fun RandomFunction() {
	val randomValue : String = async { getRemoteValue() };
	println($"value: ${randomValue.await()}")
}
```

- Je kan ook coroutines aan variabelen toekennen

```kotlin
fun main() {
	runBlocking {
		val job = launch { randomFunction(); }
	}

	job.cancel(); // cancel job
	job.join(); // wacht tot job is afgehandeld
}
```
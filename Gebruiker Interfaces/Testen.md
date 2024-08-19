## Unit -test
Unit-testen zijn redelijk simpel voorgesteld & geïmplementeerd, ze testen namelijk de code van ons programma, niet het gebruik ervan, unit-testen worden vooral gebruikt voor:
- Functies
- Klassen
- Eigenschappen

```kotlin
class SpecificTestClass {
	@Test
	fun TestOperationABC() {
		val expectedValue = "xyz";
		val actualValue = { 
			// test code 
		};
		assertEqual(expectedValue, actualValue)
	}

	@Test
	fun TestOperationXYZ() {
		// another test
	}
}
```
### Visible For Testing
Wanneer we boven onze functie, `@VisibleForTesting` plaatsen, kunnen we tijdens het draaien van onze unit-tests wel toegang krijgen tot de functie, maar zal deze bij de productie-build wel private zijn.
```kotlin
@VisibleForTesting
private fun Operation() {
	// program code
}
```
## UI-test
UI-testen zijn complexer, we testen namelijk de gebruikersinterface van onze applicatie, we moeten er dus voor kunnen zorgen dat we een persoon "emuleren" die ons programma gebruikt.
- Deel van de mobiele app testen
### Context emuleren
Bij UI-test testen we dus het gebruik van de applicatie in **specifieke omstandigheden**, om deze specifiek omstandigheden te krijgen, kunnen we gebruik maken van `setContent`.
```kotlin
class UITest {
	// get => Testen kunnen dit item opvragen
	// Rule => Wordt voor elke test uitgevoerd
	// Resultaat => elke functie creert eerst een testComposable
	@get:Rule
	val testComposable = createComposeRule();

	@Test
	fun testABC() {
		testComposable.setContent {
			// intial content
		}

		// plaats ergens een waarde
		testComposable.onNodeWithText("abc").performTextInput("10");
	}
}
```

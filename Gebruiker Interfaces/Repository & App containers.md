## Programmastructuur
- My Application -klasse
	- Extend de build-in `Application()`, is hoogste klasse in onze programmastructuur
	- Bevat container
	- Voert `super.onCreate()` welke de standaard applicatie initialisatie uitvoert
- Container 
	- Bevat objecten voor dependency injection
	- Bevat de repository of repositories
- ViewModel
	- Krijgt objecten via dependency injection
		- repository
		- application
	- Bepaald de UI-state
- UI
	- Bepaald op basis van de UI-state
## Repository
Mediator tussen de [[ViewModel, UI & data layer#ViewModel]] & [[ViewModel, UI & data layer#Data layer]].
>[!to-know]
>- **SEPERATION OF CONCERNS**
>	- De repository weet waar & hoe data moet opgehaald en aangepast worden
>- **SINGLE SOURCE OF TRUTH**
>	- Voor de applicatie is dit de repository
>	- De repository moet voor de gegevens integriteit zorgen
>- Functionaliteit
>	- Mediator tussen **data laag** & **ViewModel**
>	- Module voor gegevensbewerking
>	- Abstractie van de concrete implementatie
## App Container
- Beheerd objecten die bezorgt worden aan de nodige constructors
- Beheerd dependencies
### Dependency Injection
I.p.v. een klasse een object te laten initialiseren geven we het object als parameter mee, op deze manier is het mogelijk een variantie op deze object aan te maken waardoor we met één klasse een variërend aantal producten kunnen maken.
```kotlin
interface IEngine { ... }
class EngineA : IEngine { ... }
class EngineB : IEngine { ... }

class customClass(private val dependecyInjectionObject : IEngine ) {
	fun EnginePower : Int {
		return IEngine.TestPower();
	}
}
```
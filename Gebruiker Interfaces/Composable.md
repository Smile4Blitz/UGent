## Object types
---
Er zijn veel build-in componenten je kan gebruiken in composables:
- Card
- Column
- Row
- Grid

>[!to-know]
>Vergeet niet aan lazy loading te doen bij vele items, bv.: 
>- lazyVerticalGrid
>- lazyColumn
>- lazyRow
### Gewicht
---
Gewicht kan je gebruiken om de plaats binnen een component evenwichtig te verdelen volgens het toegekend gewicht.
```kotlin
@Composable
fun Element(_modifier : Modifier) {
	Card {
		modifier = _modifier;
	}
}

@Composable
fun View() {
	list<Element> elements = emptyList()
	
	for(Element in elements) {
		if(...)
			Element.modifier.weight(1); // smaller element
		else
			Element.modifier.weight(2) // larger element
	}
}
```
## Scaffold
---
The Scaffold is a special component as it provides **"default layout for [[#Material design]]"**.
- Top balk
- Inhoud
- Onderste balk
- Actieknop

>[!to-know]
De scaffold zorgt niet **alleen** voor de layout, maar veel meer:
>- Layout
>- Kleuren
>- Vormen
>- Animaties
>- Fonts
>- etc.
### Material design
**Material design** is het ontwerpsysteem van Google voor een "goede" UI (eerder een standaard design in my opinion), het is een consistent ontwerp dat over vele applicaties gebruikt wordt en dus een **standaard** genoemd kan worden.

De composables gebruiken de material design voor een aantal zaken, waardoor een aantal zaken dus ook uniform zijn voor de gehele applicatie.
- Kleuren
- Typografie
- Vormen
- Animaties

#note abstractie, abstractie, abstractie...
## Animaties
---

### Soorten
- High bounce
- No bounce
- High stiffness
- Very low stiffness
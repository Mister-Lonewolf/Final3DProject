# Final Project 3D Game Development

Hier kan alle extra informatie vinden over de onze game. Onze game zal gaan over de Sustainable development goals, meer bepaald over (ruimte)afval en sorteren. De game bestaat uit 3 levels die elks een eigen minigame voorstellen. Hieronder kan u meer info vinden over de verschillende levels, belangrijke code en controls.

## Level 1

### Beschrijving

Het eerste level gaat over afval opruimen en sorteren. Het doel is om het afval zo snel mogelijk weg te doen. Het afval zal op random locaties genereren in de kamer elke 15 seconden. Dan moet u het afval oprapen en in de juiste vuilniscontainer stoppen. Elke keer dat een stuk afval in de juiste container gestoken wordt zal uw scoren met 10 stijgen en zal te tijd van spawning versnellen. Als u het in de foute vuilniscontainer steekt zal uw score met 5 dalen en gebeurt er niets met de spawn tijd. Als u te traag het afval weg doet en het blijft opstapelen zal u de game verliezen. Dit zal gebeuren wanneer er 20 stukken afval aanwezig zijn (opgeraapt afval telt niet).

### Controls

De game ondersteunt volgende controls:

- ESC => Pauzeerd de game
- W => Wandel vooruit
- S => Wandel achteruit
- A => Draai naar links
- D => Draai naar rechts
- E => Raap afval op of drop het in de container
- 1 (niet op nummerpad) => Camera 1
- 2 (niet op nummerpad) => Camera 2
- 3 (niet op nummerpad) => Camera 3
- 4 (niet op nummerpad) => Camera 4

Extra info voor het sorteren:

- Wanneer het afval opgeraapt wordt zal links in het scherm "Holding: item" in dezelfde kleur komen te staan als de vuilniscontainer waar het afval in thuis hoort.

### Belangrijkste code blokken

De belangrijkste codeblokken in level 1 zijn de volgende:

- Random afval spawner
- Sorteren
- Na 20 items afval game over
- Switching cameras
- Foto toevoegen voor controls

#### Random afval spawnen

Om een afval generator te maken moeten we eerst een lijst van afval gameobjecten toevoegen aan het script. Door dit in een lijst op te slagen wordt het gemakkelijker om hier een willekeurig object uit te kiezen.

We zullen ook een spawndelay nodig hebben om te specifiëren hoe snel we willen dat het afval genereerd. Hierbij horen ook nog de time en seconds variabelen om op te slagen hoeveel tijd er voorbij gegaan is.

Vervolgens is er ook nog een aantal variabelen die ervoor gaan zorgen dat de speler zal verliezen en hoe de game hiermee moet omgaan. MaxAllowedTrash geeft het maximum toegestane afval weer en zal ervoor zorgen dat als de list van gespawned afval, currentTrash, groter is dan de gegeven lengte de speler de game verliest. Het verliezen van de game wordt opgeslagen in de game lost variabele. de spawning variabele wordt gebruikt om het spawnen uit of aan te zetten naargelang de game verloren of gepauzeerd is of niet.

CurrentTrash is een statische lijst wegens het anders instantie afhankelijk is en dus niet werkt voor onze toepassing.

![image](CodeSnippets/level1/randomTrash/listOfTrash.jpg)

Vervolgens moeten we de currentTrash lijst en spawndelay instantiëren in de start functie. Dit zal ervoor zorgen dat als de game (her)start wordt de game juist ingesteld wordt.

![image](CodeSnippets/level1/randomTrash/start.jpg)

Daarna komen we aan de updatefunctie van ons script. Dit is eigenlijk de functie die alles zal sturen en dus zeer belangrijk is. In deze functie roepen we eerst een andere functie, namelijk TrackTime, op die de timing in het oog zal houden van de spawner. Vervolgens kijken we na of er niet te veel objecten aanwezig zijn in onze scene, voor fps redenen, en of de tijd van de spawndelay nog niet verstreken is. Indien dit het geval is zal een nieuw stuk afval gespawned worden via SpawnTrash.

Daarna kijken we na of het maximaal ingesteld afval overschreden is en als dat ook is gebeurd zal de spawner stopen met spawnen en gaat gameLost op true komen te staan.

![image](CodeSnippets/level1/randomTrash/updateAndTrackTime.jpg)

Tenslotte komen we bij de belangrijkste functie, de spawnfuctie zelf. Hier gaan we eerst een random kiezen tussen al de mogelijke afval objecten. Vervolgens gaan we een random positie in de kamer kiezen. Hiervoor hebben we de kamer opgesplitst in 4 delen waarvan 3 gebruikt gaan worden voor het spawnen, het ongebruikte deel is voor de vuilniscontainers zelf waar dus geen afval mag komen.

We maken dus eeen vector3 array aan met random posities in per deel van de ruimte. Zo vul je de array met vectors waarvan de x en y posities een random zijn van de min en max values voor dat deel van de kamer. Je kan ook bepaalde vectors dupliceren om zo de kans te vergroten om in een bepaald deel te spawnen, zoals hier geïmplementeerd is om zo te voorkomen dat al het afval in het kleine deel spawned en dus meer verspreid is over de grotere ruimtes.

Tenslotte gaan we nog een random van die positie vector kiezen en maken we een afval instantie aan van het eerder gekozen object met als posities de random gekozen posities en we voegen dit dan toe aan de currentTrash lijst.

![image](CodeSnippets/level1/randomTrash/spawn.jpg)

#### Sorteren

Het sorteren van afval is ook een belangrijk deel van onze game. Hiervoor gaan we gebruik maken van tags. Zo geven we al het afval een gepaste tag naargelang bij welk soort afval het thuis hoort, dit is hoofdlettergevoelig! Zo hebben we voor het afval de tags: PMD, GFT, Rest en Paper.

Voor de vuilniscontainers gaan we hetzelfde doen maar dan met "Bin" achter de tags geschreven. De tags hier zullen dan zijn: PMDBin, GFTBin, RestBin en PaperBin.

Vervolgens gaan we het sorteren zelf toepassen. Zo gaan we wanneer de speler collides met afval eerst nakijken welk afval dit is en dit opslagen in zijn inventory. Het afval zal dan ook verwijderd worden van het speelveld. Daarna gaan we wanneer de speler collides met de vuilniscontainer eerst nakijken welk afval de speler vast en dit vergelijken met de container waar de speler met gecollided is. Als de container de tag van het afval in zijn naam heeft, zoals "PMD" voor het afval en "PMDBin" voor de container, Zal de speler 10 punten krijgen. Indien het niet overeenkomt zal de speler 5 punten verliezen. Tenslotte verwijderen we het afval van zijn inventory.

![image](CodeSnippets/level1/sort/sort.jpg)

#### Switching cameras

Ook het switchen van camera’s is een deel dat onze game niet zonder kan, de speler moet namelijk altijd zijn karakter in beeld kunnen hebben. Daarom hebben we een systeem dat de zal wisselen tussen de camera’s. Dit is een vrijs simpele functie waar we gewoon af hangend van welke camera actief moet zijn de camera’s actief of inactief gaan zetten.

![image](CodeSnippets/level1/cameras/code.jpg)

Dit wordt gestuurd door de Camera buttons die we declareren in de crossplatform inputmanager.
![image](CodeSnippets/level1/cameras/inputmanager.jpg)

#### Foto toevoegen voor controls

Als laatste laten we ook nog de controls zien op de eerste camera zodat de speler altijd weet hoe hij de game moet spelen. Dit doen we door een RawImage object toe te voegen als child van de gewenste camera. Tenslotte voegen we de foto toe als texture aan de RawImage component van dit object.

![image](CodeSnippets/level1/controls/controls.jpg)

### Assets

De assets gebruikt in level 1 zijn:

- Spotlight and Structure by SPACEZETA
- Free Scavenger by PAUL N.
- Junkyard Car Parts by GADE EMBOSSED
- Cardboard Boxes Pack HD by NOTANOTHERAPOCALYPTICCO.
- Plastic Trash Bins by SPACEZETA
- Trash Low Poly Cartoon Pack by BLANKFACESTANISLAV
- World Materials Free by AVIONX
- Mess Maker Free by THE QUANTUM NEXUS (alleen maar voor de afval prefabs, spawning is zelf gemaakt)

## Level 2

### Beschrijving

### Controls

### Belangrijkste code blokken

### Assets

## Level 3

### Beschrijving

### Controls

### Belangrijkste code blokken

### Assets

## Globale info

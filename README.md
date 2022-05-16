# Laagna Racer
### version 0.6.9
![Logo-modified](https://user-images.githubusercontent.com/70939410/168591371-bfdb5353-a9ec-4e3a-ad33-2b48c0f5acdc.png)

### Mobile game with unity and C#
### *Currently in deeper alpha than DayZ Standalone in 2013.*


![Screenshot_2022-05-16-15-38-06-712_com Ubisoft2 LaagnaRacer](https://user-images.githubusercontent.com/70939410/168594500-d2ee44e3-b95b-447b-82d8-76f15e3c0add.jpg)
![Screenshot_2022-05-16-15-38-57-490_com Ubisoft2 LaagnaRacer](https://user-images.githubusercontent.com/70939410/168594512-395cc2e0-34f3-4bf0-a929-4d772a82cda0.jpg)




#### Download The Newest Bugridden version here:> https://drive.google.com/file/d/1pJ2r2Rbt6CTNUDLgyr2k0XfXO1eRLeeq/view?usp=sharing



##### Lühidalt ülesannete kirjeldused:

Ehitada mobiilirakendus kasutades “Unity game engine” platvormi ning C# keelt. rakenduseks osutus sõitmis mäng, kus peab püsima võimalikult kaua mängu poolt genereeritud rajal. Mängu on võimalik mängida nii gyro controllerit kasutades kui ka lihtsaid left-right nuppe vajutades. Veel on võimalik muuta rajal sõitva auto värvi kasutajale meelepäraseks.

##### Mis osutus kergeks:
Unity pakub enda poolt palju lahendusi ning suurem osa projektist oli seetõttu enam vähem kerge. Näiteks  “scene manager” mille abil saab ehitada erinevaid lehti(stseene) ning neid vajadusel vahetada. Samuti oli võrdlemisi lihtne kasutada sisseehitatud güroskoopi lugemis moodulit, mille abil lisasime auto juhtimis loogika.

Kuuenda nädala ülesanne, kus pidi kasutaja andmeid salvestama, oli samuti täiesti jõukohane. Täpsemalt sai kasutada Unity scripting API-t nimega “PlayerPrefs”, mille abil saab salvestada kasutaja poolt määratud eelistused, näiteks auto värv.

##### Mis osutus raskeks:
Üks suurimaid probleemi tekitajaid oli augmenteeritud reaalsus. Proovisime samuti kasutada Unity poolt sisseehitatud mooduleid, kuid tekkis probleeme telefonide kokkusobimatusega ning versiooni erinevustega. Samuti polnud me päris kindlad kus oma mängus augementeeritud reaalsust implementeerida. Ülesande lahendamiseks kasutasime ARCore ja AR Foundation pluginaid.

Oli ka probleeme UI elementidega, millest tekkisid kas duplikaadid ekraanile või ei töötanud üleüldse peale mängule reseti tegemist. Viga sai mõnevõrra leeventatud kui muutsime milliseid gameobjecte mäng restardi puhul “killib”.

Unity scripti ning välise serveri ühendamine tekitas samuti alguses probleeme kuna polnud varem läbi C# serveritega ühendanud, kuid hiljem vaadates polnud midagi rasket. 



Kasutusel olevad keeled:

##### C# 

Üldiselt on kogemus C#-ga olnud suhteliselt vähene. Peamiselt on märgata selle sarnasust Java keelega, millega on meil kõigil vähemalt kerge kokkupuude olnud. 
Kuna kogemus C#-ga on meie seas üsna kesine, siis ei oska detailseid võrdlusi tuua teiste C# raamistikega. 
Järgi uurides ilmnevad aga mitmed erinevused - Näiteks on Unity’l suur osa funktsionaalsustest niiviisi sisse ehitatud, et ei pea neid nullist ehitama hakkama, näiteks valgustus ning füüsikalised omadused (küll aga saab neid muuta). Lisaks on Unity’l graafiline liides, mis aitab kergemini atribuute muuta ning kohe ka tulemust näha. 
Unity skript on konkreetne C# klass, mis laiendab MonoBehaviour faili nimega, mis on klassi nimega sama. See erineb veidi tavalisest C#, mille puhul pole tegelikult vahet, kus klassid deklareeritakse.
Kokkuvõttes pole funktsioonide ega süntaksi osas erinevusi. Unity C# on siiski tavaline C#.




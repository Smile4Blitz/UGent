using BestandsSysteem.Model;
FileSystem bs = new();

bs.mktext("tekst1");
bs.mktext(""); // 1
bs.mkdir("map1");
bs.dir(); // 2
bs.cd("map1");
bs.mkdir("map2");
bs.cd("map2");
bs.mktext("tekst2");
bs.mkdir("tekst2"); // 3
bs.dir(); // 4
bs.cd("tekst2"); // 5
bs.cd("..");
bs.tree(); // 6
bs.cd("/");
bs.tree(); // 7

/* 
 * EXPECTED OUTPUT:
 * 1. Lege naam niet toegelaten
 * 2. tekst1
 * 2. map1/
 * 3. Map bevat al bestand met naam 'tekst2'
 * 4. tekst2
 * 5. Ongeldig pad
 * 6. map1/
 * 6.  map2/
 * 6.    tekst2
 * 7. /
 * 7.   tekst1
 * 7.   map1/
 * 7.    map2/
 * 7.      tekst2
 */
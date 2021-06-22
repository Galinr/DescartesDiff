# DescartesDiff

Aplikacija namenjena primerjavi dveh stringov. Stringe se pridobi preko JSON-a kateri vsebuje BASE64. 
Za zacasno shranjevanje je uporabljena InMemory podatkovna baza do katere dostopamo z standardnimi EF core operacijami. 
Za shranjevanje podatkov v podatkovno bazo uporabljamo Put metodo katera na podlagi že obstoječih vnosov določi ali gre za nov vnos ali gre za update.
Za preverjanje razlik med dvema vnosoma uporabljamo Get metodo. Get metoda dekodira Base64 v string in ju nato preveri. 
Za preverjanje uporabljamo preporost algoritem kateri preveja vsak char stringa posebej. Naprej se preveri dolžina samega stringa. Če se razlikujeta metoda vrne rezulatat 
SizeDoNotMatch. V nasprotnem primeru se začne preverjati razlika med stringi.
V primeru razlike dobimo rezulata ContentDoNotMatch. Ob tem pa dobimo tudi izpis Offset in Length za vsako napako posebej. Če razlike ne najde dobimo rezultat Equals.

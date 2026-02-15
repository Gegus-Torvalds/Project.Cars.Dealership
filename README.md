CarsDealership Web Application:
  CarsDealership je web aplikacija razvijena u ASP.NET Core MVC okruženju sa ciljem upravljanja auto-salonom,
  korisnicima i administrativnim funkcionalnostima. Aplikacija je organizovana kroz slojevitu arhitekturu sa jasno razdvojenim domenskim, infrastrukturnim i prezentacionim slojem.
  Trenutna implementacija koristi server-rendered MVC pristup radi brže inicijalne realizacije, uz planiranu migraciju ka Web API arhitekturi i odvojenom frontend serveru.

Arhitektura:
  Aplikacija je organizovana kroz tri projekta:
  - Core sloj predstavlja domenski centar aplikacije i sadrži entitete, DTO modele, repository contracts i service contracts. 
Ovaj sloj ne zavisi od drugih slojeva i definiše poslovna pravila i interfejse.
  - Infrastructure sloj implementira pristup bazi podataka, Entity Framework Core konfiguraciju, ASP.NET Core Identity integraciju i konkretne implementacije repository i service slojeva.
  - UI sloj predstavlja prezentacioni sloj aplikacije i sadrži MVC kontrolere, Razor Views i konfiguraciju HTTP pipeline-a.
  Primijenjen je princip razdvajanja odgovornosti (Separation of Concerns) i modularna organizacija koda, čime se povećava održivost i testabilnost sistema.

Tehnologije:
  Backend je razvijen korištenjem ASP.NET Core MVC frameworka. Za pristup bazi podataka koristi se Entity Framework Core u kombinaciji sa PostgreSQL bazom podataka.
  Autentifikacija i autorizacija realizovane su putem ASP.NET Core Identity sistema sa role-based pristupom.
  Frontend dio implementiran je kroz Razor Views uz korištenje HTML, CSS i JavaScript tehnologija.
  Verzionisanje koda vršeno je putem Git sistema.

Autentifikacija i autorizacija
  Aplikacija koristi ASP.NET Core Identity sa prilagođenim identity entitetima radi brže implementacije. Implementirana je registracija i prijava korisnika uz cookie-based autentifikaciju.
  Autorizacija je realizovana kroz role-based pristup sa podjelom na administratore i standardne korisnike.
  Zaštita kontrolera i akcija ostvarena je korištenjem atributa za autorizaciju u MVC sloju.

Poslovna logika i ugovori:
  U Core sloju definisani su repository contracts i service contracts sa ciljem simulacije timskog rada i jasnog razdvajanja interfejsa od implementacije.
  Repository sloj je zadužen za pristup podacima, dok service sloj enkapsulira poslovnu logiku aplikacije. Infrastructure sloj sadrži konkretne implementacije definisanih interfejsa.
  Ovakva struktura omogućava zamjenu implementacije bez izmjene Core i Domenskog sloja i olakšava buduće proširenje sistema.

Trenutne funkcionalnosti
  Aplikacija omogućava registraciju i prijavu korisnika, upravljanje korisničkim ulogama.
  Struktura aplikacije omogućava jednostavno proširenje funkcionalnosti, uključujući buduće module poput zakazivanja servisa i CRUD operatcije nad Entitetima.

Planirana migracija na Web API arhitekturu i JWT token:
  Trenutna MVC implementacija realizovana je radi brže inicijalne izgradnje sistema. Planirano je prebacivanje aplikacije na ASP.NET Core Web API pristup,
  pri čemu će backend servis vraćati JSON odgovore, a frontend biti implementiran kao odvojena aplikacija.
  Ova promjena će omogućiti potpunu separaciju klijentskog i serverskog sloja, veću fleksibilnost pri razvoju frontend tehnologija i bolju skalabilnost sistema.
  Takođe korištenje JWT tokena umjesto Cookie-a u svrhu edukacije.


Cilj projekta:
  Cilj projekta je razvoj modularne i proširive backend arhitekture uz primjenu industrijskih principa organizacije koda,
  autentifikacije i rada sa bazama podataka. 
  Projekat predstavlja osnovu za dalji razvoj REST API sistema.

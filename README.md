# WareFlow
Wareflow to aplikacja desktopowa oraz usługa Windows Service stworzona w celu zoptymalizowania pracy z produktami i magazynem. Pozwala na zarządzanie magazynami jak i dostawami i wydaniami towarów. Projekt został napisany przy użyciu WPF, języka C# i bazy danych MySQL.

## Baza Danych
Wykorzystano bazę danych MySQL postawioną lokalnie. Baza została stworzona w oparciu o poniższy schemat:

![Zrzut ekranu 2024-02-11 155347](https://github.com/DarkArbiterr/WareFlow/assets/75552617/7fed925b-7685-4a4e-82da-c561641a042c)

W folderze projektu znajduje się plik .sql z dumpem bazy danych do własnego zaimportowania.

## Biblioteka
Projekt zawiera bibliotekę na którą składają się:
* **Modele Danych:** deklaracje klas obiektów otrzymywanych z bazy danych wraz z konstruktorami.
* **Dostęp do Danych:** zawiera funkcje zapytań do bazy danych (operacje CRUD itp.).
Po za tym, biblioteka również przetrzymuje informacje niezbędne do połączenia lokalnego z bazą danych (SQLConnector). Do łączenia z bazą wykorzystano bibliotekę Dapper.

## Testy Jednostkowe
Do każdej funkcji z biblioteki został napisany test jednostkowy. Biblioteka i testy były pisane zgodnie z metodyką TDD (Test Driven Development). Do stworzenia testów korzystano z biblioteki XUnit.

## Aplikacja
Struktura aplikacji to dwa okna: pierwsze do logowania i drugie bazowe okno aplikacji.

### Logowanie i Rejestracja
Logowanie wykorzystuje zapisane email i hasło z bazy danych. Obecnie nie jest możliwa rejestracja nowego użyktownika.
> [!NOTE]
> W celu przetestowania aplikacji, można skorzystać z testowego użytkownika:/
> **Email:** fakemail/
> **Hasło:** fakeuser

### Głowne Okno Aplikacji
Główne okno zawiera menu z zakładkami, które wyświetlają się  po kliknięciu odpowiednio w prawym panelu aplikacji.

### Produkty
Pozwala na podejrzenie produktów które znajdują się w naszej bazie danych oraz dodanie nowych.

### Magazyny
Pozwala na dodawanie bądź usuwanie magazynów zalogowanego użytkownika.

### Dostawy
Pozwala na wprowadzenie do systemu nowej dostawy (lista produktów i do jakiego magazynu przychodzi dostawa).

### Wydania
Pozwala na wprowadzenie do systemu nowego wydania (np. sprzedanie towaru w sklepie)

## Usługa Windows Service
Usługa monitoruje akcje dokonywane w czasie korzystania z aplikacji. Zapisuje poniższe czynności do pliku z logami oraz wypisuje je na dziennik zdarzeń usługi:
* Start i stop usługi
* Logowanie
* Dodawanie i usuwanie produktów, magazynów, dostaw i wydań

## Zarządzanie Pracą
Głownym aspektem stworzenie aplikacji WareFlow była nauka organizacji pracy i zadań w mini zespole dwuosobowym.

### Github Pojects
Do zarządzania zadaniami wykorzystano Github Projects. Kanban został podzielony na 4 części: Backlog, In Progress, Code Review i Done. Każde zadanie przed zakończniem poddawane było wzajemnemu Code Review.

### Gałęzie i Pull Request
Oprócz gałęzi main, każdy z nas posiadał indywidualną gałąź do której wypychał nowe implementacje. Następnie tworzony był Pull Request, druga osoba wtedy weryfikowała kod, dodawała ewentualne komentarze, po czym zatwierdzała i scalała z gałęzią main.

### Code Review
Code Review był wykonywany na podstawie Pull Requestów ale też ręcznie w programie w Visual Studio.


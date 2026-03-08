classDiagram

%% ===== Inheritance =====
Person <|-- Reader
Person <|-- Librarian

UserCreator <|-- ReaderCreator
UserCreator <|-- LibrarianCreator

%% ===== Factory relations =====
UserCreator --> Person : creates
ReaderCreator --> Reader
LibrarianCreator --> Librarian

%% ===== Borrow system =====
Borrow --> Book : borrows
History --> Borrow : stores

%% ===== Strategy =====
IFineRule <|.. DailyFine
IFineRule <|.. FixedFine
Borrow --> IFineRule : fineRule

%% ===== Database relations =====
Database --> Book
Database --> Borrow
Database --> Reader
Database --> Librarian
Database --> History

%% ===== Classes =====
class Person{
  +String name
  +getRole() String
}

class Reader{
  +int id
  +String email
  +String status
}

class Librarian{
}

class UserCreator{
  +createUser() Person
}

class ReaderCreator{
}

class LibrarianCreator{
}

class Book{
  +int id
  +String title
  +String author
  +int year
  +int copies
  +isAvailable() bool
}

class Borrow{
  +int id
  +Date issueDate
  +Date dueDate
  +Date returnDate
}

class History{
  +addBorrow()
  +getHistory()
}

class IFineRule{
  <<interface>>
  +calculateFine(daysLate) double
}

class DailyFine{
}

class FixedFine{
}

class Database{
  <<singleton>>
  +getInstance() Database
  +save()
  +load()
}

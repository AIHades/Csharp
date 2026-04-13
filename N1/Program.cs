using System;
using System.Collections.Generic;


namespace N1
{
    class Book
    {
        private string title;
        private string author;
        private int year;
        private int pages;
        private string genre;
        private string language;
        private bool isIssuedBook;


        public Book(
            string title, 
            string author, 
            int year, 
            int pages, 
            string genre,
            string language,
            bool isIssuedBook
        )
        {
            this.title = title;
            this.author = author;
            this.year = year;
            this.pages = pages;
            this.genre = genre;
            this.language = language;
            this.isIssuedBook = isIssuedBook;
        }

        public string Title
        {
            get{return title;}
        }

        public string Author
        {
            get{return author;}
        }

        public int Year
        {
            get{return year;}
        }

        public int Pages
        {
            get{return pages;}
        }

        public string Genre
        {
            get{return genre;}
        }

        public string Language
        {
            get{return language;}
        }

        public bool IsIssuedBook
        {
            get{return isIssuedBook;}
            set{isIssuedBook = value;}
        }
    }


    class Reader
    {
        private string fullName;
        private int age;
        private string phoneNumber;
        private string email;
        private int currentBooks;
        private List<Book> books;
        public Reader(
            string fullName,
            int age,
            string phoneNumber,
            string email,
            int currentBooks
        )
        {
            this.fullName = fullName;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.currentBooks = currentBooks;
            books = new List<Book>();
        }

        public string FullName
        {
            get{return fullName;}
        }

        public int Age
        {
            get{return age;}
        }

        public string PhoneNumber
        {
            get{return phoneNumber;}
        }

        public string Email
        {
            get{return email;}
        }

        public int CurrentBooks
        {
            get{return currentBooks;}
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            currentBooks = books.Count;
        }
        
        public void RemoveBook(Book book)
        {
            books.Remove(book);
            currentBooks = books.Count;
        }

        public List<Book> getBooks(){return books;}
    }


    class IssBooks
    {
        private Book book;
        private Reader reader;
        private DateTime issDate;

        public IssBooks(
            Book book,
            Reader reader,
            DateTime issDate
        )
        {
            this.book = book;
            this.reader = reader;
            this.issDate = issDate;
        }
        public Book Book
        {
            get{return book;}
        }

        public Reader Reader
        {
            get{return reader;}
        }

        public DateTime IssDate
        {
            get{return issDate;}
        }
    }


    class RetBooks
    {
        private Book book;
        private Reader reader;
        private DateTime retDate;

        public RetBooks(
            Book book,
            Reader reader,
            DateTime retDate
        )
        {
            this.book = book;
            this.reader = reader;
            this.retDate = retDate;
        }
        public Book Book
        {
            get{return book;}
        }

        public Reader Reader
        {
            get{return reader;}
        }
        public DateTime RetDate
        {
            get{return retDate;}
        }
    }


    class Library
    {
        static Dictionary<string, Book> books;
        static Dictionary<string, Reader> readers;
        static List<IssBooks> issBooks;
        static List<RetBooks> retBooks;

        static Library()
        {
            books = new Dictionary<string, Book>();
            readers = new Dictionary<string, Reader>();
            issBooks = new List<IssBooks>();
            retBooks = new List<RetBooks>();
        }

        public static void AddBook()
        {
            Console.WriteLine("Название книги: ");
            string title = Console.ReadLine();

            Console.WriteLine("Автор книги:" );
            string author = Console.ReadLine();

            Console.WriteLine("Год издания книги:" );
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Кол-во страниц книги:" );
            int pages = int.Parse(Console.ReadLine());

            Console.WriteLine("Жанр книги: ");
            string genre = Console.ReadLine();

            Console.Write("Язык книги: ");
            string language = Console.ReadLine();

            books.Add(title, new Book(title, author, year, pages, genre, language, false));
        }

        public static void AddReader()
        {
            Console.Write("ФИО читателя: ");
            string name = Console.ReadLine();

            Console.Write("Возраст читателя: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Телефон читателя: ");
            string phone = Console.ReadLine();

            Console.Write("Email читателя: ");
            string email = Console.ReadLine();

            readers.Add(name, new Reader(name, age, phone, email, 0));
        }

        public static void IssueBook()
        {
            Console.Write("Название книги: ");
            string title = Console.ReadLine();

            Console.Write("ФИО читателя: ");
            string name = Console.ReadLine();

            Book book = books[title];
            Reader reader = readers[name];

            book.IsIssuedBook = true;
            reader.AddBook(book);
            issBooks.Add(new IssBooks(book, reader, DateTime.Now));

            Console.WriteLine("Книга " + title + "выдана " + name);
        }

        public static void ReturnBook()
        {
            Console.Write("Название книги: ");
            string title = Console.ReadLine();

            Console.Write("ФИО читателя: ");
            string name = Console.ReadLine();

            Book book = books[title];
            Reader reader = readers[name];

            book.IsIssuedBook = false;
            reader.RemoveBook(book);
            retBooks.Add(new RetBooks(book, reader, DateTime.Now));
        }

        public static void ShowReader()
        {
            Console.Write("ФИО читателя: ");
            string name = Console.ReadLine();

            Reader reader = readers[name];
            Console.WriteLine("ФИО читателя: " + reader.FullName);
            Console.WriteLine("Возраст читателя: " + reader.Age);
            Console.WriteLine("Телефон читателя: " + reader.PhoneNumber);
            Console.WriteLine("Email читателя: " + reader.Email);
            Console.WriteLine("Кол-во книг на руках: " + reader.CurrentBooks);
        }

        public static void ShowBook()
        {
            Console.Write("Название книги: ");
            string title = Console.ReadLine();

            Book book = books[title];
            Console.WriteLine("Название книги: " + book.Title);
            Console.WriteLine("Автор книги: " + book.Author);
            Console.WriteLine("Кол-во страниц книги: " + book.Pages);
            Console.WriteLine("Жанр книги: " + book.Genre);
            Console.WriteLine("Язык книги: " + book.Language);
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        int m = 0;

        do
        {
            Console.WriteLine("\n1 - Добавить книгу");
            Console.WriteLine("2 - Добавить читателя");
            Console.WriteLine("3 - Выдать книгу");
            Console.WriteLine("4 - Вернуть книгу");
            Console.WriteLine("5 - Информация о книге");
            Console.WriteLine("6 - Информация о читателе");
            Console.WriteLine("0 - Выход");

            m = int.Parse(Console.ReadLine());

            switch (m)
            {
                case 1: Library.AddBook(); break;
                case 2: Library.AddReader(); break;
                case 3: Library.IssueBook(); break;
                case 4: Library.ReturnBook(); break;
                case 5: Library.ShowBook(); break;
                case 6: Library.ShowReader(); break;
            }

        } while (m != 0);

    }
}

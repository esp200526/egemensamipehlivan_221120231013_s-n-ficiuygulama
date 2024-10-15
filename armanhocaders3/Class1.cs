using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, string isbn, int year)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Year = year;
    }

    public override string ToString()
    {
        return $"Kitap Adı: {Title}, Yazar: {Author}, ISBN: {ISBN}, Yayın Yılı: {Year}";
    }
}

public class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(string title, string author, string isbn, int year)
    {
        Book newBook = new Book(title, author, isbn, year);
        books.Add(newBook);
        Console.WriteLine("Kitap başarıyla eklendi!");
    }

    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Kütüphanede hiç kitap yok.");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    public void SearchBook(string title)
    {
        var foundBooks = books.FindAll(b => b.Title.ToLower().Contains(title.ToLower()));
        if (foundBooks.Count > 0)
        {
            foreach (var book in foundBooks)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.");
        }
    }

    public void DeleteBook(string isbn)
    {
        var bookToRemove = books.Find(b => b.ISBN == isbn);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Kitap başarıyla silindi!");
        }
        else
        {
            Console.WriteLine("Silinecek kitap bulunamadı.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();
        while (true)
        {
            Console.WriteLine("\n--- Kütüphane Yönetim Sistemi ---");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitapları Listele");
            Console.WriteLine("3. Kitap Ara");
            Console.WriteLine("4. Kitap Sil");
            Console.WriteLine("5. Çıkış");

            Console.Write("Seçiminizi yapın: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Kitap Adı: ");
                    string title = Console.ReadLine();
                    Console.Write("Yazar Adı: ");
                    string author = Console.ReadLine();
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    Console.Write("Yayın Yılı: ");
                    int year = int.Parse(Console.ReadLine());
                    library.AddBook(title, author, isbn, year);
                    break;

                case "2":
                    library.ListBooks();
                    break;

                case "3":
                    Console.Write("Aranacak Kitap Adı: ");
                    string searchTitle = Console.ReadLine();
                    library.SearchBook(searchTitle);
                    break;

                case "4":
                    Console.Write("Silinecek Kitabın ISBN'si: ");
                    string deleteIsbn = Console.ReadLine();
                    library.DeleteBook(deleteIsbn);
                    break;

                case "5":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}

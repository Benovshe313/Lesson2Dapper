
using System.Data.SqlClient;
using ConsoleApp1Dapper.Models;
using ConsoleApp1Dapper.Models.DTOs;
using Dapper;

var conStr = "Data Source=DESKTOP-RFGQSC7;Initial Catalog=Library;Integrated Security=true";

using var sqlCon = new SqlConnection(conStr);

var query = @"SELECT Categories.Id, Categories.Name AS CategoryName, Books.Name AS BookName
              FROM Categories LEFT JOIN Books ON Categories.Id = Books.Id_Category";

var categoriesWithBooks = sqlCon.Query<CategoryWithBooks>(query);

foreach (var category in categoriesWithBooks)
{
    Console.WriteLine($"Category: {category.CategoryName}");
    Console.WriteLine($"Book: {category.BookName}");
}


var query2 = @"SELECT Books.Id, Books.Name AS BooksName, Themes.Name AS ThemeName
               FROM Books LEFT JOIN Themes ON Books.Id_Themes = Themes.Id";

var booksWithThemes = sqlCon.Query<BooksWithTheme>(query2);

foreach(var book in booksWithThemes)
{
    Console.WriteLine($"Book: {book.BooksName}");
    Console.WriteLine($"Theme: {book.ThemeName}");
}


string query3 = @"SELECT BookId, BookName, ThemeName FROM BooksWithThemes";

var booksWithThemes2 = sqlCon.Query<BooksWithThemeDTO>(query3);

foreach(var book in booksWithThemes2)
{
    Console.WriteLine($"Book: {book.BookName}");
    Console.WriteLine($"Theme: {book.ThemeName}");
}

var categoriesWithBooksEx = sqlCon.Query<CategoryWithBooks>("GetCategoriesWithBooks", System.Data.CommandType.StoredProcedure);

foreach(var category in categoriesWithBooksEx)
{
    Console.WriteLine($"Category: {category.CategoryName}");
    Console.WriteLine($"Book: {category.BookName}");
}

var booksWithThemesEx = sqlCon.Query<BooksWithTheme>("GetBooksWithThemes", System.Data.CommandType.StoredProcedure);

foreach(var book in booksWithThemesEx)
{
    Console.WriteLine($"Book: {book.BooksName}");
    Console.WriteLine($"Theme: {book.ThemeName}");
}
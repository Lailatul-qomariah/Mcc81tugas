﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    public class LibraryCatalog
    {
        List<Book> books = new List<Book>();
        
        ErrorHandler errorHandl = new ErrorHandler();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

       
        public void RemoveBook(string book)
        {
            var bookDelete = books.FirstOrDefault(b => b.Tittle == book); //mencocokkan dan mengambil objek berdasarkan tittle
            if (bookDelete != null)
            {
                books.Remove(bookDelete);
                Console.WriteLine("Book data has been successfully deleted!!");
            }
            else
            {
                ErrorHandler.HandleError("Invalid ISBN number. Book not found!!");
            }
        }

        public void FindBook(string tittles)
        {
            //search berdasarkan tittle, author, publisher dan ISBN
            var findBook = books.Where
                (b => Regex.IsMatch(b.Tittle, tittles, RegexOptions.IgnoreCase)).ToList();

            if (findBook.Count == 0)
            {
                ErrorHandler.HandleError("There are no books that match the keywords given!");
            }
            else
            {
                /*Console.WriteLine("Buku berhasil ditemukan");
                foreach (var item in findBook)
                {
                    Console.WriteLine($"Title: {item.Tittle}, Author: {item.Author}, Publication Year: {item.PublishYear}");
                }*/

                ListBook(findBook);
            }
        }

        public void ListBook(List<Book> books) //parameter menggunakan list 
        {
            
            foreach (var listBook in books)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine($"" +
                    $"\nJudul Buku          : {listBook.Tittle} " +
                    $"\nPenulis             : {listBook.Author} " +
                    $"\nTahun Terbit        : {listBook.PublishYear}");
                  
                Console.WriteLine("--------------------------------------------");

            }
        }

        public void ShowListBook()
        {
            ListBook(books);
        }

      

        
    }
}
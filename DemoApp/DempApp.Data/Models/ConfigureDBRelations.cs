using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DempApp.Data.Models
{
    class ConfigureDBRelations
    {
        /// <summary>
        /// One to Many
        /// </summary>
        public class Company
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Employee> Employees { get; set; }
        }
        public class Employee
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public Company Company { get; set; }
        }

        /// <summary>
        /// One to One
        /// </summary>
        public class Author
        {
            public int AuthorId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public AuthorBiography Biography { get; set; }
        }
        public class AuthorBiography
        {
            public int AuthorBiographyId { get; set; }
            public string Biography { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string PlaceOfBirth { get; set; }
            public string Nationality { get; set; }
            public int AuthorRef { get; set; }
            public Author Author { get; set; }
        }


        /// <summary>
        /// Many to Many
        /// </summary>
        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public Author Author { get; set; }
            public ICollection<BookCategory> BookCategories { get; set; }
        }
        public class Category
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public ICollection<BookCategory> BookCategories { get; set; }
        }
        public class BookCategory
        {
            public int BookId { get; set; }
            public Book Book { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; }
        }
    }
}

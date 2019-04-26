using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Models;

namespace WebApi.Repository
{
    public class BookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Book>> GetBooks()
        {
            return _context.Books.ToListAsync();
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _context.Books.First(i => i.Isbn.Equals(isbn));

        }

        public Book GetBookByAuthorName(string authorName)
        {
            return _context.Books.First(i => i.Author.Equals(authorName));
        }

        public IQueryable<Book> GetBookByAuthorNameContains(string authorName)
        {
         return _context.Books.Where(e => e.Author.Contains(authorName));
      
        }
      
        public async Task<Book> AddBook(Book book)
        {
            var data = _context.Books.FirstOrDefault(p => p.Isbn ==book.Isbn );
            if (data != null)
            {
                throw new Exception("Already Exist");
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;

        }

        public async Task<Book> UpdateBook(Book book)
        {
            var data = _context.Books.FirstOrDefault(p => p.Isbn == book.Isbn);
            if (data == null)
            {
                throw new Exception("No such ISBN Exists");
            }
            {
                data.Author = book.Author;
                data.Isbn = book.Isbn;
                data.Title = book.Title;
            }
            _context.Books.Update(data);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBook(Book book)
        {
            var data = _context.Books.FirstOrDefault(p => p.Isbn == book.Isbn);
            if (data == null)
            {
                throw new Exception("No such ISBN Exists");
            }
            _context.Books.Remove(data);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}

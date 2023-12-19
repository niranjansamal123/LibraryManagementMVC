using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementMVC.Models;
using System.Data.Entity;

namespace LibraryManagementMVC.Controllers
{
    public class BookController : Controller
    {
        LibraryDbContext dc = new LibraryDbContext();
       public ViewResult DisplayBooks()
        {
            var obj =dc.Books;
            return View(obj);
        }
        public ViewResult DisplayBook(int Id)
        {
            Book book = dc.Books.Where(B=>B.Bid==Id).FirstOrDefault();
            return View(book);
        }
        [HttpGet]
        public ViewResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddBook(Book book)
        {
            dc.Books.Add(book);
            dc.SaveChanges();
            return RedirectToAction("DisplayBooks");
        }
        public ViewResult EditBook(int Id)
        {
            var obj = dc.Books.Find(Id);
            return View(obj);
        }
        public RedirectToRouteResult UpdateBook(Book book)
        {
            dc.Entry(book).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayBooks");
        }
        public RedirectToRouteResult DeleteBook(int Id)
        {
            Book book = dc.Books.Find(Id);
            dc.Books.Remove(book);
            dc.SaveChanges();
            return RedirectToAction("DisplayBooks");
        }
    }
}
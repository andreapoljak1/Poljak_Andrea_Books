using Ispit.Books.Data;
using Ispit.Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ispit.Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
      
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        // Admin/Books
        public ActionResult Index(string? message)
        {
            ViewBag.BookMessage = message;
            var books = _context.Book.Select(
                s => new Book
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    AuthorName = s.Author.FirstName + " "+s.Author.LastName ,
                    PublisherName=s.Publisher.Title
                }
            ).ToList();
            if(books.Count()== 0)
            {
                ViewBag.BookMessage = "Knjige nisu unesene!";
                
                return View(books);
            }
            return View(books);
        }

        // GET: Admin/BooksController/Details/5
       
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", new { message = "Tražena knjiga ne postoji." });
            }

            var book = _context.Book.Where(p => p.Id == id).Select(
                s => new Book
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    AuthorName = s.Author.FirstName + " " + s.Author.LastName,
                    PublisherName = s.Publisher.Title
                }
            ).FirstOrDefault();

            if (book == null)
            {
                return RedirectToAction("Index", new { message = "Tražena knjiga ne postoji." });
            }
          
            return View(book);
        }

        // GET: Admin/BooksController/Create
        public ActionResult Create(string? message)
        {
            ViewBag.Authors = _context.Author.ToList();
            ViewBag.Publishers = _context.Publisher.ToList();
            ViewBag.BookMessage = message;

            return View();
        }

        // POST:Admin/BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
        {
          
            if (model.PublisherId == 0)
            {
                return RedirectToAction("Create", new { message = "Molimo odaberite nakladnika" });
            }
            if (model.AuthorId == 0)
            {
                return RedirectToAction("Create", new { message = "Molimo odaberite autora" });
            }
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model.UserId = userId;
                _context.Book.Add(model);
                _context.SaveChanges(); 

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create", new { message = ex.Message });
            }
        }

        // GET: Admin/BooksController/Edit/5
        public ActionResult Edit(int id, string? message)
        {
           if (id == 0)
            {
                return RedirectToAction("Index");
            }

            var book = _context.Book.Where(p => p.Id == id).Select(
                s => new Book
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    AuthorName = s.Author.FirstName + " " + s.Author.LastName,
                    PublisherName = s.Publisher.Title,
                    AuthorId = s.AuthorId,
                    PublisherId = s.PublisherId
                }
            ).FirstOrDefault();

            if (book == null)
            {
                return RedirectToAction("Index", new { msg = "Tražena knjiga ne postoji." });
            }
            ViewBag.AuthorId = _context.Author.ToList();
            ViewBag.SelectedAutor = _context.Author.FirstOrDefault(s => s.Id == book.AuthorId);
            ViewBag.PublisherId= _context.Publisher.ToList();
            ViewBag.SelectedNakladnik = _context.Publisher.FirstOrDefault(s => s.Id == book.PublisherId);
            return View(book);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book model)
        {

            if (model.PublisherId == 0)
            {
                return RedirectToAction("Create", new { message = "Molimo odaberite nakladnika" });
            }
            if (model.AuthorId == 0)
            {
                return RedirectToAction("Create", new { message = "Molimo odaberite autora" });
            }

            try
            {
                _context.Book.Update(model);
                _context.SaveChanges();


                return RedirectToAction("Edit", new { book_id = id, message = "Knjiga je uspješno ažurirana" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Edit", new { book_id = id, message = ex.Message });
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id, string? error_message)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var book = _context.Book.Where(p => p.Id == id).Select(
               s => new Book
               {
                   Id = s.Id,
                   Title = s.Title,
                   Description = s.Description,
                   AuthorName = s.Author.FirstName + " " + s.Author.LastName,
                   PublisherName = s.Publisher.Title
               }
           ).FirstOrDefault();

            if (book == null)
            {
                return RedirectToAction("Index", new { msg = "Tražena knjiga ne postoji." });
            }
            
            return View(book);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            try
            {
               var book = _context.Book.SingleOrDefault(s => s.Id == id);

                if (book == null)
                {
                    return View("Delete", new { product_id = id, msg = "Tražena knjiga ne postoji." });
                }

                _context.Book.Remove(book);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Delete", new { error_message = ex.InnerException.Message });
            }
        }
    }
}

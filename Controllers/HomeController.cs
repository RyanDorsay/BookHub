using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookHub.Models;
using BookHub.Data;

namespace BookHub.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    // Inject the ApplicationDbContext via constructor injection
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Books()
    {
        var books = _context.Books.ToList();


        return View(books);
    }

    // New Details action to display details for one book
    public IActionResult Details(int id)
    {
        // Retrieve the book from the database based on its id
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    // GET: Home/Edit
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // Retrieve the book with the matching id
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Title,Author,Genre,Description")] BookHub.Models.Books book)
    {
        if (id != book.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(book);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(b => b.Id == book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            // After a successful update, redirect to the Books view
            return RedirectToAction(nameof(Books));
        }
        return View(book);
    }


    // GET: Home/Delete
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    //delete id
    // POST: Home/Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        _context.SaveChanges();

        // After deletion, redirect to the Books view
        return RedirectToAction(nameof(Books));
    }


    //===== Non Book Stuff below 

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using Kollegeni.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using Kollegeni.Data;

namespace Kollegeni.Controllers;
public class BookingController : Controller
{
    private readonly BookingDbContext _db;

    public BookingController(BookingDbContext db)
    {
        _db = db;
    }


    // GET: Booking
    public ActionResult Index()
    {
        var bookinger = _db.Bookinger.Include(b => b.Fælleslokale).Include(b => b.Residens);
        return View(bookinger.ToList());
    }

    // GET: Booking/Create
    public ActionResult Create()
    {
        ViewBag.FælleslokaleId = new SelectList(_db.Fælleslokaler, "Id", "Navn");
        ViewBag.ResidensId = new SelectList(_db.Residenser, "Id", "Adresse");
        return View();
    }

    // POST: Booking/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind("Starttidspunkt,Sluttidspunkt,FælleslokaleId,ResidensId")] Booking booking)
    {
        if (ModelState.IsValid)
        {
            _db.Bookinger.Add(booking);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.FælleslokaleId = new SelectList(_db.Fælleslokaler, "Id", "Navn", booking.FælleslokaleId);
        ViewBag.ResidensId = new SelectList(_db.Residenser, "Id", "Adresse", booking.ResidensId);
        return View(booking);
    }

    // POST: Booking/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind("Id,Starttidspunkt,Sluttidspunkt,FælleslokaleId,ResidensId")] Booking booking)
    {
        if (ModelState.IsValid)
        {
            _db.Entry(booking).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.FælleslokaleId = new SelectList(_db.Fælleslokaler, "Id", "Navn", booking.FælleslokaleId);
        ViewBag.ResidensId = new SelectList(_db.Residenser, "Id", "Adresse", booking.ResidensId);
        return View(booking);
    }

    // GET: Booking/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null) return BadRequest(); // Replaces HttpStatusCodeResult(HttpStatusCode.BadRequest)

        Booking booking = _db.Bookinger.Find(id);
        if (booking == null) return NotFound(); // Replaces HttpNotFound()

        return View(booking);
    }


    // POST: Booking/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Booking booking = _db.Bookinger.Find(id);
        _db.Bookinger.Remove(booking);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _db.Dispose();
        }
        base.Dispose(disposing);
    }
}

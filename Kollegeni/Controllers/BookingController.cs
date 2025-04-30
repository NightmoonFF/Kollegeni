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
        var bookings = _db.Bookings.Include(b => b.Room).Include(b => b.Residency);
        return View(bookings.ToList());
    }

    // GET: Booking/Create
    public ActionResult Create()
    {
        ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Name");
        ViewBag.ResidencyId = new SelectList(_db.Residencies, "Id", "Address");
        return View();
    }

    // POST: Booking/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind("StartTime,EndTime,RoomId,ResidencyId")] Booking booking)
    {
        if (ModelState.IsValid)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Name", booking.RoomId);
        ViewBag.ResidencyId = new SelectList(_db.Residencies, "Id", "Address", booking.TenantId);
        return View(booking);
    }

    // POST: Booking/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind("Id,StartTime,EndTime,RoomId,ResidencyId")] Booking booking)
    {
        if (ModelState.IsValid)
        {
            _db.Entry(booking).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.RoomId = new SelectList(_db.Rooms, "Id", "Name", booking.RoomId);
        ViewBag.ResidencyId = new SelectList(_db.Residencies, "Id", "Address", booking.TenantId);
        return View(booking);
    }

    // GET: Booking/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null) return BadRequest(); // Replaces HttpStatusCodeResult(HttpStatusCode.BadRequest)

        Booking booking = _db.Bookings.Find(id);
        if (booking == null) return NotFound(); // Replaces HttpNotFound()

        return View(booking);
    }


    // POST: Booking/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Booking booking = _db.Bookings.Find(id);
        _db.Bookings.Remove(booking);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using video_rental;
using video_rental.Models;

namespace video_rental.Controllers
{
    public class RentalRecordsController : Controller
    {
        private readonly video_rentalsContext _context;

        public RentalRecordsController(video_rentalsContext context)
        {
            _context = context;
        }

        // GET: RentalRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentalRecords.ToListAsync());
        }

        // GET: RentalRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordsModel = await _context.RentalRecords
                .SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordsModel == null)
            {
                return NotFound();
            }

            return View(rentalRecordsModel);
        }

        // GET: Check out movie
        public async Task<IActionResult> CheckOutMovie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies
                .Include(m => m.GenresModel)
                .SingleOrDefaultAsync(m => m.MovieID == id);

            ViewData["customers"] = new SelectList(_context.Customers, "CustomerID", "CustomerName");

            if (moviesModel == null)
            {
                return NotFound();
            }

            return View(moviesModel);
        }


        //GET: RentalRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CheckInMovie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             var moviesModel = await _context.Movies
                .Include(m => m.GenresModel)
                .SingleOrDefaultAsync(m => m.MovieID == id);
            moviesModel.IsCheckedOut = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Movies");
        }

        //POST: RentalRecords/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,MovieID,DueDate")] RentalRecordsModel rentalRecordsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalRecordsModel);
                var movie = await _context.Movies.SingleOrDefaultAsync(s => s.MovieID == rentalRecordsModel.MovieID);
                movie.IsCheckedOut = true;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalRecordsModel);
        }

        // public async Task<IActionResult> CheckOutMovie()
        // {

        // }

        // GET: RentalRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordsModel = await _context.RentalRecords.SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordsModel == null)
            {
                return NotFound();
            }
            return View(rentalRecordsModel);
        }

        // POST: RentalRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalID,CustomerID,CustomerName,MovieID,MovieTitle,DueDate,IsOverdue")] RentalRecordsModel rentalRecordsModel)
        {
            if (id != rentalRecordsModel.RentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalRecordsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalRecordsModelExists(rentalRecordsModel.RentalID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rentalRecordsModel);
        }

        // GET: RentalRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordsModel = await _context.RentalRecords
                .SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordsModel == null)
            {
                return NotFound();
            }

            return View(rentalRecordsModel);
        }

        // POST: RentalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalRecordsModel = await _context.RentalRecords.SingleOrDefaultAsync(m => m.RentalID == id);
            _context.RentalRecords.Remove(rentalRecordsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalRecordsModelExists(int id)
        {
            return _context.RentalRecords.Any(e => e.RentalID == id);
        }
    }
}

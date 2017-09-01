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
    public class MoviesController : Controller
    {
        private readonly video_rentalsContext _context;

        public MoviesController(video_rentalsContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            var video_rentalsContext = _context.Movies.Include(m => m.GenresModel);
            return View(await video_rentalsContext.ToListAsync());
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies
                .Include(m => m.GenresModel)
                .SingleOrDefaultAsync(m => m.MovieID == id);
            if (moviesModel == null)
            {
                return NotFound();
            }

            return View(moviesModel);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            ViewData["GenresModelID"] = new SelectList(_context.Genres, "GenreID", "GenreID");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,MovieTitle,YearReleased,Director,GenresModelID")] MoviesModel moviesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenresModelID"] = new SelectList(_context.Genres, "GenreID", "GenreID", moviesModel.GenresModelID);
            return View(moviesModel);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies.SingleOrDefaultAsync(m => m.MovieID == id);
            if (moviesModel == null)
            {
                return NotFound();
            }
            ViewData["GenresModelID"] = new SelectList(_context.Genres, "GenreID", "GenreID", moviesModel.GenresModelID);
            return View(moviesModel);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,MovieTitle,YearReleased,Director,GenresModelID")] MoviesModel moviesModel)
        {
            if (id != moviesModel.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesModelExists(moviesModel.MovieID))
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
            ViewData["GenresModelID"] = new SelectList(_context.Genres, "GenreID", "GenreID", moviesModel.GenresModelID);
            return View(moviesModel);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesModel = await _context.Movies
                .Include(m => m.GenresModel)
                .SingleOrDefaultAsync(m => m.MovieID == id);
            if (moviesModel == null)
            {
                return NotFound();
            }

            return View(moviesModel);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviesModel = await _context.Movies.SingleOrDefaultAsync(m => m.MovieID == id);
            _context.Movies.Remove(moviesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesModelExists(int id)
        {
            return _context.Movies.Any(e => e.MovieID == id);
        }
    }
}

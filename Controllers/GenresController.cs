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
    public class GenresController : Controller
    {
        private readonly video_rentalsContext _context;

        public GenresController(video_rentalsContext context)
        {
            _context = context;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genres.ToListAsync());
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genresModel = await _context.Genres
                .SingleOrDefaultAsync(m => m.GenreID == id);
            if (genresModel == null)
            {
                return NotFound();
            }

            return View(genresModel);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreID,GenreName")] GenresModel genresModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genresModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genresModel);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genresModel = await _context.Genres.SingleOrDefaultAsync(m => m.GenreID == id);
            if (genresModel == null)
            {
                return NotFound();
            }
            return View(genresModel);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenreID,GenreName")] GenresModel genresModel)
        {
            if (id != genresModel.GenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genresModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenresModelExists(genresModel.GenreID))
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
            return View(genresModel);
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genresModel = await _context.Genres
                .SingleOrDefaultAsync(m => m.GenreID == id);
            if (genresModel == null)
            {
                return NotFound();
            }

            return View(genresModel);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genresModel = await _context.Genres.SingleOrDefaultAsync(m => m.GenreID == id);
            _context.Genres.Remove(genresModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenresModelExists(int id)
        {
            return _context.Genres.Any(e => e.GenreID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace Movies.Controllers
{
    public class MovieGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieGenres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MovieGenres.Include(m => m.Genre).Include(m => m.Movie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MovieGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGenre = await _context.MovieGenres
                .Include(m => m.Genre)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            return View(movieGenre);
        }

        // GET: MovieGenres/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return View();
        }

        // POST: MovieGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("MovieId,GenreId")] MovieGenre movieGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", movieGenre.GenreId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieGenre.MovieId);
            return View(movieGenre);
        }

        // GET: MovieGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGenre = await _context.MovieGenres.FindAsync(id);
            if (movieGenre == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", movieGenre.GenreId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieGenre.MovieId);
            return View(movieGenre);
        }

        // POST: MovieGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,GenreId")] MovieGenre movieGenre)
        {
            if (id != movieGenre.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieGenreExists(movieGenre.MovieId))
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
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", movieGenre.GenreId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieGenre.MovieId);
            return View(movieGenre);
        }

        // GET: MovieGenres/Delete/5
        public async Task<IActionResult> Delete(int? movieId, int? genreId)
        {
            if (movieId == null && genreId == null)
            {
                return NotFound();
            }

            var movieGenre = await _context.MovieGenres
                .Include(m => m.Genre)
                .Include(m => m.Movie)
                .Where(m => m.MovieId == movieId && m.GenreId == genreId).FirstOrDefaultAsync();
            if (movieGenre == null)
            {
                return NotFound();
            }

            return View(movieGenre);
        }

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movieGenre = await _context.MovieGenres
        //        .Include(m => m.Genre)
        //        .Include(m => m.Movie)
        //        .FirstOrDefaultAsync(m => m.MovieId == id);
        //    if (movieGenre == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movieGenre);
        //}


        // POST: MovieGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int movieId, int genreId)
        {
            var movieGenre = await _context.MovieGenres
                .Include(m => m.Genre)
                .Include(m => m.Movie)
                .Where(m => m.MovieId == movieId && m.GenreId == genreId).FirstOrDefaultAsync();
            //var movieGenre = await _context.MovieGenres.FindAsync(id);
            _context.MovieGenres.Remove(movieGenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieGenreExists(int id)
        {
            return _context.MovieGenres.Any(e => e.MovieId == id);
        }
    }
}

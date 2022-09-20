using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deal.Models;

namespace Deal.Controllers
{
    public class VideoController : Controller
    {
        private readonly ProjectDealContext _context;

        public VideoController(ProjectDealContext context)
        {
            _context = context;
        }

        // GET: Video
        public async Task<IActionResult> Index()
        {
              return _context.Video != null ? 
                          View(await _context.Video.ToListAsync()) :
                          Problem("Entity set 'ProjectDealContext.Video'  is null.");
        }

        // GET: Video/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Video/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Video/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoId,VideoPortfolio")] Video video)
        {
            if (ModelState.IsValid)
            {
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }

        // GET: Video/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        // POST: Video/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoId,VideoPortfolio")] Video video)
        {
            if (id != video.VideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.VideoId))
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
            return View(video);
        }

        // GET: Video/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Video == null)
            {
                return NotFound();
            }

            var video = await _context.Video
                .FirstOrDefaultAsync(m => m.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Video == null)
            {
                return Problem("Entity set 'ProjectDealContext.Video'  is null.");
            }
            var video = await _context.Video.FindAsync(id);
            if (video != null)
            {
                _context.Video.Remove(video);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(int id)
        {
          return (_context.Video?.Any(e => e.VideoId == id)).GetValueOrDefault();
        }
    }
}

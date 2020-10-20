using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EPolis.Models;
using Epolis.Data;

namespace EPolis.Controllers
{
    public class PerluasanController : Controller
    {
        private readonly EpolisContext _context;

        public PerluasanController(EpolisContext context)
        {
            _context = context;
        }

        // GET: Perluasan
        public async Task<IActionResult> Index()
        {
            return View(await _context.MPERLUASAN.ToListAsync());
        }

        // GET: Perluasan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mPERLUASAN = await _context.MPERLUASAN
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mPERLUASAN == null)
            {
                return NotFound();
            }

            return View(mPERLUASAN);
        }

        // GET: Perluasan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perluasan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OKUPASI,KODEPERTANGGUNGAN,DESKRIPSI,RATEPERTANGGUNGAN,RESIKO,UPDATEDBY,UPLOADDATE")] MPERLUASAN mPERLUASAN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mPERLUASAN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mPERLUASAN);
        }

        // GET: Perluasan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mPERLUASAN = await _context.MPERLUASAN.FindAsync(id);
            if (mPERLUASAN == null)
            {
                return NotFound();
            }
            return View(mPERLUASAN);
        }

        // POST: Perluasan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OKUPASI,KODEPERTANGGUNGAN,DESKRIPSI,RATEPERTANGGUNGAN,RESIKO,UPDATEDBY,UPLOADDATE")] MPERLUASAN mPERLUASAN)
        {
            if (id != mPERLUASAN.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mPERLUASAN);
                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MPERLUASANExists(mPERLUASAN.ID))
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
            return View(mPERLUASAN);
        }

        // GET: Perluasan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mPERLUASAN = await _context.MPERLUASAN
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mPERLUASAN == null)
            {
                return NotFound();
            }

            return View(mPERLUASAN);
        }

        // POST: Perluasan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mPERLUASAN = await _context.MPERLUASAN.FindAsync(id);
            _context.MPERLUASAN.Remove(mPERLUASAN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MPERLUASANExists(int id)
        {
            return _context.MPERLUASAN.Any(e => e.ID == id);
        }
    }
}

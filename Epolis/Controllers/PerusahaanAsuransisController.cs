using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EPolis.Models;
using Epolis.Data;

namespace EPolis.Controllers
{
    public class PerusahaanAsuransisController : Controller
    {
        private readonly EpolisContext _context;

        public PerusahaanAsuransisController(EpolisContext context)
        {
            _context = context;
        }

        // GET: PerusahaanAsuransis
        public async Task<IActionResult> Index()
        {
            return View(await _context.PerusahaanAsuransi.ToListAsync());
        }

        // GET: PerusahaanAsuransis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perusahaanAsuransi = await _context.PerusahaanAsuransi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (perusahaanAsuransi == null)
            {
                return NotFound();
            }

            return View(perusahaanAsuransi);
        }

        // GET: PerusahaanAsuransis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PerusahaanAsuransis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,KODEPERUSAHAAN,NAMAPERUSAHAAN,ALAMAT,NOTLP,NOFAX,CONTACTPERSON,EMAIL")] PerusahaanAsuransi perusahaanAsuransi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perusahaanAsuransi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perusahaanAsuransi);
        }

        // GET: PerusahaanAsuransis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perusahaanAsuransi = await _context.PerusahaanAsuransi.FindAsync(id);
            if (perusahaanAsuransi == null)
            {
                return NotFound();
            }
            return View(perusahaanAsuransi);
        }

        // POST: PerusahaanAsuransis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,KODEPERUSAHAAN,NAMAPERUSAHAAN,ALAMAT,NOTLP,NOFAX,CONTACTPERSON,EMAIL")] PerusahaanAsuransi perusahaanAsuransi)
        {
            if (id != perusahaanAsuransi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perusahaanAsuransi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerusahaanAsuransiExists(perusahaanAsuransi.ID))
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
            return View(perusahaanAsuransi);
        }

        // GET: PerusahaanAsuransis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perusahaanAsuransi = await _context.PerusahaanAsuransi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (perusahaanAsuransi == null)
            {
                return NotFound();
            }

            return View(perusahaanAsuransi);
        }

        // POST: PerusahaanAsuransis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perusahaanAsuransi = await _context.PerusahaanAsuransi.FindAsync(id);
            _context.PerusahaanAsuransi.Remove(perusahaanAsuransi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerusahaanAsuransiExists(int id)
        {
            return _context.PerusahaanAsuransi.Any(e => e.ID == id);
        }
    }
}

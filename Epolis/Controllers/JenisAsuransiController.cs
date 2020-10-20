using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EPolis.Models;
using Epolis.Data;

namespace EPolis.Controllers
{
    public class JenisAsuransiController : Controller
    {
        private readonly EpolisContext _context;

        public JenisAsuransiController(EpolisContext context)
        {
            _context = context;
        }

        // GET: JenisAsuransi
        public async Task<IActionResult> Index()
        {
            return View(await _context.MJENISASURANSI.ToListAsync());
        }

        // GET: JenisAsuransi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJENISASURANSI = await _context.MJENISASURANSI
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mJENISASURANSI == null)
            {
                return NotFound();
            }

            return View(mJENISASURANSI);
        }

        // GET: JenisAsuransi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JenisAsuransi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,KODEJENISASURANSI,JENISASURANSI,UPDATEDBY,UPDATEDDATE")] MJENISASURANSI mJENISASURANSI)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mJENISASURANSI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mJENISASURANSI);
        }

        // GET: JenisAsuransi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJENISASURANSI = await _context.MJENISASURANSI.FindAsync(id);
            if (mJENISASURANSI == null)
            {
                return NotFound();
            }
            return View(mJENISASURANSI);
        }

        // POST: JenisAsuransi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,KODEJENISASURANSI,JENISASURANSI,UPDATEDBY,UPDATEDDATE")] MJENISASURANSI mJENISASURANSI)
        {
            if (id != mJENISASURANSI.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mJENISASURANSI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MJENISASURANSIExists(mJENISASURANSI.ID))
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
            return View(mJENISASURANSI);
        }

        // GET: JenisAsuransi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJENISASURANSI = await _context.MJENISASURANSI
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mJENISASURANSI == null)
            {
                return NotFound();
            }

            return View(mJENISASURANSI);
        }

        // POST: JenisAsuransi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mJENISASURANSI = await _context.MJENISASURANSI.FindAsync(id);
            _context.MJENISASURANSI.Remove(mJENISASURANSI);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MJENISASURANSIExists(int id)
        {
            return _context.MJENISASURANSI.Any(e => e.ID == id);
        }
    }
}

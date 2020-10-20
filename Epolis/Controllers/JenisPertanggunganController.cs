using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EPolis.Models;
using EpolisParam.Models;
using Epolis.Data;

namespace EPolis.Controllers
{
    public class JenisPertanggunganController : Controller
    {
        private readonly EpolisContext _context;

        public JenisPertanggunganController(EpolisContext context)
        {
            _context = context;
        }

        // GET: JenisPertanggungan
        public ActionResult Index()
        {

            List<Models.MJENISPERTANGGUNGAN> pertanggungan = _context.MJENISPERTANGGUNGAN.ToList();
            List<MOKUPASI> okupasi = _context.MOKUPASI.ToList();
            List<MRESIKO> resiko = _context.MRESIKO.ToList();

            var OkupasiRecord = from p in pertanggungan
                                join o in okupasi on p.OKUPASIID equals o.ID into table1
                                from o in table1.ToList()
                                select new ViewModel
                                {
                                    pertanggungan = p,
                                    okupasi = o,
                                  
                                };
            return View(OkupasiRecord);
        }

        // GET: JenisPertanggungan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJENISPERTANGGUNGAN = await _context.MJENISPERTANGGUNGAN
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mJENISPERTANGGUNGAN == null)
            {
                return NotFound();
            }

            return View(mJENISPERTANGGUNGAN);
        }

        // GET: JenisPertanggungan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JenisPertanggungan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OKUPASI,KODEPERTANGGUNGAN,DESKRIPSI,RATEPERTANGGUNGAN,RESIKO,UPDATEDBY,UPDATEDATE")] Models.MJENISPERTANGGUNGAN mJENISPERTANGGUNGAN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mJENISPERTANGGUNGAN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mJENISPERTANGGUNGAN);
        }

        // GET: JenisPertanggungan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJENISPERTANGGUNGAN = await _context.MJENISPERTANGGUNGAN.FindAsync(id);
            if (mJENISPERTANGGUNGAN == null)
            {
                return NotFound();
            }
            return View(mJENISPERTANGGUNGAN);
        }

        // POST: JenisPertanggungan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OKUPASI,KODEPERTANGGUNGAN,DESKRIPSI,RATEPERTANGGUNGAN,RESIKO,UPDATEDBY,UPDATEDATE")] Models.MJENISPERTANGGUNGAN mJENISPERTANGGUNGAN)
        {
            if (id != mJENISPERTANGGUNGAN.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mJENISPERTANGGUNGAN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MJENISPERTANGGUNGANExists(mJENISPERTANGGUNGAN.ID))
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
            return View(mJENISPERTANGGUNGAN);
        }

        // GET: JenisPertanggungan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mJENISPERTANGGUNGAN = await _context.MJENISPERTANGGUNGAN
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mJENISPERTANGGUNGAN == null)
            {
                return NotFound();
            }

            return View(mJENISPERTANGGUNGAN);
        }

        // POST: JenisPertanggungan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mJENISPERTANGGUNGAN = await _context.MJENISPERTANGGUNGAN.FindAsync(id);
            _context.MJENISPERTANGGUNGAN.Remove(mJENISPERTANGGUNGAN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MJENISPERTANGGUNGANExists(int id)
        {
            return _context.MJENISPERTANGGUNGAN.Any(e => e.ID == id);
        }
    }
}

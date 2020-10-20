using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EpolisParam.Models;
using Epolis.Data;

namespace EPolis.Controllers
{
    public class BrokerController : Controller
    {
        private readonly EpolisContext _context;

        public BrokerController(EpolisContext context)
        {
            _context = context;
        }

        // GET: Broker
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mbroker.ToListAsync());
        }

        // GET: Broker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbroker = await _context.Mbroker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mbroker == null)
            {
                return NotFound();
            }

            return View(mbroker);
        }

        // GET: Broker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Broker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,KODEBROKER,NAMABROKER,ALAMAT,NOTLP,NOFAX,CONTACTPERSON,EMAIL,UPDATEDBY,UPDATEDATE")] Mbroker mbroker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mbroker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mbroker);
        }

        // GET: Broker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbroker = await _context.Mbroker.FindAsync(id);
            if (mbroker == null)
            {
                return NotFound();
            }
            return View(mbroker);
        }

        // POST: Broker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,KODEBROKER,NAMABROKER,ALAMAT,NOTLP,NOFAX,CONTACTPERSON,EMAIL,UPDATEDBY,UPDATEDATE")] Mbroker mbroker)
        {
            if (id != mbroker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mbroker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MbrokerExists(mbroker.ID))
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
            return View(mbroker);
        }

        // GET: Broker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbroker = await _context.Mbroker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mbroker == null)
            {
                return NotFound();
            }

            return View(mbroker);
        }

        // POST: Broker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mbroker = await _context.Mbroker.FindAsync(id);
            _context.Mbroker.Remove(mbroker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MbrokerExists(int id)
        {
            return _context.Mbroker.Any(e => e.ID == id);
        }
    }
}

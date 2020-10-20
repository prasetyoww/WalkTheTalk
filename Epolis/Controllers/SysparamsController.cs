using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epolis.Data;
using Epolis.Models;

namespace Epolis.Controllers
{
    public class SysparamsController : Controller
    {
        private readonly EpolisContext _context;

        public SysparamsController(EpolisContext context)
        {
            _context = context;
        }

        // GET: Sysparams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Msysparam.ToListAsync());
        }

        // GET: Sysparams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msysparam = await _context.Msysparam
                .FirstOrDefaultAsync(m => m.ID == id);
            if (msysparam == null)
            {
                return NotFound();
            }

            return View(msysparam);
        }

        // GET: Sysparams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sysparams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PARAMCODE,PARAMNAME,PARAMVALUE,PARAMDESC,ISMASKED,PARAMGROUP,ORDERNO,UPDATEDBY,UPDATEDATE")] Msysparam msysparam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(msysparam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(msysparam);
        }

        // GET: Sysparams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msysparam = await _context.Msysparam.FindAsync(id);
            if (msysparam == null)
            {
                return NotFound();
            }
            return View(msysparam);
        }

        // POST: Sysparams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PARAMCODE,PARAMNAME,PARAMVALUE,PARAMDESC,ISMASKED,PARAMGROUP,ORDERNO,UPDATEDBY,UPDATEDATE")] Msysparam msysparam)
        {
            if (id != msysparam.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(msysparam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MsysparamExists(msysparam.ID))
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
            return View(msysparam);
        }

        // GET: Sysparams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msysparam = await _context.Msysparam
                .FirstOrDefaultAsync(m => m.ID == id);
            if (msysparam == null)
            {
                return NotFound();
            }

            return View(msysparam);
        }

        // POST: Sysparams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var msysparam = await _context.Msysparam.FindAsync(id);
            _context.Msysparam.Remove(msysparam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MsysparamExists(int id)
        {
            return _context.Msysparam.Any(e => e.ID == id);
        }
    }
}

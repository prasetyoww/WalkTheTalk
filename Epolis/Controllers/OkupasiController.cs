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
    public class OkupasiController : Controller
    {
        private readonly EpolisContext _context;

        public OkupasiController(EpolisContext context)
        {
            _context = context;
        }

        // GET: Okupasi
        public ActionResult Index()
        {  
                List<MOKUPASI> okupasi = _context.MOKUPASI.ToList();
                List<MRESIKO> resiko =_context.MRESIKO.ToList();

                var OkupasiRecord = from o in okupasi
                                     join r in resiko on o.RESIKOID equals r.ID into table1
                                     from r in table1.ToList()
                                     select new ViewModel
                                     {
                                         okupasi = o,
                                         resiko = r
                                     };
                return View(OkupasiRecord);
        }

        // GET: Okupasi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mOKUPASI = await _context.MOKUPASI
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mOKUPASI == null)
            {
                return NotFound();
            }

            return View(mOKUPASI);
        }

        public IActionResult Create()
        {
            ViewBag.DDLResiko = _context.MRESIKO.ToList();
            return View();
        }

        // POST: Okupasi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(MOKUPASI model)

        {

            try

            {

                MOKUPASI okupasi = new MOKUPASI()

                {

                    KODEOKUPASI = model.KODEOKUPASI,

                    NAMAOKUPASI = model.NAMAOKUPASI,

                    RATESTANDAR = model.RATESTANDAR,

                    STDKELAS1 = model.STDKELAS1,

                    STDKELAS2 = model.STDKELAS2,

                    RESIKOID = model.RESIKOID,

                };

                _context.MOKUPASI.Add(okupasi);

                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            catch

            {

                return View(model);

            }

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,KODEOKUPASI,NAMAOKUPASI,RATESTANDAR,STDKELAS1,STDKELAS2,RESIKOID,UPDATEDBY,UPDATEDATE")] MOKUPASI mOKUPASI)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(mOKUPASI);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(mOKUPASI);
        //}

        // GET: Okupasi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mOKUPASI = await _context.MOKUPASI.FindAsync(id);
            if (mOKUPASI == null)
            {
                return NotFound();
            }
            ViewBag.DDLResiko = _context.MRESIKO.ToList();
            return View(mOKUPASI);
        }

        // POST: Okupasi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,KODEOKUPASI,NAMAOKUPASI,RATESTANDAR,STDKELAS1,STDKELAS2,RESIKOID,UPDATEDBY,UPDATEDATE")] MOKUPASI mOKUPASI)
        {
            if (id != mOKUPASI.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mOKUPASI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MOKUPASIExists(mOKUPASI.ID))
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
            return View(mOKUPASI);
        }

        // GET: Okupasi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mOKUPASI = await _context.MOKUPASI
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mOKUPASI == null)
            {
                return NotFound();
            }

            return View(mOKUPASI);
        }

        // POST: Okupasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mOKUPASI = await _context.MOKUPASI.FindAsync(id);
            _context.MOKUPASI.Remove(mOKUPASI);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       //Contoh Panggil data API
        //public IActionResult View(int id)
        //{
        //    try
        //    {
        //        var url = ConfigDataAccess.Configuration["baseApi"] + ConfigDataAccess.Configuration["urlapi:Mokupasi:getById"];
        //        (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, HttpContext.Session.GetString(SessionConst.jwt_Token));
        //        var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<MOKUPASI>>(result);

        //        return PartialView("_View", jsonResult.data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        private bool MOKUPASIExists(int id)
        {
            return _context.MOKUPASI.Any(e => e.ID == id);
        }
    }
}

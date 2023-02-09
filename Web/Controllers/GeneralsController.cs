using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Repositories;
using Entity;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class GeneralsController : Controller
    {
        private readonly CarContext _context = new CarContext();



        // GET: Generals
        public async Task<IActionResult> Index()
        {
            return View(await _context.GeneralInfo.ToListAsync());
        }

        // GET: Generals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general = await _context.GeneralInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (general == null)
            {
                return NotFound();
            }

            return View(general);
        }

        // GET: Generals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Generals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,description,tel1,tel2,email,adress,provizyon_desc")] General general)
        {
            if (ModelState.IsValid)
            {
                _context.Add(general);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(general);
        }

        // GET: Generals/Edit/5
        public async Task<IActionResult> Edit(int id = 1)
        {

            var general = await _context.GeneralInfo.FindAsync(id);
            if (general == null)
            {
                return NotFound();
            }
            return View(general);
        }

        // POST: Generals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,description,tel1,tel2,email,adress,Maps,provizyon_desc,aboutOffice")] General general)
        {
            if (id != general.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(general);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralExists(general.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "İşlem başarılı.";
                return RedirectToAction("Edit");
            }
            return View(general);
        }

        // GET: Generals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general = await _context.GeneralInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (general == null)
            {
                return NotFound();
            }

            return View(general);
        }

        // POST: Generals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var general = await _context.GeneralInfo.FindAsync(id);
            _context.GeneralInfo.Remove(general);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralExists(int id)
        {
            return _context.GeneralInfo.Any(e => e.Id == id);
        }
    }
}

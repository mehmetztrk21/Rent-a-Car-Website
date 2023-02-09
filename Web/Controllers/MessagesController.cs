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
    public class MessagesController : Controller
    {
        private readonly CarContext _context = new CarContext();


        // GET: Messages
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Messages.OrderByDescending(i => i.date).ToListAsync());
        }

        [Authorize(Roles = "admin")]
        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, string email, string phone, string title, string content)
        {
            if (ModelState.IsValid)
            {
                Message message = new Message() { name = name, title = title, phone = phone, content = content, mail = email, date = DateTime.Now };
                _context.Add(message);
                await _context.SaveChangesAsync();
                TempData["success"] = "Mesajınız iletildi. Size en kısa sürede dönüş yapacağız.";
                return RedirectToAction("Index", "Home");
            }
            return View("Contact", "Home");
        }



        // POST: Messages/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            TempData["success"] = "İşlem başarılı.";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}

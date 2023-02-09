using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Repositories;
using Entity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles="admin")]
    public class CarsController : Controller
    {
        private readonly CarContext _context=new CarContext();


        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var carContext = _context.Cars.Include(c => c.category);
            return View(await carContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> items = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.name

            });
            ViewData["CategoryId"] = items;
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,model,image,km,weekly_price,daily_price,type,description,Anasayfa,CategoryId")] Car car, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    {
                        var extention = Path.GetExtension(image.FileName);  //resmin uzantısını bulduk.
                        var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        car.image = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\assets\\images", randomName); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }
                _context.Add(car);
                await _context.SaveChangesAsync();
                TempData["success"] = "İşlem başarılı.";
                return RedirectToAction(nameof(Index));
            }
            IEnumerable<SelectListItem> items = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.name

            });
            ViewData["CategoryId"] = items;
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> items = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.name

            });
            ViewData["CategoryId"] = items;
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,model,image,km,weekly_price,daily_price,type,description,Anasayfa,CategoryId")] Car car,IFormFile image)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    {
                        var extention = Path.GetExtension(image.FileName);  //resmin uzantısını bulduk.
                        var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                        car.image = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\tema\\assets\\images", randomName); //resmin kaydedileceği yer.

                        using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                        {
                            await image.CopyToAsync(stream);  //kaydettik.
                        }
                    }
                }
                

                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "İşlem başarılı.";

                return RedirectToAction(nameof(Index));
            }
            IEnumerable<SelectListItem> items = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.name

            });
            ViewData["CategoryId"] = items;
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            TempData["success"] = "İşlem başarılı.";

            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}

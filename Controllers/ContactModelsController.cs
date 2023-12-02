using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChristiansClothes.Data;
using ChristiansClothes.Models;

namespace ChristiansClothes.Controllers
{
    public class ContactModelsController : Controller
    {
        private readonly ChristiansClothesContext _context;

        public ContactModelsController(ChristiansClothesContext context)
        {
            _context = context;
        }

        // GET: ContactModels
        public async Task<IActionResult> Index()
        {
              return _context.ContactDb != null ? 
                          View(await _context.ContactDb.ToListAsync()) :
                          Problem("Entity set 'ChristiansClothesContext.ContactDb'  is null.");
        }

        // GET: ContactModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactDb == null)
            {
                return NotFound();
            }

            var contactModel = await _context.ContactDb
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactModel == null)
            {
                return NotFound();
            }

            return View(contactModel);
        }

        // GET: ContactModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,FirstName,LastName,Address,Phone,Email,Message")] ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactModel);
        }

        // GET: ContactModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactDb == null)
            {
                return NotFound();
            }

            var contactModel = await _context.ContactDb.FindAsync(id);
            if (contactModel == null)
            {
                return NotFound();
            }
            return View(contactModel);
        }

        // POST: ContactModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,FirstName,LastName,Address,Phone,Email,Message")] ContactModel contactModel)
        {
            if (id != contactModel.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactModelExists(contactModel.ContactId))
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
            return View(contactModel);
        }

        // GET: ContactModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactDb == null)
            {
                return NotFound();
            }

            var contactModel = await _context.ContactDb
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contactModel == null)
            {
                return NotFound();
            }

            return View(contactModel);
        }

        // POST: ContactModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactDb == null)
            {
                return Problem("Entity set 'ChristiansClothesContext.ContactDb'  is null.");
            }
            var contactModel = await _context.ContactDb.FindAsync(id);
            if (contactModel != null)
            {
                _context.ContactDb.Remove(contactModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactModelExists(int id)
        {
          return (_context.ContactDb?.Any(e => e.ContactId == id)).GetValueOrDefault();
        }
    }
}
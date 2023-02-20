using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Developer.Data;
using Developer.Models;

namespace Developer.Controllers
{
    public class Contact_UsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Contact_UsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contact_Us
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact_Us.ToListAsync());
        }

        // GET: Contact_Us/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact_Us = await _context.Contact_Us
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact_Us == null)
            {
                return NotFound();
            }

            return View(contact_Us);
        }

        // GET: Contact_Us/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contact_Us/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country,Email,Phone,Message")] Contact_Us contact_Us)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact_Us);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact_Us);
        }

        // GET: Contact_Us/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact_Us = await _context.Contact_Us.FindAsync(id);
            if (contact_Us == null)
            {
                return NotFound();
            }
            return View(contact_Us);
        }

        // POST: Contact_Us/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country,Email,Phone,Message")] Contact_Us contact_Us)
        {
            if (id != contact_Us.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact_Us);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Contact_UsExists(contact_Us.Id))
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
            return View(contact_Us);
        }

        // GET: Contact_Us/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact_Us = await _context.Contact_Us
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact_Us == null)
            {
                return NotFound();
            }

            return View(contact_Us);
        }

        // POST: Contact_Us/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact_Us = await _context.Contact_Us.FindAsync(id);
            _context.Contact_Us.Remove(contact_Us);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Contact_UsExists(int id)
        {
            return _context.Contact_Us.Any(e => e.Id == id);
        }
    }
}

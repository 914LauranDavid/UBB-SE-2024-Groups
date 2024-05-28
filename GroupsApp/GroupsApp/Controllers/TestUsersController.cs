using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Controllers
{
    public class TestUsersController : Controller
    {
        private readonly GroupsAppContext _context;

        public TestUsersController(GroupsAppContext context)
        {
            _context = context;
        }

        // GET: TestUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestUser.ToListAsync());
        }

        // GET: TestUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testUser = await _context.TestUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testUser == null)
            {
                return NotFound();
            }

            return View(testUser);
        }

        // GET: TestUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,FullName,Email")] TestUser testUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testUser);
        }

        // GET: TestUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testUser = await _context.TestUser.FindAsync(id);
            if (testUser == null)
            {
                return NotFound();
            }
            return View(testUser);
        }

        // POST: TestUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,FullName,Email")] TestUser testUser)
        {
            if (id != testUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestUserExists(testUser.Id))
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
            return View(testUser);
        }

        // GET: TestUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testUser = await _context.TestUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testUser == null)
            {
                return NotFound();
            }

            return View(testUser);
        }

        // POST: TestUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testUser = await _context.TestUser.FindAsync(id);
            if (testUser != null)
            {
                _context.TestUser.Remove(testUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestUserExists(int id)
        {
            return _context.TestUser.Any(e => e.Id == id);
        }
    }
}

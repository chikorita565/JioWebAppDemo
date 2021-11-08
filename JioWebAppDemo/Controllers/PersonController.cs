using JioWebAppDemo.Data;
using JioWebAppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JioWebAppDemo.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var person = await _context.Person.ToListAsync();
            return View(person);
        }
        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Person person)
        {
            if(ModelState.IsValid)
            {
                _context.Person.Add(person);             
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var personinDb = await _context.Person.FirstOrDefaultAsync(p => p.ID == id);

            if (personinDb == null)
                return NotFound();

            return View(personinDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Person person)
        {
            if (!ModelState.IsValid)
                return View(person);

            _context.Person.Update(person);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var personinDb = await _context.Person.FirstOrDefaultAsync(p => p.ID == id);

            if (personinDb == null)
                return NotFound();

            _context.Person.Remove(personinDb);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

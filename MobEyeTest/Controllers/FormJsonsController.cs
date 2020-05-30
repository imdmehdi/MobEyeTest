using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobEyeTest.Data;
using MobEyeTest.Models;

namespace MobEyeTest.Controllers
{
    public class FormJsonsController : Controller
    {
        private readonly MobEyeTestContext _context;

        public FormJsonsController(MobEyeTestContext context)
        {
            _context = context;
        }

        // GET: FormJsons
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormJson.ToListAsync());
        }

        // GET: FormJsons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formJson = await _context.FormJson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formJson == null)
            {
                return NotFound();
            }

            return View(formJson);
        }

        // GET: FormJsons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormJsons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FormContent")] FormJson formJson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formJson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formJson);
        }

        // GET: FormJsons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formJson = await _context.FormJson.FindAsync(id);
            if (formJson == null)
            {
                return NotFound();
            }
            return View(formJson);
        }

        // POST: FormJsons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FormContent")] FormJson formJson)
        {
            if (id != formJson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formJson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormJsonExists(formJson.Id))
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
            return View(formJson);
        }

        // GET: FormJsons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formJson = await _context.FormJson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formJson == null)
            {
                return NotFound();
            }

            return View(formJson);
        }

        // POST: FormJsons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formJson = await _context.FormJson.FindAsync(id);
            _context.FormJson.Remove(formJson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormJsonExists(int id)
        {
            return _context.FormJson.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveFormDetails([Bind("Id,FormContent")] FormJson formDetails)
        {
            FormDetails obj = new FormDetails();
            obj.Id = formDetails.Id;
            obj.FromDetailsEntered = formDetails.FormContent;
            if (ModelState.IsValid)
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return View(obj);
            }
            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> SaveFormDetails()
        {
            return View(nameof(ListIndex), await _context.FormDetails.ToListAsync());
        }
        public async Task<IActionResult> ListIndex()
        {
            return View(await _context.FormDetails.ToListAsync());
        }
        public async Task<IActionResult> FormDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formJson = await _context.FormDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formJson == null)
            {
                return NotFound();
            }

            return View(nameof(SaveFormDetails),formJson);

        }


       


    }
}

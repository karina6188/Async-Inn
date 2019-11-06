using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;

namespace Async_Inn.Controllers
{
    public class AmenitiesController : Controller
    {
        /// <summary>
        /// Use IAmenitiesManager interface to connect with database
        /// </summary>
        private readonly IAmenitiesManager _context;

        public AmenitiesController(IAmenitiesManager context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all the amenities from database and show them on index page
        /// </summary>
        /// <returns></returns>
        // GET: Amenities
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAmenitiesAsync());
        }

        // GET: Amenities/Details/5
        /// <summary>
        /// Find amenities details by id. If id is not 0, get the amenities by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Amenities amenities = await _context.GetAmenitiesAsync(id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create an amenity and redirect the page back to index page.
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateAmenitiesAsync(amenities);
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        /// <summary>
        /// Get the amenity by id. If found, edit the amenity and send back the result.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var amenities = await _context.GetAmenitiesAsync(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Get the amenity by id. If found, edit the amenity then redirect to the index page.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAmenitiesAsync(amenities);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AmenitiesExists(amenities.ID))
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
            return View(amenities);
        }

        // GET: Amenities/Delete/5
        /// <summary>
        /// Get the amenity by id. If found, delete the amenity and redirect to index page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            await _context.DeleteAmenitiesAsync(id);
            return RedirectToAction("Index");
        }

        // POST: Amenities/Delete/5
        /// <summary>
        /// To confirm if the amenity is to be deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteAmenitiesAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AmenitiesExists(int id)
        {
            Amenities amenities = await _context.GetAmenitiesAsync(id);
            if(amenities != null)
            {
                return true;
            }
            return false;
        }
    }
}

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
using Async_Inn.Models.ViewModels;

namespace Async_Inn.Controllers
{
    public class RoomAmenitiesController : Controller
    {
        /// <summary>
        /// Get data from AsyncDatabase
        /// </summary>

        private readonly IRoomManager _rooms;
        private readonly IAmenitiesManager _amenities;

        public RoomAmenitiesController(IRoomManager rooms, IAmenitiesManager amenities)
        {
            _rooms = rooms;
            _amenities = amenities;
        }

        // GET: RoomAmenities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Room room = await _rooms.GetRoomById(id);
            var roomAmenities = _rooms.GetRoomAmenitiesByRoom(id);
            RoomAmenitiesVM ravm = new RoomAmenitiesVM();
            ravm.Room = room;
            ravm.RoomAmenities = roomAmenities;

            if (roomAmenities == null)
            {
                return NotFound();
            }

            return View(ravm);
        }

        // GET: RoomAmenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AmenitiesID,RoomID")] RoomAmenities roomAmenities)
        {
            if (ModelState.IsValid)
            {
                await _rooms.GetRoomById(roomAmenities.RoomID);
                return RedirectToAction(nameof(Index));
            }
            return View(roomAmenities);
        }
    }
}

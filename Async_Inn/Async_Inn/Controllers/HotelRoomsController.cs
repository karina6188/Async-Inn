﻿using System;
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
    public class HotelRoomsController : Controller
    {
        /// <summary>
        /// Get data from interfaces IHotelManager and IRoomManager
        /// </summary>
        private readonly IHotelManager _hotels;
        private readonly IRoomManager _rooms;

        public HotelRoomsController(IHotelManager hotels, IRoomManager rooms)
        {
            _hotels = hotels;
            _rooms = rooms;
        }

        // GET: HotelRooms
        //public async Task<IActionResult> Index()
        //{
        //    var asyncDbContext = _hotels.HotelRooms.Include(r => r.Amenities).Include(r => r.Room);
        //    return View(await asyncDbContext.ToListAsync());
        //}

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> HotelDetailsAsync(int id)
        {
            var hotelRoom = _hotels.GetHotelRoomsForHotel(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            RoomHotelVM rhvm = new RoomHotelVM();

            rhvm.Hotel = await _hotels.GetHotelById(id);
            rhvm.HotelRoom = hotelRoom;

            return View(rhvm);
        }

        // GET: HotelRooms/Create
        public async Task<IActionResult> Create()
        {
            ViewData["HotelID"] = new SelectList(await _hotels.GetHotels(), "ID", "City");
            ViewData["RoomID"] = new SelectList(await _rooms.GetRooms(), "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _rooms.GetHotelRoomsForHotel(hotelRoom.HotelID);
                return RedirectToAction(nameof(Index), "Rooms");
            }
            ViewData["HotelID"] = new SelectList(await _hotels.GetHotels(), "ID", "City", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(await _rooms.GetRooms(), "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int id, int roomID)
        {
            if (id <= 0 || roomID <= 0)
            {
                return NotFound();
            }

            await _rooms.DeleteRoom(id);

            return RedirectToAction(nameof(Index), "Rooms", roomID);
        }
    }
}


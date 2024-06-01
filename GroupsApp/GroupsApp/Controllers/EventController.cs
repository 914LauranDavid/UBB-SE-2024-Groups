﻿using GroupsApp.Models;
using GroupsApp.Models.MarketplacePosts;
using GroupsApp.Payload.DTO;
using GroupsApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupsApp.Controllers
{
    [Route("/event")]
    public class EventController : Controller
    {
        
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            return eventService.GetAllEvents();
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(Guid eventId)
        {
            try
            {
                this.eventService.DeleteEventById(eventId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<Event>> GetEvent(Guid eventId)
        {
            try
            {
                return Ok(eventService.GetEventById(eventId));
                
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}

/*
 *         [HttpGet("{eventId}")]
        public ActionResult<Event> GetEventById(Guid eventId)
        {
            try
            {
                var event = eventService.GetEventById(eventId);
                return Ok(event);
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
    }
*/
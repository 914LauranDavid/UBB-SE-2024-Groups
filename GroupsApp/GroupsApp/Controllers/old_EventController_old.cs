using GroupsApp.Models;
using GroupsApp.Models.MarketplacePosts;
using GroupsApp.Payload.DTO;
using GroupsApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupsApp.Controllers
{
    [Authorize]
    [Route("/event")]
    public class old_EventController_old : Controller
    {

        private readonly IEventService eventService;

        public old_EventController_old(IEventService eventService)
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

            }
            catch (Exception ex)
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
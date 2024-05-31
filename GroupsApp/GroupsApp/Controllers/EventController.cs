using Microsoft.AspNetCore.Mvc;

namespace GroupsApp.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

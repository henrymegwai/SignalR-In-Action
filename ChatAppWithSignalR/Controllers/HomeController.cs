using ChatAppWithSignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatAppWithSignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; 
        private IHubContext<MessageHub> _hubContext;
        public HomeController(IHubContext<MessageHub> hubContext,ILogger<HomeController> logger)
        {
            _logger = logger;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
           await _hubContext.Clients.All.SendAsync("DetermineConnection","You are connected now");
            return RedirectToAction("Index", "Home");
        }
    }
}

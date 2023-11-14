using ChatAppWithSignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatAppWithSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;
        private IHubContext<MessageHub> _hubContext;
        public MessagesController(IHubContext<MessageHub> hubContext, ILogger<MessagesController> logger)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        // GET: api/<MessagesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public async Task SendMessageToRoom(string roomNumber)
        {
            //retrieve last 5 messages and send to frontend
            string message = "";
            await _hubContext.Clients.Group(roomNumber).SendAsync("ReceiveMessage", message);
        }


        // GET api/<MessagesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MessagesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MessagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

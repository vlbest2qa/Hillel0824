using Microsoft.AspNetCore.Mvc;
using TestingApiService.Repository;

namespace TestingApiService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProphecyController : ControllerBase
    {
        private static readonly List<string> randomProphecies =
        [
            "The stars align in your favor today.",
            "Unexpected fortune is coming your way.",
            "Be alert, a new opportunity will soon present itself.",
            "Today is a day of great possibilities.",
            "A surprise awaits you around the corner."
        ];


        [HttpGet]
        public IActionResult Get([FromQuery] string topic)
        {
            var random = new Random();
            string randomProphecy = randomProphecies[random.Next(randomProphecies.Count)];

            string responseProphecyText = $"You prophecy about \"{topic}\" is: {randomProphecy}";

            var dbRepo = new ProphecyRepositoryMyslq();
            dbRepo.LogPropheciesResponse(topic, responseProphecyText);

            return Content(responseProphecyText, "text/plain");
        }
    }
}

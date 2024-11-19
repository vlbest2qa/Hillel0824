using Microsoft.AspNetCore.Mvc;
using TestingApiService.Models;
using TestingApiService.Repository;

namespace TestingApiService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProphecyNotForHWController : ControllerBase
    {
        private static readonly List<ProphecyNotForHWModel> prophecies =
        [
            new ProphecyNotForHWModel() { Topic = "games", ProphecyTopic = "Some about games" },
            new ProphecyNotForHWModel() { Topic = "work", ProphecyTopic = "Some about work" },
            new ProphecyNotForHWModel() { Topic = "today", ProphecyTopic = "Some about today" },
        ];


        [HttpGet]
        public IActionResult Get([FromQuery] string topic)
        {
            var prophecy = prophecies.SingleOrDefault(p => p.Topic == topic.ToLower());

            if (prophecy == null)
            {
                string topicsList = string.Join(", ", prophecies.Select(p => p.Topic));
                return NotFound($"No prophecy found for the topic: \"{topic}\". Сhoose from these topics: {topicsList}");
            }

            string prophecyText = $"You prophecy about \"{prophecy.Topic}\" is: {prophecy.ProphecyTopic}";
            var dbRepo = new ProphecyRepositoryMyslq();
            dbRepo.LogPropheciesResponse(prophecy.Topic, prophecyText);

            return Content(prophecyText, "text/plain");
        }
    }
}

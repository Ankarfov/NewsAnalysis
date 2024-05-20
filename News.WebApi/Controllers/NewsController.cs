using Microsoft.AspNetCore.Mvc;
using News.Application.News.Commands.AnalyseNews;
using News.Application.News.Commands.SaveNews;
using News.Application.News.Queries.GetNews;
using News.Application.News.Queries.LoadNews;
using News.Domain;

namespace News.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : DefaultController
    {
        [HttpGet]
        public async Task<ActionResult<New>> GetNews([FromQuery] GetNewsQuery newsQuery)
        {
            var news = await Mediator.Send(newsQuery);

            return Ok(news);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<New>> LoadNews(int id)
        {
            var query = new LoadNewsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> SaveNews([FromBody] SaveNewsCommand saveNewsCommand)
        {
            var newsId = await Mediator.Send(saveNewsCommand);

            return Ok(newsId);
        }

        [HttpPut]
        public async Task<ActionResult<int>> AnalyseNews([FromQuery] AnalyseNewsCommand analyseNews)
        {
            var analysed = await Mediator.Send(analyseNews);

            return Ok(analysed);
        }
    }
}

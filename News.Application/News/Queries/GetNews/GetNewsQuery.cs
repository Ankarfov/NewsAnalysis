using MediatR;
using News.Domain;

namespace News.Application.News.Queries.GetNews
{
    public class GetNewsQuery : IRequest<New>
    {
        public string ApiKey { get; set; }
        public int NewsNumber { get; set; } = 0;
        public string? Keyword { get; set; }
        public string? Language { get; set; }
    }
}

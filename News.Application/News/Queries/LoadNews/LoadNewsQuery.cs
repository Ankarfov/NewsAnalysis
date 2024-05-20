using MediatR;
using News.Domain;

namespace News.Application.News.Queries.LoadNews
{
    public class LoadNewsQuery : IRequest<New>
    {
        public int Id { get; set; }
    }
}

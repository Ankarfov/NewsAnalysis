using MediatR;
using News.Domain;

namespace News.Application.News.Commands.SaveNews
{
    public class SaveNewsCommand : IRequest<int>
    {
        public New News { get; set; }
    }
}

using MediatR;

namespace News.Application.News.Commands.AnalyseNews
{
    public class AnalyseNewsCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Chapter { get; set; }
    }
}

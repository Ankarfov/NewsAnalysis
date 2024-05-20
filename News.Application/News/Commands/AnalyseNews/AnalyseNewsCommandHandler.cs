using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Common.Defines;
using News.Application.Common.Exceptions;
using News.Application.Interfaces;

namespace News.Application.News.Commands.AnalyseNews
{
    public class AnalyseNewsCommandHandler : IRequestHandler<AnalyseNewsCommand, int>
    {
        private readonly INewsDbContext _dbContext;

        public AnalyseNewsCommandHandler(INewsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(AnalyseNewsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var enity = await _dbContext.News.FirstOrDefaultAsync(x => x.Id == request.Id) ?? null;

                if (enity == null)
                    throw new NotFoundException(request.Id);

                enity.Chapter = request.Chapter;

                string chapter = string.Empty;

                switch(request.Chapter)
                {
                    case NewsAnalysysKeysDefine.Title:
                        chapter = enity.Title;
                        break;
                    case NewsAnalysysKeysDefine.Description:
                        chapter = enity.Description;
                        break;
                    case NewsAnalysysKeysDefine.Content:
                        chapter = enity.Content;
                        break;
                }

                enity.VowelsCount = GetVowelsInfo(chapter).Values.Sum();

                await _dbContext.SaveChangesAsync(cancellationToken);

                return enity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return -1;
            }
        }

        private Dictionary<char, int> GetVowelsInfo(string text)
        {
            Dictionary<char, int> statistic = new Dictionary<char, int>();

            string textLower = text.ToLower();

            foreach (char c in textLower)
            {
                if(LettersDefine.Volves.Contains(c))
                {
                    if(statistic.ContainsKey(c))
                        statistic[c]++;
                    else
                        statistic.Add(c, 1);
                }
            }

            statistic = statistic.OrderByDescending(pair => pair.Value).ToDictionary();

            return statistic;
        }
    }
}

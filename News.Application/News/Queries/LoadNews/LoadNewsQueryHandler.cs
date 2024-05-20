using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Common.Exceptions;
using News.Application.Interfaces;
using News.Domain;

namespace News.Application.News.Queries.LoadNews
{
    public class LoadNewsCommandHandler : IRequestHandler<LoadNewsQuery, New>
    {
        private readonly INewsDbContext _dbContext;

        public LoadNewsCommandHandler(INewsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<New> Handle(LoadNewsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var enity = await _dbContext.News.FirstOrDefaultAsync(x => x.Id == request.Id) ?? null;

                if (enity == null)
                    throw new NotFoundException(request.Id);

                return enity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return null;
            }
        }
    }
}

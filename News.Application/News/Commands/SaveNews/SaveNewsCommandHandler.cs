using MediatR;
using News.Application.Interfaces;

namespace News.Application.News.Commands.SaveNews
{
    public class SaveNewsCommandHandler : IRequestHandler<SaveNewsCommand, int>
    {
        private readonly INewsDbContext _dbContext;

        public SaveNewsCommandHandler(INewsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(SaveNewsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.News.AddAsync(request.News, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return request.News.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return -1;
            }
        }
    }
}

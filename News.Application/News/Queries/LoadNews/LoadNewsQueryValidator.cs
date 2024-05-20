using FluentValidation;

namespace News.Application.News.Queries.LoadNews
{
    public class LoadNewsQueryValidator : AbstractValidator<LoadNewsQuery>
    {
        public LoadNewsQueryValidator()
        {
            RuleFor(loadNewsQuery =>
            loadNewsQuery.Id >= 0);
        }
    }
}

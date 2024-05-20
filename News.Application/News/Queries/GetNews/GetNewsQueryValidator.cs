using FluentValidation;
using News.Application.Common.Defines;

namespace News.Application.News.Queries.GetNews
{
    public class GetNewsQueryValidator : AbstractValidator<GetNewsQuery>
    {
        public GetNewsQueryValidator()
        {
            RuleFor(getNewsQuery =>
            getNewsQuery.ApiKey).NotEmpty();

            RuleFor(getNewsQuery =>
            getNewsQuery.NewsNumber >= 0);

            RuleFor(getNewsQuery =>
            getNewsQuery.Keyword).NotEmpty()
            .When(getNewsQuery => getNewsQuery.Language == null);

            RuleFor(getNewsQuery =>
            getNewsQuery.Language).NotEmpty()
            .When(getNewsQuery => getNewsQuery.Keyword == LanguagesDefine.US || 
            getNewsQuery.Keyword == LanguagesDefine.RU);
        }
    }
}

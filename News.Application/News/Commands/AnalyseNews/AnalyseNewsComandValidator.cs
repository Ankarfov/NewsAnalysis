using FluentValidation;
using News.Application.Common.Defines;

namespace News.Application.News.Commands.AnalyseNews
{
    public class AnalyseNewsComandValidator : AbstractValidator<AnalyseNewsCommand>
    {
        public AnalyseNewsComandValidator()
        {
            RuleFor(analyseNewsCommand =>
            analyseNewsCommand.Id >= 0);

            RuleFor(analyseNewsCommand =>
            analyseNewsCommand.Chapter).NotEmpty()
            .When(analyseNewsCommand => analyseNewsCommand.Chapter == NewsAnalysysKeysDefine.Title || 
            analyseNewsCommand.Chapter == NewsAnalysysKeysDefine.Description || 
            analyseNewsCommand.Chapter == NewsAnalysysKeysDefine.Content);
        }
    }
}

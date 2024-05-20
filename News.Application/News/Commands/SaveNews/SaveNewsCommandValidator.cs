using FluentValidation;

namespace News.Application.News.Commands.SaveNews
{
    public class SaveNewsCommandValidator : AbstractValidator<SaveNewsCommand>
    {
        public SaveNewsCommandValidator()
        {
            RuleFor(saveNewsCommand =>
            saveNewsCommand.News.Title).NotEmpty()
            .When(saveNewsCommand => saveNewsCommand.News.Description == null ||
            saveNewsCommand.News.Content == null);

            RuleFor(saveNewsCommand =>
            saveNewsCommand.News.Description).NotEmpty()
            .When(saveNewsCommand => saveNewsCommand.News.Title == null ||
            saveNewsCommand.News.Content == null);

            RuleFor(saveNewsCommand =>
            saveNewsCommand.News.Content).NotEmpty()
            .When(saveNewsCommand => saveNewsCommand.News.Title == null ||
            saveNewsCommand.News.Description == null);
        }
    }
}

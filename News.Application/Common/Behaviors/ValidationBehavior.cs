using FluentValidation;
using MediatR;

namespace News.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator) => _validators = validator;

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var contex = new ValidationContext<TRequest>(request);

            var failtures = _validators
                .Select(v => v.Validate(contex))
                .SelectMany(result => result.Errors)
                .Where(failture => failture != null)
                .ToList();

            if (failtures.Count != 0)
            {
                throw new ValidationException(failtures);
            }

            return next();
        }
    }
}

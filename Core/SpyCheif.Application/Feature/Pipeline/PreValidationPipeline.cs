

using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SpyCheif.Application.Dto;
using SpyCheif.Application.Validation;

namespace SpyCheif.Application.Feature.Pipeline
{
    public class PreValidationPipeline<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = validators.Select(v => v.Validate(context));
            var failures = validationResults.SelectMany(result => result.Errors).Where(f => f != null).ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return await next();
        }
    }
}

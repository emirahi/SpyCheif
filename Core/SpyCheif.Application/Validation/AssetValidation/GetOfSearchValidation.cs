using FluentValidation;
using SpyCheif.Application.Feature.Query.AssetQuery.GetOfSearch;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class GetOfSearchValidation : AbstractValidator<AssetGetOfSearchQueryRequest>
    {
        public GetOfSearchValidation()
        {
            RuleFor(asset => asset.ProjectId).NotEqual(Guid.Empty);
        }
    }
}

using FluentValidation;
using SpyCheif.Application.Feature.Query.AssetQuery.GetAll;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class GetAllAssetValidation : AbstractValidator<AssetGetAllQueryRequest>
    {
        public GetAllAssetValidation()
        {
            RuleFor(asset => asset.ProjectId).NotEqual(Guid.Empty);
        }
    }
}

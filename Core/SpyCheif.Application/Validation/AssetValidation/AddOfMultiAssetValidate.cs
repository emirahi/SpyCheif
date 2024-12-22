using FluentValidation;
using SpyCheif.Application.Feature.Command.AssetCommand.AddOfMulti;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class AddOfMultiAssetValidate : AbstractValidator<AssetAddOfMultiCommandRequest>
    {
        public AddOfMultiAssetValidate()
        {
            RuleFor(asset => asset.AssetTypeId).NotEqual(Guid.Empty);
            RuleFor(asset => asset.ProjectId).NotEqual(Guid.Empty);
            RuleFor(asset => asset.FileId).NotEqual(Guid.Empty);
        }

    }
}

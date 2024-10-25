using FluentValidation;
using SpyCheif.Application.Feature.Command.AssetCommand.Add;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class AddAssetValidate : AbstractValidator<AssetAddCommandRequest>
    {
        public AddAssetValidate()
        {
            RuleFor(asset => asset.ProjectId).NotNull();
            RuleFor(asset => asset.AssetTypeId).NotNull();
            RuleFor(asset => asset.Value).MinimumLength(3).NotNull();
        }
    }
}

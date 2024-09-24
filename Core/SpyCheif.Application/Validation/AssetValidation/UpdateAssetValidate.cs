using FluentValidation;
using SpyCheif.Application.Feature.Command.AssetCommand.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class UpdateAssetValidate : AbstractValidator<AssetUpdateCommandRequest>
    {
        public UpdateAssetValidate()
        {
            RuleFor(asset => asset.Id).NotNull();
            RuleFor(asset => asset.AssetTypeId).NotNull();
            RuleFor(asset => asset.Value).MinimumLength(3).NotNull();

        }
    }
}

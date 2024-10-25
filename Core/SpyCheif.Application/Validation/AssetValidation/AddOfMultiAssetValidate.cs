using FluentValidation;
using SpyCheif.Application.Feature.Command.AssetCommand.AddOfMulti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class AddOfMultiAssetValidate : AbstractValidator<AssetAddOfMultiCommandRequest>
    {
        public AddOfMultiAssetValidate()
        {
            RuleFor(asset => asset.AssetTypeId).NotEqual(Guid.Empty);
            RuleFor(asset => asset.ProjectId).NotEqual(Guid.Empty);
            RuleFor(asset => asset.Value).Must(assets => assets.Count > 0);
        }

    }
}

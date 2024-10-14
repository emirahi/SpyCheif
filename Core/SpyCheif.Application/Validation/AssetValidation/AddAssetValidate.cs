using FluentValidation;
using SpyCheif.Application.Dto.AssetDtos;
using SpyCheif.Application.Feature.Command.AssetCommand.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class AddAssetValidate:AbstractValidator<AssetAddCommandRequest>
    {
        public AddAssetValidate()
        {
            RuleFor(asset => asset.ProjectId).NotNull();
            RuleFor(asset => asset.AssetTypeId).NotNull();
            RuleFor(asset => asset.Value).MinimumLength(3).NotNull();
        }
    }
}

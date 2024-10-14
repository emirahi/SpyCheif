using FluentValidation;
using SpyCheif.Application.Feature.Query.AssetQuery.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class GetAssetValidation:AbstractValidator<AssetGetQueryRequest>
    {
        public GetAssetValidation()
        {
            RuleFor(asset => asset.Id).NotEqual(Guid.Empty);
            RuleFor(asset => asset.ProjectId).NotEqual(Guid.Empty);
        }
    }
}

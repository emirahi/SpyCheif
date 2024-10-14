using FluentValidation;
using SpyCheif.Application.Feature.Query.AssetQuery.GetAll;
using SpyCheif.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class GetAllAssetValidation:AbstractValidator<AssetGetAllQueryRequest>
    {
        public GetAllAssetValidation()
        {
            RuleFor(asset => asset.ProjectId).NotEqual(Guid.Empty);
        }
    }
}

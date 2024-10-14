using FluentValidation;
using SpyCheif.Application.Feature.Query.AssetQuery.GetOfSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCheif.Application.Validation.AssetValidation
{
    public class GetOfSearchValidation:AbstractValidator<AssetGetOfSearchQueryRequest>
    {
        public GetOfSearchValidation()
        {
            RuleFor(asset => asset.ProjectId).NotEqual(Guid.Empty);
        }
    }
}

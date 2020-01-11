using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using RealestateManager.Web.Core.Entities;
using RealestateManager.Web.Core.Inputs;
using RealestateManager.Web.Core.Repository.Contracts;
using RealestateManager.Web.Core.Types;

namespace RealestateManager.Web.Services.Mutation
{
    public class PropertyMutation: ObjectGraphType
    {
        public PropertyMutation(IPropertyRepository propertyRepository)
        {
            Name = "AddPropertyMutation";

            Field<PropertyType>(
                "addProperty",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PropertyInputType>> {Name = "property"}),
                resolve: context =>
                {
                    var property = context.GetArgument<Property>("property");
                    return propertyRepository.Add(property);
                });
        }
    }
}

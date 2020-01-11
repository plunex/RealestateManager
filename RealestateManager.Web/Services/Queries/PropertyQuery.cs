using System.Collections.Generic;
using GraphQL.Types;
using RealestateManager.Web.Core.Repository.Contracts;
using RealestateManager.Web.Core.Types;

namespace RealestateManager.Web.Services.Queries
{
    public class PropertyQuery: ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository)
        {
            Field<ListGraphType<PropertyType>>(
                "properties",
                resolve: context => propertyRepository.GetAll());

            Field<PropertyType>(
                "property",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => propertyRepository.GetById(context.GetArgument<int>("id")));
        }
    }
}
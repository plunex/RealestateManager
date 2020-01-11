using GraphQL;
using RealestateManager.Web.Services.Mutation;
using RealestateManager.Web.Services.Queries;

namespace RealestateManager.Web.Services.Schema
{
    public class RealEstateSchema: GraphQL.Types.Schema
    {
        public RealEstateSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<PropertyQuery>();
            Mutation = resolver.Resolve<PropertyMutation>();
        }
    }
}

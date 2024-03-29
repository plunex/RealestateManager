using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace RealestateManager.Web.Core.Inputs
{
    public class PropertyInputType: InputObjectGraphType
    {
        public PropertyInputType()
        {
            Name = "PropertyInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("city");
            Field<StringGraphType>("family");
            Field<StringGraphType>("street");
            Field<IntGraphType>("value");
        }
    }
}

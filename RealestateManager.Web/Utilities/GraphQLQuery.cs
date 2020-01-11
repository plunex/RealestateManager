using Newtonsoft.Json.Linq;

namespace RealestateManager.Utilities
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; } 
    }
}
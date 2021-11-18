using GraphQL;
using GraphQL.Types;
using MyShop.API.Queries;

namespace MyShop.API
{
    public class RootSchema : Schema
    {
        public RootSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<RootQuery>();
        }
    }
}

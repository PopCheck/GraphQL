using GraphQL;
using GraphQL.Types;
using MyShop.API.Repositories;
using MyShop.API.Types;
using System;

namespace MyShop.API.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(CustomerRepository customerRepository)
        {
            FieldAsync<ListGraphType<CustomerType>>("customers", resolve: async (context) =>
            {
                return await customerRepository.GetAllAsync();
            });

            FieldAsync<CustomerType>("customer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: async (context) =>
                {
                    try
                    {
                        int id;

                        if (!int.TryParse(context.GetArgument<string>("id"), out id))
                        {
                            context.Errors.Add(new ExecutionError("Error: Use number for id parameter"));
                            return null;
                        }

                        return await customerRepository.GetAsync(id);
                    }
                    catch(Exception ex)
                    {
                        context.Errors.Add(new ExecutionError(ex.Message));
                        return null;
                    }
                });
        }
    }
}

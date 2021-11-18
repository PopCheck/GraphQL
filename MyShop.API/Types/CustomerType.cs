using GraphQL.Types;
using MyShop.API.Models;

namespace MyShop.API.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(t => t.Customerid).Description("Id of customer");
            Field(t => t.Companyname).Description("The name of company");
            Field(t => t.City, nullable: true);
            Field(t => t.Country, nullable: true);
        }
    }
}

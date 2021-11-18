using Microsoft.EntityFrameworkCore.Migrations;

namespace Theta.Migrations
{
    public partial class spgetOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp =
@"CREATE PROCEDURE obtain_order_with_joins
AS
SELECT o.[OrderId]
      ,o.[Date]
      ,o.[CustomerId]
      ,o.[ProductId]
	  ,c.[FirstName]
	  ,c.[LastName]
	  ,c.[CustomerId]
	  ,p.[ProductId]
	  ,p.[Name]
	  ,p.[Price]
  
  FROM [RetailDb].[dbo].[Order] o
  INNER JOIN [RetailDb].[dbo].[Customer] c
  ON o.[CustomerId] = c.[CustomerId]
  INNER JOIN [RetailDb].[dbo].[Product] p
  ON o.[ProductId] = p.[ProductId];

GO";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

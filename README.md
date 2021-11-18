# Theta-project

This project composes of the API and the react application. 

### SETUP

* Clone this repository.
* Navigate to the directory: Theta-project/Theta. Here run `docker-compose up` to initialize a new SQL Server database running on docker.
* run `dotnet tool install --global dotnet-ef`
* `dotnet ef migrations add retail-db`
* `dotnet ef database update`
* Open the sln file and run it. You are able to interact with the API using the "swagger" UI that will open in the browser.

It is necessary for the api to run on "https://localhost:5001" as the frontend fetch requests use that path. So make sure it is not using IIS Express but rather "Theta" when you start it. 

For the react app
* navigate to the react-app folder
* run `npm install`
* now you can run `npm start` and it open on a browser. The port does not matter as the CORS allows for anything.

### Notes

This uses the ORM called EF Core to connect to the SQL server database. It also connects using the SQL client in order to check to pass in sample data. Raw sql was typically used apart from one function. The order service's to obtain all orders, as well as customers and products. Note that two stored procedures will automatically be added into the SQL Server database, this is because I added them to the migrations. I made these as sql joins don't work in EF Core's raw sql, and require use of `Include` methods to generate the SQL Code first, however in this code I still decided to use the code first approach.

The stored procedure is: 
```
CREATE PROCEDURE updated_obtain_order_with_joins
AS
SELECT o.[OrderId]
      ,o.[Date]
      ,o.[CustomerId]
      ,o.[ProductId]
      ,c.[FirstName]
      ,c.[LastName]
      ,p.[ProductId]
      ,p.[Name]
      ,p.[Price]
  
  FROM [RetailDb].[dbo].[Order] o
  INNER JOIN [RetailDb].[dbo].[Customer] c
  ON o.[CustomerId] = c.[CustomerId]
  INNER JOIN [RetailDb].[dbo].[Product] p
  ON o.[ProductId] = p.[ProductId];

GO
```
The other procedure is very similar, apart from querying the ProductId twice.

# OrdersAPI

The project is using :
.Net Core 2.2 
Entity Framework Core
Swagger
log4net
SQL database . 
Authentication with JWT 


before run the project : 
You can change the connection string in 
appsettings.json 

  "ConnectionStrings": {
    "sqlConnection": "Server=(localdb)\\MSSQLLocalDB;Database=OrdersDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }




Getting started :
When you run the project the first time will create the database and populate with the admin user 
test users : 
username : admin
password : admin



when the project is builded and run  will open the browser in the swagger page , that was used to create the documenation about the functions
the project contais a Unit test and Integration Test


<img src="https://github.com/prea/OrdersAPI/blob/master/swagger_orders.png">

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

To Test using the Swagger .

1 - Click in the Authorization/token method and click in Try it out .  will open a textarea to change  the username and password .
change to 
username : admin
password : admin
after that click in Execute .
it will return the  access_token :
<img src="https://github.com/prea/OrdersAPI/blob/master/login.png">
2 - Copy the access_token and click in the look in the header of the method  , it will open a popup to paste the token .
you need include the key afer Beare  . 
exame Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyIxIiwiMSJdLCJqdGkiOiIxYzA3NmQ5Y2NkZTQ0ZTJhYWU2MjhhMTcxZTFlMjVlZSIsIm5iZiI6MTU3MDIwODg4MSwiZXhwIjoxNTcwMjE0ODgxLCJpYXQiOjE1NzAyMDg4ODEsImlzcyI6Ik9yZGVyQVBJSXNzdWVyIiwiYXVkIjoiT3JkZXJBUElBdWRpZW5jZSJ9.zydtM8uNJ9aJ2geYotUO4ImO3HCPtrNFt7q3HR4Ua-A6c-ONoF-mWDpbmOuB0-yPpe205ypu5dEa8LB7Klk8R51AJDGSzZN8Ty6vw-4Mzrdb37-Q4AsmpGopwbMYdIvcbemOYLEZYfKPrMnyge93EUfF9mPqRtGdHeMRIuuTq6xklY9SldeCwcZYLVwyuz3UdbnWphohayr8WOskeN5fEKIVqf-RewGwYgD6ugoIVxR_D-gkPQ1v7KYtp5A5G1MgvxVp2jwg7tocU6xTW8rs7mMWqfwsJz6d_izk16cu8-zkMrK8ROk-vZy8ZXf_r_ou-N4_zMLPMKCFqxfXQgM3Wg

<img src="https://github.com/prea/OrdersAPI/blob/master/token.png">
than click in Authorize , Now you will be able to test the other methods 

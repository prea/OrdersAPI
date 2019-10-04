# OrdersAPI

The project was made using:<br>
.Net Core 2.2 <br>
Entity Framework Core<br>
Swagger<br>
log4net<br>
SQL database <br>
Authentication with JWT <br>


Before build the project  : <br>
You can change the connection string in appsettings.json <br>

  "ConnectionStrings": {
    "sqlConnection": "Server=(localdb)\\MSSQLLocalDB;Database=OrdersDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }




Getting started:<br>
When you run the project the first time, it will create the database and populate with the admin user.<br>
username : admin<br>
password : admin<br>

when the project is built and is running, it will open the browser in the swagger page, that was used to create the documetation about the methods. The project contains a Unit test and Integration Test<br>

<img src="https://github.com/prea/OrdersAPI/blob/master/swagger_orders.png">

To Test using the Swagger .

1 - Click in the Authorization/token method then click in Try it out. <br>
It will open a textarea to change the username and password.<br>
change to <br>
username : admin<br>
password : admin<br>
after that, click in Execute. It will return the access_token :<br>
<img src="https://github.com/prea/OrdersAPI/blob/master/login.png">
2 - Copy the access_token then click in the look in the header of the method, it will open a popup to paste the token.<br>
you need include the key afer Beare.<br>
example:<br>
Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyIxIiwiMSJdLCJqdGkiOiIxYzA3NmQ5Y2NkZTQ0ZTJhYWU2MjhhMTcxZTFlMjVlZSIsIm5iZiI6MTU3MDIwODg4MSwiZXhwIjoxNTcwMjE0ODgxLCJpYXQiOjE1NzAyMDg4ODEsImlzcyI6Ik9yZGVyQVBJSXNzdWVyIiwiYXVkIjoiT3JkZXJBUElBdWRpZW5jZSJ9.zydtM8uNJ9aJ2geYotUO4ImO3HCPtrNFt7q3HR4Ua-A6c-ONoF-mWDpbmOuB0-yPpe205ypu5dEa8LB7Klk8R51AJDGSzZN8Ty6vw-4Mzrdb37-Q4AsmpGopwbMYdIvcbemOYLEZYfKPrMnyge93EUfF9mPqRtGdHeMRIuuTq6xklY9SldeCwcZYLVwyuz3UdbnWphohayr8WOskeN5fEKIVqf-RewGwYgD6ugoIVxR_D-gkPQ1v7KYtp5A5G1MgvxVp2jwg7tocU6xTW8rs7mMWqfwsJz6d_izk16cu8-zkMrK8ROk-vZy8ZXf_r_ou-N4_zMLPMKCFqxfXQgM3Wg

<img src="https://github.com/prea/OrdersAPI/blob/master/token.png">
then click in Authorize , Now you will be able to test the other methods.

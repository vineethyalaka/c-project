Implement a RESTful web service that performs CRUD operations (Create, Read, Update, and Delete) for a Vehicle
entity.

Create table named vehicle in the Database as follows : 

Create table vehicle
(
Id int primary key Identity(1,1),
Year int CHECK (Year>=1950 and year<=2050) Not Null,
Make varchar(50) Not Null,
Model varchar(50) Not Null
)

Connect the database to the Api Model and name it as you choose. Create the Api using Data Model.

Run the C# code.

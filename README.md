# .NET 6 Jwt Authentication + Docker Assignment

# Task # 1
Create a simple web API in Dotnet 6 which will have an authentication mechanism using
Microsoft identity with JWT Authentication schema. This API will be responsible for performing
CRUD operations on these entities. These entities will have attributes as follows.
Patient (ID : GUID , Name : string, Contact : string);
Visit (ID : GUID , VisitDate : DateTime);
Doctor (ID : GUID , Name : string , Contact : string)
A patient can have multiple visits but a single visit can only be made by only one patient.
Where patients can have multiple doctors and doctors can have multiple patients.
You need to make sure your table has these attributes plus all other attributes which will be
used to define the relationship between entities.
You need to ensure that you are using the following tools in this API.
● Entity Framework (Code first approach)
● Any database engines (Postgres, or MySQL). (Please don’t use Microsoft SQL Server)

# Task # 2
Create a Middleware component for this API which will be responsible for logging and exception
handling. Every request and response will be logged in Elasticsearch. Elasticsearch Url will be
configurable from the environment variables. ()

# Task # 3
Dockerize this API and create a readme file for deployment guidelines on any server using
docker. This should also involve the environment variables your API needs.
Note: You will push this project on GitHub with proper commit messages and will share the URL
of that repository for our review. You will be evaluated on the basis of the number of tasks

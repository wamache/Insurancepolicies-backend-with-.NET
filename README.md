# Insurancepolicies-backend-with-C#
simple Insurance Policy Management System using .NET

Install .NET SDK: 
  Go to the official .NET download page: https://dotnet.microsoft.com/en-us/download
  
Add .NET to PATH:
  1 Open the Start Menu and search for Environment Variables. 
  2 Select "Edit the system environment variables."
  3 In the System Properties window, click the Environment Variables button.
  Under System Variables, find the Path variable and click Edit.
  4 Ensure the following paths (or similar) are included
  C:\Program Files\dotnet\

Create new dotnet application
  dotnet new webapi -n Insurancepolicies
  cd Insurancepolicies

Packeges 
 	dotnet add package Pomelo.EntityFrameworkCore.MySql
	dotnet add package BCrypt.Net-Next
	dotnet tool install --global dotnet-ef
	dotnet tool update --global dotnet-ef
	dotnet add package Microsoft.EntityFrameworkCore
	dotnet add package Microsoft.EntityFrameworkCore.Design
	dotnet add package Pomelo.EntityFrameworkCore.MySql  # For MySQL
	dotnet add package Microsoft.AspNetCore.Mvc
	dotnet add package System.ComponentModel.DataAnnotations

Apply Migrations:
	dotnet ef migrations add InitialCreate
	dotnet ef database update

Build and run:
	dotnet build
	dotnet run

Test APIs:
localhost:5138/swagger/

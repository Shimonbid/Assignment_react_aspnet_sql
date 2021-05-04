# Assignment_react_aspnet_sql
Collection of information for user search by a proxy server built by react app, asp.net webapi, sql server.

## Development Enviroment
1. Visual Studio Code (Client)
2. Visual Studio 2019 (Server)
3. SQL Server (DB)

## Projects in Solution
1. WebAPI
2. react-app

## WebAPI
1. Create project Asp.net Core WebAPI => WebAPI
2. Add Packages: EntityFrameworkCore / .SqlServer /.Tools => CodeGeneration / .Designs / .Utils 
4. Create Folder Model => Add Classes UserQueries, Results, ResultsView (json) => Add UserQueriesContext
5. DB Config: Startup ConfigureServices + EnableCors => appsettings.json ConnectionStrings
6. DB Create: Package Manager Console => Add-Migration "InitialCreate" => Update-Database => SQLQuery.sql (Create Tables PK/FK + Stored Procedure)
7. Controllers => Add => new scaffolded item => Class and ClassContext => CRUD (not used)
8. ValuesController.cs => GetResults (query) => get results from WebClient(DuckDuckGoAPI) => save db query, time and results => return results to user
9. ValuesController.cs => GetResultsFromDate (date) => get db results of user from date
10. Swagger => Run and Check

## react-app
1. Download and Install Javascript Library: nodejs.org
2. SolutionDir => cmd => npx create-react-app NameApp
3. cd NameApp => code . => npm start
4. Main => react-app/src/index.js
5. Submit Search => get links by paging

## angular-app (not used)
1. npm install -g @angular/cli
2. ng new NameApp => y,n,enter
3. cd NameApp => code . => ng serve --o

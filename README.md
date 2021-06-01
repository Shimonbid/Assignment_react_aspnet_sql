# UserQueriesInfo
Collection of information for user search by a proxy server built by react app, asp.net webapi, sql server.

### The User Scenario
1. User(query) => WebAPI => WebClient(DuckDuckGoAPI)
2. WebClient(DuckDuckGoAPI) => WebAPI(Serialize(results)) => WebAPI(Save db: query, time and results) 
3. WebAPI(links) => React(Links by paging) => User(Links)

### The Developer Scenario
1. Developer(fromdate) => WebAPI => DB
2. DB => All results from date for this user

### Development Enviroment
1. Visual Studio Code (Client)
2. Visual Studio 2019 (Server)
3. SQL Server (DB)

## WebAPI
### Model
1. CodeFirst (Entities => DB)
2. Create project Asp.net Core WebAPI => NameAPI
3. Add Packages: EntityFrameworkCore / .SqlServer /.Tools => CodeGeneration / .Designs / .Utils 
4. Create Folder Model => Add Classes UserQueries, Results, ResultsView (json) => Add UserQueriesContext
5. DB Config: Startup ConfigureServices + EnableCors => appsettings.json ConnectionStrings
6. DB Create: Package Manager Console => Add-Migration "InitialCreate" => Update-Database
### Controller
8. Controller => Add => new scaffolded item => Class and ClassContext => CRUD
9. ValuesController.cs => GetResults (query) => Serialize results from WebClient(DuckDuckGoAPI) => save db query, time and results => return results to user
10. ValuesController.cs => GetResultsFromDate (date) => get db results of user from date
11. Swagger => Run and Check

## DAL
1. DBFirst (DB => Entities)
1. Support for Stored Procedure
3. Create Tables PK/FK + Stored Procedure
4. Create project Asp.net (.NetFramework) => DAL
5. Create Folder Model => Add Data => Ado.net => NameServer + NameDB => Tables + SP
6. Add Class DAL => DBInfoEntities db => Methods(CRUD) => SingleTon (Design Patterns)
7. WebAPI: Add Project Reference + App.config + EntityFramework Package

## ReactApp (react-app)
1. Download and Install Javascript Library: nodejs.org
2. SolutionDir => cmd => npx create-react-app NameApp
3. cd NameApp => code . => npm start
4. Main => react-app/src/index.js
5. Search => get links by paging

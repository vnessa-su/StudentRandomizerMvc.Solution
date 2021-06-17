# Student Randomizer MVC

## Technologies Used

- C# / .NET 5 Framework / MySQL / Entity

### Description
Note: This application was generated to get the client side of the application for calling the Student Randomizer API: https://github.com/Brenthubbard/StudentRandomizer.Solution.
Users can add a list of students into the application to generate a list of groups randomly. Integrated with a scoring methodology, each group will have a score where the lower the score, the better diverse the group will be. The application will generate groups with the lowest scores first but can also regenerate groups if the groups are not suitable for the user.

## Setup Instructions
- Note: In order to run this application you will need to clone down the API from `https://github.com/vnessa-su/StudentRandomizerMvc.Solution`.
1. Navigate to destination directory using `cd <directory name>` inside of the terminal.
2. Clone repository to destinated directory using the syntax `git clone https://github.com/vnessa-su/StudentRandomizerMvc.Solution.git`.
3. Open the repository using `code StudentRandomizerMvc.Solution`.
4. Nagivate to project folder using `cd StudentRandomizerMvc`
5. `dotnet restore` to install dependencies.
6. `dotnet run` to run application on server http://localhost:4000/
- Note: In order to run this on one machine you will have to configure your launchSettings.json to the application url http://localhost:4000/ or configure your WebHostDefaults in Program.cs with the following code `webBuilder.UseUrls("http://localhost:4000/");`.

#### API Setup Instructions
1. Clone repo in to destinated directory
2. Change directory to StudentRandomizer.Solution/StudentRandomizer
3. Install Dependencies with `dotnet restore`
4. Create file name appsettings.json and enter following: `{ "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=Student_Randomizer;uid=[user mysql username];pwd=[user mysql password];" } }`
5. To create the database needed using the migrations tool `dotnet ef database update`
6. To watch for live changes `dotnet watch run` in http://localhost:5000/

#### Launching API
1. Navigate to the root StudentRandomizer file
2. Using the command `dotnet run` in your terminal it will launch http://localhost:5000/ for you
3. Access postman to make requests using the API

#### Using Swagger
- To use swagger nagivate to the http://localhost:5000/swagger page.
- When running the API you can use swagger to document your api calls.
- Swagger lets you see all the different requests accessed in the controller.
- To test one of the requests simply click on the request(GET/POST/PUT/DELETE) then click try it out and then execute.
- You will see the response body and the request URL for documentation.

### Known Bugs
- Currently there are optimizations for the database that needs to get done. In order for the user to use this application they would have to seed their own data using migrations to properly function the application. Work in progress is to get a more intuitive database that can update based on API calls.
- Not all Views complete for CRUD functionality

### License

[MIT License](license)

#### Contact Information
- Min Chang: minchangmhc at gmail dot com
- Vanessa Su: vnessa.su at gmail dot com
- Jonathan Stull: jonathan.d.stull at gmail dot com
- Brent Hubbard: hubbardbrent at hotmail dot com
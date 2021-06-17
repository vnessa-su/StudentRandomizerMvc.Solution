# Student Randomizer MVC

#### MVC application for generating groups weighted by a score

#### By Brent Hubbard, Jonathan Stull, Min Change, Vanessa Su

## Technologies Used

- C#
- .NET 5 Framework
- Entity Framework Core
- RestSharp

### Description

_Note: This application was generated to get the client side of the application for calling the Student Randomizer API: https://github.com/Brenthubbard/StudentRandomizer.Solution._

Web app displays all students, matches, and groups stored in a database. Users can generate groups, of all of the students in the database, of a desired size. The group selections are optimized by how many times the people in the group have been in a group together before, with preference for less times paired with others in a group. Then the user has the option to save the generated groups to the database or generate a new set of groups.

## Setup Instructions

### Prerequisites

- [.NET](https://dotnet.microsoft.com/)
- A text editor like [VS Code](https://code.visualstudio.com/)

### Installation

1. Clone repository: `git clone https://github.com/vnessa-su/StudentRandomizerMvc.Solution.git`.
2. Navigate to the `/StudentRandomizerMvc.Solution` directory
3. Open with your preferred text editor to view the code base

- #### **Run the Program**

1. Nagivate to project folder using `cd /StudentRandomizerMvc`
2. `dotnet restore` to install dependencies.
3. `dotnet run` to run application server
4. Open http://localhost:4000/ in your preferred browser

_Note: In order to run this on one machine you will have to configure your launchSettings.json to the application url http://localhost:4000/ or configure your WebHostDefaults in Program.cs with the following code `webBuilder.UseUrls("http://localhost:4000/");`._

#### **API Setup Instructions**

In order to be able to run the MVC web app with full functionality, you will need to also run the associate database API.

See full setup and launch instruction here: `https://github.com/Brenthubbard/StudentRandomizer.Solution`

### Known Bugs

- Currently there are optimizations for the database that needs to get done. In order for the user to use this application they would have to seed their own data using migrations to properly function the application. Work in progress is to get a more intuitive database that can update based on API calls.
- Not all Views complete for CRUD functionality
- Group score is not optimized when extra students are added to the groups

### License

[MIT License](license)

#### Contact Information

- Min Chang: minchangmhc@gmail.com
- Vanessa Su: vnessa.su@gmail.com
- Jonathan Stull: jonathan.d.stull@gmail.com
- Brent Hubbard: hubbardbrent@hotmail.com

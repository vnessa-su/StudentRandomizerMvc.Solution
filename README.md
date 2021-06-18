# Student Randomizer MVC

#### MVC application for generating groups weighted by a score

#### By Brent Hubbard, Jonathan Stull, Min Change, Vanessa Su

## **Table of Contents**

<br />

* <a href="#about-the-student-randomizer-MVC-application">About the Student Randomizer MVC Application</a>
    * <a href="#technologies-used">Technologies Used</a>
* <a href="#Set-Up-instructions">Set Up Instructions</a>
* <a href="#API-setup-instructions">API Setup Instructions</a>
* <a href="#known-bugs">Known Bugs</a>
* <a href="#License">License</a>
* <a href="#Acknowledgements">Acknowledgements</a>
* <a href="#Contact-Information">Contact Information</a>

<br />

### About the Student Randomizer MVC Application

<br />

_Note: This application was generated to get the client side of the application for calling the Student Randomizer API: https://github.com/Brenthubbard/StudentRandomizer.Solution._

Web app displays all students, matches, and groups stored in a database. Users can generate groups, of all of the students in the database, of a desired size. The group selections are optimized by how many times the people in the group have been in a group together before, with preference for less times paired with others in a group. Then the user has the option to save the generated groups to the database or generate a new set of groups.

<br />

## Technologies Used

<br />

- C#
- .NET 5 Framework
- Entity Framework Core
- RestSharp

<br />

## Setup Instructions

### Prerequisites

<br />

- [.NET](https://dotnet.microsoft.com/)
- A text editor like [VS Code](https://code.visualstudio.com/)

<br />

### Installation

<br />

1. Clone repository: `git clone https://github.com/vnessa-su/StudentRandomizerMvc.Solution.git`.
2. Navigate to the `/StudentRandomizerMvc.Solution` directory
3. Open with your preferred text editor to view the code base

<br />

- #### **Run the Program**

<br />

1. Nagivate to project folder using `cd /StudentRandomizerMvc`
2. `dotnet restore` to install dependencies.
3. `dotnet run` to run application server
4. Open http://localhost:4000/ in your preferred browser

_Note: In order to run this on one machine you will have to configure your launchSettings.json to the application url http://localhost:4000/ or configure your WebHostDefaults in Program.cs with the following code `webBuilder.UseUrls("http://localhost:4000/");`._

<br />

#### **API Setup Instructions**

<br />

In order to be able to run the MVC web app with full functionality, you will need to also run the associate database API.

See full setup and launch instruction here: `https://github.com/Brenthubbard/StudentRandomizer.Solution`

<br />

### Known Bugs

<br />

- Currently there are optimizations for the database that needs to get done. In order for the user to use this application they would have to seed their own data using migrations to properly function the application. Work in progress is to get a more intuitive database that can update based on API calls.
- Not all Views complete for CRUD functionality
- Group score is not optimized when extra students are added to the groups

<br />

### License

<br />

Copyright (c) 2021 by [Vanessa Su](https://github.com/vnessa-su), [Min Chang](https://github.com/M-H-Chang), [Brent Hubbard](https://github.com/Brenthubbard), and [Jonathan Stull](https://github.com/jonathanstull)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM.cs, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

<br />

## **Acknowledgements**

<br />

This project was developed alongside the [LearnHowToProgram curriculum](learnhowtoprogram.com) at Epicodus, a coding bootcamp in Portland, Oregon. This project would not have been possible without the collaboration of [Vanessa Su](https://github.com/vnessa-su), [Min Chang](https://github.com/M-H-Chang), [Brent Hubbard](https://github.com/Brenthubbard), and [Jonathan Stull](https://github.com/jonathanstull).

In particular, the developers would like to acknowledge Vanessa Su's algorithmic talents for building a recursive depth-first search and group generation algorithms. Min Chang lended his talent to group scoring, without which there would be no functional distinction from groups with high pairing frequencies. Brent Hubbard lent his abilities to MVC implementation and back- and front-end controller implementation, without which there would be no [user interface](https://github.com/vnessa-su/StudentRandomizerMvc.Solution.git). Jonathan Stull developed and implemented database design and facilitated the overall development of the API, including its models and controllers, without which this API would not be.

This app would not have been possible without the tutelage of Epicodus instructors [Erik Irgens](https://github.com/erik-t-irgens) and [James Henager](https://github.com/jhenager).

<br />

#### Contact Information

- Min Chang: minchangmhc@gmail.com
- Vanessa Su: vnessa.su@gmail.com
- Jonathan Stull: jonathan.d.stull@gmail.com
- Brent Hubbard: hubbardbrent@hotmail.com

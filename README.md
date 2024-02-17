# Course API for Automation of Bootcamp Cohort

This .NET project aims to provide a streamlined API for managing courses for a bootcamp cohort. The API facilitates the automation of registering students into various bootcamp courses effortlessly.


## Features

- Course Management: Easily create, update, retrieve, and delete courses.
- Student Registration: Automate the process of registering students into specific courses.
- Flexible Integration: Seamlessly integrate the API with existing bootcamp management systems.
- Data Validation: Ensure data integrity and consistency through robust input validation.
- Logging and Error Handling: Capture and handle errors effectively for improved troubleshooting and maintenance.

## Tech Stack

- ASP.NET Core
- Entity Framework Core: For efficient data access and management.
- C#: Leverage the versatility and performance of C# for implementing business logic and data manipulation.
- Swagger UI: To Provide interactive API documentation using Swagger UI for easy exploration and testing.
- Serilog: For structured logging to gain insights into application behavior and troubleshoot issues effectively.
## Setup Instructions

1. Clone the Repository: Clone the repository to your local machine.

```bash
https://github.com/damosman/CourseRepo.git

```
2. Install Dependencies: Navigate to the project dir. and install the necessary dependencies using NuGet Package Manager or .NET CLI.

```bash
cd CourseRepo
dotnet restore
```

3. Database Configuration: Configure the database connection string in the `appsettings.json` file to connect to your preferred database provider.

4. Database Migrations: Apply database migrations to create the necessary tables in the database.

```bash
update-database
```

5. Run the Application: Start the ASP.NET Core application.

```bash
dotnet run
```

6. Explore the API: Navigate to https://localhost:44306/swagger in your preferred web browser to access the Swagger UI and explore the API endpoints.
## API Endpoints

The API provides the following endpoints for managing courses:

- `GET` /api/courses: Retrieves a list of all courses in the bootcamp.
- `GET` /api/courses/{id}: Retrieve the details of a specific course by its ID.
- `POST` /api/courses: Create a new bootcamp course.
- `PUT` /api/courses/{id}: Update an existing course.
- `DELETE` /api/courses/{id}: Delete a course by ID.

## License

This project is licensed under the [MIT](https://choosealicense.com/licenses/mit/) License. 

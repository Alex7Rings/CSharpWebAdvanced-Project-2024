# CSharpWebAdvanced-Project-2024

MoonGameRev: 
MoonGameRev is a web application for gaming enthusiasts to discover, review, and discuss their favorite games and news related to the gaming industry. The platform allows users to browse upcoming games, and trending titles, read news articles, and interact with other users through reviews and comments.


![Screenshot 2025-02-03 115553](https://github.com/user-attachments/assets/b18f1f79-bc00-4358-8a88-55c627f712b2)

# 1. Features: 
- Game Catalog: Browse a catalog of games, including upcoming releases and trending titles.
- News Section: Stay up-to-date with the latest news and articles from the gaming industry.
- User Reviews: Read and write reviews for games, sharing opinions and experiences with the community.
- User Authentication: Secure user authentication and authorization using ASP.NET Identity.
- Admin Panel: Admin panel for managing games, news articles, and user accounts.
- Responsive Design: Mobile-friendly design for seamless browsing on any device.

# 2. Technologies Used:

- ASP.NET Core: Backend framework for building web applications.
- Entity Framework Core: Object-relational mapping (ORM) framework for database interactions.
- HTML/CSS/JavaScript: Frontend technologies for building the user interface.
- Bootstrap: Frontend framework for responsive and mobile-first design.
- MS SQL Server: Relational database management system for storing application data.
- GitHub: Version control and collaboration platform for managing project code.

# 3. Getting Started:

Set the Startup Project:
- Set MoonGameRev.Web as the startup project in your development environment.

Update the Database:
- Add the connection string for your database in the appropriate configuration file.
- Use the Package Manager Console in Visual Studio and ensure that MoonGameRev.Data is set as the default project.
- Update-Database

Run the Web Application and Web API:
- Select both MoonGameRev.Web and MoonGameRev.Api projects as startup projects.
- Start the projects by choosing "Start without debugging" to run both the web application and the web API.


# 4. Administrator Setup Instructions
The application includes an administrator role for enhanced management capabilities. Follow these steps to add an administrator:

Create an Account:
- Register an account through the web application by accessing the registration page via either "User/login" or "User/register".
  
Elevate Account to Journalist:
- After creating the account, navigate to the "/Journalist/Become" endpoint to elevate the account to journalist status.
  
Configure Administrator Email:
- In the MoonGameRev.Common.GeneralApplicationConstants file, locate the public const string DevAdminEmail field.
- Set the email address of the desired account to be assigned as an administrator.

Upon completing these steps, the designated administrator will gain access to additional functionalities, including the ability to assign moderator roles to other users through the "/User/AddToModerator" endpoint.


  

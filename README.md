# RoboConnect

RoboConnect is an ASP.NET Core web application and RESTful API platform designed to manage robotics service requests, provider interactions, and community discussion boards.

---

## Features

- **Robot Request Management:** Submit, track, and process customized robotics hardware and automation requests.
- **Community Discussions:** Interactive forum for discussing robotics technology, troubleshooting, and project ideas.
- **RESTful API & Swagger:** Full OpenAPI/Swagger documentation for testing and integrating external client apps.
- **Database Persistence:** Entity Framework Core integration configured with Microsoft SQL Server.
- **Modern MVC Architecture:** Clean separation of concerns across Models, Views, Controllers, and Services.

---

## Tech Stack

- **Framework:** .NET 10 / ASP.NET Core (MVC & Web API)
- **ORM:** Entity Framework Core
- **Database:** Microsoft SQL Server
- **API Documentation:** Swagger / Swashbuckle
- **Frontend:** Bootstrap, HTML5, CSS3, JavaScript

---

## Project Structure

```text
RoboConnect/
├── Controllers/       # MVC and Web API endpoints
├── Data/              # DbContext and database seed data
├── Migrations/        # EF Core database migrations
├── Models/            # Data models and view models
├── Properties/        # Launch profiles and settings
├── Services/          # Core business logic and helpers
├── Views/             # Razor views for UI rendering
├── wwwroot/           # Static web assets (CSS, JS, images)
├── appsettings.json   # Configuration settings (secrets excluded)
└── Program.cs         # Dependency injection and HTTP pipeline
```

---

## Getting Started

### Prerequisites

- [.NET SDK 10.0+](https://dotnet.microsoft.com/)
- [SQL Server](https://www.microsoft.com/sql-server/) (or a cloud-hosted SQL Server instance)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio 2022+](https://visualstudio.microsoft.com/)

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Lh797/RoboConnect.git
   cd RoboConnect
   ```

2. **Configure connection string:**
   Update `appsettings.json` or use user secrets to specify your SQL Server connection:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Data Source=YOUR_SERVER;Initial Catalog=Roboconnect;User ID=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True"
     }
   }
   ```

3. **Apply database migrations:**
   ```bash
   dotnet ef database update
   ```

4. **Run the application:**
   ```bash
   dotnet run
   ```

5. **Access the application:**
   - Web UI: `http://localhost:5000` (or `https://localhost:5001`)
   - Swagger API Docs: `http://localhost:5000/swagger`

---

## License

This project is licensed under the MIT License - see the LICENSE file for details.

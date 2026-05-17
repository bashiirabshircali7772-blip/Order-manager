# Order-manager

ASP.NET Core 9 Razor Pages + Entity Framework Core + SQLite

---

## Features
- **List** all orders in a sortable HTML table
- **Create** new orders via a validated form
- **Edit** existing orders
- **Delete** orders with a confirmation screen

## Project Structure

```
ASPCRUDAssignment/
├── Models/
│   └── Order.cs                   # Entity with Id, CustomerName, ProductName, Quantity, Price, OrderDate
├── Data/
│   └── ApplicationDbContext.cs    # EF Core DbContext with seed data
├── Pages/
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml
│   └── Orders/
│       ├── Index.cshtml / .cs     # List all orders
│       ├── Create.cshtml / .cs    # Add new order
│       ├── Edit.cshtml / .cs      # Edit order
│       └── Delete.cshtml / .cs    # Delete confirmation
├── Program.cs
├── appsettings.json               # SQLite connection string
└── ASPCRUDAssignment.csproj
```

---

## Setup & Run

### 1. Install EF Core packages
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 2. Run the app
```bash
dotnet run
```
Navigate to `https://localhost:{port}/Orders`

### 4. Run locally with Docker
```bash
docker build -t order-manager .
docker run --rm -p 8080:80 order-manager
```
Then open `http://localhost:8080/Orders`

### 5. Docker image CI on GitHub
A second workflow builds and publishes a Docker image to GitHub Container Registry when you push to `main`.

- Image: `ghcr.io/<your-github-username>/order-manager:latest`
- Use this image with Render, Railway, Fly.io, or any Docker-friendly host.

### 6. Deploy to Azure with GitHub Actions
This project also includes an Azure deploy workflow, but the deploy step will only run if you add these GitHub secrets:

- `AZURE_WEBAPP_NAME`
- `AZURE_PUBLISH_PROFILE`

The workflow will build successfully even without those secrets, but it will skip Azure deployment until they are set.

1. Push this repository to GitHub.
2. Create an Azure Web App for .NET 9.
3. Download the Azure publish profile for the Web App.
4. Add these GitHub secrets to your repository:
   - `AZURE_WEBAPP_NAME` → your Azure Web App name
   - `AZURE_PUBLISH_PROFILE` → contents of the publish profile XML file
5. Push to `main` or `master`.

The workflow file is located at `.github/workflows/deploy-azure-webapp.yml`.

> Note: This is a server-side ASP.NET Core app, so it cannot be deployed to GitHub Pages. Azure App Service is the correct live host.

---

## Submission Checklist
- [ ] GitHub repository link shared
- [ ] Complete source code committed
- [ ] Database migration files included (`Migrations/` folder)

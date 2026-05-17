# Order-manager

ASP.NET Core 9 Razor Pages + Entity Framework Core + SQL Server LocalDB

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
├── appsettings.json               # LocalDB connection string
└── ASPCRUDAssignment.csproj
```

---

## Setup & Run

### 1. Install EF Core packages
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 2. Create and apply the database migration
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3. Run the app
```bash
dotnet run
```
Navigate to `https://localhost:{port}/Orders`

### 4. Deploy to Azure with GitHub Actions
This project uses a GitHub Actions workflow for live deployment to Azure App Service.

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

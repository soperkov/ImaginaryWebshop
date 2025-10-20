# ImaginaryWebshop

Welcome to the **ImaginaryWebshop** repository! This webshop allows users to order imaginary products which can't be found anywhere else.

---

## Table of Contents

- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)

---

## Getting Started

Follow these steps to set up and run the application on your local machine:

### **Step 1: Configure Application Settings**

1. Open the `appsettings.json` file located in the **ImaginaryWebshop.API** project.
2. Update the `Server` name under the `ConnectionStrings` section to match your database server configuration:
   ```json
   "ConnectionStrings": {
     "WebshopContext": "Server=yourservername;Database=ImaginaryWebshop;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;"
    }

---

### **Step 2: Update database to get ImaginaryWebshop**

1. Open the Package manager terminal
2. Write this line:
    ```bash
   dotnet ef database update --startup-project ImaginaryWebshop.API --project ImaginaryWebshop.Data
   ```

---

### **Step 3 (optional): Insert some data into database**

1. Navigate to the folder `ImaginaryWebshop.Data/Queries`.
2. Execute the SQL scripts in your preferred database management system to insert data into tables Products and Warehouse.

---

### **Step 4: Run the Backend**

1. Open the **ImaginaryWebshop.API** project in your IDE.
2. Ensure the database connection string in `appsettings.json` is configured correctly.
3. Run the project.
   - The backend server will start at: **https://localhost:7014** 

---

### **Step 5: Run the Frontend**

1. Navigate to the `ImaginaryWebshop.Web` folder in your terminal.
2. Open Command prompt (CMD)
3. Install the dependencies:
   ```bash
   npm install
   ```
4. Start the Angular development server:
   ```bash
   ng serve
   ```
- The frontend will be accessible at: **http://localhost:52910**

---

### **Step 6: Access the Application**

1. Open your browser and navigate to **http://localhost:52910** to use the application.
2. Ensure both the backend and frontend are running for full functionality.

---

## Project Structure

```plaintext
ImaginaryWebshop/
├── ImaginaryWebshop.API/                     # Backend Web API
│   ├── Controllers/                          # API controllers
│   ├── Services/                             # Business logic and helper services (e.g., ProductService)
│   ├── wwwroot/
│   │   └── uploads/
│   │       └── products/                     # Stored product images
│   ├── GlobalUsings.cs                       # Common global using statements
│
├── ImaginaryWebshop.Data/                    # Data Access Layer
│   ├── Contexts/                             # AppDbContext.cs
│   ├── Dtos/                                 # Data Transfer Objects
│   ├── Interfaces/                           # Service interfaces
│   ├── Migrations/                           # Entity Framework Core migrations
│   ├── Models/                               # Database entities (Product, Order, User, etc.)
│   ├── Queries/                              # Query for inserting into Products and Warehouse
│   └── GlobalUsings.cs                       # Common global using statements
│
├── ImaginaryWebshop.Web/                     # Angular Frontend
│   ├── src/
│   │   ├── app/
│   │   │   ├── pages/                        # Page components (Products, Cart, Orders, etc.)
│   │   │   ├── models/                       # TypeScript interfaces (Product, Order, Cart, etc.)
│   │   │   ├── services/                     # Angular services (ProductService, CartService, etc.)
│   │   │   └── shared/                       # Navbar
│
├── README.md
```

---

## Technologies Used

- **Backend**: ASP.NET Core Web Api
- **Frontend**: Angular 20.3.6
                Node 22.19.0
- **Database**: SQL Server 15.0.4382

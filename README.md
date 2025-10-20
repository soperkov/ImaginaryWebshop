# ImaginaryWebshop

Welcome to the **ImaginaryWebshop** repository! This webshop allows users to order imaginary products which can't be found anywhere else.

---

## Table of Contents

- [Getting Started](#getting-started)
- [Features](#features)
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


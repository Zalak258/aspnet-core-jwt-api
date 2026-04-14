# 🔐 ASP.NET Core Web API with JWT Authentication (N-Tier Architecture)

## 📌 Overview

This project is a production-ready ASP.NET Core Web API built using Clean/N-Tier Architecture. It includes secure JWT authentication, user management, and product APIs.

## 🚀 Features

* 🔐 JWT Authentication (Login/Register)
* 🧱 N-Tier Architecture (API, Core, Infrastructure, Services)
* 🗄️ Entity Framework Core (Code First)
* 🔒 Password Hashing using BCrypt
* ✅ Data Validation using DataAnnotations
* 🚫 Duplicate Data Prevention (Unique Constraints)
* 📦 Clean API Response Structure
* ⚠️ Global Exception Handling Middleware
* 📄 Swagger API Documentation

## 🛠️ Tech Stack

* ASP.NET Core (.NET 8)
* Entity Framework Core
* SQL Server / LocalDB
* JWT Authentication
* BCrypt.Net

## 📂 Project Structure

* **API** → Controllers, Middleware, Configuration
* **Core** → Entities, DTOs, Interfaces
* **Infrastructure** → DbContext, Repositories
* **Services** → Business Logic

## 🔑 API Endpoints

### Auth

* POST `/api/auth/register`
* POST `/api/auth/login`

### Products (Protected)

* GET `/api/product`
* POST `/api/product`

## 🧪 How to Run

1. Clone repository
2. Update connection string in `appsettings.json`
3. Run migrations:

   ```
   Add-Migration Init -Project DemoAPI.Infrastructure -StartupProject DemoAPI.API
   Update-Database -Project DemoAPI.Infrastructure -StartupProject DemoAPI.API
   ```
4. Run project
5. Open Swagger and test APIs

## 💡 Key Highlights

* Designed scalable architecture suitable for enterprise applications
* Implemented secure authentication and clean code practices
* Built reusable and maintainable backend system

## 👨‍💻 Author

Zalak Lakhani

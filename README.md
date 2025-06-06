
# Extended RESTful Web API (.NET 8.0)

This project is a simple RESTful Web API built with **.NET 8.0** that integrates with the mock API at [https://restful-api.dev](https://restful-api.dev). It extends the mock API by providing additional features such as filtering, pagination, validation, and structured error handling.

---

## 🚀 Features

- Retrieve products from the mock API with optional **name filtering** and **pagination**
- Add new products with full **model validation**
- Delete products by ID
- Unified **error handling** with meaningful error messages

---

## 🛠️ Tech Stack

- **.NET 8.0**
- **ASP.NET Core Web API**
- **HttpClientFactory**
- **FluentValidation**
- **Swashbuckle (Swagger UI)**

---

## 🧑‍💻 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- IDE: Visual Studio 2022+, Rider, or VS Code

---

### 🧱 Solution Structure

 TrueStory.Products.sln

 - TrueStory.Products.Core ->
Core domain models and business contracts

 - TrueStory.Products.Api ->
Primary Web API entry point (Controllers)

 - TrueStory.Products.RestfulApi ->
The module that handles integration with restful-api.dev

 - TrueStory.Products.RestfulApi.Client ->
The client wrapper for interacting with the external mock API

---

### 🏃‍♂️ How to Run

1. **Clone the repository**
   ```bash
   git clone https://github.com/TarekSK/TrueStory.Products.git
   cd TrueStory.Products
2. **Run the project**
   ```bash
   dotnet restore
   dotnet build
   cd TrueStory.Products.Api
   dotnet run
3. **Swagger**
   ```bash
   Open Swagger UI
   Visit https://localhost:5001/swagger (or http://localhost:5000/swagger)

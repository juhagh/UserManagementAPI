# User Management API  
Back-End Development with .NET — Coursera Assignment

This project is a simple User Management API built with ASP.NET Core Web API.  
It was developed as part of the **Back-End Development with .NET** course on Coursera.

The API demonstrates core backend concepts including:

- Controllers and routing  
- Dependency injection  
- Repository pattern  
- Model validation  
- Custom middleware  
- Error handling  
- Token-based authentication  
- Logging  
- REST client testing  

---

## 🚀 Features

### ✔ CRUD Operations  
Manage users with:
- `GET /api/user`
- `GET /api/user/{id}`
- `POST /api/user`
- `PUT /api/user/{id}`
- `DELETE /api/user/{id}`

### ✔ Validation  
The API validates:
- Required fields  
- Email format  
- String length  

### ✔ Custom Middleware  
Three middleware components were implemented:

1. **Error Handling Middleware**  
   - Catches unhandled exceptions  
   - Returns consistent JSON error responses  

2. **Authentication Middleware**  
   - Validates a simple token from the `Authorization` header  
   - Returns `401 Unauthorized` for invalid or missing tokens  

3. **Logging Middleware**  
   - Logs HTTP method, path, and response status code  

### ✔ Middleware Pipeline Order  
The pipeline is configured as:

1. Error handling  
2. Authentication  
3. Logging  
4. Controllers  

---

## 🧪 Testing

A Rider REST Client file (`UserManagementAPI.http`) is included to test:

- Valid and invalid tokens  
- CRUD operations  
- Validation errors  
- Exception handling  

Example:
GET http://localhost:5039/api/user
Authorization: my-secret-token

---

## 🛠 Technologies Used

- .NET 8 / ASP.NET Core Web API  
- C#  
- Dependency Injection  
- Middleware  
- Swagger / OpenAPI  
- Rider REST Client  

---

## 📚 How Copilot Helped

Microsoft Copilot assisted with:

- Identifying bugs in the initial API  
- Adding validation attributes  
- Implementing custom middleware  
- Structuring the middleware pipeline  
- Generating test cases  
- Improving code readability and maintainability  

---

## 📄 License

This project is licensed under the MIT License.  
See the `LICENSE` file for details.

# TodoList Minimal API

**TodoList Minimal API** is a lightweight .NET 8 project demonstrating a **Minimal API** implementation with **PostgreSQL** as the database. It allows managing a simple todo list with CRUD operations while following modern best practices for configuration and security.

---

## Features

- **Minimal API** using .NET 8  
- **Entity Framework Core** with PostgreSQL backend  
- **CRUD operations** for `ListItem` entities (Create, Read, Update, Delete)  
- **Asynchronous database operations** using `async/await`  
- **Swagger/OpenAPI** documentation and testing  
- **Secure configuration** via `.env` file (passwords and credentials are never hard-coded)  
- Easy to extend for additional features (users, authentication, etc.)

---

## Technologies

- .NET 8 Minimal API  
- Entity Framework Core 8  
- PostgreSQL 15+  
- pgcli / psql for database management  
- Swagger UI for API testing  

---

## Setup

1. **Clone the repository:**

```bash
git clone https://github.com/DavidMamatsashvili/TodoListMinimalApi.git
cd TodoListMinimalApi

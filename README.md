# 📦 ControlStock2026

Sistema de gestión y control de stock desarrollado con **.NET 10**, **Blazor WebAssembly**, **ASP.NET Core Web API** y **Entity Framework Core**.

El proyecto está diseñado con una arquitectura separada por responsabilidades, permitiendo mantener desacopladas la interfaz de usuario, la API, el acceso a datos, los servicios y los modelos compartidos.

---

## 🚀 Tecnologías utilizadas

### Frontend

- .NET 10
- Blazor WebAssembly
- Razor Components
- HTML / CSS
- C#

### Backend

- ASP.NET Core Web API
- .NET 10
- C#
- Swagger / OpenAPI

### Base de datos

- Microsoft SQL Server
- Entity Framework Core 10
- Entity Framework Core Migrations
- LocalDB para desarrollo

### Arquitectura

El proyecto se encuentra dividido en diferentes capas:

- `ControlStock2026.Cliente` → Aplicación cliente / interfaz.
- `ControlStock2026.Server` → API y servidor ASP.NET Core.
- `ControlStock.BD` → Contexto y configuración de acceso a datos.
- `ControlStock.Repositorio` → Capa de repositorios.
- `CrontolStock.Servicio` → Servicios de aplicación.
- `ControlStock.Shared` → DTOs y modelos compartidos.
- `ClienteStock.Cliente` → Componentes adicionales del cliente.

---

## 📁 Estructura del proyecto

```text
ControlStock2026/
│
├── ClienteStock.Cliente/
│   └── Cliente y componentes de la aplicación
│
├── ControlStock.BD/
│   ├── Datos/
│   ├── Migrations/
│   └── Configuración de Entity Framework Core
│
├── ControlStock.Repositorio/
│   └── Acceso y abstracción de repositorios
│
├── ControlStock.Shared/
│   └── DTOs y modelos compartidos
│
├── ControlStock2026.Cliente/
│   ├── Layout/
│   ├── Pages/
│   ├── Properties/
│   ├── wwwroot/
│   ├── App.razor
│   └── Program.cs
│
├── ControlStock2026.Server/
│   ├── Controllers/
│   │   └── ProductoController.cs
│   ├── Pages/
│   ├── Properties/
│   ├── Program.cs
│   ├── appsettings.json
│   └── appsettings.Development.json
│
├── CrontolStock.Servicio/
│   └── Servicios de aplicación
│
└── ControlStock2026.slnx

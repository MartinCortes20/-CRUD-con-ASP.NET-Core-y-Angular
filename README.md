# Prueba Técnica de Edgar - CRUD con ASP.NET Core y Angular

## Descripción

Este proyecto es una prueba técnica que consiste en crear una aplicación CRUD utilizando ASP.NET Core para el backend, SQL Server como base de datos y Angular para el frontend. La aplicación permite gestionar usuarios y roles, autenticar usuarios mediante JWT y proporciona diferentes funcionalidades de administración.

## Tecnologías Utilizadas

- **Backend**: ASP.NET Core (C#)
- **Base de Datos**: SQL Server
- **Frontend**: Angular (v18)
- **Herramientas**: Docker, Azure Data Studio

## Instrucciones de Instalación

### 1. Configuración del Contenedor SQL Server (para MacOs)

Para ejecutar SQL Server en un contenedor Docker, usa los siguientes comandos:

```bash
docker pull mcr.microsoft.com/azure-sql-edge
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Tu_Contraseña' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge

2. Configuración del Proyecto .NET
Clona el repositorio y navega a la carpeta del proyecto:


git clone https://github.com/MartinCortes20/-CRUD-con-ASP.NET-Core-y-Angular
cd PruebaTecnica
Restaura las dependencias y ejecuta la aplicación:

dotnet restore
dotnet run

3. Configuración del Frontend Angular
Navega a la carpeta del frontend y ejecuta el servidor de desarrollo:


cd frontend
ng serve
Endpoints de la API
tener en cuenta que role 1  = admin
role 2 = usuario

Usuarios
Registrar Usuario

POST /api/Users
Body:
json

{
  "Email": "admin@example.com",
  "Password": "password123",
  "Username": "testuser3",
  "Phone": "1234567899",
  "RoleId": 1
}
Obtener Todos los Usuarios (Admin)

GET /api/Users/admin/users
Requiere autenticación con rol de administrador.
Obtener Usuario por ID (Admin)

GET /api/Users/admin/{id}
Requiere autenticación con rol de administrador.
Actualizar Usuario

PUT /api/Users/{id}
Body:
json
{
  "Email": "updated@example.com",
  "Password": "newpassword123",
  "Username": "updateduser",
  "Phone": "9876543210",
  "RoleId": 2
}

Eliminar Usuario

DELETE /api/Users/{id}
Login

POST /api/Users/login
Body:
json

{
  "Email": "admin@example.com",
  "Password": "admin_password"
}

Roles
Obtener Todos los Roles

GET /api/Roles
Obtener Rol por ID

GET /api/Roles/{id}
Crear Rol

POST /api/Roles
Body:
json

{
  "Name": "newrole"
}
Actualizar Rol

PUT /api/Roles/{id}
Body:
json

{
  "Name": "updatedrole"
}
Eliminar Rol

DELETE /api/Roles/{id}


#Notas Adicionales

Autenticación: Utiliza JWT para la autenticación de usuarios. Asegúrate de proporcionar el token JWT en las solicitudes que requieran autenticación.

Base de Datos: La base de datos se inicializa con las tablas Roles y Users y contiene datos de ejemplo.
Archivos de Configuración: Los detalles de la cadena de conexión y la clave JWT están en appsettings.json.
Migrations: Se utilizan para gestionar el esquema de la base de datos.

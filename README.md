# Prueba técnica de backend con .NET 8
Proyecto creado con .NET 8 y SQL Server para administrar clientes, cuentas bancarias y movimientos de dinero.

## Características

Se crearon dos microservicios
- `ClientsApi` para clientes
- `AccountsApi` para cuentas y movimientos
  
Se aplicó los siguientes patrones de diseño
- Repository
- UnitOfWork
- DependencyInyection
- Dtos

Se utilizó Clean Architecture, cada web api tiene la siguiente estructura
```
- Application/
  - Dtos/         -> Clases las entradas y salidas de los endpoints
  - Interfaces/   -> Contratos de la capa de aplicación
  - Services/     -> Servicios de lógica de aplicaciónm
- Domain/
  - Entities/     -> Entidades de dominio y lógica de dominio
  - Validators/   -> Validación de los campos de las entidades
- Infrastructure/
  - Controllers/  -> Endpoints de entrada al api
  - Database/     -> DbContext y configuración de entidades
  - Interfaces/   -> Contratos de la capa de infra
  - Repositories/ -> Repositorios y unidad de trabajo
```

Se implementó algunas pruebas
- `AccountsApi.Tests AccountsControllerTests` contiene pruebas de integración
- `AccountsApi.Tests AccountsServiceTests` contiene pruebas unitarias

Librería utilizadas
- Para los WebApi
  - EntityFrameworkCore
  - EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools
  - FluentValidation
- Para testing
  - xUnit
  - Moq
  - FluentAssertions
  - Microsoft.AspNetCore.Mvc.Testing
  - EntityFrameworkCore.InMemory

## Requisitos
- SDK de .NET 8 [https://dotnet.microsoft.com/es-es/download/dotnet/8.0](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)
- Herramientas de entity framework (solo para crear las bases de datos por terminal)
    ```
    dotnet tool install --global dotnet-ef --version 8.*
    ```
- Postman para ejecutar peticiones


## Instalación
Abrir la terminar y clonar el repositorio
```
git clone https://github.com/MarlonEnmanuel/reto-dotnet-banco.git
```
Ubicarse dentro de la carpeta descargada y compilar la solución
```
cd .\reto-dotnet-banco\
dotnet build
```
Crear las BD en SQL Server para cada microservicio
- Opción 1: Crear las bases de datos manualmente y ejecutar los siguientes archivos provistos en el repositorio
    ```
    ClientsDb     -> Files\BaseDatos_ClientsDb.sql
    AccountsDb    -> Files\BaseDatos_AccountsDb.sql
    ```
- Opción 2: Ejecuta las migraciones de EF por terminal
  ```
  cd .\ClientsApi\
  dotnet-ef database update
  cd ..
  cd .\AccountsApi\
  dotnet-ef database update
  ```
- En caso de utiizar nombres de base de datos diferentes a las provistas por defecto se debe actualizar las cadenas de conexión en los siguientes archivos:
    ```  
    ClientsApi/appsettings.json
    AccountsApi/appsettings.json
    ```

## Ejecutar microservicios

Abrir una terminar en la carpeta de la solución y ejecutar
```
cd .\ClientsApi\
dotnet run --urls "http://localhost:4001"
```
Abrir otra terminar en la carpeta de la solución y ejecutar
```
cd .\AccountsApi\
dotnet run --urls "http://localhost:4002"
```
Abrir la aplicación Postman e importar el archivo provisto en el repositorio
- `Files/Reto .NET Banco.postman_collection.json`

En caso de utilizar puertos diferentes al 4001 y 4002:
- Actualizar en `AccountsApi/appsettings.json` la URL del api de clientes
- Actualizar los request de Postman con los puertos correspondientes

## Ejecutar pruebas
Abrir una terminar en la carpeta de la solución y ejecutar
```
dotnet test
```
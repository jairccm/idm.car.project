
# Proyecto .NET Core 8 con CQRS, Mediator, Repository Pattern e Inyección de Dependencias

Este es un proyecto desarrollado en **.NET Core 8** utilizando **C#** en **Visual Studio 2020** con la implementación de diversos patrones de diseño como **Mediator** (con MediatR), **CQRS** (Command Query Responsibility Segregation), **Repository Pattern**, e **Inyección de Dependencias**.

## Tecnologías y Herramientas Utilizadas

- **.NET Core 8**: Framework de desarrollo utilizado para construir la solución.
- **C#**: Lenguaje de programación principal.
- **Visual Studio 2020**: IDE utilizado para el desarrollo.
- **MediatR**: Biblioteca para implementar el patrón Mediator, facilitando la comunicación entre componentes sin acoplamiento directo.
- **CQRS**: Implementado para separar las operaciones de lectura (Query) y escritura (Command).
- **Patrón Repository**: Para abstraer el acceso a datos.
- **AutoMapper**: Para simplificar la conversión de entidades y DTOs.
- **Inyección de Dependencias**: Para gestionar las dependencias entre los servicios.

## Estructura del Proyecto

El proyecto está dividido en varias capas para mantener una arquitectura limpia y desacoplada. La estructura de carpetas y soluciones es la siguiente:

```
├── src
│   ├── idm.car.project.api            # API principal que expone los servicios
│   ├── idm.car.project.application    # Lógica de aplicación, comandos y consultas CQRS
│   ├── idm.car.project.domain         # Entidades y lógica de dominio
│   ├── idm.car.project.infraestructure # Implementación de repositorios y acceso a datos
├── docs                               # Documentación del proyecto
├── test                               # Pruebas unitarias y de integración
```

### Descripción de los Módulos Principales

- **API (idm.car.project.api)**: Expone los endpoints RESTful utilizando controladores que dependen de MediatR para manejar las solicitudes.
- **Application (idm.car.project.application)**: Contiene la lógica de negocio. Aquí se encuentran los **Comandos** y **Consultas** implementados bajo el patrón CQRS.
- **Domain (idm.car.project.domain)**: Define las entidades del dominio y las reglas de negocio. No tiene dependencias con otras capas.
- **Infrastructure (idm.car.project.infraestructure)**: Provee implementaciones concretas de los repositorios que se utilizan para el acceso a la base de datos.

## Requisitos del Sistema

- **.NET Core 8 SDK** o superior
- **Visual Studio 2022** o superior
- **AutoMapper**: `Install-Package AutoMapper`
- **MediatR**: `Install-Package MediatR`
- **Entity Framework Core**: `Install-Package Microsoft.EntityFrameworkCore`

## Ejecución del Proyecto

1. Clona el repositorio:
   ```bash
   git clone https://github.com/jairccm/idm.car.project.git
   ```

2. Navega a la carpeta del proyecto:
   ```bash
   cd project-car
   ```

3. Restaura los paquetes NuGet:
   ```bash
   dotnet restore
   ```

4. Compila la solución:
   ```bash
   dotnet build
   ```

5. Corre la aplicación:
   ```bash
   dotnet run --project src/idm.car.project.api
   ```

## Pruebas

Las pruebas unitarias e integración están localizadas en la carpeta `test`. Para ejecutarlas:

```bash
dotnet test
```

## Licencia

Este proyecto está licenciado bajo los términos de la MIT License. Consulta el archivo [LICENSE](LICENSE) para más información.

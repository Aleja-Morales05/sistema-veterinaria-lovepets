# Sistema-veterinaria-lovepets
# Sistema de registro de tratamientos para la veterinaria LovePets

Proyecto académico individual de programación web, desarrollado en 2024 (2024-1) en la Universidad Distrital Francisco José de Caldas

Sistema web en ASP.NET Core MVC con C# que permite registrar mascotas y llevar el control de los tratamientos y procedimientos realizados a cada una.

## Problema

La veterinaria LovePets registraba sus operaciones de forma manual, lo que generaba falta de organización, riesgo de perder la historia clínica de las mascotas y dificultad para compartir información entre veterinarios.

## Solución

Un sitio web con inicio de sesión para veterinarios que centraliza en una base de datos el registro de mascotas y sus tratamientos, para agilizar el trabajo y mejorar el control de la salud de cada animal.

## Funcionalidades

- **Clientes:** crear, consultar, editar y eliminar
- **Empleados:** crear, consultar, editar y eliminar
- **Inventario de tratamientos:** crear, consultar, editar y eliminar
- **Registro de mascotas:** registrar, consultar y editar, asignando cliente, tratamiento y veterinario
- **Eliminación de mascotas:** módulo para eliminar registros que ya no se necesitan
- **Gráfica:** al buscar el Id de un veterinario, muestra los tratamientos que ha realizado
- **Reporte de historia clínica en PDF:** al ingresar el Niup (número único de identificación) de una mascota, genera su historial de tratamientos

## Tecnologías

- C# y ASP.NET Core MVC
- SQL Server (LocalDB)
- HTML, CSS y JavaScript
- Visual Studio 2022

## Cómo ejecutarlo

1. Clona el repositorio:
   `git clone https://github.com/Aleja-Morales05/sistema-veterinaria-lovepets.git`
2. Abre `FinalWeb.sln` en Visual Studio 2022.
3. Crea la base de datos con el script `database/script.sql` y ajusta la cadena de conexión en `appsettings.json`.
4. Ejecuta el proyecto con F5.


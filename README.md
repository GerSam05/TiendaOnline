<p align="center">
  <img width="626" height="134" src="https://github.com/GerSam05/GalponIndustrial/assets/146037370/6623ae64-08b3-46f2-b04b-74edfbade9e8"><br>
  <img src="https://komarev.com/ghpvc/?username=gersam05&label=Profile%20views&color=0e75b6&style=flat" alt="gersam05" />
</p>


# 🛒API Restfull TiendaOnline

## Introducción
-	**TiendaOnline** es una **API Restfull** de tipo comercial elaborada con el objeto de efectuar operaciones de consulta, registro, modificación y eliminación de artículos de una tienda comercial.
-	Todo esto con operaciones sencillas y remotas de tipo **CRUD** en una única tabla (img:1) almacenada en una base de datos.
-	La Api posee un único controlador “**ArticuloController**” para realizar acciones en la tabla “**Articulo**”.
-	La metodología utilizada fué **Stored Procedures** (Procedimientos Almacenados) con **Microsoft SQL Server Management Studio** (img:2) y el **Paquete Microsoft.Data.SqlClient** (5.1.1).
-	Siguiendo las buenas prácticas y manteniendo la funcionalidad de la Api, se incorporó la clase “**DataArticulo**” como capa intermedia entre el controlador y la clase “**ConexionBd**” donde se estableció el enlace con la cadena de conexión.
-	La Api posee una clase "**APIResponse**" con métodos, encargada de retornar una respuesta estandarizada para todas las peticiones realizadas desde los endpoints.


<br>

## Tecnologías utilizadas

<p align="left"> <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a> <a href="https://postman.com" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/getpostman/getpostman-icon.svg" alt="postman" width="40" height="40"/> </a> </p>

<br>

## Imágenes

Tablas de la base de datos:

![Select Table](https://github.com/GerSam05/TiendaOnline/assets/146037370/fd2ef460-ca3d-411c-899e-f0e1cd1c1ed5)
> Imagen 1: Query "Select * from Articulo"
<br>

![Procedures](https://github.com/GerSam05/TiendaOnline/assets/146037370/02d4f11c-7cfa-4c20-bc90-34f8447e493c)
> Imagen 2: Stored Procedures utilizados para las operaciones CRUD
<br>

---

Espero que el repositorio les sea de utilidad👍🏻💡!!!...
 
> 📁 Todos mis proyectos estan disponibles en [![GitHub repository](https://img.shields.io/badge/repository-github-orange)](https://github.com/GerSam05?tab=repositories)

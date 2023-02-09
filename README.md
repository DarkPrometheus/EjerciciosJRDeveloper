# Ejercios JR Developer de Grupo Timex

## Ejercicios solicitados:

1. **En una base de datos crear una tabla la cual almacena la siguiente información** 

   1. IdRegistro 
   2. Nombre 
   3. Apellidos 
   4. FechaNacimiento 
   5. FechaDeRegistroEnSIstema 

2. **Generar un Script para almacenar la siguiente información en la tabla anterior** 

   | IdRegistro | Nombre | Apellidos | FechaNacimiento | FechaRegistroEnSistema |
   | ---------- | ------ | --------- | --------------- | ---------------------- |
   | 1          | Pedro  | Mola      | 19791011        | FechaYHoraActual       |
   | 2          | Pablo  | Videgaray | 19750105        | FechaYHoraActual       |
   | 3          | Sonia  | Lopez     | 19850306        | FechaYHoraActual       |
   | 4          | Alex   | Perez     | 19800708        | FechaYHoraActual       |

    

3. **Generar un script para consultar los registros donde el nombre inicie la letra P**

4. **Implementar en el lenguaje y plataforma que domine la ejecución de los scripts de los punto 2 y 3**

5. **Considerando la información almacenada anteriormente y la implementación anterior , ¿cómo evitarías que se repitieran registros con "Nombre" y "Apellido" iguales?. Explicar a detalle.**

6. **¿Qué pasos tomas para resolver problemas en código con los sistemas que ha participado?**

7. **¿Qué editor de código utilizas y por qué?**

---

## Resolucion

He realizado los ejercicios en C# con la base de datos SQLite.

1. **En una base de datos crear una tabla la cual almacena la siguiente información**

<div align="center"><i><b>CREATE DATABASE</b> Personas</i></div>

<div align="center"><i><b>CREATE TABLE</b> Persona(IdRegistro <b>INTEGER PRIMARY KEY AUTOINCREMENT</b>, Nombre <b>TEXT</b>, Apellidos <b>TEXT</b>, FechaNacimiento <b>INTEGER</b>, FechaRegistroEnSistema <b>TEXT</b>)</i></div>

<br>

Para los campos *Nombre* y *Apellido* he decidido declararlos como tipo **TEXT** por la razón de evitar usar un **varchar** con un tamaños más pequeño del que pueda ocupar y tener que estarlo modificando posteriormente.

Para el campo *FechaNacimiento* he supuesto que el valor está en Unix Time, por lo que considere que un **INTEGER** era lo más viable.

Y por último, para el campo *FechaRegistroEnSistema*, ya que SQLite [no tiene](https://www.sqlite.org/datatype3.html#:~:text=2.2.-,Date%20and%20Time%20Datatype,DD%20HH%3AMM%3ASS.) un tipo de dato **DATETIME** decidí tomar la opción de almacenarlo como **TEXT** con el formato sugerido por la [documentacion oficial](https://www.sqlite.org/datatype3.html) (***TEXT** as ISO8601 strings ("YYYY-MM-DD HH:MM:SS.SSS")*).

<br>

2. **Generar un Script para almacenar la siguiente información en la tabla anterior**

<div align="center"><i><b>INSERT INTO</b> Persona(Nombre, Apellidos, FechaNacimiento, FechaRegistroEnSistema) <b>VALUES</b>('Pedro', 'Mola', 19791011, '2023-02-09 01:00:00.000')</i></div>

<div align="center"><i><b>INSERT INTO</b> Persona(Nombre, Apellidos, FechaNacimiento, FechaRegistroEnSistema) <b>VALUES</b>('Pablo', 'Videgaray', 19750105, '2023-02-09 01:00:00.000')</i></div>

<div align="center"><i><b>INSERT INTO</b> Persona(Nombre, Apellidos, FechaNacimiento, FechaRegistroEnSistema) <b>VALUES</b>('Sonia', 'Lopez', 19850306, '2023-02-09 01:00:00.000')</i></div>

<div align="center"><i><b>INSERT INTO</b> Persona(Nombre, Apellidos, FechaNacimiento, FechaRegistroEnSistema) <b>VALUES</b>('Alex', 'Perez', 19800708, '2023-02-09 01:00:00.000')</i></div>

<br>

3. **Generar un script para consultar los registros donde el nombre inicie la letra P**

   <div align="center"><i><b>SELECT</b> * <b>FROM</b> Persona <b>WHERE</b> Nombre <b>LIKE</b> 'P%'</i></div>

   <br>

4. **Implementar en el lenguaje y plataforma que domine la ejecución de los scripts de los punto 2 y 3**

<br>

5. **Considerando la información almacenada anteriormente y la implementación anterior , ¿cómo evitarías que se repitieran registros con "Nombre" y "Apellido" iguales?. Explicar a detalle.**

En vez de crear la tabla con un **PRIMARY KEY** en el campo *IdRegistro* crearía la tabla con una llave compuesta con el campo *Nombre* y el campo *Apellido*, esto haría que al intentar insertar un registro con el nombre y el apellido igual la BDD lanze un error, por lo que solo se podrían insertar registros donde el campo *Nombre* y el campo *Apellido* no se hayan ingresado con los mismos valores antes.

<br>

6. **¿Qué pasos tomas para resolver problemas en código con los sistemas que ha participado?**

- Si el programa es muy simple o sencillo comienzo a desarrollarlo sin planificar nada o casi nada, ya que programas pequeños que no van a escalar no requieren de mucha planificación y prefiero comenzar a desarrollarlo para no perder tiempo en una planificación que no será útil realmente.
- Si el programa es muy complejo o llevara mucho tiempo de desarrollo, intento seguir los lineamientos de alguna metodología de desarrollo como SCRUM, adaptándolo a lo que necesite para ese proyecto en específico. Pero siempre suelo desglosar el sistema por requerimientos, si es necesario hacer diagramas de flujo, diagramas para la BDD y/o los diagramas que sean necesarios para tener una mejor visión y entendimiento del proyecto. Al finalizar el desarrollo o durante el mismo, si se requiere también realizo la documentación pertinente, ya sea para el usuario final o para próximos desarrolladores que vayan a trabajar en el proyecto.

<br>

7. **¿Qué editor de código utilizas y por qué?**

Para desarrollo web utilizo **Visual Studio Code** principalmente por las extensiones, el conjunto de extensiones que uso me dan todo lo que necesito para trabajar con <u>ReactJS</u>, que es lo que casi siempre suelo usar para páginas o aplicaciones web por la versatilidad y facilidad que da.


Para trabajar con **C#**, *WinForms, programas de consola* o *Blazor* por ejemplo, siempre uso **Visual Studio**, ya que considero que este <u>IDE</u> es bastante potente e integra todas las herramientas necesarias para trabajar con **.NET**


<h1 align="center">Práctico 2</h1>

## Bibliografía

https://aulas.ort.edu.uy/pluginfile.php/324381/mod_resource/content/1/S3C2.pdf

## Objetivos

El objetivo de este práctico es añadir funcionalidades a la aplicación de ejemplo.

ASPost es una aplicación en Rails donde las personas pueden postear contenido y comentar los posts de otras personas.

## Diseño

### Asociaciones

* El ​Equipo​ se dió cuenta que si bien se había solicitado agregar el modelo de comentarios y asociarlo a un usuario faltó que este esté asociado a un ​Post.
* Además, es deseable que dado un ​Post​ se conozcan sus comentarios. 

### Modelos

El ​Product Owner​ solicita que cada ​Post​ tenga asociada una serie de categorías, pues de esta manera piensa desplegarlas en el sitio. De cada categoría conocemos:

* Código​: texto no visible, que pueda ser utilizado como parte de una ​URL
* Descripción​: texto a desplegar en la página visible para el usuario

De las categorías se saben que si bien son un número finito es deseable que en un futuro sea gestionable por el administrador del sitio por lo que tome las consideraciones necesarias.

## Implementación

El código fuente del práctico completo está disponible en la [carpeta src](src/).

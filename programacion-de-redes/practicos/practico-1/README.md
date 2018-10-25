<h1 align="center">Práctico 1</h1>

## Bibliografía

https://aulas.ort.edu.uy/pluginfile.php/322920/mod_folder/content/0/Práctico%2001%20-%20Threads.pdf?forcedownload=1

## Objetivos

- Mostrar las ventajas de la programación multi-hilos para realizar tareas paralelizables.

- Mostrar el problema de la corrupción de datos que son accedidos por varios hilos y su solución (concurrencia).

- Mostrar el problema de sincronización entre hilos y su solución.

## Ejercicio 1

Desarrolle una aplicación que ejecute un número al azar de threads o reciba la misma cantidad por consola y que por cada thread escriba varias líneas por consola que diga "Bienvenidos a Programación de Redes 2018 – Thread X", donde X representa el numero de thread ejecutandose.

## Ejercicio 2

Desarrolle una aplicación que ejecute un número al azar de threads o reciba la misma cantidad por consola y que el primer thread en estar activo escriba en consola "Bienvenidos a Programación de Redes 2018", luego de que un thread lo escriba una vez los demás no deberán hacerlo.

Se sugiere hacerlo con una variable estática. Ejecute la aplicación varias veces y vea si ocurren errores e intente deducir que es lo que ocurre.

## Ejercicio 3

Desarrolle la misma aplicación que en el ejercicio 2 pero que esta vez no se produzcan errores.

## Ejercicio 4

Desarrolle una aplicación que en un thread escriba por consola cien ceros, luego de terminar se debe indicar desde el thread principal que el nuevo thread terminó. Desarrolle la aplicación de dos maneras distintas.

## Ejercicio 5

Desarrolle una aplicación que tenga un método para recibir dos números y devuelva la suma, además de otro método que realice lo mismo con tres sumandos, deberá utilizar dos threads donde cada uno realizará un método distinto de los de sumar y luego mostrará individualmente la suma de cada operación y luego la suma total.
<h1 align="center">Práctico 2</h1>

## Bibliografía

https://aulas.ort.edu.uy/pluginfile.php/322920/mod_folder/content/0/Práctico%2002%20-%20Sincronización.pdf?forcedownload=1

## Objetivos

- Mostrar las ventajas de la programación multi-hilos para realizar tareas paralelizables.

- Mostrar el problema de la corrupción de datos que son accedidos por varios hilos y su solución (concurrencia).

- Mostrar el problema de sincronización entre hilos y su solución.

## Ejercicio 1

Desarrolle un programa que tenga 2 hilos de ejecución, uno que imprima 20 ‘x’, y el otro que imprima 20 ‘o’, entre la impresión de cada carácter haga una espera de 100 mseg. Logre que primero se impriman todas las ‘x’.

[Ver código fuente](src/p2e01/Program.cs)

## Ejercicio 2

Desarrolle una aplicación que, mediante el uso de threads, provoque un deadlock, comente como podria solucionar esta situacion.

[Ver código fuente](src/p2e02/Program.cs)

## Ejercicio 3

Desarrolle una aplicación que ingrese personas a una lista. Los datos de las personas serán CI, nombre, email y teléfono. La aplicación debe permitir que se ingresen personas desde varios hilos y que en caso de que una persona tenga la misma cédula de identidad se dispare una excepción mostrando un mensaje por pantalla. Se recomienda utilizar el mecanismo de locks.

[Ver código fuente](src/p2e03/Program.cs)

## Ejercicio 4

Desarrolle una aplicación que simule a una discoteca. El máximo de personas simultáneas que se permiten dentro de la discoteca es cien, además cuando la discoteca recaude cien mil pesos no se permitirá el ingreso de más personas (aunque haya menos de cien adentro) pero si la salida. Simule que cada persona es un hilo y tiene las funciones de gastar o bailar (sleep), entrar o salir. Se recomienda utilizar el Slim Semaphore.

[Ver código fuente](src/p2e04/Program.cs)

## Ejercicio 5

Desarrolle una aplicación que simule el problema del productor consumidor, cada uno en un thread independiente utilizando monitores.

[Ver código fuente](src/p2e05/Program.cs)

## Ejercicio 6

Desarrolle una aplicación que simplemente ponga una condición sobre un bloque que imprima el mensaje “Deje de estar bloqueado” y que funcione mediante los comandos de Wait y Pulse con monitores.

[Ver código fuente](src/p2e06/Program.cs)

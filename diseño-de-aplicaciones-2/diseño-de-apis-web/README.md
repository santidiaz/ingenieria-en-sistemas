# Diseño de APIs Web

Las buenas prácticas de diseño presentadas en esta sección fueron extraídas del libro [Web API Design: Crafting Interfaces that Developers Love](https://pages.apigee.com/rs/apigee/images/api-design-ebook-2012-03.pdf
) de [Brian Mulloy](https://www.linkedin.com/in/brianmulloy/). Las mismas están profundamente influenciadas por [REST](#rest) por lo que resulta preciso profundizar en este concepto.

## REST

REST es un estilo arquitectónico para diseñar aplicaciones en red.

Más info: http://www.ics.uci.edu/~fielding/pubs/dissertation/rest_arch_style.htm

## Buenas Prácticas

Estas son algunas de las buenas prácticas que se mencionan en el libro.

### Sustantivos &#x1F44D;; verbos &#x1F44E;

Lo que intenta esta buena práctica es **mantener la URL simple e intuitiva**. Para eso propone:

* **Usar hasta 2 URLs base por recurso**

    URL          | Propósito                                                      
    ------------ | --------------------------------------------------------------
    `/dogs/`     | Para hacer referencia a la colección                          
    `/dogs/1234` | Para hacer referencia a un elemento específico de la colección

* **No usar verbos en la URL base**

* **Usar verbos HTTP para operar en las colecciones y elementos**

    Mapear los verbos HTTP `POST`, `GET`, `PUT`, y `DELETE`, a las operaciones **CRUD** (**C**reate, **R**ead, **U**pdate, **D**elete). Con 2 URLs base por recurso y los cuatro verbos HTTP tenemos una gama de operaciones posibles que son intuitivas para el desarrollador:

    URL          | POST           | GET                     | PUT                                        | DELETE                    
    ------------ | -------------- | ----------------------- | ------------------------------------------ | -------------------------
    `/dogs/`     | Crear un perro | Listar todos los perros | Actualizar varios perros a la vez          | Eliminar todos los perros
    `/dogs/1234` | `Error`        | Detalle de un perro     | Actualizar un perro (Si no existe `Error`) | Eliminar un perro        

### Sustantivos en plural y nombres concretos

* **Sustantivos en plural**

    La operación que probablemente más se haga contra un API REST es un GET, por lo que resulta más legible e intuitivo el uso de sustantivos en plural para nombrar los recursos. Más allá de eso lo importante es ser **consistente**, evitando nombrar algunos recursos en singular y otros en plural.  
* **Nombres concretos son mejores que abstractos**

    Nombres concretos como `dogs`, `news`, `videos` son preferibles ante abstractos como `items` o `assets`. **Intentar tener entre 12 y 24 recursos**.
    
### Simplificar asociaciones - complejidad después del ?

* **Asociaciones**

    Raramente es necesario indentificar una asociación entre recursos con una URL más larga que esta: `/resource/identifier/resource`. Por ejemplo para obtener todos los perros que pertenecen a un dueño específico, hacer un `GET` a `/owners/5678/dogs`.

* **Mantener la complejidad después del ?**

    Poner estados opcionales y atributos luego del signo de pregunta de la URL. Por ejemplo, para obtener todos los perros rojos corriendo en el parque hacer un `GET` a `/dogs?color=red&state=running&location=park`.

### Manejo de errores

* **Usar códigos de estado de HTTP**

    Interacción                                  | Código de estado HTTP
    -------------------------------------------- | ----------------------------
    Todo funcionó bien - `success`               | 200 - OK                        
    La aplicación hizo algo mal - `client error` | 400 - Bad Request
    La API hizo algo mal - `server error`        | 500 - Internal Server Error

    Para empezar estos tres deberían ser suficiente. Si se necesitan más intentar utilizar los siguientes cinco:

    Código de estado HTTP        |
    ---------------------------- |
    201 - Created                |
    304 - Not Modified           |
    401 - Unauthorized           |
    403 - Forbidden              |
    404 - Not Found              |

    No debería ser necesario manejar más de 8. En caso de necesitar más esta es la lista de todos los códigos de estado HTTP: https://en.wikipedia.org/wiki/List_of_HTTP_status_codes

* **Hacer que los mensajes devueltos en el cuerpo de la respuesta sean lo más detallados posible**

    Usar lenguaje plano y ser detallado agregando todas las sugerencias posibles para que el equipo de desarrollo de la API pueda identificar qué está causando el error.

    ```json
    {
        "developerMessage": "Verbose, plain language description of the problem for the app developer with hints about how to fix it.",
        "userMessage": "Pass this message on to the app user if needed.",
        "errorCode": 12345,
        "more info": "http://dev.teachdogrest.com/errors/12345"
    }
    ```

### Versionado

* **Nunca publicar una API sin versión. Hacer que la vesión sea obligatoria**

    Especificar la versión en la parte izquierda de la URL utilizando la letra **v** como prefijo al ordinal que indica la versión (v1, v2, ...). Por ejemplo: `/v1/dogs`, `/v2/dogs`.

* **Mantener por lo menos una versión anterior funcionando**

### Paginación y respuestas parciales

* **Soportar respuestas parciales agregando campos opcionales como una lista de elementos separados por coma**

    Permitir a los desarrolladores que consumen la API obtener sólo la información que necesitan utilizando este enfoque: `/dogs?fields=name,color,location`. 
    
* **Facilitar a los desarrolladores la paginación de colecciones de objetos**

    Utilizar `limit` y `offset` como parámetros para permitir paginar los resultados de las respuestas. Por ejemplo: `/dogs?limit=25&offset=50`. El valor por defecto de estos parámetros varía según el tamaño del recurso pero suele ser `limit=10&offset=0`.

### Respuestas que no involucran recursos

Llamadas a la API que envían una respuesta que no es un recurso no son poco comunes dependiendo del dominio. Por ejemplo, quizás la API deba proveer un algoritmo para convertir de una moneda a otra.

* **Usar verbos en vez de sustantivos**

    Por ejemplo, una API que convierte 100 Euros a Yenes Chinos: `/convert?from=EUR&to=CNY&amout=100`.

* **Aclarar en la documentación de la API que estos escenarios son diferentes**

### Soportar múltiples formatos

* **Permitir elegir el formato de la respuesta**

    Permitir a los desarrolladores que consumen la API elegir el formato de la respuesta especificándolo de alguna manera en la URL. Preferentemente utilizando la siguiente notación:
    
    <pre>/dogs<b>.json</b></pre>
    <pre>/dogs/1234<b>.json</b></pre>

### Nombres de atributos

* **Usar JSON por defecto**

* **Seguir las convenciones de JavaScript para nombrar atributos**

    * Usar CamelCase
    * Usar mayúsculas o minúsculas dependiendo del tipo de objeto

### Tips para búsqueda

* **Búsqueda global**

    ```
    /search?q=fluffy+fur
    ```

* **Búsqueda contextual**

    ```
    /owners/5678/dogs?q=fluffy+fur
    ```

### Autenticación

Usar la última versión disponible de OAuth. Más info en https://oauth.net
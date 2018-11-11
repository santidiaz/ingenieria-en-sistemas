# Frameworks

Un framework es una aplicación semicompleta y reusable que se puede especializar para producir aplicaciones específicas.

Más info: http://www.cs.wustl.edu/~schmidt/CACM-frameworks.html

## Beneficios

Los principales beneficios de un framework provienen de la modularidad, reusabilidad, extensibilidad, y la inversión de control que proveen a los desarrolladores.

**Modularidad**: los frameworks mejoran la modularidad al encapsular detalles volátiles de implementación detrás de interfaces estables.

**Reusabilidad**: las interfaces estables provistas por los frameworks mejoran la reusabilidad al definir componentes genéricos que pueden ser reaplicados para crear nuevas aplicaciones.

**Extensibilidad**: un framework mejora la extensibilidad proveyendo métodos *hook* que permiten a las aplicaciones extender las interfaces estables provistas por el propio framework. 

**Inversión de control**: La arquitectura de ejecución de un framework está catacterizada por una inversión de control. Cuando ocurren eventos el *dispatcher* del framework reacciona invocando los métodos *hook* en objetos pre-registrados que ejecutan el proceso específico de la aplicación para el evento. La inversión de control permite que el framework determine (en vez de que lo haga cada aplicación) qué conjunto de métodos específicos de aplicación deben ser invocados en respuesta a eventos externos (mensajes de ventanas del S.O. o paquetes llegando a los puertos de comunicación).

## Desafíos

Equipos de trabajo que intentan construir o utilizar frameworks reusables normalmente fallan a no ser que reconozcan y resuelvan los siguientes desafíos: **esfuerzo requerido para desarrollarlos, curva de aprendizaje, integrabilidad, mantenibilidad, eliminación de defectos, eficiencia, falta de estándares**.

## Categorizacón (por alcance)

- **De infraestructura**. Por ejemplo: .NET, Mono
- **De integración**. Por ejemplo: EntityFramework
- **De dominios particulares**: Por ejemplo: CakePHP

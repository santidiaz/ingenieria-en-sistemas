<h1 align="center">Principios de Diseño a Nivel de Paquetes</h1>

Los principios de diseño presentados en esta sección fueron extraídos del libro [Design Principles and Design Patterns](https://aulas.ort.edu.uy/pluginfile.php/206903/course/section/37747/Principles_and_Patterns.pdf) de [Robert C. Martin](https://en.wikipedia.org/wiki/Robert_Cecil_Martin), capítulo 
*Principles of Package Architecture* (página 16).

## Principios de Cohesión de Paquetes

Son principios que intentan ayudar a decidir **qué clases corresponden a qué paquete**.

### REP - Release Reuse Equivalency Principle

**Un paquete no puede ser liberado a menos que sea manejado por algún tipo de sistema de versionado**. Las versiones anteriores deben ser mantenidas durante un tiempo.

Un criterio para agrupar clases en paquetes es su reusabilidad. **O bien todas las clases dentro del paquete son reusables o ninguna lo es**.

### CCP - Common Closure Principle

Buscando minimizar el número de paquetes que cambian en cada liberación es que se busca **agrupar clases que probablemente cambien por el mismo motivo en un mismo paquete**.

### CRP - Common Reuse Principle

**Clases que no se reusan juntas no deben ser agrupadas**.

### Tensión entre los Principios de Cohesión de Paquetes

Los tres principios no pueden satisfacerse simultáneamente porque cada uno beneficia a diferentes grupos de personas: [REP](#rep-release-reuse-equivalency-principle) y [CRP](#crp-common-reuse-principle) le facilitan la vida a los "re-usadores", mientras que [CPP](ccp-common-closure-principle) le facilita la vida a los "mantenedores".

[CPP](ccp-common-closure-principle) intenta hacer que los paquetes sean lo más grande posible (Después de todo si todas las clases están en un sólo paquete entonces sólo un paquete va a cambiar), mientras que [CRP](#crp-common-reuse-principle) trata de que los paquetes sean chicos.

## Principios de Acoplamiento de Paquetes

Son principios que intentan gobernar la **interrelación de los paquetes**.

### ADP - Acyclic Dependency Principle

**Las dependencias entre paquetes no deben formar ciclos**.

### SDP - Stable Dependency Principle

**Paquetes propicios a cambiar deben depender de paquetes estables**. 

**Estabilidad**: es un concepto relacionado con la cantidad de trabajo requerido para hacer un cambio. **Un paquete con un montón de dependencias entrantes es muy estable** porque requiere mucho trabajo reconciliar los cambios con todos los paquetes dependientes.

> Una moneda no es estable porque requiere muy poco trabajo darla vuelta, mientras que una mesa es estable porque requiere una cantidad de trabajo considerable darla vuelta.

### SAP - Stable Abstractions Principle

**Paquetes estables deben ser abstractos**
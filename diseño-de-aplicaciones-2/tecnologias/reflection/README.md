# Reflection

Es la habilidad de un programa de examinar, praticar la introversión, y modificar su propia estructura y comportamiento en tiempo de ejecución.

Más info: http://www2.parc.com/csl/groups/sda/projects/reflection96/docs/malenfant/malenfant.pdf

## Ejemplo en C&#35;

```c#
var assemby = Assembly.LoadFile("path/to/dll");

foreach (var type in assembly.GetTypes()) {
    foreach (var method in type.GetMethods()) {
        if (method.GetName() == "DoSomething") {
            method.Invoke(null);
        }
    }
}
```
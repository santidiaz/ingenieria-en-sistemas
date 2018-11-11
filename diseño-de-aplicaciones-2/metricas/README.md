# Métricas

Más info: https://aulas.ort.edu.uy/pluginfile.php/206903/course/section/37747/Principles_and_Patterns.pdf.

## Conceptos

* **Atributo**: Una propiedad medible que comparten todas las entidades de una misma categoría.

    Ejemplo: Defecto

* **Medida**: Resultado de una medición.

    Ejemplo: Número de defectos

* **Métrica**: Medida cuantitativa del grado en que un sistema posee un atributo dado. Es una forma de medir y una escala definida para realizar mediciones de uno a varios atributos.

    Ejemplo: Promedio de defectos por persona

## Categorías

- Orientadas a paquetes
- Orientadas a clases
- Orientadas a métodos

## Cohesión relacional

Mide la relación entre clases de un paquete

<p align="center"><img src="/diseño-de-aplicaciones-2/metricas/tex/f1caaa98bb81e930bafac243a8553c6a.svg?invert_in_darkmode&sanitize=true" align=middle width=79.8090678pt height=33.62942055pt/></p>

> <img src="/diseño-de-aplicaciones-2/metricas/tex/5e168b0912626b283e10c59daa3cf0e6.svg?invert_in_darkmode&sanitize=true" align=middle width=12.60847334999999pt height=22.465723500000017pt/> = Cantidad de relaciones entre clases internas al paquete 
>
> <img src="/diseño-de-aplicaciones-2/metricas/tex/5e9c7a7d16b15ab5b947bedf5f56bd79.svg?invert_in_darkmode&sanitize=true" align=middle width=14.99998994999999pt height=22.465723500000017pt/> = Cantidad de clases e interfaces dentro del paquete.

Es buena si <img src="/diseño-de-aplicaciones-2/metricas/tex/5fde7705b9890304582d9021bfb5160a.svg?invert_in_darkmode&sanitize=true" align=middle width=14.99998994999999pt height=22.465723500000017pt/> está entre <img src="/diseño-de-aplicaciones-2/metricas/tex/9f78d566733991ee8806223d7b181100.svg?invert_in_darkmode&sanitize=true" align=middle width=58.44761669999998pt height=24.65753399999998pt/>

## Inestabilidad

<p align="center"><img src="/diseño-de-aplicaciones-2/metricas/tex/656b1aad38828960d1b5add3cf3f0a21.svg?invert_in_darkmode&sanitize=true" align=middle width=91.0061889pt height=36.09514755pt/></p>

> <img src="/diseño-de-aplicaciones-2/metricas/tex/4c288eba8e7e17182872bdaf0c820278.svg?invert_in_darkmode&sanitize=true" align=middle width=18.879232349999988pt height=22.465723500000017pt/> = Cantidad de clases aferentes (Clases fuera del paquete que dependen de clases dentro del paquete).
>
> <img src="/diseño-de-aplicaciones-2/metricas/tex/c6c43bedbe53b94177ee62518822bb10.svg?invert_in_darkmode&sanitize=true" align=middle width=17.98576889999999pt height=22.465723500000017pt/> = Cantidad de clases eferentes (Clases dentro del paquete que dependen de clases fuera del paquete)

Si <img src="/diseño-de-aplicaciones-2/metricas/tex/6885b5f684a7299aa27de9444ae4ce07.svg?invert_in_darkmode&sanitize=true" align=middle width=8.515988249999989pt height=22.465723500000017pt/> es <img src="/diseño-de-aplicaciones-2/metricas/tex/dc3cce2aedba164600c8e5bc4b8fcaa5.svg?invert_in_darkmode&sanitize=true" align=middle width=8.219209349999991pt height=21.18721440000001pt/> el paquete es estable, mientras que si <img src="/diseño-de-aplicaciones-2/metricas/tex/6885b5f684a7299aa27de9444ae4ce07.svg?invert_in_darkmode&sanitize=true" align=middle width=8.515988249999989pt height=22.465723500000017pt/> es <img src="/diseño-de-aplicaciones-2/metricas/tex/57839dff3317ee4f9c8f18baf8d1e7e2.svg?invert_in_darkmode&sanitize=true" align=middle width=8.219209349999991pt height=21.18721440000001pt/> el paquete es inestable. Esto nos permite reescrbir el [SDP](../4/#sdp-stable-dependency-principle) como: **un paquete debe depender de paquetes cuya métrica <img src="/diseño-de-aplicaciones-2/metricas/tex/6885b5f684a7299aa27de9444ae4ce07.svg?invert_in_darkmode&sanitize=true" align=middle width=8.515988249999989pt height=22.465723500000017pt/> es menor que la propia**.

## Abstracción

<p align="center"><img src="/diseño-de-aplicaciones-2/metricas/tex/09e370d7b4724ce0a3c5d103094de6e7.svg?invert_in_darkmode&sanitize=true" align=middle width=57.379071749999994pt height=36.09514755pt/></p> 

> <img src="/diseño-de-aplicaciones-2/metricas/tex/87150a98fe1035ecea4c791fe2a1603c.svg?invert_in_darkmode&sanitize=true" align=middle width=20.338150799999987pt height=22.465723500000017pt/> = Cantidad de clases abstractas e interfaces del paquete
>
> <img src="/diseño-de-aplicaciones-2/metricas/tex/cacbb444428e855c8d1343d908d8931a.svg?invert_in_darkmode&sanitize=true" align=middle width=19.082419949999988pt height=22.465723500000017pt/> = Cantidad de clases concretas, abstractas e interfaces del paquete

Un paquete es abstracto en la medida que <img src="/diseño-de-aplicaciones-2/metricas/tex/4ddffcd42610c451b271272b7ec53505.svg?invert_in_darkmode&sanitize=true" align=middle width=12.32879834999999pt height=22.465723500000017pt/> tiende a <img src="/diseño-de-aplicaciones-2/metricas/tex/57839dff3317ee4f9c8f18baf8d1e7e2.svg?invert_in_darkmode&sanitize=true" align=middle width=8.219209349999991pt height=21.18721440000001pt/>. Esto nos permite reescribir el [SAP](../4/#sap-stable-abstractions-principle) como: **<img src="/diseño-de-aplicaciones-2/metricas/tex/6885b5f684a7299aa27de9444ae4ce07.svg?invert_in_darkmode&sanitize=true" align=middle width=8.515988249999989pt height=22.465723500000017pt/> debe crecer en la medida en que <img src="/diseño-de-aplicaciones-2/metricas/tex/4ddffcd42610c451b271272b7ec53505.svg?invert_in_darkmode&sanitize=true" align=middle width=12.32879834999999pt height=22.465723500000017pt/> decrece** (Paquetes concretos deberían ser inestables y paquetes abstractos deberían ser estables).

## Inestabilidad vs Abstracción

<p align="center"><img src="./img/inestabilidad-vs-abstraccion.png" alt="Inestabilidad vs Abstracción" width="60%" /></p>

Queremos que nuestros paquetes estén lo más cerca posible de la línea *The Main Sequence*. Un posicionamiento en la línea indica que el paquete es abstracto en proporción a sus dependencias entrantes y es concreto en proporción a sus dependencias salientes. Esto deja un conjunto más de métricas a examinar: las [distancias](#distancia).

### Distancia

<p align="center"><img src="/diseño-de-aplicaciones-2/metricas/tex/512ece0aa888e0b4be0d6f34588ed06f.svg?invert_in_darkmode&sanitize=true" align=middle width=107.20281494999999pt height=37.64101605pt/></p>

Varía entre <img src="/diseño-de-aplicaciones-2/metricas/tex/6816bb8fd86e956d059433fa111eef14.svg?invert_in_darkmode&sanitize=true" align=middle width=67.58004659999999pt height=24.65753399999998pt/>

### Distancia normalizada

<p align="center"><img src="/diseño-de-aplicaciones-2/metricas/tex/3955c4b31b8bf127e77feb55fc149c09.svg?invert_in_darkmode&sanitize=true" align=middle width=118.9745403pt height=17.2895712pt/></p>

Varía entre <img src="/diseño-de-aplicaciones-2/metricas/tex/9627d10377ff00291237fc2cabbe0a43.svg?invert_in_darkmode&sanitize=true" align=middle width=32.87674994999999pt height=24.65753399999998pt/>. Si es <img src="/diseño-de-aplicaciones-2/metricas/tex/dc3cce2aedba164600c8e5bc4b8fcaa5.svg?invert_in_darkmode&sanitize=true" align=middle width=8.219209349999991pt height=21.18721440000001pt/> entonces el paquete está posicionado directamente en la línea *The Main Sequence*.


<h1 align="center">Implementación de una Gramática</h1>

## Bibliografía

[Ranta, A. (2012). *Implementing programming languages: An introduction to compilers and interpreters*. London, UK: College Publications, pp.32-36.](https://www.scribd.com/document/387692631/Ranta-A-2012-Implementing-Programming-Languages-An-Introduction-to-Compilers-and-Interpreters)

## Introducción

A continuación implementaremos la gramática de un lenguaje parecido a [`C`](https://es.wikipedia.org/wiki/C_(lenguaje_de_programación)). Lo llamaremos `CPP` y lo iremos construyendo desde arriba hacia abajo (Desde las definiciones más grandes hasta las más chicas) escribiendo las reglas apropiadas en cada paso.

## Definición de la Gramática

Un **programa** es una secuencia de definiciones:

```
PDefs.  Program ::= [Def] ;
terminator Def "" ;
```

Un programa puede contener comentarios, que deberían ser ignorados por el compilador. Los comentarios pueden comenzar con el símoblo `//` y extenderse hasta el final de la línea o también pueden comenzar con `/*` y extenderse hasta el próximo `*/`:

```
comment "//" ;
comment "/*" "*/" ;
```

&nbsp;

Una **definición de función** tiene un tipo, un nombre, una lista de argumentos y un cuerpo. La lista de argumentos se escribe entre paréntesis y los argumentos se separan con comas. El cuerpo es una lista de sentencias escrita entre llaves:

<details>
    <summary>Ejemplo</summary>
    
    int foo(double x, int y)
    {
        return y + 9;
    }
</details>

```
DFun.   Def ::= Type Id "(" [Arg] ")" "{" [Stm] "}" ;
separator Arg "," ;
terminator Stm "" ;
```

&nbsp;

Un **argumento** tiene un tipo y un identificador:

```
ADecl.  Arg ::= Type Id ;
```

&nbsp;

Una **sentencia** siempre termina en punto y coma y puede ser: 

* Cualquier **expresión**:

    ```
    SExp.   Stm ::= Exp ";" ;
    ```

* Cualquier **declaración de variable**:

    ```
    SDecl.  Stm ::= Type Id ";" ;
    SDecls. Stm ::= Type Id "," [Id] ";" ;
    SInit.  Stm ::= Type Id "=" Exp ";" ;
    ```

    Una declaración de variable puede ser un tipo y una variable (SDecl), un tipo y varias variables (SDecls) o un tipo y una variable inicializada (SInit).

* Un `return`:

    ```
    SReturn. Stm ::= "return" Exp ";" ;   
    ```

* Un `while` seguido de una expresión entre paréntesis seguida de una sentencia: 

    <details>
        <summary>Ejemplo</summary>

        while (i < 10) i++;
    </details>

    ```
    SWhile.  Stm ::= "while" "(" Exp ")" Stm ;
    ```

* Un `if` seguido de una expresión entre paréntesis, una sentencia, un `else`, y otra sentencia:

    <details>
        <summary>Ejemplo</summary>
    
        if (x > 0) 
            return x; 
        else 
            return y;
    </details>

    ```
    SIfElse. Stm ::= "if" "(" Exp ")" Stm "else" Stm ;
    ```

* Un **bloque** (Cualquier lista de sentencias, incluida la lista vacía) entre llaves:

    <details>
        <summary>Ejemplo</summary>
    
        {
            int i = 2;
            {
            }
            i++;
        }
    </details>

    ```
    SBlock.  Stm ::= "{" [Stm] "}" ;
    ```

&nbsp;

Una **expresión** puede ser cualquiera de las que se especifican en la siguiente tabla (que además describe los niveles de precedencia). Los operadores infijos se asumen *left-associative*, excepto las asignaciones que son *right-associative*.

Nivel | Expresión                            | Explicación
------|--------------------------------------|------------------------------------------
15    | literal                              | literal (*integer*, *float*, *string*, *boolean*)
15    | identificador                        | nombres y variables
15    | `f(e, ..., e)`                       | llamada a una función
14    | `v++`, `v--`                         | post-incremento, post-decremento
13    | `++v`, `--v`                         | pre-incremento, pre-decremento
13    | `-e`                                 | negación numérica
12    | `e * e`, `e / e`                     | multiplicación, división
11    | `e + e`, `e - e`                     | suma, resta
9     | `e < e`, `e > e`, `e >= e`, `e <= e` | comparación
8     | `e == e`, `e != e`                   | igualdad, desigualdad
4     | `e && e`                             | conjunción (*and*)
3     | `e \|\| e`                           | disjunción (*or*)
2     | `v = e`                              | asignación

Las reglas que representan esta tabla son:

```
EInt.    Exp15 ::= Integer ;
EDouble. Exp15 ::= Double ;
EString. Exp15 ::= String ;
ETrue.   Exp15 ::= "true" ;
EFalse.  Exp15 ::= "false" ;
EId.     Exp15 ::= Id ;
ECall.   Exp15 ::= Id "(" [Exp] ")" ;
EPIncr.  Exp14 ::= Exp15 "++" ;
EPDecr.  Exp14 ::= Exp15 "--" ;
EIncr.   Exp13 ::= "++" Exp14 ;
EDecr.   Exp13 ::= "--" Exp14 ;
ENeg.    Exp13 ::= "-" Exp14 ;
EMul.    Exp12 ::= Exp12 "*" Exp13 ;
EDiv.    Exp12 ::= Exp12 "/" Exp13 ;
EAdd.    Exp11 ::= Exp11 "+" Exp12 ;
ESub.    Exp11 ::= Exp11 "-" Exp12 ;
ELt.     Exp9  ::= Exp9 "<" Exp10 ;
EGt.     Exp9  ::= Exp9 ">" Exp10 ;
ELEq.    Exp9  ::= Exp9 "<=" Exp10 ;
EGEq.    Exp9  ::= Exp9 ">=" Exp10 ;

EEq.     Exp8  ::= Exp8 "==" Exp9 ;
ENEq.    Exp8  ::= Exp8 "!=" Exp9 ;
EAnd.    Exp4  ::= Exp4 "&&" Exp5 ;
EOr.     Exp3  ::= Exp3 "||" Exp4 ;
EAss.    Exp2  ::= Exp3 "=" Exp2 ;

coercions Exp 15 ;
separator Exp "," ;
```

&nbsp;

Los **tipos** disponibles son `bool`, `double`, `int`, `string` y `void`:

```
Tbool.   Type ::= "bool" ;
Tdouble. Type ::= "double" ;
Tint.    Type ::= "int" ;
Tstring. Type ::= "string" ;
Tvoid.   Type ::= "void" ;
```

&nbsp;

Por último, un **nombre** o **identificador** es una letra seguida de una lista de letras, dígitos y *underscores*:

```
token Id (letter (letter | digit | '_')*) ;
```

## Implementación

1. Descargar el archivo [`cpp.cf`](https://raw.githubusercontent.com/agurodriguez/ort-ingdesoft-ldp/master/extras/implementacion-de-una-gramatica/cpp.cf) que contiene la definición del lenguaje (todas las reglas que definimos anteriormente).

2. Ejecutar `bnfc -m cpp.cf` en el directorio donde se encuentra el archivo `.cf` para generar el código fuente del *lexer/parser*.

3. Ejecutar `make` en el mismo directorio para compilar el código fuente y obtener el ejecutable (`TestCpp`). Esta aplicación recibe una cadena de caracteres del lenguaje `CPP`, la *parsea* y devuelve el árbol de sintaxis abstracta correspondiente.

4. Para probarlo podemos hacer lo siguiente:

    Crear un archivo [`ejemplo.cpp`](https://raw.githubusercontent.com/agurodriguez/ort-ingdesoft-ldp/master/extras/implementacion-de-una-gramatica/ejemplo.cpp) con el siguiente contenido:

    ```c
    // no "hello world" here 
    void fn(int param1, bool param2) {
        if (param1 > 0 && param2 == true) 
            return true;
        else
            return false;
    }
    ```

    Ejecutar:

    ```
    cat ejemplo.cpp | ./TestCpp
    ```

    Verificar que la salida sea:

    ```
    Parse Successful!

    [Abstract Syntax]

    PDefs [DFun Tvoid (Id "fn") [ADecl Tint (Id "param1"), ADecl Tbool (Id "param2")] [SIfElse (EAnd (EGt (EId (Id "param1")) (EInt 0)) (EEq (EId (Id "param2")) ETrue)) (SReturn ETrue) (SReturn EFalse)]]

    [Linearized tree]

    void fn (int param1, bool param2){
    if (param1 > 0 && param2 == true)return true ;
    else return false ;
    }
    ```
    

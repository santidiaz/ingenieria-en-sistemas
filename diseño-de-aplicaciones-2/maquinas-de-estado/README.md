# Máquinas de Estado

Es una especificación de la secuencia de estados por las que transita un objeto a lo largo de su vida en respuesta a eventos.

Más info: http://faculty.ksu.edu.sa/amani.h/Documents/UMLTutoria(To%20benefit).pdf

## Elementos

### Estado

Situación durante la vida de un objeto en la que satisface alguna condición, realiza alguna actividad o espera por algún por evento. 

- Es único
- Tiene acciones instantáneas e ininterrumpibles que se realizan al entrar y salir del estado.
- Puede realizar actividades prolongadas e interrumpibles
- Puede tener transiciones internas que permiten manejar eventos sin salir del estado

### Evento

Es un estímulo que tiene lugar en el tiempo y espacio y puede disparar una transición en el estado. Puede ser interno (Entre objetos del sistema) o externo (Entre actores y el sistema)

- **Evento de Tiempo**: Ocurre de forma automática luego de que pase `x` tiempo

    `after (x)`

- **Evento de Cambio**: Ocurre de forma automática cuando se cumple una condición

    `when (var == 1)`

### Transición

Respresenta el cambio de un estado a otro (o al mismo) dado por un evento. Es única para un estado.

- **Transición Automática**: No tiene un evento asociado

- **Transición No Automática**: Generada por un evento

## Diagrama UML

<p align="center"><img src="./img/maquina-de-estados.png" alt="Máquina de Estados de un Molinete" width="80%" /></p>

Más info: http://www.agilemodeling.com/artifacts/stateMachineDiagram.htm

## Representación Tabular

Estado actual | Cuando ocurra evento | Transicionar a estado | Invocar método
------------- | -------------------- | --------------------- | --------------  
Locked        | Coin                 | Unlocked              | Unlock
Locked        | Pass                 | Locked                | Alarm 
Unlocked      | Coin                 | Unlocked              | Thankyou
Unlocked      | Pass                 | Locked                | Lock

## Implementación

### Switch-Case

```c#
enum State {
    Locked, 
    Unlocked
};

enum Event {
    Pass, 
    Coin
};

class TurnstileStateMachine {

    private State s = .Locked;
    
    public void Transition(Event e) {
        switch (s) {
            case .Locked:
                switch (e) {
                    case .Coin:
                        s = .Unlocked;
                        Unlock();
                        break;
                    case .Pass:
                        Alarm();
                        break;
                } 
                break;

            case .Unlocked:
                switch (e) {
                    case .Coin:
                        Thankyou();
                        break;
                    case .Pass:
                        s = .Locked;
                        Lock();
                        break;
                } 
                break;    
        }
    }

}
```

### Intérprete de Tablas

[TODO]

### Patrón `State`

<p align="center"><img src="./img/patron-state.png" alt="Patrón State" width="70%" /></p>

Más info: [Ver en sección Patrones de Diseño](../5/#state)

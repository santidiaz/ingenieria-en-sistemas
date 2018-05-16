<h1 align="center">AngularJS</h1>

Es un framework de JavaScript orientado a construir [aplicaciones web de una sola página]().

Más info: https://angular.io/docs

## Arquitectura

<p align="center"><img src="./img/arquitectura.png" alt="Arquitectura" /></p>

### Modules

Todas las apps Angular tienen al menos un *module*, el *root module*, nombrado `AppModule` por convención. Además, la mayoría de las apps tienen varios *feature module*, cada uno como un bloque cohesivo de código dedicado a un conjunto de funcionalidades relacionadas. Un *module*, ya sea *root* o *feature*, es una clase con un decorador `@NgModule`.

```js
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    imports:      [ BrowserModule ],
    providers:    [ Logger ],
    declarations: [ AppComponent ],
    exports:      [ AppComponent ],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }
```

Más info: https://angular.io/guide/architecture#modules

### Components

Un *component* controla una parte de la pantalla llamada *view*. Un *component* es una clase de JavaScript que interactúa con la *view* a través de sus métodos y propiedades.

```js
export class HeroListComponent implements OnInit {
    heroes: Hero[];
    selectedHero: Hero;

    constructor(private service: HeroService) { }

    ngOnInit() {
        this.heroes = this.service.getHeroes();
    }

    selectHero(hero: Hero) { 
        this.selectedHero = hero; 
    }
}
```

Más info: https://angular.io/guide/architecture#components

### Templates

Un *template* es una porción de código HTML que define como se renderiza un *component*.

```html
<h2>Hero List</h2>
<p><i>Pick a hero from the list</i></p>
<ul>
    <li *ngFor="let hero of heroes" (click)="selectHero(hero)">
        {{hero.name}}
    </li>
</ul>
<hero-detail *ngIf="selectedHero" [hero]="selectedHero">
</hero-detail>
```

> Un *template* usa elementos típicos de HTML como &lt;h2&gt; and &lt;p&gt; y también elementos propios de la sintaxis de Angular como `*ngFor`, `{{hero.name}}`, `(click)`, `[hero]`, and `<hero-detail>`.

Más info: https://angular.io/guide/architecture#templates

### Data Binding

Es un mecanismo para coordinar partes de un *template* con partes de un *component*. Para indicar a Angular como conectar esas partes se utilizan el siguiente *markup* especial en el código HTML del *template*:

<p align="center"><img src="./img/databinding.png" alt="Data Binding" /></p>

La siguiente porción de código ilustra el uso del *markup* mencionado más arriba:

```html
<li (click)="selectHero(hero)">
    {{hero.name}}
</li>
<hero-detail [hero]="selectedHero"></hero-detail>
```

> * `{{hero.name}}`: Hace que se muestre el valor de la propiedad `hero.name` del *component* asociado al *template*.
>
> * `[hero]`: Hace que se pase el valor de la propiedad `selectedHero` del *component* padre (`HeroListComponent`) a la propiedad `hero` del *component* hijo (`HeroDetailComponent`).
>
> * `(click)`: Hace que se invoque el método `selectHero` del *component* `HeroListComponent` cuando el usuario hace clic en el &lt;li&gt; que contiene el nombre del heroe.

Más info: https://angular.io/guide/architecture#data-binding

### Directives

Los *template* son dinámicos. Cuando Angular los lee, genera el DOM según instrucciones dadas por las *directives*. Una *directive* es una clase de JavaScript con un decorador `@Directive`.

```html      
<li *ngFor="let hero of heroes"></li>
<hero-detail *ngIf="selectedHero"></hero-detail>
```

> * `*ngFor` hace que Angular renderice un &lt;li&gt; por heroe en la lista de heroes.
>
> * `*ngIf` hace que Angular incluya el *component* `HeroDetailComponent` sólo si `selectedHero` no es vacío.

Más info: https://angular.io/guide/architecture#directives

### Services

Un *service* es una clase JavaScript con un propósito bien definido. Ejemplos de ello: logging, acceso a datos, configuración de la aplicación, calculadora de impuestos, etc.

```js
export class HeroService {
    private heroes: Hero[] = [];

    constructor(private backend: BackendService, private logger: Logger) { }

    getHeroes() {
        this.backend.getAll(Hero).then( (heroes: Hero[]) => {
            this.logger.log(`Fetched ${heroes.length} heroes.`);
            this.heroes.push(...heroes); // fill cache
        });
        return this.heroes;
    }
}
```  

Más info: https://angular.io/guide/architecture#services

### Dependency Injection

Dependency injection es un mecanismo para proveer nuevas instancias de una clase con todas las dependencias que esta requiere.

Angular detecta que *services* requiere un *component* mirando el tipo de los parámetros de su constructor. Por ejemplo, el constructor de `HeroListComponent` requiere un `HeroService`. Luego de obtener las dependencias pide instancias al *Injector* para luego pasarlas como argumento al constructor de la instancia del *component*:

<p align="center"><img src="./img/dependency-injection.png" alt="Data Binding" /></p>

Más info: https://angular.io/guide/architecture#dependency-injection
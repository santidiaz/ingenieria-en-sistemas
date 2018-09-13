<h1 align="center">Práctico 2</h1>

## Bibliografía

https://aulas.ort.edu.uy/pluginfile.php/324381/mod_resource/content/1/S3C2.pdf

## Objetivos

El objetivo de este práctico es añadir funcionalidades a la aplicación de ejemplo.

ASPost es una aplicación en Rails donde las personas pueden postear contenido y comentar los posts de otras personas.

## Diseño

### Asociaciones

* El ​Equipo​ se dió cuenta que si bien se había solicitado agregar el modelo de comentarios y asociarlo a un usuario faltó que este esté asociado a un ​Post.
* Además, es deseable que dado un ​Post​ se conozcan sus comentarios. 

### Modelos

El ​Product Owner​ solicita que cada ​Post​ tenga asociada una serie de categorías, pues de esta manera piensa desplegarlas en el sitio. De cada categoría conocemos:

* Código​: texto no visible, que pueda ser utilizado como parte de una ​URL
* Descripción​: texto a desplegar en la página visible para el usuario

De las categorías se saben que si bien son un número finito es deseable que en un futuro sea gestionable por el administrador del sitio por lo que tome las consideraciones necesarias.

## Procedimiento

### Easy

1. Creamos los nuevos modelos:

    ```bash
    rails generate model category code:string description:string
    ```

2. Creamos las nuevas asociaciones:

    ```bash
    rails generate migration AddPostToCategories post:references
    rails generate migration AddPostToComments post:references
    ```

3. Agregamos los `has_many` en el archivo [`app/models/post.rb`](./src/app/models/post.rb):

    ```diff
    class Post < ApplicationRecord
        belongs_to :user
    +   has_many :categories
    +   has_many :comments
    end
    ```

4. Agregamos los `belongs_to`:

    [`app/models/category.rb`](./src/app/models/category.rb):

    ```diff
    class Category < ApplicationRecord
    +    belongs_to :post
    end
    ```
    
    [`app/models/comment.rb`](./src/app/models/comment.rb):

    ```diff
    class Comment < ApplicationRecord
        belongs_to :user
    +    belongs_to :post
    end
    ```

5. Agregamos datos de ejemplo en [`db/seeds.rb`](./src/db/seeds.rb):

    ```diff
    user = User.new name: 'Pedro', email: 'pedropicapiedra@gmail.com', password: '123456'
    user.save!
    
    post = Post.new title: 'Un nuevo post!', content: 'Contenido de ejemplo', data: Date.new
    post.user = user
    post.save
    + 
    + post.categories << Category.new(code: 'generic', description: 'Categoría genérica')
    + post.comments << Comment.new(text: 'Un nuevo comentario!', date: Date.new, user: user)
    ```

6. Ejecutamos los siguientes comandos para actualizar la base de datos:

    ```bash
    rake db:migrate
    rake db:seed
    ```

## Implementación

El código fuente del práctico completo está disponible en la [carpeta src](src/).

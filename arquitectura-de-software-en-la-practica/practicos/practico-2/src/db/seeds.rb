# This file should contain all the record creation needed to seed the database with its default values.
# The data can then be loaded with the rails db:seed command (or created alongside the database with db:setup).
#
# Examples:
#
#   movies = Movie.create([{ name: 'Star Wars' }, { name: 'Lord of the Rings' }])
#   Character.create(name: 'Luke', movie: movies.first)

user = User.new name: 'Pedro', email: 'pedropicapiedra@gmail.com', password: '123456'
user.save!

post = Post.new title: 'Un nuevo post!', content: 'Contenido de ejemplo', date: Date.new
post.user = user
post.save

post.categories << Category.new(code: 'generic', description: 'Categoría genérica')
post.comments << Comment.new(text: 'Un nuevo comentario!', date: Date.new, user: user)
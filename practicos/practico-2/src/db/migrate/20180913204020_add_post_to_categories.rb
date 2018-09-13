class AddPostToCategories < ActiveRecord::Migration[5.2]
  def change
    add_reference :categories, :post, foreign_key: true
  end
end

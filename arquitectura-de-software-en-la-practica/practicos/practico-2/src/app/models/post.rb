class Post < ApplicationRecord
    belongs_to :user
    has_many :categories
    has_many :comments
end

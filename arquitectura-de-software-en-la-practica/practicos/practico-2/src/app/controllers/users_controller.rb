class UsersController < ApplicationController
  def new
    @user = User.new
  end

  def create
    @user = User.new user_params

    if @user.save
      redirect_to @user, notice: 'Usuario creado correctamente.'
    else
      render action: 'new'
    end
  end

  def edit
    @user = User.find params[:id]
  end

  def update
    @user = User.find params[:id]

    if @user.update_attributes user_params
      redirect_to @user, notice: 'Usuario editado correctamente.'
    else
      render action: 'edit'
    end
  end

  def destroy
    @user = User.find params[:id]
    @user.destroy
    redirect_to users_url
  end

  def index
    @users = User.all
  end

  def show
    @user = User.find params[:id]
  end

  private

    def user_params
      # It's mandatory to specify the nested attributes that should be whitelisted.
      # If you use `permit` with just the key that points to the nested attributes hash,
      # it will return an empty hash.
      params.require(:user).permit(:name, :email, :password)
    end

end

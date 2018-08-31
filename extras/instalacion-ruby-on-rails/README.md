<h1 align="center">Instalación Ruby on Rails</h1>

## Instalación "todo de una"

1. Descargar e instalar [Vagrant](https://www.vagrantup.com/downloads.html)
    > Vagrant is a tool for building and managing virtual machine environments in a single workflow. With an easy-to-use workflow and focus on automation, Vagrant lowers development environment setup time, increases production parity, and makes the "works on my machine" excuse a relic of the past.
    
2. Descargar el archivo [`Vagrantfile`](https://raw.githubusercontent.com/agurodriguez/ort-ingdesoft-asp/master/extras/instalacion-ruby-on-rails/Vagrantfile).

3. Ejecutar `vagrant up` en el directorio donde se encuentra el archivo `Vagrantfile`.

4. Ejecutar `vagrant ssh` para acceder a la máquina virtual con todos los componentes necesarios para el curso (`ruby`, `rails`, `wrk`, etc).

5. Ejecutar `cd /vagrant` para moverse al directorio con los archivos del proyecto (Directorio en la máquina host donde se encuentra el archivo `Vagrantfile`).

Para ver más info sobre el funcionamiento de Vagrant visitar https://www.vagrantup.com/intro/getting-started/index.html.
# Instalación BNFC + Haskell

## Instalación "todo de una"

1. Descargar e instalar [Vagrant](https://www.vagrantup.com/downloads.html)
    > Vagrant is a tool for building and managing virtual machine environments in a single workflow. With an easy-to-use workflow and focus on automation, Vagrant lowers development environment setup time, increases production parity, and makes the "works on my machine" excuse a relic of the past.
    
2. Descargar el archivo [`Vagrantfile`](https://raw.githubusercontent.com/agurodriguez/ort-ingdesoft-ldp/master/extras/instalacion-bnfc/Vagrantfile).

3. Ejecutar `vagrant up` en el directorio donde se encuentra el archivo `Vagrantfile`.

4. Ejecutar `vagrant ssh` para acceder al entorno de desarrollo con todos los componentes necesarios (`bnfc`, `ghc`, `make`, etc) para el curso.

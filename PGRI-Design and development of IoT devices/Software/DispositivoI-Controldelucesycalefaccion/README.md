# Instalacion del Dispositivo : 

## 1. Prerequisitos / Prerequisites

Para poder ejecutar el codigo se debe instalar la libreria Webiopi en la Raspberry, posteriormente crear una carpeta con nombre myprojecttemp en la ruta /home/pi 
y guardar las carpetas html y pyton contenidas en el repositorio.

**Arquitectura Webiopi / Architecture Webiopi :** 

![](http://trouch.com/wp-content/uploads/2012/11/webiopi-architecture.png)

**Link para instalar Webiopi / Link to Install Webiopi:** 
```
http://webiopi.trouch.com/INSTALL.html

```


Es importante tener en cuenta los componentes que conforman la arquitectura del dispositivo, para implementar esta arquitectura es necesario tener los archivos contenidos en este repositorio (python/script.py;html/index.html ; configtemp) a continuación se presenta cada uno de ellos :

* **python/script.py :** Archivo que se encarga de la manipulación y configuración de los GPIO Pin's que utilizara nuestro dispositivo
* **html/index.html :** Archivo encargado de la interfaz de usuario del dispositivo, sin embargo tambien alberga un script de javascript que se encarga de consumir los metodos de la libreria Webiopi.
* **configtemp :** Archivo de configuracion del dispositivo, donde se especifica los GPIO Pin's, los sensores, puertos, entre otras configuraciones aue utilizara el dispositivo.




**Ruta de creación Carpeta / Folder Path Creation :** 

- [ ]   /home/pi/nombredecarpeta --- /home/pi/foldername




![](https://www.jeremymorgan.com/images/raspberry-pi-linux-3.png)





## 2. Correr el Codigo / Run the program

Luego de tener configurada correctamente la libreria Webiopi se debe guardar el archivo configtemp en la ruta /etc/webiopi/ , posteriormente se procede a ejecutar la siguiente linea de codigo desde el terminal : 
```
sudo webiopi -d -c /etc/webiopi/configtemp
```
Al ejecutarse el servidor proveera la URL donde se debe conectar para ingresar a la interfaz de control de luces y temperatura.

La URL debe apuntar al puerto 8000

Ejemplo : 

```
http://192.168.0.1:8000/
```

Las credenciales de autenticación para el cliente en la interfaz de usuario son : 

user : webiopi
password : alice 


# Instalacion del Dispositivo : 

### PreRequisitos

Para poder ejecutar el codigo se debe instalar la libreria Webiopi en la Raspberry, posteriormente crear una carpeta con nombre myprojecttemp en la ruta /home/pi 
y guardar las carpetas html y pyton contenidas en el repositorio.
Link para instalar Webiopi: 
```
http://webiopi.trouch.com/INSTALL.html
```

## Correr el Codigo 

Luego de tener configurada correctamente la libreria Webiopi se debe guardar el archivo configtemp en la ruta /etc/webiopi/ , posteriormente se procede a ejecutar la siguiente linea de codigo desde el terminal : 
```
sudo webiopi -d -c /etc/webiopi/configtemp
```
Al ejecutarse el servidor proveera la URL donde se debe conectar para ingresar a la interfaz de control de luces y temperatura
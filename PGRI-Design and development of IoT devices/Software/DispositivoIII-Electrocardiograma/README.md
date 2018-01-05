# Instalación de Dispositivo 

### PreRequisitos

* 	Raspberry PI 1 o posterior
* 	Microsoft Windows 10 IOT core instalado en el Dispositivo Raspberry
* 	Adafruit ADS1115
* 	SparkFun Single Lead Heart Rate Monitor - AD8232
* 	Acceso a la plataforma Microsoft Azure
* 	Acceso a la plataforma Power BI

Realizar el montaje del siguiente circuito : 

```
https://hackster.imgix.net/uploads/image/file/155672/Heart_bb.png?auto=compress%2Cformat&w=680&h=510&fit=max

```


## Instalación

-Para poder ejecutar el codigo del repositorio se debe configurar previamente un IoT Hub en la plataforma de Azure de Microsoft :

```

https://docs.microsoft.com/es-es/azure/iot-hub/iot-hub-create-through-portal

```

* Obtener la cadena de conexión y reemplazar en el archivo DeviceKey.txt y MainPage.xaml.cs. El cual se encuentra en este repositorio de ser posible recompilar con VisualStudio2015.

-Crear un Trabajo en StreamAnalitycs para recibir los eventos entrantes al IoT Hub : 

```

https://docs.microsoft.com/en-us/azure/stream-analytics/stream-analytics-create-a-job

```

* Se debe configurar la entrada de datos proveniente del grupo de recursos del IoTHub, la salida de los datosse debe configurar con PowerBI, para esto debe tener una cuenta de ingreso a la plataforma en sincronizarla.

* Reemplazar el valor de la consulta por el que se muestra a continuación : 

```

SELECT System.Timestamp AS WindowEnd,
    position,
     count
INTO
    jongblogpowerbi
FROM
    jonblogiothub

```

* Al momento de ejecutar el trabajo StreamAnaltycs se encargara de crear un conjunto de datos en PowerBI donde se recibiran los datos provenientes del dispositivo, 


* Una vez creado el conjunto de datos en PowerBi se puede ingresar para configurar el DashBoard, el cual mostrara los datos que van entrando a PowerBI en tiempo real por medio de diferentes graficos. (Tarjetas,Graficos de Lineas, Medidores entre otros).a continuación podra encontrar un tutorial de como realizar todo  este procedimiento. 

```
https://docs.microsoft.com/en-us/azure/stream-analytics/stream-analytics-power-bi-dashboard

```

## Correr el Codigo 

Para correr el codigo debera ingresar al dispositivo de manera remota utilizando la IP que tiene designada el mismo en la red y apuntando al puerto 8080.

Ejemplo

```
http://192.168.0.1:8080

```
Para conectarse a esta plataforma remota debe usar las siguientes credenciales :
*User : administrator 
*Password : password


Guardar él codigo modificado junto con el contenido de esta carpeta en un nuevo Folder y posteriormente proceder a importarlo desde la plataforma remota por medio de la pestaña apps.

*Ejecutar el codigo guardado en el dispositivo desde la plataforma remota, conectarse a la plataforma Microsoft PowerBI y ver en el DashBoard los datos que entran graficados en tiempo real.







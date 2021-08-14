Pasos para usar este programa

Asegurarse que existe una version de node instalado

Usar node -v para ver la version
Si no tienes instalado node porfavor instalalo.
Actualizar node y npm a la ultima version desde sus sitios web
Puedes intentar usar los comandos npm-windows-upgrade o npm i -g npm para actualizarlos. 

El proyecto esta dividido en dos partes en una misma solucion, por un lado tenemos los servicios web y por otro el cliente (interfaz grafica realizada en Angular).
En la carpeta Src se encuentran todos los proyectos que definen la arquitectura solucion de la prueba y  consiste de una capa de acceso a datos (carpeta DAL), capa de negocios (carpeta BLL) y capa de servicios (carpeta Services).
En la carpeta Apps se encuentra el proyecto cliente (GUI) que va a consumir los servicios, por lo tanto para poder ejecutar el cliente deberiamos clonar en dos carpetas distintas el mismo repositorio, uno para ejecutar el proyecto ProductosServices y el otro para ejecutar el cliente.

Ejecutar el proyecto ProductosServices:
Configuracion Base de datos
En sql server crear base de datos llamada Jugueteria.
Establecer como proyecto predeterminado ProductosServices.
Abrir consola de administrador de paquetes y en proyecto predeterminado elegir Src\Producto\DAL\Repository
y escribir:
update-database 
con la finalidad de ejecutar la migracion y se actualice en la BD.

Una vez finalizado estos pasos se puede ejecutar el proyecto y consumir los servicios.

Ejecutar el proyecto JugueteriaApp:
asegurarse que esta ejecutandose el proyecto ProductosServices para poder consumir dichos servicios.
Establecer como proyecto de inicio el proyecto JugueteriaApp
Ubicarse en la siguiente carpeta del proyecto:
Apps/JugueteriaApp/ClientApp y dar click secundario para abrir el menu contextual y dar click en copiar ruta de acceso completa, posteriormente abrir consola de cmd  escribir:
cd ruta_copiada
con la finalidad de posicionarnos en dicha ruta y escribir lo siguiente:
ng -serve
con la finalidad de compilar el proyecto angular
una vez finalizado dicha compilacion podemos ejecutar el proyecto desde visual studio.




# dse_certificados v1.1.0
## Programa para la gestión de certificados digitales

### Desarrollado por Carlos Clemente (09-2024)

### Control de versiones
- Version 1.0.0 - Primera version funcional
- Version 1.1.0 - Añadida funcionalidad para exportar un certificado en base64
<br>

### Descripcion:
- Permite obtener una relacion de los certificados digitales instalados en el equipo, con todas sus propiedades
- Tambien se puede seleccionar un fichero de un certificado digital, y obtener las propiedades
- Pasando como parametro un fichero con un certificado digital, se exporta en base64 (necesario para Conectass)
<br>

### Uso de la aplicacion:
	dse_certificados.exe clave tipo [salida.json | certificado.pfx password]

### Parametros:
- clave: unicamente sirve como medida de seguridad de ejecucion
- tipo: permite indicar el tipo de proceso segun los siguientes:
	- 1 = Obtener relacion de certificados instalados en el equipo y sus propiedades
	- 2 = Obtener propiedades del certificado seleccionado en pantalla
	- 3 = Exportar certificado digital a base64
- salida.json: fichero de salida con la relacion de certificados y sus propiedades
- certificado.pfx: nombre del fichero con el certificado a exportar (solo para el tipo 3)
- password: contraseña del certificado digital a exportar (solo para el tipo 3)
		
### Ejemplos de uso: 
	 
* Obtener relacion de certificados instalados en el equipo con sus datos:
```
dse_certificados clave 1 certificados.json
```
<br>

* Obtener datos del certificado seleccionado en pantalla: 
```
dse_certificados clave 2 certificados.json
```
<br>

* Exportar certificado a base64: 
```
dse_certificados clave 3 certificado.pfx contraseña
```
<br>

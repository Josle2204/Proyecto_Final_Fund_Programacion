# README – Sistema Teleshop Streaming

## 1. Nombre del proyecto

**Sistema de gestión de cuentas Teleshop Streaming**

## 2. Descripción del sistema

Este programa fue desarrollado en **C#** para automatizar la gestión de cuentas de plataformas de streaming del negocio Teleshop Streaming. El sistema permite mostrar clientes, buscar cuentas, registrar nuevas cuentas, eliminar registros, revisar alertas de vencimiento, calcular la ganancia total y salir del programa.

La información se almacena en un archivo llamado **Streaming.csv**, el cual funciona como base de datos básica del sistema.

## 3. Funciones principales

El sistema cuenta con un menú principal de siete opciones:

1. Mostrar clientes.
2. Buscar cliente.
3. Registrar cuenta.
4. Eliminar cuenta.
5. Alerta de vencimientos.
6. Ganancia total.
7. Salir.

## 4. Requisitos para ejecutar el programa

Para ejecutar el sistema se necesita:

* Sistema operativo Windows.
* Visual Studio o Visual Studio Code.
* .NET instalado.
* Archivo principal: **Program.cs**.
* Archivo de datos: **Streaming.csv**.

## 5. Archivo de datos Streaming.csv

El archivo **Streaming.csv** almacena los registros de las cuentas. Cada fila representa una cuenta registrada y los datos están separados por punto y coma (;).

La estructura del archivo es:

Teléfono;Precio;Vencimiento;Cuenta;Perfil;Plataforma

Ejemplo:

987654321;15;25/06/2026;[usuario@gmail.com](mailto:usuario@gmail.com) clave123;Perfil 1;Disney

Los campos utilizados son:

* Teléfono: número telefónico del cliente.
* Precio: monto pagado por la cuenta.
* Vencimiento: fecha de vencimiento del servicio.
* Cuenta: correo o usuario junto con la clave.
* Perfil: nombre del perfil o disponibilidad.
* Plataforma: servicio contratado, como IPTV, Paramount, HBO MAX, Disney o Crunchyroll.

## 6. Cómo ejecutar el programa

1. Abrir el proyecto en Visual Studio.
2. Verificar que el archivo **Streaming.csv** esté en la carpeta del proyecto o en la misma carpeta donde se ejecuta el programa.
3. Ejecutar el archivo **Program.cs**.
4. Seleccionar una opción del menú principal.
5. Ingresar los datos solicitados por el sistema.
6. Para finalizar el programa, seleccionar la opción **7) Salir**.

## 7. Descripción de las opciones del menú

### Opción 1: Mostrar clientes

Muestra todos los registros almacenados en el archivo **Streaming.csv** en formato de tabla.

### Opción 2: Buscar cliente

Permite buscar una cuenta mediante el número telefónico del cliente. Si encuentra coincidencias, muestra los datos registrados.

### Opción 3: Registrar cuenta

Permite agregar una nueva cuenta solicitando teléfono, monto, fecha de vencimiento, correo o usuario, clave, plataforma y perfil. Al finalizar, guarda el registro en el archivo **Streaming.csv** y muestra un mensaje de confirmación.

### Opción 4: Eliminar cuenta

Permite eliminar una cuenta registrada. El sistema solicita el número telefónico, muestra las coincidencias encontradas y permite seleccionar la cuenta que se desea borrar.

### Opción 5: Alerta de vencimientos

Compara la fecha actual con las fechas registradas en el archivo. Clasifica las cuentas como vencidas, vencen hoy o próximas a vencer entre 1 y 3 días.

### Opción 6: Ganancia total

Suma los montos registrados en el archivo **Streaming.csv** y muestra el total acumulado.

### Opción 7: Salir

Finaliza la ejecución del programa.

## 8. Validaciones implementadas

El sistema incluye validaciones para reducir errores durante la ejecución:

* Validación de opciones del menú del 1 al 7.
* Validación de campos vacíos mediante la función **LeerTexto()**.
* Validación de números dentro de rangos mediante **LeerEntero()**.
* Validación de fecha mediante **LeerFecha()**.
* Validación del número telefónico en el proceso de eliminación.
* Uso de **TryParse** para evitar errores al convertir datos.
* Mensajes de confirmación al registrar o eliminar cuentas.

## 9. Estructuras utilizadas en el código

El programa utiliza:

* Variables.
* Funciones.
* Matrices bidimensionales.
* Listas temporales.
* Condicionales `if`, `else` y `switch`.
* Bucles `do-while` y `for`.
* Manejo de archivos con `StreamReader` y `StreamWriter`.
* Validaciones con `TryParse`.
* Expresiones regulares con `Regex`.

## 10. Limitaciones del sistema

El sistema utiliza un archivo CSV como almacenamiento, por lo que no tiene todavía una base de datos. Además, las credenciales de las cuentas se almacenan en texto plano, por lo que se recomienda no compartir el archivo públicamente.

## 11. Mejoras futuras

* Implementar una base de datos.
* Agregar inicio de sesión para el encargado.
* Cifrar las claves almacenadas.
* Generar reportes por plataforma.
* Mejorar el sistema de alertas.
* Crear copias de seguridad del archivo Streaming.csv.

## 12. Integrantes

* Rodrigo Vizarreta Diaz
* Luis Arellano Bravo
* Leonardo Chavez Rojas
* Jair Harpi Quispe

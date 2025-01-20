# Proyecto: GoApp

## Introducción

GoApp es una aplicación desarrollada con un backend en .NET 8 Web API y un frontend en Angular, diseñada para ofrecer una solución modular y escalable. Este documento proporciona las instrucciones para configurar y ejecutar la aplicación, así como una descripción detallada de su arquitectura.

---

## Configuración del Proyecto

### 1. Requisitos Previos

- **Node.js**: Versión 18 o superior.
- **Angular CLI**: Instalado globalmente.
- **Visual Studio**: Con soporte para .NET 8.
- **Extensión de Azure para Visual Studio Code** (opcional, para publicación en Azure).

### 2. Clonar el Repositorio

1. Clona el repositorio en tu máquina local:
   ```bash
   git clone https://github.com/cristiansep0293/appgo.git
   cd goapp
   ```

---

### 3. Configurar el Proyecto Backend (.NET 8 Web API)

1. Abre el proyecto en Visual Studio.
2. En el Explorador de soluciones, haz clic derecho en el proyecto de Web API (por ejemplo, `goapp.webApi`) y selecciona **Establecer como proyecto de inicio**.
3. En el menú desplegable del entorno de ejecución (ubicado en la parte superior de Visual Studio), selecciona **IIS Express**.

---

### 4. Configurar el Proyecto Frontend (Angular)

1. Abre una nueva terminal en Visual Studio Code.
2. Navega a la carpeta del frontend:
   ```bash
   cd goapp.front
   ```
3. Instala las dependencias necesarias:
   ```bash
   npm install
   ```
4. Ejecuta el servidor de desarrollo de Angular:
   ```bash
   ng serve -o
   ```
   Esto abrirá automáticamente el navegador con la aplicación Angular en ejecución.

---

### Nota sobre la Base de Datos

- Para acceder a la base de datos desde tu aplicación local, es necesario agregar la IP pública de tu máquina al firewall del servidor SQL en Azure.
- Obtén tu IP pública visitando [https://whatismyipaddress.com/](https://whatismyipaddress.com/) o ejecutando el siguiente comando en tu terminal:
  ```bash
  curl ifconfig.me
  ```
- Una vez obtenida, agrégala en el portal de Azure:
  1. Navega al recurso del servidor SQL.
  2. Selecciona **Firewall y redes virtuales**.
  3. Agrégala en el rango permitido.

---

## Arquitectura del Proyecto

### Arquitectura del Backend (Vertical Slice)

El proyecto está estructurado siguiendo el patrón de **Vertical Slice Architecture**, lo que implica que cada funcionalidad o característica se maneja de manera independiente, desde la capa de presentación hasta la de datos.

**Ventajas:**

- Cada "slice" funciona de forma autónoma, lo que facilita el mantenimiento y la escalabilidad del sistema.
- La reducción de dependencias entre diferentes partes del sistema mejora la claridad y el aislamiento de las funcionalidades.

---

### Estructura del Frontend (Angular)

En el frontend, desarrollado con Angular, se ha optado por una organización modular basada en áreas funcionales.

**Características:**

- Cada módulo encapsula componentes, servicios y elementos relacionados con una funcionalidad específica, promoviendo la cohesión y la reutilización del código.
- La estructura facilita la carga perezosa (lazy loading) de módulos, mejorando el rendimiento de la aplicación al cargar solo lo necesario.

---

### Análisis Detallado

#### Backend

- La adopción de la arquitectura Vertical Slice en el backend es beneficiosa para manejar complejidades al dividir el sistema en unidades manejables.
- Cada slice contiene todos los elementos necesarios para una funcionalidad específica, lo que reduce las dependencias entre diferentes partes del sistema.

#### Frontend

- La modularización por áreas en Angular permite que cada equipo o desarrollador trabaje en una parte específica de la aplicación sin interferir con otras.
- Esta estructura también mejora el rendimiento gracias al uso de **lazy loading**, cargando solo los recursos necesarios cuando se acceden.

---

## ¡Todo Listo!

Con estos pasos y esta descripción clara de la arquitectura, deberías tener tu aplicación lista para ejecutarse. Si necesitas soporte adicional, no dudes en pedirlo.

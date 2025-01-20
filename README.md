# appgo

# Manual para Configurar y Ejecutar una Aplicación de .NET 8 Web API con un Frontend en Angular

Este manual detalla los pasos necesarios para configurar y ejecutar una aplicación con un backend en .NET 8 y un frontend en Angular.

---

## 1. Requisitos Previos

Antes de comenzar, asegúrate de cumplir con los siguientes requisitos:

- _Visual Studio 2022 o superior_ (con el workload para desarrollo de .NET y Node.js instalado).
- _Node.js_ (versión 18 o superior).
- _Angular CLI_ (instalado globalmente, puedes instalarlo ejecutando npm install -g @angular/cli).
- _SQL Server_ (si la base de datos está en Azure, necesitarás agregar la IP pública de tu máquina al servidor SQL en Azure).

---

## 2. Clonar el Repositorio

1. Clona el repositorio desde tu sistema de control de versiones (GitHub, Azure DevOps, etc.).

bash

# Reemplaza la URL por la de tu repositorio

git clone https://github.com/cristiansep0293/appgo.git

2. Navega al directorio del repositorio clonado:

bash
cd <appgo>

---

## 3. Configurar el Proyecto Backend (.NET 8 Web API)

1. Abre el proyecto en _Visual Studio_.
2. En el _Explorador de soluciones, haz clic derecho en el proyecto de Web API (por ejemplo, goapp.webApi) y selecciona \*\*Establecer como proyecto de inicio_.
3. En el menú desplegable del entorno de ejecución (ubicado en la parte superior de Visual Studio), selecciona _IIS Express_.

---

## 4. Configurar el Proyecto Frontend (Angular)

1. Abre una nueva terminal en visual studio code:

2. Navega a la carpeta goapp.front desde tu terminal:

bash
cd goapp.front

3. Instala las dependencias necesarias:

bash
npm install

4. Ejecuta el servidor de desarrollo de Angular:

bash
ng serve -o

Esto abrirá automáticamente el navegador con la aplicación Angular en ejecución.

---

## Nota sobre la Base de Datos

- Para acceder a la base de datos desde tu aplicación local, es necesario agregar la _IP pública_ de tu máquina al firewall del servidor SQL en Azure.
- Puedes obtener tu IP pública visitando [https://whatismyipaddress.com/] o ejecutando el siguiente comando en tu terminal:

bash
curl ifconfig.me

Una vez obtenida, agrégala en el portal de Azure:

1. Navega al recurso del servidor SQL.
2. Selecciona _Firewall y redes virtuales_.
3. Agrega la IP pública en el rango permitido.

---

## ¡Todo listo!

Sigue estos pasos para configurar y ejecutar tu aplicación correctamente. Si necesitas soporte adicional, no dudes en pedírmelo.

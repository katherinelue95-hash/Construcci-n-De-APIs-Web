# Construcci-n-De-APIs-Web
En este modulo trabajaremos en construir APIs web 

```
# ✂️ StyleBook Barber - Web API &amp; Mobile Integration (.NET 8 + .NET MAUI)

## 📌 ¿De qué trata el proyecto?
**StyleBook Barber** es una solución integral orientada a la gestión automatizada de reservas de citas y administración de servicios en barberías. El sistema conecta una **Web API RESTful** desarrollada en **ASP.NET Core (.NET 8)** con una aplicación cliente móvil desarrollada en **.NET MAUI**, permitiendo a los clientes explorar el catálogo de cortes, seleccionar su barbero de preferencia, consultar disponibilidad en tiempo real y confirmar su cita de manera fluida.

---

## 🎯 ¿Qué problemática solventa?
La falta de estandarización en la gestión de servicios y la dependencia de llamadas manuales genera desorganización, largas esperas y choques de horarios entre clientes. **StyleBook Barber** solventa esta problemática mediante:
* **Control de colisiones de citas:** Restricción única (`UQ_Citas_Barbero_FechaHora`) a nivel de base de datos SQL Server que impide agendar dos citas para un mismo barbero en el mismo horario.
* **Experiencia de usuario intuitiva (UI/UX Móvil):** Flujo de navegación optimizado desde la autenticación hasta la confirmación de la reserva.
* **Transparencia en el catálogo:** Consulta en tiempo real de precios, duraciones por servicio y perfil/calificación de los barberos.
* **Arquitectura modular desacoplada:** Separación limpia entre capas de negocio, mapeo, endpoints RESTful y la interfaz móvil.

---

## 🏗️ Arquitectura General del Sistema

El ecosistema de software se compone de dos proyectos principales:

```text
StyleBookBarber (Solución Global)
├── 📁 StyleBookBarberBD (Backend Web API)
│   ├── 📁 Models        ──&gt; Entidades de Base de Datos (EF Core / SQL Server)
│   ├── 📁 Dtos          ──&gt; Data Transfer Objects (Contratos JSON)
│   ├── 📁 Services      ──&gt; Capa de Lógica de Negocio e Interfaces
│   ├── 📁 Mappings      ──&gt; Mapeo y conversión bidireccional (Models ↔ DTOs)
│   └── 📁 Endpoints     ──&gt; Exposición de rutas HTTP (Minimal APIs / REST)
│
└── 📁 StyleBookBarber.Mobile (Frontend Móvil .NET MAUI)
    ├── 📁 Views         ──&gt; Pantallas de la App (Vistas XAML / UI)
    ├── 📁 ViewModels    ──&gt; Lógica de presentación y enlace de datos (Data Binding)
    ├── 📁 Services      ──&gt; Consumo de API REST (`ApiService.cs` con HttpClient)
    └── 📁 Models        ──&gt; Modelos cliente formateados para interfaz

```

---

## 📱 Pantallas y Flujo del Frontend Móvil (Wireframes)

La interfaz móvil de **StyleBook Barber** está estructurada en **7 pantallas principales**:

1. **Pantalla 1: Autenticación &amp; Registro (** **LoginView** **)**
  * Inicio de sesión para clientes y barberos mediante correo y contraseña.
  * Enlace rápido para registro de nuevos usuarios.
2. **Pantalla 2: Inicio / Dashboard (** **HomeView** **)**
  * Saludo personalizado, accesos rápidos a agendamiento exprés y catálogo de servicios destacados.
3. **Pantalla 3: Catálogo de Servicios (** **ServiciosView** **)**
  * Tarjetas informativas con foto, nombre del corte, precio y duración estimada en minutos.
4. **Pantalla 4: Selección de Barbero (** **BarberosView** **)**
  * Perfiles de barberos disponibles con especialidad, foto y calificación general.
5. **Pantalla 5: Agendamiento &amp; Horarios (** **AgendarCitaView** **)**
  * Selector interactivo de fecha y turnos disponibles (mañana/tarde) evitando colisiones.
6. **Pantalla 6: Resumen y Confirmación (** **ConfirmacionCitaView** **)**
  * Desglose detallado del servicio, barbero seleccionado, fecha, hora y monto total antes de agendar.
7. **Pantalla 7: Agenda del Día / Panel del Barbero (** **AgendaBarberoView** **)**
  * Vista operativa para el barbero con la lista cronológica de citas asignadas para el día.

---

## 🚀 Pasos de Implementación por Capas

### 🔹 Backend (Web API RESTful)

1. **Models/**: Definición de las 7 entidades relacionales (`Rol`, `Categoria`, `Usuario`, `Barbero`, `HorarioBarbero`, `Servicio`, `Cita`) y el contexto `StyleBookDbContext`.
2. **Dtos/**: Creación de contratos JSON seguros (`LoginDto`, `RegistroDto`, `ServicioDto`, `CitaCreateDto`).
3. **Services/**: Implementación de las reglas de negocio (`AuthService`, `CitaService`) y validación de horarios.
4. **Mappings/**: Métodos de extensión (`MappingExtensions.cs`) para transformar entidades a DTOs de respuesta.
5. **Endpoints/**: Registro de rutas HTTP RESTful (`AuthEndpoints`, `ServiciosEndpoints`, `CitasEndpoints`) y habilitación de **Swagger UI**.

### 🔹 Frontend (Aplicación Móvil .NET MAUI)

1. **Services/ApiService.cs**: Configuración de `HttpClient` para peticiones `GET`, `POST` y `PATCH` hacia el servidor local/remoto.
2. **Views/** **&amp; XAML**: Maquetación responsiva basada en los wireframes de baja y alta fidelidad.
3. **Pruebas y Hot Reload ⚡**: Ejecución en emulador/dispositivo físico sincronizado con la Web API en ejecución.

---

## 🛠️ Tecnologías Utilizadas

* **Backend:** C# / .NET 8 (ASP.NET Core Web API)
* **ORM &amp; Persistencia:** Entity Framework Core 8 / SQL Server
* **Frontend Móvil:** .NET MAUI (C# / XAML)
* **Documentación &amp; Pruebas API:** Swagger UI / Swashbuckle
* **Control de Versiones:** Git &amp; GitHub (`feature-KatherineLúe`)

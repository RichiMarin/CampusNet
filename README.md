# CampusNet MVC (C#)

---

# Descripción del proyecto

CampusNet es una aplicación de consola desarrollada en **C#** que simula una red social académica utilizando la estructura de datos de **Grafos Dirigidos**, aplicando el patrón de arquitectura **MVC (Modelo - Vista - Controlador)**.

El sistema permite:

- Registrar usuarios académicos.
- Crear relaciones de seguimiento dirigidas.
- Ejecutar recorridos BFS y DFS.
- Detectar ciclos dentro del grafo.
- Consultar usuarios influyentes y activos.
- Realizar operaciones CRUD sobre usuarios y relaciones.

---

# Autor

- **Nombre:** Ricardo Marín Herrera
- **Universidad:** Universidad de Manizales
- **Programa:** Ingeniería de Sistemas Virtual
- **Asignatura:** Programación III
- **Proyecto:** CampusNet MVC

---

# Responsabilidades

- Diseño e implementación del grafo dirigido
- Desarrollo del modelo (vértices, aristas y lista de adyacencia)
- Implementación de BFS y DFS
- Detección de ciclos
- Desarrollo del controlador
- Desarrollo de la vista en consola
- Integración del patrón MVC
- Validación y pruebas del sistema

---

# Arquitectura del sistema (MVC)

## Model

Contiene:

- `Vertex.cs`
- `Edge.cs`
- `Graph.cs`

Responsabilidades:

- Gestión del grafo
- Lista de adyacencia
- BFS
- DFS
- CRUD
- Validación de duplicados
- Detección de ciclos

---

## View

Contiene:

- `GraphView.cs`

Responsabilidades:

- Mostrar información en consola
- Imprimir recorridos
- Mostrar lista de adyacencia
- Mostrar resultados de consultas

---

## Controller

Contiene:

- `GraphController.cs`

Responsabilidades:

- Coordinar casos de uso
- Comunicación entre Model y View
- Flujo principal del sistema

---

# Tecnologías utilizadas

- C#
- .NET Console App
- Arquitectura MVC
- Grafos dirigidos
- Git
- GitHub

---

# Estructura del proyecto

```text
CampusNet/
│
├── Controllers/
│   └── GraphController.cs
│
├── Models/
│   ├── Vertex.cs
│   ├── Edge.cs
│   └── Graph.cs
│
├── Views/
│   └── GraphView.cs
│
├── Program.cs
│
├── CampusNet.csproj
│
└── README.md
```

---

# Funcionalidades implementadas

## Construcción del grafo

- Grafo dirigido
- Lista de adyacencia
- Inserción de usuarios
- Inserción de relaciones
- Validación de duplicados

---

## Recorridos

### BFS

- BFS desde múltiples usuarios
- Orden de visita
- Cantidad de vértices alcanzados

### DFS

- DFS completo
- Detección de ciclos

---

# Consultas sociales

- Usuarios sin seguidores
- Usuarios influyentes
- Usuarios más activos
- Verificación de alcanzabilidad entre usuarios

---

# Operaciones CRUD

## Usuarios

- Agregar usuario
- Actualizar usuario
- Eliminar usuario

## Relaciones

- Agregar relación
- Eliminar relación

---

# Ejecución del proyecto

## Clonar repositorio

```bash
git clone https://github.com/RichiMarin/CampusNet.git
```

---

## Ingresar al proyecto

```bash
cd CampusNet
```

---

## Ejecutar aplicación

```bash
dotnet run
```

---

# Requisitos cumplidos

- Grafo dirigido
- Más de 12 vértices
- Más de 18 aristas
- Arquitectura MVC estricta
- BFS
- DFS
- CRUD funcional
- Detección de ciclos
- Validación de duplicados
- Sin lógica de negocio en Main
- Sin consola en Model

---

# Repositorio

Repositorio público:

https://github.com/RichiMarin/CampusNet
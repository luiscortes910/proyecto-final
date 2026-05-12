# Sistema de Gestión de Envíos

## Integrantes

* Brayan Stic Ramirez Posada
* Luis Miguel Cortés Sena

---

# Descripción

Aplicación de consola desarrollada en C# que permite registrar pedidos y calcular automáticamente el tipo y costo de envío según reglas de negocio.

El proyecto implementa una arquitectura modular basada en separación de responsabilidades.

---

# Arquitectura del Proyecto

| Componente      | Responsabilidad                     |
| --------------- | ----------------------------------- |
| Program.cs      | Coordina el inicio del sistema      |
| ConsolaUI       | Maneja entrada y salida por consola |
| EnvioService    | Lógica de negocio                   |
| RegistroService | Historial de pedidos                |
| Validaciones    | Validación de datos                 |
| Pedido          | Modelo de datos                     |

---

# Estructura del Proyecto

```text
SistemaEnviosMejorado/
│
├── Models/
│   └── Pedido.cs
│
├── Services/
│   ├── EnvioService.cs
│   └── RegistroService.cs
│
├── UI/
│   └── ConsolaUI.cs
│
├── Utils/
│   └── Validaciones.cs
│
├── Program.cs
├── README.md
└── .gitignore
```

---

# Funcionalidades

* Registro de pedidos
* Clasificación automática de envíos
* Cálculo de costos
* Historial de pedidos
* Validación de entradas
* Menú interactivo

---

# Reglas de Negocio

| Condición                           | Resultado      |
| ----------------------------------- | -------------- |
| Monto >= 150000 y cliente frecuente | Envío Gratis   |
| 5 o más productos                   | Envío Express  |
| Monto >= 300000                     | Envío Express  |
| Otros casos                         | Envío Estándar |

---

# Tarifas

| Tipo de envío    | Valor    |
| ---------------- | -------- |
| Gratis           | $0       |
| Express          | $20.000  |
| Estándar         | $10.000  |
| Recargo exterior | +$15.000 |

---

# Casos de Prueba

## Caso 1

### Entrada

* Monto: 200000
* Cliente: Frecuente
* Productos: 2
* Zona: Interior

### Resultado esperado

* Tipo de envío: Gratis
* Costo: $0

---

## Caso 2

### Entrada

* Monto: 320000
* Cliente: Nuevo
* Productos: 6
* Zona: Exterior

### Resultado esperado

* Tipo de envío: Express
* Costo: $35.000

---

# Validaciones Implementadas

| Validación | Descripción            |
| ---------- | ---------------------- |
| Decimal    | Solo valores positivos |
| Entero     | Solo números positivos |
| Zona       | Solo 0 o 1             |
| Cliente    | Solo 0 o 1             |
| Menú       | Solo opciones válidas  |

---

# Tecnologías Utilizadas

* C#
* .NET
* Consola

---

# Instrucciones de Ejecución

1. Abrir el proyecto en Visual Studio.
2. Compilar la solución.
3. Ejecutar el programa.
4. Usar el menú interactivo.

---

# Consideraciones

* El historial se almacena en memoria.
* Los datos se pierden al cerrar el programa.
* Aplicación orientada a consola.

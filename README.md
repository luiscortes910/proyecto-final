# Sistema de Gestión de Envíos

## Integrantes

* Brayan Stic Ramirez Posada
* Luis Miguel Cortés Sena

---

# Descripción

Aplicación de consola desarrollada en C# para registrar pedidos y calcular automáticamente el tipo y costo de envío según reglas de negocio.

El sistema implementa arquitectura modular mediante separación de responsabilidades entre interfaz, lógica de negocio, validaciones y almacenamiento de registros.

---

# Arquitectura del Proyecto

| Componente      | Responsabilidad                   |
| --------------- | --------------------------------- |
| Program.cs      | Punto de entrada y coordinación   |
| ConsolaUI       | Interacción con el usuario        |
| EnvioService    | Lógica de clasificación y cálculo |
| RegistroService | Gestión del historial             |
| Validaciones    | Validación de entradas            |
| Pedido          | Modelo de datos                   |

---

# Estructura del Proyecto

```text
SistemaEnviosMejorado/
│
├── Models/
├── Services/
├── UI/
├── Utils/
└── Program.cs
```

---

# Funcionalidades

* Registro de pedidos
* Clasificación automática de envíos
* Cálculo de costos
* Historial de pedidos
* Validaciones de entrada
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

| Tipo             | Valor    |
| ---------------- | -------- |
| Gratis           | $0       |
| Express          | $20.000  |
| Estándar         | $10.000  |
| Recargo Exterior | +$15.000 |

---

# Casos de Prueba

## Caso 1

Entrada:

* Monto: 200000
* Cliente: Frecuente
* Productos: 2
* Zona: Interior

Resultado esperado:

* Tipo: Gratis
* Costo: $0

---

## Caso 2

Entrada:

* Monto: 320000
* Cliente: Nuevo
* Productos: 6
* Zona: Exterior

Resultado esperado:

* Tipo: Express
* Costo: $35.000

---

# Tecnologías Utilizadas

* C#
* .NET
* Consola

---

# Instrucciones de Ejecución

1. Abrir el proyecto en Visual Studio
2. Compilar la solución
3. Ejecutar el programa
4. Usar el menú interactivo

---

# Validaciones Implementadas

* Decimales positivos
* Enteros positivos
* Validación de opciones del menú
* Validación de zona
* Validación de tipo de cliente

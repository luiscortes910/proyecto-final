using System;
using SistemaEnviosMejorado.Models;
using SistemaEnviosMejorado.Services;
using SistemaEnviosMejorado.Utils;

namespace SistemaEnviosMejorado.UI
{
    /// <summary>
    /// Maneja toda la interacción con el usuario por consola.
    /// </summary>
    class ConsolaUI
    {
        private static readonly EnvioService envioService = new EnvioService();

        /// <summary>
        /// Inicia el menú principal del sistema.
        /// </summary>
        /// <param name="registroService">Servicio de registros.</param>
        public static void IniciarMenu(RegistroService registroService)
        {
            string opcion;

            do
            {
                MostrarMenu();
                opcion = Console.ReadLine().Trim();

                switch (opcion)
                {
                    case "1":
                        RegistrarPedido(registroService);
                        break;

                    case "2":
                        MostrarRegistros(registroService);
                        break;

                    case "3":
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (opcion != "3");
        }

        /// <summary>
        /// Muestra el menú principal.
        /// </summary>
        private static void MostrarMenu()
        {
            Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Nuevo envío");
            Console.WriteLine("2. Ver registros");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
        }

        /// <summary>
        /// Registra un nuevo pedido.
        /// </summary>
        /// <param name="registroService">Servicio de registros.</param>
        private static void RegistrarPedido(RegistroService registroService)
        {
            decimal monto = Validaciones.PedirDecimal("Ingrese el monto del pedido:");
            int items = Validaciones.PedirEntero("Cantidad de productos:");

            Zona zona = PedirZona();
            ClienteTipo cliente = PedirCliente();

            string tipoEnvio = envioService.DeterminarEnvio(monto, cliente, items);

            decimal costo = envioService.CalcularCosto(tipoEnvio, zona);

            Pedido pedido = new Pedido
            {
                TipoEnvio = tipoEnvio,
                Precio = costo,
                Momento = DateTime.Now
            };

            registroService.AgregarPedido(pedido);

            MostrarResultado(tipoEnvio, costo);
        }

        /// <summary>
        /// Solicita la zona de envío.
        /// </summary>
        /// <returns>Zona seleccionada.</returns>
        private static Zona PedirZona()
        {
            while (true)
            {
                Console.WriteLine("\nSeleccione zona:");
                Console.WriteLine("0. Interior");
                Console.WriteLine("1. Exterior");

                string opcion = Console.ReadLine().Trim();

                if (opcion == "0")
                {
                    return Zona.Interior;
                }

                if (opcion == "1")
                {
                    return Zona.Exterior;
                }

                Console.WriteLine("Ingrese solo 0 o 1.");
            }
        }

        /// <summary>
        /// Solicita el tipo de cliente.
        /// </summary>
        /// <returns>Tipo de cliente seleccionado.</returns>
        private static ClienteTipo PedirCliente()
        {
            while (true)
            {
                Console.WriteLine("\nSeleccione tipo de cliente:");
                Console.WriteLine("0. Nuevo");
                Console.WriteLine("1. Frecuente");

                string opcion = Console.ReadLine().Trim();

                if (opcion == "0")
                {
                    return ClienteTipo.Nuevo;
                }

                if (opcion == "1")
                {
                    return ClienteTipo.Frecuente;
                }

                Console.WriteLine("Ingrese solo 0 o 1.");
            }
        }

        /// <summary>
        /// Muestra el resultado del pedido.
        /// </summary>
        /// <param name="tipo">Tipo de envío.</param>
        /// <param name="costo">Costo total.</param>
        private static void MostrarResultado(string tipo, decimal costo)
        {
            Console.WriteLine("\n--- RESULTADO ---");
            Console.WriteLine($"Tipo de envío: {tipo}");
            Console.WriteLine($"Costo del envío: ${costo:N0}");

            if (costo == 0)
            {
                Console.WriteLine("El pedido recibió envío gratis.");
            }
        }

        /// <summary>
        /// Muestra el historial de pedidos.
        /// </summary>
        /// <param name="registroService">Servicio de registros.</param>
        private static void MostrarRegistros(RegistroService registroService)
        {
            var pedidos = registroService.ObtenerPedidos();

            Console.WriteLine("\n--- HISTORIAL DE PEDIDOS ---");

            if (pedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados.");
                return;
            }

            foreach (Pedido pedido in pedidos)
            {
                Console.WriteLine(
                    $"{pedido.Momento:HH:mm} | {pedido.TipoEnvio} | ${pedido.Precio:N0}"
                );
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Total pedidos: {pedidos.Count}");
            Console.WriteLine(
                $"Total recaudado: ${registroService.CalcularTotalRecaudado():N0}"
            );
        }
    }
}

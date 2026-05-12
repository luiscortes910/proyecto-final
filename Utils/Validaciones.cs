using System;

namespace SistemaEnviosMejorado.Utils
{
    /// <summary>
    /// Contiene métodos para validar entradas del usuario.
    /// </summary>
    class Validaciones
    {
        /// <summary>
        /// Solicita un número decimal válido.
        /// </summary>
        /// <param name="mensaje">Mensaje mostrado al usuario.</param>
        /// <returns>Número decimal válido.</returns>
        public static decimal PedirDecimal(string mensaje)
        {
            decimal numero;
            bool valido;

            do
            {
                Console.WriteLine(mensaje);

                valido = decimal.TryParse(Console.ReadLine(), out numero)
                         && numero >= 0;

                if (!valido)
                {
                    Console.WriteLine("Valor inválido.");
                }

            } while (!valido);

            return numero;
        }

        /// <summary>
        /// Solicita un número entero válido.
        /// </summary>
        /// <param name="mensaje">Mensaje mostrado al usuario.</param>
        /// <returns>Número entero válido.</returns>
        public static int PedirEntero(string mensaje)
        {
            int numero;
            bool valido;

            do
            {
                Console.WriteLine(mensaje);

                valido = int.TryParse(Console.ReadLine(), out numero)
                         && numero >= 0;

                if (!valido)
                {
                    Console.WriteLine("Número inválido.");
                }

            } while (!valido);

            return numero;
        }
    }
}

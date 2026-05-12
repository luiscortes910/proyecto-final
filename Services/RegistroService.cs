using System.Collections.Generic;
using SistemaEnviosMejorado.Models;

namespace SistemaEnviosMejorado.Services
{
    /// <summary>
    /// Administra el historial de pedidos.
    /// </summary>
    class RegistroService
    {
        private readonly List<Pedido> pedidos = new List<Pedido>();

        /// <summary>
        /// Agrega un pedido al historial.
        /// </summary>
        /// <param name="pedido">Pedido a registrar.</param>
        public void AgregarPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
        }

        /// <summary>
        /// Obtiene la lista de pedidos registrados.
        /// </summary>
        /// <returns>Lista de pedidos.</returns>
        public List<Pedido> ObtenerPedidos()
        {
            return pedidos;
        }

        /// <summary>
        /// Calcula el dinero total recaudado.
        /// </summary>
        /// <returns>Total recaudado.</returns>
        public decimal CalcularTotalRecaudado()
        {
            decimal total = 0;

            foreach (Pedido pedido in pedidos)
            {
                total += pedido.Precio;
            }

            return total;
        }
    }
}

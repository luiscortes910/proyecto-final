using System;

namespace SistemaEnviosMejorado.Models
{
    /// <summary>
    /// Representa un pedido registrado en el sistema.
    /// </summary>
    class Pedido
    {
        /// <summary>
        /// Tipo de envío asignado.
        /// </summary>
        public string TipoEnvio { get; set; }

        /// <summary>
        /// Precio final del envío.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Fecha y hora del pedido.
        /// </summary>
        public DateTime Momento { get; set; }
    }

    /// <summary>
    /// Tipos de cliente disponibles.
    /// </summary>
    enum ClienteTipo
    {
        Nuevo,
        Frecuente
    }

    /// <summary>
    /// Zonas disponibles para envío.
    /// </summary>
    enum Zona
    {
        Interior,
        Exterior
    }
}

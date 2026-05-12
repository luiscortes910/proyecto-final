using SistemaEnviosMejorado.Models;

namespace SistemaEnviosMejorado.Services
{
    /// <summary>
    /// Contiene la lógica de cálculo y clasificación de envíos.
    /// </summary>
    class EnvioService
    {
        private const decimal LIMITE_GRATIS = 150000;
        private const decimal LIMITE_EXPRESS = 300000;

        private const decimal TARIFA_ESTANDAR = 10000;
        private const decimal TARIFA_EXPRESS = 20000;
        private const decimal EXTRA_EXTERIOR = 15000;

        /// <summary>
        /// Determina el tipo de envío según las reglas del negocio.
        /// </summary>
        /// <param name="monto">Monto total del pedido.</param>
        /// <param name="cliente">Tipo de cliente.</param>
        /// <param name="items">Cantidad de productos.</param>
        /// <returns>Tipo de envío correspondiente.</returns>
        public string DeterminarEnvio(decimal monto, ClienteTipo cliente, int items)
        {
            if (monto >= LIMITE_GRATIS && cliente == ClienteTipo.Frecuente)
            {
                return "Gratis";
            }

            if (items >= 5 || monto >= LIMITE_EXPRESS)
            {
                return "Express";
            }

            return "Estandar";
        }

        /// <summary>
        /// Calcula el costo final del envío.
        /// </summary>
        /// <param name="tipo">Tipo de envío.</param>
        /// <param name="zona">Zona de destino.</param>
        /// <returns>Costo total del envío.</returns>
        public decimal CalcularCosto(string tipo, Zona zona)
        {
            decimal valor = tipo switch
            {
                "Gratis" => 0,
                "Express" => TARIFA_EXPRESS,
                _ => TARIFA_ESTANDAR
            };

            if (zona == Zona.Exterior)
            {
                valor += EXTRA_EXTERIOR;
            }

            return valor;
        }
    }
}

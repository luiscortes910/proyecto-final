using SistemaEnviosMejorado.Services;
using SistemaEnviosMejorado.UI;

namespace SistemaEnviosMejorado
{
    class Program
    {
        static void Main()
        {
            RegistroService registroService = new RegistroService();
            ConsolaUI.IniciarMenu(registroService);
        }
    }
}

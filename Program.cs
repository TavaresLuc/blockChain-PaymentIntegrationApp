using System;
using System.IO;
using System.Windows.Forms;

namespace cryptoPayment
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Configuração global da aplicação
            ApplicationConfiguration.Initialize();
            string email = args.Length > 0 ? args[0] : string.Empty;
            string descricao = args.Length > 1 ? args[1] : string.Empty;
            string valor = args.Length > 2 ? args[2] : string.Empty;

            try
            {
                // Inicializa e executa o formulário principal
                Application.Run(new Form1(email, descricao, valor));
            }
            catch (Exception ex)
            {
                // Trata erros não previstos e os registra
                HandleGlobalError(ex);
            }
        }

        /// <summary>
        /// Lida com erros globais não tratados e registra no arquivo de log.
        /// </summary>
        /// <param name="ex">Exceção capturada</param>
        private static void HandleGlobalError(Exception ex)
        {
            // Caminho do arquivo de log
            string logFilePath = "app_errors.log";

            // Escreve o erro no arquivo de log
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {ex.Message}\n{ex.StackTrace}\n\n");

            // Exibe mensagem de erro ao usuário
            MessageBox.Show(
                "Ocorreu um erro inesperado. Verifique o arquivo de log para mais detalhes.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}

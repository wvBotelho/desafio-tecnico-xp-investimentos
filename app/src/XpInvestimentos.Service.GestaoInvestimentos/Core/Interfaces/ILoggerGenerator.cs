using System.Runtime.CompilerServices;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface para implementar o padrão de logs do EM4
    /// </summary>
    public interface ILoggerGenerator
    {
        /// <sumary>
        /// Escreve uma mensagem de log em nível Trace
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        void Trace(string message);

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Trace
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="data">Classe object que contém as informações do contrato recebido pelo microserviço</param>
        void Trace(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0);

        /// <sumary>
        /// Escreve uma mensagem de log em nível Info
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>     
        void Info(string message);

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Info
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="data">Classe object que contém as informações do contrato recebido pelo microserviço</param>
        void Info(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0);

        /// <sumary>
        /// Escreve uma mensagem de log em nível Debug
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>  
        void Debug(string message);

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Debug
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="data">Classe object que contém as informações do contrato recebido pelo microserviço</param>
        void Debug(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0);

        /// <sumary>
        /// Escreve uma mensagem de log em nível Warning
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        void Warning(string message);

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Warning
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="data">Classe object que contém as informações do contrato recebido pelo microserviço</param>
        void Warning(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0);

        /// <sumary>
        /// Escreve uma mensagem de log em nível Error
        /// </sumary>
        /// <param name="e">Exceção de erro</param>
        void Error(Exception e);

        /// <sumary>
        /// Escreve uma mensagem de log em nível Error
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>          
        void Error(string message);

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Error
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="data">Classe object que contém as informações do contrato recebido pelo microserviço</param>
        void Error(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0);
    }
}
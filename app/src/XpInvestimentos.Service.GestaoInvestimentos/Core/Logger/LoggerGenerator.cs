using System.Runtime.CompilerServices;
using Core.Contracts;
using Core.Interfaces;
using NLog;

namespace Core.Logger
{
    public class LoggerGenerator : ILoggerGenerator
    {
        private readonly NLog.Logger logger;

        /// <summary>
        /// Instancia uma nova instância da className LoggerGenerator
        /// </summary>
        public LoggerGenerator(Guid trackingId)
        {
            logger = LogManager.GetCurrentClassLogger();

            logger = logger.WithProperties([new("trackingId", trackingId)]);
        }

        /// <sumary>
        /// Escreve uma mensagem de log em nível Debug
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>  
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Debug
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="log">className object que contém as informações do contrato recebido pelo microserviço</param>
        public void Debug(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0)
        {
            int index = filePath.LastIndexOf('\\') + 1;

            string className = filePath[index..]
                .Replace(".cs", string.Empty);

            Log log = new()
            {
                Class = className,
                Method = memberName,
                Line = fileNumber,
                Data = data
            };

            LogEventInfo logEvent = new(LogLevel.Debug, string.Empty, message);

            logEvent.Properties["log"] = log;

            logger.Debug(logEvent);
        }

        /// <sumary>
        /// Escreve uma mensagem de log em nível Error
        /// </sumary>
        /// <param name="e">Exceção de erro</param>
        public void Error(Exception e)
        {
            logger.Error(e, e.Message);
        }

        /// <sumary>
        /// Escreve uma mensagem de log em nível Error
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>   
        public void Error(string message)
        {
            logger.Error(message);
        }

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Error
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="log">className object que contém as informações do contrato recebido pelo microserviço</param>
        public void Error(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0)
        {
            int index = filePath.LastIndexOf('\\') + 1;

            string className = filePath[index..]
                .Replace(".cs", string.Empty);

            Log log = new()
            {
                Class = className,
                Method = memberName,
                Line = fileNumber,
                Data = data
            };

            LogEventInfo logEvent = new(LogLevel.Error, string.Empty, message);

            logEvent.Properties["log"] = log;

            logger.Error(logEvent);
        }

        /// <sumary>
        /// Escreve uma mensagem de log em nível Info
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        public void Info(string message)
        {
            logger.Info(message);
        }

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Info
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="data">className object que contém as informações do contrato recebido pelo microserviço</param>
        public void Info(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0)
        {
            int index = filePath.LastIndexOf('\\') + 1;

            string className = filePath[index..]
                .Replace(".cs", string.Empty);

            Log log = new()
            {
                Class = className,
                Method = memberName,
                Line = fileNumber,
                Data = data
            };

            LogEventInfo logEvent = new(LogLevel.Info, string.Empty, message);

            logEvent.Properties["log"] = log;

            logger.Info(logEvent);
        }

        /// <sumary>
        /// Escreve uma mensagem de log em nível Trace
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        public void Trace(string message)
        {
            logger.Trace(message);
        }

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Trace
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="log">className object que contém as informações do contrato recebido pelo microserviço</param>
        public void Trace(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0)
        {
            int index = filePath.LastIndexOf('\\') + 1;

            string className = filePath[index..]
                .Replace(".cs", string.Empty);

            Log log = new()
            {
                Class = className,
                Method = memberName,
                Line = fileNumber,
                Data = data
            };

            LogEventInfo logEvent = new(LogLevel.Info, string.Empty, message);

            logEvent.Properties["log"] = log;

            logger.Trace(logEvent);
        }

        /// <sumary>
        /// Escreve uma mensagem de log em nível Warning
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        public void Warning(string message)
        {
            logger.Warn(message);
        }

        /// <sumary>
        /// Escreve uma mensagem de log customizada com informações de contrato em nível Warning
        /// </sumary>
        /// <param name="message">A mensagem que será exibida no log</param>
        /// <param name="log">className object que contém as informações do contrato recebido pelo microserviço</param>
        public void Warning(string message, object data, [CallerFilePath] string filePath = "", [CallerMemberName]string memberName = "", 
            [CallerLineNumber] int fileNumber = 0)
        {
            int index = filePath.LastIndexOf('\\') + 1;

            string className = filePath[index..]
                .Replace(".cs", string.Empty);

            Log log = new()
            {
                Class = className,
                Method = memberName,
                Line = fileNumber,
                Data = data
            };

            LogEventInfo logEvent = new(LogLevel.Info, string.Empty, message);

            logEvent.Properties["log"] = log;

            logger.Warn(logEvent);
        }
    }
}
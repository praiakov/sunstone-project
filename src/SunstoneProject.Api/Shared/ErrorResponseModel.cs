using System;
using System.Collections.Generic;

namespace SunstoneProject.Api.Shared
{
    /// <summary>
    /// Error Response Model
    /// </summary>
    public class ErrorResponseModel
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ErrorResponseModel(string code, string message)
        {
            Code = code;
            Message = message;
        }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="errors"></param>
        public ErrorResponseModel(string code, string message, List<string> errors)
        {
            Code = code;
            Message = message;
            Details = errors;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public ErrorResponseModel(Exception ex)
        {
            while (ex != null)
            {
                Details.Add(ex.Message);
                ex = ex.InnerException;
            }
        }

        ///<inheritdoc/>
        public ErrorResponseModel(string code, string message, Exception ex)
        {
            Code = code;
            Message = message;

            while (ex != null)
            {
                Details.Add(ex.Message);
                ex = ex.InnerException;
            }
        }

        /// <summary>
        /// Code error
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Exception message error
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Lista de erros
        /// </summary>
        public List<string> Details { get; private set; } = new List<string>();
    }
}

using System;
using System.Collections.Generic;

namespace SunstoneProject.Api.Shared
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public ErrorResponseModel(string code, string message, List<string> errors)
        {
            Code = code;
            Message = message;
            Details = errors;
        }

        public ErrorResponseModel(Exception ex)
        {
            while (ex != null)
            {
                Details.Add(ex.Message);
                ex = ex.InnerException;
            }
        }

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

        public string Code { get; private set; }

        public string Message { get; private set; }

        public List<string> Details { get; private set; } = new List<string>();
    }
}

using System;

namespace SunstoneProject.Domain.Exceptions
{
    public class CustomErrorException : Exception
    {
        public string Code { get; set; }

        public CustomErrorException(string code, string message)
            : base(message)
        {
            Code = code;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TemplateEngine
{
    [Serializable]
    internal class RazorEngineException : Exception
    {
        public string Message { get; set; }

        public RazorEngineException(string? message) : base(message)
        {
        }

        public RazorEngineException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}

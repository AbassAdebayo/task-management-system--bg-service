using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        T Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace inventory.DTO
{
    public class ErrorModeDto
    {
        public string title { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
    
}
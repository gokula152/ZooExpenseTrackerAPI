using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ZooExpenseTracker.Lib.Model
{
    public class FileInputModel
    {
        public IFormFile? PricesFile { get; set; }
        public IFormFile? AnimalsFile { get; set; }
        public IFormFile? ZooFile { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_Architecture_Pattern.Models
{
    internal class Student // Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Marks { get; set; } 
        public string Address { get; set; }
    }
}

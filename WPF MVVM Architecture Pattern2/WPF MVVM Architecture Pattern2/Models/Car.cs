using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
     * Model:

    Represents the application's data and business logic.
    Should be unaware of the user interface.
 */
namespace WPF_MVVM_Architecture_Pattern2.Models
{
    public class Car // Model
    {
        public string Color { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}

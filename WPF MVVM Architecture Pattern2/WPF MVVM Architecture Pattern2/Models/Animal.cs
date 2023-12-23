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
    public class Animal // Model
    {
        public string Species { get; set; }
        public string Sound { get; set; }
        public string Type { get; set; }

    }
}

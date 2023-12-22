using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Architecture_Pattern.Models;
using System.Collections.ObjectModel;

namespace WPF_MVVM_Architecture_Pattern.ViewModels
{
    internal class Studentdata // View Model
    {
        public Studentdata()
        {
            Students = new ObservableCollection<Student>
            {
                new Student() { Id = 1, Name = "Vladimir", Marks= 99.4, Address ="Svilengrad"},
                new Student() { Id = 2, Name = "Pesho", Marks= 78.2, Address ="Plovdiv"},
                new Student() { Id = 3, Name = "Gosho", Marks= 45.7, Address ="Sofia"},
                new Student() { Id = 4, Name = "Svetlin", Marks= 97.2, Address ="Manastirski Livadi"},
                new Student() { Id = 5, Name = "Stanislav", Marks= 99.8, Address ="London"},
                new Student() { Id = 6, Name = "Martin", Marks= 96.9, Address ="Sofia"},
                new Student() { Id = 7, Name = "Ivan", Marks= 82.3, Address ="Varna"},
            };
         }
        public ObservableCollection<Student> Students { get; set; }
    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wine
{
    public class Cargo
    {
        public string Name { get; set; }       // Наименование груза
        public int MinQuantity { get; set; }   // Минимальное количество
        public int MaxQuantity { get; set; }   // Максимальное количество
        public double WeightPerUnit { get; set; } // Вес единицы груза
    }
}

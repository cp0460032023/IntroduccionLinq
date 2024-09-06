using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionLinq
{
    // Definición de la clase 'Enfermero' dentro del namespace 'IntroduccionLinq'.
    // La clase 'Enfermero' hereda de la clase 'Empleado', lo que significa que obtiene todas las propiedades y métodos de 'Empleado'.
    internal class Enfermero : Empleado
    {
        // Propiedad que representa el nombre del enfermero.
        public new string Nombre { get; set; }
    }
}


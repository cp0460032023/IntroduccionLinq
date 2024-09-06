using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionLinq
{
    // Definición de la clase 'Medico' dentro del namespace 'IntroduccionLinq'.
    // La clase 'Medico' hereda de la clase 'Empleado', obteniendo todas las propiedades y métodos de 'Empleado'.
    internal class Medico : Empleado
    {
        // Propiedad que representa el nombre del médico.
        public new string Nombre { get; set; }
    }
}


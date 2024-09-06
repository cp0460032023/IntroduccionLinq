using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionLinq
{
    // Definición de la clase 'Habitante' dentro del namespace 'IntroduccionLinq'.
    public class Habitante
    {
        // Propiedad que representa el identificador único del habitante.
        public int IdHabitante { get; set; }

        // Propiedad que representa el nombre del habitante.
        public string Nombre { get; set; }

        // Propiedad que representa la edad del habitante.
        public int Edad { get; set; }

        // Propiedad que representa el identificador de la casa en la que vive el habitante.
        public int IdCasa { get; set; }

        // Método que devuelve una cadena con los detalles del habitante.
        public string datosHabitante()
        {
            return $"Soy {Nombre} con edad de {Edad} años vividos en {IdCasa}";
        }
    }
}


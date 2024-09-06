using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionLinq
{
    // Definición de la clase 'Casa' dentro del namespace 'IntroduccionLinq'.
    public class Casa
    {
        // Propiedad que representa el identificador único de la casa.
        public int Id { get; set; }

        // Propiedad que representa la dirección de la casa.
        public string Direccion { get; set; }

        // Propiedad que representa la ciudad donde se encuentra la casa.
        public string Ciudad { get; set; }

        // Propiedad que representa el número de habitaciones de la casa.
        public int numeroHabitaciones { get; set; }

        // Método que devuelve una cadena con los detalles de la casa.
        public string dameDatosCasa()
        {
            return $"Dirección es {Direccion} en la ciudad de {Ciudad} con número de habitaciones {numeroHabitaciones}";
        }
    }
}


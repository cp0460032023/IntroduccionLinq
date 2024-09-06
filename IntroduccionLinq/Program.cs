using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionLinq
{
    // Definición de la clase 'Program' que contiene el punto de entrada de la aplicación.
    class Program
    {
        // Método principal 'Main', el punto de entrada de la aplicación.
        static void Main(string[] args)
        {
            // Creación de las listas para almacenar objetos de tipo 'Casa' y 'Habitante'.
            List<Casa> ListaCasas = new List<Casa>();
            List<Habitante> ListaHabitantes = new List<Habitante>();

            // Añadir elementos a la lista 'ListaCasas' que contiene objetos de tipo 'Casa'.
            ListaCasas.Add(new Casa
            {
                Id = 1,
                Direccion = "3 av Norte ArcanCity",
                Ciudad = "Gothan City",
                numeroHabitaciones = 20
            });

            ListaCasas.Add(new Casa
            {
                Id = 2,
                Direccion = "6 av Sur SmollVille",
                Ciudad = "Metropolis",
                numeroHabitaciones = 5
            });

            ListaCasas.Add(new Casa
            {
                Id = 3,
                Direccion = "Forest Hills, Queens, NY 11375",
                Ciudad = "New York",
                numeroHabitaciones = 10
            });

            // Añadir elementos a la lista 'ListaHabitantes' que contiene objetos de tipo 'Habitante'.
            ListaHabitantes.Add(new Habitante
            {
                IdHabitante = 1,
                Nombre = "Bruno Diaz",
                Edad = 36,
                IdCasa = 1
            });

            ListaHabitantes.Add(new Habitante
            {
                IdHabitante = 2,
                Nombre = "Clark Kent",
                Edad = 40,
                IdCasa = 2
            });

            ListaHabitantes.Add(new Habitante
            {
                IdHabitante = 3,
                Nombre = "Peter Parker",
                Edad = 25,
                IdCasa = 3
            });

            ListaHabitantes.Add(new Habitante
            {
                IdHabitante = 4,
                Nombre = "Tia May",
                Edad = 85,
                IdCasa = 3
            });

            ListaHabitantes.Add(new Habitante
            {
                IdHabitante = 5,
                Nombre = "Luise Lane",
                Edad = 40,
                IdCasa = 2
            });

            ListaHabitantes.Add(new Habitante
            {
                IdHabitante = 6,
                Nombre = "Selina Kyle",
                Edad = 30,
                IdCasa = 1
            });

            ListaHabitantes.Add(new Habitante
            {
                IdHabitante = 7,
                Nombre = "Alfred",
                Edad = 36,
                IdCasa = 1
            });

            ListaHabitantes.Add(new Habitante
            {
                IdHabitante = 8,
                Nombre = "Nathan Drake",
                Edad = 36,
                IdCasa = 1
            });

            // Consulta LINQ para obtener habitantes con edad mayor a 30.
            IEnumerable<Habitante> ListaEdad = from ObjetoProvicional in ListaHabitantes
                                               where ObjetoProvicional.Edad > 30
                                               select ObjetoProvicional;

            // Imprimir los habitantes con edad mayor a 30 años.
            Console.WriteLine("Habitantes con edad mayor a 30 años:");
            foreach (Habitante objetoProcicional2 in ListaEdad)
            {
                Console.WriteLine(objetoProcicional2.datosHabitante());
            }

            // Consulta LINQ para obtener habitantes que viven en "Gothan City" usando un join.
            IEnumerable<Habitante> listaCasaGothan = from objetoTemporalHabitante in ListaHabitantes
                                                     join objetoTemporalCasa in ListaCasas
                                                     on objetoTemporalHabitante.IdCasa equals objetoTemporalCasa.Id
                                                     where objetoTemporalCasa.Ciudad == "Gothan City"
                                                     select objetoTemporalHabitante;

            // Imprimir los habitantes que viven en "Gothan City".
            Console.WriteLine("\nHabitantes de Gothan City:");
            foreach (Habitante h in listaCasaGothan)
            {
                Console.WriteLine(h.datosHabitante());
            }



            #region FirsthAndFirsthOrDefault

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            // Obtiene la primera casa de la lista 'ListaCasas'.
            // Lanza una excepción si la lista está vacía.
            var primeraCasa = ListaCasas.First();
            Console.WriteLine(primeraCasa.dameDatosCasa());

            // Aplicando una restricción sin usar expresión lambda.
            // Se utiliza LINQ para seleccionar el primer habitante cuya edad es mayor que 25.
            // 'First()' lanza una excepción si no se encuentra ningún elemento que coincida con la condición.
            Habitante personaEdad = (from variableTemporalHabitante in ListaHabitantes
                                     where variableTemporalHabitante.Edad > 25
                                     select variableTemporalHabitante).First();
            Console.WriteLine(personaEdad.datosHabitante());

            Console.WriteLine("---------------------------Lo mismo pero con lambdas---------------------------------------------------------");

            // Realiza la misma operación que la consulta LINQ anterior, pero utilizando una expresión lambda.
            // 'First()' se aplica directamente a 'ListaHabitantes' con la condición de que 'Edad' sea mayor que 25.
            var Habitante1 = ListaHabitantes.First(objectTemp => objectTemp.Edad > 25);
            Console.WriteLine(Habitante1.datosHabitante());

            // Si no se encuentra el elemento buscado, 'First()' lanzará una excepción que detendrá la ejecución del código.
            // Esto puede ser riesgoso si no se maneja adecuadamente, ya que detendrá el programa completo.

            // Casa EdadError = (from vCasaTemp in ListaCasas where vCasaTemp.Id >10 select vCasaTemp).First();
            // Console.WriteLine(EdadError.dameDatosCasa());

            // 'FirstOrDefault()' devuelve el primer elemento que cumple con la condición, o el valor predeterminado (null) si no se encuentra.
            // En este caso, busca una casa con un 'Id' mayor a 200, que no existe en la lista.
            Casa CasaConFirsthOrDedault = ListaCasas.FirstOrDefault(vCasa => vCasa.Id > 200);

            // Verifica si 'CasaConFirsthOrDedault' es null, lo que indica que no se encontró ninguna casa que cumpliera la condición.
            if (CasaConFirsthOrDedault == null)
            {
                Console.WriteLine("No existe !No hay!");
                return; // Termina la ejecución del método 'Main'.
            }

            // Este bloque se ejecuta solo si se encuentra una casa que cumpla con la condición.
            Console.WriteLine("existe !Si existe!");

            #endregion


            #region Last

            // Obtiene el último elemento de la lista 'ListaCasas' que cumple con la condición especificada.
            // En este caso, busca la última casa cuyo 'Id' sea mayor que 1.
            // 'Last()' lanza una excepción si no se encuentra ningún elemento que cumpla con la condición.
            Casa ultimaCasa = ListaCasas.Last(temp => temp.Id > 1);
            Console.WriteLine(ultimaCasa.dameDatosCasa());

            Console.WriteLine("_____________________________________________________");

            // Realiza una consulta LINQ para obtener el último habitante cuya edad es mayor de 60.
            // Utiliza 'LastOrDefault()' para evitar excepciones en caso de que no haya habitantes que cumplan con la condición.
            // 'LastOrDefault()' devuelve el último elemento que cumple con la condición o el valor predeterminado (null) si no se encuentra ninguno.
            var h1 = (from objHabitante in ListaHabitantes
                      where objHabitante.Edad > 60
                      select objHabitante).LastOrDefault();

            // Verifica si 'h1' es null, lo que indica que no se encontró ningún habitante que cumpla con la condición.
            // Si es null, imprime un mensaje de error y termina la ejecución del método 'Main'.
            if (h1 == null)
            {
                Console.WriteLine("Algo fallo");
                return; // Termina la ejecución del método 'Main'.
            }

            // Imprime los detalles del habitante encontrado.
            Console.WriteLine(h1.datosHabitante());

            #endregion


            #region ElementAt

            // Obtiene el tercer elemento (índice 2) de la lista 'ListaCasas'.
            // 'ElementAt()' devuelve el elemento en la posición especificada. Si el índice está fuera de los límites de la secuencia, lanza una excepción.
            var terceraCasa = ListaCasas.ElementAt(2);
            Console.WriteLine($"La tercera casa es {terceraCasa.dameDatosCasa()}");

            // Obtiene el cuarto elemento (índice 3) de la lista 'ListaCasas' usando 'ElementAtOrDefault()'.
            // 'ElementAtOrDefault()' devuelve el elemento en la posición especificada o el valor predeterminado (null) si el índice está fuera de los límites de la secuencia.
            var casaError = ListaCasas.ElementAtOrDefault(3);

            // Verifica si 'casaError' no es null antes de imprimir los detalles de la casa.
            // Esto previene el acceso a un elemento inexistente y evita excepciones.
            if (casaError != null)
            {
                Console.WriteLine($"La cuarta casa es {casaError.dameDatosCasa()}");
            }

            // Realiza una consulta LINQ para seleccionar todos los habitantes y luego obtiene el tercer elemento (índice 2) usando 'ElementAtOrDefault()'.
            var segundoHabitante = (from objetoTem in ListaHabitantes select objetoTem).ElementAtOrDefault(2);

            // Imprime los detalles del segundo habitante obtenido. 
            // Si el índice está fuera del rango, 'segundoHabitante' será null y se evitará el acceso a una referencia nula.
            Console.WriteLine($"El segundo habitante es : {segundoHabitante?.datosHabitante()}");

            #endregion


            #region single

            try
            {
                // Obtiene un único elemento de la lista 'ListaHabitantes' que cumple con la condición especificada.
                // 'Single()' lanza una excepción si no hay exactamente un elemento que cumpla con la condición, o si hay más de un elemento que la cumple.
                var habitantes = ListaHabitantes.Single(variableTem => variableTem.Edad > 40 && variableTem.Edad < 70);

                // Realiza una consulta LINQ para obtener un único habitante cuya edad sea mayor de 70.
                // 'SingleOrDefault()' devuelve el único elemento que cumple con la condición o el valor predeterminado (null) si no se encuentra ningún elemento.
                var habitante2 = (from obtem in ListaHabitantes
                                  where obtem.Edad > 70
                                  select obtem).SingleOrDefault();

                // Imprime los detalles del habitante que cumple con la primera condición.
                Console.WriteLine($"Habitante con edad entre 40 y 70 años: {habitantes.datosHabitante()}");

                // Verifica si 'habitante2' no es null antes de imprimir los detalles del habitante.
                // Esto evita errores al intentar acceder a una propiedad de un objeto null.
                if (habitante2 != null)
                {
                    Console.WriteLine($"Habitante con más de 70 años: {habitante2.datosHabitante()}");
                }
            }
            catch (Exception)
            {
                // Captura cualquier excepción que ocurra durante la ejecución del bloque 'try'.
                // Imprime un mensaje de error en la consola si ocurre una excepción.
                Console.WriteLine($"Ocurrió un error");
            }

            #endregion


            #region typeOf

            // Crea una lista de objetos de tipo 'Empleado', que contiene instancias de 'Medico' y 'Enfermero'.
            var listaEmpleados = new List<Empleado>()
            {
                new Medico(){ Nombre= "Jorge Casa" },
                new Enfermero(){ Nombre = "Raul Blanco"}
            };

            // Usa 'OfType<Medico>()' para filtrar la lista y obtener solo los elementos que son de tipo 'Medico'.
            // 'OfType<T>()' devuelve una secuencia que contiene solo los elementos del tipo especificado.
            var medico = listaEmpleados.OfType<Medico>();

            // 'Single()' se utiliza para obtener el único elemento de la secuencia que cumple con la condición especificada.
            // Como se espera que haya solo un 'Medico' en la lista, 'Single()' devuelve ese elemento.
            // Luego se imprime el nombre del médico.
            Console.WriteLine(medico.Single().Nombre);

            #endregion


            #region OrderBy

            // Ordena la lista de 'ListaHabitantes' por la propiedad 'Edad' en orden ascendente.
            // 'OrderBy' es un método de LINQ que devuelve una secuencia ordenada de elementos en función de una clave especificada.
            var edadA = ListaHabitantes.OrderBy(x => x.Edad);

            // Realiza la misma operación de ordenamiento usando una consulta LINQ.
            // 'orderby' especifica el criterio de ordenamiento, que en este caso es la propiedad 'Edad'.
            var edadAC = from vt in ListaHabitantes
                         orderby vt.Edad
                         select vt;

            // Itera sobre la secuencia ordenada y imprime los detalles de cada habitante.
            // El uso de 'foreach' permite recorrer cada elemento de la secuencia y realizar una acción con él.
            foreach (var edad in edadAC)
            {
                Console.WriteLine(edad.datosHabitante());
            }

            #endregion


            #region OrderBYDescending()

            // Ordena la lista 'ListaHabitantes' por la propiedad 'Edad' en orden descendente.
            // 'OrderByDescending' es un método de LINQ que devuelve una secuencia ordenada de elementos en función de una clave especificada en orden descendente.
            var listaEdad = ListaHabitantes.OrderByDescending(x => x.Edad);

            // Itera sobre la secuencia ordenada en orden descendente y imprime los detalles de cada habitante.
            // 'foreach' permite recorrer cada elemento de la secuencia ordenada y realizar una acción con él.
            foreach (Habitante h in listaEdad)
            {
                Console.WriteLine(h.datosHabitante());
            }

            Console.WriteLine("-------------------------------------------");

            // Realiza el mismo ordenamiento usando una consulta LINQ.
            // 'orderby h.Edad descending' especifica el ordenamiento en función de la propiedad 'Edad' en orden descendente.
            var ListaEdad2 = from h in ListaHabitantes
                             orderby h.Edad descending
                             select h;

            // Itera sobre la secuencia ordenada por la consulta LINQ y imprime los detalles de cada habitante.
            foreach (Habitante h in ListaEdad2)
            {
                Console.WriteLine(h.datosHabitante());
            }

            #endregion


            #region thenBy

            // Ordena la lista 'ListaHabitantes' primero por la propiedad 'Edad' en orden ascendente.
            // Luego, aplica un segundo nivel de ordenamiento por la propiedad 'Nombre' en orden ascendente.
            // 'ThenBy()' se utiliza para realizar un segundo nivel de ordenamiento adicional después de haber ordenado por la clave principal.
            var habitantes3 = ListaHabitantes.OrderBy(x => x.Edad).ThenBy(x => x.Nombre);

            // Itera sobre la secuencia ordenada por 'Edad' y luego por 'Nombre', y imprime los detalles de cada habitante.
            foreach (var h in habitantes3)
            {
                Console.WriteLine(h.datosHabitante());
            }

            // Realiza el mismo ordenamiento utilizando una consulta LINQ.
            // 'orderby h.Edad, h.Nombre ascending' especifica el ordenamiento por 'Edad' y luego por 'Nombre', ambos en orden ascendente.
            var lista4 = from h in ListaHabitantes
                         orderby h.Edad, h.Nombre ascending
                         select h;

            // Itera sobre la secuencia ordenada por 'Edad' y luego por 'Nombre', y imprime los detalles de cada habitante.
            foreach (var h in lista4)
            {
                Console.WriteLine(h.datosHabitante());
            }

            // Ordena la lista 'ListaHabitantes' primero por la propiedad 'Edad' en orden ascendente.
            // Luego, aplica un segundo nivel de ordenamiento por la propiedad 'Nombre' en orden descendente.
            // 'ThenByDescending()' se utiliza para realizar un segundo nivel de ordenamiento adicional en orden descendente.
            var habitantes4 = ListaHabitantes.OrderBy(x => x.Edad).ThenByDescending(x => x.Nombre);

            // Itera sobre la secuencia ordenada por 'Edad' y luego por 'Nombre' (en orden descendente), y imprime los detalles de cada habitante.
            foreach (var h in habitantes4)
            {
                Console.WriteLine(h.datosHabitante());
            }

            // Realiza el mismo ordenamiento utilizando una consulta LINQ.
            // 'orderby h.Edad, h.Nombre descending' especifica el ordenamiento por 'Edad' y luego por 'Nombre' en orden descendente.
            var edad = from h in ListaHabitantes
                       orderby h.Edad, h.Nombre descending
                       select h;

            // Itera sobre la secuencia ordenada por 'Edad' y luego por 'Nombre' (en orden descendente), y imprime los detalles de cada habitante.
            foreach (var h in edad)
            {
                Console.WriteLine(h.datosHabitante());
            }

            #endregion
        }
    }
}

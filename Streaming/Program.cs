using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Streaming
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                opcion = menu();

                switch (opcion)
                {
                    case 1:
                        break;
                    case 2:
                        break; 
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        guardar_cargar();
                        break;
                    case 6:
                        break;
                }
            }
            while (opcion != 6);
        }

        static int menu()
        {
            Console.WriteLine("=== MENÚ ===\n");
            Console.WriteLine("1) Registrar sucripciones");
            Console.WriteLine("2) Ver suscripciones activas");
            Console.WriteLine("3) Ver alertas de vencimiento");
            Console.WriteLine("4) Buscar suscripción");
            Console.WriteLine("5) Guardar/Cargar registros");   // Desde archivo
            Console.WriteLine("6) Salir\n");

            Console.Write("Ingrese una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            return opcion;
        }

        static void guardar_cargar()
        {
            using (StreamWriter escritor = new StreamWriter("prueba.txt"))
            {
                escritor.WriteLine("HOLA PANCHITO CHUPA");  
            }
        }
    }
}

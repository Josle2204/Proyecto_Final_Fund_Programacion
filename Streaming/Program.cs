using System.Data;
using System.Reflection.Metadata;

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
                        Console.Clear();
                        mostrar_clientes();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.Clear();
                        cuentas_vencidas();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                }
            }
            while (opcion != 7);
        }   

        static int menu()
        {
            int opcion = 0;
            bool valido;

            Console.WriteLine("=== MENÚ ===\n");
            Console.WriteLine("1) Mostrar clientes");
            Console.WriteLine("2) Buscar cliente");
            Console.WriteLine("3) Registrar cuenta");
            Console.WriteLine("4) Eliminar cuenta");
            Console.WriteLine("5) Cuentas vencidas");
            Console.WriteLine("6) Ganancia total");
            Console.WriteLine("7) Salir\n");

            Console.Write("Ingrese una opción: ");

            do
            {
                valido = int.TryParse(Console.ReadLine(), out opcion);

                if (opcion < 1 || opcion > 7)
                {
                    Console.Write("\nIngrese una opción válida: ");
                    valido = false;
                }

            } while (!valido);

            return opcion;
        }

        static string[,] cargar_archivo()
        {
            using (StreamReader lector = new StreamReader("Streaming.csv"))
            {
                string datos = lector.ReadToEnd();
                string[] lineas = datos.Split('\n');
                string[,] matriz_datos = new string[100, 6];


                for (int i = 0; i < lineas.Length; i++)
                {
                    string[] lineas_separadas = lineas[i].Split(';');

                    for (int j = 0; j < 6; j++)
                    {
                        matriz_datos[i, j] = lineas_separadas[j];
                    }
                }

                return matriz_datos;
            }
        }

        static void mostrar_clientes()
        {
            string[,] matriz_datos = cargar_archivo();

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"  TELÉFONO",-13} {"PRECIO",-8} {"VENCIMIENTO",-30} {"CUENTA",-30} {"PERFIL",-20} {"PLATAFORMA",-12}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                Console.WriteLine($"{matriz_datos[i,0],-11} {matriz_datos[i, 1],-8:C} {matriz_datos[i, 2],-12:dd/MM/yyyy} {matriz_datos[i, 3],-48} {matriz_datos[i, 4],-20} {matriz_datos[i, 5],-12}"); ;
            }

            Console.Write("\nPresione una tecla para continuar...");
        }

        static void cuentas_vencidas()
        {
            string[,] matriz_datos = cargar_archivo ();

            Console.WriteLine("\n===== Cuentas vencidas =====");
            bool hayVencidas = false;

            DateTime fechaActual = DateTime.Today;
            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                if (string.IsNullOrEmpty(matriz_datos[i, 2]))
                continue;

                bool fechaValida = DateTime.TryParse(
                  matriz_datos[i, 2],
                  out DateTime fechaVencimiento
                );

                if (!fechaValida)
                   continue;

                if (fechaVencimiento < fechaActual)
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("TELÉFONO: " + matriz_datos[i, 0]);
                    Console.WriteLine("CUENTA: " + matriz_datos[i, 3]);
                    Console.WriteLine("PERFIL: " + matriz_datos[i, 4]);
                    Console.WriteLine("PLATAFORMA: " + matriz_datos[i, 5]);
                    Console.WriteLine("VENCIMIENTO: " + matriz_datos[i, 2]);
                    Console.WriteLine("-------------------------------------------");

                    hayVencidas = true;
                }
            }

            if (!hayVencidas)
            {
                 Console.WriteLine("No hay cuentas vencidas.");
            }
        }
        
    }
}
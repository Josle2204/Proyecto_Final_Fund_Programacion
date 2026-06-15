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
                        
                        break;
                    case 6:
                        Console.Clear();
                        ganancia_total();
                        console.Clear();
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
        static void ganancia_total()
        {
          Console.Clear();
          string[,] matriz_datos = cargar_archivo();
          decimal total = 0;
          int registros_sumados = 0;

          //este for recorreria todas las filas de la matriz
          for(int i = 0; i < matriz_datos.GetLength(0); i++);
            {
                //esto es para que vea si existe algun nulo en el csv y el && es por si en vez de vacio ponen ""
               if(matriz_datos[i,1] != null && matriz_datos[i,1] != "")
                {
                    //esto es para convertir todo el texto a numero para acto siguiente sumarlo
                  if(decimal.TryParse(matriz_datos[i,1],out decimal PRECIO))
                    {
                        total += PRECIO;
                    }
                }
            }
            Console.WriteLine("========================================");
            Console.WriteLine("       REPORTE DE GANANCIA TOTAL        ");
            Console.WriteLine("========================================");
            Console.WriteLine($"     LA GANANCIA TOTAL ES: {total:C}   ");
            Console.WriteLine("========================================");
            Console.Write("\nPresione una tecla para regresar al menú...");
            Console.ReadKey();


            

        }
    }
}
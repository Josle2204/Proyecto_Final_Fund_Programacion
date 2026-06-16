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
                        alertas_vencimiento();
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
            Console.WriteLine("5) Alertas de vencimiento");
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
            Console.WriteLine($"{"TELÉFONO",-15} {"PRECIO",-8} {"VENCIMIENTO",-12} {"CUENTA",-65} {"PERFIL",-25} {"PLATAFORMA",-18} {"ESTADO",-12}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                Console.WriteLine($"{matriz_datos[i,0],-11} {matriz_datos[i, 1],-8:C} {matriz_datos[i, 2],-12:dd/MM/yyyy} {matriz_datos[i, 3],-48} {matriz_datos[i, 4],-20} {matriz_datos[i, 5],-12}"); ;
            }

            Console.Write("\nPresione una tecla para continuar...");
        }

        static void alertas_vencimiento()
        {
            string[,] matriz_datos = cargar_archivo();
            DateTime fechaActual = DateTime.Today;

            bool hayVencidas = false;
            bool hayVenceHoy = false;
            bool hayPorVencer = false;

            Console.WriteLine("\n================ ALERTAS DE VENCIMIENTO ================\n");

            // =========================
            // 1. CUENTAS VENCIDAS
            // =========================

            Console.WriteLine("=============== CUENTAS VENCIDAS ===============");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"TELÉFONO",-15} {"PRECIO",-8} {"VENCIMIENTO",-12} {"CUENTA",-65} {"PERFIL",-25} {"PLATAFORMA",-18} {"ESTADO",-12}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                if (string.IsNullOrWhiteSpace(matriz_datos[i, 2]))
                    continue;

                bool fechaValida = DateTime.TryParse(matriz_datos[i, 2], out DateTime fechaVencimiento);

                if (!fechaValida)
                    continue;
                
                int diasRestantes = (fechaVencimiento.Date - fechaActual).Days;

                if (diasRestantes < 0)
                {
                    Console.WriteLine($"{matriz_datos[i, 0],-15} {matriz_datos[i, 1],-8} {matriz_datos[i, 2],-12} {matriz_datos[i, 3],-55} {matriz_datos[i, 4],-30} {matriz_datos[i, 5],-18} {"VENCIDA",-12}");
                    hayVencidas = true;
                }
            }

            if (!hayVencidas)
            {
                Console.WriteLine("No hay cuentas vencidas.");
            }
            Console.WriteLine();

            // =========================
            // 2. CUENTAS QUE VENCEN HOY
            // =========================

            Console.WriteLine("=============== CUENTAS QUE VENCEN HOY ===============");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"TELÉFONO",-15} {"PRECIO",-8} {"VENCIMIENTO",-12} {"CUENTA",-65} {"PERFIL",-25} {"PLATAFORMA",-18} {"ESTADO",-12}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                if (string.IsNullOrWhiteSpace(matriz_datos[i, 2]))
                    continue;

                bool fechaValida = DateTime.TryParse(matriz_datos[i, 2], out DateTime fechaVencimiento);

                if (!fechaValida)
                    continue;

                int diasRestantes = (fechaVencimiento.Date - fechaActual).Days;

                if (diasRestantes == 0)
                {
                    Console.WriteLine($"{matriz_datos[i, 0],-15} {matriz_datos[i, 1],-8} {matriz_datos[i, 2],-12} {matriz_datos[i, 3],-55} {matriz_datos[i, 4],-30} {matriz_datos[i, 5],-18} {"VENCE HOY",-12}");
                    hayVenceHoy = true;
                }
            }

            if (!hayVenceHoy)
            {
                Console.WriteLine("No hay cuentas que vencen hoy.");
            }
            Console.WriteLine();

            // =========================
            // 3. CUENTAS POR VENCER
            // =========================

            Console.WriteLine("=============== CUENTAS POR VENCER (1 A 3 DÍAS) ===============");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"TELÉFONO",-15} {"PRECIO",-8} {"VENCIMIENTO",-12} {"CUENTA",-70} {"PERFIL",-25} {"PLATAFORMA",-18} {"ESTADO",-12}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                if (string.IsNullOrWhiteSpace(matriz_datos[i, 2]))
                    continue;
                
                bool fechaValida = DateTime.TryParse(matriz_datos[i, 2], out DateTime fechaVencimiento);

                if (!fechaValida)
                    continue;

                int diasRestantes = (fechaVencimiento.Date - fechaActual).Days;

                if (diasRestantes > 0 && diasRestantes <= 3)
                {
                    Console.WriteLine($"{matriz_datos[i, 0],-15} {matriz_datos[i, 1],-8} {matriz_datos[i, 2],-12} {matriz_datos[i, 3],-55} {matriz_datos[i, 4],-30} {matriz_datos[i, 5],-18} {diasRestantes,-12}");
                    hayPorVencer = true;
                }
            }

            if (!hayPorVencer)
            {
                Console.WriteLine("No hay cuentas por vencer en los próximos 3 días.");
            }

            Console.Write("\nPresione una tecla para continuar...");
        }
    }
}
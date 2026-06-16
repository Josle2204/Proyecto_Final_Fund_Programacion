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
                        mostrar_clientes();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        buscar_cliente();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        registrar_cuenta();
                        Console.ReadKey();
                        Console.Clear();
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
                        Console.Clear();
                        ganancia_total();
                        Console.Clear();
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
                string[,] matriz_datos = new string[lineas.Length, 6];


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
            Console.Clear();

            string[,] matriz_datos = cargar_archivo();

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"  TELÉFONO",-13} {"PRECIO",-8} {"VENCIMIENTO",-30} {"CUENTA",-30} {"PERFIL",-20} {"PLATAFORMA",-12}");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                Console.WriteLine($"{matriz_datos[i,0],-11} S/. {matriz_datos[i, 1],-8:C} {matriz_datos[i, 2],-12:dd/MM/yyyy} {matriz_datos[i, 3],-48} {matriz_datos[i, 4],-20} {matriz_datos[i, 5],-12}");
            }

            Console.Write("\nPresione una tecla para continuar...");
        }

        static void buscar_cliente()
        {
            string[,] matriz = cargar_archivo();

            Console.Write("Introduce el numero de telefono a buscar: ");
            string buscar = Console.ReadLine();
            bool encontro = false;

            Console.WriteLine("\nResultados de la busqueda:");
            Console.WriteLine("Telefono | Precio | Vencimiento | Cuenta | Perfil | Plataforma");
            Console.WriteLine("-----------------------------------------------------------------------");

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                // Cambiado a posicion 0 para buscar en la columna de telefonos
                if (matriz[i, 0] != null && matriz[i, 0].ToLower().Contains(buscar.ToLower()))
                {
                    Console.WriteLine(matriz[i, 0] + " | " + matriz[i, 1] + " | " + matriz[i, 2] + " | " + matriz[i, 3] + " | " + matriz[i, 4] + " | " + matriz[i, 5]);
                    encontro = true;
                }
            }

            if (encontro == false)
            {
                Console.WriteLine("\nNo se encontro ninguna cuenta con ese telefono.");
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
            Console.Clear();
        }

        static void registrar_cuenta()
        {
            string[,] matriz_datos = cargar_archivo();

            Console.WriteLine("=== Agregando cuenta ===\n");
            Console.Write("Ingrese teléfono: ");
            string telefono = Console.ReadLine()!;  //

            Console.Write("\nIngrese monto: S/ ");

            bool validar_monto;
            int opcion_monto;

            do
            {
                validar_monto = int.TryParse(Console.ReadLine(), out opcion_monto);

                if (opcion_monto < 1)
                {
                    Console.Write("Ingrese monto correcto (número): S/ ");
                    validar_monto = false;
                }

            } while (!validar_monto);

            string monto = opcion_monto.ToString(); //

            Console.WriteLine("\nIngrese respetando el formato (dd/MM/yyyy): ");
            Console.Write("Día: ");
            string dia = Console.ReadLine()!;
            Console.Write("Mes: ");
            string mes = Console.ReadLine()!;
            Console.Write("Año: ");
            string año = Console.ReadLine()!;
            string fecha = $"{dia}/{mes}/{año}";    //

            Console.WriteLine("\nIngrese la cuenta:");
            Console.Write("Correo/usuario: ");
            string correo_usuario = Console.ReadLine()!;
            Console.Write("Clave: ");
            string clave = Console.ReadLine()!;
            string cuenta = $"{correo_usuario} {clave}";    //

            Console.WriteLine("\nEscoja la plataforma:");
            Console.WriteLine("[1. IPTV]");
            Console.WriteLine("[2. Paramount]");
            Console.WriteLine("[3. HBO MAX]");
            Console.WriteLine("[4. Disney]");
            Console.WriteLine("[5. Crunchyroll]\n");

            Console.Write("Ingrese la opción: ");

            int opcion = 0;
            bool validar;
            string plataforma = ""; //

            do
            {
                validar = int.TryParse(Console.ReadLine(), out opcion);

                if (opcion < 1 || opcion > 5)
                {
                    Console.Write("\nIngrese una opción válida: ");
                    validar = false;
                }

            } while (!validar);

            switch (opcion)
            {
                case 1:
                    plataforma = "IPTV";
                    break;
                case 2:
                    plataforma = "Paramount";
                    break;
                case 3:
                    plataforma = "HBO MAX";
                    break;
                case 4:
                    plataforma = "Disney";
                    break;
                case 5:
                    plataforma = "Crunchyroll";
                    break;
            }

            string perfil = "";  //
            
            if (opcion != 1)
            {
                Console.Write("\nPerfil: ");
                string perfil_1 = Console.ReadLine()!;
                Console.Write("PIN (Dejar vació si no tiene): ");
                string perfil_2 = Console.ReadLine();

                if (perfil_2 != "")
                {
                    perfil = $"{perfil_1} {perfil_2}";
                }
                else
                {
                    perfil = perfil_1;
                }
            }

            else if (opcion == 1)
            {
                Console.Write("Ingrese 'FULL' o '1 DISPO' (Perfil en caso tenga): ");
                perfil = Console.ReadLine()!;
            }

            using (StreamWriter escritor = new StreamWriter("Streaming.csv", true))
            {
                escritor.Write($"\n{telefono};{monto};{fecha};{cuenta};{perfil};{plataforma};");
            }
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

        static void ganancia_total()
        {
            Console.Clear();
            string[,] matriz_datos = cargar_archivo();
            decimal total = 0;

            //este for recorreria todas las filas de la matriz
            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                //esto es para que vea si existe algun nulo en el csv y el && es por si en vez de vacio ponen ""
                if (matriz_datos[i, 1] != null && matriz_datos[i, 1] != "")
                {
                    //esto es para convertir todo el texto a numero para acto siguiente sumarlo
                    if (decimal.TryParse(matriz_datos[i, 1], out decimal PRECIO))
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
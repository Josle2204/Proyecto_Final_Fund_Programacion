using System.Text.RegularExpressions;

namespace Streaming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                opcion = menu();

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        mostrar_clientes();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        buscar_cliente();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        registrar_cuenta();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        eliminar_cuenta();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        alertas_vencimiento();
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
            Console.WriteLine("5) Alerta de vencimientos");
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
            Console.ReadKey(true);
        }

        static void buscar_cliente()
        {
            string[,] matriz = cargar_archivo();

            //leertexto nos valida con el formato hecho asi el numero que pongas aca no es incoherente
            string buscar = LeerTexto("Introduce el numero de telefono a buscar: ");
            bool encontro = false;

            Console.WriteLine("\nResultados de la busqueda:\n");
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

            Console.Write("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
            Console.Clear();
        }

        static void registrar_cuenta()
        {
            string[,] matriz_datos = cargar_archivo();

            Console.WriteLine("=== Agregando cuenta ===\n");
            string telefono = LeerTexto("Ingrese teléfono: "); 

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

            string monto = opcion_monto.ToString(); 

            Console.WriteLine("\nIngrese respetando el formato (dd/MM/yyyy): ");
            string fecha = LeerFecha();

            Console.WriteLine("\nIngrese la cuenta:");
            string correo_usuario = LeerTexto("Correo/usuario: ");
            string clave = LeerTexto("Clave: ");
            string cuenta = $"{correo_usuario} {clave}";    

            Console.WriteLine("\nEscoja la plataforma:");
            Console.WriteLine("[1. IPTV]");
            Console.WriteLine("[2. Paramount]");
            Console.WriteLine("[3. HBO MAX]");
            Console.WriteLine("[4. Disney]");
            Console.WriteLine("[5. Crunchyroll]\n");

            Console.Write("Ingrese la opción: ");

            int opcion = 0;
            bool validar;
            string plataforma = ""; 

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

            string perfil = "";
            
            if (opcion != 1)
            {
                string perfil_1 = LeerTexto("\nPerfil: ");
                Console.Write("PIN (Dejar vacío si no tiene): ");
                string perfil_2 = Console.ReadLine()?.Trim() ?? "";

                if (!string.IsNullOrEmpty(perfil_2))
                {
                    perfil = $"{perfil_1} {perfil_2}";
                }
                else
                {
                    perfil = perfil_1;
                }
            }
            else
            {
                Console.Write("Ingrese 'FULL' o '1 DISPO' (Perfil en caso tenga): ");
                perfil = Console.ReadLine()?.Trim() ?? "";
            }

            using (StreamWriter escritor = new StreamWriter("Streaming.csv", true))
            {
                escritor.Write($"\n{telefono};{monto};{fecha};{cuenta};{perfil};{plataforma};");
            }

            Console.WriteLine("\n Cuenta registrada con éxito.");

            Console.Write("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void eliminar_cuenta()
        {
            string[,] matriz_datos = cargar_archivo();

            List<string> lista_temporal = new List<string>();

            for (int i = 0; i < matriz_datos.GetLength(0); i++)
            {
                lista_temporal.Add($"{matriz_datos[i, 0]};{matriz_datos[i, 1]};{matriz_datos[i, 2]};{matriz_datos[i, 3]};{matriz_datos[i, 4]};{matriz_datos[i, 5]}");
            }

            Console.WriteLine("=== Eliminar Cuenta ===");

            string telefono;

            do
            {
                Console.Write("Ingrese un número telefónico: ");
                telefono = Console.ReadLine()!;

                if (!Regex.IsMatch(telefono, @"^\d{9}$"))
                {
                    Console.WriteLine("Número inválido. Debe tener 9 dígitos.\n");
                }

            } while (!Regex.IsMatch(telefono, @"^\d{9}$"));

            string identificador = "";

            for (int i = 0; i < lista_temporal.Count; i++)
            {
                string telefonoRegistro = lista_temporal[i].Split(';')[0];

                if (telefonoRegistro == telefono)
                {
                    if (identificador != "")
                    {
                        identificador = $"{identificador},{i}";
                    }
                    else
                    {
                        identificador = $"{i}";
                    }
                }
            }

            string[] identificador_separado;

            if (identificador != "")
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{"  TELÉFONO",-13} {"PRECIO",-8} {"VENCIMIENTO",-30} {"CUENTA",-30} {"PERFIL",-20} {"PLATAFORMA",-12}");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                identificador_separado =  identificador.Split(',');
                for (int i = 0; i < identificador_separado.Length; i++)
                {
                    int indice = int.Parse(identificador_separado[i]);

                    Console.WriteLine($"{i+1}) {matriz_datos[indice, 0],-11} S/. {matriz_datos[indice, 1],-8:C} {matriz_datos[indice, 2],-12:dd/MM/yyyy} {matriz_datos[indice, 3],-48} {matriz_datos[indice, 4],-20} {matriz_datos[indice, 5],-12}");
                }

                int opcion_borrar = LeerEntero(
                    "\nIngrese la cuenta a borrar (opción): ",
                    1,
                    identificador_separado.Length
                );

                int indiceReal = int.Parse(identificador_separado[opcion_borrar - 1]);

                lista_temporal.RemoveAt(indiceReal);

                using (StreamWriter escritor = new StreamWriter("Streaming.csv"))
                {
                    string nuevos_datos = "";

                    for (int i = 0; i < lista_temporal.Count; i++)
                    {
                        if (nuevos_datos == "")
                        {
                            nuevos_datos = $"{lista_temporal[i]}";
                        }
                        else
                        {
                            nuevos_datos = $"{nuevos_datos}\n{lista_temporal[i]}";
                        }
                    }

                    escritor.Write(nuevos_datos);
                }
            }
            else
            {
                Console.WriteLine("\nNo se encontró al cliente.");
            }

            Console.WriteLine("\n Cuenta eliminada correctamente.");

            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        static void alertas_vencimiento()
        {
            Console.Clear();

            string[,] matriz_datos = cargar_archivo();
            DateTime fechaActual = DateTime.Today;

            bool hayVencidas = false;
            bool hayVenceHoy = false;
            bool hayPorVencer = false;

            Console.WriteLine("\n======================================================================= ALERTAS DE VENCIMIENTO =================================================================\n");

            // =========================
            // 1. CUENTAS VENCIDAS
            // =========================

            Console.WriteLine("=============== CUENTAS VENCIDAS ===============");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"TELÉFONO",-15} {"PRECIO",-8} {"VENCIMIENTO",-12} {"CUENTA",-60} {"PERFIL",-20} {"PLATAFORMA",-18} {"ESTADO",-12}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------");

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
                    Console.WriteLine($"{matriz_datos[i, 0],-15} {matriz_datos[i, 1],-8} {matriz_datos[i, 2],-12} {matriz_datos[i, 3],-60} {matriz_datos[i, 4],-20} {matriz_datos[i, 5],-18} {"VENCIDA",-12}");
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
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"TELÉFONO",-15} {"PRECIO",-8} {"VENCIMIENTO",-12} {"CUENTA",-60} {"PERFIL",-20} {"PLATAFORMA",-18} {"ESTADO",-12}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------");

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
                    Console.WriteLine($"{matriz_datos[i, 0],-15} {matriz_datos[i, 1],-8} {matriz_datos[i, 2],-12} {matriz_datos[i, 3],-60} {matriz_datos[i, 4],-20} {matriz_datos[i, 5],-18} {"VENCE HOY",-12}");
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
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"TELÉFONO",-15} {"PRECIO",-8} {"VENCIMIENTO",-12} {"CUENTA",-60} {"PERFIL",-20} {"PLATAFORMA",-18} {"ESTADO",-12}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");

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
                    Console.WriteLine($"{matriz_datos[i, 0],-15} {matriz_datos[i, 1],-8} {matriz_datos[i, 2],-12} {matriz_datos[i, 3],-60} {matriz_datos[i, 4],-20} {matriz_datos[i, 5],-18} {diasRestantes,-12}");
                    hayPorVencer = true;
                }
            }

            if (!hayPorVencer)
            {
                Console.WriteLine("\nNo hay cuentas por vencer en los próximos 3 días.");
            }

            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey(true);
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
            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        // ================= VALIDACIONES =================
        static string LeerTexto(string mensaje)
        {
            string valor;

            do
            {
                Console.Write(mensaje);
                valor = Console.ReadLine()?? "";

                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine("no puede estar vacio. ");
                }

            }while(string.IsNullOrWhiteSpace(valor));

            return valor;
        }
        static int LeerEntero(string mensaje,int min,int max)
        {
            int valor;
            bool valido;

            do
            {
                Console.Write(mensaje);
                valido=int.TryParse(Console.ReadLine(), out valor);

                if(!valido || valor <min || valor > max)
                {
                    Console.WriteLine($"Ingrese un numero valido entre {min} y {max}");
                    valido = false;
                }
            } while(!valido);
            return valor;
        }

        static string LeerFecha()
        {
            int dia = LeerEntero("dia: ",1,31);
            int mes = LeerEntero("Mes: ", 1, 12);
            int año = LeerEntero("Año: ", 2000, 2100);

            return $"{dia}/{mes}/{año}";
        }

    }
}
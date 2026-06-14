namespace Streaming;
using System;
using System.Globalization;
using System.IO;

    internal class Program
    {
        static string[] clientes = new string[100];
        static string[] plataformas = new string[100];
        static string[] fechasVencimiento = new string[100];
        static int totalSuscripciones = 0;
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
                        VerAlertasVencimiento();
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
            int opcion = int.Parse(Console.ReadLine()!);

            return opcion;
        }

        static void guardar_cargar()
        {
            using (StreamWriter escritor = new StreamWriter("prueba.txt"))
            {
                escritor.WriteLine("HOLA PANCHITO CHUPA");
            }
        }

        //ALERTAS DE VENCIMIENTO DE SUSCRIPCIONES//

        static void VerAlertasVencimiento()
        {
            Console.WriteLine();
            Console.WriteLine("===== ALERTAS DE VENCIMIENTO =====");

            if (totalSuscripciones == 0)
            {
                Console.WriteLine("No hay suscripciones registradas.");
                return;
            }

            DateTime fechaActual = DateTime.Today;
            bool hayAlertas = false;

            string[] formatosFecha = { "dd/MM/yyyy", "d/M/yyyy" };

            for (int i = 0; i < totalSuscripciones; i++)
            {
                bool fechaValida = DateTime.TryParseExact(
                    fechasVencimiento[i],
                    formatosFecha,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime fechaVencimiento
                );

                if (!fechaValida)
                {
                    Console.WriteLine("Registro con fecha inválida.");
                    Console.WriteLine("Cliente: " + clientes[i]);
                    Console.WriteLine("Fecha registrada: " + fechasVencimiento[i]);
                    Console.WriteLine("-----------------------------------");
                    hayAlertas = true;
                    continue;
                }

                int diasRestantes = (fechaVencimiento.Date - fechaActual).Days;

                if (diasRestantes < 0)
                {
                    Console.WriteLine("SUSCRIPCIÓN VENCIDA");
                    Console.WriteLine("Cliente: " + clientes[i]);
                    Console.WriteLine("Plataforma: " + plataformas[i]);
                    Console.WriteLine("Fecha de vencimiento: " + fechasVencimiento[i]);
                    Console.WriteLine("Días vencidos: " + Math.Abs(diasRestantes));
                    Console.WriteLine("-----------------------------------");
                    hayAlertas = true;
                }
                else if (diasRestantes == 0)
                {
                    Console.WriteLine("ALERTA: LA SUSCRIPCIÓN VENCE HOY");
                    Console.WriteLine("Cliente: " + clientes[i]);
                    Console.WriteLine("Plataforma: " + plataformas[i]);
                    Console.WriteLine("Fecha de vencimiento: " + fechasVencimiento[i]);
                    Console.WriteLine("-----------------------------------");
                    hayAlertas = true;
                }
                else if (diasRestantes <= 3)
                {
                    Console.WriteLine("ALERTA URGENTE: LA SUSCRIPCIÓN VENCE PRONTO");
                    Console.WriteLine("Cliente: " + clientes[i]);
                    Console.WriteLine("Plataforma: " + plataformas[i]);
                    Console.WriteLine("Fecha de vencimiento: " + fechasVencimiento[i]);
                    Console.WriteLine("Días restantes: " + diasRestantes);
                    Console.WriteLine("-----------------------------------");
                    hayAlertas = true;
                }
                else if (diasRestantes <= 7)
                {
                    Console.WriteLine("ALERTA PREVENTIVA: LA SUSCRIPCIÓN VENCE ESTA SEMANA");
                    Console.WriteLine("Cliente: " + clientes[i]);
                    Console.WriteLine("Plataforma: " + plataformas[i]);
                    Console.WriteLine("Fecha de vencimiento: " + fechasVencimiento[i]);
                    Console.WriteLine("Días restantes: " + diasRestantes);
                    Console.WriteLine("-----------------------------------");
                    hayAlertas = true;
                }
            }

            if (!hayAlertas)
            {
                Console.WriteLine("No hay suscripciones vencidas ni próximas a vencer en los próximos 7 días.");
            }
        }
}


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
                        Buscar_suscripcion();
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

        static void Buscar_suscripcion()
        {
                    
        
            Console.Clear();
            Console.WriteLine("=== BUSCAR SUSCRIPCION ===");
            Console.Write("Ingrese el nombre de la plataforma a buscar (ejem: crunchyroll): ");
            
            // por lo que tengo ententido el ! se usa para asegurar al programa que no sera un valor nulo 
            string busqueda = Console.ReadLine()!;
            
            Console.WriteLine($"Buscando '{busqueda}' en el sistema...");
            
            // Espacio listo para conectar la base de datos o el archivo de texto en tu examen
            Console.WriteLine("Funcion conectada con exito. Presione cualquier tecla para volver al menu.");
            Console.ReadKey();
            Console.Clear();
        

        }
    }
}
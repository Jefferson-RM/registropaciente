using System;

class Program
{
    static void Main(string[] args)
    {
        PacienteRepositorio repositorio = new PacienteRepositorio();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n===== SISTEMA DE REGISTRO DE PACIENTES =====");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Buscar paciente");
            Console.WriteLine("3. Actualizar paciente");
            Console.WriteLine("4. Eliminar paciente");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Paciente nuevo = new Paciente();
                    Console.Write("Ingrese nombre: ");
                    nuevo.Nombre = Console.ReadLine() ?? "";
                    Console.Write("Ingrese edad: ");
                    if (int.TryParse(Console.ReadLine(), out int edad)) nuevo.Edad = edad;
                    Console.Write("Ingrese diagnóstico: ");
                    nuevo.Diagnostico = Console.ReadLine() ?? "";

                    repositorio.Registrar(nuevo);
                    break;

                case "2":
                    int idBusqueda = PedirNumero("Ingrese el ID del paciente: ");
                    var paciente = repositorio.BuscarPorId(idBusqueda);

                    if (paciente != null)
                    {
                        Console.WriteLine($"[Encontrado] ID: {paciente.Id} | Nombre: {paciente.Nombre} | Edad: {paciente.Edad} | Diagnóstico: {paciente.Diagnostico}");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el paciente.");
                    }
                    break;

                case "3":
                    int idAct = PedirNumero("Ingrese el ID del paciente a actualizar: ");
                    Console.Write("Ingrese el nuevo diagnóstico: ");
                    string nuevoDiag = Console.ReadLine() ?? "";
                    repositorio.Actualizar(idAct, nuevoDiag);
                    break;

                case "4":
                    int idDel = PedirNumero("Ingrese el ID del paciente a eliminar: ");
                    repositorio.Eliminar(idDel);
                    break;

                case "5":
                    salir = true;
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        }
    }

    // Método auxiliar reutilizable para pedir números de forma segura
    static int PedirNumero(string mensaje)
    {
        int numero;
        Console.Write(mensaje);
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Valor inválido. Por favor, ingrese un número entero: ");
        }
        return numero;
    }
}
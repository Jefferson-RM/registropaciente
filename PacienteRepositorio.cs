using System;
using Microsoft.Data.SqlClient;

public class PacienteRepositorio
{
    // Reemplaza esta cadena con tu cadena de conexión real a SQL Server
    private readonly string connectionString = "Server=TU_SERVIDOR;Database=tu_base_de_datos;Trusted_Connection=True;TrustServerCertificate=True;";

    public void Registrar(Paciente paciente)
    {
        using SqlConnection conexion = new SqlConnection(connectionString);
        conexion.Open();
        string query = "INSERT INTO Pacientes (Nombre, Edad, Diagnostico) VALUES (@Nombre, @Edad, @Diagnostico)";
        using SqlCommand comando = new SqlCommand(query, conexion);
        
        comando.Parameters.AddWithValue("@Nombre", paciente.Nombre);
        comando.Parameters.AddWithValue("@Edad", paciente.Edad);
        comando.Parameters.AddWithValue("@Diagnostico", paciente.Diagnostico);
        
        comando.ExecuteNonQuery();
        Console.WriteLine("Paciente registrado exitosamente.");
    }

    public Paciente? BuscarPorId(int id)
    {
        using SqlConnection conexion = new SqlConnection(connectionString);
        conexion.Open();
        string query = "SELECT Id, Nombre, Edad, Diagnostico FROM Pacientes WHERE Id = @Id";
        using SqlCommand comando = new SqlCommand(query, conexion);
        comando.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = comando.ExecuteReader();
        if (reader.Read())
        {
            return new Paciente
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Edad = reader.GetInt32(2),
                Diagnostico = reader.GetString(3)
            };
        }
        return null;
    }

    public void Actualizar(int id, string nuevoDiagnostico)
    {
        using SqlConnection conexion = new SqlConnection(connectionString);
        conexion.Open();
        string query = "UPDATE Pacientes SET Diagnostico = @Diagnostico WHERE Id = @Id";
        using SqlCommand comando = new SqlCommand(query, conexion);
        comando.Parameters.AddWithValue("@Diagnostico", nuevoDiagnostico);
        comando.Parameters.AddWithValue("@Id", id);

        int filasAfectadas = comando.ExecuteNonQuery();
        if (filasAfectadas > 0)
            Console.WriteLine("Paciente actualizado correctamente.");
        else
            Console.WriteLine("No se encontró el paciente para actualizar.");
    }

    public void Eliminar(int id)
    {
        using SqlConnection conexion = new SqlConnection(connectionString);
        conexion.Open();
        string query = "DELETE FROM Pacientes WHERE Id = @Id";
        using SqlCommand comando = new SqlCommand(query, conexion);
        comando.Parameters.AddWithValue("@Id", id);

        int filasAfectadas = comando.ExecuteNonQuery();
        if (filasAfectadas > 0)
            Console.WriteLine("Paciente eliminado correctamente.");
        else
            Console.WriteLine("No se encontró el paciente a eliminar.");
    }
}
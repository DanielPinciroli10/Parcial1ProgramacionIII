using Microsoft.AspNetCore.Http.Metadata;
using System.Data.SqlClient;

namespace Parcial1DanielPinciroli.Datos
{
    public class ParticipantesDatos
    {
        string ConexionString = @"Data Source = DESKTOP-NSUH7KO\SQLEXPRESS02;Initial Catalog = TORNEO; Integrated Security = True";
        public List<Participantes> ListarParticipantes()
        {
            List<Participantes> listaParticipantes = new List<Participantes>();
            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                string query = $"SELECT P.IDParticipantes, P.Nombre, P.Disciplina, P.Edad, P.CiudadResidencia, D.IDDisciplina, D.Nombre AS NombreDisciplina FROM Participante P INNER JOIN Disciplinas D ON D.IDDisciplina = P.IDDisciplina ORDER BY P.Nombre";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaParticipantes.Add(new Participantes()
                    {
                        IDParticipante = (int)reader["IDParticipantes"],
                        Nombre = reader["Nombre"].ToString(),
                        IDDisciplina = (int)reader["Disciplina"],
                        Edad = (int)reader["Edad"],
                        CiudadResidencia = reader["CiudadResidencia"].ToString(),
                        disciplinas = new Disciplinas()
                        {
                            IDDisciplina = (int)reader["IDDisciplina"],
                            Nombre = reader["Nombre"].ToString(),
                        }
                    });
                }
                return listaParticipantes;
            }
        }
        public string CrearParticipante(Participantes participantes)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConexionString))
                {
                    string query = $"INSERT INTO Participante (Nombre, Disciplina, Edad, CiudadResidencia) VALUES ('{participantes.Nombre}', {participantes.IDDisciplina}, {participantes.Edad}, '{participantes.CiudadResidencia}'";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<Disciplinas> ListarDisciplinas()
        {
            List<Disciplinas> listaDisciplinas = new List<Disciplinas>();
            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                string query = $"SELECT * FROM Disciplinas ORDER BY Nombre";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
               
                while (reader.Read())
                {
                    listaDisciplinas.Add(new Disciplinas()
                    {
                        IDDisciplina = (int)reader["IDDisciplina"],
                        Nombre = reader["Nombre"].ToString(),

                    });
                }
                return listaDisciplinas;
            }
        }
    }
}

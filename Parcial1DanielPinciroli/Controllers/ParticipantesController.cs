using Microsoft.AspNetCore.Mvc;
using Parcial1DanielPinciroli.Datos;
using System.Data.SqlClient;

namespace Parcial1DanielPinciroli.Controllers
{
    public class ParticipantesController : Controller
    {
        ParticipantesDatos _BD = new ParticipantesDatos();
        public IActionResult Index()
        {
            return View(_BD.ListarParticipantes());
        }
        public IActionResult Create()
        {
            ViewBag.Disciplinas = _BD.ListarDisciplinas();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Participantes participantes)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Disciplinas = _BD.ListarDisciplinas();
                    return View(participantes);
                }
                ViewBag.Error = _BD.CrearParticipante(participantes);
                if (ViewBag.Error != "")
                {
                    ViewBag.Disciplinas =_BD.ListarDisciplinas();
                    return View(participantes);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ViewBag.Disciplinas = _BD.ListarDisciplinas();
                return View(participantes);
            }
        }
        public IActionResult CantidadRegistrados ()
        {
            string ConexionString = @"Data Source = DESKTOP-NSUH7KO\SQLEXPRESS02;Initial Catalog = TORNEO; Integrated Security = True";
            List<CantidadRegistrados> listaRegistrados = new List<CantidadRegistrados>();
            using (SqlConnection con = new SqlConnection(ConexionString))
            {
                string query = $"SELECT D.IDDisciplina, D.Nombre, COUNT (IDParticipantes) AS CantidadRegistrados FROM Participante P INNER JOIN Disciplinas D ON D.IDDisciplina = P.IDDisciplina GROUP BY D.IDDisciplina, D.Nombre ORDER BY D.Nombre";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listaRegistrados.Add(new CantidadRegistrados()
                    {
                        IDRegistrados = (int)reader["IDDisciplina"],
                        NombreDisciplina = reader["Nombre"].ToString(),
                        Cantidad = (int)reader["CantidadRegistrados"]
                        
                    });
                }
                return View(listaRegistrados);
            }
        }
    }
}

            

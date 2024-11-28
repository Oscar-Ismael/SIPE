using Microsoft.AspNetCore.Mvc;
using SIPE.Models;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;

namespace SIPE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SQLHelper _sqlHelper;

        public HomeController(ILogger<HomeController> logger, SQLHelper sqlHelper)
        {
            _logger = logger;
            _sqlHelper = sqlHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetEmpleados()
        {
            var empleados = new List<Empleado>();

            // Llama al stored procedure 
            var dt = _sqlHelper.ExecuteStoredProcedure("spSELECT_Prueba");

            // Mapea el DataTable a una lista de empleados
            foreach (DataRow row in dt.Rows)
            {
                empleados.Add(new Empleado
                {
                    NumeroEmpleado = Convert.ToInt32(row["numero_empleado"]),
                    Nombre = row["nombre"].ToString(),
                    Correo = row["correo"].ToString()
                });
            }


            // prueba de git
            // prueba de git
            // prueba de git


            // Retorna la lista de empleados como JSON
            return Json(empleados);
        }
    }
}

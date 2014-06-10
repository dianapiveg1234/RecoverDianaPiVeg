using EmployeeQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeQuiz.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(Employe emp)
        {

            //Creo el objeto del modelo de datos
            Payrolldm nomina = new Payrolldm(
                @"E:\Recover\EmployeeQuiz\Models\EmployeeDb.csv");
   
            //busco el empleado dado su id
            
            var empleado=nomina.GetEmployeById(emp.Id);

            //para que solo entren los numeros de control registrados
            double comprobacion = double.Parse(emp.Id);


            
            if (comprobacion <= 91130079 && comprobacion >=91130075)
            {
                return View("WorkerView", empleado);
            }

                //en caso contrario te renderea a otra vista
            else { return View("otra"); }
        }




    }
}

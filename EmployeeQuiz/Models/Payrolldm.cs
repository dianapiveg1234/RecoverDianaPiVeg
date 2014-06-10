using System;
using System.Collections.Generic;
//Espacio de nombre para espacio de nombres
using System.IO;
using System.Linq;
using System.Web;


namespace EmployeeQuiz.Models
{
    public class Payrolldm
    {
        //lista de empleados
        List<Employe> empList;


        //Constructor del modelo 
        public Payrolldm(string dbPath)
        {

            //creando el objeto de la lista empleados
            empList = new List<Employe>();



            //Leer el Archivo             
            var reader = new StreamReader(File.OpenRead(dbPath));

            //Parsear
            while (!reader.EndOfStream)
            { 
                //Leo una linea
                var line = reader.ReadLine();

                //Pasear
                //Separar los valores
                //Guardar un objeto

                var valores = line.Split(',');
                
                empList.Add(new Employe
                    {
                        Id = valores[0],
                        FirstLastname = valores[1],
                        SecondLastname = valores[2],
                        Name = valores[3],
                        Position = valores[4],
                        Wage = valores[5],
                        Sex = valores[6],
                        PhothoPath = valores[7]
                    });
                }
        }


        //accesor
        public Employe GetEmployeById(string id)
        {
            var emp = empList.Find(e => e.Id == id);
                return emp;
        }
    }
}
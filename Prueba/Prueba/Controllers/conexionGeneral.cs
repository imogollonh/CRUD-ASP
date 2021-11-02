using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.Controllers
{
    public class conexionGeneral
    {
        public string conexion()
        {
            string con = "datasource=127.0.0.1;port=3306;username=root;password=root;database=mydb;";
            return con;
        }
    }
}
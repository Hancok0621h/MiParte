using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiParte
{
    internal class CDconexion
    {
        public SqlConnection db_conexion = new SqlConnection("Data Source=DESKTOP-ITBVOOJ\\SQLEXPRESS;Initial Catalog=DB_HoTel;Integrated Security=True;Encrypt=False");

        public SqlConnection MtdAbrirConexion()
        {
            if (db_conexion.State == ConnectionState.Closed)
            {
                db_conexion.Open();
            }
            return db_conexion;
        }

        public SqlConnection MtdCerrarConexion()
        {
            if (db_conexion.State == ConnectionState.Open)
            {
                db_conexion.Close();
            }
            return db_conexion;
        }
    }
}

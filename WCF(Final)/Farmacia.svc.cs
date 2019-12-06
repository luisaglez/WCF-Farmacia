using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCF_Final_
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Farmacia" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Farmacia.svc o Farmacia.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Farmacia : IFarmacia
    {
        public void guardar(int a, string b, string c, int d, string e, float f)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection("Data Source=localhost;Initial Catalog=Farmacia;Integrated Security=true");
            con.Open();
            cadena = "insert into  Medicamentos values('" + a + "','" + b + "','" + c + "','" + d + "','" + e + "','" + f + "')";
            cmd = new SqlCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool borrar(int a)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection("Data Source=localhost;Initial Catalog=Farmacia;Integrated Security=true");
            con.Open();
            cadena = "delete from Medicamentos where Folio=" + a;
            cmd = new SqlCommand(cadena, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }
        public string[] buscar(int fol)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dato;
            string cadena = "";
            string[] datos = new string[6];
            con = new SqlConnection("Data Source=localhost;Initial Catalog=Farmacia;Integrated Security=true");
            con.Open();
            cadena = "select * from Medicamentos where Folio=" + fol;
            cmd = new SqlCommand(cadena, con);
            dato = cmd.ExecuteReader();
            if (dato.Read())
            {
                datos[0] = dato.GetInt64(0).ToString();
                datos[1] = dato.GetString(1);
                datos[2] = dato.GetString(2);
                datos[3] = dato.GetInt32(3).ToString();
                datos[4] = dato.GetString(4);
                datos[5] = dato.GetDecimal(5).ToString();
            }
            con.Close();
            return datos;
        }
        public bool editar(int a, string b, string c, int d, string e, float f)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection("Data Source=localhost;Initial Catalog=Farmacia;Integrated Security=true");
            con.Open();
            cadena = "UPDATE Medicamentos SET Folio = ('" + a + "'), Nombre= ('" + b + "'),Contenido= ('" + c + "') , Unidades= ('" + d + "') , Categoria= ('" + e + "'), Precio= ('" + f + "') where Folio = ('" + a + "') ";
            cmd = new SqlCommand(cadena, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }

    }
}

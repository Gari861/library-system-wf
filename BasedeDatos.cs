using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoJueves
{
    internal class BasedeDatos
    {
        static SqlConnection conn = new SqlConnection();
        static private bool Conectar()
        {
            try
            {
                conn.ConnectionString = @"Data Source=PCDEESCRITORIOM;Initial Catalog=Biblioteca;Integrated Security=True";
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        static private void Desconectar()
        {
            conn.Close();
        }
        static public DataTable Buscar(string CadenaSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                Conectar();
                SqlDataAdapter da = new SqlDataAdapter(CadenaSQL, conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }
        static public bool EjecutarConsulta(string CadenaSQL)
        {
            bool Correcto;
            try
            {
                Conectar();
                SqlDataAdapter da = new SqlDataAdapter(CadenaSQL, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Correcto = true;
            }
            catch
            {
                Correcto = false;
            }
            finally
            {
                Desconectar();
            }
            return Correcto;
        }
    }
}

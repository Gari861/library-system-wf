using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoJueves
{
    internal class Libros
    {
        private int id;
        private string titulo;
        private string autor;
        private string editorial;
        private string genero;
        private string ubicacion;
        private int copias;

        public int Id { get { return id; } set { id = value; } }
        public string Titulo { get { return titulo; } set { titulo = value; } }
        public string Autor { get { return autor; } set { autor = value; } }
        public string Editorial { get { return editorial; } set { editorial = value; } }
        public string Genero { get { return genero; } set { genero = value; } }
        public string Ubicacion { get { return ubicacion; } set { ubicacion = value; } }
        public int Copias { get { return copias; } set { copias = value; } }
        public Libros() { }
        public Libros(string ptitulo, string pautor, string peditorial, string pgenero, string pubicacion, int pcopias)
        {
            Titulo = ptitulo;
            Autor = pautor;
            Editorial = peditorial;
            Genero = pgenero;
            Ubicacion = pubicacion;
            Copias = pcopias;
        }
        public bool Nuevo()
        {
            bool Correcto;
            string Consulta = "INSERT INTO Libros (Titulo, Autor, Editorial, Genero, Ubicacion, Copias) VALUES('" + Titulo + "', '" + Autor + "', '" + Editorial + "', '" + Genero + "', '" + Ubicacion + "', " + Copias + ")";
            Correcto = BasedeDatos.EjecutarConsulta(Consulta);
            return Correcto;
        }
        public bool Modificar()
        {
            bool Correcto;
            string Consulta = $"UPDATE Libros SET Titulo= '{Titulo}', Autor= '{Autor}', Editorial= '{Editorial}', Genero= '{Genero}', Ubicacion= '{Ubicacion}', Copias= {Copias} WHERE Id= {Id}";
            Correcto = BasedeDatos.EjecutarConsulta(Consulta);
            return Correcto;
        }

        static public bool Eliminar(int Idseleccionado)
        {
            bool Correcto;
            string Consulta = $"DELETE FROM Libros WHERE Id= {Idseleccionado}";
            Correcto = BasedeDatos.EjecutarConsulta(Consulta);
            return Correcto;
        }

        static public DataTable BuscarTodo()
        {
            DataTable dt = new DataTable();
            string Consulta = "SELECT * FROM dbo.Libros";
            dt = BasedeDatos.Buscar(Consulta);
            return dt;
        }
        static public DataTable BuscarPorId(int IdBuscado)
        {
            DataTable dt = new DataTable();
            string Consulta = $"SELECT * FROM Libros WHERE id = {IdBuscado}";
            dt = BasedeDatos.Buscar(Consulta);
            return dt;
        }
    }
}

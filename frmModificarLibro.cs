using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoJueves
{
    public partial class frmModificarLibro : Form
    {
        Libros libros = new Libros();
        public frmModificarLibro(int idLibro)
        {
            InitializeComponent();
            if (idLibro > 0)
            {
                DataTable dt = Libros.BuscarPorId(idLibro);
                if (dt.Rows.Count > 0)
                {
                    libros.Id = dt.Rows[0].Field<int>("Id"); // Asignar el ID al objeto libros
                    libros.Titulo = dt.Rows[0].Field<string>("Titulo");
                    libros.Autor = dt.Rows[0].Field<string>("Autor");
                    libros.Editorial = dt.Rows[0].Field<string>("Editorial");
                    libros.Genero = dt.Rows[0].Field<string>("Genero");
                    libros.Ubicacion = dt.Rows[0].Field<string>("Ubicacion");
                    libros.Copias = dt.Rows[0].Field<int>("Copias");

                    txtTitulo.Text = libros.Titulo;
                    txtAutor.Text = libros.Autor;
                    txtEditorial.Text = libros.Editorial;
                    txtGenero.Text = libros.Genero;
                    txtUbicacion.Text = libros.Ubicacion;
                    txtCopias.Text = libros.Copias.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró libro con el id buscado");
                }
            }
            else
            {
                MessageBox.Show("El código ingresado no es válido");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text.Trim().Length > 0 &&
                    txtAutor.Text.Length > 0 &&
                    txtEditorial.Text.Length > 0 &&
                    txtGenero.Text.Length > 0 &&
                    txtUbicacion.Text.Length > 0)
            {
                int copias;
                if (int.TryParse(txtCopias.Text, out copias))
                {
                    libros.Titulo = txtTitulo.Text.Trim();
                    libros.Autor = txtAutor.Text.Trim();
                    libros.Genero = txtGenero.Text.Trim();
                    libros.Editorial = txtEditorial.Text.Trim();
                    libros.Ubicacion = txtUbicacion.Text.Trim();
                    libros.Copias = copias;

                    try
                    {
                        if (libros.Modificar())
                        {
                            MessageBox.Show("Guardado correctamente");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un número entero de copias");
                }
            }
            else
            {
                MessageBox.Show("Tiene que agregar los datos faltantes");
            }
        }

        private void frmModificarLibro_Load(object sender, EventArgs e)
        {

        }
    }
}

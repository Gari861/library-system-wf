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
    public partial class frmNuevoLibro : Form
    {
        public frmNuevoLibro()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text.Trim().Length > 0 && txtAutor.Text.Length > 0 && txtEditorial.Text.Length > 0 && txtGenero.Text.Length > 0 && txtUbicacion.Text.Length > 0)
            {
                int copias;
                if (int.TryParse(txtCopias.Text, out copias))
                {
                    Libros libros = new Libros(txtTitulo.Text.Trim(), txtAutor.Text.Trim(), txtEditorial.Text.Trim(), txtGenero.Text.Trim(), txtUbicacion.Text.Trim(), copias);
                    if (libros.Nuevo())
                    {
                        MessageBox.Show("Guardado correctamente");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Dio error al guardar");
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
    }
}

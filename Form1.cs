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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoLibro frmNuevo = new frmNuevoLibro();
            frmNuevo.Show();
            DataTable dt = new DataTable();
            dt = Libros.BuscarTodo();
            if (dt.Rows.Count > 0)
            {
                LlenarGrilla(dt);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Libros.BuscarTodo();
            if (dt.Rows.Count > 0)
            {
                LlenarGrilla(dt);
            }
            else
            {
                MessageBox.Show("No se encontraron datos o la tabla está vacía");
            }
        }
        private void LlenarGrilla(DataTable dt)
        {
            dgvLibros.DataSource = null;
            dgvLibros.DataSource = dt;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.Rows.Count > 0)
            {
                if (dgvLibros.SelectedRows.Count > 0)
                {
                    int idSeleccionado;
                    idSeleccionado = Convert.ToInt32(dgvLibros.CurrentRow.Cells[0].Value);
                    DialogResult Borra = MessageBox.Show("Está seguro que desea eliminarlo", "Advertencia", MessageBoxButtons.YesNo);
                    if (Borra == DialogResult.Yes)
                    {
                        Libros.Eliminar(idSeleccionado);
                        DataTable dt = new DataTable();
                        dt = Libros.BuscarTodo();
                        if (dt.Rows.Count > 0)
                        {
                            LlenarGrilla(dt);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elemento");
                }
            }
            else
            {
                MessageBox.Show("La grilla está vacía");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.Rows.Count > 0)
            {
                if (dgvLibros.SelectedRows.Count > 0)
                {
                    int idSeleccionado;
                    idSeleccionado = Convert.ToInt32(dgvLibros.CurrentRow.Cells[0].Value);
                    frmModificarLibro frmModificarlibro = new frmModificarLibro(idSeleccionado);
                    frmModificarlibro.Show();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elemento");
                }
            }
            else
            {
                MessageBox.Show("La grilla está vacía");
            }
            DataTable dt = new DataTable();
            dt = Libros.BuscarTodo();
            if (dt.Rows.Count > 0)
            {
                LlenarGrilla(dt);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

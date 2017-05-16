using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_rutas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Ruta gestionRuta = new Ruta();

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int minutos = Convert.ToInt32(txtMinutos.Text);
            gestionRuta.agregar(nombre,minutos);

            txtMinutos.Text = "";
            txtNombre.Text = "";
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            txtReporte.Text = gestionRuta.buscar(nombre);

            txtNombre.Text = "";
        }

        private void cmdReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = gestionRuta.reporte();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            gestionRuta.eliminar(nombre);

            txtNombre.Text = "";
        }

        private void cmdAgregarIn_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int minutos = Convert.ToInt32(txtMinutos.Text);
            gestionRuta.agregarInicio(nombre, minutos);

            txtMinutos.Text = "";
            txtNombre.Text = "";
        }

        private void cmdAgregarUltimo_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int minutos = Convert.ToInt32(txtMinutos.Text);
            gestionRuta.agregarUltimo(nombre, minutos);

            txtMinutos.Text = "";
            txtNombre.Text = "";
        }

        private void cmdEliminarUltimo_Click(object sender, EventArgs e)
        {
            gestionRuta.eliminarUltimo();
        }

        private void cmdEliminarIn_Click(object sender, EventArgs e)
        {
            gestionRuta.eliminarInicio();
        }

        private void cmdInsDespuesDe_Click(object sender, EventArgs e)
        {
            string nombreB = txtNombre.Text;
            int minutos = Convert.ToInt32(txtMinutos.Text);
            string nombre = txtNombreDeBase.Text;
            gestionRuta.insertarDespuesDe(nombre, nombreB, minutos);

            txtMinutos.Text = "";
            txtNombre.Text = "";
            txtNombreDeBase.Text = "";
        }

        private void cmdRecorrido_Click(object sender, EventArgs e)
        {
            int hi = Convert.ToInt32(txtHI.Text);
            int mi = Convert.ToInt32(txtMI.Text);
            int hf = Convert.ToInt32(txtHF.Text);
            int mf = Convert.ToInt32(txtMF.Text);
            string nombre = txtNombre.Text;

            txtReporte.Text = gestionRuta.recorrido(nombre, hi, mi, hf, mf);

            txtHF.Text = "";
            txtHI.Text = "";
            txtMF.Text = "";
            txtMI.Text = "";
            txtNombre.Text = "";
        }
    }
}

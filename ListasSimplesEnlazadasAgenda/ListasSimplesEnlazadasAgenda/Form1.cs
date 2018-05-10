using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListasSimplesEnlazadasAgenda
{
    public partial class Form1 : Form
    {
        Contactos contactos = new Contactos();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregarEnInicio_Click(object sender, EventArgs e)
        {
            if (vacio())
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                int vCodigo = Convert.ToInt16(txtCodigo.Text);
                string vNombre = txtNombre.Text;
                string vTelefono = txtTelefono.Text;
                string vCorreo = txtCorreo.Text;
                string vFecha = txtFecha.Text;

                contactos.agregarEnInicio(new Persona(vCodigo, vNombre, vTelefono, vCorreo, vFecha));
                limpiarTXT();
            }
        }
        public bool vacio()
        {
            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "" || txtCorreo.Text == "" || txtFecha.Text == "")
                return true;
            else
                return false;
        }
        public void limpiarTXT()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtFecha.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (vacio())
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                int vCodigo = Convert.ToInt16(txtCodigo.Text);
                string vNombre = txtNombre.Text;
                string vTelefono = txtTelefono.Text;
                string vCorreo = txtCorreo.Text;
                string vFecha = txtFecha.Text;

                contactos.agregar(new Persona(vCodigo, vNombre, vTelefono, vCorreo, vFecha));
                limpiarTXT();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (vacio())
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                int vCodigo = Convert.ToInt16(txtCodigo.Text);
                string vNombre = txtNombre.Text;
                string vTelefono = txtTelefono.Text;
                string vCorreo = txtCorreo.Text;
                string vFecha = txtFecha.Text;

                contactos.insertar(new Persona(vCodigo, vNombre, vTelefono, vCorreo, vFecha), Convert.ToInt16(txtPosicion.Text));
                limpiarTXT();
                txtPosicion.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del contacto a eliminar.");
            else
            {
                if (contactos.eliminar(Convert.ToInt16(txtCodigo.Text)))
                {
                    MessageBox.Show("Contacto eliminado");
                    txtShow.Text = contactos.mostrar();
                }
                else
                    MessageBox.Show("El contacto no existe");
            }
            limpiarTXT();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del contacto a buscar.");
            else
                txtShow.Text = contactos.buscar(Convert.ToInt16(txtCodigo.Text)).ToString();
            limpiarTXT();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            txtShow.Text = contactos.mostrar();
        }

        private void btnEliminarPrimero_Click(object sender, EventArgs e)
        {
            if (contactos.eliminarPrimero())
            {
                MessageBox.Show("Contacto Eliminado!");
                txtShow.Text = contactos.mostrar();
            }
            else
                MessageBox.Show("Agenda vacia!!");
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            if (contactos.eliminarUltimo())
            {
                MessageBox.Show("Contacto Eliminado!");
                txtShow.Text = contactos.mostrar();
            }
            else
                MessageBox.Show("Agenda vacia!!");
        }

        private void btnListarInverso_Click(object sender, EventArgs e)
        {
            txtShow.Text = contactos.inverso();
        }
    }
}

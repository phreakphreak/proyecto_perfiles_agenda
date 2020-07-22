﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaNegocio.src;


namespace CapaPresentacion.FormsAgregar
{
    public partial class FrmCarreraInterna : Form
    {
        //BORDE SOMBREADO FORMULAR
        private const int CS_DROPSHADOW = 0x20000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }
        #region Constructor

        public FrmCarreraInterna()
        {
            InitializeComponent();
            InitialForms();
        }
        #endregion

        #region Instancias
        Helpers helper = new Helpers();

        NegocioLicenciados obj = new NegocioLicenciados();

        #endregion

        #region Atributos


        int posY = 0;
        int posX = 0;

        #endregion

        #region Buttons y Controls
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNuevaCarreraLicenciado_Click(object sender, EventArgs e)
        {
            try
            {
                Insert();
                txtNombreCarreraLic.Clear();
                this.DialogResult = DialogResult.OK;

            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void pnlBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }


        #endregion

        #region Metodos
        public void InitialForms()
        {


            //cmbTipo.Items.Clear();
           // ShowCarrerasLicenciado();
            mostrarFacultades();
           // cmbTipo.SelectedItem = null;
           // cmbTipo.Items.Insert(0, "externo");
           // cmbTipo.Items.Insert(1, "interno");
            //cmbTipo.SelectedIndex = 0;


            //ShowLicenciados();
        }
        public void Insert()
        {
            string nombre = txtNombreCarreraLic.Text;
            Object[] datos = new Object[] { nombre };
            helper.ControlInput(datos);
            helper.MainInsertCarreraLicenciado();


        }

        public void mostrarFacultades()
        {
            cmbFacultad.DataSource = null;
            cmbFacultad.Items.Clear();
            cmbFacultad.DataSource = obj.cargarInstitucio();
            cmbFacultad.ValueMember = "id";
            cmbFacultad.DisplayMember = "nombre";

        }
        #endregion

        private void FrmCarrera_Load(object sender, EventArgs e)
        {

        }

        private void pnlBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

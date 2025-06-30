using Service.Services;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop.Interface;
using Desktop.States.Localidades;
using System.Windows.Controls;

namespace KioscoInformaticoDesktop.Views
{
    public partial class LocalidadesView : Form
    {
        public IFormState InitialDisplayState;
        public IFormState AddState;
        public IFormState EditState;
        public IFormState DeleteState;

        // Estado actual del formulario
        public IFormState currentState;

        public IGenericService<Localidad> localidadService = new GenericService<Localidad>();
        public BindingSource listaLocalidades = new BindingSource();
        public Localidad localidadCurrent;

        public LocalidadesView()
        {
            InitializeComponent();
            InitialDisplayState = new InitialDisplayState(this);
            AddState = new AddState(this);
            EditState = new EditState(this);
            DeleteState = new DeleteState(this);

            currentState = InitialDisplayState;
            currentState.UpdateUI();
        }


        public void SetState(IFormState state)
        {
            currentState = state ?? throw new ArgumentNullException(nameof(state), "El estado no puede ser nulo.");

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SetState(AddState);
            currentState.OnAgregar();

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            currentState.OnGuardar();
            //    if (string.IsNullOrEmpty(txtNombre.Text))
            //    {
            //        MessageBox.Show("El nombre de la localidad es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    if (localidadCurrent != null)
            //    {
            //        localidadCurrent.Nombre = txtNombre.Text;
            //        await localidadService.UpdateAsync(localidadCurrent);
            //        localidadCurrent = null;
            //    }
            //    else
            //    {
            //        var localidad = new Localidad
            //        {
            //            Nombre = txtNombre.Text
            //        };
            //        await localidadService.AddAsync(localidad);
            //    }
            //    await CargarGrilla();
            //    txtNombre.Text = string.Empty;
            //    tabControl.SelectTab(tabPageLista);
            //
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SetState(EditState);
            currentState.OnModificar();
            //localidadCurrent = (Localidad)listaLocalidades.Current;
            //txtNombre.Text = localidadCurrent.Nombre;
            //tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            SetState(DeleteState);
            currentState.OnEliminar();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            currentState.OnCancelar();
            //localidadCurrent = null;
            //txtNombre.Text = string.Empty;
            //tabControl.SelectTab(tabPageLista);

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            currentState.OnBuscar();
            //FiltrarLocalidades();
        }

      
    }
}

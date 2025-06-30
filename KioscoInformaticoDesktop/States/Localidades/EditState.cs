using Desktop.Interface;
using KioscoInformaticoDesktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.States.Localidades
{
    internal class EditState : IFormState
    {
        private readonly LocalidadesView _form;
        public EditState(LocalidadesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }
        public void OnCancelar()
        {
            _form.txtNombre.Clear();
            _form.SetState(_form.InitialDisplayState);
            _form.currentState.UpdateUI();
        }
        public async void OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("El nombre de la localidad es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.localidadCurrent.Nombre = _form.txtNombre.Text.Trim();


            await _form.localidadService.UpdateAsync(_form.localidadCurrent);
            _form.SetState(_form.InitialDisplayState);
            await _form.currentState.UpdateUI();
        }

        public Task UpdateUI()
        {
            _form.localidadCurrent =_form.dataGridLocalidades.CurrentRow.DataBoundItem as Localidad;    
            _form.txtNombre.Text = _form.localidadCurrent.Nombre;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);
            return Task.CompletedTask;
        }
        public void OnModificar()
        {
            UpdateUI();
        }
        public void OnSalir() { }
        public void OnEliminar() { }
        public void OnBuscar() { }
        public void OnAgregar() {
        }

    }
}


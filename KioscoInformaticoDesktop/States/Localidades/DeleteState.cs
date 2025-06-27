using Desktop.Interface;
using KioscoInformaticoDesktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.States.Localidades
{
    internal class DeleteState : IFormState
    {
        private readonly LocalidadesView _form;
        public DeleteState(LocalidadesView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }

        public async void OnEliminar() {

           var localidad = (Localidad)_form.localidadCurrent;

            var result = MessageBox.Show($"¿Está seguro que desea eliminar la localidad {localidad.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await _form.localidadService.DeleteAsync(localidad.Id);
                _form.SetState(_form.InitialDisplayState);
                await _form.currentState.UpdateUI();

            }
            else
            {
                _form.SetState(_form.InitialDisplayState);
                
            }
            
        }

        public Task UpdateUI() { return Task.CompletedTask; }
        public void OnGuardar() { }
        public void OnLoadGrid() { }
        public void OnModificar() {  }
        public void OnSalir() { }
        public void OnAgregar() { }
        public void OnBuscar() { }
        public void OnCancelar() { }
          
    }
}

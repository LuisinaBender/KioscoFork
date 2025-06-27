using Desktop.Interface;
using KioscoInformaticoDesktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.States.Proveedores
{
    public class DeleteState : IFormState
    {
        private readonly ProveedoresView _form;
        public DeleteState(ProveedoresView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }
       
        public async void OnEliminar()
        {
            //no me salio
        }

        public void OnGuardar() {}
        public void OnModificar() {}
        public void OnSalir() {}
        public void OnAgregar() { }
        public void OnBuscar() { }
        public void OnCancelar() { }
        public Task UpdateUI() {return Task.CompletedTask;}
    }
}

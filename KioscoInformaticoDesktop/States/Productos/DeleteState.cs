using Desktop.Interface;
using KioscoInformaticoDesktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Desktop.States.Produtos
{
    public class DeleteState : IFormState
    {
        private readonly ProductosView _form;
        public DeleteState(ProductosView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }
        

        public async void OnEliminar()
        {
            var producto = (Producto)_form.ListProductos.Current;
            var result = MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _form.productoCurrent = (Producto)_form.ListProductos.Current;
                if (_form.productoCurrent != null)
                {
                    await _form.productoService.DeleteAsync(_form.productoCurrent.Id);
                    _form.SetState(_form.initialDisplayState);
                    _form.currentState.UpdateUI();
                }

            }
            else
            {
                _form.SetState(_form.initialDisplayState);
            }
        }

        public Task UpdateUI() { return Task.CompletedTask; }
        public void OnAgregar() { }
        public void OnBuscar() { }
        public void OnCancelar() { }
        public void OnGuardar() { }
        public void OnModificar() { }
        public void OnSalir() { }
    }
}

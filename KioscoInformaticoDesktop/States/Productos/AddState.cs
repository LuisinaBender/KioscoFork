using Desktop.Interface;
using Desktop.States.Produtos;
using KioscoInformaticoDesktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Desktop.States.Produtos
{
    public class AddState : IFormState
    {
        public readonly ProductosView _form;
        public AddState(ProductosView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }

        public void OnAgregar()
        {
            UpdateUI();
        }

        public void OnBuscar()
        {
            
        }

        public void OnCancelar()
        {
            _form.txtNombre.Clear();
            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }

        public void OnEliminar()
        {
            
        }

        public async void OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var producto = new Producto
            {
                Nombre = _form.txtNombre.Text,
                Precio = _form.numericPrecio.Value
            };
            await _form.productoService.AddAsync(producto);
            _form.SetState(_form.initialDisplayState);
            await _form.currentState.UpdateUI();
        }

        public void OnModificar()
        {
            UpdateUI();
        }

        public void OnSalir()
        {
            
        }

        public Task UpdateUI()
        {
            _form.txtNombre.Clear();
            _form.tabControl.IsAccessible = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);
            return Task.CompletedTask;
        }
    }
}

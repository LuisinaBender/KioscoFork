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
    public class AddState : IFormState

    {
        private readonly ProveedoresView _form;
        public AddState(ProveedoresView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }
        public void OnAgregar()
        {
            UpdateUI();
        }

        public void OnBuscar()
        {
            throw new NotImplementedException();
        }

        public void OnCancelar()
        {
            _form.txtNombre.Text = string.Empty;
            _form.txtDireccion.Text = string.Empty;
            _form.txtTelefonos.Text = string.Empty;
            _form.txtCbu.Text = string.Empty;
            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }

        public void OnEliminar()
        {
            throw new NotImplementedException();
        }

        public async void OnGuardar()
        {
            var proveedor = new Proveedor
            {
                Nombre = _form.txtNombre.Text,
                Direccion = _form.txtDireccion.Text,
                Telefonos = _form.txtTelefonos.Text,
                Cbu = _form.txtCbu.Text,
                LocalidadId = (int)_form.comboLocalidades.SelectedValue,
            };
            await _form.proveedorService.AddAsync(proveedor);
            _form.SetState(_form.initialDisplayState);
            await _form.currentState.UpdateUI();
        }

        public void OnModificar()
        {
            UpdateUI();
        }

        public void OnSalir()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUI()
        {
            _form.txtNombre.Text = string.Empty;
            _form.txtDireccion.Text = string.Empty;
            _form.txtTelefonos.Text = string.Empty;
            _form.txtCbu.Text = string.Empty;
            _form.tabControl1.SelectTab(_form.tabPageEditarAgregar);
            return Task.CompletedTask;
        }
    }
}

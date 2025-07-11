﻿using Desktop.Interface;
using KioscoInformaticoDesktop.Views;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.States.Produtos
{
    public class EditState : IFormState
    {
        private readonly ProductosView _form;
        public EditState(ProductosView form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }
       
        public void OnCancelar()
        {
            _form.txtNombre.Clear();
            _form.numericPrecio.Value = 0;
            _form.SetState(_form.initialDisplayState);
            _form.currentState.UpdateUI();
        }
        public async void OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.productoCurrent.Nombre = _form.txtNombre.Text;
            _form.productoCurrent.Precio = _form.numericPrecio.Value;


            await _form.productoService.UpdateAsync(_form.productoCurrent);
            _form.SetState(_form.initialDisplayState);
            await _form.currentState.UpdateUI();
        }

        public Task UpdateUI()
        {
            _form.productoCurrent = _form.dataGridProductosView.CurrentRow.DataBoundItem as Producto;
            _form.txtNombre.Text = _form.productoCurrent.Nombre;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);
            return Task.CompletedTask;
        }
        public void OnSalir() { }
        public void OnModificar() { }
        public void OnEliminar() { }
        public void OnAgregar() { }
        public void OnBuscar() { }
    }
}

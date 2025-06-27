using Desktop.Interface;
using KioscoInformaticoDesktop.Views;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.States.Produtos
{
    
        public class InitialDisplayState : IFormState
        {
            public ProductosView _form;
            public InitialDisplayState(ProductosView form)

            {
                _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
            }

        public async void OnBuscar()
            {
                await UpdateUI();
        }

            public void OnSalir()
            {
                _form.Close();
            }

        public async Task UpdateUI()
        {
            var productos = await _form.productoService.GetAllAsync("");
            _form.ListProductos.DataSource = productos;
            _form.dataGridProductosView.DataSource = _form.ListProductos;
            _form.tabControl.SelectTab(_form.tabPageLista);
            _form.tabControl.Selecting += (sender, e) =>
            {
                if (e.TabPage == _form.tabPageAgregarEditar && (_form.currentState == _form.initialDisplayState)) ;


            };
            ;
        }

        public void OnGuardar() { }
        public void OnCancelar() { }
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnEliminar() { }
        }
    }



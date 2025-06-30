using Desktop.Interface;
using KioscoInformaticoDesktop.Views;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.States.Localidades
{
    public class InitialDisplayState : IFormState
    {
        private LocalidadesView _form;
        public InitialDisplayState(LocalidadesView form)

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
            _form.listaLocalidades.DataSource = await _form.localidadService.GetAllAsync(_form.txtFiltro.Text);
            _form.dataGridLocalidades.DataSource = _form.listaLocalidades;
            _form.tabControl.SelectTab(_form.tabPageLista);
            _form.tabControl.Selecting += (sender, e) =>
            {
                if (e.TabPage == _form.tabPageAgregarEditar && (_form.currentState == _form.InitialDisplayState)) ;


            };
        }

        public void OnGuardar() { }
        public void OnCancelar() { }
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnEliminar() { }
    }
}

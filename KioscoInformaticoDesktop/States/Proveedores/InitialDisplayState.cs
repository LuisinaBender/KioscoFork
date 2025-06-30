using Desktop.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KioscoInformaticoDesktop.Views;

namespace Desktop.States.Proveedores
{
    public class InitialDisplayState : IFormState
    {
        private ProveedoresView _form;
        public InitialDisplayState(ProveedoresView form)

        {
            _form = form ?? throw new ArgumentNullException(nameof(form), "El formulario no puede ser nulo.");
        }


        public void OnAgregar()
        {

        }

        public async void OnBuscar()
        {
            await UpdateUI();
        }

        public void OnCancelar()
        {

        }

        public void OnEliminar()
        {

        }

        public void OnGuardar()
        {

        }

        public void OnModificar()
        {

        }

        public void OnSalir()
        {
            _form.Close();
        }

        public async Task UpdateUI()
        {
            await CargarCombo();
            var proveedores = await _form.proveedorService.GetAllAsync(null);
            _form.ListProveedores.DataSource = proveedores;
            _form.dataGridProveedoresView.DataSource = _form.ListProveedores;
            _form.tabControl1.SelectTab(_form.tabPageLista);
        }

        public async Task CargarCombo()
        {
            _form.comboLocalidades.DataSource = await _form.localidadService.GetAllAsync("");
            _form.comboLocalidades.DisplayMember = "Nombre";
            _form.comboLocalidades.ValueMember = "Id";
            _form.comboLocalidades.SelectedIndex = -1;
        }
    }
}

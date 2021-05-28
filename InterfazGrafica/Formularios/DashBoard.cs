using InterfazGrafica.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace InterfazGrafica.Formularios
{
    public partial class DashBoard : Form
    {
        #region Atributos
        private UC.BienvenidaUC bienvenidaUC;

        private ClientesUC clientes = new ClientesUC();

        private ListaPedidosUC listaPedidos;

        private ResumenUC resumen;
        #endregion

        #region Constructor

        public DashBoard()
        {
            InitializeComponent();

            BienvenidaUC = new UC.BienvenidaUC();
            panel_BaseDashboard.Controls.Add(BienvenidaUC);

        }

        #endregion

        #region Propiedades

        public BienvenidaUC BienvenidaUC { get => bienvenidaUC; set => bienvenidaUC = value; }
        public ClientesUC Clientes { get => clientes; set => clientes = value; }
        public ListaPedidosUC ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
        public ResumenUC Resumen { get => resumen; set => resumen = value; }


        #endregion

        #region Metodos

        #endregion

        #region Eventos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Clientes_Click(object sender, EventArgs e)
        {

            // TODO: crea el UC ClientesUC y cargalo en el Dashboard

            panel_BaseDashboard.Controls.Clear();
            this.clientes.ClienteSeleccionado += ClientesUC_ClienteSeleccionado;
            panel_BaseDashboard.Controls.Add(this.clientes);
            

        }

        /// <summary>
        /// 
        /// </summary>
        void ClientesUC_ClienteSeleccionado()
        {
            Console.WriteLine("clientes clicado");
            // TODO: Habilita el boton lista pedidos
            but_ListaPedidos.Enabled = true; ;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_ListaPedidos_Click(object sender, EventArgs e)
        {

            this.listaPedidos = new ListaPedidosUC(this.clientes.ClinteSeleccionado.IDCliente);

            panel_BaseDashboard.Controls.Remove(this.clientes);

            panel_BaseDashboard.Controls.Add(this.listaPedidos);

            but_Resumen.Enabled = true;

        }






        #endregion

        private void but_Resumen_Click(object sender, EventArgs e)
        {
            this.resumen = new ResumenUC(this.listaPedidos.ListaPedidos);
            panel_BaseDashboard.Controls.Remove(this.listaPedidos);
            panel_BaseDashboard.Controls.Add(this.resumen);
        }
    }
}

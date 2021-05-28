using ObjetosTransferencia.DTO;
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

namespace InterfazGrafica.UC
{
    public partial class ListaPedidosUC : UserControl
    {
        private List<PedidoDTO> listaPedidos;

        public ListaPedidosUC(String nombreCliente)
        {
            InitializeComponent();
            // TODO: haz la peticion de los clientes y asociala a la lista y cargalo en el DataGridView
            var pedidos = ControladorBLL.ListarPedidosCliente(nombreCliente);
            listaPedidos = pedidos;
            dGV_Pedidos.DataSource = pedidos;
         
        }

        public List<PedidoDTO> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }


    }
}

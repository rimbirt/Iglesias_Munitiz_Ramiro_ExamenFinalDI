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

namespace InterfazGrafica.UC
{
    public partial class ResumenUC : UserControl
    {

        private List<PedidoDTO> listaPedidos;

        public ResumenUC(List<PedidoDTO> listaPedidos)
        {
            InitializeComponent();

            this.listaPedidos = listaPedidos;

            PintarGrafico();

            PintarSumaGastosEnvio();

            
        }

        private void PintarSumaGastosEnvio()
        {
            double gastosEnvio = 0;

            for (int i = 0; i < listaPedidos.Count; i++)
            {
                gastosEnvio = gastosEnvio + listaPedidos[i].PrecioEnvio;
            }

            lab_SumaEnvio.Text = "Gastos de envio totales: " + gastosEnvio.ToString();
        }

        private void PintarGrafico() {
            for (int i = 0; i<listaPedidos.Count;i++) {
                chart_Pedidos.Series["Gastos Envio"].Points.AddXY(listaPedidos[i].FechaEnvio, listaPedidos[i].PrecioEnvio);

            }
        }


    }
}

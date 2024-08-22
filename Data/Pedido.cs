using System;
using System.Collections.Generic;

namespace ApiTMS.Data
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public int IdEstado { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdCiudadOrigen { get; set; }
        public string DireccionOrigen { get; set; } = null!;
        public int IdCiudadDestino { get; set; }
        public string DireccionDestino { get; set; } = null!;
        public DateTime Fecha { get; set; }

        public virtual Ciudad IdCiudadDestinoNavigation { get; set; } = null!;
        public virtual Ciudad IdCiudadOrigenNavigation { get; set; } = null!;
        public virtual Estado IdEstadoNavigation { get; set; } = null!;
    }
}

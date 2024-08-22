using System;
using System.Collections.Generic;

namespace ApiTMS.Data
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            PedidoIdCiudadDestinoNavigations = new HashSet<Pedido>();
            PedidoIdCiudadOrigenNavigations = new HashSet<Pedido>();
        }

        public int IdCiudad { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Pedido> PedidoIdCiudadDestinoNavigations { get; set; }
        public virtual ICollection<Pedido> PedidoIdCiudadOrigenNavigations { get; set; }
    }
}

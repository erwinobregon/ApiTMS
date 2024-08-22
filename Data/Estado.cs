using System;
using System.Collections.Generic;

namespace ApiTMS.Data
{
    public partial class Estado
    {
        public Estado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}

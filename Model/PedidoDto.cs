namespace ApiTMS.Model
{
    public class PedidoDto
    {
        public int IdPedido { get; set; }
        public int IdEstado { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdCiudadOrigen { get; set; }
        public string DireccionOrigen { get; set; } = null!;
        public int IdCiudadDestino { get; set; }
        public string DireccionDestino { get; set; } = null!;
        public DateTime Fecha { get; set; }

        public string CiudadOrigen { get; set; } = null!;
        public string CiudadDestino { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}

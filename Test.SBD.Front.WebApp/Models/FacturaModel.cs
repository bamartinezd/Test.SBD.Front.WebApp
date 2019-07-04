namespace Test.SBD.Front.WebApp.Models
{
    using System;

    public partial class FacturaModel
    {
        public int Id { get; set; }

        public long? ClienteId { get; set; }

        public DateTime? FechaVenta { get; set; }

        public decimal? ValorTotal { get; set; }

        public bool? Estado { get; set; }
    }
}
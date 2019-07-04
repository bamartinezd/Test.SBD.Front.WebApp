namespace Test.SBD.Front.WebApp.Models
{
    using System;

    public partial class ClienteModel
    {
        public long Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public bool? Estado { get; set; }
    }
}
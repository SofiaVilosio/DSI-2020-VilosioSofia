
namespace OpenShopCarrito.PatronDTO
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DatosCobranza
    {
        [JsonProperty("Cliente")]
        public Cliente Cliente { get; set; }

        [JsonProperty("FechaVenta")]
        public DateTime FechaVenta { get; set; }

        [JsonProperty("Monto")]
        public decimal Monto { get; set; }
        
        [JsonProperty("Producto")]
        public List<Producto> Producto { get; set; }
    }

    public partial class Cliente
    {
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Apellido")]
        public string Apellido { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("DNI")]
        public long Dni { get; set; }

        [JsonProperty("Domicilio")]
        public string Domicilio { get; set; }

        [JsonProperty("Provincia")]
        public string Provincia { get; set; }
    }

    public partial class Producto
    {
        [JsonProperty("idProducto")]
        public string IdProducto { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Descripción")]
        public string Descripción { get; set; }

        [JsonProperty("Marca")]
        public string Marca { get; set; }

        [JsonProperty("Cantidad")]
        public long Cantidad { get; set; }

        [JsonProperty("Precio")]
        public decimal Precio { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, OpenShopCarrito.PatronDTO.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, OpenShopCarrito.PatronDTO.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

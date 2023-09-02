using System.Text.Json.Serialization;

namespace DataLayer.EntityModel
{
        public class SucursalEntity
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public int C_Id_Sucursal { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string C_Nombre { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string C_Url_Img { get; set; }
           

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? C_Transaccion_Mensaje { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public int C_Transaccion_Estado { get; set; }

    }

}
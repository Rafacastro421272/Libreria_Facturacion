using WebApi_Entity_Framework.Data.Models;

namespace WebApi_Entity_Framework.Dto
{
    public class ArticuloDto
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        //public bool Activo { get; set; } = true;

        public static ArticuloDto FromEntity(Articulo a)
        {
            return new ArticuloDto()
            {
                IdArticulo = a.IdArticulo,
                Nombre = a.Nombre,
                Precio = a.PreUnitario ?? 0m
            };
        }

        public static Articulo ToEntity(ArticuloDto dto)
        {
            return new Articulo
            {
                IdArticulo = dto.IdArticulo,
                Nombre = dto.Nombre,
                PreUnitario = dto.Precio
            };
        }

    }
}

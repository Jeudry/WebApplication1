using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ClienteModel
    {
        public int Id_c { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? nom_c { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? tel_c { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? cor_c { get; set; }
    }
}

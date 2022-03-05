using System.ComponentModel.DataAnnotations;

namespace BrokerAPP.Application.DTOs
{
    public class AssetDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ERROR! Name is Required")]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BrokerAPP.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ERROR! Name is Required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "ERROR! Age is Required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "ERROR! Balance is Required")]
        public long Balance { get; set; }
    }
}

using AP.BoomTP.Application.CQRS.UserCQRS;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.User
{
    public class CreateUserVievModel
    {
        public int Id { get; set; }

        [Display(Name = "Voornaam")]
        [Required(ErrorMessage = "Voornaam is een verplicht veld")]
        public string FirstName { get; set; }

        [Display(Name = "Achternaam")]
        [Required(ErrorMessage = "Achternaam is een verplicht veld")]
        public string LastName { get; set; }

        [Display(Name = "AuthId")]
        [Required(ErrorMessage = "AuthId is een verplicht veld")]
        public string AuthId { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Mail is een verplicht veld")]
        public string Email { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Rol is een verplicht veld")]
        public Role Role { get; set; }

        [Display(Name = "Contract type")]
        [Required(ErrorMessage = "Contract is een verplicht veld")]
        public ContractType ContractType { get; set; }
    }
}

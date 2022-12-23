using AP.BoomTP.Application.CQRS.UserCQRS;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AP.BoomTP.WebApp.ViewModels.User
{
    public class UpdateUserViewModel
    {

        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [Display(Name = "AuthId")]
        public string AuthId { get; set; }

        [Display(Name = "Mail")]
        public string Email { get; set; }

        [Display(Name = "Rol")]
        public Role Role { get; set; }

        [Display(Name = "Contract type")]
        public ContractType ContractType { get; set; }
    }
}

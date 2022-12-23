using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Application.CQRS.UserCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.Domain;
using System.ComponentModel.DataAnnotations;

namespace AP.BoomTP.WebApp.ViewModels.Schedule
{
    public class UpdateScheduleViewModel
    {
        public int Id { get; set; }
        public IEnumerable<ZoneDTO>? Zones { get; set; }
        public IEnumerable<UserDTO>? Users { get; set; }
        public IEnumerable<TasksDTO>? Tasks { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is een verplicht veld")]
        public DateTime Date { get; set; }

        [Display(Name = "UserId")]
        [Required(ErrorMessage = "UserId is een verplicht veld")]
        public int UserId { get; set; }

        [Display(Name = "ZoneId")]
        [Required(ErrorMessage = "ZoneId is een verplicht veld")]
        public int ZoneId { get; set; }
        public int[] TaskId { get; set; }
    }
}


namespace PsychologyVisitSite.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using PsychologyVisitSite.Domain.Enums;

    public class RegistrationForm
    {
        //  [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        //    [Required(ErrorMessage = "Укажите как вас зовут")]
        //    [Display(Name = "Имя")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Location { get; set; }

        //   [Required(ErrorMessage = "Укажите адресс электронной почты")]
        //    [Display(Name = "Адресс электронной почты")]
        //    [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //  [Required(ErrorMessage = "Укажите телефонный номер")]
        //   [Display(Name = "Телефонный номер")]
        //  [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string Skype { get; set; }

        public ContactType ContactType { get; set; }

        //   [Display(Name = "Комментарий")]
        //   [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}


namespace PsychologyVisitSite.Domain.Entities
{
    using System;
  //  using System.ComponentModel.DataAnnotations;
   // using System.Web.Mvc;

    using PsychologyVisitSite.Domain.Enums;

    public class MeetingEvent
    {
       // [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

    //    [Display(Name = "Название")]
    //    [Required(ErrorMessage = "Пожалуйста, введите название")]
        public string Name { get; set; }

    //    [Display(Name = "Описание")]
   //     [Required(ErrorMessage = "Пожалуйста, введите описание")]
    //    [DataType(DataType.MultilineText)]
        public string Description { get; set; }

   //     [Display(Name = "Категория")]
   //     [Required(ErrorMessage = "Пожалуйста, укажите категорию")]
        public string Category { get; set; }

     //   [Display(Name = "Цена (грн)")]
    //    [Required]
    //    [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

     //   [Display(Name = "Время проведения")]
        public DateTime EventDateTime { get; set; }

        public RelevantType NotRelevant { get; set; }

        public int RegisteredPeopleNumber { get; set; }
    }
}

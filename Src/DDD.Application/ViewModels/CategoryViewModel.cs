using System;
using System.ComponentModel.DataAnnotations;

namespace DDD.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        public string Name { get; set; }
    }
}

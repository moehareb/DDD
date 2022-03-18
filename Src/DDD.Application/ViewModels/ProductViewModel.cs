using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DDD.Domain.Models;

namespace DDD.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Barcode is Required")]
        public string Barcode { get;  set; }
        public string Description { get;  set; }

        [Range(0.5,200,ErrorMessage ="Weight must be between 0.5Kg and 200Kg")]
        public float Weight { get;  set; }
        public int Quantity { get; set; }
        public Status ProductSatus { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }

    public class ProductSellViewModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}

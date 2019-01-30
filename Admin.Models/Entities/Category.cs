﻿using Admin.Models.Abstracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity<int>
    {
        private decimal _taxRate;

        [StringLength(100, ErrorMessage = "Kategori adi 3-100 karakter arasinda olabilir.", MinimumLength = 3)]
        [DisplayName("Kategori Adı")]
        [Required]
        public string CategoryName { get; set; }

        [DisplayName("Kdv")]
        [Range(0, 100)]
        public decimal TaxRate { get=>_taxRate*100; set=>_taxRate=value/100; }

        [DisplayName("Üst Kategori")]
        public int? SupCategoryId { get; set; }
        
        [ForeignKey("SupCategoryId")]
        public virtual Category SupCategory { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}

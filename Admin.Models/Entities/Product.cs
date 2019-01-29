﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Admin.Models.Abstracts;
using Admin.Models.Enums;

namespace Admin.Models.Entities
{
    [Table("Products")]
    public class Product : BaseEntity<Guid>
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }
        //yrum eklendi
        [DisplayName("Birim")]
        public int Quantity { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Ürün Adi 1-100 karakter arasinda olmalıdır.")]
        [Required]
        [DisplayName("Ürün Adi")]
        public string ProductName { get; set; }

        [DisplayName("Ürün Tipi")]
        public ProductTypes ProductType { get; set; }

        [DisplayName("Satış Fiyatı")]
        public decimal SalesPrice { get; set; }
        [DisplayName("Alış Fiyatı")]
        public decimal BuyPrice { get; set; }

        [DisplayName("Stok Miktarı")]
        [Range(0,9999)]
        public double UnitsInStock { get; set; }

        [DisplayName("Fiyat Güncellenme Tarihi")]
        public DateTime LastPriceUpdate { get; set; }

        public int CategoryId { get; set; }

        public Guid? SupProductId { get; set; }

        [StringLength(20)]
        [Required]
        [Index(IsUnique = true)]
        public string Barcode { get; set; }

        [ForeignKey("SupProductId")]
        public virtual Product SupProduct { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
    }
}

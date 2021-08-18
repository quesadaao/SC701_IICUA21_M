using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class InvoiceDetail
    {
        public int Id { get; set; }
        public int InvoiceHeaderId { get; set; }
        public int MaterialId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalLine { get; set; }

        public virtual InvoiceHeader InvoiceHeader { get; set; }
        public virtual Material Material { get; set; }
    }
}

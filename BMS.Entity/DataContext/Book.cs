namespace BMS.Entity.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Author { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; }

        public int PublicationYear { get; set; }

        public decimal Price { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    
    
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string Key { get; set; }
        //list from https://en.wikipedia.org/wiki/ISO_4217

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
    //can add format for avoid .00 for IRR/Iran
}
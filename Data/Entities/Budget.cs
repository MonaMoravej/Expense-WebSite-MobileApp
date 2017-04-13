using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    
    public  class Budget
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public decimal Amount { get; set; } 

        [Required]
        public DateTime YearMonth { get; set; }


        //navigation Property
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }


        [Required]
        public long CategoryId { get; set; }

        public Category Category { get; set; }


        [Required]
        [StringLength(14)] // YearMonth(6char)-[I/E]-5 char for categoryName ,eg. 139103-I-AutoG
        public string Key { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }


    }
}

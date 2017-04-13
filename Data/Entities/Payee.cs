using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities
{
   
    public  class Payee
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName ="nvarchar(max)")]
        public string Memo { get; set; }


        //navigation Property 

        [Required]
        public long UserId { get; set; }
        public User User { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public ICollection<Transaction> Transactions { get; set; }


        [Required]
        [StringLength(12)] // Name(4char)-[I/E]-5 char for categoryName ,eg. 139103-I-AutoG
        public string Key { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities
{
  
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal StartBalance { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }

        //navigation property

        [Required]
         public long UserId { get; set; }
        public User User { get; set; }
     
        [Required]
        public AccountType Type { get; set; } = AccountType.Cash;

        [Required]
        public Color Color { get; set; } = Color.Gray;


        [InverseProperty("Account")]
        public ICollection<Transaction> Transactions { get; set; }

        [InverseProperty("ToAccount")]
        public ICollection<Transaction> ToTransactions { get; set; }

        [InverseProperty("FromAccount")]
        public ICollection<Transaction> FromTransactions { get; set; }



        [Required]
        [StringLength(8)]
        public string Key { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }

        //  [Obsolete("Only needed for serialization and materialization", true)]

    }
}

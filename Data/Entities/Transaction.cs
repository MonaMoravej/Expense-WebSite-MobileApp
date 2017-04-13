using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities
{
   
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }


        [Required]
        public DateTime Date { get; set; } //must get from client not serve = DateTime.Today;


        [Required]
        public TransactionType Type { get; set; } = TransactionType.Expense;

        [Required]
        public decimal Amount { get; set; }

        //navigation Property

        [Required]
        public long UserId { get; set; }
        public User User { get; set; }

        public long? PayeeId { get; set; }

        [ForeignKey("PayeeId")]
        public Payee Payee { get; set; }

        public long? AccountId { get; set; }
        
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        
        public long? CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

       
        public long? ToAccountId { get; set; }

        [ForeignKey("ToAccountId")]
        public Account ToAccount { get; set; }
        
          
        public long? FromAccountId { get; set; }

        [ForeignKey("FromAccountId")]
        public Account FromAccount { get; set; }

        
        //41
        //type(2)-date(8)-payee(12)-account(8)-category(7)

        //31
        //type(2)-date(8)-acountfrom(8)-accountto(8)-number per day (9 transaction per day)(1)
        //[Required]
        //[StringLength(41)] // type+date+payee+account+category … or type+date+from+to+
        //public string Key { get; set; } //is it necessary after all????


        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

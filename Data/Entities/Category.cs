using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities
{
    [Table("Categories", Schema = "Expense")]
    public class Category
    {
          [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public CategoryType Type { get; set; } = CategoryType.Expense;


        //navigation property
        public long? UserId { get; set; }
        public User User { get; set; }

        public long? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public Category Parent { get; set; }

        [InverseProperty("Parent")]
        public ICollection<Category> Children { get; set; }

        public long? IconId { get; set; }

        [ForeignKey("IconId")]
        public Icon Icon { get; set; }


        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Payee> Payees { get; set; }
        public ICollection<Budget> Budgets { get; set; }

        [Required]
        [StringLength(7)] // [I/E]-5 char for categoryName ,eg.I-AutoG
        public string Key { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

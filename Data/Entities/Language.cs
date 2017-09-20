using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities
{
   
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Key { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }


    }
}
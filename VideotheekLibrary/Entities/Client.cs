using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideotheekLibrary.Entities
{
    [Table("clients")]
    public class Client : BaseEntity<int>
    {
        [Key]
        [Column("client_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int ID { get; set; }

        public override bool IsNew()
        {
            return this.ID == 0;
        }

        [Column("surname")]
        [Required(ErrorMessage = "A surname is required")]
        [StringLength(255, ErrorMessage = "A surname cannot be longer than 255 characters")]
        public string Surname { get; set; }

        [Column("first_name")]
        [Required(ErrorMessage = "A first name is required")]
        [StringLength(255, ErrorMessage = "A first name cannot be longer than 255 characters")]
        public string FirstName { get; set; }

        [Column("birth_date")]
        [Required(ErrorMessage = "A birth date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        
    }
}

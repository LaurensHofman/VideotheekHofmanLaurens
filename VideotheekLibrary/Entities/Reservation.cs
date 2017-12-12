using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideotheekLibrary.Entities
{
    [Table("reservations")]
    public class Reservation
    {
        [Key]
        [Column("reservation_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("created_at")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime CreatedAt { get; set; }

        public Reservation()
        {
            CreatedAt = DateTime.Now;
        }

        [Column("res_DVD_id", Order = 1)]
        public int ResDVDID { get; set; }
        
        [Column("res_client_id", Order = 2)]
        public int ResClientID { get; set; }

        [Column("client_full_details")]
        public string ClientFullDetails { get; set; }

        [Column("dvd_full_details")]
        public string DVDDetails { get; set; }
    }
}

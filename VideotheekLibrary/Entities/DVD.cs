using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideotheekLibrary.Entities
{
    public class DVD : BaseEntity<int>
    {
        [Key]
        [Column("DVD_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int ID { get; set; }

        public override bool IsNew()
        {
            return this.ID == 0;
        }

        [Column("name")]
        [Required(ErrorMessage = "A name is required for the DVD")]
        [StringLength(255, ErrorMessage = "A name cannot be longer than 255 characters")]
        public string Name { get; set; }

        [Column("stock")]
        [Required(ErrorMessage = "A current stock is required")]
        [Range(0, 99999, ErrorMessage = "The stock cannot be lower than 0")]
        public int Stock { get; set; }

        [Column("price")]
        [Required(ErrorMessage = "A price per day is required")]
        [Range(0.00, 99999, ErrorMessage = "A price must be greater than € 0.00")]
        [DisplayFormat(DataFormatString = "{0:0, 0.00}")]
        [DisplayName("Price (€)")]
        public Decimal Price{ get; set; }

        [Column("director")]
        public string Director { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("PEGI_age")]
        public int? PEGIage { get; set; }

        [Column("genres")]
        public string Genres { get; set; }

        [Column("DVD_type")]
        public string DVDType { get; set; }

        [Column("movie_duration")]
        [Range(0, 99999, ErrorMessage = "The movie duration has to be at least 0 minutes")]
        public int? MovieDuration { get; set; }

        [Column("series_episodes")]
        [Range(0, 99999, ErrorMessage = "The amount of episodes has to be at least 0")]
        public int? SeriesEpisodes { get; set; }
        


    }
}

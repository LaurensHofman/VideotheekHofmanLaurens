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
    /// <summary>
    /// Contains the entity from a DVD.
    /// </summary>
    [Table("DVDs")]
    public class DVD : BaseEntity<int>
    {
        /// <summary>
        /// Overrides the unique ID of the entity.
        /// </summary>
        [Key]
        [Column("DVD_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int ID { get; set; }

        /// <summary>
        /// Gives the information that this DVD is new, which can be used by other classes.
        /// </summary>
        /// <returns></returns>
        public override bool IsNew()
        {
            return this.ID == 0;
        }

        /// <summary>
        /// Gets/Sets the name of the DVD.
        /// </summary>
        [Column("name")]
        [Required(ErrorMessage = "A name is required for the DVD")]
        [StringLength(255, ErrorMessage = "A name cannot be longer than 255 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Gets/Sets the total stock of the DVD.
        /// </summary>
        [Column("stock")]
        [Required(ErrorMessage = "A current stock is required")]
        [Range(0, 99999, ErrorMessage = "The stock cannot be lower than 0")]
        public int? Stock { get; set; }
        
        /// <summary>
        /// Determines the available stock of the DVD.
        /// </summary>
        public int? AvailableStock
        {
            get
            {
                return Stock - ReservedAmount;
            }
        }

        /// <summary>
        /// Gets/Sets the reserved amount of the DVD.
        /// </summary>
        [Column("reserved_amount")]
        public int? ReservedAmount { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DVD()
        {
            ReservedAmount = 0;
        }

        /// <summary>
        /// Gets/Sets the price of the DVD.
        /// </summary>
        [Column("price")]
        [Required(ErrorMessage = "A price per day is required")]
        [Range(0.00, 99999, ErrorMessage = "A price must be greater than € 0,00")]
        [DisplayName("Price (€)")]
        public Decimal? Price { get; set; }

        /// <summary>
        /// Gets/Sets the Director or Creator of the DVD.
        /// </summary>
        [Column("director")]
        public string Director { get; set; }

        /// <summary>
        /// Gets/Sets the description of the DVD.
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets/Sets the minimum allowed age to watch the DVD.
        /// </summary>
        [Column("PEGI_age")]
        public int? PEGIage { get; set; }

        /// <summary>
        /// Gets/Sets the genres of the DVD.
        /// </summary>
        [Column("genres")]
        public string Genres { get; set; }

        /// <summary>
        /// Gets/Sets the type of DVD this one is (Movie or TV series).
        /// </summary>
        [Column("DVD_type")]
        public string DVDType { get; set; }

        /// <summary>
        /// Gets/Sets the duration, if this DVD is a movie.
        /// </summary>
        [Column("movie_duration")]
        [Range(0, 99999, ErrorMessage = "The movie duration has to be at least 0 minutes")]
        public int? MovieDuration { get; set; }

        /// <summary>
        /// Gets/Sets the amount of episodes, if this DVD is a TV series.
        /// </summary>
        [Column("series_episodes")]
        [Range(0, 99999, ErrorMessage = "The amount of episodes has to be at least 0")]
        public int? SeriesEpisodes { get; set; }
    }
}

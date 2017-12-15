using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideotheekLibrary.Entities
{
    /// <summary>
    /// Contains the generic information, that could be used by multiple entities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// Gets/sets the unique ID of the entity
        /// </summary>
        public abstract T ID { get; set; }

        /// <summary>
        /// Gets/sets the exact time when the entity is created
        /// </summary>
        [Column("created_at")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets/sets the exact time when the entity is modified
        /// </summary>
        [Column("modified_at")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Gets/sets the exact time when the entity is "deleted"
        /// </summary>
        [Column("deleted_at")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Checks whether the object is new
        /// </summary>
        /// <returns></returns>
        public abstract bool IsNew();

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseEntity()
        {
            CreatedAt = ModifiedAt = DateTime.Now;
        }
    }
}

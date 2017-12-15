using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideotheekLibrary.Data;
using VideotheekLibrary.Entities;
using System.Data.Entity;

namespace VideotheekLibrary.DAL
{
    /// <summary>
    /// Data Access Logic for actions concerning DVDs.
    /// </summary>
    public static class DAL_DVD
    {
        /// <summary>
        /// Gets a list of all the DVDs from the database.
        /// </summary>
        /// <returns></returns>
        public static List<DVD> GetAll()
        {
            var ctx = AppDbContext.Instance();

            return ctx.DVDs
                .Where(dvd => dvd.DeletedAt == null)
                .OrderBy(dvd => dvd.Name)
                .ToList();
        }

        /// <summary>
        /// Adds a new DVD to the database.
        /// </summary>
        /// <param name="model"></param>
        public static void Create(DVD model)
        {
            var ctx = AppDbContext.Instance();

            ctx.DVDs.Add(model);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Updates an existing DVD in the database.
        /// </summary>
        /// <param name="model"></param>
        public static void Update(DVD model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        /// <summary>
        /// Gets a filtered list of DVDs from the database.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static List<DVD> Filter(string search, string filter)
        {
            var ctx = AppDbContext.Instance();
            
            switch (filter)
            {
                case "Name":
                    return ctx.DVDs
                                .Where(dvd => dvd.Name.Contains(search) && dvd.DeletedAt == null)
                                .OrderBy(dvd => dvd.Name)
                                .ToList();

                case "Director":
                    return ctx.DVDs
                                .Where(dvd => dvd.Director.Contains(search) && dvd.DeletedAt == null)
                                .OrderBy(dvd => dvd.Director)
                                .ToList();

                case "Genres":
                    return ctx.DVDs
                                .Where(dvd => dvd.Genres.Contains(search) && dvd.DeletedAt == null)
                                .OrderBy(dvd => dvd.Genres)
                                .ToList();

                default:
                    return ctx.DVDs
                                .Where(dvd => dvd.DeletedAt == null)
                                .OrderBy(dvd => dvd.Name)
                                .ToList();
            }

            
        }
    }
}

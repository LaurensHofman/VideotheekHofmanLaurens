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
    public static class DAL_DVD
    {
        public static List<DVD> GetAll()
        {
            var ctx = AppDbContext.Instance();

            return ctx.DVDs
                .Where(dvd => dvd.DeletedAt == null)
                .OrderBy(dvd => dvd.Name)
                .ToList();
        }

        public static void Create(DVD model)
        {
            var ctx = AppDbContext.Instance();

            ctx.DVDs.Add(model);
            ctx.SaveChanges();
        }

        public static void Update(DVD model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }

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
                    break;

                case "Director":
                    return ctx.DVDs
                                .Where(dvd => dvd.Director.Contains(search) && dvd.DeletedAt == null)
                                .OrderBy(dvd => dvd.Director)
                                .ToList();
                    break;

                case "Genres":
                    return ctx.DVDs
                                .Where(dvd => dvd.Genres.Contains(search) && dvd.DeletedAt == null)
                                .OrderBy(dvd => dvd.Genres)
                                .ToList();
                    break;

                default:
                    return ctx.DVDs
                                .Where(dvd => dvd.DeletedAt == null)
                                .OrderBy(dvd => dvd.Name)
                                .ToList();
            }

            
        }
    }
}

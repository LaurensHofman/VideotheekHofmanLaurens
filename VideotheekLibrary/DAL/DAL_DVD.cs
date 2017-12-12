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
                .OrderBy(d => d.Name)
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

        public static string GetDetails(int dvdID)
        {
            var ctx = AppDbContext.Instance();

            var det = ctx.DVDs.SingleOrDefault(c => c.ID == dvdID);
            return det.Details;

        }
    }
}

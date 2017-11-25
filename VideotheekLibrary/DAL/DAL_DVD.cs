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
    }
}

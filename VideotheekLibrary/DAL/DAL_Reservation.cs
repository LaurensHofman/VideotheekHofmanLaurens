using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideotheekLibrary.Data;
using VideotheekLibrary.Entities;

namespace VideotheekLibrary.DAL
{
    public static class DAL_Reservation
    {
        public static List<Reservation> GetAll()
        {
            var ctx = AppDbContext.Instance();

            return ctx.Reservations
                .OrderBy(r => r.ClientFullDetails)
                .ToList();
        }

        public static List<Reservation> GetAllReservations(int clientID)
        {
            var ctx = AppDbContext.Instance();

            return ctx.Reservations
                .Where(r => r.ResClientID == clientID)
                .ToList();
        }

        public static void Create(Reservation model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Reservations.Add(model);
            ctx.SaveChanges();
        }

        public static void Delete(Reservation model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Reservations.Remove(model);
            ctx.SaveChanges();
        }

        public static List<Reservation> GetSpecific(int resClientID)
        {
            var ctx = AppDbContext.Instance();

            return ctx.Reservations
                .Where(r => r.ResClientID == resClientID)
                .OrderBy(r => r.DVDDetails)
                .ToList();
        }
    }
}

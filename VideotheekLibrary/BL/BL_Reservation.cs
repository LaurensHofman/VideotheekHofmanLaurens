using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideotheekLibrary.DAL;
using VideotheekLibrary.Entities;

namespace VideotheekLibrary.BL
{
    public static class BL_Reservation
    {
        public static List<Reservation> GetAll()
        {
            try
            {
                return DAL_Reservation.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Reservation> GetAllReservations(int clientID)
        {
            try
            {
                return DAL_Reservation.GetAllReservations(clientID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Create(Reservation model)
        {
            try
            {
                DAL_Reservation.Create(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public static void Delete(Reservation model)
        {
            try
            {
                DAL_Reservation.Delete(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Reservation> GetSpecific(int resClientID)
        {
            return DAL_Reservation.GetSpecific(resClientID);
        }
    }
}

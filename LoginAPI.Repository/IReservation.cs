using LoginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Repository
{
        public interface IReservationRepository
        {
            Task<IEnumerable<Reservation>> GetAllReservations();
            Task<Reservation> GetReservationById(int id);
            Task AddReservation(Reservation reservation);
            Task UpdateReservation(Reservation reservation);
            Task DeleteReservation(int id);
        }

}

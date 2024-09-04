using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginAPI;
using LoginAPI.Core;
using LoginAPI.Repository;

namespace LoginAPI.Service
{
        public class ReservationService : IReservationService
        {
            private readonly IReservationRepository _reservationRepository;

            public ReservationService(IReservationRepository reservationRepository)
            {
                _reservationRepository = reservationRepository;
            }

            public async Task<IEnumerable<Reservation>> GetAllReservations()
            {
                return await _reservationRepository.GetAllReservations();
            }

            public async Task<Reservation> GetReservationById(int id)
            {
                return await _reservationRepository.GetReservationById(id);
            }

            public async Task AddReservation(Reservation reservation)
            {
                await _reservationRepository.AddReservation(reservation);
            }

            public async Task UpdateReservation(Reservation reservation)
            {
                await _reservationRepository.UpdateReservation(reservation);
            }

            public async Task DeleteReservation(int id)
            {
                await _reservationRepository.DeleteReservation(id);
            }
        }
 }



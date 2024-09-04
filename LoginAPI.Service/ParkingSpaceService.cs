using System;
using System.Collections.Generic;
using LoginAPI.Repository;
using LoginAPI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginAPI.Core;

namespace LoginAPI.Service
{
        public class ParkingSpaceService : IParkingSpaceService
        {
            private readonly IParkingSpaceRepository _parkingSpaceRepository;

            public ParkingSpaceService(IParkingSpaceRepository parkingSpaceRepository)
            {
                _parkingSpaceRepository = parkingSpaceRepository;
            }

            public async Task<IEnumerable<ParkingSpace>> GetAllParkingSpaces()
            {
                return await _parkingSpaceRepository.GetAllParkingSpaces();
            }

            public async Task<ParkingSpace> GetParkingSpaceById(int id)
            {
                return await _parkingSpaceRepository.GetParkingSpaceById(id);
            }

            public async Task AddParkingSpace(ParkingSpace parkingSpace)
            {
                await _parkingSpaceRepository.AddParkingSpace(parkingSpace);
            }

            public async Task UpdateParkingSpace(ParkingSpace parkingSpace)
            {
                await _parkingSpaceRepository.UpdateParkingSpace(parkingSpace);
            }

            public async Task DeleteParkingSpace(int id)
            {
                await _parkingSpaceRepository.DeleteParkingSpace(id);
            }
    }
  

}

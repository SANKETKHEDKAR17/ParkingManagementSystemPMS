using LoginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Service
{
   
        public interface IParkingSpaceService
        {
            Task<IEnumerable<ParkingSpace>> GetAllParkingSpaces();
            Task<ParkingSpace> GetParkingSpaceById(int id);
            Task AddParkingSpace(ParkingSpace parkingSpace);
            Task UpdateParkingSpace(ParkingSpace parkingSpace);
            Task DeleteParkingSpace(int id);
        }
    

}

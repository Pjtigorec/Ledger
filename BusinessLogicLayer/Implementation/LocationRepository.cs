using System.Collections.Generic;
using Common.Core;
using Common.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Implementation
{
    public class LocationRepository : ILocationRepository
    {
        IDataAccess _db;

        public LocationRepository(IDataAccess db)
        {
            _db = db;
        }

        public Building GetBuilding(int id)
        {
            return _db.Locations.GetBuilding(id);
        }

        public List<Building> GetBuildings()
        {
            return _db.Locations.GetBuildings();
        }

        public Floot GetFloot(int id)
        {
            return _db.Locations.GetFloot(id);
        }

        public List<Floot> GetFloots(int buildingId)
        {
            return _db.Locations.GetFloots(buildingId);
        }

        public Room GetRoom(int id)
        {
            return _db.Locations.GetRoom(id);
        }

        public int GetRoomId(string roomName)
        {
            return _db.Locations.GetRoomId(roomName);
        }

        public List<Room> GetRooms(int flootId)
        {
            return _db.Locations.GetRooms(flootId);
        }
    }
}

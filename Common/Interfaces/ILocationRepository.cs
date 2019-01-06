using Common.Core;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface ILocationRepository
    {
        Room GetRoom(int id);

        int GetRoomId(string roomName);

        List<Room> GetRooms(int flootId);

        Floot GetFloot(int id);

        List<Floot> GetFloots(int buildingId);

        Building GetBuilding(int id);

        List<Building> GetBuildings();
    }
}

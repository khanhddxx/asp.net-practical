﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetTripsByUserName(string username);

        Task<bool> SaveChangesAsync();

        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop stop, string username);

        Trip GetTripByName(string tripName);
        Trip GetUserTripByName(string tripName, string username);
    }
}
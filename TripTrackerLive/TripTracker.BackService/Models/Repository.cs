﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.BackService.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
        {
            new Trip
            {
                Id = 0,
                Name = "MVP Summit",
                StartDate = new DateTime(2019,3,5),
                EndDate = new DateTime(2019,3,8)
            },
            new Trip
            {
                Id = 1,
                Name = "DevInterSection Orlando 2018",
                StartDate = new DateTime(2019,3,25),
                EndDate = new DateTime(2019,3,27)
            },
            new Trip
            {
                Id = 2,
                Name = "Build 2019",
                StartDate = new DateTime(2019,5,7),
                EndDate = new DateTime(2019,5,9)
            }
        };

        public Trip Get(int id)
        {
            return MyTrips.First(t => t.Id == id);
        }
        public List<Trip> Get()
        {
            return MyTrips;
        }

        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }
        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            Add(tripToUpdate);
        }
        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}

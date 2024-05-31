using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GroupsApp.Mapper;
using GroupsApp.Data;
using GroupsApp.Models.MarketplacePosts;
using GroupsApp.Payloads.DTO;
using GroupsApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Hosting;
using GroupsApp.Models;
using GroupsApp.Payload.DTO;
using GroupsApp.Mapper;

namespace GroupsApp.Services
{
    public class EventService : IEventService
    {
        private readonly EventRepository _eventRepository;

        public Event CreateEvent(EventDTO eventDTO)
        {
            throw new NotImplementedException();
        }

    public void DeleteEventById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Event GetEventById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Event UpdateEvent(EventDTO eventDTO)
        {
            throw new NotImplementedException();
        }
    }
}

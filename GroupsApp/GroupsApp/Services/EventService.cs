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

        public void DeleteEventById(Guid id)
        {
            try
            {
                this._eventRepository.DeleteEventById(id);
            }
            catch (Exception error)
            {
                throw new Exception("Error deleting event", error);
            }
        }

        public List<Event> GetAllEvents()
        {
            return this._eventRepository.GetAllEvents();
        }

        public Event? GetEventById(Guid id)
        {
            return _eventRepository.GetEventById(id);
        }

        //TODO WHAT IS BELOW ( YOU NEED THE MAPPER )
        public Event CreateEvent(EventDTO eventDTO)
        {
            throw new NotImplementedException();
        }

        public Event UpdateEvent(EventDTO eventDTO)
        {
            throw new NotImplementedException();
        }
    }
}

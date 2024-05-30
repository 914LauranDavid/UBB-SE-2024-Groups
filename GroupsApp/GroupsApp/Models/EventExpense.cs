using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System;

namespace GroupsApp.Models
{
    public class EventExpense
    {
        private Guid eventExpenseId;
        private Guid eventId;
        private string expenseName;
        private float cost;

        [Key]
        public Guid EventExpenseId { get => eventExpenseId; set => eventExpenseId = value; }
        public Guid EventId { get => eventId; set => eventId = value; }
        public string ExpenseName { get => expenseName; set => expenseName = value; }
        public float Cost { get => cost; set => cost = value; }

        public Event Event { get; set; }

        public EventExpense(Guid eventExpenseId, Guid eventGUID, string expenseName, float cost)
        {
            this.eventExpenseId = eventExpenseId;
            this.eventId = eventGUID;
            this.expenseName = expenseName;
            this.cost = cost;
        }

        public EventExpense()
        {
            this.eventExpenseId = Guid.NewGuid();
            this.eventId = Guid.NewGuid();
            this.expenseName = Constants.EMPTY_STRING;
            this.cost = 0;
        }

        public EventExpense(Guid eventGUID, string expenseName, float cost)
        {
            this.eventExpenseId = Guid.NewGuid();
            this.eventId = eventGUID;
            this.expenseName = expenseName;
            this.cost = cost;
        }
    }
}

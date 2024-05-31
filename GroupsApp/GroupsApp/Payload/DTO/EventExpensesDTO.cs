using GroupsApp.Models;

namespace GroupsApp.Payload.DTO
{
    public class EventExpensesDTO
    {
        private Guid eventExpenseId;
        private Guid eventId;
        private string expenseName;
        private float cost;

        public Guid EventExpenseId { get => eventExpenseId; set => eventExpenseId = value; }
        public Guid EventGUID { get => eventId; set => eventId = value; }
        public string ExpenseName { get => expenseName; set => expenseName = value; }
        public float Cost { get => cost; set => cost = value; }
    }
}

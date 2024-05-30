using GroupsApp.Data;
using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public class EventExpenseRepository
    {
        private readonly GroupsAppContext _context;

        public EventExpenseRepository(GroupsAppContext context)
        {
            _context = context;
        }

        public EventExpense AddEventExpense(EventExpense eventExpense)
        {
            _context.EventExpenses.Add(eventExpense);
            _context.SaveChanges();
            return eventExpense;
        }

        public EventExpense? GetEventExpenseById(Guid id)
        {
            return _context.EventExpenses.Find(id);
        }

        public EventExpense UpdateEventExpense(EventExpense eventExpense)
        {
            EventExpense? foundEventExpense = _context.EventExpenses.Find(eventExpense.EventExpenseId);
            if (foundEventExpense == null)
            {
                throw new Exception("Event expense not found");
            }
            foundEventExpense.EventGUID = eventExpense.EventGUID;
            foundEventExpense.ExpenseName = eventExpense.ExpenseName;
            foundEventExpense.Cost = eventExpense.Cost;
            EventExpense updatedEventExpense = _context.EventExpenses.Update(foundEventExpense).Entity;
            _context.SaveChanges();
            return updatedEventExpense;
        }

        public void DeleteEventExpense(EventExpense eventExpense)
        {
            EventExpense? foundEventExpense = _context.EventExpenses.Find(eventExpense.EventExpenseId);
            if (foundEventExpense == null)
            {
                throw new Exception("Event expense not found");
            }
            _context.EventExpenses.Remove(foundEventExpense);
            _context.SaveChanges();
        }

        public List<EventExpense> GetAllEventExpenses()
        {
            return _context.EventExpenses.ToList();
        }
    }
}

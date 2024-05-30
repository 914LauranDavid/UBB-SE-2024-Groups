using GroupsApp.Models;

namespace GroupsApp.Repositories
{
    public interface IEventExpenseRepository
    {
        public EventExpense AddEventExpense(EventExpense eventExpense);
        public EventExpense UpdateEventExpense(EventExpense eventExpense);
        public EventExpense? GetEventExpenseById(Guid id);
        public List<EventExpense> GetAllEventExpenses();
    }
}

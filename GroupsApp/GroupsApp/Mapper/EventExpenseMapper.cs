using GroupsApp.Models;
using GroupsApp.Payload.DTO;

namespace GroupsApp.Mapper
{
    public class EventExpenseMapper
    {
        public static EventExpensesDTO EventExepenseToEventExpenseDTO(EventExpense eventExpense)
        {
            EventExpensesDTO eventExpensesDTO = new EventExpensesDTO();
            eventExpensesDTO.EventExpenseId = eventExpense.EventExpenseId;
            eventExpensesDTO.EventGUID = eventExpense.EventGUID;
            eventExpensesDTO.ExpenseName = eventExpense.ExpenseName;
            eventExpensesDTO.Cost = eventExpense.Cost;
            return eventExpensesDTO;
        }

        public static EventExpense EventExpenseDTOToEventExpense(EventExpensesDTO eventExpenseDTO) {
            return new EventExpense(eventExpenseDTO.EventExpenseId, eventExpenseDTO.EventGUID, eventExpenseDTO.ExpenseName, eventExpenseDTO.Cost);
        }
    }
}

using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IPollOptionRepository
    {
        PollOption AddPollOption(PollOption pollOption);
        PollOption? GetPollOptionById(Guid pollOptionId);
        PollOption UpdatePollOption(PollOption pollOption);
        void DeletePollOption(PollOption pollOption);
        List<PollOption> GetAllPollOptions();
    }
}
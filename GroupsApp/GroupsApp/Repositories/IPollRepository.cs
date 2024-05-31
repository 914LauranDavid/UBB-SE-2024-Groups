using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IPollRepository
    {
        Poll AddPoll(Poll poll);
        void DeletePoll(Poll poll);
        Poll? GetPollById(Guid id);
        List<Poll> GetAllPolls();
        Poll UpdatePoll(Poll poll);
    }
}
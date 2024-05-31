using GroupsApp.Models;
using System;
using System.Collections.Generic;

namespace GroupsApp.Repositories
{
    public interface IPollAnswerRepository
    {
        PollAnswer AddPollAnswer(PollAnswer pollAnswer);
        PollAnswer? GetPollAnswerByIds(Guid pollOptionId, Guid userId);
        void DeletePollAnswer(PollAnswer pollAnswer);
        List<PollAnswer> GetAllPollAnswers();
    }
}

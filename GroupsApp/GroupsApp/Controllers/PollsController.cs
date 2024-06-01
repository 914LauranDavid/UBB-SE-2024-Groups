using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Data;
using GroupsApp.Models;
using System.Text.RegularExpressions;

namespace GroupsApp.Controllers
{
    public class PollsController : Controller
    {
        private readonly GroupsAppContext _context;
        private readonly IPollService _pollService;

        public PollsController(GroupsAppContext context, IPollService pollService)
        {
            _context = context;
            _pollService = pollService;
        }


        // GET: Polls/GroupPolls/5
        public async Task<IActionResult> GroupPolls(Guid? groupId)
        {
            if (groupId == null)
            {
                return NotFound();
            }

            var pollsFromGroup = _pollService.GetGroupPolls((Guid)groupId);
            if (pollsFromGroup == null)
            {
                return NotFound();
            }

            return View(pollsFromGroup);
        }

        // GET: Polls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Polls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,Description,EndDate,IsPinned,IsVisible,IsMultipleChoice,IsAnonymous")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                poll.PollId = Guid.NewGuid();

                // add poll
                _pollService.AddNewPoll(PollMapper.MapPollToPollDTO(poll));

                return RedirectToAction(nameof(GroupPolls), new { groupId = poll.GroupId });

            }

            return View(poll);
        }

}

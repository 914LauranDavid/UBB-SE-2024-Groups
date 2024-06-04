using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupsApp.Data;
using GroupsApp.Models;
using GroupsApp.Services;
using GroupsApp.Mapper;
using Microsoft.AspNetCore.Authorization;

namespace GroupsApp.Controllers
{
    [Authorize]
    public class GroupPostsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;
        private Guid _currentGroupId = new Guid("a8fc999f-43fc-4370-a3ff-564998fe032d");  // TODO: NOT OK

        public GroupPostsController(IGroupService groupService, IUserService userService)
        {
            this._groupService = groupService;
            this._userService = userService;
            Console.WriteLine("Group Posts Controller constructor");
        }

        // GET: GroupPosts
        public async Task<IActionResult> Index()
        {
            //var groupsAppContext = _context.GroupPosts.Include(g => g.Author).Include(g => g.Group);
            //return View(await groupsAppContext.ToListAsync());
            var groupPosts = this._groupService.GetGroupPosts(_currentGroupId);
            return View(groupPosts);
        }

        // GET: GroupPosts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPost = this._groupService.GetGroupPostById(_currentGroupId, id.Value);
            if (groupPost == null)
            {
                return NotFound();
            }

            return View(GroupPostMapper.GroupPostDTOToGroupPost(groupPost));
        }

        // GET: GroupPosts/Create
        public IActionResult Create()
        {
            Console.WriteLine("GPC Create enter");
            ViewData["AuthorId"] = new SelectList(this._userService.GetUsers().Value, "UserId", "UserId");
            ViewData["GroupId"] = new SelectList(this._groupService.GetAllGroups(), "GroupId", "GroupId");
            Console.WriteLine("GPC Create exit");
            return View();
        }

        // POST: GroupPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupPostId,AuthorId,GroupId,Description,MediaContent,IsPinned,AdminOnly")] GroupPost groupPost)
        {
            groupPost.GroupPostId = Guid.NewGuid();
            groupPost.AuthorId = Guid.Parse("20084852-bf05-4972-9703-590310e3f309");
            groupPost.GroupId = _currentGroupId;
            this._groupService.AddGroupPost(GroupPostMapper.GroupPostToGroupPostDTO(groupPost));
            return RedirectToAction(nameof(Index));
        }

        // GET: GroupPosts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var groupPost = this._groupService.GetGroupPostById(_currentGroupId, id.Value);
            if (groupPost == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(this._userService.GetUsers().Value, "UserId", "UserId", groupPost.AuthorId);
            ViewData["GroupId"] = new SelectList(this._groupService.GetAllGroups(), "GroupId", "GroupId", groupPost.GroupId);
            return View(GroupPostMapper.GroupPostDTOToGroupPost(groupPost));
        }

        // POST: GroupPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GroupPostId,AuthorId,GroupId,Description,MediaContent,IsPinned,AdminOnly")] GroupPost groupPost)
        {
            if (id != groupPost.GroupPostId)
            {
                return NotFound();
            }
            
            try
            {
                this._groupService.UpdateGroupPost(GroupPostMapper.GroupPostToGroupPostDTO(groupPost));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupPostExists(groupPost.GroupPostId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: GroupPosts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPost = this._groupService.GetGroupPostById(_currentGroupId, id.Value);
            if (groupPost == null)
            {
                return NotFound();
            }

            return View(GroupPostMapper.GroupPostDTOToGroupPost(groupPost));
        }

        // POST: GroupPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var groupPost = this._groupService.GetGroupPostById(_currentGroupId, id);
            if (groupPost != null)
            {
                this._groupService.DeleteGroupPost(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool GroupPostExists(Guid id)
        {
            return this._groupService.GetGroupPostById(_currentGroupId, id) != null;
        }
    }
}

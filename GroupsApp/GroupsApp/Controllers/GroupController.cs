using GroupsApp.Mapper;
using GroupsApp.Models;
using GroupsApp.Models.MarketplacePosts;
using GroupsApp.Payload.DTO;
using GroupsApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GroupsApp.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }
        /*
        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupDTO groupDTO)
        {
            try
            {
                var createdGroup = groupService.CreateGroup(groupDTO);
                return CreatedAtAction(nameof(GetGroup), new { id = createdGroup.GroupId }, createdGroup);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Group>> UpdateGroup([FromBody] GroupDTO groupDTO)
        {
            try
            {
                var updatedGroup = groupService.UpdateGroup(groupDTO);
                return Ok(updatedGroup);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> DeleteGroup(Guid groupId)
        {
            try
            {
                groupService.DeleteGroup(groupId);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("members")]
        public async Task<ActionResult<Membership>> AddMemberToGroup([FromBody] MembershipDTO membershipDTO)
        {
            try
            {
                var addedMember = groupService.AddMemberToGroup(membershipDTO);
                return CreatedAtAction(nameof(IsUserInGroup), new { groupId = addedMember.GroupId, userId = addedMember.UserId }, addedMember);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("members/{groupId}/{userId}")]
        public async Task<IActionResult> RemoveMemberFromGroup(Guid groupId, Guid userId)
        {
            try
            {
                groupService.RemoveMemberFromGroup(groupId, userId);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("members")]
        public async Task<ActionResult<Membership>> UpdateMembership([FromBody] MembershipDTO membershipDTO)
        {
            try
            {
                var updatedMembership = groupService.UpdateMembership(membershipDTO);
                return Ok(updatedMembership);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("join-requests")]
        public async Task<ActionResult<JoinRequest>> AddNewRequestToJoinGroup([FromBody] JoinRequestDTO joinRequestDTO)
        {
            try
            {
                var joinRequest = groupService.AddNewRequestToJoinGroup(joinRequestDTO);
                return CreatedAtAction(nameof(GetRequestsToJoinFromGroup), new { groupId = joinRequest.GroupId }, joinRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("join-requests/accept")]
        public async Task<IActionResult> AcceptRequestToJoinGroup([FromBody] JoinRequestDTO joinRequestDTO)
        {
            try
            {
                groupService.AcceptRequestToJoinGroup(joinRequestDTO);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("join-requests/{joinRequestId}")]
        public async Task<IActionResult> RejectRequestToJoinGroup(Guid joinRequestId)
        {
            try
            {
                groupService.RejectRequestToJoinGroup(joinRequestId);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("{groupId}/posts")]
        public IActionResult CreateNewPostOnGroupChat(Guid groupId, [FromBody] GroupPostDTO groupPostDTO)
        {
            try
            {
                groupService.CreateNewPostOnGroupChat(groupId, groupPostDTO.GroupPostId, groupPostDTO.PostContent, groupPostDTO.PostImage);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{groupId}/posts")]
        public ActionResult<ICollection<MarketplacePost>> GetGroupPosts(Guid groupId)
        {
            try
            {
                var posts = groupService.GetGroupPosts(groupId);
                return Ok(posts);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{groupId}/members")]
        public ActionResult<List<User>> GetGroupMembers(Guid groupId)
        {
            try
            {
                var members = groupService.GetGroupMembers(groupId);
                return Ok(members);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{groupId}/members/{groupMemberId}")]
        public ActionResult<bool> IsUserInGroup(Guid groupId, Guid groupMemberId)
        {
            var isInGroup = groupService.IsUserInGroup(groupId, groupMemberId);
            return Ok(isInGroup);
        }

        [HttpGet("{groupId}/join-requests")]
        public ActionResult<List<JoinRequest>> GetRequestsToJoinFromGroup(Guid groupId)
        {
            try
            {
                var requests = groupService.GetRequestsToJoinFromGroup(groupId);
                return Ok(requests);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("user/{groupMemberId}/groups")]
        public ActionResult<List<Models.Group>> GetAllGroupsUserBelongsTo(Guid groupMemberId)
        {
            try
            {
                var groups = groupService.GetAllGroupsUserBelongsTo(groupMemberId);
                return Ok(groups);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{groupId}")]
        public async Task<ActionResult<Group>> GetGroup(Guid groupId)
        {
            try
            {
                var group = groupService.GetGroupById(groupId);
                return Ok(group);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /*[HttpGet]
        public IActionResult GetGroups()
        {
            var groups =  groupService.GetAllGroups();
            return View(groups);
        }*/

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var groups = groupService.GetAllGroupsNonDTO();
            return View(groups);
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = groupService.GetGroupById(id.Value);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(groupService.GetAllGroups(), "UserId", "UserId");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,OwnerId,GroupName,Description,CreatedDate,IsPublic,AllowanceOfPostage")] Group @group)
        {
            if (ModelState.IsValid)
            {
                @group.GroupId = Guid.NewGuid();
                groupService.CreateGroup(GroupMapper.GroupToGroupDTO(@group));
                return RedirectToAction(nameof(Index));
            }
            return View(@group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = groupService.GetGroupById(id.Value);
            if (@group == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(groupService.GetAllGroups(), "UserId", "UserId", @group.OwnerId);
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("GroupId,OwnerId,GroupName,Description,CreatedDate,IsPublic,AllowanceOfPostage")] Group @group)
        {
            if (id != @group.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    groupService.UpdateGroup(GroupMapper.GroupToGroupDTO(@group));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.GroupId))
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
            ViewData["OwnerId"] = new SelectList(groupService.GetAllGroups(), "UserId", "UserId", @group.OwnerId);
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = groupService.GetGroupById(id.Value);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var group = groupService.GetGroupById(id);
            if (group != null)
            {
                groupService.DeleteGroupPost(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(Guid id)
        {
            return groupService.GetGroupById(id) != null;
        }
    }
}

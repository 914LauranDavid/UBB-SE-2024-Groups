using GroupsApp.Models;
using GroupsApp.Models.MarketplacePosts;
using GroupsApp.Payload.DTO;
using GroupsApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupsApp.WPF_Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpPost]
        public async Task<ActionResult<Group>> CreateGroup([FromBody] GroupDTO groupDTO)
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

        [HttpGet]
        public async Task<ActionResult<List<GroupDTO>>> GetGroups()
        {
            return groupService.GetAllGroups();
        }
    }
}

namespace UI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    using System;
    using System.Threading.Tasks;

    using NLog;

    using Common;
    using static Common.Consts;

    using DAL;

    using Entities.DTOs;
    using Entities.Models;



    /// <summary>
    /// GroupsUser controller
    /// </summary>
    [Route("api/v1.0/[controller]/[action]/")]
    [ApiController]
    public class GroupUsersController:ControllerBase
    {
        /// <summary>
        /// context
        /// </summary>
        private static DataBaseContext Context { get; set; }

        /// <summary>
        /// User manager
        /// </summary>
        private readonly IGenericManager<GroupUsers, GroupUsersDTO> groupUsersManager;

        /// <summary>
        /// Logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// message
        /// </summary>
        private string message;

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="GroupUsersManager"></param>
        public GroupUsersController(DataBaseContext context, IGenericManager<GroupUsers, GroupUsersDTO> GroupUsersManager)
        {
            Context = context;
            groupUsersManager = GroupUsersManager;
        }

        /// <summary>
        /// Select all users of a group
        /// </summary>
        /// <param name="groupId">unique identifier for a group</param>
        /// <returns>ManagerResponse with result</returns>
        [HttpGet]
        [Route("{groupId}")]
        public async Task<ActionResult<ManagerResponse<GroupUsersDTO>>> Select(string groupId = null)
        {
            ManagerResponse<GroupUsersDTO> retVal;

            try
            {
                if (ModelState.IsValid)
                {
                    if (groupUsersManager.ValidateSelectById(groupId))
                    {
                        retVal = await groupUsersManager.SelectById(groupId, Context);

                        if (retVal.Object == null)
                        {
                            Logger.Warn("500", NOTFOUND);

                            return NotFound(groupId);
                        }
                    }
                    else
                    {
                        Logger.Warn("400", BAD_INPUT_PARAMETERS);

                        return BadRequest(groupId);
                    }
                }
                else
                {
                    Logger.Warn("400", BADREQUEST);

                    return BadRequest(groupId);
                }
            }
            catch (Exception e)
            {
                message = e.Message;

                Logger.Error("500", message);

                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return Ok(retVal);
        }

        /// <summary>
        /// Add a user to a group
        /// </summary>
        /// <param name="groupId">unique identifier for a group</param>
        /// <param name="user">user to add</param>
        /// <returns>ManagerResponse with result</returns>
        [HttpPost]
        [Route("{groupId}")]
        public async Task<ActionResult<ManagerResponse<GroupUsersDTO>>> Add(string groupId,[FromBody] GroupUsers user)
        {
            ManagerResponse<GroupUsersDTO> retVal;

            try
            {
                if (ModelState.IsValid)
                {
                    if (groupUsersManager.ValidateInsert(groupId))
                    {
                        retVal = await groupUsersManager.Insert(user, Context);

                        if (retVal.Object == null)
                        {
                            Logger.Warn("500", NOTFOUND);

                            return NotFound(groupId);
                        }
                    }
                    else
                    {
                        Logger.Warn("400", BAD_INPUT_PARAMETERS);

                        return BadRequest(groupId);
                    }
                }
                else
                {
                    Logger.Warn("400", BADREQUEST);

                    return BadRequest(groupId);
                }
            }
            catch (Exception e)
            {
                message = e.Message;

                Logger.Error("500", message);

                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return Ok(retVal);
        }

        /// <summary>
        /// remove a user of a group
        /// </summary>
        /// <param name="groupId">unique identifier</param>
        /// <param name="userId">user id for remove</param>
        /// <returns>ManagerResponse with result</returns>
        [HttpDelete]
        [Route("{groupId}/{userId}")]
        public async Task<ActionResult<ManagerResponse<UserGroupsDTO>>> Remove(string groupId, string userId)
        {
            ManagerResponse<GroupUsersDTO> retVal;

            try
            {
                if (ModelState.IsValid)
                {
                    if (groupUsersManager.ValidateDelete(groupId))
                    {
                        retVal = await groupUsersManager.Delete(userId, Context);

                        if (retVal.Object == null)
                        {
                            Logger.Warn("500", NOTFOUND);

                            return NotFound(groupId);
                        }
                    }
                    else
                    {
                        Logger.Warn("400", BAD_INPUT_PARAMETERS);

                        return BadRequest(groupId);
                    }
                }
                else
                {
                    Logger.Warn("400", BADREQUEST);

                    return BadRequest(groupId);
                }
            }
            catch (Exception e)
            {
                message = e.Message;

                Logger.Error("500", message);

                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return Ok(retVal);
        }
    }
}
namespace UI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    using System;
    using System.Threading.Tasks;

    using NLog;

    using Common;
    using static Common.Consts;

    using Entities.DTOs;
    using Entities.Models;
    using DAL;

    /// <summary>
    /// Users Controller
    /// </summary>
    [Route("api/v1.0/[controller]/[action]/")]
    [ApiController]
    [Authorize]

    public class UserGroupsController:ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private static DataBaseContext Context { get; set; }

        /// <summary>
        /// User manager
        /// </summary>
        private readonly IGenericManager<UserGroups, UserGroupsDTO> userGroupsManager;

        /// <summary>
        /// 
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        private string message;

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="UserGroupsManager"></param>
        public UserGroupsController(DataBaseContext context, IGenericManager<UserGroups, UserGroupsDTO> UserGroupsManager)
        {
            Context = context;
            userGroupsManager = UserGroupsManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<ManagerResponse<UserGroupsDTO>>> SelectByUserId(string userId = null)
        {
            ManagerResponse<UserGroupsDTO> retVal;

            try
            {
                if (ModelState.IsValid)
                {
                    if (userGroupsManager.ValidateSelectById(userId))
                    {
                        retVal = await userGroupsManager.SelectById(userId, Context);

                        if (retVal.Object == null)
                        {
                            Logger.Warn("500", NOTFOUND);

                            return NotFound(userId);
                        }
                    }
                    else
                    {
                        Logger.Warn("400", BAD_INPUT_PARAMETERS);

                        return BadRequest(userId);
                    }
                }
                else
                {
                    Logger.Warn("400", BADREQUEST);

                    return BadRequest(userId);
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

       

        [HttpPost]
        public async Task<ActionResult<ManagerResponse<UserGroupsDTO>>> Insert([FromBody] UserGroups userGroups)
        {
            return null;
        }

       

        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult<ManagerResponse<UserGroupsDTO>>> Delete(string id)
        {
            return null;
        }









    }
}

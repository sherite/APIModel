namespace UI.Controllers
{
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
    public class UsersController : ControllerBase
    {
        private static DataBaseContext Context { get; set; }

        /// <summary>
        /// User manager
        /// </summary>
        private readonly IGenericManager<User, UserDTO> userManager;

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="context">database context</param>
        /// <param name="UserManager">IGenericManager implementation</param>
        public UsersController(DataBaseContext context, IGenericManager<User, UserDTO> UserManager)
        {
            Context = context;
            userManager = UserManager;
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private string message;

        private ManagerResponse<UserDTO> retVal = new ManagerResponse<UserDTO>();

        /// <summary>
        /// Select.
        /// </summary>
        /// <param name="id">unique identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ManagerResponse<UserDTO>>> SelectById(string id = null)
        {
            ManagerResponse<UserDTO> retVal;

            try
            {
                if (ModelState.IsValid)
                {
                    retVal = await userManager.SelectById(id, Context);

                    if (retVal.Object == null)
                    {
                        message = NOTFOUND;
                        Logger.Warn("500", message);

                        return NotFound(id);
                    }
                }
                else
                {
                    message = BADREQUEST;
                    Logger.Warn("400", message);

                    return BadRequest(id);
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
        /// Select.
        /// </summary>
        /// <param name="parameters">parameters list</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ManagerResponse<UserDTO>>> SelectByFilter([FromBody] Parameters parameters = null)
        {
            ManagerResponse<UserDTO> retVal;

            try
            {
                if (ModelState.IsValid)
                {
                    var result = userManager.ValidateParams(parameters);

                    if ( result.ErrorsList.Count == 0)
                    {
                        retVal = await userManager.SelectByFilter(parameters, Context);

                        if (retVal.Object == null)
                        {
                            message = NOTFOUND;
                            Logger.Warn("500", message);

                            return NotFound(parameters);
                        }
                    }
                    else
                    {
                        message = NOTACCEPTABLE;
                        Logger.Warn("406", message);

                        return StatusCode(StatusCodes.Status406NotAcceptable, parameters);
                    }
                }
                else
                {
                    message = BADREQUEST;
                    Logger.Warn("400", message);

                    return BadRequest(parameters);
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
        /// Insert.
        /// </summary>
        /// <param name="element">element to insert</param>
        /// <returns>result of insertion</returns>
        [HttpPost]
        public async Task<ActionResult<ManagerResponse<UserDTO>>> Insert([FromBody] User element)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await userManager.ValidateInsert(element, Context);

                    if (result.ErrorsList.Count > 0)
                    {
                        result = await userManager.Insert(element, Context);

                        retVal.Object = result.Object;
                        retVal.ErrorsList = retVal.ErrorsList;
                    }
                    else
                    {
                        result.CorrelationId = retVal.CorrelationId;
                        return result;
                    }
                }
                else
                {
                    message = BADREQUEST;
                    Logger.Warn("400", message);

                    return BadRequest(element);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(retVal);
        }


        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="user">element to update</param>
        /// <returns>result of update</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ManagerResponse<UserDTO>>> Update(UserDTO user)
        {
            try
            {
                retVal = await userManager.Change(user, Context);
            }
            catch (Exception)
            {
                throw;
            }

            return retVal;
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">id element to delete</param>
        /// <returns>result of delete</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ManagerResponse<UserDTO>>> Delete(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    retVal = await userManager.Delete(id, Context);
                }
                else
                {
                    message = BADREQUEST;
                    Logger.Warn("400", message);

                    return BadRequest(id);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(retVal);
        }
    }
}
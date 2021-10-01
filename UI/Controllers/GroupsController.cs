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
    /// Groups Controller
    /// </summary>
    [Route("api/v1.0/[controller]/[action]/")]
    [ApiController]
    public class GroupsController:ControllerBase
    {
        private static DataBaseContext Context { get; set; }

        /// <summary>
        /// Group manager
        /// </summary>
        private readonly IGenericManager<Group, GroupDTO> groupManager;

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="context">database context</param>
        /// <param name="GroupManager">IGenericManager implementation</param>
        public GroupsController(DataBaseContext context, IGenericManager<Group, GroupDTO> GroupManager)
        {
            Context = context;
            
            groupManager = GroupManager;
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private string message;

        private ManagerResponse<GroupDTO> retVal = new ManagerResponse<GroupDTO>();

        /// <summary>
        /// Select.
        /// </summary>
        /// <param name="id">unique identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ManagerResponse<GroupDTO>>> SelectById(string id = null)
        {
            ManagerResponse<GroupDTO> retVal;

            try
            {
                if (ModelState.IsValid)
                {
                    retVal = await groupManager.SelectById(id, Context);

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
        public async Task<ActionResult<ManagerResponse<GroupDTO>>> SelectByFilter([FromBody] Parameters parameters = null)
        {
            ManagerResponse<GroupDTO> retVal;

            try
            {
                if (ModelState.IsValid)
                {
                    var result = groupManager.ValidateParams(parameters);

                    if (result.ErrorsList.Count == 0)
                    {
                        retVal = await groupManager.SelectByFilter(parameters, Context);

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
        public async Task<ActionResult<ManagerResponse<GroupDTO>>> Insert([FromBody] Group element)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await groupManager.ValidateInsert(element, Context);

                    if (result.ErrorsList.Count > 0)
                    {
                        result = await groupManager.Insert(element, Context);

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
        /// <param name="element">element to update</param>
        /// <returns>result of update</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ManagerResponse<GroupDTO>>> Update(GroupDTO element)
        {
            try
            {
                retVal = await groupManager.Change(element, Context);
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
        public async Task<ActionResult<ManagerResponse<GroupDTO>>> Delete(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    retVal = await groupManager.Delete(id, Context);
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
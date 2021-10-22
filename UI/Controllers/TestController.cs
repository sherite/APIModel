using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Common;
using Entities.Models;
using Entities.DTOs;

namespace UI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestController : ControllerBase, IControllersMethods<User, UserDTO>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IActionResult> Delete(string id = null)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<IActionResult> GetByFilter([FromBody] Parameters parameters = null)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IActionResult> GetById(string id = null)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<IActionResult> Insert([FromBody] User entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<IActionResult> Update(UserDTO entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
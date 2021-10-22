namespace Common
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public interface IControllersMethods<T1,T2>
    {
        public Task<IActionResult> GetById(string id = null);
        public Task<IActionResult> GetByFilter([FromBody] Parameters parameters = null);
        public Task<IActionResult> Insert([FromBody] T1 entity);
        public Task<IActionResult> Update(T2 entity);
        public Task<IActionResult> Delete(string id = null);
    }
}
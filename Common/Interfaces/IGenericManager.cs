using System.Threading.Tasks;

namespace Common
{
    public interface IGenericManager<T1,T2>
    {
        public Task<ManagerResponse<T2>> SelectById(string id, object context);
        public Task<ManagerResponse<T2>> SelectByFilter(Parameters filter, object context);
        public Task<ManagerResponse<T2>> Insert(T1 entity, object context);
        public Task<ManagerResponse<T2>> Change(T2 entity, object context);
        public Task<ManagerResponse<T2>> Delete(string id, object context);

        public bool ValidateSelectById(object element);
        public bool ValidateSelectByFilter(object element);
        public bool ValidateInsert(object element);
        public bool ValidateUpdate(object element);
        public bool ValidateDelete(object element);
    }
}
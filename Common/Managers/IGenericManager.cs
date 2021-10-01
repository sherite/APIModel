namespace Common
{
    using System.Threading.Tasks;


    public interface IGenericManager<T1,T2>
    {
        public Task<ManagerResponse<T2>> SelectById(string id, object context);
        public Task<ManagerResponse<T2>> SelectByFilter(Parameters filter, object context);
        public Task<ManagerResponse<T2>> Insert(T1 entity, object context);
        public Task<ManagerResponse<T2>> Change(string id, string change, object context);
        public Task<ManagerResponse<T2>> Delete(string id, object context);
        public Task<ManagerResponse<T2>> ValidateParams(Parameters parameters, object context);
        public Task<ManagerResponse<T2>> ValidateInsert(T1 element, object context);
    }
}
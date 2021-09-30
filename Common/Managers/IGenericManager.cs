namespace Common
{
    using System.Threading.Tasks;


    public interface IGenericManager<T1,T2>
    {
        public Task<ManagerResponse<T2>> SelectById(string id, object context);
        public Task<ManagerResponse<T2>> SelectByFilter(Parameters filter);
        public Task<ManagerResponse<T2>> Insert(T1 entity);
        public Task<ManagerResponse<T2>> Change(string id, string change);
        public Task<ManagerResponse<T2>> Delete(string id);
        public bool ValidateParams(Parameters parameters);
        public Task<ManagerResponse<T2>> ValidateInsert(T1 element);
    }
}
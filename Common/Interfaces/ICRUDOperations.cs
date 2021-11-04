namespace Common
{
    using System.Threading.Tasks;

    public interface ICRUDOperations<T1,T2>
    {
        public Task<ManagerResponse<T2>> SelectById(string id, object context);
        public Task<ManagerResponse<T2>> SelectByFilter(Parameters filter, object context);
        public Task<ManagerResponse<T2>> Insert(T1 entity, object context);
        public Task<ManagerResponse<T2>> Change(T2 entity, object context);
        public Task<ManagerResponse<T2>> Delete(string id, object context);

    }
}
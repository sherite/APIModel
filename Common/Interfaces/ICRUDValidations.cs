namespace Common
{
    public interface ICRUDValidations
    {
        public bool ValidateSelectById(object element);
        public bool ValidateSelectByFilter(object element);
        public bool ValidateInsert(object element);
        public bool ValidateUpdate(object element);
        public bool ValidateDelete(object element);
    }
}
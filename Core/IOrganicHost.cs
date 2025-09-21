namespace OrganicBeing.Core
{
    public interface IOrganicHost<T> : IOrganic
    {
        T Data { get; set; }
        void Absorb(T value);
    }
}
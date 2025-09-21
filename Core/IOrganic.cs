namespace OrganicBeing.Core
{
    public interface IOrganic
    {
        bool IsReady { get; set; }
        void Grow();
    }
}
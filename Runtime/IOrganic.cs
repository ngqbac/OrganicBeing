namespace OrganicBeing
{
    public interface IOrganic
    {
        bool IsReady { get; set; }
        void Grow();
    }
}
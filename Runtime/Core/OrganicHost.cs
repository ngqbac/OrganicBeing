namespace OrganicBeing.Core
{
    public abstract class OrganicHost<T> : OrganicObject, IOrganicHost<T>
    {
        private T _data;

        public T Data
        {
            get => _data;
            set => Absorb(value);
        }

        public void Absorb(T data) => WhenReady(() =>
        {
            _data = data;
            OnAbsorb();
        });

        protected abstract void OnAbsorb();
    }
}
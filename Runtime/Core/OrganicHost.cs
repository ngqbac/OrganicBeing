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

        public void Absorb(T value) => WhenReady(() =>
        {
            _data = value;
            OnAbsorb();
        });

        protected abstract void OnAbsorb();
    }
}
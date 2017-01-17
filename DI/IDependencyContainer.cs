namespace DI
{
    public interface IDependencyContainer
    {
        void Register<T, I>();
        void Register<T, I>(string key);

        T Resolve<T>();
    }
}
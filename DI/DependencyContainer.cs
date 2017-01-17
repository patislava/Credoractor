using System;
using System.Threading;
using Autofac;

namespace DI
{
    public class DependencyContainer : IDependencyContainer
    {
        private static Lazy<DependencyContainer> _instance = new Lazy<DependencyContainer>(() => new DependencyContainer(), 
            LazyThreadSafetyMode.ExecutionAndPublication);

        public static DependencyContainer Instance
        {
            get { return _instance.Value; }
        }

        private ContainerBuilder _builder;
        private IContainer _container;

        private DependencyContainer()
        {
          _builder = new ContainerBuilder();
        }

        public void Register<T, I>()
        {
            RemoveContainer();

            _builder.RegisterType<I>().As<T>();
        }

        public void Register<T, I>(string key)
        {
            RemoveContainer();

            _builder.RegisterType<I>().Keyed<T>(key);
        }

        public T Resolve<T>()
        {
            if (_container == null)
            {
                _container = _builder.Build();
            }

            return _container.Resolve<T>();
        }

        private void RemoveContainer()
        {
                _container = null;
        }
    }
}

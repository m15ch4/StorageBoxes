namespace StorageBoxes {
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using ViewModels;
    using Interfaces;
    using Contracts;
    using Implementations;
    using Implementations.Tasks;
    using Contracts.Tasks;
    using Implementations.Users;
    using Contracts.Users;

    public class AppBootstrapper : BootstrapperBase {
        SimpleContainer container;

        public AppBootstrapper() {
            Initialize();
        }

        protected override void Configure() {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();

            container.PerRequest<IShell, ShellViewModel>();
            container.PerRequest<IOption, OptionViewModel>();
            container.PerRequest<ICount, CountViewModel>();

            container.PerRequest<IProductService, ProductService>();
            container.PerRequest<IOptionService, OptionService>();
            container.PerRequest<IOptionValueService, OptionValueService>();
            container.PerRequest<ICategoryService, CategoryService>();
            container.PerRequest<IProductSKUService, ProductSKUService>();
            container.PerRequest<ISKUValueService, SKUValueService>();
            container.PerRequest<IBoxService, BoxService>();
            container.PerRequest<ITaskTypeService, TaskTypeService>();
            container.PerRequest<ITaskStatusService, TaskStatusService>();
            container.PerRequest<ITaskService, TaskService>();
            container.PerRequest<IUserService, UserService>();
            container.PerRequest<IRoleService, RoleService>();
        }

        protected override object GetInstance(Type service, string key) {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service) {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance) {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e) {
            DisplayRootViewFor<IShell>();
        }
    }
}
﻿using Autofac;
using Data.Sources.LocalStorage.Sqlite;
using Kanban.Desktop.LocalBase.DataBaseSelector.Model;
using Kanban.Desktop.LocalBase.DataBaseSelector.View;
using Kanban.Desktop.LocalBase.DataBaseSelector.ViewModel;
using Kanban.Desktop.LocalBase.Issues.Model;
using Kanban.Desktop.LocalBase.Issues.View;
using Kanban.Desktop.LocalBase.Issues.ViewModel;
using Kanban.Desktop.LocalBase.LocalBoard.Model;
using Kanban.Desktop.LocalBase.LocalBoard.View;
using Kanban.Desktop.LocalBase.LocalBoard.ViewModel;
using Ui.Wpf.Common;

namespace Kanban.Desktop.LocalBase
{
    public class Bootstrapper : IBootstraper
    {
        public IShell Init()
        {
            var container = ConfigureContainer();
            var shell = container.Resolve<IShell>();
            shell.Container = container;
            return shell;
        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Shell>()
                .As<IShell>()
                .SingleInstance();

            builder
                .RegisterType<MainWindow>()
                .As<IDockWindow>();

            builder
                .RegisterType<SqliteLocalRepository>();

            builder.RegisterType<SqliteSettings>()
                .As<IDataBaseSettings>()
                .SingleInstance();

            //TODO: Modules discovering?
            ConfigureView<StartupModel, StartupViewModel, StartupView>(builder);
            ConfigureView<BoardModel, BoardViewModel, BoardView>(builder);
            ConfigureView<IssueModel, IssueViewModel, IssueView>(builder);

            return builder.Build();
        }

        private static void ConfigureView<TModel, TViewModel, TView>(ContainerBuilder builder)
        {
            builder.RegisterType<TModel>();
            builder.RegisterType<TViewModel>();
            builder.RegisterType<TView>();
        }
    }
}

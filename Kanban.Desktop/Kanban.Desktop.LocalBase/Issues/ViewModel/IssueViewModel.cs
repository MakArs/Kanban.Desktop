﻿using System;
using System.Reactive.Linq;
using AutoMapper;
using Data.Entities.Common.LocalBase;
using Kanban.Desktop.LocalBase.Issues.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Ui.Wpf.Common;
using Ui.Wpf.Common.ViewModels;

namespace Kanban.Desktop.LocalBase.Issues.ViewModel
{
    public class IssueViewModel : ViewModelBase, IIssueViewModel
    {
        private readonly IMapper mapper;
        private readonly IIssueModel model;

        public  int Id { get; set; }
        public  DateTime Created { get; set; }

        public ReactiveList<RowInfo> AwailableRows { get; set; } = new ReactiveList<RowInfo>();
        public ReactiveList<ColumnInfo> AwailableColumns { get; set; } = new ReactiveList<ColumnInfo>();
        [Reactive] public string     Head   { get; set; }
        [Reactive] public string     Body   { get; set; }
        [Reactive] public RowInfo    Row    { get; set; }
        [Reactive] public ColumnInfo Column { get; set; }
        [Reactive] public string     Color  { get; set; }
        public ReactiveCommand CancelCommand { get; set; }
        public ReactiveCommand SaveCommand { get; set; }
    
        public IssueViewModel(IIssueModel model)
        {
            this.model = model;
            mapper     = CreateMapper();

            SaveCommand=ReactiveCommand.CreateFromTask(async _ =>
            {
                var editedIssue = new LocalIssue();

                mapper.Map(this, editedIssue);

                await model.SaveIssueAsync(editedIssue);
            });

            CancelCommand=ReactiveCommand.Create(Close);
        }


        public void Initialize(ViewRequest viewRequest)
        {
            var issueId = (viewRequest as IssueViewRequest)?.IssueId;
             
            Observable.FromAsync(() => model.LoadOrCreateAsync(issueId))
                .ObserveOnDispatcher()
                .Subscribe(issue =>
                    mapper.Map(issue,this));

            Observable.FromAsync(() => model.GetRows())
                .ObserveOnDispatcher()
                .Subscribe(rows =>
                    AwailableRows.PublishCollection(rows));

            Observable.FromAsync(() => model.GetColumns())
                .ObserveOnDispatcher()
                .Subscribe(columns =>
                    AwailableColumns.PublishCollection(columns));

            Title = $"Редактирование задачи {Head}";
        }

        private IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
                cfg.AddProfile(typeof(MapperProfileSqliteRepos)));

            return mapperConfig.CreateMapper();
        }

        private class MapperProfileSqliteRepos : Profile
        {
            public MapperProfileSqliteRepos()
            {
                CreateMap<LocalIssue, IssueViewModel>();

                CreateMap<IssueViewModel, LocalIssue>();
            }
        }

    }
}
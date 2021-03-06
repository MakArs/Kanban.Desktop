﻿using Data.Entities.Common.IssuesBoard;

namespace Kanban.Desktop.KanbanBoard.Model
{
    public interface IKanbanBoardModel
    {
        KanbanConfiguration Configuration { get; set; }
        
        void GetConfiguration(string configurationName);
        
        KanbanData LoadData(Filters filters);

        FiltersData LoadFiltersData();
    }
}
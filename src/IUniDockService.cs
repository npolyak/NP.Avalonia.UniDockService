using System;
using System.Collections.ObjectModel;

namespace NP.Ava.UniDockService
{
    public interface IUniDockService
    {
        public event Action<DockItemViewModelBase> DockItemAddedEvent;

        public event Action<DockItemViewModelBase> DockItemRemovedEvent;

        public event Action<DockItemViewModelBase> DockItemSelectionChangedEvent;

        ObservableCollection<DockItemViewModelBase> DockItemsViewModels { get; set; }

        void SaveToFile(string filePath);
        void SaveDockManagerParamsToStream(Stream stream);

        void RestoreFromFile(string filePath,
                             bool restorePredefinedWindowsPositionParams = false);
        void RestoreDockManagerParamsFromStream(Stream stream,
                                                bool restorePredefinedWindowsPositionParams = false);

        void SaveViewModelsToFile(string filePath);

        void SaveViewModelsToStream(Stream stream);

        void RestoreViewModelsFromFile(string filePath, params Type[] extraTypes);

        void RestoreViewModelsFromStream(Stream stream, params Type[] extraTypes);

        DockObjectInfo? GetParentGroupInfo(string? dockId);

        DockObjectInfo? GetGroupByDockId(string? dockId);
    }
}

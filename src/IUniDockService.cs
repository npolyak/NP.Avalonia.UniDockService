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

        public string? LayoutName { get; set; }

        public string? TabbedDockControlClasses { get; set; }

        public string? DefaultTabItemsClasses { get; set; }

        public bool DragDropWithinSingleWindow { get; set; }

        public IUniDockService CreateChildService();

        void SaveToFile(string filePath);
        void SaveDockManagerParamsToStream(Stream stream);

        void RestoreFromFile(string filePath,
                             bool restorePredefinedWindowsPositionParams = false);
        void RestoreDockManagerParamsFromStream(Stream stream,
                                                bool restorePredefinedWindowsPositionParams = false);

        void SaveViewModelsToFile(string filePath, params Type[] extraTypes);

        void SaveViewModelsToStream(Stream stream, params Type[] extraTypes);

        void AddExternalVmType(Type externalVmType);

        void AddExternalVmTypes(params Type[] externalVmTypes);

        string SaveDockManagerParamsToStr();

        void RestoreViewModelsFromFile(string filePath, params Type[] extraTypes);

        void RestoreViewModelsFromStream(Stream stream, params Type[] extraTypes);

        DockObjectInfo? GetParentGroupInfo(string? dockId);

        DockObjectInfo? GetGroupByDockId(string? dockId);
    }
}

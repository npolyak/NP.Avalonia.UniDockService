using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NP.Ava.UniDockService
{
    public interface IUniDockService : INotifyPropertyChanged
    {
        public event Action<DockItemViewModelBase> DockItemAddedEvent;

        // this works for only for View Model based events.
        public event Action<DockItemViewModelBase> DockItemRemovedEvent;

        public event Action<DockItemViewModelBase> DockItemSelectionChangedEvent;

        ObservableCollection<DockItemViewModelBase> DockItemsViewModels { get; set; }

        public List<string> DockItemTypes { get; }

        public event Action<object> PredefinedDataContextAddedEvent;
        public event Action<object> PredefinedDataContextRemovedEvent;

        public string? LayoutName { get; set; }
        public string? TabbedDockControlClasses { get; set; }

        public string? DefaultTabItemsClasses { get; set; }

        public bool DragDropWithinSingleWindow { get; set; }

        public IUniDockService CreateChildService(string? childLayoutName, string? tabDockControlClasses = null);

        bool LayoutExists { get; }

        void ClearFolder();

        void SaveToFile(string filePath);
        void SaveDockManagerParamsToStream(Stream stream);

        void SaveLayout(string? baseFolder = null);
        
        void RestoreFromFile(string filePath,
                             bool restorePredefinedWindowsPositionParams = false);
        void RestoreDockManagerParamsFromStream(Stream stream,
                                                bool restorePredefinedWindowsPositionParams = false);
        
        void RestoreLayout(string? baseFolder = null);

        void RestoreDefaultLayout();

        void SaveViewModelsToFile(string filePath, params Type[] extraTypes);

        void SaveViewModelsToStream(Stream stream, params Type[] extraTypes);

        string SaveDockManagerParamsToStr();

        string SaveViewModelsToStr();

        (string layoutStr, string vmStr) SaveLayoutToStr();

        void SetRestorationStrs(string? dockParamsStr, string? vmParamsStr);

        void AddExtraVmType(Type externalVmType);

        void AddExtraVmTypes(params Type[] externalVmTypes);

        void AddExtraChildVmType(Type extraChildVmType);

        void AddExtraChildVmTypes(params Type[] extraChildVmTypes);

        void RestoreViewModelsFromFile(string filePath, params Type[] extraTypes);

        void RestoreViewModelsFromStream(Stream stream, params Type[] extraTypes);

        void RestoreFromStr(string str, bool restorePredefinedWindowsPositionParams = false);
        void RestoreLayoutFromStrs(string layoutStr, string vmStr);

        DockObjectInfo? GetParentGroupInfo(string? dockId);

        DockObjectInfo? GetGroupByDockId(string? dockId);

        object? GetRootGroup();

        string GetUniqueLayoutName();
    }
}

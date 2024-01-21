using NP.Utilities;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NP.Ava.UniDockService
{
    public interface IDockItemViewModel
    {
        bool IsDockVisible { get; set; }

        string? DockId { get; }

        string? DefaultDockGroupId { get; }

        string? GroupOnlyById { get; }

        double DefaultDockOrderInGroup { get; }

        bool IsSelected { get; set; }

        bool IsActive { get; set; }

        bool CanFloat { get; }

        bool CanClose { get; }

        bool IsPredefined { get; }

        object? Header { get; }

        string? HeaderContentTemplateResourceKey { get; }

        object? Content { get; }

        string? ContentTemplateResourceKey { get; }
    }

    public class DockItemViewModelBase : VMBase, IDockItemViewModel
    {
        public event Action<IDockItemViewModel>? RemovedEvent;

        #region IsDockVisible Property
        private bool _isDockVisible = true;
        [XmlAttribute]
        public bool IsDockVisible
        {
            get
            {
                return this._isDockVisible;
            }
            set
            {
                if (this._isDockVisible == value)
                {
                    return;
                }

                this._isDockVisible = value;
                this.OnPropertyChanged(nameof(IsDockVisible));
            }
        }
        #endregion IsDockVisible Property

        [XmlAttribute]
        public string? DockId { get; set; }
        
        [XmlAttribute]
        public string? DefaultDockGroupId { get; set; }

        [XmlAttribute]
        public string? GroupOnlyById { get; set; }

        [XmlAttribute]
        public double DefaultDockOrderInGroup { get; set; } = default;

        #region IsSelected Property
        private bool _isSelected = default;
        [XmlIgnore]
        public bool IsSelected
        {
            get
            {
                return this._isSelected;
            }
            set
            {
                if (this._isSelected == value)
                {
                    return;
                }

                this._isSelected = value;
                this.OnPropertyChanged(nameof(IsSelected));
            }
        }
        #endregion IsSelected Property

        #region IsActive Property
        private bool _isActive = default;
        [XmlIgnore]
        public bool IsActive
        {
            get
            {
                return this._isActive;
            }
            set
            {
                if (this._isActive == value)
                {
                    return;
                }

                this._isActive = value;
                this.OnPropertyChanged(nameof(IsActive));
            }
        }
        #endregion IsActive Property


        #region CanFloat Property
        private bool _canFloat = true;
        [XmlAttribute]
        public bool CanFloat
        {
            get
            {
                return this._canFloat;
            }
            set
            {
                if (this._canFloat == value)
                {
                    return;
                }

                this._canFloat = value;
                this.OnPropertyChanged(nameof(CanFloat));
            }
        }
        #endregion CanFloat Property


        #region CanClose Property
        private bool _canClose = true;
        [XmlAttribute]
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                if (this._canClose == value)
                {
                    return;
                }

                this._canClose = value;
                this.OnPropertyChanged(nameof(CanClose));
            }
        }
        #endregion CanClose Property


        [XmlAttribute]
        public bool IsPredefined { get; set; } = false;


        #region Header Property
        private object? _header;
        [XmlIgnore]
        public virtual object? Header
        {
            get
            {
                return this._header;
            }
            set
            {
                if (this._header == value)
                {
                    return;
                }

                this._header = value;
                this.OnPropertyChanged(nameof(Header));
            }
        }
        #endregion Header Property


        #region HeaderContentTemplateResourceKey Property
        [XmlAttribute]
        public string? HeaderContentTemplateResourceKey
        {
            get;
            set;
        }
        #endregion HeaderContentTemplateResourceKey Property


        #region Content Property
        [XmlIgnore]
        private object? _content;
        public virtual object? Content
        {
            get
            {
                return this._content;
            }
            set
            {
                if (this._content == value)
                {
                    return;
                }

                this._content = value;
                this.OnPropertyChanged(nameof(Content));
            }
        }
        #endregion Content Property

        #region ContentTemplateResourceKey Property
        [XmlAttribute]
        public string? ContentTemplateResourceKey
        {
            get;
            set;
        }
        #endregion ContentTemplateResourceKey Property

        public void MakeActive()
        {
            IsActive = true;
        }

        public void Select()
        {
            IsSelected = true;
        }
    }

    public class DockItemViewModel<TViewModel> : DockItemViewModelBase
        where TViewModel : class
    {
        #region TheVM Property
        private TViewModel? _vm;
        [XmlElement]
        public TViewModel? TheVM
        {
            get
            {
                return this._vm;
            }
            set
            {
                if (this._vm == value)
                {
                    return;
                }

                this._vm = value;
                this.OnPropertyChanged(nameof(TheVM));
            }
        }
        #endregion TheVM Property

        [XmlIgnore]
        public override object? Header
        {
            get => TheVM;
            set
            {

            }
        }

        [XmlIgnore]
        public override object? Content
        {
            get => TheVM;
            set
            {

            }
        }
    }
}

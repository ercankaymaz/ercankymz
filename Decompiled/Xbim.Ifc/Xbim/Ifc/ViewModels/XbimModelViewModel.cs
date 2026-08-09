using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Federation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc.ViewModels;

[DebuggerDisplay("ModelVM: {Name}: {Children}")]
public class XbimModelViewModel : IXbimViewModel, INotifyPropertyChanged
{
	private readonly IModel _model;

	private readonly IIfcProject _project;

	private bool _isSelected;

	private bool _isExpanded;

	private ObservableCollection<IXbimViewModel> _children;

	public IXbimViewModel CreatingParent { get; set; }

	public string Name
	{
		get
		{
			if (_project.Name != (IfcLabel?)(IfcLabel)string.Empty)
			{
				IfcLabel? name = _project.Name;
				if (!name.HasValue)
				{
					return null;
				}
				return name.GetValueOrDefault();
			}
			return "Unnamed project";
		}
	}

	public IEnumerable<IXbimViewModel> Children
	{
		get
		{
			if (_children == null)
			{
				_children = new ObservableCollection<IXbimViewModel>();
				foreach (IIfcSpatialStructureElement spatialStructuralElement in _project.GetSpatialStructuralElements())
				{
					_children.Add(new SpatialViewModel(spatialStructuralElement, this));
				}
				if (!(_model is IFederatedModel federatedModel))
				{
					return _children;
				}
				foreach (IReferencedModel referencedModel in federatedModel.ReferencedModels)
				{
					_children.Add(new XbimRefModelViewModel(referencedModel, this));
				}
			}
			return _children;
		}
	}

	public bool HasItems => Children.Any();

	public int EntityLabel => _project.EntityLabel;

	public IPersistEntity Entity => _project;

	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			_isSelected = value;
			NotifyPropertyChanged("IsSelected");
		}
	}

	public bool IsExpanded
	{
		get
		{
			return _isExpanded;
		}
		set
		{
			_isExpanded = value;
			NotifyPropertyChanged("IsExpanded");
		}
	}

	public IModel Model => _model;

	[field: NonSerialized]
	private event PropertyChangedEventHandler PropertyChanged;

	event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
	{
		add
		{
			PropertyChanged += value;
		}
		remove
		{
			PropertyChanged -= value;
		}
	}

	public XbimModelViewModel(IIfcProject project, IXbimViewModel parent)
	{
		_model = project.Model;
		_project = project;
		CreatingParent = parent;
		_ = Children;
	}

	private void NotifyPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public void AddRefModel(XbimRefModelViewModel xbimModelViewModel)
	{
		_children.Add(xbimModelViewModel);
		NotifyPropertyChanged("Children");
	}

	public void RemoveRefModel(XbimRefModelViewModel xbimModelViewModel)
	{
		_children.Remove(xbimModelViewModel);
		NotifyPropertyChanged("Children");
	}
}

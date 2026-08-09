using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.ViewModels;

[DebuggerDisplay("ContainedElementsVM: {Name}: {Children}")]
public class ContainedElementsViewModel : IXbimViewModel, INotifyPropertyChanged
{
	private readonly IModel _model;

	private readonly string _type;

	private readonly IEnumerable<IIfcProduct> _childProducts;

	private readonly IIfcSpatialStructureElement _spatialContainer;

	private bool _isSelected;

	private bool _isExpanded;

	private List<IXbimViewModel> _children;

	public IXbimViewModel CreatingParent { get; set; }

	public string Name => _type;

	public IEnumerable<IXbimViewModel> Children
	{
		get
		{
			if (_children == null)
			{
				_children = new List<IXbimViewModel>();
				foreach (IIfcProduct item in _childProducts.OrderBy((IIfcProduct p) => p.Name?.ToString()))
				{
					_children.Add(new IfcProductModelView(item, this));
				}
			}
			return _children;
		}
	}

	public bool HasItems => Children.Any();

	public int EntityLabel => _spatialContainer.EntityLabel;

	public IPersistEntity Entity => _spatialContainer;

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

	public ContainedElementsViewModel(IIfcSpatialStructureElement spatialElem, string type, IEnumerable<IIfcProduct> children, IXbimViewModel parent)
	{
		_spatialContainer = spatialElem;
		_type = type;
		_childProducts = children;
		_model = spatialElem.Model;
		CreatingParent = parent;
	}

	private void NotifyPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

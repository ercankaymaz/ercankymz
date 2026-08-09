using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc.ViewModels;

[DebuggerDisplay("ProductVM: {Name}: {Children}")]
public class IfcProductModelView : IXbimViewModel, INotifyPropertyChanged
{
	private readonly IIfcProduct _product;

	private bool _isSelected;

	private bool _isExpanded;

	private List<IXbimViewModel> _children;

	public IXbimViewModel CreatingParent { get; set; }

	public IEnumerable<IXbimViewModel> Children
	{
		get
		{
			if (_children != null)
			{
				return _children;
			}
			_children = new List<IXbimViewModel>();
			List<IIfcRelAggregates> list = _product.IsDecomposedBy.ToList();
			if (!list.Any())
			{
				return _children;
			}
			foreach (IIfcRelAggregates item in list)
			{
				foreach (IIfcProduct item2 in from p in item.RelatedObjects.OfType<IIfcProduct>()
					orderby p.Name?.ToString()
					select p)
				{
					_children.Add(new IfcProductModelView(item2, this));
				}
			}
			return _children;
		}
	}

	public string Name
	{
		get
		{
			IfcLabel? name = _product.Name;
			if (!string.IsNullOrWhiteSpace(name.HasValue ? ((string)name.GetValueOrDefault()) : null))
			{
				return $"{_product.Name} - {_product.ExpressType.ExpressName.Substring(3)} #{_product.EntityLabel}";
			}
			return $"{_product.ExpressType.ExpressName.Substring(3)} #{_product.EntityLabel}";
		}
	}

	public bool HasItems => Children.Any();

	public int EntityLabel => _product.EntityLabel;

	public IPersistEntity Entity => _product;

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

	public IModel Model => _product.Model;

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

	public IfcProductModelView(IIfcProduct prod, IXbimViewModel parent)
	{
		CreatingParent = parent;
		_product = prod;
	}

	private void NotifyPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

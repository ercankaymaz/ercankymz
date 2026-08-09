using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc.ViewModels;

[DebuggerDisplay("GroupVM: {Name}: {Children}")]
public class GroupViewModel : IXbimViewModel, INotifyPropertyChanged
{
	private readonly IIfcGroup _group;

	private bool _isSelected;

	private bool _isExpanded;

	private List<IXbimViewModel> _children;

	public IXbimViewModel CreatingParent { get; set; }

	public IEnumerable<IXbimViewModel> Children
	{
		get
		{
			if (_children == null)
			{
				_children = new List<IXbimViewModel>();
				foreach (IIfcRelAssignsToGroup item in _group.IsGroupedBy)
				{
					foreach (IIfcProduct item2 in from p in item.RelatedObjects.OfType<IIfcProduct>()
						orderby p.Name?.ToString()
						select p)
					{
						_children.Add(new IfcProductModelView(item2, this));
					}
					foreach (IIfcGroup item3 in from p in item.RelatedObjects.OfType<IIfcGroup>()
						orderby p.Name?.ToString()
						select p)
					{
						_children.Add(new GroupViewModel(item3, this));
					}
				}
			}
			return _children;
		}
	}

	public string Name
	{
		get
		{
			IfcLabel? name = _group.Name;
			if (!string.IsNullOrWhiteSpace(name.HasValue ? ((string)name.GetValueOrDefault()) : null))
			{
				return $"{_group.Name} #{_group.EntityLabel}";
			}
			return $"{_group.ExpressType.ExpressName.Substring(3)} #{_group.EntityLabel}";
		}
	}

	public int EntityLabel => _group.EntityLabel;

	public IPersistEntity Entity => _group;

	public IModel Model => _group.Model;

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

	[field: NonSerialized]
	public event PropertyChangedEventHandler PropertyChanged;

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

	public GroupViewModel(IIfcGroup gr, IXbimViewModel parent)
	{
		_group = gr;
		CreatingParent = parent;
	}

	public override string ToString()
	{
		return $"{Name}: {_group.Description} ({_group.GetGroupedObjects<IIfcProduct>().Count()})";
	}

	private void NotifyPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

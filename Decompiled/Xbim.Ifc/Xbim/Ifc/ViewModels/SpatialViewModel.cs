using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc.ViewModels;

[DebuggerDisplay("SpatialVM: {Name}: {Children}")]
public class SpatialViewModel : IXbimViewModel, INotifyPropertyChanged
{
	private readonly IModel _model;

	private readonly IIfcObjectDefinition _spatialStructure;

	private bool _isSelected;

	private bool _isExpanded;

	private List<IXbimViewModel> _children;

	public IXbimViewModel CreatingParent { get; set; }

	public string Name
	{
		get
		{
			IfcLabel? name = _spatialStructure.Name;
			if (!string.IsNullOrWhiteSpace(name.HasValue ? ((string)name.GetValueOrDefault()) : null))
			{
				return $"{_spatialStructure.Name} #{_spatialStructure.EntityLabel}";
			}
			return $"{_spatialStructure.ExpressType.ExpressName.Substring(3)} #{_spatialStructure.EntityLabel}";
		}
	}

	public IEnumerable<IXbimViewModel> Children
	{
		get
		{
			if (_children != null)
			{
				return _children;
			}
			_children = new List<IXbimViewModel>();
			foreach (IIfcRelAggregates item in _spatialStructure.IsDecomposedBy)
			{
				foreach (IIfcSpatialStructureElement item2 in from p in item.RelatedObjects.OfType<IIfcSpatialStructureElement>()
					orderby p.Name?.ToString()
					select p)
				{
					_children.Add(new SpatialViewModel(item2, this));
				}
			}
			if (!(_spatialStructure is IIfcSpatialStructureElement ifcSpatialStructureElement))
			{
				return _children;
			}
			foreach (IGrouping<string, IIfcProduct> item3 in from p in ifcSpatialStructureElement.ContainsElements.SelectMany((IIfcRelContainedInSpatialStructure container) => container.RelatedElements).GroupBy(GetKey)
				orderby p.Key
				select p)
			{
				_children.Add(new ContainedElementsViewModel(ifcSpatialStructureElement, item3.Key, item3, this));
			}
			return _children;
		}
	}

	public bool HasItems => Children.Any();

	public int EntityLabel => _spatialStructure.EntityLabel;

	public IPersistEntity Entity => _spatialStructure;

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

	public SpatialViewModel(IIfcSpatialStructureElement spatialStructure, IXbimViewModel parent)
	{
		if (spatialStructure == null)
		{
			throw new ArgumentNullException("spatialStructure");
		}
		_model = spatialStructure.Model;
		_spatialStructure = spatialStructure;
		CreatingParent = parent;
	}

	public SpatialViewModel(IIfcProject project)
	{
		if (project == null)
		{
			throw new ArgumentNullException("project");
		}
		_model = project.Model;
		_spatialStructure = project;
	}

	private static string GetKey(IIfcProduct prod)
	{
		Type type = prod.IsTypedBy?.FirstOrDefault()?.RelatingType?.GetType();
		if (type == null)
		{
			return prod.GetType().Name.Replace("Ifc", "");
		}
		return type.Name.Replace("Ifc", "").Replace("Type", "").Replace("Style", "");
	}

	private void NotifyPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

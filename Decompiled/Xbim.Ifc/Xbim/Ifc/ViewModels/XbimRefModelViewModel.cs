using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Federation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.ViewModels;

[DebuggerDisplay("RefModelVM: {Name}: {Children}")]
public class XbimRefModelViewModel : IXbimViewModel, INotifyPropertyChanged
{
	private readonly IReferencedModel _refModel;

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
				IIfcProject ifcProject = _refModel.Model.Instances.FirstOrDefault<IIfcProject>();
				if (ifcProject != null)
				{
					foreach (IIfcSpatialStructureElement spatialStructuralElement in ifcProject.GetSpatialStructuralElements())
					{
						_children.Add(new SpatialViewModel(spatialStructuralElement, this));
					}
				}
			}
			return _children;
		}
	}

	public string Name => Path.GetFileNameWithoutExtension(_refModel.Name) + " [" + _refModel.Role + "]";

	public IReferencedModel RefModel => _refModel;

	public bool HasItems => Children.Any();

	public int EntityLabel => -1;

	public IPersistEntity Entity => null;

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

	public IModel Model => _refModel.Model;

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

	public XbimRefModelViewModel(IReferencedModel refModel, IXbimViewModel parent)
	{
		CreatingParent = parent;
		_refModel = refModel;
	}

	public override string ToString()
	{
		return Name;
	}

	private void NotifyPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

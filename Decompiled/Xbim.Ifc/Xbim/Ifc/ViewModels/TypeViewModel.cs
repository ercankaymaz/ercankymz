using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.ViewModels;

[DebuggerDisplay("TypeVM: {Name}: {Children}")]
public class TypeViewModel : IXbimViewModel, INotifyPropertyChanged
{
	private readonly IModel _model;

	private readonly Type _type;

	private bool _isSelected;

	private bool _isExpanded;

	private List<IXbimViewModel> _children;

	public IXbimViewModel CreatingParent { get; set; }

	public string Name => _type.Name.Substring(3);

	public IEnumerable<IXbimViewModel> Children
	{
		get
		{
			if (_children == null)
			{
				_children = new List<IXbimViewModel>();
				foreach (IIfcProduct item in from p in _model.Instances
					where p.GetType().IsAssignableFrom(_type)
					orderby p.Name?.ToString()
					select p)
				{
					_children.Add(new IfcProductModelView(item, this));
				}
			}
			return _children;
		}
	}

	public int EntityLabel => 0;

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

	public TypeViewModel(Type type, IModel model)
	{
		_type = type;
		_model = model;
	}

	private void NotifyPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

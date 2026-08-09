#define TRACE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
public abstract class LayoutElement : DependencyObject, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging
{
	[NonSerialized]
	private ILayoutContainer _parent;

	[NonSerialized]
	private ILayoutRoot _root;

	[XmlIgnore]
	public ILayoutContainer Parent
	{
		get
		{
			return _parent;
		}
		set
		{
			if (_parent != value)
			{
				ILayoutContainer parent = _parent;
				ILayoutRoot root = _root;
				RaisePropertyChanging("Parent");
				OnParentChanging(parent, value);
				_parent = value;
				OnParentChanged(parent, value);
				_root = Root;
				if (root != _root)
				{
					OnRootChanged(root, _root);
				}
				RaisePropertyChanged("Parent");
				if (Root is LayoutRoot layoutRoot)
				{
					layoutRoot.FireLayoutUpdated();
				}
			}
		}
	}

	public ILayoutRoot Root
	{
		get
		{
			ILayoutContainer parent = Parent;
			while (parent != null && !(parent is ILayoutRoot))
			{
				parent = parent.Parent;
			}
			return parent as ILayoutRoot;
		}
	}

	[field: NonSerialized]
	[field: XmlIgnore]
	public event PropertyChangedEventHandler PropertyChanged;

	[field: NonSerialized]
	[field: XmlIgnore]
	public event PropertyChangingEventHandler PropertyChanging;

	internal LayoutElement()
	{
	}

	public virtual void ConsoleDump(int tab)
	{
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine(((object)this).ToString());
	}

	protected virtual void OnParentChanging(ILayoutContainer oldValue, ILayoutContainer newValue)
	{
	}

	protected virtual void OnParentChanged(ILayoutContainer oldValue, ILayoutContainer newValue)
	{
	}

	protected virtual void OnRootChanged(ILayoutRoot oldRoot, ILayoutRoot newRoot)
	{
		if (oldRoot != null)
		{
			((LayoutRoot)oldRoot).OnLayoutElementRemoved(this);
		}
		if (newRoot != null)
		{
			((LayoutRoot)newRoot).OnLayoutElementAdded(this);
		}
	}

	protected virtual void RaisePropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	protected virtual void RaisePropertyChanging(string propertyName)
	{
		if (this.PropertyChanging != null)
		{
			this.PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
		}
	}
}

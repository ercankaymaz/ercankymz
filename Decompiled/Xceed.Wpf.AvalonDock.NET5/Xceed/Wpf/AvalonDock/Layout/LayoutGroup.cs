using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
public abstract class LayoutGroup<T> : LayoutGroupBase, ILayoutContainer, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging, ILayoutGroup, IXmlSerializable where T : class, ILayoutElement
{
	private ObservableCollection<T> _children = new ObservableCollection<T>();

	private bool _isVisible = true;

	public ObservableCollection<T> Children => _children;

	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		protected set
		{
			if (_isVisible != value)
			{
				RaisePropertyChanging("IsVisible");
				_isVisible = value;
				OnIsVisibleChanged();
				RaisePropertyChanged("IsVisible");
			}
		}
	}

	public int ChildrenCount => _children.Count;

	IEnumerable<ILayoutElement> ILayoutContainer.Children => _children.Cast<ILayoutElement>();

	internal LayoutGroup()
	{
		_children.CollectionChanged += _children_CollectionChanged;
	}

	protected override void OnParentChanged(ILayoutContainer oldValue, ILayoutContainer newValue)
	{
		base.OnParentChanged(oldValue, newValue);
		ComputeVisibility();
	}

	public void ComputeVisibility()
	{
		IsVisible = GetVisibility();
	}

	public void MoveChild(int oldIndex, int newIndex)
	{
		if (oldIndex != newIndex)
		{
			_children.Move(oldIndex, newIndex);
			ChildMoved(oldIndex, newIndex);
		}
	}

	public void RemoveChildAt(int childIndex)
	{
		_children.RemoveAt(childIndex);
	}

	public int IndexOfChild(ILayoutElement element)
	{
		return _children.Cast<ILayoutElement>().ToList().IndexOf(element);
	}

	public void InsertChildAt(int index, ILayoutElement element)
	{
		_children.Insert(index, (T)element);
	}

	public void RemoveChild(ILayoutElement element)
	{
		_children.Remove((T)element);
	}

	public void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement)
	{
		int num = _children.IndexOf((T)oldElement);
		if (num >= 0)
		{
			ReplaceChildAt(num, newElement);
		}
	}

	public void ReplaceChildAt(int index, ILayoutElement element)
	{
		if (index >= 0 && index < _children.Count)
		{
			_children[index] = (T)element;
		}
	}

	public XmlSchema GetSchema()
	{
		return null;
	}

	public virtual void ReadXml(XmlReader reader)
	{
		reader.MoveToContent();
		if (reader.IsEmptyElement)
		{
			reader.Read();
			ComputeVisibility();
			return;
		}
		string localName = reader.LocalName;
		reader.Read();
		while (!(reader.LocalName == localName) || reader.NodeType != XmlNodeType.EndElement)
		{
			if (reader.NodeType == XmlNodeType.Whitespace)
			{
				reader.Read();
				continue;
			}
			XmlSerializer xmlSerializer = null;
			if (reader.LocalName == "LayoutAnchorablePaneGroup")
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutAnchorablePaneGroup));
			}
			else if (reader.LocalName == "LayoutAnchorablePane")
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutAnchorablePane));
			}
			else if (reader.LocalName == "LayoutAnchorable")
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutAnchorable));
			}
			else if (reader.LocalName == "LayoutDocumentPaneGroup")
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutDocumentPaneGroup));
			}
			else if (reader.LocalName == "LayoutDocumentPane")
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutDocumentPane));
			}
			else if (reader.LocalName == "LayoutDocument")
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutDocument));
			}
			else if (reader.LocalName == "LayoutAnchorGroup")
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutAnchorGroup));
			}
			else if (reader.LocalName == "LayoutPanel")
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutPanel));
			}
			else
			{
				Type type = FindType(reader.LocalName);
				if (type == null)
				{
					throw new ArgumentException("AvalonDock.LayoutGroup doesn't know how to deserialize " + reader.LocalName);
				}
				xmlSerializer = new XmlSerializer(type);
			}
			Children.Add((T)xmlSerializer.Deserialize(reader));
		}
		reader.ReadEndElement();
	}

	public virtual void WriteXml(XmlWriter writer)
	{
		foreach (T child in Children)
		{
			new XmlSerializer(child.GetType()).Serialize(writer, child);
		}
	}

	protected virtual void OnIsVisibleChanged()
	{
		UpdateParentVisibility();
	}

	protected abstract bool GetVisibility();

	protected virtual void ChildMoved(int oldIndex, int newIndex)
	{
	}

	private void _children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if ((e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace) && e.OldItems != null)
		{
			foreach (LayoutElement oldItem in e.OldItems)
			{
				if (oldItem.Parent == this)
				{
					oldItem.Parent = null;
				}
			}
		}
		if ((e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace) && e.NewItems != null)
		{
			foreach (LayoutElement newItem in e.NewItems)
			{
				if (newItem.Parent != this)
				{
					if (newItem.Parent != null)
					{
						newItem.Parent.RemoveChild(newItem);
					}
					newItem.Parent = this;
				}
			}
		}
		ComputeVisibility();
		OnChildrenCollectionChanged();
		NotifyChildrenTreeChanged(ChildrenTreeChange.DirectChildrenChanged);
		RaisePropertyChanged("ChildrenCount");
	}

	private void UpdateParentVisibility()
	{
		if (base.Parent is ILayoutElementWithVisibility layoutElementWithVisibility)
		{
			layoutElementWithVisibility.ComputeVisibility();
		}
	}

	private Type FindType(string name)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			Type[] types = assemblies[i].GetTypes();
			foreach (Type type in types)
			{
				if (type.Name.Equals(name))
				{
					return type;
				}
			}
		}
		return null;
	}
}

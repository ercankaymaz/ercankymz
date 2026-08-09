using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
public abstract class LayoutFloatingWindow : LayoutElement, ILayoutContainer, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging, IXmlSerializable
{
	public abstract IEnumerable<ILayoutElement> Children { get; }

	public abstract int ChildrenCount { get; }

	public abstract bool IsValid { get; }

	public LayoutFloatingWindow()
	{
	}

	public abstract void RemoveChild(ILayoutElement element);

	public abstract void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement);

	public XmlSchema GetSchema()
	{
		return null;
	}

	public abstract void ReadXml(XmlReader reader);

	public virtual void WriteXml(XmlWriter writer)
	{
		foreach (ILayoutElement child in Children)
		{
			new XmlSerializer(child.GetType()).Serialize(writer, child);
		}
	}
}

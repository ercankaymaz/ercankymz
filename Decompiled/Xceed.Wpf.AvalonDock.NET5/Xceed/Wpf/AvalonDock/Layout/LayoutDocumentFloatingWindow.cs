#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
[ContentProperty("RootDocument")]
public class LayoutDocumentFloatingWindow : LayoutFloatingWindow
{
	private LayoutDocument _rootDocument;

	public LayoutDocument RootDocument
	{
		get
		{
			return _rootDocument;
		}
		set
		{
			if (_rootDocument != value)
			{
				RaisePropertyChanging("RootDocument");
				_rootDocument = value;
				if (_rootDocument != null)
				{
					_rootDocument.Parent = this;
				}
				RaisePropertyChanged("RootDocument");
				if (this.RootDocumentChanged != null)
				{
					this.RootDocumentChanged(this, EventArgs.Empty);
				}
			}
		}
	}

	public override IEnumerable<ILayoutElement> Children
	{
		get
		{
			if (RootDocument != null)
			{
				yield return RootDocument;
			}
		}
	}

	public override int ChildrenCount
	{
		get
		{
			if (RootDocument == null)
			{
				return 0;
			}
			return 1;
		}
	}

	public override bool IsValid => RootDocument != null;

	public event EventHandler RootDocumentChanged;

	public override void RemoveChild(ILayoutElement element)
	{
		RootDocument = null;
	}

	public override void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement)
	{
		RootDocument = newElement as LayoutDocument;
	}

	public override void ReadXml(XmlReader reader)
	{
		reader.MoveToContent();
		if (reader.IsEmptyElement)
		{
			reader.Read();
			return;
		}
		string localName = reader.LocalName;
		reader.Read();
		while (!reader.LocalName.Equals(localName) || reader.NodeType != XmlNodeType.EndElement)
		{
			if (reader.NodeType == XmlNodeType.Whitespace)
			{
				reader.Read();
				continue;
			}
			XmlSerializer xmlSerializer;
			if (reader.LocalName.Equals("LayoutDocument"))
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutDocument));
			}
			else
			{
				Type type = LayoutRoot.FindType(reader.LocalName);
				if (type == null)
				{
					throw new ArgumentException("AvalonDock.LayoutDocumentFloatingWindow doesn't know how to deserialize " + reader.LocalName);
				}
				xmlSerializer = new XmlSerializer(type);
			}
			RootDocument = (LayoutDocument)xmlSerializer.Deserialize(reader);
		}
		reader.ReadEndElement();
	}

	public override void ConsoleDump(int tab)
	{
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine("FloatingDocumentWindow()");
		RootDocument.ConsoleDump(tab + 1);
	}
}

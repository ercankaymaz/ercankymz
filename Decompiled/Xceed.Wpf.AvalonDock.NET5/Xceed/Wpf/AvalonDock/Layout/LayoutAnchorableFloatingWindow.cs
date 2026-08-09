#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
[ContentProperty("RootPanel")]
public class LayoutAnchorableFloatingWindow : LayoutFloatingWindow, ILayoutElementWithVisibility
{
	private LayoutAnchorablePaneGroup _rootPanel;

	[NonSerialized]
	private bool _isVisible = true;

	public bool IsSinglePane
	{
		get
		{
			if (RootPanel != null)
			{
				return (from p in RootPanel.Descendents().OfType<ILayoutAnchorablePane>()
					where p.IsVisible
					select p).Count() == 1;
			}
			return false;
		}
	}

	[XmlIgnore]
	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		private set
		{
			if (_isVisible != value)
			{
				RaisePropertyChanging("IsVisible");
				_isVisible = value;
				RaisePropertyChanged("IsVisible");
				if (this.IsVisibleChanged != null)
				{
					this.IsVisibleChanged(this, EventArgs.Empty);
				}
			}
		}
	}

	public LayoutAnchorablePaneGroup RootPanel
	{
		get
		{
			return _rootPanel;
		}
		set
		{
			if (_rootPanel != value)
			{
				RaisePropertyChanging("RootPanel");
				if (_rootPanel != null)
				{
					_rootPanel.ChildrenTreeChanged -= _rootPanel_ChildrenTreeChanged;
				}
				_rootPanel = value;
				if (_rootPanel != null)
				{
					_rootPanel.Parent = this;
				}
				if (_rootPanel != null)
				{
					_rootPanel.ChildrenTreeChanged += _rootPanel_ChildrenTreeChanged;
				}
				RaisePropertyChanged("RootPanel");
				RaisePropertyChanged("IsSinglePane");
				RaisePropertyChanged("SinglePane");
				RaisePropertyChanged("Children");
				RaisePropertyChanged("ChildrenCount");
				((ILayoutElementWithVisibility)this).ComputeVisibility();
			}
		}
	}

	public ILayoutAnchorablePane SinglePane
	{
		get
		{
			if (!IsSinglePane)
			{
				return null;
			}
			LayoutAnchorablePane layoutAnchorablePane = RootPanel.Descendents().OfType<LayoutAnchorablePane>().Single((LayoutAnchorablePane p) => p.IsVisible);
			layoutAnchorablePane.UpdateIsDirectlyHostedInFloatingWindow();
			return layoutAnchorablePane;
		}
	}

	public override IEnumerable<ILayoutElement> Children
	{
		get
		{
			if (ChildrenCount == 1)
			{
				yield return RootPanel;
			}
		}
	}

	public override int ChildrenCount
	{
		get
		{
			if (RootPanel == null)
			{
				return 0;
			}
			return 1;
		}
	}

	public override bool IsValid => RootPanel != null;

	public event EventHandler IsVisibleChanged;

	public override void RemoveChild(ILayoutElement element)
	{
		RootPanel = null;
	}

	public override void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement)
	{
		RootPanel = newElement as LayoutAnchorablePaneGroup;
	}

	public override void ReadXml(XmlReader reader)
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
		while (!reader.LocalName.Equals(localName) || reader.NodeType != XmlNodeType.EndElement)
		{
			if (reader.NodeType == XmlNodeType.Whitespace)
			{
				reader.Read();
				continue;
			}
			XmlSerializer xmlSerializer;
			if (reader.LocalName.Equals("LayoutAnchorablePaneGroup"))
			{
				xmlSerializer = new XmlSerializer(typeof(LayoutAnchorablePaneGroup));
			}
			else
			{
				Type type = LayoutRoot.FindType(reader.LocalName);
				if (type == null)
				{
					throw new ArgumentException("AvalonDock.LayoutAnchorableFloatingWindow doesn't know how to deserialize " + reader.LocalName);
				}
				xmlSerializer = new XmlSerializer(type);
			}
			RootPanel = (LayoutAnchorablePaneGroup)xmlSerializer.Deserialize(reader);
		}
		reader.ReadEndElement();
	}

	public override void ConsoleDump(int tab)
	{
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine("FloatingAnchorableWindow()");
		RootPanel.ConsoleDump(tab + 1);
	}

	private void _rootPanel_ChildrenTreeChanged(object sender, ChildrenTreeChangedEventArgs e)
	{
		RaisePropertyChanged("IsSinglePane");
		RaisePropertyChanged("SinglePane");
	}

	private void ComputeVisibility()
	{
		if (RootPanel != null)
		{
			IsVisible = RootPanel.IsVisible;
		}
		else
		{
			IsVisible = false;
		}
	}

	void ILayoutElementWithVisibility.ComputeVisibility()
	{
		ComputeVisibility();
	}
}

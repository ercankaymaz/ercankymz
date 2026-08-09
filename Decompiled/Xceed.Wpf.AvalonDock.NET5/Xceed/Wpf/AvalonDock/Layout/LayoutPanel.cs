#define TRACE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
[ContentProperty("Children")]
public class LayoutPanel : LayoutPositionableGroup<ILayoutPanelElement>, ILayoutPanelElement, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging, ILayoutOrientableGroup, ILayoutGroup, ILayoutContainer, ILayoutElementWithVisibility
{
	private Orientation _orientation;

	public Orientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			if (_orientation != value)
			{
				RaisePropertyChanging("Orientation");
				_orientation = value;
				RaisePropertyChanged("Orientation");
			}
		}
	}

	public LayoutPanel()
	{
	}

	public LayoutPanel(ILayoutPanelElement firstChild)
	{
		base.Children.Add(firstChild);
	}

	protected override bool GetVisibility()
	{
		return base.Children.Any((ILayoutPanelElement c) => c.IsVisible);
	}

	public override void WriteXml(XmlWriter writer)
	{
		writer.WriteAttributeString("Orientation", Orientation.ToString());
		base.WriteXml(writer);
	}

	public override void ReadXml(XmlReader reader)
	{
		if (reader.MoveToAttribute("Orientation"))
		{
			Orientation = (Orientation)Enum.Parse(typeof(Orientation), reader.Value, ignoreCase: true);
		}
		base.ReadXml(reader);
	}

	public override void ConsoleDump(int tab)
	{
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine($"Panel({Orientation})");
		foreach (LayoutElement child in base.Children)
		{
			child.ConsoleDump(tab + 1);
		}
	}
}

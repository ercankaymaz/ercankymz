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
public class LayoutAnchorablePaneGroup : LayoutPositionableGroup<ILayoutAnchorablePane>, ILayoutAnchorablePane, ILayoutPanelElement, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging, ILayoutPane, ILayoutContainer, ILayoutElementWithVisibility, ILayoutOrientableGroup, ILayoutGroup
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

	public LayoutAnchorablePaneGroup()
	{
	}

	public LayoutAnchorablePaneGroup(LayoutAnchorablePane firstChild)
	{
		base.Children.Add(firstChild);
	}

	protected override bool GetVisibility()
	{
		if (base.Children.Count > 0)
		{
			return base.Children.Any((ILayoutAnchorablePane c) => c.IsVisible);
		}
		return false;
	}

	protected override void OnIsVisibleChanged()
	{
		UpdateParentVisibility();
		base.OnIsVisibleChanged();
	}

	protected override void OnDockWidthChanged()
	{
		if (base.DockWidth.IsAbsolute && base.ChildrenCount == 1)
		{
			((ILayoutPositionableElement)base.Children[0]).DockWidth = base.DockWidth;
		}
		base.OnDockWidthChanged();
	}

	protected override void OnDockHeightChanged()
	{
		if (base.DockHeight.IsAbsolute && base.ChildrenCount == 1)
		{
			((ILayoutPositionableElement)base.Children[0]).DockHeight = base.DockHeight;
		}
		base.OnDockHeightChanged();
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
		Trace.WriteLine($"AnchorablePaneGroup({Orientation})");
		foreach (LayoutElement child in base.Children)
		{
			child.ConsoleDump(tab + 1);
		}
	}

	private void UpdateParentVisibility()
	{
		if (base.Parent is ILayoutElementWithVisibility layoutElementWithVisibility)
		{
			layoutElementWithVisibility.ComputeVisibility();
		}
	}
}

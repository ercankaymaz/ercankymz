#define TRACE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Markup;
using System.Xml;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
[ContentProperty("Children")]
public class LayoutDocumentPane : LayoutPositionableGroup<LayoutContent>, ILayoutDocumentPane, ILayoutPanelElement, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging, ILayoutPane, ILayoutContainer, ILayoutElementWithVisibility, ILayoutPositionableElement, ILayoutElementForFloatingWindow, ILayoutContentSelector, ILayoutPaneSerializable
{
	private bool _showHeader = true;

	private int _selectedIndex = -1;

	private string _id;

	public bool ShowHeader
	{
		get
		{
			return _showHeader;
		}
		set
		{
			if (value != _showHeader)
			{
				_showHeader = value;
				RaisePropertyChanged("ShowHeader");
			}
		}
	}

	public int SelectedContentIndex
	{
		get
		{
			return _selectedIndex;
		}
		set
		{
			if (value < 0 || value >= base.Children.Count)
			{
				value = -1;
			}
			if (_selectedIndex != value)
			{
				RaisePropertyChanging("SelectedContentIndex");
				RaisePropertyChanging("SelectedContent");
				if (_selectedIndex >= 0 && _selectedIndex < base.Children.Count)
				{
					base.Children[_selectedIndex].IsSelected = false;
				}
				_selectedIndex = value;
				if (_selectedIndex >= 0 && _selectedIndex < base.Children.Count)
				{
					base.Children[_selectedIndex].IsSelected = true;
				}
				RaisePropertyChanged("SelectedContentIndex");
				RaisePropertyChanged("SelectedContent");
			}
		}
	}

	public LayoutContent SelectedContent
	{
		get
		{
			if (_selectedIndex != -1)
			{
				return base.Children[_selectedIndex];
			}
			return null;
		}
	}

	public IEnumerable<LayoutContent> ChildrenSorted
	{
		get
		{
			List<LayoutContent> list = base.Children.ToList();
			list.Sort();
			return list;
		}
	}

	string ILayoutPaneSerializable.Id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}

	public LayoutDocumentPane()
	{
	}

	public LayoutDocumentPane(LayoutContent firstChild)
	{
		base.Children.Add(firstChild);
		if (base.Root != null)
		{
			base.Root.CollectGarbage();
		}
	}

	protected override bool GetVisibility()
	{
		if (base.Parent is LayoutDocumentPaneGroup)
		{
			if (base.ChildrenCount > 0)
			{
				return base.Children.Any((LayoutContent c) => (c is LayoutDocument && ((LayoutDocument)c).IsVisible) || c is LayoutAnchorable);
			}
			return false;
		}
		return true;
	}

	protected override void ChildMoved(int oldIndex, int newIndex)
	{
		if (_selectedIndex == oldIndex)
		{
			RaisePropertyChanging("SelectedContentIndex");
			_selectedIndex = newIndex;
			RaisePropertyChanged("SelectedContentIndex");
		}
		base.ChildMoved(oldIndex, newIndex);
	}

	protected override void OnChildrenCollectionChanged()
	{
		if (SelectedContentIndex >= base.ChildrenCount)
		{
			SelectedContentIndex = base.Children.Count - 1;
		}
		if (SelectedContentIndex == -1)
		{
			if (base.ChildrenCount > 0)
			{
				if (base.Root == null)
				{
					SetNextSelectedIndex();
				}
				else
				{
					LayoutContent layoutContent = base.Children.OrderByDescending((LayoutContent c) => c.LastActivationTimeStamp.GetValueOrDefault()).First();
					SelectedContentIndex = base.Children.IndexOf(layoutContent);
					layoutContent.IsActive = true;
				}
			}
			else if (base.Root != null)
			{
				base.Root.ActiveContent = null;
			}
		}
		base.OnChildrenCollectionChanged();
		RaisePropertyChanged("ChildrenSorted");
	}

	protected override void OnIsVisibleChanged()
	{
		UpdateParentVisibility();
		base.OnIsVisibleChanged();
	}

	public override void WriteXml(XmlWriter writer)
	{
		if (_id != null)
		{
			writer.WriteAttributeString("Id", _id);
		}
		if (!_showHeader)
		{
			writer.WriteAttributeString("ShowHeader", _showHeader.ToString());
		}
		base.WriteXml(writer);
	}

	public override void ReadXml(XmlReader reader)
	{
		if (reader.MoveToAttribute("Id"))
		{
			_id = reader.Value;
		}
		if (reader.MoveToAttribute("ShowHeader"))
		{
			_showHeader = bool.Parse(reader.Value);
		}
		base.ReadXml(reader);
	}

	public override void ConsoleDump(int tab)
	{
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine("DocumentPane()");
		foreach (LayoutContent child in base.Children)
		{
			child.ConsoleDump(tab + 1);
		}
	}

	public int IndexOf(LayoutContent content)
	{
		return base.Children.IndexOf(content);
	}

	internal void SetNextSelectedIndex()
	{
		SelectedContentIndex = -1;
		for (int i = 0; i < base.Children.Count; i++)
		{
			if (base.Children[i].IsEnabled)
			{
				SelectedContentIndex = i;
				break;
			}
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

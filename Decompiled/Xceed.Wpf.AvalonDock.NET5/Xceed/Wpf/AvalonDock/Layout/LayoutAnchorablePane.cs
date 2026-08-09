#define TRACE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Markup;
using System.Xml;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
[ContentProperty("Children")]
public class LayoutAnchorablePane : LayoutPositionableGroup<LayoutAnchorable>, ILayoutAnchorablePane, ILayoutPanelElement, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging, ILayoutPane, ILayoutContainer, ILayoutElementWithVisibility, ILayoutPositionableElement, ILayoutElementForFloatingWindow, ILayoutContentSelector, ILayoutPaneSerializable
{
	private int _selectedIndex = -1;

	[XmlIgnore]
	private bool _autoFixSelectedContent = true;

	private string _name;

	private string _id;

	public bool CanHide => base.Children.All((LayoutAnchorable a) => a.CanHide);

	public bool CanClose => base.Children.All((LayoutAnchorable a) => a.CanClose);

	public bool IsHostedInFloatingWindow => this.FindParent<LayoutFloatingWindow>() != null;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (_name != value)
			{
				_name = value;
				RaisePropertyChanged("Name");
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

	public bool IsDirectlyHostedInFloatingWindow => this.FindParent<LayoutAnchorableFloatingWindow>()?.IsSinglePane ?? false;

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

	public LayoutAnchorablePane()
	{
	}

	public LayoutAnchorablePane(LayoutAnchorable anchorable)
	{
		base.Children.Add(anchorable);
	}

	protected override bool GetVisibility()
	{
		if (base.Children.Count > 0)
		{
			return base.Children.Any((LayoutAnchorable c) => c.IsVisible);
		}
		return false;
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
		AutoFixSelectedContent();
		for (int i = 0; i < base.Children.Count; i++)
		{
			if (base.Children[i].IsSelected)
			{
				SelectedContentIndex = i;
				break;
			}
		}
		RaisePropertyChanged("CanClose");
		RaisePropertyChanged("CanHide");
		RaisePropertyChanged("IsDirectlyHostedInFloatingWindow");
		base.OnChildrenCollectionChanged();
	}

	protected override void OnParentChanged(ILayoutContainer oldValue, ILayoutContainer newValue)
	{
		if (oldValue is ILayoutGroup layoutGroup)
		{
			layoutGroup.ChildrenCollectionChanged -= OnParentChildrenCollectionChanged;
		}
		RaisePropertyChanged("IsDirectlyHostedInFloatingWindow");
		if (newValue is ILayoutGroup layoutGroup2)
		{
			layoutGroup2.ChildrenCollectionChanged += OnParentChildrenCollectionChanged;
		}
		base.OnParentChanged(oldValue, newValue);
	}

	public override void WriteXml(XmlWriter writer)
	{
		if (_id != null)
		{
			writer.WriteAttributeString("Id", _id);
		}
		if (_name != null)
		{
			writer.WriteAttributeString("Name", _name);
		}
		base.WriteXml(writer);
	}

	public override void ReadXml(XmlReader reader)
	{
		if (reader.MoveToAttribute("Id"))
		{
			_id = reader.Value;
		}
		if (reader.MoveToAttribute("Name"))
		{
			_name = reader.Value;
		}
		_autoFixSelectedContent = false;
		base.ReadXml(reader);
		_autoFixSelectedContent = true;
		AutoFixSelectedContent();
	}

	public override void ConsoleDump(int tab)
	{
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine("AnchorablePane()");
		foreach (LayoutAnchorable child in base.Children)
		{
			child.ConsoleDump(tab + 1);
		}
	}

	public int IndexOf(LayoutContent content)
	{
		if (!(content is LayoutAnchorable item))
		{
			return -1;
		}
		return base.Children.IndexOf(item);
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

	internal void UpdateIsDirectlyHostedInFloatingWindow()
	{
		RaisePropertyChanged("IsDirectlyHostedInFloatingWindow");
	}

	private void AutoFixSelectedContent()
	{
		if (_autoFixSelectedContent)
		{
			if (SelectedContentIndex >= base.ChildrenCount)
			{
				SelectedContentIndex = base.Children.Count - 1;
			}
			if (SelectedContentIndex == -1 && base.ChildrenCount > 0)
			{
				SetNextSelectedIndex();
			}
		}
	}

	private void OnParentChildrenCollectionChanged(object sender, EventArgs e)
	{
		RaisePropertyChanged("IsDirectlyHostedInFloatingWindow");
	}
}

using System.Collections.Generic;
using System.Drawing;

namespace System.Windows.Forms;

public class RibbonMouseSensor : IDisposable
{
	private RibbonItem _lastMouseDown;

	public Control Control { get; }

	public bool Disposed { get; private set; }

	internal RibbonTab HittedTab { get; set; }

	internal bool HittedTabScroll
	{
		get
		{
			if (!HittedTabScrollLeft)
			{
				return HittedTabScrollRight;
			}
			return true;
		}
	}

	internal bool HittedTabScrollLeft { get; set; }

	internal bool HittedTabScrollRight { get; set; }

	internal RibbonPanel HittedPanel { get; set; }

	internal RibbonItem HittedItem { get; set; }

	internal RibbonItem HittedSubItem { get; set; }

	[Obsolete("use IsSuspended")]
	public bool IsSupsended => IsSuspended;

	public bool IsSuspended { get; private set; }

	public IEnumerable<RibbonItem> ItemsSource { get; set; }

	public List<RibbonItem> Items { get; }

	public RibbonPanel PanelLimit { get; set; }

	public List<RibbonPanel> Panels { get; }

	public Ribbon Ribbon { get; }

	internal RibbonTab SelectedTab { get; set; }

	internal RibbonPanel SelectedPanel { get; set; }

	internal RibbonItem SelectedItem { get; set; }

	internal RibbonItem SelectedSubItem { get; set; }

	public RibbonTab TabLimit { get; set; }

	public List<RibbonTab> Tabs { get; }

	private RibbonMouseSensor()
	{
		Tabs = new List<RibbonTab>();
		Panels = new List<RibbonPanel>();
		Items = new List<RibbonItem>();
	}

	public RibbonMouseSensor(Control control, Ribbon ribbon)
		: this()
	{
		Control = control ?? throw new ArgumentNullException("control");
		Ribbon = ribbon ?? throw new ArgumentNullException("ribbon");
		AddHandlers();
	}

	public RibbonMouseSensor(Control control, Ribbon ribbon, IEnumerable<RibbonTab> tabs, IEnumerable<RibbonPanel> panels, IEnumerable<RibbonItem> items)
		: this(control, ribbon)
	{
		if (tabs != null)
		{
			Tabs.AddRange(tabs);
		}
		if (panels != null)
		{
			Panels.AddRange(panels);
		}
		if (items != null)
		{
			Items.AddRange(items);
		}
	}

	public RibbonMouseSensor(Control control, Ribbon ribbon, RibbonTab tab)
		: this(control, ribbon)
	{
		Tabs.Add(tab);
		Panels.AddRange(tab.Panels);
		foreach (RibbonPanel panel in tab.Panels)
		{
			Items.AddRange(panel.Items);
		}
	}

	public RibbonMouseSensor(Control control, Ribbon ribbon, IEnumerable<RibbonItem> itemsSource)
		: this(control, ribbon)
	{
		ItemsSource = itemsSource;
		foreach (RibbonItem item in itemsSource)
		{
			if (item.Selected)
			{
				HittedItem = item;
			}
		}
	}

	private void AddHandlers()
	{
		if (Control == null)
		{
			throw new ArgumentNullException("Control", "Control is Null, cant Add RibbonMouseSensor Handles");
		}
		Control.MouseMove += Control_MouseMove;
		Control.MouseLeave += Control_MouseLeave;
		Control.MouseDown += Control_MouseDown;
		Control.MouseUp += Control_MouseUp;
		Control.MouseClick += Control_MouseClick;
		Control.MouseDoubleClick += Control_MouseDoubleClick;
	}

	private void Control_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		if (!IsSuspended && !Disposed)
		{
			if (HittedPanel != null)
			{
				HittedPanel.OnDoubleClick(e);
			}
			if (HittedItem != null)
			{
				HittedItem.OnDoubleClick(e);
			}
			if (HittedSubItem != null)
			{
				HittedSubItem.OnDoubleClick(e);
			}
		}
	}

	private void Control_MouseClick(object sender, MouseEventArgs e)
	{
		if (!IsSuspended && !Disposed)
		{
			if (HittedPanel != null)
			{
				HittedPanel.OnClick(e);
			}
			if (HittedItem != null && HittedItem == _lastMouseDown)
			{
				HittedItem.OnClick(e);
			}
			if (HittedSubItem != null)
			{
				HittedSubItem.OnClick(e);
			}
		}
	}

	private void Control_MouseUp(object sender, MouseEventArgs e)
	{
		if (IsSuspended || Disposed)
		{
			return;
		}
		if (HittedTab != null)
		{
			if (HittedTab.ScrollLeftVisible)
			{
				HittedTab.SetScrollLeftPressed(pressed: false);
				Control.Invalidate(HittedTab.ScrollLeftBounds);
			}
			if (HittedTab.ScrollRightVisible)
			{
				HittedTab.SetScrollRightPressed(pressed: false);
				Control.Invalidate(HittedTab.ScrollRightBounds);
			}
		}
		if (HittedPanel != null)
		{
			HittedPanel.SetPressed(pressed: false);
			HittedPanel.OnMouseUp(e);
			Control.Invalidate(HittedPanel.Bounds);
		}
		if (HittedItem != null)
		{
			HittedItem.SetPressed(pressed: false);
			HittedItem.OnMouseUp(e);
			Control.Invalidate(HittedItem.Bounds);
		}
		if (HittedSubItem != null)
		{
			HittedSubItem.SetPressed(pressed: false);
			HittedSubItem.OnMouseUp(e);
			Control.Invalidate(Rectangle.Intersect(HittedItem.Bounds, HittedSubItem.Bounds));
		}
	}

	private void Control_MouseDown(object sender, MouseEventArgs e)
	{
		if (IsSuspended || Disposed)
		{
			return;
		}
		HitTest(e.Location);
		_lastMouseDown = HittedItem;
		if (HittedTab != null)
		{
			if (HittedTabScrollLeft)
			{
				HittedTab.SetScrollLeftPressed(pressed: true);
				Control.Invalidate(HittedTab.ScrollLeftBounds);
			}
			if (HittedTabScrollRight)
			{
				HittedTab.SetScrollRightPressed(pressed: true);
				Control.Invalidate(HittedTab.ScrollRightBounds);
			}
		}
		if (HittedPanel != null)
		{
			HittedPanel.SetPressed(pressed: true);
			HittedPanel.OnMouseDown(e);
			Control.Invalidate(HittedPanel.Bounds);
		}
		if (HittedItem != null)
		{
			HittedItem.SetPressed(pressed: true);
			HittedItem.OnMouseDown(e);
			Control.Invalidate(HittedItem.Bounds);
		}
		if (HittedSubItem != null)
		{
			HittedSubItem.SetPressed(pressed: true);
			HittedSubItem.OnMouseDown(e);
			Control.Invalidate(Rectangle.Intersect(HittedItem.Bounds, HittedSubItem.Bounds));
		}
	}

	private void Control_MouseLeave(object sender, EventArgs e)
	{
		if (!IsSuspended)
		{
			_ = Disposed;
		}
	}

	private void Control_MouseMove(object sender, MouseEventArgs e)
	{
		if (IsSuspended || Disposed)
		{
			return;
		}
		HitTest(e.Location);
		if (SelectedPanel != null && SelectedPanel != HittedPanel)
		{
			SelectedPanel.SetSelected(selected: false);
			SelectedPanel.OnMouseLeave(e);
			Control.Invalidate(SelectedPanel.Bounds);
		}
		if (SelectedItem != null && SelectedItem != HittedItem)
		{
			SelectedItem.SetSelected(selected: false);
			SelectedItem.OnMouseLeave(e);
			Control.Invalidate(SelectedItem.Bounds);
		}
		if (SelectedSubItem != null && SelectedSubItem != HittedSubItem)
		{
			SelectedSubItem.SetSelected(selected: false);
			SelectedSubItem.OnMouseLeave(e);
			Control.Invalidate(Rectangle.Intersect(SelectedItem.Bounds, SelectedSubItem.Bounds));
		}
		if (HittedTab != null)
		{
			if (HittedTab.ScrollLeftVisible)
			{
				HittedTab.SetScrollLeftSelected(HittedTabScrollLeft);
				Control.Invalidate(HittedTab.ScrollLeftBounds);
			}
			if (HittedTab.ScrollRightVisible)
			{
				HittedTab.SetScrollRightSelected(HittedTabScrollRight);
				Control.Invalidate(HittedTab.ScrollRightBounds);
			}
		}
		if (HittedPanel != null)
		{
			if (HittedPanel == SelectedPanel)
			{
				HittedPanel.OnMouseMove(e);
			}
			else
			{
				HittedPanel.SetSelected(selected: true);
				HittedPanel.OnMouseEnter(e);
				Control.Invalidate(HittedPanel.Bounds);
			}
		}
		if (HittedItem != null)
		{
			if (HittedItem == SelectedItem)
			{
				HittedItem.OnMouseMove(e);
			}
			else
			{
				HittedItem.SetSelected(selected: true);
				HittedItem.OnMouseEnter(e);
				Control.Invalidate(HittedItem.Bounds);
			}
		}
		if (HittedSubItem != null)
		{
			if (HittedSubItem == SelectedSubItem)
			{
				HittedSubItem.OnMouseMove(e);
				return;
			}
			HittedSubItem.SetSelected(selected: true);
			HittedSubItem.OnMouseEnter(e);
			Control.Invalidate(Rectangle.Intersect(HittedItem.Bounds, HittedSubItem.Bounds));
		}
	}

	internal void HitTest(Point p)
	{
		SelectedTab = HittedTab;
		SelectedPanel = HittedPanel;
		SelectedItem = HittedItem;
		SelectedSubItem = HittedSubItem;
		HittedTab = null;
		HittedTabScrollLeft = false;
		HittedTabScrollRight = false;
		HittedPanel = null;
		HittedItem = null;
		HittedSubItem = null;
		if (TabLimit != null && TabLimit.Visible)
		{
			if (TabLimit.TabContentBounds.Contains(p))
			{
				HittedTab = TabLimit;
			}
		}
		else
		{
			foreach (RibbonTab tab in Tabs)
			{
				if (tab.Visible && tab.TabContentBounds.Contains(p))
				{
					HittedTab = tab;
					break;
				}
			}
		}
		if (HittedTab != null)
		{
			HittedTabScrollLeft = HittedTab.ScrollLeftVisible && HittedTab.ScrollLeftBounds.Contains(p);
			HittedTabScrollRight = HittedTab.ScrollRightVisible && HittedTab.ScrollRightBounds.Contains(p);
		}
		if (HittedTabScroll)
		{
			return;
		}
		if (PanelLimit != null && PanelLimit.Visible)
		{
			if (PanelLimit.Bounds.Contains(p))
			{
				HittedPanel = PanelLimit;
			}
		}
		else
		{
			foreach (RibbonPanel panel in Panels)
			{
				if (panel.Visible && panel.Bounds.Contains(p))
				{
					HittedPanel = panel;
					break;
				}
			}
		}
		IEnumerable<RibbonItem> enumerable = Items;
		if (ItemsSource != null)
		{
			enumerable = ItemsSource;
		}
		foreach (RibbonItem item in enumerable)
		{
			if ((item.OwnerPanel == null || !item.OwnerPanel.OverflowMode || Control is RibbonPanelPopup) && item.Visible && item.Bounds.Contains(p))
			{
				HittedItem = item;
				break;
			}
		}
		IContainsSelectableRibbonItems containsSelectableRibbonItems = HittedItem as IContainsSelectableRibbonItems;
		IScrollableRibbonItem scrollableRibbonItem = HittedItem as IScrollableRibbonItem;
		if (containsSelectableRibbonItems == null)
		{
			return;
		}
		Rectangle rect = scrollableRibbonItem?.ContentBounds ?? HittedItem.Bounds;
		foreach (RibbonItem item2 in containsSelectableRibbonItems.GetItems())
		{
			if (item2.Visible)
			{
				Rectangle bounds = item2.Bounds;
				bounds.Intersect(rect);
				if (bounds.Contains(p))
				{
					HittedSubItem = item2;
				}
			}
		}
	}

	private void RemoveHandlers()
	{
		Control.MouseMove -= Control_MouseMove;
		Control.MouseLeave -= Control_MouseLeave;
		Control.MouseDown -= Control_MouseDown;
		Control.MouseUp -= Control_MouseUp;
		Control.MouseClick -= Control_MouseClick;
		Control.MouseDoubleClick -= Control_MouseDoubleClick;
	}

	public void Resume()
	{
		IsSuspended = false;
	}

	public void Suspend()
	{
		IsSuspended = true;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			Disposed = true;
			RemoveHandlers();
		}
	}
}

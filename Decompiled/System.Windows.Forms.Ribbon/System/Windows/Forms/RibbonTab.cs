using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace System.Windows.Forms;

[DesignTimeVisible(false)]
[Designer(typeof(RibbonTabDesigner))]
public class RibbonTab : Component, IRibbonElement, IRibbonToolTip, IContainsRibbonComponents
{
	private bool? _isopeninvisualstudiodesigner;

	private bool _enabled;

	private bool _pressed;

	private bool _selected;

	private bool _active;

	private string _text;

	private RibbonContext _context;

	private int _offset;

	private bool _visible = true;

	private readonly RibbonToolTip _TT;

	private string _Name = string.Empty;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public virtual string Name
	{
		get
		{
			if (Site != null)
			{
				_Name = Site.Name;
			}
			return _Name;
		}
		set
		{
			_Name = value;
		}
	}

	[DefaultValue(true)]
	[Category("Behavior")]
	[Description("Sets if the tab should be enabled")]
	public bool Enabled
	{
		get
		{
			if (Owner != null)
			{
				if (_enabled)
				{
					return Owner.Enabled;
				}
				return false;
			}
			return _enabled;
		}
		set
		{
			_enabled = value;
			Owner.Invalidate();
			foreach (RibbonPanel panel in Panels)
			{
				panel.Enabled = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public bool ScrollRightVisible { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public bool ScrollRightSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public bool ScrollRightPressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Rectangle ScrollRightBounds { get; private set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(false)]
	public bool ScrollLeftVisible { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Rectangle ScrollLeftBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public bool ScrollLeftSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public bool ScrollLeftPressed { get; private set; }

	[Browsable(false)]
	public Rectangle Bounds => TabBounds;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonPanelCollection Panels { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle TabBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle TabContentBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Ribbon Owner { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool Pressed => _pressed;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool Selected => _selected;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool Active => _active;

	[Description("An Object field for associating custom data for this control")]
	[DefaultValue(null)]
	[Category("Data")]
	[TypeConverter(typeof(StringConverter))]
	public object Tag { get; set; }

	[DefaultValue(null)]
	[Category("Data")]
	[Description("A string field for associating custom data for this control")]
	public string Value { get; set; }

	[Category("Behavior")]
	[DefaultValue(null)]
	public string AltKey { get; set; }

	[Localizable(true)]
	[Category("Appearance")]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			OnTextChanged(EventArgs.Empty);
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool Contextual => _context != null;

	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public RibbonContext Context
	{
		get
		{
			return _context;
		}
		set
		{
			_context = value;
			OnContextChanged(EventArgs.Empty);
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
				Owner.UpdateRegions();
			}
		}
	}

	[Category("Behavior")]
	[Localizable(true)]
	[DefaultValue(true)]
	public bool Visible
	{
		get
		{
			if (Owner != null && !Owner.IsDesignMode() && !Owner.Visible)
			{
				return false;
			}
			if (!Contextual)
			{
				return _visible;
			}
			return Context.Visible;
		}
		set
		{
			_visible = value;
			if (Owner != null)
			{
				Owner.UpdateRegions();
				if (Active)
				{
					EnsureAnyTabVisible();
				}
				else
				{
					Owner.Invalidate();
				}
			}
		}
	}

	[DefaultValue("")]
	public string ToolTipTitle
	{
		get
		{
			return _TT.ToolTipTitle;
		}
		set
		{
			_TT.ToolTipTitle = value;
		}
	}

	[DefaultValue(ToolTipIcon.None)]
	public ToolTipIcon ToolTipIcon
	{
		get
		{
			return _TT.ToolTipIcon;
		}
		set
		{
			_TT.ToolTipIcon = value;
		}
	}

	[DefaultValue(null)]
	[Localizable(true)]
	public string ToolTip { get; set; }

	[DefaultValue(null)]
	[Localizable(true)]
	public Image ToolTipImage
	{
		get
		{
			return _TT.ToolTipImage;
		}
		set
		{
			_TT.ToolTipImage = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal bool Invisible
	{
		get
		{
			if (Owner != null && Owner.HideSingleTabIfTextEmpty && Owner.Tabs.Count == 1)
			{
				return string.IsNullOrEmpty(Text);
			}
			return false;
		}
	}

	public event MouseEventHandler MouseEnter;

	public event MouseEventHandler MouseLeave;

	public event MouseEventHandler MouseMove;

	public event EventHandler ScrollRightVisibleChanged;

	public event EventHandler ScrollRightPressedChanged;

	public event EventHandler ScrollRightBoundsChanged;

	public event EventHandler ScrollRightSelectedChanged;

	public event EventHandler ScrollLeftVisibleChanged;

	public event EventHandler ScrollLeftPressedChanged;

	public event EventHandler ScrollLeftSelectedChanged;

	public event EventHandler ScrollLeftBoundsChanged;

	public event EventHandler TabBoundsChanged;

	public event EventHandler TabContentBoundsChanged;

	public event EventHandler OwnerChanged;

	public event EventHandler PressedChanged;

	public event EventHandler ActiveChanged;

	public event EventHandler TextChanged;

	public event EventHandler ContextChanged;

	public virtual event RibbonElementPopupEventHandler ToolTipPopUp;

	public RibbonTab()
	{
		Panels = new RibbonPanelCollection(this);
		_enabled = true;
		_TT = new RibbonToolTip(this)
		{
			InitialDelay = 100,
			AutomaticDelay = 800,
			AutoPopDelay = 8000,
			UseAnimation = true,
			Active = false
		};
		_TT.Popup += _TT_Popup;
	}

	public RibbonTab(string text)
		: this()
	{
		_text = text;
	}

	[Obsolete("Use 'public RibbonTab(string text)' instead!")]
	public RibbonTab(Ribbon owner, string text)
		: this(text)
	{
	}

	protected bool IsOpenInVisualStudioDesigner()
	{
		if (!_isopeninvisualstudiodesigner.HasValue)
		{
			_isopeninvisualstudiodesigner = LicenseManager.UsageMode == LicenseUsageMode.Designtime || base.DesignMode;
			if (!_isopeninvisualstudiodesigner.Value)
			{
				try
				{
					using Process process = Process.GetCurrentProcess();
					_isopeninvisualstudiodesigner = process.ProcessName.ToLowerInvariant().Contains("devenv");
				}
				catch
				{
				}
			}
		}
		return _isopeninvisualstudiodesigner.Value;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && RibbonDesigner.Current == null)
		{
			_TT.Popup -= _TT_Popup;
			_TT.Dispose();
			try
			{
				foreach (RibbonPanel panel in Panels)
				{
					panel.Dispose();
				}
			}
			catch (InvalidOperationException)
			{
				if (!IsOpenInVisualStudioDesigner())
				{
					throw;
				}
			}
		}
		base.Dispose(disposing);
	}

	public void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (Owner == null)
		{
			return;
		}
		Owner.Renderer.OnRenderRibbonTab(new RibbonTabRenderEventArgs(Owner, e.Graphics, e.Clip, this));
		Owner.Renderer.OnRenderRibbonTabText(new RibbonTabRenderEventArgs(Owner, e.Graphics, e.Clip, this));
		if (Active && (!Owner.Minimized || (Owner.Minimized && Owner.Expanded)))
		{
			int num = 0;
			foreach (RibbonPanel panel in Panels)
			{
				if (panel.Visible)
				{
					panel.Index = num;
					panel.IsFirstPanel = num == 0;
					panel.OnPaint(this, new RibbonElementPaintEventArgs(e.Clip, e.Graphics, panel.SizeMode, e.Control));
					num++;
				}
			}
			foreach (RibbonPanel panel2 in Panels)
			{
				if (panel2.Visible)
				{
					panel2.IsLastPanel = panel2.Index == num - 1;
					break;
				}
			}
		}
		Owner.Renderer.OnRenderTabScrollButtons(new RibbonTabRenderEventArgs(Owner, e.Graphics, e.Clip, this));
	}

	public void SetBounds(Rectangle bounds)
	{
		throw new NotSupportedException();
	}

	public void SetContext(RibbonContext context)
	{
		if (!context.Equals(context))
		{
			OnContextChanged(EventArgs.Empty);
		}
		_context = context;
	}

	public Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible && !Owner.IsDesignMode())
		{
			return new Size(0, 0);
		}
		return Size.Ceiling(e.Graphics.MeasureString(string.IsNullOrEmpty(Text) ? " " : Text, Owner.Font));
	}

	internal void SetOwner(Ribbon owner)
	{
		Owner = owner;
		Panels.SetOwner(owner);
		OnOwnerChanged(EventArgs.Empty);
	}

	internal virtual void ClearOwner()
	{
		Owner = null;
		OnOwnerChanged(EventArgs.Empty);
	}

	internal void SetPressed(bool pressed)
	{
		_pressed = pressed;
		OnPressedChanged(EventArgs.Empty);
	}

	internal void SetSelected(bool selected)
	{
		_selected = selected;
		if (selected)
		{
			OnMouseEnter(new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
		}
		else
		{
			OnMouseLeave(new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
		}
	}

	public void OnContextChanged(EventArgs e)
	{
		if (this.ContextChanged != null)
		{
			this.ContextChanged(this, e);
		}
	}

	public void OnTextChanged(EventArgs e)
	{
		if (this.TextChanged != null)
		{
			this.TextChanged(this, e);
		}
	}

	public void OnActiveChanged(EventArgs e)
	{
		if (this.ActiveChanged != null)
		{
			this.ActiveChanged(this, e);
		}
	}

	public void OnPressedChanged(EventArgs e)
	{
		if (this.PressedChanged != null)
		{
			this.PressedChanged(this, e);
		}
	}

	public void OnOwnerChanged(EventArgs e)
	{
		if (this.OwnerChanged != null)
		{
			this.OwnerChanged(this, e);
		}
	}

	public void OnTabContentBoundsChanged(EventArgs e)
	{
		if (this.TabContentBoundsChanged != null)
		{
			this.TabContentBoundsChanged(this, e);
		}
	}

	public void OnTabBoundsChanged(EventArgs e)
	{
		if (this.TabBoundsChanged != null)
		{
			this.TabBoundsChanged(this, e);
		}
	}

	public void OnScrollRightVisibleChanged(EventArgs e)
	{
		if (this.ScrollRightVisibleChanged != null)
		{
			this.ScrollRightVisibleChanged(this, e);
		}
	}

	public void OnScrollRightPressedChanged(EventArgs e)
	{
		if (this.ScrollRightPressedChanged != null)
		{
			this.ScrollRightPressedChanged(this, e);
		}
	}

	public void OnScrollRightBoundsChanged(EventArgs e)
	{
		if (this.ScrollRightBoundsChanged != null)
		{
			this.ScrollRightBoundsChanged(this, e);
		}
	}

	public void OnScrollRightSelectedChanged(EventArgs e)
	{
		if (this.ScrollRightSelectedChanged != null)
		{
			this.ScrollRightSelectedChanged(this, e);
		}
	}

	public void OnScrollLeftVisibleChanged(EventArgs e)
	{
		if (this.ScrollLeftVisibleChanged != null)
		{
			this.ScrollLeftVisibleChanged(this, e);
		}
	}

	public void OnScrollLeftPressedChanged(EventArgs e)
	{
		if (this.ScrollLeftPressedChanged != null)
		{
			this.ScrollLeftPressedChanged(this, e);
		}
	}

	public void OnScrollLeftBoundsChanged(EventArgs e)
	{
		if (this.ScrollLeftBoundsChanged != null)
		{
			this.ScrollLeftBoundsChanged(this, e);
		}
	}

	public void OnScrollLeftSelectedChanged(EventArgs e)
	{
		if (this.ScrollLeftSelectedChanged != null)
		{
			this.ScrollLeftSelectedChanged(this, e);
		}
	}

	internal void SetActive(bool active)
	{
		bool num = _active != active;
		_active = active;
		if (num)
		{
			OnActiveChanged(EventArgs.Empty);
		}
	}

	internal void SetTabBounds(Rectangle tabBounds)
	{
		_ = TabBounds != tabBounds;
		TabBounds = tabBounds;
		OnTabBoundsChanged(EventArgs.Empty);
	}

	internal void SetTabContentBounds(Rectangle tabContentBounds)
	{
		_ = TabContentBounds != tabContentBounds;
		TabContentBounds = tabContentBounds;
		OnTabContentBoundsChanged(EventArgs.Empty);
	}

	private RibbonPanel GetLargerPanel(RibbonElementSizeMode size)
	{
		RibbonPanel ribbonPanel = null;
		foreach (RibbonPanel panel in Panels)
		{
			if (panel.SizeMode == size)
			{
				if (ribbonPanel == null)
				{
					ribbonPanel = panel;
				}
				if (panel.Bounds.Width > ribbonPanel.Bounds.Width)
				{
					ribbonPanel = panel;
				}
			}
		}
		return ribbonPanel;
	}

	private RibbonPanel GetLargerPanel()
	{
		RibbonPanel largerPanel = GetLargerPanel(RibbonElementSizeMode.Large);
		if (largerPanel != null)
		{
			return largerPanel;
		}
		RibbonPanel largerPanel2 = GetLargerPanel(RibbonElementSizeMode.Medium);
		if (largerPanel2 != null)
		{
			return largerPanel2;
		}
		RibbonPanel largerPanel3 = GetLargerPanel(RibbonElementSizeMode.Compact);
		if (largerPanel3 != null)
		{
			return largerPanel3;
		}
		RibbonPanel largerPanel4 = GetLargerPanel(RibbonElementSizeMode.Overflow);
		if (largerPanel4 != null)
		{
			return largerPanel4;
		}
		return null;
	}

	private bool AllPanelsOverflow()
	{
		foreach (RibbonPanel panel in Panels)
		{
			if (panel.SizeMode != RibbonElementSizeMode.Overflow)
			{
				return false;
			}
		}
		return true;
	}

	internal void UpdatePanelsRegions()
	{
		if (Panels.Count == 0 || Owner == null || Owner.IsDisposed)
		{
			return;
		}
		if (!Owner.IsDesignMode())
		{
			_offset = 0;
		}
		int num = TabContentBounds.Left + Owner.PanelPadding.Left + _offset;
		int num2 = TabContentBounds.Right - Owner.PanelPadding.Right;
		int y = TabContentBounds.Top + Owner.PanelPadding.Top;
		int num3 = 0;
		using (Graphics graphics = Owner.CreateGraphics())
		{
			foreach (RibbonPanel panel in Panels)
			{
				if (panel.Visible && Owner.RightToLeft == RightToLeft.No)
				{
					RibbonElementSizeMode sizeMode = ((panel.FlowsTo == RibbonPanelFlowDirection.Right) ? RibbonElementSizeMode.Medium : RibbonElementSizeMode.Large);
					panel.SetBounds(new Rectangle(0, 0, 1, TabContentBounds.Height - Owner.PanelPadding.Vertical));
					Size size = panel.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(graphics, sizeMode));
					Rectangle bounds = new Rectangle(num, y, size.Width, size.Height);
					panel.SetBounds(bounds);
					panel.SetSizeMode(sizeMode);
					num = bounds.Right + Owner.PanelSpacing;
					num3++;
				}
				else if (panel.Visible && Owner.RightToLeft == RightToLeft.Yes)
				{
					RibbonElementSizeMode sizeMode2 = ((panel.FlowsTo == RibbonPanelFlowDirection.Right) ? RibbonElementSizeMode.Medium : RibbonElementSizeMode.Large);
					panel.SetBounds(new Rectangle(0, 0, 1, TabContentBounds.Height - Owner.PanelPadding.Vertical));
					Size size2 = panel.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(graphics, sizeMode2));
					num2 -= size2.Width + Owner.PanelSpacing;
					Rectangle bounds2 = new Rectangle(num2, y, size2.Width, size2.Height);
					panel.SetBounds(bounds2);
					panel.SetSizeMode(sizeMode2);
					num2 = bounds2.Left - 1 - Owner.PanelSpacing;
					num3++;
				}
				else
				{
					panel.SetBounds(Rectangle.Empty);
				}
			}
			if (!Owner.IsDesignMode() && num3 > 0)
			{
				while (num > TabContentBounds.Right && !AllPanelsOverflow())
				{
					RibbonPanel largerPanel = GetLargerPanel();
					if (largerPanel.SizeMode == RibbonElementSizeMode.Large)
					{
						largerPanel.SetSizeMode(RibbonElementSizeMode.Medium);
					}
					else if (largerPanel.SizeMode == RibbonElementSizeMode.Medium)
					{
						largerPanel.SetSizeMode(RibbonElementSizeMode.Compact);
					}
					else if (largerPanel.SizeMode == RibbonElementSizeMode.Compact)
					{
						largerPanel.SetSizeMode(RibbonElementSizeMode.Overflow);
					}
					Size size3 = largerPanel.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(graphics, largerPanel.SizeMode));
					largerPanel.SetBounds(new Rectangle(largerPanel.Bounds.Location, new Size(size3.Width + Owner.PanelMargin.Horizontal, size3.Height)));
					num = TabContentBounds.Left + Owner.PanelPadding.Left;
					foreach (RibbonPanel panel2 in Panels)
					{
						Size size4 = panel2.Bounds.Size;
						panel2.SetBounds(new Rectangle(new Point(num, y), size4));
						num += panel2.Bounds.Width + Owner.PanelSpacing;
					}
				}
			}
			foreach (RibbonPanel panel3 in Panels)
			{
				panel3.UpdateItemsRegions(graphics, panel3.SizeMode);
			}
		}
		UpdateScrollBounds();
	}

	private void UpdateScrollBounds()
	{
		int num = 13;
		bool scrollRightVisible = ScrollRightVisible;
		_ = ScrollLeftVisible;
		Rectangle scrollRightBounds = ScrollRightBounds;
		Rectangle scrollLeftBounds = ScrollLeftBounds;
		if (Panels.Count == 0)
		{
			return;
		}
		if (Panels[Panels.Count - 1].Bounds.Right > TabContentBounds.Right)
		{
			ScrollRightVisible = true;
		}
		else
		{
			ScrollRightVisible = false;
		}
		if (ScrollRightVisible != scrollRightVisible)
		{
			OnScrollRightVisibleChanged(EventArgs.Empty);
		}
		if (_offset < 0)
		{
			ScrollLeftVisible = true;
		}
		else
		{
			ScrollLeftVisible = false;
		}
		if (ScrollRightVisible != scrollRightVisible)
		{
			OnScrollLeftVisibleChanged(EventArgs.Empty);
		}
		if (ScrollLeftVisible || ScrollRightVisible)
		{
			ScrollRightBounds = Rectangle.FromLTRB(Owner.ClientRectangle.Right - num, TabContentBounds.Top, Owner.ClientRectangle.Right, TabContentBounds.Bottom);
			ScrollLeftBounds = Rectangle.FromLTRB(0, TabContentBounds.Top, num, TabContentBounds.Bottom);
			if (ScrollRightBounds != scrollRightBounds)
			{
				OnScrollRightBoundsChanged(EventArgs.Empty);
			}
			if (ScrollLeftBounds != scrollLeftBounds)
			{
				OnScrollLeftBoundsChanged(EventArgs.Empty);
			}
		}
	}

	public override string ToString()
	{
		return $"Tab: {Text}";
	}

	public virtual void OnMouseEnter(MouseEventArgs e)
	{
		if (this.MouseEnter != null)
		{
			this.MouseEnter(this, e);
		}
	}

	public virtual void OnMouseLeave(MouseEventArgs e)
	{
		_TT.Active = false;
		if (this.MouseLeave != null)
		{
			this.MouseLeave(this, e);
		}
	}

	public virtual void OnMouseMove(MouseEventArgs e)
	{
		if (this.MouseMove != null)
		{
			this.MouseMove(this, e);
		}
		if (!_TT.Active && !string.IsNullOrEmpty(ToolTip))
		{
			if (ToolTip != _TT.GetToolTip(Owner))
			{
				_TT.SetToolTip(Owner, ToolTip);
			}
			_TT.Active = true;
		}
	}

	internal void SetScrollLeftPressed(bool pressed)
	{
		ScrollLeftPressed = pressed;
		if (pressed)
		{
			ScrollLeft();
		}
		OnScrollLeftPressedChanged(EventArgs.Empty);
	}

	internal void SetScrollLeftSelected(bool selected)
	{
		ScrollLeftSelected = selected;
		OnScrollLeftSelectedChanged(EventArgs.Empty);
	}

	internal void SetScrollRightPressed(bool pressed)
	{
		ScrollRightPressed = pressed;
		if (pressed)
		{
			ScrollRight();
		}
		OnScrollRightPressedChanged(EventArgs.Empty);
	}

	internal void SetScrollRightSelected(bool selected)
	{
		ScrollRightSelected = selected;
		OnScrollRightSelectedChanged(EventArgs.Empty);
	}

	public void ScrollLeft()
	{
		ScrollOffset(50);
	}

	public void ScrollRight()
	{
		ScrollOffset(-50);
	}

	public void ScrollOffset(int amount)
	{
		_offset += amount;
		foreach (RibbonPanel panel in Panels)
		{
			panel.SetBounds(new Rectangle(panel.Bounds.Left + amount, panel.Bounds.Top, panel.Bounds.Width, panel.Bounds.Height));
		}
		if (Site != null && Site.DesignMode)
		{
			UpdatePanelsRegions();
		}
		UpdateScrollBounds();
		Owner.Invalidate();
	}

	private void _TT_Popup(object sender, PopupEventArgs e)
	{
		if (this.ToolTipPopUp != null)
		{
			this.ToolTipPopUp(sender, new RibbonElementPopupEventArgs(this, e));
			if (ToolTip != _TT.GetToolTip(Owner))
			{
				_TT.SetToolTip(Owner, ToolTip);
			}
		}
	}

	private void EnsureAnyTabVisible()
	{
		int num = Owner.Tabs.IndexOf(this);
		for (int i = num; i < Owner.Tabs.Count; i++)
		{
			if (this != Owner.Tabs[i] && Owner.Tabs[i]._visible)
			{
				Owner.ActiveTab = Owner.Tabs[i];
				return;
			}
		}
		for (int j = 0; j < num; j++)
		{
			if (this != Owner.Tabs[j] && Owner.Tabs[j]._visible)
			{
				Owner.ActiveTab = Owner.Tabs[j];
				return;
			}
		}
		Owner.Invalidate();
	}

	public IEnumerable<Component> GetAllChildComponents()
	{
		return Panels.ToArray();
	}
}

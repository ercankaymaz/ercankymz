using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace System.Windows.Forms;

[DesignTimeVisible(false)]
[Designer(typeof(RibbonPanelDesigner))]
public class RibbonPanel : Component, IRibbonElement, IContainsSelectableRibbonItems, IContainsRibbonComponents
{
	private bool? _isopeninvisualstudiodesigner;

	private bool _enabled;

	private Image _image;

	private string _text;

	private bool _selected;

	private RibbonPanelFlowDirection _flowsTo;

	private bool _buttonMoreVisible;

	private bool _buttonMoreEnabled;

	internal Rectangle overflowBoundsBuffer;

	private bool _visible = true;

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
	[Description("Sets if the panel should be enabled")]
	public bool Enabled
	{
		get
		{
			if (OwnerTab != null)
			{
				if (_enabled)
				{
					return OwnerTab.Enabled;
				}
				return false;
			}
			return _enabled;
		}
		set
		{
			_enabled = value;
			Owner.Invalidate();
			foreach (RibbonItem item in Items)
			{
				item.Enabled = value;
			}
		}
	}

	[DefaultValue(true)]
	[Category("Behavior")]
	[Description("Sets if the panel should be Visible")]
	public virtual bool Visible
	{
		get
		{
			if (Owner != null && !Owner.IsDesignMode() && OwnerTab != null && !OwnerTab.Visible)
			{
				return false;
			}
			return _visible;
		}
		set
		{
			_visible = value;
			if (Owner != null)
			{
				Owner.PerformLayout();
				Owner.Invalidate();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Collapsed => SizeMode == RibbonElementSizeMode.Overflow;

	[Description("Sets the visibility of the \"More...\" button")]
	[Category("Appearance")]
	[DefaultValue(true)]
	public bool ButtonMoreVisible
	{
		get
		{
			return _buttonMoreVisible;
		}
		set
		{
			_buttonMoreVisible = value;
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
			}
		}
	}

	[Description("Enables/Disables the \"More...\" button")]
	[Category("Appearance")]
	[DefaultValue(true)]
	public bool ButtonMoreEnabled
	{
		get
		{
			return _buttonMoreEnabled;
		}
		set
		{
			_buttonMoreEnabled = value;
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonMoreSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonMorePressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ButtonMoreBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Pressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal Control PopUp { get; set; }

	[Browsable(false)]
	public RibbonElementSizeMode SizeMode { get; private set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonItemCollection Items { get; }

	[Category("Appearance")]
	[Localizable(true)]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
			}
		}
	}

	[DefaultValue(null)]
	[Category("Appearance")]
	public Image Image
	{
		get
		{
			return _image;
		}
		set
		{
			_image = value;
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool OverflowMode => SizeMode == RibbonElementSizeMode.Overflow;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Ribbon Owner { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle Bounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool Selected
	{
		get
		{
			return _selected;
		}
		set
		{
			_selected = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool IsFirstPanel { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool IsLastPanel { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual int Index { get; set; } = -1;

	[Description("An Object field for associating custom data for this control")]
	[DefaultValue(null)]
	[Category("Data")]
	[TypeConverter(typeof(StringConverter))]
	public object Tag { get; set; }

	[Browsable(false)]
	public Rectangle ContentBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonTab OwnerTab { get; private set; }

	[DefaultValue(RibbonPanelFlowDirection.Bottom)]
	[Category("Layout")]
	public RibbonPanelFlowDirection FlowsTo
	{
		get
		{
			return _flowsTo;
		}
		set
		{
			_flowsTo = value;
			if (Owner != null)
			{
				Owner.OnRegionsChanged();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal bool PopupShowed { get; set; }

	public event MouseEventHandler MouseEnter;

	public event MouseEventHandler MouseLeave;

	public event MouseEventHandler MouseMove;

	public event PaintEventHandler Paint;

	public event EventHandler Resize;

	public event EventHandler ButtonMoreClick;

	public virtual event EventHandler Click;

	public virtual event EventHandler DoubleClick;

	public virtual event MouseEventHandler MouseDown;

	public virtual event MouseEventHandler MouseUp;

	public RibbonPanel()
	{
		Items = new RibbonItemCollection();
		Items.SetOwnerPanel(this);
		SizeMode = RibbonElementSizeMode.None;
		_flowsTo = RibbonPanelFlowDirection.Bottom;
		_buttonMoreEnabled = true;
		_buttonMoreVisible = true;
		_enabled = true;
	}

	public RibbonPanel(string text)
		: this(text, RibbonPanelFlowDirection.Bottom)
	{
	}

	public RibbonPanel(string text, RibbonPanelFlowDirection flowsTo)
		: this(text, flowsTo, new RibbonItem[0])
	{
	}

	public RibbonPanel(string text, RibbonPanelFlowDirection flowsTo, IEnumerable<RibbonItem> items)
		: this()
	{
		_text = text;
		_flowsTo = flowsTo;
		Items.AddRange(items);
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
			try
			{
				foreach (RibbonItem item in Items)
				{
					item.Dispose();
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

	public Size SwitchToSize(Control ctl, Graphics g, RibbonElementSizeMode size)
	{
		Size result = MeasureSize(this, new RibbonElementMeasureSizeEventArgs(g, size));
		Rectangle bounds = new Rectangle(0, 0, result.Width, result.Height);
		SetBounds(bounds);
		UpdateItemsRegions(g, size);
		return result;
	}

	public virtual void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (this.Paint != null)
		{
			this.Paint(this, new PaintEventArgs(e.Graphics, e.Clip));
		}
		if (PopupShowed && e.Control == Owner)
		{
			RibbonPanel ribbonPanel = new RibbonPanel(Text)
			{
				Image = Image
			};
			ribbonPanel.SetOwner(Owner);
			ribbonPanel.SetSizeMode(RibbonElementSizeMode.Overflow);
			ribbonPanel.SetBounds(overflowBoundsBuffer);
			ribbonPanel.SetPressed(pressed: true);
			Owner.Renderer.OnRenderRibbonPanelBackground(new RibbonPanelRenderEventArgs(Owner, e.Graphics, e.Clip, ribbonPanel, e.Control));
			Owner.Renderer.OnRenderRibbonPanelText(new RibbonPanelRenderEventArgs(Owner, e.Graphics, e.Clip, ribbonPanel, e.Control));
		}
		else
		{
			Owner.Renderer.OnRenderRibbonPanelBackground(new RibbonPanelRenderEventArgs(Owner, e.Graphics, e.Clip, this, e.Control));
			Owner.Renderer.OnRenderRibbonPanelText(new RibbonPanelRenderEventArgs(Owner, e.Graphics, e.Clip, this, e.Control));
		}
		if (e.Mode == RibbonElementSizeMode.Overflow && (e.Control == null || e.Control != PopUp))
		{
			return;
		}
		foreach (RibbonItem item in Items)
		{
			if (item.Visible || Owner.IsDesignMode())
			{
				item.OnPaint(this, new RibbonElementPaintEventArgs(item.Bounds, e.Graphics, item.SizeMode));
			}
		}
	}

	public void SetBounds(Rectangle bounds)
	{
		_ = Bounds != bounds;
		Bounds = bounds;
		OnResize(EventArgs.Empty);
		if (Owner != null)
		{
			ContentBounds = Rectangle.FromLTRB(bounds.X + Owner.PanelMargin.Left, bounds.Y + Owner.PanelMargin.Top, bounds.Right - Owner.PanelMargin.Right, bounds.Bottom - Owner.PanelMargin.Bottom);
		}
		if (ButtonMoreVisible)
		{
			SetMoreBounds(Rectangle.FromLTRB(bounds.Right - Owner.PanelMoreMargin.Right - 15, bounds.Bottom - Owner.PanelMoreMargin.Bottom - 14, bounds.Right - Owner.PanelMoreMargin.Right, bounds.Bottom - Owner.PanelMoreMargin.Bottom));
		}
		else
		{
			SetMoreBounds(Rectangle.Empty);
		}
	}

	public Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		Size empty = Size.Empty;
		Size empty2 = Size.Empty;
		if (!Visible && !Owner.IsDesignMode())
		{
			return new Size(0, 0);
		}
		int height = OwnerTab.TabContentBounds.Height - Owner.PanelPadding.Vertical;
		empty2.Width = e.Graphics.MeasureString(Text, Owner.Font).ToSize().Width + Owner.PanelMargin.Horizontal + 1;
		if (ButtonMoreVisible)
		{
			empty2.Width += ButtonMoreBounds.Width + 3;
		}
		if (e.SizeMode == RibbonElementSizeMode.Overflow)
		{
			return new Size(RibbonButton.MeasureStringLargeSize(e.Graphics, Text, Owner.Font).Width + Owner.PanelMargin.Horizontal, height);
		}
		return new Size(Math.Max((FlowsTo switch
		{
			RibbonPanelFlowDirection.Left => MeasureSizeFlowsToBottom(sender, e), 
			RibbonPanelFlowDirection.Right => MeasureSizeFlowsToRight(sender, e), 
			RibbonPanelFlowDirection.Bottom => MeasureSizeFlowsToBottom(sender, e), 
			_ => Size.Empty, 
		}).Width, empty2.Width), height);
	}

	internal void SetOwner(Ribbon owner)
	{
		Owner = owner;
		Items.SetOwner(owner);
	}

	internal virtual void ClearOwner()
	{
		OwnerTab = null;
		Owner = null;
	}

	internal void SetSelected(bool selected)
	{
		_selected = selected;
	}

	protected virtual void OnResize(EventArgs e)
	{
		if (this.Resize != null)
		{
			this.Resize(this, e);
		}
	}

	private void ShowOverflowPopup()
	{
		Rectangle bounds = Bounds;
		RibbonPanelPopup ribbonPanelPopup = new RibbonPanelPopup(this);
		Point screenLocation = Owner.PointToScreen(new Point(bounds.Left, bounds.Bottom));
		PopupShowed = true;
		ribbonPanelPopup.Show(screenLocation);
	}

	private Size MeasureSizeFlowsToRight(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		int num = Owner.PanelMargin.Horizontal;
		int val = 0;
		int val2 = 0;
		int num2 = 0;
		foreach (RibbonItem item in Items)
		{
			if (item.Visible || Owner.IsDesignMode())
			{
				Size size = item.MeasureSize(this, e);
				num += size.Width + Owner.ItemPadding.Horizontal + 1;
				val = Math.Max(val, size.Width);
				val2 = Math.Max(val2, size.Height);
			}
		}
		switch (e.SizeMode)
		{
		case RibbonElementSizeMode.Large:
			num2 = num / 1;
			break;
		case RibbonElementSizeMode.Medium:
			num2 = num / 2;
			break;
		case RibbonElementSizeMode.Compact:
			num2 = num / 3;
			break;
		}
		num2 += Owner.PanelMargin.Horizontal;
		return new Size(Math.Max(val, num2) + Owner.PanelMargin.Horizontal, 0);
	}

	private Size MeasureSizeFlowsToBottom(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		int x = Owner.PanelMargin.Left + Owner.ItemPadding.Horizontal;
		int num = ContentBounds.Top + Owner.ItemPadding.Vertical;
		int num2 = 0;
		int num3 = 0;
		_ = OwnerTab.TabContentBounds.Height;
		_ = Owner.TabContentMargin.Vertical;
		_ = Owner.PanelPadding.Vertical;
		_ = Owner.PanelMargin.Vertical;
		int num4 = 0;
		int val = 0;
		foreach (RibbonItem item in Items)
		{
			if (item.Visible || Owner.IsDesignMode() || item.GetType() == typeof(RibbonSeparator))
			{
				Size size = item.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(e.Graphics, e.SizeMode));
				if (num + size.Height > ContentBounds.Bottom)
				{
					num = ContentBounds.Top + Owner.ItemPadding.Vertical;
					x = num4 + Owner.ItemPadding.Horizontal;
				}
				Rectangle rectangle = new Rectangle(x, num, size.Width, size.Height);
				num2 = rectangle.Right;
				num3 = rectangle.Bottom;
				num = rectangle.Bottom + Owner.ItemPadding.Vertical + 1;
				num4 = Math.Max(num4, num2);
				val = Math.Max(val, num3);
			}
		}
		return new Size(num4 + Owner.ItemPadding.Right + Owner.PanelMargin.Right + 1, 0);
	}

	internal void SetSizeMode(RibbonElementSizeMode sizeMode)
	{
		SizeMode = sizeMode;
		foreach (RibbonItem item in Items)
		{
			item.SetSizeMode(sizeMode);
		}
	}

	internal void SetContentBounds(Rectangle contentBounds)
	{
		ContentBounds = contentBounds;
	}

	internal void SetOwnerTab(RibbonTab ownerTab)
	{
		OwnerTab = ownerTab;
		Items.SetOwnerTab(OwnerTab);
	}

	internal void UpdateItemsRegions(Graphics g, RibbonElementSizeMode mode)
	{
		switch (FlowsTo)
		{
		case RibbonPanelFlowDirection.Right:
			UpdateRegionsFlowsToRight(g, mode);
			break;
		case RibbonPanelFlowDirection.Bottom:
			UpdateRegionsFlowsToBottom(g, mode);
			break;
		case RibbonPanelFlowDirection.Left:
			UpdateRegionsFlowsToLeft(g, mode);
			break;
		}
		CenterItems();
	}

	private void UpdateRegionsFlowsToBottom(Graphics g, RibbonElementSizeMode mode)
	{
		int num = ContentBounds.Left + Owner.ItemPadding.Horizontal;
		int num2 = ContentBounds.Top + Owner.ItemPadding.Vertical;
		int num3 = num;
		List<RibbonItem> list = new List<RibbonItem>();
		foreach (RibbonItem item in Items)
		{
			Size size = ((!item.Visible && !Owner.IsDesignMode()) ? new Size(0, 0) : item.LastMeasuredSize);
			if (num2 + size.Height > ContentBounds.Bottom)
			{
				num2 = ContentBounds.Top + Owner.ItemPadding.Vertical;
				num = num3 + Owner.ItemPadding.Horizontal;
				Items.CenterItemsVerticallyInto(list, ContentBounds);
				list.Clear();
			}
			item.SetBounds(new Rectangle(num, num2, size.Width, size.Height));
			num3 = Math.Max(item.Bounds.Right, num3);
			_ = item.Bounds.Bottom;
			num2 = item.Bounds.Bottom + Owner.ItemPadding.Vertical + 1;
			list.Add(item);
		}
		Items.CenterItemsVerticallyInto(list, ContentBounds);
	}

	private void UpdateRegionsFlowsToLeft(Graphics g, RibbonElementSizeMode mode)
	{
		int num = ContentBounds.Left + Owner.ItemPadding.Horizontal;
		int num2 = ContentBounds.Top + Owner.ItemPadding.Vertical;
		int num3 = num;
		List<RibbonItem> list = new List<RibbonItem>();
		for (int num4 = Items.Count - 1; num4 >= 0; num4--)
		{
			RibbonItem ribbonItem = Items[num4];
			Size size = ((!ribbonItem.Visible) ? new Size(0, 0) : ribbonItem.LastMeasuredSize);
			if (num2 + size.Height > ContentBounds.Bottom)
			{
				num2 = ContentBounds.Top + Owner.ItemPadding.Vertical;
				num = num3 + Owner.ItemPadding.Horizontal;
				Items.CenterItemsVerticallyInto(list, ContentBounds);
				list.Clear();
			}
			ribbonItem.SetBounds(new Rectangle(num, num2, size.Width, size.Height));
			num3 = Math.Max(ribbonItem.Bounds.Right, num3);
			_ = ribbonItem.Bounds.Bottom;
			num2 = ribbonItem.Bounds.Bottom + Owner.ItemPadding.Vertical + 1;
			list.Add(ribbonItem);
		}
		Items.CenterItemsVerticallyInto(list, Items.GetItemsBounds());
	}

	private void UpdateRegionsFlowsToRight(Graphics g, RibbonElementSizeMode mode)
	{
		int num = ContentBounds.Left;
		int y = ContentBounds.Top;
		int num2 = ((mode == RibbonElementSizeMode.Medium) ? 7 : 0);
		int num3 = 0;
		RibbonItem[] array = Items.ToArray();
		for (int num4 = array.Length - 1; num4 >= 0; num4--)
		{
			for (int i = 1; i <= num4; i++)
			{
				if (array[i - 1].LastMeasuredSize.Width < array[i].LastMeasuredSize.Width)
				{
					RibbonItem ribbonItem = array[i - 1];
					array[i - 1] = array[i];
					array[i] = ribbonItem;
				}
			}
		}
		List<RibbonItem> list = new List<RibbonItem>(array);
		while (list.Count > 0)
		{
			RibbonItem ribbonItem2 = list[0];
			list.Remove(ribbonItem2);
			if (num + ribbonItem2.LastMeasuredSize.Width > ContentBounds.Right)
			{
				num = ContentBounds.Left;
				y = num3 + Owner.ItemPadding.Vertical + 1 + num2;
			}
			ribbonItem2.SetBounds(new Rectangle(new Point(num, y), ribbonItem2.LastMeasuredSize));
			num += ribbonItem2.Bounds.Width + Owner.ItemPadding.Horizontal;
			num3 = Math.Max(num3, ribbonItem2.Bounds.Bottom);
			int num5 = ContentBounds.Right - num;
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].LastMeasuredSize.Width < num5)
				{
					list[j].SetBounds(new Rectangle(new Point(num, y), list[j].LastMeasuredSize));
					num += list[j].Bounds.Width + Owner.ItemPadding.Horizontal;
					num3 = Math.Max(num3, list[j].Bounds.Bottom);
					num5 = ContentBounds.Right - num;
					list.RemoveAt(j);
					j = 0;
				}
			}
		}
	}

	private void CenterItems()
	{
		Items.CenterItemsInto(ContentBounds);
	}

	public override string ToString()
	{
		return $"Panel: {Text} ({SizeMode})";
	}

	public void SetPressed(bool pressed)
	{
		Pressed = pressed;
	}

	internal void SetMorePressed(bool pressed)
	{
		ButtonMorePressed = pressed;
	}

	internal void SetMoreSelected(bool selected)
	{
		ButtonMoreSelected = selected;
	}

	internal void SetMoreBounds(Rectangle bounds)
	{
		ButtonMoreBounds = bounds;
	}

	protected void OnButtonMoreClick(EventArgs e)
	{
		if (this.ButtonMoreClick != null)
		{
			this.ButtonMoreClick(this, e);
		}
	}

	public IEnumerable<RibbonItem> GetItems()
	{
		return Items;
	}

	public Rectangle GetContentBounds()
	{
		return ContentBounds;
	}

	public virtual void OnMouseEnter(MouseEventArgs e)
	{
		if (Enabled && this.MouseEnter != null)
		{
			this.MouseEnter(this, e);
		}
	}

	public virtual void OnMouseLeave(MouseEventArgs e)
	{
		if (Enabled && this.MouseLeave != null)
		{
			this.MouseLeave(this, e);
		}
	}

	public virtual void OnMouseMove(MouseEventArgs e)
	{
		if (Enabled)
		{
			if (this.MouseMove != null)
			{
				this.MouseMove(this, e);
			}
			bool flag = false;
			if (ButtonMoreEnabled && ButtonMoreVisible && ButtonMoreBounds.Contains(e.X, e.Y) && !Collapsed)
			{
				SetMoreSelected(selected: true);
				flag = true;
			}
			else
			{
				flag = ButtonMoreSelected;
				SetMoreSelected(selected: false);
			}
			if (flag)
			{
				Owner.Invalidate(Bounds);
			}
		}
	}

	public virtual void OnClick(EventArgs e)
	{
		if (Enabled)
		{
			if (this.Click != null)
			{
				this.Click(this, e);
			}
			if (Collapsed && PopUp == null)
			{
				ShowOverflowPopup();
			}
		}
	}

	public virtual void OnDoubleClick(EventArgs e)
	{
		if (Enabled && this.DoubleClick != null)
		{
			this.DoubleClick(this, e);
		}
	}

	public virtual void OnMouseDown(MouseEventArgs e)
	{
		if (Enabled)
		{
			if (this.MouseDown != null)
			{
				this.MouseDown(this, e);
			}
			SetPressed(pressed: true);
			bool flag = false;
			if (ButtonMoreEnabled && ButtonMoreVisible && ButtonMoreBounds.Contains(e.X, e.Y) && !Collapsed)
			{
				SetMorePressed(pressed: true);
				flag = true;
			}
			else
			{
				flag = ButtonMoreSelected;
				SetMorePressed(pressed: false);
			}
			if (flag)
			{
				Owner.Invalidate(Bounds);
			}
		}
	}

	public virtual void OnMouseUp(MouseEventArgs e)
	{
		if (Enabled)
		{
			if (this.MouseUp != null)
			{
				this.MouseUp(this, e);
			}
			if (ButtonMoreEnabled && ButtonMoreVisible && ButtonMorePressed && !Collapsed)
			{
				OnButtonMoreClick(EventArgs.Empty);
			}
			SetPressed(pressed: false);
			SetMorePressed(pressed: false);
		}
	}

	public IEnumerable<Component> GetAllChildComponents()
	{
		return Items.ToArray();
	}
}

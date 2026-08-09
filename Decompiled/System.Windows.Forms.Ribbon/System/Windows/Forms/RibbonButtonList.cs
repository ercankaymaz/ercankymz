using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms;

[Designer(typeof(RibbonButtonListDesigner))]
public sealed class RibbonButtonList : RibbonItem, IContainsSelectableRibbonItems, IScrollableRibbonItem, IContainsRibbonComponents
{
	public enum ListScrollType
	{
		UpDownButtons,
		Scrollbar
	}

	public delegate void RibbonItemEventHandler(object sender, RibbonItemEventArgs e);

	private int _itemsInLargeMode;

	private int _itemsInMediumMode;

	private Size _ItemsInDropwDownMode;

	private Rectangle _contentBounds;

	private int _controlButtonsWidth;

	private RibbonElementSizeMode _buttonsSizeMode;

	private int _jumpDownSize;

	private int _jumpUpSize;

	private int _offset;

	private RibbonDropDown _dropDown;

	private bool _dropDownVisible;

	private Rectangle _thumbBounds;

	private int _scrollValue;

	private Rectangle fullContentBounds;

	private int _thumbOffset;

	private bool _avoidNextThumbMeasure;

	private RibbonItem _selectedItem;

	[Category("Layout")]
	[Description("If activated, buttons will flow to bottom inside the list")]
	public bool FlowToBottom { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ScrollBarBounds => Rectangle.FromLTRB(ButtonUpBounds.Left, ButtonUpBounds.Top, ButtonDownBounds.Right, ButtonDownBounds.Bottom);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ScrollBarEnabled { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ListScrollType ScrollType { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ScrolledPercent
	{
		get
		{
			return ((double)ContentBounds.Top - (double)fullContentBounds.Top) / ((double)fullContentBounds.Height - (double)ContentBounds.Height);
		}
		set
		{
			_avoidNextThumbMeasure = true;
			ScrollTo(-Convert.ToInt32((double)(fullContentBounds.Height - ContentBounds.Height) * value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ScrollMinimum
	{
		get
		{
			if (ScrollType == ListScrollType.Scrollbar)
			{
				return ButtonUpBounds.Bottom;
			}
			return 0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ScrollMaximum
	{
		get
		{
			if (ScrollType == ListScrollType.Scrollbar)
			{
				return ButtonDownBounds.Top - ThumbBounds.Height;
			}
			return 0;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ScrollValue
	{
		get
		{
			return _scrollValue;
		}
		set
		{
			if (value > ScrollMaximum || value < ScrollMinimum)
			{
				throw new ArgumentOutOfRangeException("ScrollValue", "Scroll value must exist between ScrollMinimum and Scroll Maximum");
			}
			_thumbBounds.Y = value;
			double num = value - ScrollMinimum;
			double num2 = ScrollMaximum - ScrollMinimum;
			ScrolledPercent = num / num2;
			_scrollValue = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ThumbSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ThumbPressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ThumbBounds => _thumbBounds;

	[Browsable(false)]
	public bool ButtonDropDownPresent => ButtonDropDownBounds.Height > 0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonItemCollection DropDownItems { get; }

	[Category("Appearance")]
	public RibbonElementSizeMode ButtonsSizeMode
	{
		get
		{
			return _buttonsSizeMode;
		}
		set
		{
			_buttonsSizeMode = value;
			if (base.Owner != null)
			{
				base.Owner.OnRegionsChanged();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonUpEnabled { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonDownEnabled { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonDropDownSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonDropDownPressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonDownSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonDownPressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonUpSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonUpPressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Rectangle ContentBounds => _contentBounds;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ButtonUpBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ButtonDownBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ButtonDropDownBounds { get; private set; }

	[DefaultValue(16)]
	[Browsable(false)]
	public int ControlButtonsWidth
	{
		get
		{
			return _controlButtonsWidth;
		}
		set
		{
			_controlButtonsWidth = value;
			if (base.Owner != null)
			{
				base.Owner.OnRegionsChanged();
			}
		}
	}

	[DefaultValue(7)]
	[Category("Appearance")]
	public int ItemsWideInLargeMode
	{
		get
		{
			return _itemsInLargeMode;
		}
		set
		{
			_itemsInLargeMode = value;
			if (base.Owner != null)
			{
				base.Owner.OnRegionsChanged();
			}
		}
	}

	[DefaultValue(3)]
	[Category("Appearance")]
	public int ItemsWideInMediumMode
	{
		get
		{
			return _itemsInMediumMode;
		}
		set
		{
			_itemsInMediumMode = value;
			if (base.Owner != null)
			{
				base.Owner.OnRegionsChanged();
			}
		}
	}

	[Category("Appearance")]
	public Size ItemsSizeInDropwDownMode
	{
		get
		{
			return _ItemsInDropwDownMode;
		}
		set
		{
			_ItemsInDropwDownMode = value;
			if (base.Owner != null)
			{
				base.Owner.OnRegionsChanged();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonButtonCollection Buttons { get; }

	public event RibbonItemEventHandler ButtonItemClicked;

	public event RibbonItemEventHandler DropDownItemClicked;

	public RibbonButtonList()
	{
		Buttons = new RibbonButtonCollection(this);
		DropDownItems = new RibbonItemCollection();
		DropDownItems.SetOwnerItem(this);
		_controlButtonsWidth = 16;
		_itemsInLargeMode = 7;
		_itemsInMediumMode = 3;
		_ItemsInDropwDownMode = new Size(7, 5);
		_buttonsSizeMode = RibbonElementSizeMode.Large;
		ScrollType = ListScrollType.UpDownButtons;
	}

	public RibbonButtonList(IEnumerable<RibbonButton> buttons)
		: this(buttons, null)
	{
	}

	public RibbonButtonList(IEnumerable<RibbonButton> buttons, IEnumerable<RibbonItem> dropDownItems)
		: this()
	{
		if (buttons != null)
		{
			List<RibbonButton> list = new List<RibbonButton>(buttons);
			Buttons.AddRange(list.ToArray());
			foreach (RibbonButton button in buttons)
			{
				button.Click += item_Click;
			}
		}
		if (dropDownItems == null)
		{
			return;
		}
		DropDownItems.AddRange(dropDownItems);
		foreach (RibbonItem dropDownItem in dropDownItems)
		{
			dropDownItem.Click += item_Click;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			foreach (RibbonItem button in Buttons)
			{
				button.Click -= item_Click;
			}
			foreach (RibbonItem dropDownItem in DropDownItems)
			{
				dropDownItem.Click -= item_Click;
			}
		}
		base.Dispose(disposing);
	}

	private void RedrawScroll()
	{
		if (base.Canvas != null)
		{
			base.Canvas.Invalidate(Rectangle.FromLTRB(ButtonDownBounds.X, ButtonUpBounds.Y, ButtonDownBounds.Right, ButtonDownBounds.Bottom));
		}
	}

	private void IgnoreDeactivation()
	{
		if (base.Canvas is RibbonPanelPopup)
		{
			(base.Canvas as RibbonPanelPopup).IgnoreNextClickDeactivation();
		}
		if (base.Canvas is RibbonDropDown)
		{
			(base.Canvas as RibbonDropDown).IgnoreNextClickDeactivation();
		}
	}

	private void RedrawControlButtons()
	{
		if (base.Canvas != null)
		{
			if (ScrollType == ListScrollType.Scrollbar)
			{
				base.Canvas.Invalidate(ScrollBarBounds);
			}
			else
			{
				base.Canvas.Invalidate(Rectangle.FromLTRB(ButtonUpBounds.Left, ButtonUpBounds.Top, ButtonDropDownBounds.Right, ButtonDropDownBounds.Bottom));
			}
		}
	}

	private void ScrollOffset(int amount)
	{
		ScrollTo(_offset + amount);
	}

	private void ScrollTo(int offset)
	{
		int num = ContentBounds.Height - fullContentBounds.Height;
		if (offset < num)
		{
			offset = num;
		}
		_offset = offset;
		SetBounds(base.Bounds);
		RedrawItem();
	}

	public void ScrollDown()
	{
		ScrollOffset(-(_jumpDownSize + 1));
	}

	public void ScrollUp()
	{
		ScrollOffset(_jumpDownSize + 1);
	}

	public void ShowDropDown()
	{
		if (DropDownItems.Count == 0)
		{
			SetPressed(pressed: false);
			return;
		}
		IgnoreDeactivation();
		_dropDown = new RibbonDropDown(this, DropDownItems, base.Owner)
		{
			ShowSizingGrip = true
		};
		Point screenLocation = base.Canvas.PointToScreen(new Point(base.Bounds.Left, base.Bounds.Top));
		SetDropDownVisible(visible: true);
		_dropDown.Show(screenLocation);
	}

	private void dropDown_FormClosed(object sender, FormClosedEventArgs e)
	{
		SetDropDownVisible(visible: false);
	}

	public void CloseDropDown()
	{
		_ = _dropDown;
		SetDropDownVisible(visible: false);
	}

	internal void SetDropDownVisible(bool visible)
	{
		_dropDownVisible = visible;
	}

	public override void OnCanvasChanged(EventArgs e)
	{
		base.OnCanvasChanged(e);
		if (base.Canvas is RibbonDropDown)
		{
			ScrollType = ListScrollType.Scrollbar;
		}
		else
		{
			ScrollType = ListScrollType.UpDownButtons;
		}
	}

	protected override bool ClosesDropDownAt(Point p)
	{
		if (!ButtonDropDownBounds.Contains(p) && !ButtonDownBounds.Contains(p) && !ButtonUpBounds.Contains(p))
		{
			if (ScrollType == ListScrollType.Scrollbar)
			{
				return !ScrollBarBounds.Contains(p);
			}
			return true;
		}
		return false;
	}

	internal override void SetOwner(Ribbon owner)
	{
		base.SetOwner(owner);
		Buttons.SetOwner(owner);
		DropDownItems.SetOwner(owner);
	}

	internal override void SetOwnerPanel(RibbonPanel ownerPanel)
	{
		base.SetOwnerPanel(ownerPanel);
		Buttons.SetOwnerPanel(ownerPanel);
		DropDownItems.SetOwnerPanel(ownerPanel);
	}

	internal override void SetOwnerTab(RibbonTab ownerTab)
	{
		base.SetOwnerTab(ownerTab);
		Buttons.SetOwnerTab(ownerTab);
		DropDownItems.SetOwnerTab(base.OwnerTab);
	}

	internal override void SetOwnerItem(RibbonItem ownerItem)
	{
		base.SetOwnerItem(ownerItem);
	}

	internal override void ClearOwner()
	{
		List<RibbonItem> list = new List<RibbonItem>(Buttons.Count + DropDownItems.Count);
		list.AddRange(Buttons);
		list.AddRange(DropDownItems);
		base.ClearOwner();
		foreach (RibbonItem item in list)
		{
			item.ClearOwner();
		}
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		base.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, e.Clip, this));
		if (e.Mode == RibbonElementSizeMode.Compact)
		{
			return;
		}
		Region clip = e.Graphics.Clip;
		Region region = new Region(clip.GetBounds(e.Graphics));
		region.Intersect(ContentBounds);
		e.Graphics.SetClip(region.GetBounds(e.Graphics));
		foreach (RibbonButton button in Buttons)
		{
			if (!button.Bounds.IsEmpty)
			{
				button.OnPaint(this, new RibbonElementPaintEventArgs(button.Bounds, e.Graphics, ButtonsSizeMode));
			}
		}
		e.Graphics.SetClip(clip.GetBounds(e.Graphics));
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
		if (ScrollType != ListScrollType.Scrollbar)
		{
			int num = 3;
			int num2 = bounds.Height / num;
			int controlButtonsWidth = _controlButtonsWidth;
			ButtonUpBounds = Rectangle.FromLTRB(bounds.Right - controlButtonsWidth, bounds.Top, bounds.Right, bounds.Top + num2);
			ButtonDownBounds = Rectangle.FromLTRB(ButtonUpBounds.Left, ButtonUpBounds.Bottom, bounds.Right, ButtonUpBounds.Bottom + num2);
			if (num == 2)
			{
				ButtonDropDownBounds = Rectangle.Empty;
			}
			else
			{
				ButtonDropDownBounds = Rectangle.FromLTRB(ButtonDownBounds.Left, ButtonDownBounds.Bottom, bounds.Right, bounds.Bottom + 1);
			}
			_thumbBounds.Location = Point.Empty;
		}
		else
		{
			int width = ThumbBounds.Width;
			int width2 = ThumbBounds.Width;
			ButtonUpBounds = Rectangle.FromLTRB(bounds.Right - width, bounds.Top + 1, bounds.Right, bounds.Top + width2 + 1);
			ButtonDownBounds = Rectangle.FromLTRB(ButtonUpBounds.Left, bounds.Bottom - width2, bounds.Right, bounds.Bottom);
			ButtonDropDownBounds = Rectangle.Empty;
			_thumbBounds.X = ButtonUpBounds.Left;
		}
		_contentBounds = Rectangle.FromLTRB(bounds.Left + 1, bounds.Top + 1, ButtonUpBounds.Left - 1, bounds.Bottom - 1);
		ButtonUpEnabled = _offset < 0;
		if (!ButtonUpEnabled)
		{
			_offset = 0;
		}
		ButtonDownEnabled = false;
		int num3 = ContentBounds.Left + 1;
		int num4 = ContentBounds.Top + 1 + _offset;
		int num5 = num4;
		int num6 = num4;
		foreach (RibbonItem button in Buttons)
		{
			button.SetBounds(Rectangle.Empty);
		}
		for (int i = 0; i < Buttons.Count && Buttons[i] is RibbonButton ribbonButton; i++)
		{
			if (num3 + ribbonButton.LastMeasuredSize.Width > ContentBounds.Right)
			{
				num3 = ContentBounds.Left + 1;
				num4 = num5 + 1;
			}
			ribbonButton.SetBounds(new Rectangle(num3, num4, ribbonButton.LastMeasuredSize.Width, ribbonButton.LastMeasuredSize.Height));
			num3 = ribbonButton.Bounds.Right + 1;
			num5 = Math.Max(num5, ribbonButton.Bounds.Bottom);
			if (ribbonButton.Bounds.Bottom > ContentBounds.Bottom)
			{
				ButtonDownEnabled = true;
			}
			_jumpDownSize = ribbonButton.Bounds.Height;
			_jumpUpSize = ribbonButton.Bounds.Height;
		}
		num5++;
		double num7 = num5 - num6;
		double num8 = ContentBounds.Height;
		if (num7 > num8 && num7 != 0.0)
		{
			double num9 = num8 / num7;
			double num10 = ButtonDownBounds.Top - ButtonUpBounds.Bottom;
			double num11 = Math.Ceiling(num9 * num10);
			if (num11 < 30.0)
			{
				num11 = ((!(num10 >= 30.0)) ? num10 : 30.0);
			}
			_thumbBounds.Height = Convert.ToInt32(num11);
			fullContentBounds = Rectangle.FromLTRB(ContentBounds.Left, num6, ContentBounds.Right, num5);
			ScrollBarEnabled = true;
			UpdateThumbPos();
		}
		else
		{
			ScrollBarEnabled = false;
		}
	}

	private void UpdateThumbPos()
	{
		if (_avoidNextThumbMeasure)
		{
			_avoidNextThumbMeasure = false;
			return;
		}
		if (!double.IsInfinity(ScrolledPercent))
		{
			double value = Math.Ceiling((double)(ScrollMaximum - ScrollMinimum) * ScrolledPercent);
			_thumbBounds.Y = ScrollMinimum + Convert.ToInt32(value);
		}
		else
		{
			_thumbBounds.Y = ScrollMinimum;
		}
		if (_thumbBounds.Y > ScrollMaximum)
		{
			_thumbBounds.Y = ScrollMaximum;
		}
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible && !base.Owner.IsDesignMode())
		{
			SetLastMeasuredSize(new Size(0, 0));
			return base.LastMeasuredSize;
		}
		int num = 0;
		switch (e.SizeMode)
		{
		case RibbonElementSizeMode.DropDown:
			num = ItemsSizeInDropwDownMode.Width;
			break;
		case RibbonElementSizeMode.Large:
			num = ItemsWideInLargeMode;
			break;
		case RibbonElementSizeMode.Medium:
			num = ItemsWideInMediumMode;
			break;
		case RibbonElementSizeMode.Compact:
			num = 0;
			break;
		}
		int val = base.OwnerPanel.ContentBounds.Height - base.Owner.ItemPadding.Vertical - 4;
		int num2 = 0;
		int num3 = 1;
		int num4 = 0;
		int num5 = 0;
		bool flag = true;
		foreach (RibbonButton button in Buttons)
		{
			Size size = button.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(e.Graphics, ButtonsSizeMode));
			if (flag)
			{
				num3 += size.Width + 1;
			}
			num4 = button.LastMeasuredSize.Height;
			num5 += num4;
			if (++num2 == num)
			{
				flag = false;
			}
		}
		if (e.SizeMode == RibbonElementSizeMode.DropDown)
		{
			val = num4 * ItemsSizeInDropwDownMode.Height;
		}
		if (ScrollBarRenderer.IsSupported)
		{
			_thumbBounds = new Rectangle(Point.Empty, ScrollBarRenderer.GetSizeBoxSize(e.Graphics, ScrollBarState.Normal));
		}
		else
		{
			_thumbBounds = new Rectangle(Point.Empty, new Size(16, 16));
		}
		SetLastMeasuredSize(new Size(Math.Max(0, num3 + ControlButtonsWidth), Math.Max(0, val)));
		return base.LastMeasuredSize;
	}

	internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
	{
		base.SetSizeMode(sizeMode);
		foreach (RibbonItem button in Buttons)
		{
			button.SetSizeMode(ButtonsSizeMode);
		}
	}

	public override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (ButtonDownPressed && ButtonDownSelected && ButtonDownEnabled)
		{
			ScrollOffset(-1);
		}
		if (ButtonUpPressed && ButtonUpSelected && ButtonUpEnabled)
		{
			ScrollOffset(1);
		}
		bool buttonUpSelected = ButtonUpSelected;
		bool buttonDownSelected = ButtonDownSelected;
		bool buttonDropDownSelected = ButtonDropDownSelected;
		bool thumbSelected = ThumbSelected;
		ButtonUpSelected = ButtonUpBounds.Contains(e.Location);
		ButtonDownSelected = ButtonDownBounds.Contains(e.Location);
		ButtonDropDownSelected = ButtonDropDownBounds.Contains(e.Location);
		ThumbSelected = _thumbBounds.Contains(e.Location) && ScrollType == ListScrollType.Scrollbar && ScrollBarEnabled;
		if (buttonUpSelected != ButtonUpSelected || buttonDownSelected != ButtonDownSelected || buttonDropDownSelected != ButtonDropDownSelected || thumbSelected != ThumbSelected)
		{
			RedrawControlButtons();
		}
		if (ThumbPressed)
		{
			int num = e.Y - _thumbOffset;
			if (num < ScrollMinimum)
			{
				num = ScrollMinimum;
			}
			else if (num > ScrollMaximum)
			{
				num = ScrollMaximum;
			}
			ScrollValue = num;
			RedrawScroll();
		}
	}

	public override void OnMouseLeave(MouseEventArgs e)
	{
		base.OnMouseLeave(e);
		bool num = ButtonUpSelected || ButtonDownSelected || ButtonDropDownSelected;
		ButtonUpSelected = false;
		ButtonDownSelected = false;
		ButtonDropDownSelected = false;
		if (num)
		{
			RedrawControlButtons();
		}
	}

	public override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (ButtonDownSelected || ButtonUpSelected || ButtonDropDownSelected)
		{
			IgnoreDeactivation();
		}
		if (ButtonDownSelected && ButtonDownEnabled)
		{
			ButtonDownPressed = true;
			ScrollDown();
		}
		if (ButtonUpSelected && ButtonUpEnabled)
		{
			ButtonUpPressed = true;
			ScrollUp();
		}
		if (ButtonDropDownSelected)
		{
			ButtonDropDownPressed = true;
			ShowDropDown();
		}
		if (ThumbSelected)
		{
			ThumbPressed = true;
			_thumbOffset = e.Y - _thumbBounds.Y;
		}
		if (ScrollType == ListScrollType.Scrollbar && ScrollBarBounds.Contains(e.Location) && e.Y >= ButtonUpBounds.Bottom && e.Y <= ButtonDownBounds.Y && !ThumbBounds.Contains(e.Location) && !ButtonDownBounds.Contains(e.Location) && !ButtonUpBounds.Contains(e.Location))
		{
			if (e.Y < ThumbBounds.Y)
			{
				ScrollOffset(ContentBounds.Height);
			}
			else
			{
				ScrollOffset(-ContentBounds.Height);
			}
		}
	}

	public override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		ButtonDownPressed = false;
		ButtonUpPressed = false;
		ButtonDropDownPressed = false;
		ThumbPressed = false;
	}

	public override void OnClick(EventArgs e)
	{
		if (!(base.Canvas is RibbonPopup))
		{
			base.OnClick(e);
		}
	}

	public void OnDropDownItemClicked(ref RibbonItemEventArgs e)
	{
		if (this.DropDownItemClicked != null)
		{
			this.DropDownItemClicked(e.Item, e);
		}
	}

	public void OnButtonItemClicked(ref RibbonItemEventArgs e)
	{
		if (this.ButtonItemClicked != null)
		{
			this.ButtonItemClicked(e.Item, e);
		}
	}

	internal void item_Click(object sender, EventArgs e)
	{
		_selectedItem = sender as RibbonItem;
		RibbonItemEventArgs e2 = new RibbonItemEventArgs(_selectedItem);
		if (DropDownItems.Contains(_selectedItem))
		{
			OnDropDownItemClicked(ref e2);
		}
		else
		{
			OnButtonItemClicked(ref e2);
		}
	}

	public IEnumerable<RibbonItem> GetItems()
	{
		return Buttons;
	}

	public Rectangle GetContentBounds()
	{
		return ContentBounds;
	}

	public IEnumerable<Component> GetAllChildComponents()
	{
		List<Component> list = new List<Component>(Buttons.ToArray());
		list.AddRange(DropDownItems.ToArray());
		return list;
	}
}

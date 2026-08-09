using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;

namespace System.Windows.Forms;

[ToolboxItem(false)]
public class RibbonDropDown : RibbonPopup, IScrollableRibbonItem
{
	private bool _showSizingGrip;

	private bool _ignoreNext;

	private bool _resizing;

	private Point _resizeOrigin;

	private Size _resizeSize;

	private Rectangle _thumbBounds;

	private Rectangle _fullContentBounds;

	private int _scrollValue;

	private bool _avoidNextThumbMeasure;

	private int _jumpDownSize;

	private int _jumpUpSize;

	private int _offset;

	private int _thumbOffset;

	public int DropDownMaxHeight { get; set; }

	public int ScrollBarSize { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Control Canvas => this;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ScrollBarBounds => Rectangle.FromLTRB(ButtonUpBounds.Left, ButtonUpBounds.Top, ButtonDownBounds.Right, ButtonDownBounds.Bottom);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ScrollBarEnabled { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ScrolledPercent
	{
		get
		{
			if ((double)_fullContentBounds.Height > (double)ContentBounds.Height)
			{
				return ((double)ContentBounds.Top - (double)_fullContentBounds.Top) / ((double)_fullContentBounds.Height - (double)ContentBounds.Height);
			}
			return 0.0;
		}
		set
		{
			_avoidNextThumbMeasure = true;
			ScrollTo(-Convert.ToInt32((double)(_fullContentBounds.Height - ContentBounds.Height) * value));
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ScrollMinimum => ButtonUpBounds.Bottom;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ScrollMaximum => ButtonDownBounds.Top - ThumbBounds.Height;

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
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonUpEnabled { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonDownEnabled { get; private set; }

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
	public Rectangle ContentBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ButtonUpPressed { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ButtonUpBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ButtonDownBounds { get; private set; }

	public bool DrawIconsBar { get; set; }

	internal ISelectionService SelectionService { get; set; }

	public Rectangle SizingGripBounds { get; private set; }

	public RibbonElementSizeMode MeasuringSize { get; set; }

	public RibbonItem ParentItem { get; }

	public RibbonMouseSensor Sensor { get; }

	public Ribbon OwnerRibbon { get; }

	public IEnumerable<RibbonItem> Items { get; }

	public bool ShowSizingGrip
	{
		get
		{
			return _showSizingGrip;
		}
		set
		{
			_showSizingGrip = value;
			UpdateSize();
		}
	}

	[DefaultValue(12)]
	public int SizingGripHeight { get; set; }

	private RibbonDropDown()
	{
		DoubleBuffered = true;
		DrawIconsBar = true;
	}

	internal RibbonDropDown(RibbonItem parentItem, IEnumerable<RibbonItem> items, Ribbon ownerRibbon)
		: this(parentItem, items, ownerRibbon, RibbonElementSizeMode.DropDown)
	{
	}

	internal RibbonDropDown(RibbonItem parentItem, IEnumerable<RibbonItem> items, Ribbon ownerRibbon, RibbonElementSizeMode measuringSize)
		: this()
	{
		Items = items;
		OwnerRibbon = ownerRibbon;
		SizingGripHeight = 12;
		ParentItem = parentItem;
		Sensor = new RibbonMouseSensor(this, OwnerRibbon, items);
		MeasuringSize = measuringSize;
		ScrollBarSize = 16;
		if (Items != null)
		{
			foreach (RibbonItem item in Items)
			{
				item.SetSizeMode(RibbonElementSizeMode.DropDown);
				item.SetCanvas(this);
				if (item is RibbonHost)
				{
					((RibbonHost)item).ClientMouseMove += OnRibbonHostMouseMove;
				}
			}
		}
		UpdateSize();
	}

	private void RedrawScroll()
	{
		if (Canvas != null)
		{
			Canvas.Invalidate(Rectangle.FromLTRB(ButtonDownBounds.X, ButtonUpBounds.Y, ButtonDownBounds.Right, ButtonDownBounds.Bottom));
		}
	}

	public void SetBounds()
	{
		if (ShowSizingGrip)
		{
			SizingGripBounds = Rectangle.FromLTRB(base.ClientSize.Width - SizingGripHeight, base.ClientSize.Height - SizingGripHeight, base.ClientSize.Width, base.ClientSize.Height);
		}
		else
		{
			SizingGripBounds = Rectangle.Empty;
		}
		if (ScrollBarEnabled)
		{
			int scrollBarSize = ScrollBarSize;
			int scrollBarSize2 = ScrollBarSize;
			_thumbBounds.Width = ScrollBarSize;
			ButtonUpBounds = new Rectangle(base.Bounds.Right - scrollBarSize - 1, base.Bounds.Top + OwnerRibbon.DropDownMargin.Top, scrollBarSize, scrollBarSize2);
			ButtonDownBounds = new Rectangle(ButtonUpBounds.Left, base.Bounds.Height - scrollBarSize2 - SizingGripBounds.Height - OwnerRibbon.DropDownMargin.Bottom - 1, scrollBarSize, scrollBarSize2);
			_thumbBounds.X = ButtonUpBounds.Left;
			ButtonUpEnabled = _offset < 0;
			if (!ButtonUpEnabled)
			{
				_offset = 0;
			}
			ButtonDownEnabled = false;
		}
		int num = (ScrollBarEnabled ? ScrollBarSize : 0);
		int num2 = Math.Max(0, base.ClientSize.Width - OwnerRibbon.DropDownMargin.Horizontal - num);
		ContentBounds = Rectangle.FromLTRB(OwnerRibbon.DropDownMargin.Left, OwnerRibbon.DropDownMargin.Top, base.Bounds.Right - num - OwnerRibbon.DropDownMargin.Right, base.Bounds.Bottom - OwnerRibbon.DropDownMargin.Bottom - SizingGripBounds.Height);
		int num3 = OwnerRibbon.DropDownMargin.Top + _offset;
		int left = OwnerRibbon.DropDownMargin.Left;
		int num4 = num3;
		int top = num3;
		foreach (RibbonItem item in Items)
		{
			item.SetBounds(Rectangle.Empty);
		}
		foreach (RibbonItem item2 in Items)
		{
			num3 = num4;
			item2.SetBounds(new Rectangle(left, num3, num2, item2.LastMeasuredSize.Height));
			num4 = num3 + item2.LastMeasuredSize.Height;
			_jumpDownSize = item2.Bounds.Height;
			_jumpUpSize = item2.Bounds.Height;
		}
		_fullContentBounds = Rectangle.FromLTRB(ContentBounds.Left, top, ContentBounds.Right, num4);
		_ = base.Bounds.Height;
		if (ContentBounds.Height < _fullContentBounds.Height)
		{
			double num5 = ((_fullContentBounds.Height > ContentBounds.Height) ? ((double)ContentBounds.Height / (double)_fullContentBounds.Height) : 0.0);
			double num6 = ButtonDownBounds.Top - ButtonUpBounds.Bottom;
			double num7 = Math.Ceiling(num5 * num6);
			if (num7 < 30.0)
			{
				num7 = ((!(num6 >= 30.0)) ? num6 : 30.0);
			}
			ButtonUpEnabled = _offset < 0;
			ButtonDownEnabled = ScrollMaximum > -_offset;
			_thumbBounds.Height = Convert.ToInt32(num7);
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

	public void ScrollDown()
	{
		if (ScrollBarEnabled)
		{
			ScrollOffset(-(_jumpDownSize + 1));
		}
	}

	public void ScrollUp()
	{
		if (ScrollBarEnabled)
		{
			ScrollOffset(_jumpUpSize + 1);
		}
	}

	private void ScrollOffset(int amount)
	{
		ScrollTo(_offset + amount);
	}

	private void ScrollTo(int offset)
	{
		if (ScrollBarEnabled)
		{
			int num = ContentBounds.Height - _fullContentBounds.Height;
			if (offset < num)
			{
				offset = num;
			}
			_offset = offset;
			SetBounds();
			Invalidate();
		}
	}

	public void IgnoreNextClickDeactivation()
	{
		_ignoreNext = true;
	}

	private void UpdateSize()
	{
		int num = OwnerRibbon.DropDownMargin.Vertical;
		int num2 = 0;
		int num3 = 0;
		using (Graphics graphics = CreateGraphics())
		{
			foreach (RibbonItem item in Items)
			{
				Size size = item.MeasureSize(this, new RibbonElementMeasureSizeEventArgs(graphics, MeasuringSize));
				num += size.Height;
				num2 = Math.Max(num2, size.Width + OwnerRibbon.DropDownMargin.Horizontal);
				if (item is IScrollableRibbonItem)
				{
					num3 += size.Height;
				}
			}
		}
		if ((DropDownMaxHeight > 0 && DropDownMaxHeight < num && !_resizing) || num + (ShowSizingGrip ? (SizingGripHeight + 2) : 0) + 1 > Screen.PrimaryScreen.WorkingArea.Height)
		{
			num = ((DropDownMaxHeight <= 0) ? (Screen.PrimaryScreen.WorkingArea.Height - ((ShowSizingGrip ? (SizingGripHeight + 2) : 0) + 1)) : DropDownMaxHeight);
			num2 += ScrollBarSize;
			_thumbBounds.Width = ScrollBarSize;
			ScrollBarEnabled = true;
		}
		if (!_resizing)
		{
			Size size2 = new Size(num2, num + (ShowSizingGrip ? (SizingGripHeight + 2) : 0));
			base.Size = size2;
		}
		if (base.WrappedDropDown != null)
		{
			base.WrappedDropDown.Size = base.Size;
		}
		SetBounds();
	}

	private void IgnoreDeactivation()
	{
		if (Canvas is RibbonPanelPopup)
		{
			(Canvas as RibbonPanelPopup).IgnoreNextClickDeactivation();
		}
		if (Canvas is RibbonDropDown)
		{
			(Canvas as RibbonDropDown).IgnoreNextClickDeactivation();
		}
	}

	protected override void OnOpening(CancelEventArgs e)
	{
		base.OnOpening(e);
		SetBounds();
	}

	protected override void OnShowed(EventArgs e)
	{
		base.OnShowed(e);
		if (!(ParentItem is RibbonButton))
		{
			return;
		}
		foreach (RibbonItem item in Items)
		{
			item.SetSelected(selected: false);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (Cursor == Cursors.SizeNWSE)
		{
			_resizeOrigin = new Point(e.X, e.Y);
			_resizeSize = base.Size;
			_resizing = true;
		}
		if (ButtonDownSelected || ButtonUpSelected)
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
		if (ThumbSelected)
		{
			ThumbPressed = true;
			_thumbOffset = e.Y - _thumbBounds.Y;
		}
		if (ScrollBarBounds.Contains(e.Location) && e.Y >= ButtonUpBounds.Bottom && e.Y <= ButtonDownBounds.Y && !ThumbBounds.Contains(e.Location) && !ButtonDownBounds.Contains(e.Location) && !ButtonUpBounds.Contains(e.Location))
		{
			if (e.Y < ThumbBounds.Y)
			{
				ScrollOffset(base.Bounds.Height);
			}
			else
			{
				ScrollOffset(-base.Bounds.Height);
			}
		}
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		base.OnMouseClick(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (ShowSizingGrip && SizingGripBounds.Contains(e.X, e.Y))
		{
			Cursor = Cursors.SizeNWSE;
		}
		else if (Cursor == Cursors.SizeNWSE)
		{
			Cursor = Cursors.Default;
		}
		if (_resizing)
		{
			int num = e.X - _resizeOrigin.X;
			int num2 = e.Y - _resizeOrigin.Y;
			int num3 = _resizeSize.Width + num;
			int num4 = _resizeSize.Height + num2;
			if (num3 != base.Width || num4 != base.Height)
			{
				base.Size = new Size(num3, num4);
				if (base.WrappedDropDown != null)
				{
					base.WrappedDropDown.Size = base.Size;
				}
				int num5 = base.Bounds.Height - OwnerRibbon.DropDownMargin.Vertical - SizingGripBounds.Height;
				if (num5 < _fullContentBounds.Height)
				{
					ScrollBarEnabled = true;
					if (-_offset + num5 > _fullContentBounds.Height)
					{
						_offset = num5 - _fullContentBounds.Height;
					}
				}
				else
				{
					ScrollBarEnabled = false;
				}
				SetBounds();
				Invalidate();
			}
		}
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
		bool thumbSelected = ThumbSelected;
		ButtonUpSelected = ButtonUpBounds.Contains(e.Location);
		ButtonDownSelected = ButtonDownBounds.Contains(e.Location);
		ThumbSelected = _thumbBounds.Contains(e.Location) && ScrollBarEnabled;
		if (buttonUpSelected != ButtonUpSelected || buttonDownSelected != ButtonDownSelected || thumbSelected != ThumbSelected)
		{
			Invalidate();
		}
		if (ThumbPressed)
		{
			int num6 = e.Y - _thumbOffset;
			if (num6 < ScrollMinimum)
			{
				num6 = ScrollMinimum;
			}
			else if (num6 > ScrollMaximum)
			{
				num6 = ScrollMaximum;
			}
			ScrollValue = num6;
			Invalidate();
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		ButtonDownPressed = false;
		ButtonUpPressed = false;
		ThumbPressed = false;
		if (_resizing)
		{
			_resizing = false;
		}
		else if (_ignoreNext)
		{
			_ignoreNext = false;
		}
		else if (RibbonDesigner.Current != null)
		{
			Close();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		OwnerRibbon.Renderer.OnRenderDropDownBackground(new RibbonCanvasEventArgs(OwnerRibbon, e.Graphics, new Rectangle(Point.Empty, base.ClientSize), this, ParentItem));
		RectangleF clipBounds = e.Graphics.ClipBounds;
		RectangleF clip = clipBounds;
		clip.Y = OwnerRibbon.DropDownMargin.Top;
		clip.Height = base.Bounds.Bottom - SizingGripBounds.Height - OwnerRibbon.DropDownMargin.Vertical;
		e.Graphics.SetClip(clip);
		foreach (RibbonItem item in Items)
		{
			if ((item is RibbonButton && !(item is RibbonDescriptionMenuItem)) || (item is RibbonSeparator && ((RibbonSeparator)item).DropDownWidth == RibbonSeparatorDropDownWidth.Partial))
			{
				OwnerRibbon.Renderer.OnRenderDropDownDropDownImageSeparator(item, new RibbonCanvasEventArgs(OwnerRibbon, e.Graphics, new Rectangle(Point.Empty, base.ClientSize), this, ParentItem));
			}
			if (item.Bounds.IntersectsWith(ContentBounds))
			{
				item.OnPaint(this, new RibbonElementPaintEventArgs(item.Bounds, e.Graphics, RibbonElementSizeMode.DropDown));
			}
		}
		if (ScrollBarEnabled)
		{
			OwnerRibbon.Renderer.OnRenderScrollbar(e.Graphics, this, OwnerRibbon);
		}
		e.Graphics.SetClip(clipBounds);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		foreach (RibbonItem item in Items)
		{
			item.SetSelected(selected: false);
		}
	}

	private void OnRibbonHostMouseMove(object sender, MouseEventArgs e)
	{
		OnMouseMove(e);
	}
}

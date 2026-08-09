using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text.RegularExpressions;

namespace System.Windows.Forms;

[Designer(typeof(RibbonButtonDesigner))]
public class RibbonButton : RibbonItem, IContainsRibbonComponents
{
	public delegate void RibbonItemEventHandler(object sender, RibbonItemEventArgs e);

	private const int arrowWidth = 5;

	private RibbonButtonStyle _style;

	private Image _smallImage;

	private Image _flashSmallImage;

	private Size _dropDownArrowSize;

	private Padding _dropDownMargin;

	private Point _lastMousePos;

	private RibbonArrowDirection _dropDownArrowDirection;

	private RibbonItem _selectedItem;

	private readonly Set<RibbonItem> _assignedHandlers;

	private Size _minimumSize;

	private Size _maximumSize;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonItem SelectedItem
	{
		get
		{
			if (_selectedItem == null)
			{
				return null;
			}
			if (DropDownItems.Contains(_selectedItem))
			{
				return _selectedItem;
			}
			_selectedItem = null;
			return null;
		}
		set
		{
			if (value.GetType().BaseType == typeof(RibbonItem))
			{
				if (DropDownItems.Contains(value))
				{
					_selectedItem = value;
					return;
				}
				DropDownItems.Add(value);
				_selectedItem = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedValue
	{
		get
		{
			if (_selectedItem == null)
			{
				return null;
			}
			return _selectedItem.Value;
		}
		set
		{
			foreach (RibbonItem dropDownItem in DropDownItems)
			{
				if (dropDownItem.Value == value)
				{
					_selectedItem = dropDownItem;
				}
			}
		}
	}

	internal RibbonDropDown DropDown { get; private set; }

	[Category("Drop Down")]
	[DefaultValue(true)]
	[Description("Gets or sets if the icon bar on a drop down should be drawn")]
	public bool DrawDropDownIconsBar { get; set; }

	[DefaultValue(false)]
	[Category("Behavior")]
	[Description("Toggles the Checked property of the button when clicked")]
	public bool CheckOnClick { get; set; }

	[Category("Drop Down")]
	[DefaultValue(false)]
	[Description("Makes the DropDown resizable with a grip on the corner")]
	public bool DropDownResizable { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle ImageBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle TextBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DropDownVisible { get; private set; }

	[Browsable(false)]
	[DefaultValue(typeof(Size), "5, 3")]
	public Size DropDownArrowSize
	{
		get
		{
			return _dropDownArrowSize;
		}
		set
		{
			_dropDownArrowSize = value;
			NotifyOwnerRegionsChanged();
		}
	}

	[Category("Drop Down")]
	[DefaultValue(RibbonArrowDirection.Down)]
	public RibbonArrowDirection DropDownArrowDirection
	{
		get
		{
			return _dropDownArrowDirection;
		}
		set
		{
			_dropDownArrowDirection = value;
			NotifyOwnerRegionsChanged();
		}
	}

	[DefaultValue(RibbonButtonStyle.Normal)]
	[Category("Appearance")]
	[Description("Indicates the visual style of the button.")]
	public RibbonButtonStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			_style = value;
			if (base.Canvas is RibbonPopup || (base.OwnerItem != null && base.OwnerItem.Canvas is RibbonPopup))
			{
				DropDownArrowDirection = RibbonArrowDirection.Left;
			}
			NotifyOwnerRegionsChanged();
		}
	}

	[Category("Drop Down")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RibbonItemCollection DropDownItems { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Rectangle ButtonFaceBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public Rectangle DropDownBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DropDownSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DropDownPressed { get; private set; }

	[DefaultValue(null)]
	[Category("Appearance")]
	[Description("sets the image of the button when in large size mode.")]
	public virtual Image LargeImage
	{
		get
		{
			return base.Image;
		}
		set
		{
			base.Image = value;
		}
	}

	[Browsable(false)]
	[Category("Appearance")]
	public override Image Image
	{
		get
		{
			return base.Image;
		}
		set
		{
			base.Image = value;
		}
	}

	[DefaultValue(null)]
	[Category("Appearance")]
	[Description("sets the image of the button when in compact, medium or dropdown size modes.")]
	public virtual Image SmallImage
	{
		get
		{
			return _smallImage;
		}
		set
		{
			if (_smallImage != value)
			{
				_smallImage = value;
				NotifyOwnerRegionsChanged();
			}
		}
	}

	[Category("Flash")]
	[DefaultValue(null)]
	public virtual Image FlashSmallImage
	{
		get
		{
			return _flashSmallImage;
		}
		set
		{
			if (_flashSmallImage != value)
			{
				_flashSmallImage = value;
			}
		}
	}

	[DefaultValue(typeof(Size), "0, 0")]
	[Category("Appearance")]
	[Description("Sets the minimum size for this Item.  Only applies when in Large Size Mode.")]
	public Size MinimumSize
	{
		get
		{
			return _minimumSize;
		}
		set
		{
			_minimumSize = value;
			NotifyOwnerRegionsChanged();
		}
	}

	[DefaultValue(typeof(Size), "0, 0")]
	[Category("Appearance")]
	[Description("Sets the maximum size for this Item.  Only applies when in Large Size Mode.")]
	public Size MaximumSize
	{
		get
		{
			return _maximumSize;
		}
		set
		{
			_maximumSize = value;
			NotifyOwnerRegionsChanged();
		}
	}

	public event EventHandler DropDownShowing;

	public event RibbonItemEventHandler DropDownItemClicked;

	public virtual void OnDropDownItemClicked(ref RibbonItemEventArgs e)
	{
		if (this.DropDownItemClicked != null)
		{
			this.DropDownItemClicked(this, e);
		}
	}

	public RibbonButton()
	{
		_style = RibbonButtonStyle.Normal;
		_dropDownArrowDirection = RibbonArrowDirection.Down;
		_assignedHandlers = new Set<RibbonItem>();
		DropDownItems = new RibbonItemCollection();
		DropDownItems.SetOwnerItem(this);
		_dropDownArrowSize = new Size(5, 3);
		_dropDownMargin = new Padding(6);
		Image = CreateImage(32);
		SmallImage = CreateImage(16);
		DrawDropDownIconsBar = true;
	}

	public RibbonButton(string text)
		: this()
	{
		Text = text;
	}

	public RibbonButton(Image smallImage)
		: this()
	{
		SmallImage = smallImage;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && RibbonDesigner.Current == null)
		{
			RemoveHandlers();
		}
		base.Dispose(disposing);
	}

	protected void SetDropDownMargin(Padding p)
	{
		_dropDownMargin = p;
	}

	public void PerformClick()
	{
		OnClick(EventArgs.Empty);
	}

	private Image CreateImage(int size)
	{
		return new Bitmap(size, size);
	}

	protected virtual void CreateDropDown()
	{
		DropDown = new RibbonDropDown(this, DropDownItems, base.Owner);
	}

	internal override void SetPressed(bool pressed)
	{
		base.SetPressed(pressed);
	}

	internal override void SetOwner(Ribbon owner)
	{
		base.SetOwner(owner);
		if (DropDownItems != null)
		{
			DropDownItems.SetOwner(owner);
		}
	}

	internal override void SetOwnerPanel(RibbonPanel ownerPanel)
	{
		base.SetOwnerPanel(ownerPanel);
		if (DropDownItems != null)
		{
			DropDownItems.SetOwnerPanel(ownerPanel);
		}
	}

	internal override void SetOwnerTab(RibbonTab ownerTab)
	{
		base.SetOwnerTab(ownerTab);
		if (DropDownItems != null)
		{
			DropDownItems.SetOwnerTab(ownerTab);
		}
	}

	internal override void SetOwnerItem(RibbonItem ownerItem)
	{
		base.SetOwnerItem(ownerItem);
	}

	internal override void ClearOwner()
	{
		List<RibbonItem> list = ((DropDownItems == null) ? null : new List<RibbonItem>(DropDownItems));
		base.ClearOwner();
		if (list == null)
		{
			return;
		}
		foreach (RibbonItem item in list)
		{
			item.ClearOwner();
		}
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		if (base.Owner != null)
		{
			OnPaintBackground(e);
			OnPaintImage(e);
			OnPaintText(e);
		}
	}

	protected virtual void OnPaintText(RibbonElementPaintEventArgs e)
	{
		if (base.SizeMode == RibbonElementSizeMode.Compact)
		{
			return;
		}
		StringFormat stringFormat = StringFormatFactory.NearCenter();
		if (base.Owner.AltPressed || base.Owner.OrbDropDown.MenuItems.Contains(this))
		{
			stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
		}
		else
		{
			stringFormat.HotkeyPrefix = HotkeyPrefix.Hide;
		}
		if (base.SizeMode == RibbonElementSizeMode.Large)
		{
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Near;
		}
		if (Style == RibbonButtonStyle.DropDownListItem)
		{
			stringFormat.LineAlignment = StringAlignment.Near;
			base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, e.Clip, this, base.Bounds, Text, stringFormat));
			return;
		}
		string text = Text;
		if (!string.IsNullOrEmpty(base.AltKey) && Text.Contains(base.AltKey))
		{
			text = new Regex(Regex.Escape(base.AltKey), RegexOptions.IgnoreCase).Replace(Text.Replace("&", ""), "&" + base.AltKey, 1).Replace("&&", "&");
		}
		base.Owner.Renderer.OnRenderRibbonItemText(new RibbonTextEventArgs(base.Owner, e.Graphics, e.Clip, this, TextBounds, text, stringFormat));
	}

	private void OnPaintImage(RibbonElementPaintEventArgs e)
	{
		RibbonElementSizeMode nearestSize = GetNearestSize(e.Mode);
		if (_showFlashImage)
		{
			if ((nearestSize == RibbonElementSizeMode.Large && base.FlashImage != null) || FlashSmallImage != null)
			{
				base.Owner.Renderer.OnRenderRibbonItemImage(new RibbonItemBoundsEventArgs(base.Owner, e.Graphics, e.Clip, this, OnGetImageBounds(nearestSize, base.Bounds)));
			}
		}
		else if ((nearestSize == RibbonElementSizeMode.Large && Image != null) || SmallImage != null)
		{
			base.Owner.Renderer.OnRenderRibbonItemImage(new RibbonItemBoundsEventArgs(base.Owner, e.Graphics, e.Clip, this, OnGetImageBounds(nearestSize, base.Bounds)));
		}
	}

	private void OnPaintBackground(RibbonElementPaintEventArgs e)
	{
		base.Owner.Renderer.OnRenderRibbonItem(new RibbonItemRenderEventArgs(base.Owner, e.Graphics, e.Clip, this));
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
		RibbonElementSizeMode nearestSize = GetNearestSize(base.SizeMode);
		ImageBounds = OnGetImageBounds(nearestSize, bounds);
		TextBounds = OnGetTextBounds(nearestSize, bounds);
		if (Style == RibbonButtonStyle.SplitDropDown)
		{
			DropDownBounds = OnGetDropDownBounds(nearestSize, bounds);
			ButtonFaceBounds = OnGetButtonFaceBounds(nearestSize, bounds);
		}
	}

	internal virtual Rectangle OnGetImageBounds(RibbonElementSizeMode sMode, Rectangle bounds)
	{
		if (sMode == RibbonElementSizeMode.Large)
		{
			if (Image != null)
			{
				return new Rectangle(base.Bounds.Left + (base.Bounds.Width - Image.Width) / 2, base.Bounds.Top + base.Owner.ItemMargin.Top, Image.Width, Image.Height);
			}
			return new Rectangle(ContentBounds.Location, new Size(32, 32));
		}
		if (SmallImage != null && SmallImage.PixelFormat != PixelFormat.Undefined)
		{
			return new Rectangle(base.Bounds.Left + base.Owner.ItemMargin.Left, base.Bounds.Top + (base.Bounds.Height - SmallImage.Height) / 2, SmallImage.Width, SmallImage.Height);
		}
		return new Rectangle(ContentBounds.Location, new Size(0, 0));
	}

	internal virtual Rectangle OnGetTextBounds(RibbonElementSizeMode sMode, Rectangle bounds)
	{
		int width = ImageBounds.Width;
		int height = ImageBounds.Height;
		if (sMode == RibbonElementSizeMode.Large)
		{
			return Rectangle.FromLTRB(base.Bounds.Left + base.Owner.ItemMargin.Left, base.Bounds.Top + base.Owner.ItemMargin.Top + height, base.Bounds.Right - base.Owner.ItemMargin.Right, base.Bounds.Bottom - base.Owner.ItemMargin.Bottom);
		}
		int num = ((Style != RibbonButtonStyle.Normal && Style != RibbonButtonStyle.DropDownListItem) ? _dropDownMargin.Horizontal : 0);
		int num2 = ((sMode == RibbonElementSizeMode.DropDown) ? base.Owner.ItemImageToTextSpacing : 0);
		return Rectangle.FromLTRB(base.Bounds.Left + width + base.Owner.ItemMargin.Horizontal + base.Owner.ItemMargin.Left + num2, base.Bounds.Top + base.Owner.ItemMargin.Top, base.Bounds.Right - num, base.Bounds.Bottom - base.Owner.ItemMargin.Bottom);
	}

	internal virtual Rectangle OnGetDropDownBounds(RibbonElementSizeMode sMode, Rectangle bounds)
	{
		Rectangle result = Rectangle.FromLTRB(bounds.Right - _dropDownMargin.Horizontal - 2, bounds.Top, bounds.Right, bounds.Bottom);
		switch (sMode)
		{
		case RibbonElementSizeMode.Overflow:
		case RibbonElementSizeMode.Large:
			return Rectangle.FromLTRB(bounds.Left, bounds.Top + Image.Height + base.Owner.ItemMargin.Vertical, bounds.Right, bounds.Bottom);
		case RibbonElementSizeMode.Compact:
		case RibbonElementSizeMode.Medium:
		case RibbonElementSizeMode.DropDown:
			return result;
		default:
			return Rectangle.Empty;
		}
	}

	internal virtual Rectangle OnGetButtonFaceBounds(RibbonElementSizeMode sMode, Rectangle bounds)
	{
		Rectangle.FromLTRB(bounds.Right - _dropDownMargin.Horizontal - 2, bounds.Top, bounds.Right, bounds.Bottom);
		switch (sMode)
		{
		case RibbonElementSizeMode.Overflow:
		case RibbonElementSizeMode.Large:
			return Rectangle.FromLTRB(bounds.Left, bounds.Top, bounds.Right, DropDownBounds.Top);
		case RibbonElementSizeMode.Compact:
		case RibbonElementSizeMode.Medium:
		case RibbonElementSizeMode.DropDown:
			return Rectangle.FromLTRB(bounds.Left, bounds.Top, DropDownBounds.Left, bounds.Bottom);
		default:
			return Rectangle.Empty;
		}
	}

	public static Size MeasureStringLargeSize(Graphics g, string text, Font font)
	{
		if (string.IsNullOrEmpty(text))
		{
			return Size.Empty;
		}
		Size size = g.MeasureString(text, font).ToSize();
		string[] array = text.Split(' ');
		string text2 = string.Empty;
		int width = size.Width;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Length > text2.Length)
			{
				text2 = array[i];
			}
		}
		if (array.Length > 1)
		{
			width = Math.Max(size.Width / 2, g.MeasureString(text2, font).ToSize().Width) + 1;
			Size size2 = g.MeasureString(text, font, width).ToSize();
			return new Size(size2.Width, size2.Height);
		}
		return g.MeasureString(text, font).ToSize();
	}

	public override Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e)
	{
		if (!Visible && !base.Owner.IsDesignMode())
		{
			SetLastMeasuredSize(new Size(0, 0));
			return base.LastMeasuredSize;
		}
		RibbonElementSizeMode nearestSize = GetNearestSize(e.SizeMode);
		int num = base.Owner.ItemMargin.Horizontal;
		int vertical = base.Owner.ItemMargin.Vertical;
		int val = ((base.OwnerPanel != null) ? (base.OwnerPanel.ContentBounds.Height - base.Owner.ItemPadding.Vertical) : 0);
		Size size = ((SmallImage != null) ? SmallImage.Size : Size.Empty);
		Size size2 = ((Image != null) ? Image.Size : Size.Empty);
		Size empty = Size.Empty;
		switch (nearestSize)
		{
		case RibbonElementSizeMode.Overflow:
		case RibbonElementSizeMode.Large:
			empty = MeasureStringLargeSize(e.Graphics, Text, base.Owner.Font);
			if (!string.IsNullOrEmpty(Text))
			{
				num += Math.Max(empty.Width + 1, size2.Width);
				vertical = Math.Max(0, val);
			}
			else
			{
				num += size2.Width;
				vertical += size2.Height;
			}
			break;
		case RibbonElementSizeMode.DropDown:
			empty = Size.Ceiling(e.Graphics.MeasureString(Text, base.Owner.Font));
			if (!string.IsNullOrEmpty(Text))
			{
				num += empty.Width + 1;
			}
			num += size.Width + base.Owner.ItemMargin.Horizontal + base.Owner.ItemImageToTextSpacing;
			vertical += Math.Max(empty.Height, size.Height);
			break;
		case RibbonElementSizeMode.Medium:
			empty = Size.Ceiling(e.Graphics.MeasureString(Text, base.Owner.Font));
			if (!string.IsNullOrEmpty(Text))
			{
				num += empty.Width + 1;
			}
			num += size.Width + base.Owner.ItemMargin.Horizontal;
			vertical += Math.Max(empty.Height, size.Height);
			break;
		case RibbonElementSizeMode.Compact:
			num += size.Width;
			vertical += size.Height;
			break;
		default:
			throw new ArgumentException("SizeMode not supported: " + e.SizeMode);
		}
		switch (Style)
		{
		case RibbonButtonStyle.DropDown:
		case RibbonButtonStyle.SplitDropDown:
			num += 5 + _dropDownMargin.Horizontal;
			break;
		}
		if (nearestSize == RibbonElementSizeMode.Large)
		{
			if (MinimumSize.Height > 0 && vertical < MinimumSize.Height)
			{
				vertical = MinimumSize.Height;
			}
			if (MinimumSize.Width > 0 && num < MinimumSize.Width)
			{
				num = MinimumSize.Width;
			}
			if (MaximumSize.Height > 0 && vertical > MaximumSize.Height)
			{
				vertical = MaximumSize.Height;
			}
			if (MaximumSize.Width > 0 && num > MaximumSize.Width)
			{
				num = MaximumSize.Width;
			}
		}
		SetLastMeasuredSize(new Size(num, vertical));
		return base.LastMeasuredSize;
	}

	internal void SetDropDownPressed(bool pressed)
	{
		throw new NotSupportedException();
	}

	internal void SetDropDownSelected(bool selected)
	{
		throw new NotSupportedException();
	}

	public void ShowDropDown()
	{
		if (Style == RibbonButtonStyle.Normal)
		{
			if (DropDown != null)
			{
				RibbonPopupManager.DismissChildren(DropDown, RibbonPopupManager.DismissReason.NewPopup);
			}
			return;
		}
		if (Style == RibbonButtonStyle.DropDown)
		{
			SetPressed(pressed: true);
		}
		else
		{
			DropDownPressed = true;
		}
		OnDropDownShowing(EventArgs.Empty);
		if (DropDownItems.Count == 0)
		{
			if (DropDown != null)
			{
				RibbonPopupManager.DismissChildren(DropDown, RibbonPopupManager.DismissReason.NewPopup);
			}
			return;
		}
		AssignHandlers();
		CreateDropDown();
		DropDown.MouseEnter += DropDown_MouseEnter;
		DropDown.Closed += DropDown_Closed;
		DropDown.ShowSizingGrip = DropDownResizable;
		DropDown.DrawIconsBar = DrawDropDownIconsBar;
		_ = base.Canvas;
		Point screenLocation = OnGetDropDownMenuLocation();
		Size minimumSize = OnGetDropDownMenuSize();
		if (!minimumSize.IsEmpty)
		{
			DropDown.MinimumSize = minimumSize;
		}
		SetDropDownVisible(visible: true);
		DropDown.SelectionService = GetService(typeof(ISelectionService)) as ISelectionService;
		DropDown.Show(screenLocation);
	}

	private void DropDownItem_Click(object sender, EventArgs e)
	{
		_selectedItem = sender as RibbonItem;
		RibbonItemEventArgs e2 = new RibbonItemEventArgs(sender as RibbonItem);
		OnDropDownItemClicked(ref e2);
	}

	private void AssignHandlers()
	{
		foreach (RibbonItem dropDownItem in DropDownItems)
		{
			if (!_assignedHandlers.Contains(dropDownItem))
			{
				dropDownItem.Click += DropDownItem_Click;
				_assignedHandlers.Add(dropDownItem);
			}
		}
	}

	private void RemoveHandlers()
	{
		if (DropDown != null)
		{
			DropDown.MouseEnter -= DropDown_MouseEnter;
			DropDown.Closed -= DropDown_Closed;
		}
		foreach (RibbonItem assignedHandler in _assignedHandlers)
		{
			assignedHandler.Click -= DropDownItem_Click;
		}
		_assignedHandlers.Clear();
	}

	private void DropDown_MouseEnter(object sender, EventArgs e)
	{
		SetSelected(selected: true);
		RedrawItem();
	}

	internal virtual Point OnGetDropDownMenuLocation()
	{
		Point empty = Point.Empty;
		if (base.Canvas is RibbonDropDown)
		{
			return base.Canvas.PointToScreen(new Point(base.Bounds.Right, base.Bounds.Top));
		}
		return base.Canvas.PointToScreen(new Point(base.Bounds.Left, base.Bounds.Bottom));
	}

	internal virtual Size OnGetDropDownMenuSize()
	{
		return Size.Empty;
	}

	private void DropDown_Closed(object sender, EventArgs e)
	{
		SetPressed(pressed: false);
		DropDownPressed = false;
		SetDropDownVisible(visible: false);
		SetSelected(selected: false);
		DropDownSelected = false;
		RedrawItem();
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

	public void CloseDropDown()
	{
		if (DropDown != null)
		{
			RibbonPopupManager.Dismiss(DropDown, RibbonPopupManager.DismissReason.NewPopup);
			RemoveHandlers();
			DropDown = null;
		}
		SetDropDownVisible(visible: false);
	}

	public override string ToString()
	{
		return string.Format("{1}: {0}", Text, GetType().Name);
	}

	internal void SetDropDownVisible(bool visible)
	{
		DropDownVisible = visible;
	}

	public void OnDropDownShowing(EventArgs e)
	{
		if (this.DropDownShowing != null)
		{
			this.DropDownShowing(this, e);
		}
	}

	public override void OnCanvasChanged(EventArgs e)
	{
		base.OnCanvasChanged(e);
		if (base.Canvas is RibbonDropDown)
		{
			DropDownArrowDirection = RibbonArrowDirection.Left;
		}
	}

	protected override bool ClosesDropDownAt(Point p)
	{
		if (Style == RibbonButtonStyle.DropDown)
		{
			return false;
		}
		if (Style == RibbonButtonStyle.SplitDropDown)
		{
			return ButtonFaceBounds.Contains(p);
		}
		return true;
	}

	internal override void SetSizeMode(RibbonElementSizeMode sizeMode)
	{
		if (sizeMode == RibbonElementSizeMode.Overflow)
		{
			base.SetSizeMode(RibbonElementSizeMode.Large);
		}
		else
		{
			base.SetSizeMode(sizeMode);
		}
	}

	internal override void SetSelected(bool selected)
	{
		base.SetSelected(selected);
		SetPressed(pressed: false);
	}

	public override void OnMouseDown(MouseEventArgs e)
	{
		if (!Enabled)
		{
			return;
		}
		if ((DropDownSelected || Style == RibbonButtonStyle.DropDown) && DropDownItems.Count > 0)
		{
			if (!DropDownVisible)
			{
				DropDownPressed = true;
				ShowDropDown();
			}
			else
			{
				DropDownPressed = false;
				CloseDropDown();
			}
		}
		base.OnMouseDown(e);
	}

	public override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
	}

	public override void OnMouseMove(MouseEventArgs e)
	{
		if (!Enabled)
		{
			return;
		}
		if (Style == RibbonButtonStyle.SplitDropDown)
		{
			bool dropDownSelected = DropDownSelected;
			if (DropDownBounds.Contains(e.X, e.Y))
			{
				DropDownSelected = true;
			}
			else
			{
				DropDownSelected = false;
			}
			if (dropDownSelected != DropDownSelected)
			{
				RedrawItem();
			}
			_ = DropDownSelected;
		}
		_lastMousePos = new Point(e.X, e.Y);
		base.OnMouseMove(e);
	}

	public override void OnMouseLeave(MouseEventArgs e)
	{
		base.OnMouseLeave(e);
		DropDownSelected = false;
	}

	public override void OnClick(EventArgs e)
	{
		if (Style == RibbonButtonStyle.Normal || Style == RibbonButtonStyle.DropDownListItem || ButtonFaceBounds.Contains(_lastMousePos))
		{
			if (CheckOnClick)
			{
				Checked = !Checked;
			}
			base.OnClick(e);
		}
	}

	public IEnumerable<RibbonItem> GetItems()
	{
		return DropDownItems;
	}

	public IEnumerable<Component> GetAllChildComponents()
	{
		return DropDownItems.ToArray();
	}
}

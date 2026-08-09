using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;

namespace System.Windows.Forms;

[DesignTimeVisible(false)]
public abstract class RibbonItem : Component, IRibbonElement, IRibbonToolTip
{
	public enum RibbonItemTextAlignment
	{
		Left = 0,
		Right = 2,
		Center = 1
	}

	private bool? _isopeninvisualstudiodesigner;

	private string _text;

	private Image _image;

	private bool _checked;

	private bool _selected;

	private bool _pressed;

	private bool _enabled;

	private object _tag;

	private string _value;

	private string _altKey;

	private RibbonElementSizeMode _maxSize;

	private RibbonElementSizeMode _minSize;

	private Control _canvas;

	private bool _visible;

	private RibbonItemTextAlignment _textAlignment;

	private bool _flashEnabled;

	private int _flashIntervall = 1000;

	private Image _flashImage;

	private readonly Timer _flashTimer = new Timer();

	protected bool _showFlashImage;

	private readonly RibbonToolTip _TT;

	private static RibbonToolTip _lastActiveToolTip;

	private string _tooltip;

	private string _checkedGroup;

	private string _name = string.Empty;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public virtual string Name
	{
		get
		{
			if (Site != null)
			{
				_name = Site.Name;
			}
			return _name;
		}
		set
		{
			if (_name != value)
			{
				_name = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Rectangle ContentBounds
	{
		get
		{
			if (Owner == null)
			{
				return Rectangle.Empty;
			}
			return Rectangle.FromLTRB(Bounds.Left + Owner.ItemMargin.Left, Bounds.Top + Owner.ItemMargin.Top, Bounds.Right - Owner.ItemMargin.Right, Bounds.Bottom - Owner.ItemMargin.Bottom);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Control Canvas
	{
		get
		{
			if (_canvas != null && !_canvas.IsDisposed)
			{
				return _canvas;
			}
			return Owner;
		}
	}

	[DefaultValue(false)]
	[Category("Flash")]
	public bool FlashEnabled
	{
		get
		{
			return _flashEnabled;
		}
		set
		{
			if (_flashEnabled != value)
			{
				_flashEnabled = value;
				if (_flashEnabled)
				{
					_showFlashImage = false;
					_flashTimer.Interval = _flashIntervall;
					_flashTimer.Enabled = true;
				}
				else
				{
					_flashTimer.Enabled = false;
					_showFlashImage = false;
					NotifyOwnerRegionsChanged();
				}
			}
		}
	}

	[DefaultValue(1000)]
	[Category("Flash")]
	public int FlashIntervall
	{
		get
		{
			return _flashIntervall;
		}
		set
		{
			if (_flashIntervall != value)
			{
				_flashIntervall = value;
			}
		}
	}

	[DefaultValue(null)]
	[Category("Flash")]
	public Image FlashImage
	{
		get
		{
			return _flashImage;
		}
		set
		{
			if (_flashImage != value)
			{
				_flashImage = value;
			}
		}
	}

	[DefaultValue(false)]
	[Browsable(false)]
	public bool ShowFlashImage
	{
		get
		{
			return _showFlashImage;
		}
		set
		{
			if (_showFlashImage != value)
			{
				_showFlashImage = value;
			}
		}
	}

	[DefaultValue(null)]
	[Category("Appearance")]
	[Localizable(true)]
	public virtual string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (_text != value)
			{
				_text = value;
				NotifyOwnerRegionsChanged();
			}
		}
	}

	[DefaultValue(null)]
	[Category("Appearance")]
	public virtual Image Image
	{
		get
		{
			return _image;
		}
		set
		{
			_image = value;
			NotifyOwnerRegionsChanged();
		}
	}

	[DefaultValue(true)]
	[Category("Behavior")]
	public virtual bool Visible
	{
		get
		{
			if (_visible && Owner != null && !Owner.IsDesignMode())
			{
				if (OwnerItem != null && !OwnerItem.Visible)
				{
					return false;
				}
				if (OwnerPanel != null && !OwnerPanel.Visible)
				{
					return false;
				}
			}
			return _visible;
		}
		set
		{
			if (_visible != value)
			{
				_visible = value;
				NotifyOwnerRegionsChanged();
			}
		}
	}

	[DefaultValue(false)]
	[Category("Appearance")]
	[Description("Indicates whether the component is in the checked state.")]
	public virtual bool Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			if (_checked == value)
			{
				return;
			}
			_checked = value;
			if (value)
			{
				if (Canvas is RibbonDropDown)
				{
					foreach (RibbonItem item in ((RibbonDropDown)Canvas).Items)
					{
						if (item.CheckedGroup == _checkedGroup && item.Checked && item != this)
						{
							item.Checked = false;
							item.RedrawItem();
						}
					}
				}
				else if (OwnerPanel != null && _checkedGroup != null)
				{
					foreach (RibbonItem item2 in OwnerPanel.Items)
					{
						if (item2.CheckedGroup == _checkedGroup && item2.Checked && item2 != this)
						{
							item2.Checked = false;
							item2.RedrawItem();
						}
					}
				}
			}
			NotifyOwnerRegionsChanged();
		}
	}

	[DefaultValue(null)]
	[Category("Behavior")]
	[Description("Determins the other Ribbon Items that belong to this checked group.  When one button is checked the other items in this group will be unchecked automatically.  This only applies to Items that are within the same Parent")]
	public virtual string CheckedGroup
	{
		get
		{
			return _checkedGroup;
		}
		set
		{
			if (_checkedGroup != value)
			{
				_checkedGroup = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonElementSizeMode SizeMode { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool Selected => _selected;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool Pressed => _pressed;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Ribbon Owner { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle Bounds { get; private set; }

	[DefaultValue(true)]
	[Category("Behavior")]
	public virtual bool Enabled
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
			if (_enabled == value)
			{
				return;
			}
			_enabled = value;
			if (this is IContainsSelectableRibbonItems containsSelectableRibbonItems)
			{
				foreach (RibbonItem item in containsSelectableRibbonItems.GetItems())
				{
					item.Enabled = value;
				}
			}
			NotifyOwnerRegionsChanged();
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
			if (_TT.ToolTipTitle != value)
			{
				_TT.ToolTipTitle = value;
			}
		}
	}

	[DefaultValue(ToolTipIcon.None)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolTipIcon ToolTipIcon
	{
		get
		{
			return _TT.ToolTipIcon;
		}
		set
		{
			if (_TT.ToolTipIcon != value)
			{
				_TT.ToolTipIcon = value;
			}
		}
	}

	[DefaultValue(null)]
	[Localizable(true)]
	public string ToolTip
	{
		get
		{
			return _tooltip;
		}
		set
		{
			if (_tooltip != value)
			{
				_tooltip = value;
			}
		}
	}

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
			if (_TT.ToolTipImage != value)
			{
				_TT.ToolTipImage = value;
			}
		}
	}

	[Description("An Object field for associating custom data for this control")]
	[DefaultValue(null)]
	[Category("Data")]
	[TypeConverter(typeof(StringConverter))]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			if (_tag != value)
			{
				_tag = value;
			}
		}
	}

	[DefaultValue(null)]
	[Category("Data")]
	[Description("A string field for associating custom data for this control")]
	public string Value
	{
		get
		{
			return _value;
		}
		set
		{
			if (_value != value)
			{
				_value = value;
			}
		}
	}

	[DefaultValue(null)]
	[Category("Behavior")]
	public string AltKey
	{
		get
		{
			return _altKey;
		}
		set
		{
			if (_altKey != value)
			{
				_altKey = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonTab OwnerTab { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonPanel OwnerPanel { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonItem OwnerItem { get; private set; }

	[DefaultValue(RibbonElementSizeMode.None)]
	[Category("Appearance")]
	[Description("Sets the maximum size mode of the element.")]
	public RibbonElementSizeMode MaxSizeMode
	{
		get
		{
			return _maxSize;
		}
		set
		{
			if (_maxSize != value)
			{
				_maxSize = value;
				NotifyOwnerRegionsChanged();
			}
		}
	}

	[DefaultValue(RibbonElementSizeMode.None)]
	[Category("Appearance")]
	[Description("Sets the minimum size mode of the element.")]
	public RibbonElementSizeMode MinSizeMode
	{
		get
		{
			return _minSize;
		}
		set
		{
			if (_minSize != value)
			{
				_minSize = value;
				NotifyOwnerRegionsChanged();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Size LastMeasuredSize { get; private set; }

	[DefaultValue(RibbonItemTextAlignment.Left)]
	[Category("Appearance")]
	public RibbonItemTextAlignment TextAlignment
	{
		get
		{
			return _textAlignment;
		}
		set
		{
			if (_textAlignment != value)
			{
				_textAlignment = value;
				NotifyOwnerRegionsChanged();
			}
		}
	}

	public virtual event EventHandler DoubleClick;

	public virtual event EventHandler Click;

	public virtual event MouseEventHandler MouseUp;

	public virtual event MouseEventHandler MouseMove;

	public virtual event MouseEventHandler MouseDown;

	public virtual event MouseEventHandler MouseEnter;

	public virtual event MouseEventHandler MouseLeave;

	public virtual event EventHandler CanvasChanged;

	public virtual event EventHandler OwnerChanged;

	public virtual event RibbonElementPopupEventHandler ToolTipPopUp;

	public RibbonItem()
	{
		_enabled = true;
		_visible = true;
		Click += RibbonItem_Click;
		_flashTimer.Tick += _flashTimer_Tick;
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
			_flashTimer.Enabled = false;
			_TT.Popup -= _TT_Popup;
			_TT.Dispose();
		}
		base.Dispose(disposing);
	}

	private void RibbonItem_Click(object sender, EventArgs e)
	{
		if (Canvas is RibbonDropDown { SelectionService: not null } ribbonDropDown)
		{
			ribbonDropDown.SelectionService.SetSelectedComponents(new Component[1] { this }, SelectionTypes.Click);
		}
	}

	private void _flashTimer_Tick(object sender, EventArgs e)
	{
		_showFlashImage = !_showFlashImage;
		NotifyOwnerRegionsChanged();
	}

	protected virtual bool ClosesDropDownAt(Point p)
	{
		return true;
	}

	protected void NotifyOwnerRegionsChanged()
	{
		if (Owner == null)
		{
			return;
		}
		if (Owner == Canvas)
		{
			Owner.OnRegionsChanged();
		}
		else if (Canvas != null)
		{
			if (Canvas is RibbonOrbDropDown)
			{
				(Canvas as RibbonOrbDropDown).OnRegionsChanged();
			}
			else
			{
				Canvas.Invalidate(Bounds);
			}
		}
	}

	internal virtual void SetOwnerItem(RibbonItem item)
	{
		OwnerItem = item;
	}

	internal virtual void SetOwner(Ribbon owner)
	{
		Owner = owner;
		OnOwnerChanged(EventArgs.Empty);
	}

	internal virtual void SetOwnerPanel(RibbonPanel ownerPanel)
	{
		OwnerPanel = ownerPanel;
	}

	internal virtual void SetSelected(bool selected)
	{
		if (Enabled)
		{
			_selected = selected;
		}
	}

	internal virtual void SetPressed(bool pressed)
	{
		_pressed = pressed;
	}

	internal virtual void SetOwnerTab(RibbonTab ownerTab)
	{
		OwnerTab = ownerTab;
	}

	internal virtual void ClearOwner()
	{
		OwnerItem = null;
		OwnerPanel = null;
		OwnerTab = null;
		Owner = null;
		OnOwnerChanged(EventArgs.Empty);
	}

	protected RibbonElementSizeMode GetNearestSize(RibbonElementSizeMode sizeMode)
	{
		int maxSizeMode = (int)MaxSizeMode;
		int minSizeMode = (int)MinSizeMode;
		int result = (int)sizeMode;
		if (maxSizeMode > 0 && (int)sizeMode > maxSizeMode)
		{
			result = maxSizeMode;
		}
		if (minSizeMode > 0 && (int)sizeMode < minSizeMode)
		{
			result = minSizeMode;
		}
		return (RibbonElementSizeMode)result;
	}

	protected void SetLastMeasuredSize(Size size)
	{
		LastMeasuredSize = size;
	}

	internal virtual void SetSizeMode(RibbonElementSizeMode sizeMode)
	{
		SizeMode = GetNearestSize(sizeMode);
	}

	public virtual void OnCanvasChanged(EventArgs e)
	{
		if (this.CanvasChanged != null)
		{
			this.CanvasChanged(this, e);
		}
	}

	public virtual void OnOwnerChanged(EventArgs e)
	{
		if (this.OwnerChanged != null)
		{
			this.OwnerChanged(this, e);
		}
	}

	public virtual void OnMouseEnter(MouseEventArgs e)
	{
		if (Enabled && this.MouseEnter != null)
		{
			this.MouseEnter(this, e);
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
		}
	}

	public virtual void OnMouseLeave(MouseEventArgs e)
	{
		if (Enabled)
		{
			DeactivateToolTip(_TT);
			if (this.MouseLeave != null)
			{
				this.MouseLeave(this, e);
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
			if (Pressed)
			{
				SetPressed(pressed: false);
				RedrawItem();
			}
		}
	}

	public virtual void OnMouseMove(MouseEventArgs e)
	{
		if (!Enabled)
		{
			return;
		}
		if (this.MouseMove != null)
		{
			this.MouseMove(this, e);
		}
		if (!Selected)
		{
			SetSelected(selected: true);
			Owner.Invalidate(Bounds);
		}
		if (!_TT.Active && !string.IsNullOrEmpty(ToolTip))
		{
			DeactivateToolTip(_lastActiveToolTip);
			if (ToolTip != _TT.GetToolTip(Canvas))
			{
				_TT.SetToolTip(Canvas, ToolTip);
			}
			_TT.Active = true;
			_lastActiveToolTip = null;
			_lastActiveToolTip = _TT;
		}
	}

	public virtual void OnClick(EventArgs e)
	{
		if (Enabled)
		{
			if (ClosesDropDownAt(Canvas.PointToClient(Cursor.Position)))
			{
				DeactivateToolTip(_TT);
				RibbonPopupManager.Dismiss(RibbonPopupManager.DismissReason.ItemClicked);
			}
			SetSelected(selected: false);
			if (this.Click != null)
			{
				this.Click(this, e);
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

	public virtual void RedrawItem()
	{
		if (Canvas != null)
		{
			Canvas.Invalidate(Rectangle.Inflate(Bounds, 1, 1));
		}
	}

	internal void SetCanvas(Control canvas)
	{
		_canvas = canvas;
		SetCanvas(this as IContainsSelectableRibbonItems, canvas);
		OnCanvasChanged(EventArgs.Empty);
	}

	private void SetCanvas(IContainsSelectableRibbonItems parent, Control canvas)
	{
		if (parent == null)
		{
			return;
		}
		foreach (RibbonItem item in parent.GetItems())
		{
			item.SetCanvas(canvas);
		}
	}

	private void _TT_Popup(object sender, PopupEventArgs e)
	{
		if (this.ToolTipPopUp != null)
		{
			this.ToolTipPopUp(sender, new RibbonElementPopupEventArgs(this, e));
			if (ToolTip != _TT.GetToolTip(Canvas))
			{
				_TT.SetToolTip(Canvas, ToolTip);
			}
		}
	}

	private void DeactivateToolTip(RibbonToolTip toolTip)
	{
		if (toolTip != null)
		{
			toolTip.Active = false;
			toolTip.RemoveAll();
		}
	}

	public abstract void OnPaint(object sender, RibbonElementPaintEventArgs e);

	public virtual void SetBounds(Rectangle bounds)
	{
		Bounds = bounds;
	}

	public abstract Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e);
}

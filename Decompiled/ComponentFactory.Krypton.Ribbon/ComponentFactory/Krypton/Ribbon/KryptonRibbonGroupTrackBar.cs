using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupTrackBar), "ToolboxBitmaps.KryptonRibbonGroupTrackBar.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTrackBarDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("ValueChanged")]
[DefaultProperty("Value")]
public class KryptonRibbonGroupTrackBar : KryptonRibbonGroupItem
{
	private bool _visible;

	private bool _enabled;

	private string _keyTip;

	private int _minimumLength;

	private int _maximumLength;

	private GroupItemSize _itemSizeCurrent;

	private NeedPaintHandler _viewPaintDelegate;

	private KryptonTrackBar _trackBar;

	private KryptonTrackBar _lastTrackBar;

	private IKryptonDesignObject _designer;

	private Control _lastParentControl;

	private ViewBase _trackBarView;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override KryptonRibbon Ribbon
	{
		set
		{
			base.Ribbon = value;
			if (value != null)
			{
				_trackBar.Palette = Ribbon.GetResolvedPalette();
				Ribbon.PaletteChanged += OnRibbonPaletteChanged;
			}
		}
	}

	[Description("Access to the actual embedded KryptonTrackBar instance.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonTrackBar TrackBar => _trackBar;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group track bar key tip.")]
	[DefaultValue("T")]
	public string KeyTip
	{
		get
		{
			return _keyTip;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "T";
			}
			_keyTip = value.ToUpper();
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the track bar is visible or hidden.")]
	[DefaultValue(true)]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			if (value != _visible)
			{
				_visible = value;
				OnPropertyChanged("Visible");
			}
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the group track bar is enabled.")]
	[DefaultValue(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (_enabled != value)
			{
				_enabled = value;
				OnPropertyChanged("Enabled");
			}
		}
	}

	[Category("Layout")]
	[Description("Specifies the minimum length of the control.")]
	[DefaultValue("55")]
	public int MinimumLength
	{
		get
		{
			return _minimumLength;
		}
		set
		{
			_minimumLength = value;
			if (Orientation == Orientation.Horizontal)
			{
				_trackBar.MinimumSize = new Size(_minimumLength, 0);
			}
			else
			{
				_trackBar.MinimumSize = new Size(0, _minimumLength);
			}
		}
	}

	[Category("Layout")]
	[Description("Specifies the maximum length of the control.")]
	[DefaultValue("50")]
	public int MaximumLength
	{
		get
		{
			return _maximumLength;
		}
		set
		{
			_maximumLength = value;
			if (Orientation == Orientation.Horizontal)
			{
				_trackBar.MaximumSize = new Size(_maximumLength, 0);
			}
			else
			{
				_trackBar.MaximumSize = new Size(0, _maximumLength);
			}
		}
	}

	[Category("Behavior")]
	[Description("The shortcut to display when the user right-clicks the control.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _trackBar.ContextMenuStrip;
		}
		set
		{
			_trackBar.ContextMenuStrip = value;
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the text box is right clicked.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _trackBar.KryptonContextMenu;
		}
		set
		{
			_trackBar.KryptonContextMenu = value;
		}
	}

	[Category("Appearance")]
	[Description("Determines size of the track bar elements.")]
	[DefaultValue(typeof(PaletteTrackBarSize), "Medium")]
	public PaletteTrackBarSize TrackBarSize
	{
		get
		{
			return _trackBar.TrackBarSize;
		}
		set
		{
			_trackBar.TrackBarSize = value;
		}
	}

	[Category("Appearance")]
	[Description("Determines where tick marks are displayed.")]
	[DefaultValue(typeof(TickStyle), "None")]
	[RefreshProperties(RefreshProperties.All)]
	public TickStyle TickStyle
	{
		get
		{
			return _trackBar.TickStyle;
		}
		set
		{
			_trackBar.TickStyle = value;
		}
	}

	[Category("Appearance")]
	[Description("Determines the frequency of tick marks.")]
	[DefaultValue(1)]
	public int TickFrequency
	{
		get
		{
			return _trackBar.TickFrequency;
		}
		set
		{
			_trackBar.TickFrequency = value;
		}
	}

	[Category("Appearance")]
	[Description("Determines if the control display like a volume control.")]
	[DefaultValue(false)]
	public bool VolumeControl
	{
		get
		{
			return _trackBar.VolumeControl;
		}
		set
		{
			_trackBar.VolumeControl = value;
		}
	}

	[Category("Appearance")]
	[Description("Background style.")]
	[DefaultValue(typeof(Orientation), "Horizontal")]
	[RefreshProperties(RefreshProperties.All)]
	public Orientation Orientation
	{
		get
		{
			return _trackBar.Orientation;
		}
		set
		{
			if (value != _trackBar.Orientation)
			{
				_trackBar.Orientation = value;
				if (Orientation == Orientation.Horizontal)
				{
					_trackBar.MinimumSize = new Size(_minimumLength, 0);
					_trackBar.MaximumSize = new Size(_maximumLength, 0);
				}
				else
				{
					_trackBar.MinimumSize = new Size(0, _minimumLength);
					_trackBar.MaximumSize = new Size(0, _maximumLength);
				}
			}
		}
	}

	[Category("Behavior")]
	[Description("Upper limit of the trackbar range.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(10)]
	public int Maximum
	{
		get
		{
			return _trackBar.Maximum;
		}
		set
		{
			_trackBar.Maximum = value;
		}
	}

	[Category("Behavior")]
	[Description("Lower limit of the trackbar range.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(0)]
	public int Minimum
	{
		get
		{
			return _trackBar.Minimum;
		}
		set
		{
			_trackBar.Minimum = value;
		}
	}

	[Category("Behavior")]
	[Description("Current position of the indicator within the trackbar.")]
	[DefaultValue(0)]
	public int Value
	{
		get
		{
			return _trackBar.Value;
		}
		set
		{
			_trackBar.Value = value;
		}
	}

	[Category("Behavior")]
	[Description("Change to apply when a small change occurs.")]
	[DefaultValue(1)]
	public int SmallChange
	{
		get
		{
			return _trackBar.SmallChange;
		}
		set
		{
			_trackBar.SmallChange = value;
		}
	}

	[Category("Behavior")]
	[Description("Change to apply when a large change occurs.")]
	[DefaultValue(5)]
	public int LargeChange
	{
		get
		{
			return _trackBar.LargeChange;
		}
		set
		{
			_trackBar.LargeChange = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMaximum
	{
		get
		{
			return GroupItemSize.Large;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeMinimum
	{
		get
		{
			return GroupItemSize.Small;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override GroupItemSize ItemSizeCurrent
	{
		get
		{
			return _itemSizeCurrent;
		}
		set
		{
			if (_itemSizeCurrent != value)
			{
				_itemSizeCurrent = value;
				OnPropertyChanged("ItemSizeCurrent");
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public IKryptonDesignObject TrackBarDesigner
	{
		get
		{
			return _designer;
		}
		set
		{
			_designer = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public ViewBase TrackBarView
	{
		get
		{
			return _trackBarView;
		}
		set
		{
			_trackBarView = value;
		}
	}

	internal Control LastParentControl
	{
		get
		{
			return _lastParentControl;
		}
		set
		{
			_lastParentControl = value;
		}
	}

	internal KryptonTrackBar LastTrackBar
	{
		get
		{
			return _lastTrackBar;
		}
		set
		{
			_lastTrackBar = value;
		}
	}

	internal NeedPaintHandler ViewPaintDelegate
	{
		get
		{
			return _viewPaintDelegate;
		}
		set
		{
			_viewPaintDelegate = value;
		}
	}

	[Browsable(false)]
	public event EventHandler GotFocus;

	[Browsable(false)]
	public event EventHandler LostFocus;

	[Category("Action")]
	[Description("Occurs when the value of the Value property changes.")]
	public event EventHandler ValueChanged;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	internal event EventHandler MouseEnterControl;

	internal event EventHandler MouseLeaveControl;

	public KryptonRibbonGroupTrackBar()
	{
		_visible = true;
		_enabled = true;
		_itemSizeCurrent = GroupItemSize.Medium;
		_keyTip = "T";
		_minimumLength = 55;
		_maximumLength = 55;
		_trackBar = new KryptonTrackBar();
		_trackBar.DrawBackground = false;
		_trackBar.TickStyle = TickStyle.None;
		_trackBar.MinimumSize = new Size(_minimumLength, 0);
		_trackBar.MaximumSize = new Size(_maximumLength, 0);
		_trackBar.TabStop = false;
		_trackBar.GotFocus += OnTrackBarGotFocus;
		_trackBar.LostFocus += OnTrackBarLostFocus;
		_trackBar.ValueChanged += OnTrackBarValueChanged;
		MonitorControl(_trackBar);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _trackBar != null)
		{
			UnmonitorControl(_trackBar);
			_trackBar.Dispose();
			_trackBar = null;
		}
		base.Dispose(disposing);
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	public void SetRange(int minValue, int maxValue)
	{
		_trackBar.SetRange(minValue, maxValue);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupTrackBar(ribbon, this, needPaint);
	}

	protected virtual void OnGotFocus(EventArgs e)
	{
		if (this.GotFocus != null)
		{
			this.GotFocus(this, e);
		}
	}

	protected virtual void OnLostFocus(EventArgs e)
	{
		if (this.LostFocus != null)
		{
			this.LostFocus(this, e);
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	internal void OnDesignTimeContextMenu(MouseEventArgs e)
	{
		if (this.DesignTimeContextMenu != null)
		{
			this.DesignTimeContextMenu(this, e);
		}
	}

	internal override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		return false;
	}

	private void MonitorControl(KryptonTrackBar c)
	{
		c.MouseEnter += OnControlEnter;
		c.MouseLeave += OnControlLeave;
	}

	private void UnmonitorControl(KryptonTrackBar c)
	{
		c.MouseEnter -= OnControlEnter;
		c.MouseLeave -= OnControlLeave;
	}

	private void OnControlEnter(object sender, EventArgs e)
	{
		if (this.MouseEnterControl != null)
		{
			this.MouseEnterControl(this, e);
		}
	}

	private void OnControlLeave(object sender, EventArgs e)
	{
		if (this.MouseLeaveControl != null)
		{
			this.MouseLeaveControl(this, e);
		}
	}

	private void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (_viewPaintDelegate != null)
		{
			_viewPaintDelegate(this, e);
		}
	}

	private void OnTrackBarGotFocus(object sender, EventArgs e)
	{
		OnGotFocus(e);
	}

	private void OnTrackBarLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
	}

	private void OnTrackBarValueChanged(object sender, EventArgs e)
	{
		if (this.ValueChanged != null)
		{
			this.ValueChanged(this, e);
		}
	}

	private void OnRibbonPaletteChanged(object sender, EventArgs e)
	{
		_trackBar.Palette = Ribbon.GetResolvedPalette();
	}
}

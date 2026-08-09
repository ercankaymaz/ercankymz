using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupNumericUpDown), "ToolboxBitmaps.KryptonRibbonGroupNumericUpDown.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupNumericUpDownDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("ValueChanged")]
[DefaultProperty("Value")]
public class KryptonRibbonGroupNumericUpDown : KryptonRibbonGroupItem
{
	private bool _visible;

	private bool _enabled;

	private string _keyTip;

	private Keys _shortcutKeys;

	private GroupItemSize _itemSizeCurrent;

	private NeedPaintHandler _viewPaintDelegate;

	private KryptonNumericUpDown _numericUpDown;

	private KryptonNumericUpDown _lastNumericUpDown;

	private IKryptonDesignObject _designer;

	private Control _lastParentControl;

	private ViewBase _numericUpDownView;

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
				_numericUpDown.Palette = Ribbon.GetResolvedPalette();
				Ribbon.PaletteChanged += OnRibbonPaletteChanged;
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to set focus to the numeric up-down.")]
	public Keys ShortcutKeys
	{
		get
		{
			return _shortcutKeys;
		}
		set
		{
			_shortcutKeys = value;
		}
	}

	[Description("Access to the actual embedded KryptonNumericUpDown instance.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonNumericUpDown NumericUpDown => _numericUpDown;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group numeric up-down key tip.")]
	[DefaultValue("X")]
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
				value = "X";
			}
			_keyTip = value.ToUpper();
		}
	}

	[Category("Data")]
	[Description("Indicates the number of decimal places to display.")]
	[DefaultValue(0)]
	public int DecimalPlaces
	{
		get
		{
			return _numericUpDown.DecimalPlaces;
		}
		set
		{
			_numericUpDown.DecimalPlaces = value;
		}
	}

	[Category("Data")]
	[Description("Indicates the amount to increment or decrement one each button click.")]
	[DefaultValue(typeof(decimal), "1")]
	public decimal Increment
	{
		get
		{
			return _numericUpDown.Increment;
		}
		set
		{
			_numericUpDown.Increment = value;
		}
	}

	[Category("Data")]
	[Description("Indicates the maximum value for the numeric up-down control.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(decimal), "100")]
	public decimal Maximum
	{
		get
		{
			return _numericUpDown.Maximum;
		}
		set
		{
			_numericUpDown.Maximum = value;
		}
	}

	[Category("Data")]
	[Description("Indicates the minimum value for the numeric up-down control.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(decimal), "0")]
	public decimal Minimum
	{
		get
		{
			return _numericUpDown.Minimum;
		}
		set
		{
			_numericUpDown.Minimum = value;
		}
	}

	[Category("Data")]
	[Description("Indicates whether the thousands separator wil be inserted between each three decimal digits.")]
	[DefaultValue(false)]
	[Localizable(true)]
	public bool ThousandsSeparator
	{
		get
		{
			return _numericUpDown.ThousandsSeparator;
		}
		set
		{
			_numericUpDown.ThousandsSeparator = value;
		}
	}

	[Category("Appearance")]
	[Description("The current value of the numeric up-down control.")]
	[DefaultValue(typeof(decimal), "0")]
	[Bindable(true)]
	public decimal Value
	{
		get
		{
			return _numericUpDown.Value;
		}
		set
		{
			_numericUpDown.Value = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates how the text should be aligned for edit controls.")]
	[DefaultValue(typeof(HorizontalAlignment), "Left")]
	[Localizable(true)]
	public HorizontalAlignment TextAlign
	{
		get
		{
			return _numericUpDown.TextAlign;
		}
		set
		{
			_numericUpDown.TextAlign = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates wheather the numeric up-down should display its value in hexadecimal.")]
	[DefaultValue(false)]
	public bool Hexadecimal
	{
		get
		{
			return _numericUpDown.Hexadecimal;
		}
		set
		{
			_numericUpDown.Hexadecimal = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates how the up-down control will position the up down buttons relative to its text box.")]
	[DefaultValue(typeof(LeftRightAlignment), "Right")]
	[Localizable(true)]
	public LeftRightAlignment UpDownAlign
	{
		get
		{
			return _numericUpDown.UpDownAlign;
		}
		set
		{
			_numericUpDown.UpDownAlign = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the up-down control will increment and decrement the value when the UP ARROW and DOWN ARROW are used.")]
	[DefaultValue(true)]
	public bool InterceptArrowKeys
	{
		get
		{
			return _numericUpDown.InterceptArrowKeys;
		}
		set
		{
			_numericUpDown.InterceptArrowKeys = value;
		}
	}

	[Category("Behavior")]
	[Description("Controls whether the text in the edit control can be changed or not.")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue(false)]
	public bool ReadOnly
	{
		get
		{
			return _numericUpDown.ReadOnly;
		}
		set
		{
			_numericUpDown.ReadOnly = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonNumericUpDown.NumericUpDownButtonSpecCollection ButtonSpecs => _numericUpDown.ButtonSpecs;

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the numeric up-down is visible or hidden.")]
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
	[Description("Determines whether the group numeric up-down is enabled.")]
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
	[Description("Specifies the minimum size of the control.")]
	[DefaultValue(typeof(Size), "121, 0")]
	public Size MinimumSize
	{
		get
		{
			return _numericUpDown.MinimumSize;
		}
		set
		{
			_numericUpDown.MinimumSize = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies the maximum size of the control.")]
	[DefaultValue(typeof(Size), "121, 0")]
	public Size MaximumSize
	{
		get
		{
			return _numericUpDown.MaximumSize;
		}
		set
		{
			_numericUpDown.MaximumSize = value;
		}
	}

	[Category("Behavior")]
	[Description("The shortcut to display when the user right-clicks the control.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _numericUpDown.ContextMenuStrip;
		}
		set
		{
			_numericUpDown.ContextMenuStrip = value;
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the numeric up down is right clicked.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _numericUpDown.KryptonContextMenu;
		}
		set
		{
			_numericUpDown.KryptonContextMenu = value;
		}
	}

	[Category("Visuals")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _numericUpDown.AllowButtonSpecToolTips;
		}
		set
		{
			_numericUpDown.AllowButtonSpecToolTips = value;
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
	public IKryptonDesignObject NumericUpDownDesigner
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
	public ViewBase NumericUpDownView
	{
		get
		{
			return _numericUpDownView;
		}
		set
		{
			_numericUpDownView = value;
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

	internal KryptonNumericUpDown LastNumericUpDown
	{
		get
		{
			return _lastNumericUpDown;
		}
		set
		{
			_lastNumericUpDown = value;
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

	[Description("Occurs when the value of the Value property changes.")]
	[Category("Property Changed")]
	public event EventHandler ValueChanged;

	[Browsable(false)]
	public event EventHandler GotFocus;

	[Browsable(false)]
	public event EventHandler LostFocus;

	[Description("Occurs when a key is pressed while the control has focus.")]
	[Category("Key")]
	public event KeyPressEventHandler KeyPress;

	[Description("Occurs when a key is released while the control has focus.")]
	[Category("Key")]
	public event KeyEventHandler KeyUp;

	[Description("Occurs when a key is pressed while the control has focus.")]
	[Category("Key")]
	public event KeyEventHandler KeyDown;

	[Description("Occurs before the KeyDown event when a key is pressed while focus is on this control.")]
	[Category("Key")]
	public event PreviewKeyDownEventHandler PreviewKeyDown;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	internal event EventHandler MouseEnterControl;

	internal event EventHandler MouseLeaveControl;

	public KryptonRibbonGroupNumericUpDown()
	{
		_visible = true;
		_enabled = true;
		_itemSizeCurrent = GroupItemSize.Medium;
		_shortcutKeys = Keys.None;
		_keyTip = "X";
		_numericUpDown = new KryptonNumericUpDown();
		_numericUpDown.InputControlStyle = InputControlStyle.Ribbon;
		_numericUpDown.AlwaysActive = false;
		_numericUpDown.MinimumSize = new Size(121, 0);
		_numericUpDown.MaximumSize = new Size(121, 0);
		_numericUpDown.TabStop = false;
		_numericUpDown.ValueChanged += OnNumericUpDownValueChanged;
		_numericUpDown.GotFocus += OnNumericUpDownGotFocus;
		_numericUpDown.LostFocus += OnNumericUpDownLostFocus;
		_numericUpDown.KeyDown += OnNumericUpDownKeyDown;
		_numericUpDown.KeyUp += OnNumericUpDownKeyUp;
		_numericUpDown.KeyPress += OnNumericUpDownKeyPress;
		_numericUpDown.PreviewKeyDown += OnNumericUpDownPreviewKeyDown;
		MonitorControl(_numericUpDown);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _numericUpDown != null)
		{
			UnmonitorControl(_numericUpDown);
			_numericUpDown.Dispose();
			_numericUpDown = null;
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeShortcutKeys()
	{
		return ShortcutKeys != Keys.None;
	}

	public void ResetShortcutKeys()
	{
		ShortcutKeys = Keys.None;
	}

	public void Show()
	{
		Visible = true;
	}

	public void Hide()
	{
		Visible = false;
	}

	public void Select(int start, int length)
	{
		_numericUpDown.Select(start, length);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupNumericUpDown(ribbon, this, needPaint);
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

	protected virtual void OnKeyDown(KeyEventArgs e)
	{
		if (this.KeyDown != null)
		{
			this.KeyDown(this, e);
		}
	}

	protected virtual void OnKeyUp(KeyEventArgs e)
	{
		if (this.KeyUp != null)
		{
			this.KeyUp(this, e);
		}
	}

	protected virtual void OnKeyPress(KeyPressEventArgs e)
	{
		if (this.KeyPress != null)
		{
			this.KeyPress(this, e);
		}
	}

	protected virtual void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
	{
		if (this.PreviewKeyDown != null)
		{
			this.PreviewKeyDown(this, e);
		}
	}

	protected virtual void OnValueChanged(EventArgs e)
	{
		if (this.ValueChanged != null)
		{
			this.ValueChanged(this, e);
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
		if (Enabled && base.ChainVisible && ShortcutKeys != Keys.None && ShortcutKeys == keyData)
		{
			if (LastNumericUpDown != null && LastNumericUpDown.CanFocus)
			{
				LastNumericUpDown.NumericUpDown.Focus();
			}
			return true;
		}
		return false;
	}

	private void MonitorControl(KryptonNumericUpDown c)
	{
		c.MouseEnter += OnControlEnter;
		c.MouseLeave += OnControlLeave;
		c.TrackMouseEnter += OnControlEnter;
		c.TrackMouseLeave += OnControlLeave;
	}

	private void UnmonitorControl(KryptonNumericUpDown c)
	{
		c.MouseEnter -= OnControlEnter;
		c.MouseLeave -= OnControlLeave;
		c.TrackMouseEnter -= OnControlEnter;
		c.TrackMouseLeave -= OnControlLeave;
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

	private void OnNumericUpDownValueChanged(object sender, EventArgs e)
	{
		OnValueChanged(e);
	}

	private void OnNumericUpDownGotFocus(object sender, EventArgs e)
	{
		OnGotFocus(e);
	}

	private void OnNumericUpDownLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
	}

	private void OnNumericUpDownKeyPress(object sender, KeyPressEventArgs e)
	{
		OnKeyPress(e);
	}

	private void OnNumericUpDownKeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void OnNumericUpDownKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
	}

	private void OnNumericUpDownPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		OnPreviewKeyDown(e);
	}

	private void OnRibbonPaletteChanged(object sender, EventArgs e)
	{
		_numericUpDown.Palette = Ribbon.GetResolvedPalette();
	}
}

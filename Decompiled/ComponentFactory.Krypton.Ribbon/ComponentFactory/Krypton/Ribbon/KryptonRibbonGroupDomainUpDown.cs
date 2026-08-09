using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupDomainUpDown), "ToolboxBitmaps.KryptonRibbonGroupDomainUpDown.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupDomainUpDownDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("SelectedItemChanged")]
[DefaultProperty("Items")]
public class KryptonRibbonGroupDomainUpDown : KryptonRibbonGroupItem
{
	private bool _visible;

	private bool _enabled;

	private string _keyTip;

	private Keys _shortcutKeys;

	private GroupItemSize _itemSizeCurrent;

	private NeedPaintHandler _viewPaintDelegate;

	private KryptonDomainUpDown _domainUpDown;

	private KryptonDomainUpDown _lastDomainUpDown;

	private IKryptonDesignObject _designer;

	private Control _lastParentControl;

	private ViewBase _domainUpDownView;

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
				_domainUpDown.Palette = Ribbon.GetResolvedPalette();
				Ribbon.PaletteChanged += OnRibbonPaletteChanged;
			}
		}
	}

	[Browsable(false)]
	[DefaultValue(-1)]
	public int SelectedIndex
	{
		get
		{
			return DomainUpDown.SelectedIndex;
		}
		set
		{
			DomainUpDown.SelectedIndex = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object SelectedItem
	{
		get
		{
			return DomainUpDown.SelectedItem;
		}
		set
		{
			DomainUpDown.SelectedItem = value;
		}
	}

	[Category("Appearance")]
	[Description("Text associated with the control.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string Text
	{
		get
		{
			return _domainUpDown.Text;
		}
		set
		{
			_domainUpDown.Text = value;
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to set focus to the domain up-down.")]
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

	[Category("Data")]
	[Description("The allowable items of the domain up down.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	public DomainUpDown.DomainUpDownItemCollection Items => DomainUpDown.Items;

	[Description("Access to the actual embedded KryptonDomainUpDown instance.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonDomainUpDown DomainUpDown => _domainUpDown;

	[Category("Behavior")]
	[Description("Controls whether items in the domain list are sorted.")]
	[DefaultValue(false)]
	public bool Sorted
	{
		get
		{
			return DomainUpDown.Sorted;
		}
		set
		{
			DomainUpDown.Sorted = value;
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group domain up-down key tip.")]
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

	[Category("Appearance")]
	[Description("Indicates how the text should be aligned for edit controls.")]
	[DefaultValue(typeof(HorizontalAlignment), "Left")]
	[Localizable(true)]
	public HorizontalAlignment TextAlign
	{
		get
		{
			return _domainUpDown.TextAlign;
		}
		set
		{
			_domainUpDown.TextAlign = value;
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
			return _domainUpDown.UpDownAlign;
		}
		set
		{
			_domainUpDown.UpDownAlign = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the up-down control will increment and decrement the value when the UP ARROW and DOWN ARROW are used.")]
	[DefaultValue(true)]
	public bool InterceptArrowKeys
	{
		get
		{
			return _domainUpDown.InterceptArrowKeys;
		}
		set
		{
			_domainUpDown.InterceptArrowKeys = value;
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
			return _domainUpDown.ReadOnly;
		}
		set
		{
			_domainUpDown.ReadOnly = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonDomainUpDown.DomainUpDownButtonSpecCollection ButtonSpecs => _domainUpDown.ButtonSpecs;

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the domain up-down is visible or hidden.")]
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
	[Description("Determines whether the group domain up-down is enabled.")]
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
			return _domainUpDown.MinimumSize;
		}
		set
		{
			_domainUpDown.MinimumSize = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies the maximum size of the control.")]
	[DefaultValue(typeof(Size), "121, 0")]
	public Size MaximumSize
	{
		get
		{
			return _domainUpDown.MaximumSize;
		}
		set
		{
			_domainUpDown.MaximumSize = value;
		}
	}

	[Category("Behavior")]
	[Description("The shortcut to display when the user right-clicks the control.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _domainUpDown.ContextMenuStrip;
		}
		set
		{
			_domainUpDown.ContextMenuStrip = value;
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the domain up down is right clicked.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _domainUpDown.KryptonContextMenu;
		}
		set
		{
			_domainUpDown.KryptonContextMenu = value;
		}
	}

	[Category("Visuals")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _domainUpDown.AllowButtonSpecToolTips;
		}
		set
		{
			_domainUpDown.AllowButtonSpecToolTips = value;
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
	public IKryptonDesignObject DomainUpDownDesigner
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
	public ViewBase DomainUpDownView
	{
		get
		{
			return _domainUpDownView;
		}
		set
		{
			_domainUpDownView = value;
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

	internal KryptonDomainUpDown LastDomainUpDown
	{
		get
		{
			return _lastDomainUpDown;
		}
		set
		{
			_lastDomainUpDown = value;
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

	[Category("Behavior")]
	[Description("Occurs when the value of the SelectedItem property changes.")]
	public event EventHandler SelectedItemChanged;

	[Category("Action")]
	[Description("Occurs when the user scrolls the scroll box.")]
	public event ScrollEventHandler Scroll;

	[Description("Occurs when the value of the Text property changes.")]
	[Category("Property Changed")]
	public event EventHandler TextChanged;

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

	public KryptonRibbonGroupDomainUpDown()
	{
		_visible = true;
		_enabled = true;
		_itemSizeCurrent = GroupItemSize.Medium;
		_shortcutKeys = Keys.None;
		_keyTip = "X";
		_domainUpDown = new KryptonDomainUpDown();
		_domainUpDown.InputControlStyle = InputControlStyle.Ribbon;
		_domainUpDown.AlwaysActive = false;
		_domainUpDown.MinimumSize = new Size(121, 0);
		_domainUpDown.MaximumSize = new Size(121, 0);
		_domainUpDown.TabStop = false;
		_domainUpDown.Scroll += OnDomainUpDownScroll;
		_domainUpDown.SelectedItemChanged += OnDomainUpDownSelectedItemChanged;
		_domainUpDown.GotFocus += OnDomainUpDownGotFocus;
		_domainUpDown.LostFocus += OnDomainUpDownLostFocus;
		_domainUpDown.KeyDown += OnDomainUpDownKeyDown;
		_domainUpDown.KeyUp += OnDomainUpDownKeyUp;
		_domainUpDown.KeyPress += OnDomainUpDownKeyPress;
		_domainUpDown.PreviewKeyDown += OnDomainUpDownPreviewKeyDown;
		_domainUpDown.TextChanged += OnDomainUpDownTextChanged;
		MonitorControl(_domainUpDown);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _domainUpDown != null)
		{
			UnmonitorControl(_domainUpDown);
			_domainUpDown.Dispose();
			_domainUpDown = null;
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
		_domainUpDown.Select(start, length);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupDomainUpDown(ribbon, this, needPaint);
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

	protected virtual void OnSelectedItemChanged(EventArgs e)
	{
		if (this.SelectedItemChanged != null)
		{
			this.SelectedItemChanged(this, e);
		}
	}

	protected virtual void OnTextChanged(EventArgs e)
	{
		if (this.TextChanged != null)
		{
			this.TextChanged(this, e);
		}
	}

	protected virtual void OnScroll(ScrollEventArgs e)
	{
		if (this.Scroll != null)
		{
			this.Scroll(this, e);
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
			if (LastDomainUpDown != null && LastDomainUpDown.CanFocus)
			{
				LastDomainUpDown.DomainUpDown.Focus();
			}
			return true;
		}
		return false;
	}

	private void MonitorControl(KryptonDomainUpDown c)
	{
		c.MouseEnter += OnControlEnter;
		c.MouseLeave += OnControlLeave;
		c.TrackMouseEnter += OnControlEnter;
		c.TrackMouseLeave += OnControlLeave;
	}

	private void UnmonitorControl(KryptonDomainUpDown c)
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

	private void OnDomainUpDownScroll(object sender, ScrollEventArgs e)
	{
		OnScroll(e);
	}

	private void OnDomainUpDownSelectedItemChanged(object sender, EventArgs e)
	{
		OnSelectedItemChanged(e);
	}

	private void OnDomainUpDownTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(e);
	}

	private void OnDomainUpDownGotFocus(object sender, EventArgs e)
	{
		OnGotFocus(e);
	}

	private void OnDomainUpDownLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
	}

	private void OnDomainUpDownKeyPress(object sender, KeyPressEventArgs e)
	{
		OnKeyPress(e);
	}

	private void OnDomainUpDownKeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void OnDomainUpDownKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
	}

	private void OnDomainUpDownPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		OnPreviewKeyDown(e);
	}

	private void OnRibbonPaletteChanged(object sender, EventArgs e)
	{
		_domainUpDown.Palette = Ribbon.GetResolvedPalette();
	}
}

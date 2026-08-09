using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupComboBox), "ToolboxBitmaps.KryptonRibbonGroupComboBox.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupComboBoxDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("SelectedTextChanged")]
[DefaultProperty("Text")]
public class KryptonRibbonGroupComboBox : KryptonRibbonGroupItem
{
	private bool _visible;

	private bool _enabled;

	private string _keyTip;

	private Keys _shortcutKeys;

	private GroupItemSize _itemSizeCurrent;

	private NeedPaintHandler _viewPaintDelegate;

	private KryptonComboBox _comboBox;

	private KryptonComboBox _lastComboBox;

	private IKryptonDesignObject _designer;

	private Control _lastParentControl;

	private ViewBase _comboBoxView;

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
				_comboBox.Palette = Ribbon.GetResolvedPalette();
				Ribbon.PaletteChanged += OnRibbonPaletteChanged;
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to set focus to the combo box.")]
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

	[Description("Access to the actual embedded KryptonComboBox instance.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonComboBox ComboBox => _comboBox;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group text box key tip.")]
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

	[Bindable(true)]
	[Category("Behavior")]
	[Description("Determines whether the text box is visible or hidden.")]
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
	[Description("Determines whether the group combo box is enabled.")]
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
			return _comboBox.MinimumSize;
		}
		set
		{
			_comboBox.MinimumSize = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies the maximum size of the control.")]
	[DefaultValue(typeof(Size), "121, 0")]
	public Size MaximumSize
	{
		get
		{
			return _comboBox.MaximumSize;
		}
		set
		{
			_comboBox.MaximumSize = value;
		}
	}

	[Category("Appearance")]
	[Description("Text associated with the control.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string Text
	{
		get
		{
			return _comboBox.Text;
		}
		set
		{
			_comboBox.Text = value;
		}
	}

	[Category("Behavior")]
	[Description("The shortcut to display when the user right-clicks the control.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _comboBox.ContextMenuStrip;
		}
		set
		{
			_comboBox.ContextMenuStrip = value;
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the combobox is right clicked.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _comboBox.KryptonContextMenu;
		}
		set
		{
			_comboBox.KryptonContextMenu = value;
		}
	}

	[Category("Data")]
	[Description("Indicates the property to use as the actual value of the items in the control.")]
	[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public string ValueMember
	{
		get
		{
			return _comboBox.ValueMember;
		}
		set
		{
			_comboBox.ValueMember = value;
		}
	}

	[Category("Data")]
	[Description("Indicates the list that this control will use to gets its items.")]
	[AttributeProvider(typeof(IListSource))]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue(null)]
	public object DataSource
	{
		get
		{
			return _comboBox.DataSource;
		}
		set
		{
			_comboBox.DataSource = value;
		}
	}

	[Category("Data")]
	[Description("Indicates the property to display for the items in this control.")]
	[TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public string DisplayMember
	{
		get
		{
			return _comboBox.DisplayMember;
		}
		set
		{
			_comboBox.DisplayMember = value;
		}
	}

	[Category("Appearance")]
	[Description("Controls the appearance and functionality of the KryptonComboBox.")]
	[DefaultValue(typeof(ComboBoxStyle), "DropDown")]
	[RefreshProperties(RefreshProperties.Repaint)]
	public ComboBoxStyle DropDownStyle
	{
		get
		{
			return _comboBox.DropDownStyle;
		}
		set
		{
			_comboBox.DropDownStyle = value;
		}
	}

	[Category("Behavior")]
	[Description("The height, in pixels, of the drop down box in a KryptonComboBox.")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(200)]
	[Browsable(true)]
	public int DropDownHeight
	{
		get
		{
			return _comboBox.DropDownHeight;
		}
		set
		{
			_comboBox.DropDownHeight = value;
		}
	}

	[Category("Behavior")]
	[Description("The width, in pixels, of the drop down box in a KryptonComboBox.")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(143)]
	[Browsable(true)]
	public int DropDownWidth
	{
		get
		{
			return _comboBox.DropDownWidth;
		}
		set
		{
			_comboBox.DropDownWidth = value;
		}
	}

	[Category("Behavior")]
	[Description("The height, in pixels, of items in an owner-draw KryptomComboBox.")]
	[Localizable(true)]
	public int ItemHeight
	{
		get
		{
			return _comboBox.ItemHeight;
		}
		set
		{
			_comboBox.ItemHeight = value;
		}
	}

	[Category("Behavior")]
	[Description("The maximum number of entries to display in the drop-down list.")]
	[Localizable(true)]
	[DefaultValue(8)]
	public int MaxDropDownItems
	{
		get
		{
			return _comboBox.MaxDropDownItems;
		}
		set
		{
			_comboBox.MaxDropDownItems = value;
		}
	}

	[Category("Behavior")]
	[Description("Specifies the maximum number of characters that can be entered into the edit control.")]
	[DefaultValue(0)]
	[Localizable(true)]
	public int MaxLength
	{
		get
		{
			return _comboBox.MaxLength;
		}
		set
		{
			_comboBox.MaxLength = value;
		}
	}

	[Category("Behavior")]
	[Description("Specifies whether the items in the list portion of the KryptonComboBox are sorted.")]
	[DefaultValue(false)]
	public bool Sorted
	{
		get
		{
			return _comboBox.Sorted;
		}
		set
		{
			_comboBox.Sorted = value;
		}
	}

	[Category("Data")]
	[Description("The items in the KryptonComboBox.")]
	[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[MergableProperty(false)]
	[Localizable(true)]
	public ComboBox.ObjectCollection Items => _comboBox.Items;

	[Category("Visuals")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _comboBox.AllowButtonSpecToolTips;
		}
		set
		{
			_comboBox.AllowButtonSpecToolTips = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonComboBox.ComboBoxButtonSpecCollection ButtonSpecs => _comboBox.ButtonSpecs;

	[Description("The StringCollection to use when the AutoCompleteSource property is set to CustomSource.")]
	[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Localizable(true)]
	[Browsable(true)]
	public AutoCompleteStringCollection AutoCompleteCustomSource
	{
		get
		{
			return _comboBox.AutoCompleteCustomSource;
		}
		set
		{
			_comboBox.AutoCompleteCustomSource = value;
		}
	}

	[Description("Indicates the text completion behavior of the combobox.")]
	[DefaultValue(typeof(AutoCompleteMode), "None")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public AutoCompleteMode AutoCompleteMode
	{
		get
		{
			return _comboBox.AutoCompleteMode;
		}
		set
		{
			_comboBox.AutoCompleteMode = value;
		}
	}

	[Description("The autocomplete source, which can be one of the values from AutoCompleteSource enumeration.")]
	[DefaultValue(typeof(AutoCompleteSource), "None")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public AutoCompleteSource AutoCompleteSource
	{
		get
		{
			return _comboBox.AutoCompleteSource;
		}
		set
		{
			_comboBox.AutoCompleteSource = value;
		}
	}

	[Description("The format specifier characters that indicate how a value is to be displayed.")]
	[Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[MergableProperty(false)]
	[DefaultValue("")]
	public string FormatString
	{
		get
		{
			return _comboBox.FormatString;
		}
		set
		{
			_comboBox.FormatString = value;
		}
	}

	[Description("If this property is true, the value of FormatString is used to convert the value of DisplayMember into a value that can be displayed.")]
	[DefaultValue(true)]
	public bool FormattingEnabled
	{
		get
		{
			return _comboBox.FormattingEnabled;
		}
		set
		{
			_comboBox.FormattingEnabled = value;
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public IFormatProvider FormatInfo
	{
		get
		{
			return _comboBox.FormatInfo;
		}
		set
		{
			_comboBox.FormatInfo = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionLength
	{
		get
		{
			return _comboBox.SelectionLength;
		}
		set
		{
			_comboBox.SelectionLength = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionStart
	{
		get
		{
			return _comboBox.SelectionStart;
		}
		set
		{
			_comboBox.SelectionStart = value;
		}
	}

	[Bindable(true)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object SelectedItem
	{
		get
		{
			return _comboBox.SelectedItem;
		}
		set
		{
			_comboBox.SelectedItem = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedText
	{
		get
		{
			return _comboBox.SelectedText;
		}
		set
		{
			_comboBox.SelectedText = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectedIndex
	{
		get
		{
			return _comboBox.SelectedIndex;
		}
		set
		{
			_comboBox.SelectedIndex = value;
		}
	}

	[Bindable(true)]
	[Browsable(false)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object SelectedValue
	{
		get
		{
			return _comboBox.SelectedValue;
		}
		set
		{
			_comboBox.SelectedValue = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DroppedDown
	{
		get
		{
			return _comboBox.DroppedDown;
		}
		set
		{
			_comboBox.DroppedDown = value;
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
	public IKryptonDesignObject ComboBoxDesigner
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
	public ViewBase ComboBoxView
	{
		get
		{
			return _comboBoxView;
		}
		set
		{
			_comboBoxView = value;
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

	internal KryptonComboBox LastComboBox
	{
		get
		{
			return _lastComboBox;
		}
		set
		{
			_lastComboBox = value;
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

	[Description("Occurs when the drop-down portion of the KryptonComboBox is shown.")]
	[Category("Behavior")]
	public event EventHandler DropDown;

	[Description("Indicates that the drop-down portion of the KryptonComboBox has closed.")]
	[Category("Behavior")]
	public event EventHandler DropDownClosed;

	[Description("Occurs when the value of the DropDownStyle property changed.")]
	[Category("Behavior")]
	public event EventHandler DropDownStyleChanged;

	[Description("Occurs when the value of the SelectedIndex property changes.")]
	[Category("Behavior")]
	public event EventHandler SelectedIndexChanged;

	[Description("Occurs when an item is chosen from the drop-down list and the drop-down list is closed.")]
	[Category("Behavior")]
	public event EventHandler SelectionChangeCommitted;

	[Description("Occurs when the value of the DataSource property changed.")]
	[Category("PropertyChanged")]
	public event EventHandler DataSourceChanged;

	[Description("Occurs when the value of the DisplayMember property changed.")]
	[Category("PropertyChanged")]
	public event EventHandler DisplayMemberChanged;

	[Description("Occurs when the list format has changed.")]
	[Category("PropertyChanged")]
	public event EventHandler Format;

	[Description("Occurs when the value of the FormatInfo property changed.")]
	[Category("PropertyChanged")]
	public event EventHandler FormatInfoChanged;

	[Description("Occurs when the value of the FormatString property changed.")]
	[Category("PropertyChanged")]
	public event EventHandler FormatStringChanged;

	[Description("Occurs when the value of the FormattingEnabled property changed.")]
	[Category("PropertyChanged")]
	public event EventHandler FormattingEnabledChanged;

	[Description("Occurs when the value of the SelectedValue property changed.")]
	[Category("PropertyChanged")]
	public event EventHandler SelectedValueChanged;

	[Description("Occurs when the value of the ValueMember property changed.")]
	[Category("PropertyChanged")]
	public event EventHandler ValueMemberChanged;

	[Description("Occurs when the KryptonComboBox text has changed.")]
	[Category("Behavior")]
	public event EventHandler TextUpdate;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	internal event EventHandler MouseEnterControl;

	internal event EventHandler MouseLeaveControl;

	public KryptonRibbonGroupComboBox()
	{
		_visible = true;
		_enabled = true;
		_itemSizeCurrent = GroupItemSize.Medium;
		_shortcutKeys = Keys.None;
		_keyTip = "X";
		_comboBox = new KryptonComboBox();
		_comboBox.InputControlStyle = InputControlStyle.Ribbon;
		_comboBox.AlwaysActive = false;
		_comboBox.MinimumSize = new Size(121, 0);
		_comboBox.MaximumSize = new Size(121, 0);
		_comboBox.TabStop = false;
		_comboBox.DropDown += OnComboBoxDropDown;
		_comboBox.DropDownClosed += OnComboBoxDropDownClosed;
		_comboBox.DropDownStyleChanged += OnComboBoxDropDownStyleChanged;
		_comboBox.SelectedIndexChanged += OnComboBoxSelectedIndexChanged;
		_comboBox.SelectionChangeCommitted += OnComboBoxSelectionChangeCommitted;
		_comboBox.TextUpdate += OnComboBoxTextUpdate;
		_comboBox.GotFocus += OnComboBoxGotFocus;
		_comboBox.LostFocus += OnComboBoxLostFocus;
		_comboBox.KeyDown += OnComboBoxKeyDown;
		_comboBox.KeyUp += OnComboBoxKeyUp;
		_comboBox.KeyPress += OnComboBoxKeyPress;
		_comboBox.PreviewKeyDown += OnComboBoxPreviewKeyDown;
		_comboBox.DataSourceChanged += OnComboBoxDataSourceChanged;
		_comboBox.DisplayMemberChanged += OnComboBoxDisplayMemberChanged;
		_comboBox.Format += OnComboBoxFormat;
		_comboBox.FormatInfoChanged += OnComboBoxFormatInfoChanged;
		_comboBox.FormatStringChanged += OnComboBoxFormatStringChanged;
		_comboBox.FormattingEnabledChanged += OnComboBoxFormattingEnabledChanged;
		_comboBox.SelectedValueChanged += OnComboBoxSelectedValueChanged;
		_comboBox.ValueMemberChanged += OnComboBoxValueMemberChanged;
		MonitorControl(_comboBox);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _comboBox != null)
		{
			UnmonitorControl(_comboBox);
			_comboBox.Dispose();
			_comboBox = null;
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

	public int FindString(string str)
	{
		return _comboBox.FindString(str);
	}

	public int FindString(string str, int startIndex)
	{
		return _comboBox.FindString(str, startIndex);
	}

	public int FindStringExact(string str)
	{
		return _comboBox.FindStringExact(str);
	}

	public int FindStringExact(string str, int startIndex)
	{
		return _comboBox.FindStringExact(str, startIndex);
	}

	public int GetItemHeight(int index)
	{
		return _comboBox.GetItemHeight(index);
	}

	public string GetItemText(object item)
	{
		return _comboBox.GetItemText(item);
	}

	public void Select(int start, int length)
	{
		_comboBox.Select(start, length);
	}

	public void SelectAll()
	{
		_comboBox.SelectAll();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupComboBox(ribbon, this, needPaint);
	}

	private bool ShouldSerializeComboBoxDesigner()
	{
		return false;
	}

	protected virtual void OnTextUpdate(EventArgs e)
	{
		if (this.TextUpdate != null)
		{
			this.TextUpdate(this, e);
		}
	}

	protected virtual void OnSelectionChangeCommitted(EventArgs e)
	{
		if (this.SelectionChangeCommitted != null)
		{
			this.SelectionChangeCommitted(this, e);
		}
	}

	protected virtual void OnSelectedIndexChanged(EventArgs e)
	{
		if (this.SelectedIndexChanged != null)
		{
			this.SelectedIndexChanged(this, e);
		}
	}

	protected virtual void OnDropDownStyleChanged(EventArgs e)
	{
		if (this.DropDownStyleChanged != null)
		{
			this.DropDownStyleChanged(this, e);
		}
	}

	protected virtual void OnDataSourceChanged(EventArgs e)
	{
		if (this.DataSourceChanged != null)
		{
			this.DataSourceChanged(this, e);
		}
	}

	protected virtual void OnDisplayMemberChanged(EventArgs e)
	{
		if (this.DisplayMemberChanged != null)
		{
			this.DisplayMemberChanged(this, e);
		}
	}

	protected virtual void OnFormat(EventArgs e)
	{
		if (this.Format != null)
		{
			this.Format(this, e);
		}
	}

	protected virtual void OnFormatInfoChanged(EventArgs e)
	{
		if (this.FormatInfoChanged != null)
		{
			this.FormatInfoChanged(this, e);
		}
	}

	protected virtual void OnFormatStringChanged(EventArgs e)
	{
		if (this.FormatStringChanged != null)
		{
			this.FormatStringChanged(this, e);
		}
	}

	protected virtual void OnFormattingEnabledChanged(EventArgs e)
	{
		if (this.FormattingEnabledChanged != null)
		{
			this.FormattingEnabledChanged(this, e);
		}
	}

	protected virtual void OnSelectedValueChanged(EventArgs e)
	{
		if (this.SelectedValueChanged != null)
		{
			this.SelectedValueChanged(this, e);
		}
	}

	protected virtual void OnValueMemberChanged(EventArgs e)
	{
		if (this.ValueMemberChanged != null)
		{
			this.ValueMemberChanged(this, e);
		}
	}

	protected virtual void OnDropDownClosed(EventArgs e)
	{
		if (this.DropDownClosed != null)
		{
			this.DropDownClosed(this, e);
		}
	}

	protected virtual void OnDropDown(EventArgs e)
	{
		if (this.DropDown != null)
		{
			this.DropDown(this, e);
		}
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
			if (LastComboBox != null && LastComboBox.CanFocus)
			{
				LastComboBox.ComboBox.Focus();
			}
			return true;
		}
		return false;
	}

	private void MonitorControl(KryptonComboBox c)
	{
		c.MouseEnter += OnControlEnter;
		c.MouseLeave += OnControlLeave;
		c.TrackMouseEnter += OnControlEnter;
		c.TrackMouseLeave += OnControlLeave;
	}

	private void UnmonitorControl(KryptonComboBox c)
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

	private void OnComboBoxGotFocus(object sender, EventArgs e)
	{
		OnGotFocus(e);
	}

	private void OnComboBoxLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
	}

	private void OnComboBoxTextUpdate(object sender, EventArgs e)
	{
		OnTextUpdate(e);
	}

	private void OnComboBoxSelectionChangeCommitted(object sender, EventArgs e)
	{
		OnSelectionChangeCommitted(e);
	}

	private void OnComboBoxSelectedIndexChanged(object sender, EventArgs e)
	{
		OnSelectedIndexChanged(e);
	}

	private void OnComboBoxDropDownStyleChanged(object sender, EventArgs e)
	{
		OnDropDownStyleChanged(e);
	}

	private void OnComboBoxDataSourceChanged(object sender, EventArgs e)
	{
		OnDataSourceChanged(e);
	}

	private void OnComboBoxDisplayMemberChanged(object sender, EventArgs e)
	{
		OnDisplayMemberChanged(e);
	}

	private void OnComboBoxDropDownClosed(object sender, EventArgs e)
	{
		OnDropDownClosed(e);
	}

	private void OnComboBoxDropDown(object sender, EventArgs e)
	{
		OnDropDown(e);
	}

	private void OnComboBoxKeyPress(object sender, KeyPressEventArgs e)
	{
		OnKeyPress(e);
	}

	private void OnComboBoxKeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void OnComboBoxKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
	}

	private void OnComboBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		OnPreviewKeyDown(e);
	}

	private void OnComboBoxFormat(object sender, ListControlConvertEventArgs e)
	{
		OnFormat(e);
	}

	private void OnComboBoxFormatInfoChanged(object sender, EventArgs e)
	{
		OnFormatInfoChanged(e);
	}

	private void OnComboBoxFormatStringChanged(object sender, EventArgs e)
	{
		OnFormatStringChanged(e);
	}

	private void OnComboBoxFormattingEnabledChanged(object sender, EventArgs e)
	{
		OnFormattingEnabledChanged(e);
	}

	private void OnComboBoxSelectedValueChanged(object sender, EventArgs e)
	{
		OnSelectedValueChanged(e);
	}

	private void OnComboBoxValueMemberChanged(object sender, EventArgs e)
	{
		OnValueMemberChanged(e);
	}

	private void OnRibbonPaletteChanged(object sender, EventArgs e)
	{
		_comboBox.Palette = Ribbon.GetResolvedPalette();
	}
}

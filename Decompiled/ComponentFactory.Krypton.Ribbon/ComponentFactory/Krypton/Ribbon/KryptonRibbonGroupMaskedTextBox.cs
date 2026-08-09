using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupMaskedTextBox), "ToolboxBitmaps.KryptonRibbonGroupMaskedTextBox.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupMaskedTextBoxDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("TextChanged")]
[DefaultProperty("Mask")]
public class KryptonRibbonGroupMaskedTextBox : KryptonRibbonGroupItem
{
	private bool _visible;

	private bool _enabled;

	private string _keyTip;

	private Keys _shortcutKeys;

	private GroupItemSize _itemSizeCurrent;

	private NeedPaintHandler _viewPaintDelegate;

	private KryptonMaskedTextBox _maskedTextBox;

	private KryptonMaskedTextBox _lastMaskedTextBox;

	private IKryptonDesignObject _designer;

	private Control _lastParentControl;

	private ViewBase _maskedTextBoxView;

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
				_maskedTextBox.Palette = Ribbon.GetResolvedPalette();
				Ribbon.PaletteChanged += OnRibbonPaletteChanged;
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to set focus to the masked text box.")]
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

	[Description("Access to the actual embedded KryptonMaskedTextBox instance.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonMaskedTextBox MaskedTextBox => _maskedTextBox;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group masked text box key tip.")]
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
	[Description("Determines whether the masked text box is visible or hidden.")]
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
	[Description("Determines whether the group masked text box is enabled.")]
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
			return _maskedTextBox.MinimumSize;
		}
		set
		{
			_maskedTextBox.MinimumSize = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies the maximum size of the control.")]
	[DefaultValue(typeof(Size), "121, 0")]
	public Size MaximumSize
	{
		get
		{
			return _maskedTextBox.MaximumSize;
		}
		set
		{
			_maskedTextBox.MaximumSize = value;
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

	[Category("Appearance")]
	[Editor("System.Windows.Forms.Design.MaskedTextBoxTextEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[RefreshProperties(RefreshProperties.All)]
	public string Text
	{
		get
		{
			return _maskedTextBox.Text;
		}
		set
		{
			_maskedTextBox.Text = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Modified => _maskedTextBox.Modified;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedText
	{
		get
		{
			return _maskedTextBox.SelectedText;
		}
		set
		{
			_maskedTextBox.SelectedText = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionLength
	{
		get
		{
			return _maskedTextBox.SelectionLength;
		}
		set
		{
			_maskedTextBox.SelectionLength = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionStart
	{
		get
		{
			return _maskedTextBox.SelectionStart;
		}
		set
		{
			_maskedTextBox.SelectionStart = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int TextLength => _maskedTextBox.TextLength;

	[Browsable(false)]
	public bool IsOverwriteMode => _maskedTextBox.IsOverwriteMode;

	[Browsable(false)]
	public bool MaskCompleted => _maskedTextBox.MaskCompleted;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MaskedTextProvider MaskedTextProvider => _maskedTextBox.MaskedTextProvider;

	[Browsable(false)]
	public bool MaskFull => _maskedTextBox.MaskFull;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int MaxLength
	{
		get
		{
			return _maskedTextBox.MaxLength;
		}
		set
		{
			_maskedTextBox.MaxLength = value;
		}
	}

	[Browsable(false)]
	[DefaultValue(null)]
	public Type ValidatingType
	{
		get
		{
			return _maskedTextBox.ValidatingType;
		}
		set
		{
			_maskedTextBox.ValidatingType = value;
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
			return _maskedTextBox.TextAlign;
		}
		set
		{
			_maskedTextBox.TextAlign = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates the character used as the placeholder.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("_")]
	[Localizable(true)]
	public char PromptChar
	{
		get
		{
			return _maskedTextBox.PromptChar;
		}
		set
		{
			_maskedTextBox.PromptChar = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the prompt character is valid as input.")]
	[DefaultValue(true)]
	public bool AllowPromptAsInput
	{
		get
		{
			return _maskedTextBox.AllowPromptAsInput;
		}
		set
		{
			_maskedTextBox.AllowPromptAsInput = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether only Ascii characters are valid as input.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(false)]
	public bool AsciiOnly
	{
		get
		{
			return _maskedTextBox.AsciiOnly;
		}
		set
		{
			_maskedTextBox.AsciiOnly = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the control will beep when an invalid character is typed.")]
	[DefaultValue(false)]
	public bool BeepOnError
	{
		get
		{
			return _maskedTextBox.BeepOnError;
		}
		set
		{
			_maskedTextBox.BeepOnError = value;
		}
	}

	[Category("Behavior")]
	[Description("The culture that determines the value of the locaizable mask language separators and placeholders.")]
	[RefreshProperties(RefreshProperties.All)]
	public CultureInfo Culture
	{
		get
		{
			return _maskedTextBox.Culture;
		}
		set
		{
			_maskedTextBox.Culture = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the text to be copied to the clipboard includes literals and/or prompt characters.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(MaskFormat), "IncludeLiterals")]
	public MaskFormat CutCopyMaskFormat
	{
		get
		{
			return _maskedTextBox.CutCopyMaskFormat;
		}
		set
		{
			_maskedTextBox.CutCopyMaskFormat = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether prompt characters are displayed when the control does not have focus.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(false)]
	public bool HidePromptOnLeave
	{
		get
		{
			return _maskedTextBox.HidePromptOnLeave;
		}
		set
		{
			_maskedTextBox.HidePromptOnLeave = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates the masked text box input character typing mode.")]
	[DefaultValue(typeof(InsertKeyMode), "Default")]
	public InsertKeyMode InsertKeyMode
	{
		get
		{
			return _maskedTextBox.InsertKeyMode;
		}
		set
		{
			_maskedTextBox.InsertKeyMode = value;
		}
	}

	[Category("Behavior")]
	[Description("Sets the string governing the input allowed for the control.")]
	[RefreshProperties(RefreshProperties.All)]
	[MergableProperty(false)]
	[DefaultValue("")]
	[Localizable(true)]
	public string Mask
	{
		get
		{
			return _maskedTextBox.Mask;
		}
		set
		{
			_maskedTextBox.Mask = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates that the selection should be hidden when the edit control loses focus.")]
	[DefaultValue(true)]
	public bool HideSelection
	{
		get
		{
			return _maskedTextBox.HideSelection;
		}
		set
		{
			_maskedTextBox.HideSelection = value;
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
			return _maskedTextBox.ReadOnly;
		}
		set
		{
			_maskedTextBox.ReadOnly = value;
		}
	}

	[Category("Behavior")]
	[Description("If true, the input is rejected whenever a character fails to comply with the mask; otherwise, characters in the text area are processed one by one as individual inputs.")]
	[DefaultValue(false)]
	public bool RejectInputOnFirstFailure
	{
		get
		{
			return _maskedTextBox.RejectInputOnFirstFailure;
		}
		set
		{
			_maskedTextBox.RejectInputOnFirstFailure = value;
		}
	}

	[Category("Behavior")]
	[Description("Specifies whether to reset and skip the current position if editable, when the input characters has the same value as the prompt.")]
	[DefaultValue(true)]
	public bool ResetOnPrompt
	{
		get
		{
			return _maskedTextBox.ResetOnPrompt;
		}
		set
		{
			_maskedTextBox.ResetOnPrompt = value;
		}
	}

	[Category("Behavior")]
	[Description("Specifies whether to reset and skip the current position if editable, when the input is the space character.")]
	[DefaultValue(true)]
	public bool ResetOnSpace
	{
		get
		{
			return _maskedTextBox.ResetOnSpace;
		}
		set
		{
			_maskedTextBox.ResetOnSpace = value;
		}
	}

	[Category("Behavior")]
	[Description("Specifies whether to skip the current position if non-editable and the input character has the same value as the literal at that position.")]
	[DefaultValue(true)]
	public bool SkipLiterals
	{
		get
		{
			return _maskedTextBox.SkipLiterals;
		}
		set
		{
			_maskedTextBox.SkipLiterals = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the string returned from the Text property includes literal and/or prompt characters.")]
	[DefaultValue(typeof(MaskFormat), "IncludeLiterals")]
	[RefreshProperties(RefreshProperties.Repaint)]
	public MaskFormat TextMaskFormat
	{
		get
		{
			return _maskedTextBox.TextMaskFormat;
		}
		set
		{
			_maskedTextBox.TextMaskFormat = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates the character to display for password input for single-line edit controls.")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue('\0')]
	[Localizable(true)]
	public char PasswordChar
	{
		get
		{
			return _maskedTextBox.PasswordChar;
		}
		set
		{
			_maskedTextBox.PasswordChar = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if the text in the edit control should appear as the default password character.")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue(false)]
	public bool UseSystemPasswordChar
	{
		get
		{
			return _maskedTextBox.UseSystemPasswordChar;
		}
		set
		{
			_maskedTextBox.UseSystemPasswordChar = value;
		}
	}

	[Category("Behavior")]
	[Description("The shortcut to display when the user right-clicks the control.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _maskedTextBox.ContextMenuStrip;
		}
		set
		{
			_maskedTextBox.ContextMenuStrip = value;
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the masked textbox is right clicked.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _maskedTextBox.KryptonContextMenu;
		}
		set
		{
			_maskedTextBox.KryptonContextMenu = value;
		}
	}

	[Category("Visuals")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _maskedTextBox.AllowButtonSpecToolTips;
		}
		set
		{
			_maskedTextBox.AllowButtonSpecToolTips = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonMaskedTextBox.MaskedTextBoxButtonSpecCollection ButtonSpecs => _maskedTextBox.ButtonSpecs;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public IKryptonDesignObject MaskedTextBoxDesigner
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
	public ViewBase MaskedTextBoxView
	{
		get
		{
			return _maskedTextBoxView;
		}
		set
		{
			_maskedTextBoxView = value;
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

	internal KryptonMaskedTextBox LastMaskedTextBox
	{
		get
		{
			return _lastMaskedTextBox;
		}
		set
		{
			_lastMaskedTextBox = value;
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

	[Description("Occurs when the value of the Text property changes.")]
	[Category("Property Changed")]
	public event EventHandler TextChanged;

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

	[Description("Occurs when the value of the HideSelection property changes.")]
	[Category("Property Changed")]
	public event EventHandler HideSelectionChanged;

	[Description("Occurs when the value of the Modified property changes.")]
	[Category("Property Changed")]
	public event EventHandler ModifiedChanged;

	[Description("Occurs when the value of the ReadOnly property changes.")]
	[Category("Property Changed")]
	public event EventHandler ReadOnlyChanged;

	[Description("Occurs when the value of the TextAlign property changes.")]
	[Category("Property Changed")]
	public event EventHandler TextAlignChanged;

	[Description("Occurs when the value of the Mask property changes.")]
	[Category("Property Changed")]
	public event EventHandler MaskChanged;

	[Description("Occurs when the value of the IsOverwriteMode property changes.")]
	[Category("Property Changed")]
	public event EventHandler IsOverwriteModeChanged;

	[Description("Occurs when the input character or text does not comply with the mask specification.")]
	[Category("Behavior")]
	public event MaskInputRejectedEventHandler MaskInputRejected;

	[Description("Occurs when the validating type object has completed parsing the input text.")]
	[Category("Focus")]
	public event TypeValidationEventHandler TypeValidationCompleted;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	internal event EventHandler MouseEnterControl;

	internal event EventHandler MouseLeaveControl;

	public KryptonRibbonGroupMaskedTextBox()
	{
		_visible = true;
		_enabled = true;
		_itemSizeCurrent = GroupItemSize.Medium;
		_shortcutKeys = Keys.None;
		_keyTip = "X";
		_maskedTextBox = new KryptonMaskedTextBox();
		_maskedTextBox.InputControlStyle = InputControlStyle.Ribbon;
		_maskedTextBox.AlwaysActive = false;
		_maskedTextBox.MinimumSize = new Size(121, 0);
		_maskedTextBox.MaximumSize = new Size(121, 0);
		_maskedTextBox.TabStop = false;
		_maskedTextBox.TextAlignChanged += OnMaskedTextBoxTextAlignChanged;
		_maskedTextBox.TextChanged += OnMaskedTextBoxTextChanged;
		_maskedTextBox.HideSelectionChanged += OnMaskedTextBoxHideSelectionChanged;
		_maskedTextBox.ModifiedChanged += OnMaskedTextBoxModifiedChanged;
		_maskedTextBox.ReadOnlyChanged += OnMaskedTextBoxReadOnlyChanged;
		_maskedTextBox.MaskChanged += OnMaskedMaskChanged;
		_maskedTextBox.IsOverwriteModeChanged += OnMaskedIsOverwriteModeChanged;
		_maskedTextBox.MaskInputRejected += OnMaskedMaskInputRejected;
		_maskedTextBox.TypeValidationCompleted += OnMaskedTypeValidationCompleted;
		_maskedTextBox.GotFocus += OnMaskedTextBoxGotFocus;
		_maskedTextBox.LostFocus += OnMaskedTextBoxLostFocus;
		_maskedTextBox.KeyDown += OnMaskedTextBoxKeyDown;
		_maskedTextBox.KeyUp += OnMaskedTextBoxKeyUp;
		_maskedTextBox.KeyPress += OnMaskedTextBoxKeyPress;
		_maskedTextBox.PreviewKeyDown += OnMaskedTextBoxPreviewKeyDown;
		MonitorControl(_maskedTextBox);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _maskedTextBox != null)
		{
			UnmonitorControl(_maskedTextBox);
			_maskedTextBox.Dispose();
			_maskedTextBox = null;
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

	private bool ShouldSerializeCulture()
	{
		return !CultureInfo.CurrentCulture.Equals(Culture);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupMaskedTextBox(ribbon, this, needPaint);
	}

	protected virtual void OnTextChanged(EventArgs e)
	{
		if (this.TextChanged != null)
		{
			this.TextChanged(this, e);
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

	protected virtual void OnHideSelectionChanged(EventArgs e)
	{
		if (this.HideSelectionChanged != null)
		{
			this.HideSelectionChanged(this, e);
		}
	}

	protected virtual void OnModifiedChanged(EventArgs e)
	{
		if (this.ModifiedChanged != null)
		{
			this.ModifiedChanged(this, e);
		}
	}

	protected virtual void OnReadOnlyChanged(EventArgs e)
	{
		if (this.ReadOnlyChanged != null)
		{
			this.ReadOnlyChanged(this, e);
		}
	}

	protected virtual void OnMaskChanged(EventArgs e)
	{
		if (this.MaskChanged != null)
		{
			this.MaskChanged(this, e);
		}
	}

	protected virtual void OnTextAlignChanged(EventArgs e)
	{
		if (this.TextAlignChanged != null)
		{
			this.TextAlignChanged(this, e);
		}
	}

	protected virtual void OnIsOverwriteModeChanged(EventArgs e)
	{
		if (this.IsOverwriteModeChanged != null)
		{
			this.IsOverwriteModeChanged(this, e);
		}
	}

	protected virtual void OnMaskInputRejected(MaskInputRejectedEventArgs e)
	{
		if (this.MaskInputRejected != null)
		{
			this.MaskInputRejected(this, e);
		}
	}

	protected virtual void OnTypeValidationCompleted(TypeValidationEventArgs e)
	{
		if (this.TypeValidationCompleted != null)
		{
			this.TypeValidationCompleted(this, e);
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
			if (LastMaskedTextBox != null && LastMaskedTextBox.CanFocus)
			{
				LastMaskedTextBox.MaskedTextBox.Focus();
			}
			return true;
		}
		return false;
	}

	private void MonitorControl(KryptonMaskedTextBox c)
	{
		c.MouseEnter += OnControlEnter;
		c.MouseLeave += OnControlLeave;
		c.TrackMouseEnter += OnControlEnter;
		c.TrackMouseLeave += OnControlLeave;
	}

	private void UnmonitorControl(KryptonMaskedTextBox c)
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

	private void OnMaskedTextBoxTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(e);
	}

	private void OnMaskedTextBoxTextAlignChanged(object sender, EventArgs e)
	{
		OnTextAlignChanged(e);
	}

	private void OnMaskedMaskChanged(object sender, EventArgs e)
	{
		OnMaskChanged(e);
	}

	private void OnMaskedIsOverwriteModeChanged(object sender, EventArgs e)
	{
		OnIsOverwriteModeChanged(e);
	}

	private void OnMaskedMaskInputRejected(object sender, MaskInputRejectedEventArgs e)
	{
		OnMaskInputRejected(e);
	}

	private void OnMaskedTypeValidationCompleted(object sender, TypeValidationEventArgs e)
	{
		OnTypeValidationCompleted(e);
	}

	private void OnMaskedTextBoxHideSelectionChanged(object sender, EventArgs e)
	{
		OnHideSelectionChanged(e);
	}

	private void OnMaskedTextBoxModifiedChanged(object sender, EventArgs e)
	{
		OnModifiedChanged(e);
	}

	private void OnMaskedTextBoxReadOnlyChanged(object sender, EventArgs e)
	{
		OnReadOnlyChanged(e);
	}

	private void OnMaskedTextBoxGotFocus(object sender, EventArgs e)
	{
		OnGotFocus(e);
	}

	private void OnMaskedTextBoxLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
	}

	private void OnMaskedTextBoxKeyPress(object sender, KeyPressEventArgs e)
	{
		OnKeyPress(e);
	}

	private void OnMaskedTextBoxKeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void OnMaskedTextBoxKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
	}

	private void OnMaskedTextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		OnPreviewKeyDown(e);
	}

	private void OnRibbonPaletteChanged(object sender, EventArgs e)
	{
		_maskedTextBox.Palette = Ribbon.GetResolvedPalette();
	}
}

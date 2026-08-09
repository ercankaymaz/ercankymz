using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupTextBox), "ToolboxBitmaps.KryptonRibbonGroupTextBox.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBoxDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("TextChanged")]
[DefaultProperty("Text")]
public class KryptonRibbonGroupTextBox : KryptonRibbonGroupItem
{
	private bool _visible;

	private bool _enabled;

	private string _keyTip;

	private Keys _shortcutKeys;

	private GroupItemSize _itemSizeCurrent;

	private NeedPaintHandler _viewPaintDelegate;

	private KryptonTextBox _textBox;

	private KryptonTextBox _lastTextBox;

	private IKryptonDesignObject _designer;

	private Control _lastParentControl;

	private ViewBase _textBoxView;

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
				_textBox.Palette = Ribbon.GetResolvedPalette();
				Ribbon.PaletteChanged += OnRibbonPaletteChanged;
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to set focus to the text box.")]
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

	[Description("Access to the actual embedded KryptonTextBox instance.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonTextBox TextBox => _textBox;

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
	[Description("Determines whether the group text box is enabled.")]
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
			return _textBox.MinimumSize;
		}
		set
		{
			_textBox.MinimumSize = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies the maximum size of the control.")]
	[DefaultValue(typeof(Size), "121, 0")]
	public Size MaximumSize
	{
		get
		{
			return _textBox.MaximumSize;
		}
		set
		{
			_textBox.MaximumSize = value;
		}
	}

	[Category("Appearance")]
	[Description("Text associated with the control.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string Text
	{
		get
		{
			return _textBox.Text;
		}
		set
		{
			_textBox.Text = value;
		}
	}

	[Category("Appearance")]
	[Description("The lines of text in a multiline edit, as an array of String values.")]
	[Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[MergableProperty(false)]
	[Localizable(true)]
	public string[] Lines
	{
		get
		{
			return _textBox.Lines;
		}
		set
		{
			_textBox.Lines = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates, for multiline edit controls, which scroll bars will be shown for this control.")]
	[DefaultValue(typeof(ScrollBars), "None")]
	[Localizable(true)]
	public ScrollBars ScrollBars
	{
		get
		{
			return _textBox.ScrollBars;
		}
		set
		{
			_textBox.ScrollBars = value;
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
			return _textBox.TextAlign;
		}
		set
		{
			_textBox.TextAlign = value;
		}
	}

	[Category("Behavior")]
	[Description("The shortcut to display when the user right-clicks the control.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _textBox.ContextMenuStrip;
		}
		set
		{
			_textBox.ContextMenuStrip = value;
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the text box is right clicked.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _textBox.KryptonContextMenu;
		}
		set
		{
			_textBox.KryptonContextMenu = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if lines are automatically word-wrapped for multiline edit controls.")]
	[DefaultValue(true)]
	[Localizable(true)]
	public bool WordWrap
	{
		get
		{
			return _textBox.WordWrap;
		}
		set
		{
			_textBox.WordWrap = value;
		}
	}

	[Category("Behavior")]
	[Description("Control whether the text in the control can span more than one line.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(false)]
	[Localizable(true)]
	public bool Multiline
	{
		get
		{
			return _textBox.Multiline;
		}
		set
		{
			_textBox.Multiline = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if return characters are accepted as input for multiline edit controls.")]
	[DefaultValue(false)]
	public bool AcceptsReturn
	{
		get
		{
			return _textBox.AcceptsReturn;
		}
		set
		{
			_textBox.AcceptsReturn = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if tab characters are accepted as input for multiline edit controls.")]
	[DefaultValue(false)]
	public bool AcceptsTab
	{
		get
		{
			return _textBox.AcceptsTab;
		}
		set
		{
			_textBox.AcceptsTab = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if all the characters should be left alone or converted to uppercase or lowercase.")]
	[DefaultValue(typeof(CharacterCasing), "Normal")]
	public CharacterCasing CharacterCasing
	{
		get
		{
			return _textBox.CharacterCasing;
		}
		set
		{
			_textBox.CharacterCasing = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates that the selection should be hidden when the edit control loses focus.")]
	[DefaultValue(true)]
	public bool HideSelection
	{
		get
		{
			return _textBox.HideSelection;
		}
		set
		{
			_textBox.HideSelection = value;
		}
	}

	[Category("Behavior")]
	[Description("Specifies the maximum number of characters that can be entered into the edit control.")]
	[DefaultValue(32767)]
	[Localizable(true)]
	public int MaxLength
	{
		get
		{
			return _textBox.MaxLength;
		}
		set
		{
			_textBox.MaxLength = value;
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
			return _textBox.ReadOnly;
		}
		set
		{
			_textBox.ReadOnly = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether shortcuts defined for the control are enabled.")]
	[DefaultValue(true)]
	public bool ShortcutsEnabled
	{
		get
		{
			return _textBox.ShortcutsEnabled;
		}
		set
		{
			_textBox.ShortcutsEnabled = value;
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
			return _textBox.PasswordChar;
		}
		set
		{
			_textBox.PasswordChar = value;
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
			return _textBox.UseSystemPasswordChar;
		}
		set
		{
			_textBox.UseSystemPasswordChar = value;
		}
	}

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
			return _textBox.AutoCompleteCustomSource;
		}
		set
		{
			_textBox.AutoCompleteCustomSource = value;
		}
	}

	[Description("Indicates the text completion behavior of the textbox.")]
	[DefaultValue(typeof(AutoCompleteMode), "None")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public AutoCompleteMode AutoCompleteMode
	{
		get
		{
			return _textBox.AutoCompleteMode;
		}
		set
		{
			_textBox.AutoCompleteMode = value;
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
			return _textBox.AutoCompleteSource;
		}
		set
		{
			_textBox.AutoCompleteSource = value;
		}
	}

	[Category("Visuals")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _textBox.AllowButtonSpecToolTips;
		}
		set
		{
			_textBox.AllowButtonSpecToolTips = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonTextBox.TextBoxButtonSpecCollection ButtonSpecs => _textBox.ButtonSpecs;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CanUndo => _textBox.CanUndo;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Modified => _textBox.Modified;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedText
	{
		get
		{
			return _textBox.SelectedText;
		}
		set
		{
			_textBox.SelectedText = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionLength
	{
		get
		{
			return _textBox.SelectionLength;
		}
		set
		{
			_textBox.SelectionLength = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionStart
	{
		get
		{
			return _textBox.SelectionStart;
		}
		set
		{
			_textBox.SelectionStart = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int TextLength => _textBox.TextLength;

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
	public IKryptonDesignObject TextBoxDesigner
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
	public ViewBase TextBoxView
	{
		get
		{
			return _textBoxView;
		}
		set
		{
			_textBoxView = value;
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

	internal KryptonTextBox LastTextBox
	{
		get
		{
			return _lastTextBox;
		}
		set
		{
			_lastTextBox = value;
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

	[Description("Occurs when the value of the AcceptsTab property changes.")]
	[Category("Property Changed")]
	public event EventHandler AcceptsTabChanged;

	[Description("Occurs when the value of the HideSelection property changes.")]
	[Category("Property Changed")]
	public event EventHandler HideSelectionChanged;

	[Description("Occurs when the value of the TextAlign property changes.")]
	[Category("Property Changed")]
	public event EventHandler TextAlignChanged;

	[Description("Occurs when the value of the Modified property changes.")]
	[Category("Property Changed")]
	public event EventHandler ModifiedChanged;

	[Description("Occurs when the value of the Multiline property changes.")]
	[Category("Property Changed")]
	public event EventHandler MultilineChanged;

	[Description("Occurs when the value of the ReadOnly property changes.")]
	[Category("Property Changed")]
	public event EventHandler ReadOnlyChanged;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	internal event EventHandler MouseEnterControl;

	internal event EventHandler MouseLeaveControl;

	public KryptonRibbonGroupTextBox()
	{
		_visible = true;
		_enabled = true;
		_itemSizeCurrent = GroupItemSize.Medium;
		_shortcutKeys = Keys.None;
		_keyTip = "X";
		_textBox = new KryptonTextBox();
		_textBox.InputControlStyle = InputControlStyle.Ribbon;
		_textBox.AlwaysActive = false;
		_textBox.MinimumSize = new Size(121, 0);
		_textBox.MaximumSize = new Size(121, 0);
		_textBox.TabStop = false;
		_textBox.AcceptsTabChanged += OnTextBoxAcceptsTabChanged;
		_textBox.TextAlignChanged += OnTextBoxTextAlignChanged;
		_textBox.TextChanged += OnTextBoxTextChanged;
		_textBox.HideSelectionChanged += OnTextBoxHideSelectionChanged;
		_textBox.ModifiedChanged += OnTextBoxModifiedChanged;
		_textBox.MultilineChanged += OnTextBoxMultilineChanged;
		_textBox.ReadOnlyChanged += OnTextBoxReadOnlyChanged;
		_textBox.GotFocus += OnTextBoxGotFocus;
		_textBox.LostFocus += OnTextBoxLostFocus;
		_textBox.KeyDown += OnTextBoxKeyDown;
		_textBox.KeyUp += OnTextBoxKeyUp;
		_textBox.KeyPress += OnTextBoxKeyPress;
		_textBox.PreviewKeyDown += OnTextBoxPreviewKeyDown;
		MonitorControl(_textBox);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _textBox != null)
		{
			UnmonitorControl(_textBox);
			_textBox.Dispose();
			_textBox = null;
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

	public void AppendText(string text)
	{
		_textBox.AppendText(text);
	}

	public void Clear()
	{
		_textBox.Clear();
	}

	public void ClearUndo()
	{
		_textBox.ClearUndo();
	}

	public void Copy()
	{
		_textBox.Copy();
	}

	public void Cut()
	{
		_textBox.Cut();
	}

	public void Paste()
	{
		_textBox.Paste();
	}

	public void ScrollToCaret()
	{
		_textBox.ScrollToCaret();
	}

	public void Select(int start, int length)
	{
		_textBox.Select(start, length);
	}

	public void SelectAll()
	{
		_textBox.SelectAll();
	}

	public void Undo()
	{
		_textBox.Undo();
	}

	public void DeselectAll()
	{
		_textBox.DeselectAll();
	}

	public int GetCharFromPosition(Point pt)
	{
		return _textBox.GetCharFromPosition(pt);
	}

	public int GetCharIndexFromPosition(Point pt)
	{
		return _textBox.GetCharIndexFromPosition(pt);
	}

	public int GetFirstCharIndexFromLine(int lineNumber)
	{
		return _textBox.GetFirstCharIndexFromLine(lineNumber);
	}

	public int GetFirstCharIndexOfCurrentLine()
	{
		return _textBox.GetFirstCharIndexOfCurrentLine();
	}

	public int GetLineFromCharIndex(int index)
	{
		return _textBox.GetLineFromCharIndex(index);
	}

	public Point GetPositionFromCharIndex(int index)
	{
		return _textBox.GetPositionFromCharIndex(index);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupTextBox(ribbon, this, needPaint);
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

	protected virtual void OnAcceptsTabChanged(EventArgs e)
	{
		if (this.AcceptsTabChanged != null)
		{
			this.AcceptsTabChanged(this, e);
		}
	}

	protected virtual void OnTextAlignChanged(EventArgs e)
	{
		if (this.TextAlignChanged != null)
		{
			this.TextAlignChanged(this, e);
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

	protected virtual void OnMultilineChanged(EventArgs e)
	{
		if (this.MultilineChanged != null)
		{
			this.MultilineChanged(this, e);
		}
	}

	protected virtual void OnReadOnlyChanged(EventArgs e)
	{
		if (this.ReadOnlyChanged != null)
		{
			this.ReadOnlyChanged(this, e);
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
			if (LastTextBox != null && LastTextBox.CanFocus)
			{
				LastTextBox.TextBox.Focus();
			}
			return true;
		}
		return false;
	}

	private void MonitorControl(KryptonTextBox c)
	{
		c.MouseEnter += OnControlEnter;
		c.MouseLeave += OnControlLeave;
		c.TrackMouseEnter += OnControlEnter;
		c.TrackMouseLeave += OnControlLeave;
	}

	private void UnmonitorControl(KryptonTextBox c)
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

	private void OnTextBoxAcceptsTabChanged(object sender, EventArgs e)
	{
		OnAcceptsTabChanged(e);
	}

	private void OnTextBoxTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(e);
	}

	private void OnTextBoxTextAlignChanged(object sender, EventArgs e)
	{
		OnTextAlignChanged(e);
	}

	private void OnTextBoxHideSelectionChanged(object sender, EventArgs e)
	{
		OnHideSelectionChanged(e);
	}

	private void OnTextBoxModifiedChanged(object sender, EventArgs e)
	{
		OnModifiedChanged(e);
	}

	private void OnTextBoxMultilineChanged(object sender, EventArgs e)
	{
		OnMultilineChanged(e);
	}

	private void OnTextBoxReadOnlyChanged(object sender, EventArgs e)
	{
		OnReadOnlyChanged(e);
	}

	private void OnTextBoxGotFocus(object sender, EventArgs e)
	{
		OnGotFocus(e);
	}

	private void OnTextBoxLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
	}

	private void OnTextBoxKeyPress(object sender, KeyPressEventArgs e)
	{
		OnKeyPress(e);
	}

	private void OnTextBoxKeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
	}

	private void OnTextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		OnPreviewKeyDown(e);
	}

	private void OnRibbonPaletteChanged(object sender, EventArgs e)
	{
		_textBox.Palette = Ribbon.GetResolvedPalette();
	}
}

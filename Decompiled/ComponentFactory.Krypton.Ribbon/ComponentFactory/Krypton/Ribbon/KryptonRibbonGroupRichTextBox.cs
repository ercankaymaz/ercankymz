using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonGroupRichTextBox), "ToolboxBitmaps.KryptonRibbonGroupRichTextBox.bmp")]
[Designer("ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRichTextBoxDesigner, ComponentFactory.Krypton.Ribbon, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultEvent("TextChanged")]
[DefaultProperty("Text")]
public class KryptonRibbonGroupRichTextBox : KryptonRibbonGroupItem
{
	private bool _visible;

	private bool _enabled;

	private string _keyTip;

	private Keys _shortcutKeys;

	private GroupItemSize _itemSizeCurrent;

	private NeedPaintHandler _viewPaintDelegate;

	private KryptonRichTextBox _richTextBox;

	private KryptonRichTextBox _lastRichTextBox;

	private IKryptonDesignObject _designer;

	private Control _lastParentControl;

	private ViewBase _richTextBoxView;

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
				_richTextBox.Palette = Ribbon.GetResolvedPalette();
				Ribbon.PaletteChanged += OnRibbonPaletteChanged;
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Shortcut key combination to set focus to the rich text box.")]
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

	[Description("Access to the actual embedded KryptonRichTextBox instance.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonRichTextBox RichTextBox => _richTextBox;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Ribbon group rich text box key tip.")]
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
	[Description("Determines whether the rich text box is visible or hidden.")]
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
	[Description("Determines whether the group rich text box is enabled.")]
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
			return _richTextBox.MinimumSize;
		}
		set
		{
			_richTextBox.MinimumSize = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies the maximum size of the control.")]
	[DefaultValue(typeof(Size), "121, 0")]
	public Size MaximumSize
	{
		get
		{
			return _richTextBox.MaximumSize;
		}
		set
		{
			_richTextBox.MaximumSize = value;
		}
	}

	[Category("Appearance")]
	[Description("Text associated with the control.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public string Text
	{
		get
		{
			return _richTextBox.Text;
		}
		set
		{
			_richTextBox.Text = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int TextLength => _richTextBox.TextLength;

	[Category("Behavior")]
	[Description("The shortcut to display when the user right-clicks the control.")]
	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return _richTextBox.ContextMenuStrip;
		}
		set
		{
			_richTextBox.ContextMenuStrip = value;
		}
	}

	[Category("Behavior")]
	[Description("KryptonContextMenu to be shown when the rich text box is right clicked.")]
	[DefaultValue(null)]
	public KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _richTextBox.KryptonContextMenu;
		}
		set
		{
			_richTextBox.KryptonContextMenu = value;
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
			return _richTextBox.Lines;
		}
		set
		{
			_richTextBox.Lines = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates, for multiline edit controls, which scroll bars will be shown for this control.")]
	[DefaultValue(typeof(RichTextBoxScrollBars), "None")]
	[Localizable(true)]
	public RichTextBoxScrollBars ScrollBars
	{
		get
		{
			return _richTextBox.ScrollBars;
		}
		set
		{
			_richTextBox.ScrollBars = value;
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
			return _richTextBox.WordWrap;
		}
		set
		{
			_richTextBox.WordWrap = value;
		}
	}

	[Category("Behavior")]
	[Description("Defines the right margin dimensions.")]
	[DefaultValue(0)]
	[Localizable(true)]
	public int RightMargin
	{
		get
		{
			return _richTextBox.RightMargin;
		}
		set
		{
			_richTextBox.RightMargin = value;
		}
	}

	[Category("Behavior")]
	[Description("Turns on/off the selection margin.")]
	[DefaultValue(false)]
	public bool ShowSelectionMargin
	{
		get
		{
			return _richTextBox.ShowSelectionMargin;
		}
		set
		{
			_richTextBox.ShowSelectionMargin = value;
		}
	}

	[Category("Behavior")]
	[Description("Defines the current scaling factor of the KryptonRichTextBox display; 1.0 is normal viewing.")]
	[DefaultValue(1f)]
	[Localizable(true)]
	public float ZoomFactor
	{
		get
		{
			return _richTextBox.ZoomFactor;
		}
		set
		{
			_richTextBox.ZoomFactor = value;
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
			return _richTextBox.Multiline;
		}
		set
		{
			_richTextBox.Multiline = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if tab characters are accepted as input for multiline edit controls.")]
	[DefaultValue(false)]
	public bool AcceptsTab
	{
		get
		{
			return _richTextBox.AcceptsTab;
		}
		set
		{
			_richTextBox.AcceptsTab = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates that the selection should be hidden when the edit control loses focus.")]
	[DefaultValue(true)]
	public bool HideSelection
	{
		get
		{
			return _richTextBox.HideSelection;
		}
		set
		{
			_richTextBox.HideSelection = value;
		}
	}

	[Category("Behavior")]
	[Description("Specifies the maximum number of characters that can be entered into the edit control.")]
	[DefaultValue(int.MaxValue)]
	[Localizable(true)]
	public int MaxLength
	{
		get
		{
			return _richTextBox.MaxLength;
		}
		set
		{
			_richTextBox.MaxLength = value;
		}
	}

	[Category("Behavior")]
	[Description("Turns on/off automatic word selection.")]
	[DefaultValue(false)]
	public bool AutoWordSelection
	{
		get
		{
			return _richTextBox.AutoWordSelection;
		}
		set
		{
			_richTextBox.AutoWordSelection = value;
		}
	}

	[Category("Behavior")]
	[Description("Defines the indent for bullets in the control.")]
	[DefaultValue(0)]
	[Localizable(true)]
	public int BulletIndent
	{
		get
		{
			return _richTextBox.BulletIndent;
		}
		set
		{
			_richTextBox.BulletIndent = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether URLs are automatically formatted as links.")]
	[DefaultValue(true)]
	public bool DetectUrls
	{
		get
		{
			return _richTextBox.DetectUrls;
		}
		set
		{
			_richTextBox.DetectUrls = value;
		}
	}

	[Category("Behavior")]
	[Description("Enable drag/drop of text, pictures and other data.")]
	[DefaultValue(false)]
	public bool EnableAutoDragDrop
	{
		get
		{
			return _richTextBox.EnableAutoDragDrop;
		}
		set
		{
			_richTextBox.EnableAutoDragDrop = value;
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
			return _richTextBox.ReadOnly;
		}
		set
		{
			_richTextBox.ReadOnly = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether shortcuts defined for the control are enabled.")]
	[DefaultValue(true)]
	public bool ShortcutsEnabled
	{
		get
		{
			return _richTextBox.ShortcutsEnabled;
		}
		set
		{
			_richTextBox.ShortcutsEnabled = value;
		}
	}

	[Category("Visuals")]
	[Description("Should tooltips be displayed for button specs.")]
	[DefaultValue(false)]
	public bool AllowButtonSpecToolTips
	{
		get
		{
			return _richTextBox.AllowButtonSpecToolTips;
		}
		set
		{
			_richTextBox.AllowButtonSpecToolTips = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonRichTextBox.RichTextBoxButtonSpecCollection ButtonSpecs => _richTextBox.ButtonSpecs;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CanRedo => _richTextBox.CanRedo;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CanUndo => _richTextBox.CanUndo;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Modified => _richTextBox.Modified;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RichTextBoxLanguageOptions LanguageOption
	{
		get
		{
			return _richTextBox.LanguageOption;
		}
		set
		{
			_richTextBox.LanguageOption = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string RedoActionName => _richTextBox.RedoActionName;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string UndoActionName => _richTextBox.UndoActionName;

	[Browsable(false)]
	[DefaultValue(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool RichTextShortcutsEnabled
	{
		get
		{
			return _richTextBox.RichTextShortcutsEnabled;
		}
		set
		{
			_richTextBox.RichTextShortcutsEnabled = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[RefreshProperties(RefreshProperties.All)]
	public string Rtf
	{
		get
		{
			return _richTextBox.Rtf;
		}
		set
		{
			_richTextBox.Rtf = value;
		}
	}

	[Browsable(false)]
	[DefaultValue("")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedRtf
	{
		get
		{
			return _richTextBox.SelectedRtf;
		}
		set
		{
			_richTextBox.SelectedRtf = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedText
	{
		get
		{
			return _richTextBox.SelectedText;
		}
		set
		{
			_richTextBox.SelectedText = value;
		}
	}

	[Browsable(false)]
	[DefaultValue(typeof(HorizontalAlignment), "Left")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public HorizontalAlignment SelectionAlignment
	{
		get
		{
			return _richTextBox.SelectionAlignment;
		}
		set
		{
			_richTextBox.SelectionAlignment = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color SelectionBackColor
	{
		get
		{
			return _richTextBox.SelectionBackColor;
		}
		set
		{
			_richTextBox.SelectionBackColor = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool SelectionBullet
	{
		get
		{
			return _richTextBox.SelectionBullet;
		}
		set
		{
			_richTextBox.SelectionBullet = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionCharOffset
	{
		get
		{
			return _richTextBox.SelectionCharOffset;
		}
		set
		{
			_richTextBox.SelectionCharOffset = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color SelectionColor
	{
		get
		{
			return _richTextBox.SelectionColor;
		}
		set
		{
			_richTextBox.SelectionColor = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Font SelectionFont
	{
		get
		{
			return _richTextBox.SelectionFont;
		}
		set
		{
			_richTextBox.SelectionFont = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionHangingIndent
	{
		get
		{
			return _richTextBox.SelectionHangingIndent;
		}
		set
		{
			_richTextBox.SelectionHangingIndent = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionIndent
	{
		get
		{
			return _richTextBox.SelectionIndent;
		}
		set
		{
			_richTextBox.SelectionIndent = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionLength
	{
		get
		{
			return _richTextBox.SelectionLength;
		}
		set
		{
			_richTextBox.SelectionLength = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionProtected
	{
		get
		{
			return _richTextBox.SelectionLength;
		}
		set
		{
			_richTextBox.SelectionLength = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionRightIndent
	{
		get
		{
			return _richTextBox.SelectionRightIndent;
		}
		set
		{
			_richTextBox.SelectionRightIndent = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionStart
	{
		get
		{
			return _richTextBox.SelectionStart;
		}
		set
		{
			_richTextBox.SelectionStart = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int[] SelectionTabs
	{
		get
		{
			return _richTextBox.SelectionTabs;
		}
		set
		{
			_richTextBox.SelectionTabs = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RichTextBoxSelectionTypes SelectionType => _richTextBox.SelectionType;

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
	public IKryptonDesignObject RichTextBoxDesigner
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
	public ViewBase RichTextBoxView
	{
		get
		{
			return _richTextBoxView;
		}
		set
		{
			_richTextBoxView = value;
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

	internal KryptonRichTextBox LastRichTextBox
	{
		get
		{
			return _lastRichTextBox;
		}
		set
		{
			_lastRichTextBox = value;
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

	[Description("Occurs when the value of the Modified property changes.")]
	[Category("Property Changed")]
	public event EventHandler ModifiedChanged;

	[Description("Occurs when the value of the Multiline property changes.")]
	[Category("Property Changed")]
	public event EventHandler MultilineChanged;

	[Description("Occurs when the value of the ReadOnly property changes.")]
	[Category("Property Changed")]
	public event EventHandler ReadOnlyChanged;

	[Description("Occurs when the current selection has changed.")]
	[Category("Behavior")]
	public event EventHandler SelectionChanged;

	[Description("Occurs when the user takes an action that would change a protected range of text.")]
	[Category("Behavior")]
	public event EventHandler Protected;

	[Description("Occurs when a hyperlink in the text is clicked.")]
	[Category("Behavior")]
	public event EventHandler LinkClicked;

	[Description("Occurs when the horizontal scroll bar is clicked.")]
	[Category("Behavior")]
	public event EventHandler HScroll;

	[Description("Occurs when the vertical scroll bar is clicked.")]
	[Category("Behavior")]
	public event EventHandler VScroll;

	[Category("Ribbon")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public event MouseEventHandler DesignTimeContextMenu;

	internal event EventHandler MouseEnterControl;

	internal event EventHandler MouseLeaveControl;

	public KryptonRibbonGroupRichTextBox()
	{
		_visible = true;
		_enabled = true;
		_itemSizeCurrent = GroupItemSize.Medium;
		_shortcutKeys = Keys.None;
		_keyTip = "X";
		_richTextBox = new KryptonRichTextBox();
		_richTextBox.InputControlStyle = InputControlStyle.Ribbon;
		_richTextBox.AlwaysActive = false;
		_richTextBox.MinimumSize = new Size(121, 0);
		_richTextBox.MaximumSize = new Size(121, 0);
		_richTextBox.Multiline = false;
		_richTextBox.ScrollBars = RichTextBoxScrollBars.None;
		_richTextBox.TabStop = false;
		_richTextBox.AcceptsTabChanged += OnRichTextBoxAcceptsTabChanged;
		_richTextBox.TextChanged += OnRichTextBoxTextChanged;
		_richTextBox.HideSelectionChanged += OnRichTextBoxHideSelectionChanged;
		_richTextBox.ModifiedChanged += OnRichTextBoxModifiedChanged;
		_richTextBox.MultilineChanged += OnRichTextBoxMultilineChanged;
		_richTextBox.ReadOnlyChanged += OnRichTextBoxReadOnlyChanged;
		_richTextBox.GotFocus += OnRichTextBoxGotFocus;
		_richTextBox.LostFocus += OnRichTextBoxLostFocus;
		_richTextBox.KeyDown += OnRichTextBoxKeyDown;
		_richTextBox.KeyUp += OnRichTextBoxKeyUp;
		_richTextBox.KeyPress += OnRichTextBoxKeyPress;
		_richTextBox.PreviewKeyDown += OnRichTextBoxPreviewKeyDown;
		_richTextBox.LinkClicked += OnRichTextBoxLinkClicked;
		_richTextBox.Protected += OnRichTextBoxProtected;
		_richTextBox.SelectionChanged += OnRichTextBoxSelectionChanged;
		_richTextBox.HScroll += OnRichTextBoxHScroll;
		_richTextBox.VScroll += OnRichTextBoxVScroll;
		MonitorControl(_richTextBox);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _richTextBox != null)
		{
			UnmonitorControl(_richTextBox);
			_richTextBox.Dispose();
			_richTextBox = null;
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
		_richTextBox.AppendText(text);
	}

	public void Clear()
	{
		_richTextBox.Clear();
	}

	public void ClearUndo()
	{
		_richTextBox.ClearUndo();
	}

	public void Copy()
	{
		_richTextBox.Copy();
	}

	public void Cut()
	{
		_richTextBox.Cut();
	}

	public void DeselectAll()
	{
		_richTextBox.DeselectAll();
	}

	public bool CanPaste(DataFormats.Format clipFormat)
	{
		return _richTextBox.CanPaste(clipFormat);
	}

	public int Find(string str)
	{
		return _richTextBox.Find(str);
	}

	public int Find(char[] characterSet)
	{
		return _richTextBox.Find(characterSet);
	}

	public int Find(char[] characterSet, int start)
	{
		return _richTextBox.Find(characterSet, start);
	}

	public int Find(string str, RichTextBoxFinds options)
	{
		return _richTextBox.Find(str, options);
	}

	public int Find(char[] characterSet, int start, int end)
	{
		return _richTextBox.Find(characterSet, start, end);
	}

	public int Find(string str, int start, RichTextBoxFinds options)
	{
		return _richTextBox.Find(str, start, options);
	}

	public int Find(string str, int start, int end, RichTextBoxFinds options)
	{
		return _richTextBox.Find(str, start, end, options);
	}

	public int GetCharFromPosition(Point pt)
	{
		return _richTextBox.GetCharFromPosition(pt);
	}

	public int GetCharIndexFromPosition(Point pt)
	{
		return _richTextBox.GetCharIndexFromPosition(pt);
	}

	public int GetFirstCharIndexFromLine(int lineNumber)
	{
		return _richTextBox.GetFirstCharIndexFromLine(lineNumber);
	}

	public int GetFirstCharIndexOfCurrentLine()
	{
		return _richTextBox.GetFirstCharIndexOfCurrentLine();
	}

	public int GetLineFromCharIndex(int index)
	{
		return _richTextBox.GetLineFromCharIndex(index);
	}

	public Point GetPositionFromCharIndex(int index)
	{
		return _richTextBox.GetPositionFromCharIndex(index);
	}

	public void LoadFile(string path)
	{
		_richTextBox.LoadFile(path);
	}

	public void LoadFile(Stream data, RichTextBoxStreamType fileType)
	{
		_richTextBox.LoadFile(data, fileType);
	}

	public void LoadFile(string path, RichTextBoxStreamType fileType)
	{
		_richTextBox.LoadFile(path, fileType);
	}

	public void Paste()
	{
		_richTextBox.Paste();
	}

	public void Undo()
	{
		_richTextBox.Undo();
	}

	public void Paste(DataFormats.Format clipFormat)
	{
		_richTextBox.Paste(clipFormat);
	}

	public void Redo()
	{
		_richTextBox.Redo();
	}

	public void SaveFile(string path)
	{
		_richTextBox.SaveFile(path);
	}

	public void SaveFile(Stream data, RichTextBoxStreamType fileType)
	{
		_richTextBox.SaveFile(data, fileType);
	}

	public void SaveFile(string path, RichTextBoxStreamType fileType)
	{
		_richTextBox.SaveFile(path, fileType);
	}

	public void ScrollToCaret()
	{
		_richTextBox.ScrollToCaret();
	}

	public void Select(int start, int length)
	{
		_richTextBox.Select(start, length);
	}

	public void SelectAll()
	{
		_richTextBox.SelectAll();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ViewBase CreateView(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		return new ViewDrawRibbonGroupRichTextBox(ribbon, this, needPaint);
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

	protected virtual void OnVScroll(EventArgs e)
	{
		if (this.VScroll != null)
		{
			this.VScroll(this, e);
		}
	}

	protected virtual void OnHScroll(EventArgs e)
	{
		if (this.HScroll != null)
		{
			this.HScroll(this, e);
		}
	}

	protected virtual void OnSelectionChanged(EventArgs e)
	{
		if (this.SelectionChanged != null)
		{
			this.SelectionChanged(this, e);
		}
	}

	protected virtual void OnProtected(EventArgs e)
	{
		if (this.Protected != null)
		{
			this.Protected(this, e);
		}
	}

	protected virtual void OnLinkClicked(LinkClickedEventArgs e)
	{
		if (this.LinkClicked != null)
		{
			this.LinkClicked(this, e);
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
			if (LastRichTextBox != null && LastRichTextBox.CanFocus)
			{
				LastRichTextBox.RichTextBox.Focus();
			}
			return true;
		}
		return false;
	}

	private void MonitorControl(KryptonRichTextBox c)
	{
		c.MouseEnter += OnControlEnter;
		c.MouseLeave += OnControlLeave;
		c.TrackMouseEnter += OnControlEnter;
		c.TrackMouseLeave += OnControlLeave;
	}

	private void UnmonitorControl(KryptonRichTextBox c)
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

	private void OnRichTextBoxAcceptsTabChanged(object sender, EventArgs e)
	{
		OnAcceptsTabChanged(e);
	}

	private void OnRichTextBoxTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(e);
	}

	private void OnRichTextBoxHideSelectionChanged(object sender, EventArgs e)
	{
		OnHideSelectionChanged(e);
	}

	private void OnRichTextBoxModifiedChanged(object sender, EventArgs e)
	{
		OnModifiedChanged(e);
	}

	private void OnRichTextBoxMultilineChanged(object sender, EventArgs e)
	{
		OnMultilineChanged(e);
	}

	private void OnRichTextBoxReadOnlyChanged(object sender, EventArgs e)
	{
		OnReadOnlyChanged(e);
	}

	private void OnRichTextBoxGotFocus(object sender, EventArgs e)
	{
		OnGotFocus(e);
	}

	private void OnRichTextBoxLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
	}

	private void OnRichTextBoxKeyPress(object sender, KeyPressEventArgs e)
	{
		OnKeyPress(e);
	}

	private void OnRichTextBoxKeyUp(object sender, KeyEventArgs e)
	{
		OnKeyUp(e);
	}

	private void OnRichTextBoxKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
	}

	private void OnRichTextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		OnPreviewKeyDown(e);
	}

	private void OnRichTextBoxVScroll(object sender, EventArgs e)
	{
		OnVScroll(e);
	}

	private void OnRichTextBoxHScroll(object sender, EventArgs e)
	{
		OnHScroll(e);
	}

	private void OnRichTextBoxSelectionChanged(object sender, EventArgs e)
	{
		OnSelectionChanged(e);
	}

	private void OnRichTextBoxProtected(object sender, EventArgs e)
	{
		OnProtected(e);
	}

	private void OnRichTextBoxLinkClicked(object sender, LinkClickedEventArgs e)
	{
		OnLinkClicked(e);
	}

	private void OnRibbonPaletteChanged(object sender, EventArgs e)
	{
		_richTextBox.Palette = Ribbon.GetResolvedPalette();
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonTextBox), "ToolboxBitmaps.KryptonTextBox.bmp")]
[DefaultEvent("TextChanged")]
[DefaultProperty("Text")]
[DefaultBindingProperty("Text")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonTextBoxDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Enables the user to enter text, and provides multiline editing and password character masking.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonTextBox : VisualControlBase, IContainedInputControl
{
	private class InternalTextBox : TextBox
	{
		private KryptonTextBox _kryptonTextBox;

		private bool _mouseOver;

		public bool MouseOver
		{
			get
			{
				return _mouseOver;
			}
			set
			{
				if (_mouseOver != value)
				{
					_mouseOver = value;
					if (_mouseOver)
					{
						OnTrackMouseEnter(EventArgs.Empty);
					}
					else
					{
						OnTrackMouseLeave(EventArgs.Empty);
					}
				}
			}
		}

		public event EventHandler TrackMouseEnter;

		public event EventHandler TrackMouseLeave;

		public InternalTextBox(KryptonTextBox kryptonTextBox)
		{
			_kryptonTextBox = kryptonTextBox;
			base.Size = Size.Empty;
			base.BorderStyle = BorderStyle.None;
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			return base.GetPreferredSize(proposedSize);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 132:
				if (_kryptonTextBox.InTransparentDesignMode)
				{
					m.Result = (IntPtr)(-1);
				}
				else
				{
					base.WndProc(ref m);
				}
				break;
			case 675:
				MouseOver = false;
				_kryptonTextBox.PerformNeedPaint(needLayout: true);
				Invalidate();
				base.WndProc(ref m);
				break;
			case 512:
				if (!MouseOver)
				{
					MouseOver = true;
					_kryptonTextBox.PerformNeedPaint(needLayout: true);
					Invalidate();
				}
				base.WndProc(ref m);
				break;
			case 15:
			case 792:
			{
				PI.PAINTSTRUCT ps = default(PI.PAINTSTRUCT);
				IntPtr intPtr = ((!(m.WParam == IntPtr.Zero)) ? m.WParam : PI.BeginPaint(base.Handle, ref ps));
				using (Graphics graphics = Graphics.FromHdc(intPtr))
				{
					PI.RECT lpRect = default(PI.RECT);
					PI.GetClientRect(base.Handle, out lpRect);
					using (SolidBrush brush = new SolidBrush(BackColor))
					{
						graphics.FillRectangle(brush, new Rectangle(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top));
					}
					Size borderSize = SystemInformation.BorderSize;
					lpRect.left -= borderSize.Width + 1;
					if (_kryptonTextBox.Enabled)
					{
						if (m.WParam == IntPtr.Zero)
						{
							m.WParam = intPtr;
							DefWndProc(ref m);
							m.WParam = IntPtr.Zero;
						}
						else
						{
							DefWndProc(ref m);
						}
					}
					else
					{
						graphics.TextRenderingHint = CommonHelper.PaletteTextHintToRenderingHint(_kryptonTextBox.StateDisabled.PaletteContent.GetContentShortTextHint(PaletteState.Disabled));
						StringFormat stringFormat = new StringFormat();
						stringFormat.Trimming = StringTrimming.None;
						stringFormat.LineAlignment = StringAlignment.Near;
						if (!_kryptonTextBox.Multiline)
						{
							stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
						}
						switch (_kryptonTextBox.TextAlign)
						{
						case HorizontalAlignment.Left:
							if (RightToLeft == RightToLeft.Yes)
							{
								stringFormat.Alignment = StringAlignment.Far;
							}
							else
							{
								stringFormat.Alignment = StringAlignment.Near;
							}
							break;
						case HorizontalAlignment.Right:
							if (RightToLeft == RightToLeft.Yes)
							{
								stringFormat.Alignment = StringAlignment.Near;
							}
							else
							{
								stringFormat.Alignment = StringAlignment.Far;
							}
							break;
						case HorizontalAlignment.Center:
							stringFormat.Alignment = StringAlignment.Center;
							break;
						}
						stringFormat.HotkeyPrefix = HotkeyPrefix.None;
						string s = Text;
						if (base.PasswordChar != 0)
						{
							s = new string(base.PasswordChar, Text.Length);
						}
						try
						{
							using SolidBrush brush2 = new SolidBrush(ForeColor);
							graphics.DrawString(s, Font, brush2, new RectangleF(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top), stringFormat);
						}
						catch (ArgumentException)
						{
							using SolidBrush brush3 = new SolidBrush(ForeColor);
							graphics.DrawString(s, _kryptonTextBox.GetTripleState().PaletteContent.GetContentShortTextFont(PaletteState.Disabled), brush3, new RectangleF(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top), stringFormat);
						}
					}
					PI.SelectClipRgn(intPtr, IntPtr.Zero);
				}
				if (m.WParam == IntPtr.Zero)
				{
					PI.EndPaint(base.Handle, ref ps);
				}
				break;
			}
			case 123:
				if (_kryptonTextBox.KryptonContextMenu != null)
				{
					Point screenPt = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
					if ((int)(long)m.LParam == -1)
					{
						screenPt = PointToScreen(new Point(base.Width / 2, base.Height / 2));
					}
					_kryptonTextBox.KryptonContextMenu.Show(_kryptonTextBox, screenPt);
				}
				else
				{
					base.WndProc(ref m);
				}
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		protected virtual void OnTrackMouseEnter(EventArgs e)
		{
			if (this.TrackMouseEnter != null)
			{
				this.TrackMouseEnter(this, e);
			}
		}

		protected virtual void OnTrackMouseLeave(EventArgs e)
		{
			if (this.TrackMouseLeave != null)
			{
				this.TrackMouseLeave(this, e);
			}
		}
	}

	public class TextBoxButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public TextBoxButtonSpecCollection(KryptonTextBox owner)
			: base((object)owner)
		{
		}
	}

	private ToolTipManager _toolTipManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ButtonSpecManagerLayout _buttonManager;

	private TextBoxButtonSpecCollection _buttonSpecs;

	private PaletteInputControlTripleRedirect _stateCommon;

	private PaletteInputControlTripleStates _stateDisabled;

	private PaletteInputControlTripleStates _stateNormal;

	private PaletteInputControlTripleStates _stateActive;

	private ViewLayoutDocker _drawDockerInner;

	private ViewDrawDocker _drawDockerOuter;

	private ViewLayoutFill _layoutFill;

	private InternalTextBox _textBox;

	private InputControlStyle _inputControlStyle;

	private bool? _fixedActive;

	private bool _inRibbonDesignMode;

	private bool _forcedLayout;

	private bool _autoSize;

	private bool _mouseOver;

	private bool _alwaysActive;

	private bool _allowButtonSpecToolTips;

	private bool _trackingMouseEnter;

	private int _cachedHeight;

	public new bool TabStop
	{
		get
		{
			return _textBox.TabStop;
		}
		set
		{
			_textBox.TabStop = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool InRibbonDesignMode
	{
		get
		{
			return _inRibbonDesignMode;
		}
		set
		{
			_inRibbonDesignMode = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public TextBox TextBox => _textBox;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public Control ContainedControl => TextBox;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool AutoSize
	{
		get
		{
			return _autoSize;
		}
		set
		{
			if (_autoSize != value)
			{
				_autoSize = value;
				if (Multiline)
				{
					SetStyle(ControlStyles.FixedHeight, value: false);
				}
				else
				{
					SetStyle(ControlStyles.FixedHeight, _autoSize);
				}
				AdjustHeight(ignoreAnchored: false);
			}
		}
	}

	[Browsable(false)]
	public override bool Focused => TextBox.Focused;

	[Browsable(false)]
	[Bindable(false)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[Browsable(false)]
	[Localizable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public override string Text
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

	public override ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return base.ContextMenuStrip;
		}
		set
		{
			base.ContextMenuStrip = value;
			_textBox.ContextMenuStrip = value;
		}
	}

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

	[Category("Appearance")]
	[Description("Defines if mnemonic characters generate click events for button specs.")]
	[DefaultValue(true)]
	public bool UseMnemonic
	{
		get
		{
			return _buttonManager.UseMnemonic;
		}
		set
		{
			if (_buttonManager.UseMnemonic != value)
			{
				_buttonManager.UseMnemonic = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Determines if the control is always active or only when the mouse is over the control or has focus.")]
	[DefaultValue(true)]
	public bool AlwaysActive
	{
		get
		{
			return _alwaysActive;
		}
		set
		{
			if (_alwaysActive != value)
			{
				_alwaysActive = value;
				PerformNeedPaint(needLayout: true);
			}
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
			if (_textBox.Multiline != value)
			{
				_textBox.Multiline = value;
				if (value)
				{
					SetStyle(ControlStyles.FixedHeight, value: false);
				}
				else
				{
					SetStyle(ControlStyles.FixedHeight, _autoSize);
				}
				AdjustHeight(ignoreAnchored: false);
			}
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

	[Category("Visuals")]
	[Description("Input control style.")]
	public InputControlStyle InputControlStyle
	{
		get
		{
			return _inputControlStyle;
		}
		set
		{
			if (_inputControlStyle != value)
			{
				_inputControlStyle = value;
				_stateCommon.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
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
			return _allowButtonSpecToolTips;
		}
		set
		{
			_allowButtonSpecToolTips = value;
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public TextBoxButtonSpecCollection ButtonSpecs => _buttonSpecs;

	[Category("Visuals")]
	[Description("Overrides for defining common textbox appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled textbox appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleStates StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal textbox appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleStates StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining active textbox appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleStates StateActive => _stateActive;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolTipManager ToolTipManager => _toolTipManager;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsActive
	{
		get
		{
			if (_fixedActive.HasValue)
			{
				return _fixedActive.Value;
			}
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver || _textBox.MouseOver;
		}
	}

	public override Rectangle DisplayRectangle
	{
		get
		{
			ForceViewLayout();
			return new Rectangle(_textBox.Location, _textBox.Size);
		}
	}

	protected override Size DefaultSize => new Size(100, PreferredHeight);

	internal bool InTransparentDesignMode => InRibbonDesignMode;

	private int PreferredHeight => GetPreferredSize(new Size(int.MaxValue, int.MaxValue)).Height;

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

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event EventHandler TrackMouseEnter;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event EventHandler TrackMouseLeave;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackColorChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageLayoutChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler ForeColorChanged;

	public KryptonTextBox()
	{
		SetStyle(ControlStyles.ContainerControl, value: true);
		SetStyle(ControlStyles.FixedHeight, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		_inputControlStyle = InputControlStyle.Standalone;
		_autoSize = true;
		_cachedHeight = -1;
		_alwaysActive = true;
		_allowButtonSpecToolTips = false;
		_buttonSpecs = new TextBoxButtonSpecCollection(this);
		_stateCommon = new PaletteInputControlTripleRedirect(base.Redirector, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone, base.NeedPaintDelegate);
		_stateDisabled = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateActive = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_textBox = new InternalTextBox(this);
		_textBox.TrackMouseEnter += OnTextBoxMouseChange;
		_textBox.TrackMouseLeave += OnTextBoxMouseChange;
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
		_textBox.Validating += OnTextBoxValidating;
		_textBox.Validated += OnTextBoxValidated;
		_layoutFill = new ViewLayoutFill(_textBox);
		_drawDockerInner = new ViewLayoutDocker();
		_drawDockerInner.Add(_layoutFill, ViewDockStyle.Fill);
		_drawDockerOuter = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border);
		_drawDockerOuter.Add(_drawDockerInner, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDockerOuter);
		_buttonManager = new ButtonSpecManagerLayout(this, base.Redirector, _buttonSpecs, null, new ViewLayoutDocker[1] { _drawDockerInner }, new IPaletteMetric[1] { _stateCommon }, new PaletteMetricInt[1] { PaletteMetricInt.HeaderButtonEdgeInsetInputControl }, new PaletteMetricPadding[1] { PaletteMetricPadding.HeaderButtonPaddingInputControl }, base.CreateToolStripRenderer, base.NeedPaintDelegate);
		_toolTipManager = new ToolTipManager();
		_toolTipManager.ShowToolTip += OnShowToolTip;
		_toolTipManager.CancelToolTip += OnCancelToolTip;
		_buttonManager.ToolTipManager = _toolTipManager;
		((KryptonReadOnlyControls)base.Controls).AddInternal(_textBox);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			OnCancelToolTip(this, EventArgs.Empty);
			_buttonManager.Destruct();
		}
		base.Dispose(disposing);
	}

	private void ResetInputControlStyle()
	{
		InputControlStyle = InputControlStyle.Standalone;
	}

	private bool ShouldSerializeInputControlStyle()
	{
		return InputControlStyle != InputControlStyle.Standalone;
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateActive()
	{
		return !_stateActive.IsDefault;
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

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
	}

	public new bool Focus()
	{
		if (TextBox != null)
		{
			return TextBox.Focus();
		}
		return false;
	}

	public new void Select()
	{
		if (TextBox != null)
		{
			TextBox.Select();
		}
	}

	public override Size GetPreferredSize(Size proposedSize)
	{
		if (base.ViewManager != null)
		{
			Size preferredSize = base.ViewManager.GetPreferredSize(base.Renderer, proposedSize);
			if (MaximumSize.Width > 0)
			{
				preferredSize.Width = Math.Min(MaximumSize.Width, preferredSize.Width);
			}
			if (MaximumSize.Height > 0)
			{
				preferredSize.Height = Math.Min(MaximumSize.Height, preferredSize.Width);
			}
			if (MinimumSize.Width > 0)
			{
				preferredSize.Width = Math.Max(MinimumSize.Width, preferredSize.Width);
			}
			if (MinimumSize.Height > 0)
			{
				preferredSize.Height = Math.Max(MinimumSize.Height, preferredSize.Height);
			}
			return preferredSize;
		}
		return base.GetPreferredSize(proposedSize);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool DesignerGetHitTest(Point pt)
	{
		if (base.IsDisposed)
		{
			return false;
		}
		if (_buttonManager != null && _buttonManager.DesignerGetHitTest(pt))
		{
			return true;
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public Component DesignerComponentFromPoint(Point pt)
	{
		if (base.IsDisposed)
		{
			return null;
		}
		return base.ViewManager.ComponentFromPoint(pt);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void DesignerMouseLeave()
	{
		OnMouseLeave(EventArgs.Empty);
	}

	protected void ForceControlLayout()
	{
		if (!base.IsHandleCreated)
		{
			_forcedLayout = true;
			OnLayout(new LayoutEventArgs(null, null));
			_forcedLayout = false;
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

	protected virtual void OnTrackMouseEnter(EventArgs e)
	{
		if (this.TrackMouseEnter != null)
		{
			this.TrackMouseEnter(this, e);
		}
	}

	protected virtual void OnTrackMouseLeave(EventArgs e)
	{
		if (this.TrackMouseLeave != null)
		{
			this.TrackMouseLeave(this, e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override ControlCollection CreateControlsInstance()
	{
		return new KryptonReadOnlyControls(this);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		PerformNeedPaint(needLayout: false);
		InvokeLayout();
		AdjustHeight(ignoreAnchored: true);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		UpdateStateAndPalettes();
		_drawDockerInner.Enabled = base.Enabled;
		_drawDockerOuter.Enabled = base.Enabled;
		_buttonManager.RefreshButtons();
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		_textBox.Focus();
	}

	protected override void OnBackColorChanged(EventArgs e)
	{
		if (this.BackColorChanged != null)
		{
			this.BackColorChanged(this, e);
		}
	}

	protected override void OnBackgroundImageChanged(EventArgs e)
	{
		if (this.BackgroundImageChanged != null)
		{
			this.BackgroundImageChanged(this, e);
		}
	}

	protected override void OnBackgroundImageLayoutChanged(EventArgs e)
	{
		if (this.BackgroundImageLayoutChanged != null)
		{
			this.BackgroundImageLayoutChanged(this, e);
		}
	}

	protected override void OnForeColorChanged(EventArgs e)
	{
		if (this.ForeColorChanged != null)
		{
			this.ForeColorChanged(this, e);
		}
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		ForceControlLayout();
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (!base.IsDisposed && !base.Disposing)
		{
			Padding contentPadding = GetTripleState().PaletteContent.GetContentPadding(_drawDockerOuter.State);
			_layoutFill.DisplayPadding = contentPadding;
		}
		AdjustHeight(ignoreAnchored: false);
		base.OnLayout(levent);
		if (base.IsHandleCreated || _forcedLayout || (base.DesignMode && _textBox != null))
		{
			Rectangle fillRect = _layoutFill.FillRect;
			_textBox.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		_mouseOver = true;
		PerformNeedPaint(needLayout: true);
		_textBox.Invalidate();
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		_mouseOver = false;
		PerformNeedPaint(needLayout: true);
		_textBox.Invalidate();
		base.OnMouseLeave(e);
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		if (_autoSize && !Multiline)
		{
			DockStyle dock = Dock;
			DockStyle dockStyle = dock;
			if ((uint)(dockStyle - 3) <= 2u && (specified & ~BoundsSpecified.Height) == specified)
			{
				_cachedHeight = height;
			}
			height = PreferredHeight;
		}
		else
		{
			_cachedHeight = height;
		}
		base.SetBoundsCore(x, y, width, height, specified);
	}

	protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (base.IsHandleCreated && !e.NeedLayout)
		{
			_textBox.Invalidate();
		}
		else
		{
			ForceControlLayout();
		}
		if (!base.IsDisposed && !base.Disposing)
		{
			UpdateStateAndPalettes();
			IPaletteTriple tripleState = GetTripleState();
			PaletteState paletteState = _drawDockerOuter.State;
			_textBox.BackColor = tripleState.PaletteBack.GetBackColor1(paletteState);
			_textBox.ForeColor = tripleState.PaletteContent.GetContentShortTextColor1(paletteState);
			Font contentShortTextFont = tripleState.PaletteContent.GetContentShortTextFont(paletteState);
			if (_textBox.Handle != IntPtr.Zero && !_textBox.Font.Equals(contentShortTextFont))
			{
				_textBox.Font = contentShortTextFont;
			}
		}
		base.OnNeedPaint(sender, e);
	}

	protected override void OnPaddingChanged(EventArgs e)
	{
		base.OnPaddingChanged(e);
		AdjustHeight(ignoreAnchored: false);
	}

	protected override void OnTabStopChanged(EventArgs e)
	{
		TextBox.TabStop = TabStop;
		base.OnTabStopChanged(e);
	}

	protected override void OnCausesValidationChanged(EventArgs e)
	{
		TextBox.CausesValidation = base.CausesValidation;
		base.OnCausesValidationChanged(e);
	}

	protected override void WndProc(ref Message m)
	{
		int msg = m.Msg;
		int num = msg;
		if (num == 132)
		{
			if (InTransparentDesignMode)
			{
				m.Result = (IntPtr)(-1);
			}
			else
			{
				base.WndProc(ref m);
			}
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	private void UpdateStateAndPalettes()
	{
		IPaletteTriple tripleState = GetTripleState();
		_drawDockerOuter.SetPalettes(tripleState.PaletteBack, tripleState.PaletteBorder);
		_drawDockerOuter.Enabled = base.Enabled;
		PaletteState elementState = ((!IsActive) ? PaletteState.Normal : PaletteState.Tracking);
		_drawDockerOuter.ElementState = elementState;
	}

	internal IPaletteTriple GetTripleState()
	{
		if (base.Enabled)
		{
			if (IsActive)
			{
				return _stateActive;
			}
			return _stateNormal;
		}
		return _stateDisabled;
	}

	private void AdjustHeight(bool ignoreAnchored)
	{
		if (!ignoreAnchored || (Anchor & (AnchorStyles.Top | AnchorStyles.Bottom)) != (AnchorStyles.Top | AnchorStyles.Bottom))
		{
			if (_autoSize && !Multiline)
			{
				base.Height = PreferredHeight;
			}
			else
			{
				base.Height = _cachedHeight;
			}
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
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
		OnGotFocus(e);
	}

	private void OnTextBoxLostFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
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

	private void OnTextBoxValidated(object sender, EventArgs e)
	{
		OnValidated(e);
	}

	private void OnTextBoxValidating(object sender, CancelEventArgs e)
	{
		OnValidating(e);
	}

	private void OnShowToolTip(object sender, ToolTipEventArgs e)
	{
		if (base.IsDisposed || base.Disposing)
		{
			return;
		}
		Form form = FindForm();
		if ((form != null && !form.ContainsFocus) || base.DesignMode)
		{
			return;
		}
		IContentValues contentValues = null;
		LabelStyle style = LabelStyle.ToolTip;
		ButtonSpec buttonSpec = _buttonManager.ButtonSpecFromView(e.Target);
		if (buttonSpec != null && AllowButtonSpecToolTips)
		{
			ButtonSpecToContent buttonSpecToContent = new ButtonSpecToContent(base.Redirector, buttonSpec);
			if (buttonSpecToContent.HasContent)
			{
				contentValues = buttonSpecToContent;
				style = buttonSpec.ToolTipStyle;
			}
		}
		if (contentValues != null)
		{
			if (_visualPopupToolTip != null)
			{
				_visualPopupToolTip.Dispose();
			}
			_visualPopupToolTip = new VisualPopupToolTip(base.Redirector, contentValues, base.Renderer, PaletteBackStyle.ControlToolTip, PaletteBorderStyle.ControlToolTip, CommonHelper.ContentStyleFromLabelStyle(style));
			_visualPopupToolTip.Disposed += OnVisualPopupToolTipDisposed;
			_visualPopupToolTip.ShowCalculatingSize(RectangleToScreen(e.Target.ClientRectangle));
		}
	}

	private void OnCancelToolTip(object sender, EventArgs e)
	{
		if (_visualPopupToolTip != null)
		{
			_visualPopupToolTip.Dispose();
		}
	}

	private void OnVisualPopupToolTipDisposed(object sender, EventArgs e)
	{
		VisualPopupToolTip visualPopupToolTip = (VisualPopupToolTip)sender;
		visualPopupToolTip.Disposed -= OnVisualPopupToolTipDisposed;
		_visualPopupToolTip = null;
	}

	private void OnTextBoxMouseChange(object sender, EventArgs e)
	{
		if (_textBox.MouseOver != _trackingMouseEnter)
		{
			_trackingMouseEnter = _textBox.MouseOver;
			if (_trackingMouseEnter)
			{
				OnTrackMouseEnter(EventArgs.Empty);
			}
			else
			{
				OnTrackMouseLeave(EventArgs.Empty);
			}
		}
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonMaskedTextBox), "ToolboxBitmaps.KryptonMaskedTextBox.bmp")]
[DefaultEvent("MaskInputRejected")]
[DefaultProperty("Mask")]
[DefaultBindingProperty("Text")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBoxDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Uses a mask to distinguish between proper and improper user input.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonMaskedTextBox : VisualControlBase, IContainedInputControl
{
	private class InternalMaskedTextBox : MaskedTextBox
	{
		private KryptonMaskedTextBox _kryptonMaskedTextBox;

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

		public InternalMaskedTextBox(KryptonMaskedTextBox kryptonMaskedTextBox)
		{
			_kryptonMaskedTextBox = kryptonMaskedTextBox;
			base.Size = Size.Empty;
			base.BorderStyle = BorderStyle.None;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 132:
				if (_kryptonMaskedTextBox.InTransparentDesignMode)
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
				_kryptonMaskedTextBox.PerformNeedPaint(needLayout: true);
				Invalidate();
				base.WndProc(ref m);
				break;
			case 512:
				if (!MouseOver)
				{
					MouseOver = true;
					_kryptonMaskedTextBox.PerformNeedPaint(needLayout: true);
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
					if (_kryptonMaskedTextBox.Enabled)
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
						graphics.TextRenderingHint = CommonHelper.PaletteTextHintToRenderingHint(_kryptonMaskedTextBox.StateDisabled.PaletteContent.GetContentShortTextHint(PaletteState.Disabled));
						StringFormat stringFormat = new StringFormat();
						stringFormat.LineAlignment = StringAlignment.Center;
						stringFormat.FormatFlags = StringFormatFlags.NoWrap;
						stringFormat.Trimming = StringTrimming.None;
						switch (_kryptonMaskedTextBox.TextAlign)
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
						string s = ((base.MaskedTextProvider == null) ? Text : base.MaskedTextProvider.ToDisplayString());
						try
						{
							using SolidBrush brush2 = new SolidBrush(ForeColor);
							graphics.DrawString(s, Font, brush2, new RectangleF(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top), stringFormat);
						}
						catch (ArgumentException)
						{
							using SolidBrush brush3 = new SolidBrush(ForeColor);
							graphics.DrawString(s, _kryptonMaskedTextBox.GetTripleState().PaletteContent.GetContentShortTextFont(PaletteState.Disabled), brush3, new RectangleF(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top), stringFormat);
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
				if (_kryptonMaskedTextBox.KryptonContextMenu != null)
				{
					Point screenPt = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
					if ((int)(long)m.LParam == -1)
					{
						screenPt = PointToScreen(new Point(base.Width / 2, base.Height / 2));
					}
					_kryptonMaskedTextBox.KryptonContextMenu.Show(_kryptonMaskedTextBox, screenPt);
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

	public class MaskedTextBoxButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public MaskedTextBoxButtonSpecCollection(KryptonMaskedTextBox owner)
			: base((object)owner)
		{
		}
	}

	private ToolTipManager _toolTipManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ButtonSpecManagerLayout _buttonManager;

	private MaskedTextBoxButtonSpecCollection _buttonSpecs;

	private PaletteInputControlTripleRedirect _stateCommon;

	private PaletteInputControlTripleStates _stateDisabled;

	private PaletteInputControlTripleStates _stateNormal;

	private PaletteInputControlTripleStates _stateActive;

	private ViewLayoutDocker _drawDockerInner;

	private ViewDrawDocker _drawDockerOuter;

	private ViewLayoutFill _layoutFill;

	private InternalMaskedTextBox _maskedTextBox;

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
			return _maskedTextBox.TabStop;
		}
		set
		{
			_maskedTextBox.TabStop = value;
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
	public MaskedTextBox MaskedTextBox => _maskedTextBox;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public Control ContainedControl => MaskedTextBox;

	[Browsable(false)]
	public override bool Focused => MaskedTextBox.Focused;

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
				SetStyle(ControlStyles.FixedHeight, value);
				AdjustHeight(ignoreAnchored: false);
			}
		}
	}

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

	[Editor("System.Windows.Forms.Design.MaskedTextBoxTextEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[RefreshProperties(RefreshProperties.All)]
	public override string Text
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

	public override ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return base.ContextMenuStrip;
		}
		set
		{
			base.ContextMenuStrip = value;
			_maskedTextBox.ContextMenuStrip = value;
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
	[DefaultValue('_')]
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
	[Description("Indicates whether shortcuts defined for the control are enabled.")]
	[DefaultValue(true)]
	public bool ShortcutsEnabled
	{
		get
		{
			return _maskedTextBox.ShortcutsEnabled;
		}
		set
		{
			_maskedTextBox.ShortcutsEnabled = value;
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
	public MaskedTextBoxButtonSpecCollection ButtonSpecs => _buttonSpecs;

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
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver || _maskedTextBox.MouseOver;
		}
	}

	public override Rectangle DisplayRectangle
	{
		get
		{
			ForceViewLayout();
			return new Rectangle(_maskedTextBox.Location, _maskedTextBox.Size);
		}
	}

	protected override Size DefaultSize => new Size(100, PreferredHeight);

	internal bool InTransparentDesignMode => InRibbonDesignMode;

	private int PreferredHeight => GetPreferredSize(new Size(int.MaxValue, int.MaxValue)).Height;

	[Description("Occurs when the value of the HideSelection property changes.")]
	[Category("Property Changed")]
	public event EventHandler HideSelectionChanged;

	[Description("Occurs when the value of the TextAlign property changes.")]
	[Category("Property Changed")]
	public event EventHandler TextAlignChanged;

	[Description("Occurs when the value of the Modified property changes.")]
	[Category("Property Changed")]
	public event EventHandler ModifiedChanged;

	[Description("Occurs when the value of the ReadOnly property changes.")]
	[Category("Property Changed")]
	public event EventHandler ReadOnlyChanged;

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

	public KryptonMaskedTextBox()
	{
		SetStyle(ControlStyles.ContainerControl, value: true);
		SetStyle(ControlStyles.FixedHeight, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		_inputControlStyle = InputControlStyle.Standalone;
		_autoSize = true;
		_cachedHeight = -1;
		_alwaysActive = true;
		_allowButtonSpecToolTips = false;
		_buttonSpecs = new MaskedTextBoxButtonSpecCollection(this);
		_stateCommon = new PaletteInputControlTripleRedirect(base.Redirector, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone, base.NeedPaintDelegate);
		_stateDisabled = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateActive = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_maskedTextBox = new InternalMaskedTextBox(this);
		_maskedTextBox.TrackMouseEnter += OnMaskedTextBoxMouseChange;
		_maskedTextBox.TrackMouseLeave += OnMaskedTextBoxMouseChange;
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
		_maskedTextBox.Validating += OnMaskedTextBoxValidating;
		_maskedTextBox.Validated += OnMaskedTextBoxValidated;
		_layoutFill = new ViewLayoutFill(_maskedTextBox);
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
		((KryptonReadOnlyControls)base.Controls).AddInternal(_maskedTextBox);
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

	public override string ToString()
	{
		return _maskedTextBox.ToString();
	}

	private bool ShouldSerializeCulture()
	{
		return !CultureInfo.CurrentCulture.Equals(Culture);
	}

	private bool ShouldSerializeInputControlStyle()
	{
		return InputControlStyle != InputControlStyle.Standalone;
	}

	private void ResetInputControlStyle()
	{
		InputControlStyle = InputControlStyle.Standalone;
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
		_maskedTextBox.AppendText(text);
	}

	public void Clear()
	{
		_maskedTextBox.Clear();
	}

	public void Copy()
	{
		_maskedTextBox.Copy();
	}

	public void Cut()
	{
		_maskedTextBox.Cut();
	}

	public void Paste()
	{
		_maskedTextBox.Paste();
	}

	public void Select(int start, int length)
	{
		_maskedTextBox.Select(start, length);
	}

	public void SelectAll()
	{
		_maskedTextBox.SelectAll();
	}

	public void DeselectAll()
	{
		_maskedTextBox.DeselectAll();
	}

	public int GetCharFromPosition(Point pt)
	{
		return _maskedTextBox.GetCharFromPosition(pt);
	}

	public int GetCharIndexFromPosition(Point pt)
	{
		return _maskedTextBox.GetCharIndexFromPosition(pt);
	}

	public Point GetPositionFromCharIndex(int index)
	{
		return _maskedTextBox.GetPositionFromCharIndex(index);
	}

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
	}

	public object ValidateText()
	{
		return _maskedTextBox.ValidateText();
	}

	public new bool Focus()
	{
		if (MaskedTextBox != null)
		{
			return MaskedTextBox.Focus();
		}
		return false;
	}

	public new void Select()
	{
		if (MaskedTextBox != null)
		{
			MaskedTextBox.Select();
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

	public void SetLayoutDisplayPadding(Padding padding)
	{
		_layoutFill.DisplayPadding = padding;
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
		_forcedLayout = true;
		OnLayout(new LayoutEventArgs(null, null));
		_forcedLayout = false;
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
		if (_forcedLayout || (base.DesignMode && _maskedTextBox != null))
		{
			Rectangle fillRect = _layoutFill.FillRect;
			_maskedTextBox.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		_mouseOver = true;
		PerformNeedPaint(needLayout: true);
		_maskedTextBox.Invalidate();
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		_mouseOver = false;
		PerformNeedPaint(needLayout: true);
		_maskedTextBox.Invalidate();
		base.OnMouseLeave(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		_maskedTextBox.Focus();
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		if (_autoSize)
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
		if (!e.NeedLayout)
		{
			_maskedTextBox.Invalidate();
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
			_maskedTextBox.BackColor = tripleState.PaletteBack.GetBackColor1(paletteState);
			_maskedTextBox.ForeColor = tripleState.PaletteContent.GetContentShortTextColor1(paletteState);
			Font contentShortTextFont = tripleState.PaletteContent.GetContentShortTextFont(paletteState);
			if (_maskedTextBox.Handle != IntPtr.Zero && !_maskedTextBox.Font.Equals(contentShortTextFont))
			{
				_maskedTextBox.Font = contentShortTextFont;
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
		MaskedTextBox.TabStop = TabStop;
		base.OnTabStopChanged(e);
	}

	protected override void OnCausesValidationChanged(EventArgs e)
	{
		MaskedTextBox.CausesValidation = base.CausesValidation;
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
			if (_autoSize)
			{
				base.Height = PreferredHeight;
			}
			else
			{
				base.Height = _cachedHeight;
			}
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

	private void OnMaskedTextBoxGotFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
		OnGotFocus(e);
	}

	private void OnMaskedTextBoxLostFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
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

	private void OnMaskedTextBoxValidated(object sender, EventArgs e)
	{
		OnValidated(e);
	}

	private void OnMaskedTextBoxValidating(object sender, CancelEventArgs e)
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

	private void OnMaskedTextBoxMouseChange(object sender, EventArgs e)
	{
		if (_maskedTextBox.MouseOver != _trackingMouseEnter)
		{
			_trackingMouseEnter = _maskedTextBox.MouseOver;
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

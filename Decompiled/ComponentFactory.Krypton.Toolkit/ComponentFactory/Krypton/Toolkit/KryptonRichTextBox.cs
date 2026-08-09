using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonRichTextBox), "ToolboxBitmaps.KryptonRichTextBox.bmp")]
[DefaultEvent("TextChanged")]
[DefaultProperty("Text")]
[DefaultBindingProperty("Text")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonRichTextBoxDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Enables the user to enter text, and provides multiline editing and password character masking.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonRichTextBox : VisualControlBase, IContainedInputControl
{
	private class InternalRichTextBox : RichTextBox
	{
		private static readonly double _anInch = 14.4;

		private KryptonRichTextBox _kryptonRichTextBox;

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

		public InternalRichTextBox(KryptonRichTextBox kryptonRichTextBox)
		{
			_kryptonRichTextBox = kryptonRichTextBox;
			base.Size = Size.Empty;
			base.BorderStyle = BorderStyle.None;
		}

		public int Print(int charFrom, int charTo, Graphics gr, Rectangle bounds)
		{
			PI.RECT rc = default(PI.RECT);
			rc.top = 0;
			rc.bottom = (int)((double)bounds.Height * _anInch);
			rc.left = 0;
			rc.right = (int)((double)bounds.Width * _anInch);
			PI.RECT rcPage = default(PI.RECT);
			rcPage.top = 0;
			rcPage.bottom = (int)((double)gr.ClipBounds.Height * _anInch);
			rcPage.left = 0;
			rcPage.right = (int)((double)gr.ClipBounds.Right * _anInch);
			IntPtr hdc = gr.GetHdc();
			PI.FORMATRANGE fORMATRANGE = default(PI.FORMATRANGE);
			fORMATRANGE.chrg.cpMax = charTo;
			fORMATRANGE.chrg.cpMin = charFrom;
			fORMATRANGE.hdc = hdc;
			fORMATRANGE.hdcTarget = hdc;
			fORMATRANGE.rc = rc;
			fORMATRANGE.rcPage = rcPage;
			IntPtr zero = IntPtr.Zero;
			IntPtr zero2 = IntPtr.Zero;
			zero2 = new IntPtr(1);
			IntPtr zero3 = IntPtr.Zero;
			zero3 = Marshal.AllocCoTaskMem(Marshal.SizeOf((object)fORMATRANGE));
			Marshal.StructureToPtr((object)fORMATRANGE, zero3, false);
			zero = (IntPtr)PI.SendMessage(base.Handle, 1081, zero2, zero3);
			Marshal.FreeCoTaskMem(zero3);
			gr.ReleaseHdc(hdc);
			return (int)zero.ToInt64();
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 132:
				if (_kryptonRichTextBox.InTransparentDesignMode)
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
				_kryptonRichTextBox.PerformNeedPaint(needLayout: true);
				Invalidate();
				base.WndProc(ref m);
				break;
			case 512:
				if (!MouseOver)
				{
					MouseOver = true;
					_kryptonRichTextBox.PerformNeedPaint(needLayout: true);
					Invalidate();
				}
				base.WndProc(ref m);
				break;
			case 123:
				if (_kryptonRichTextBox.KryptonContextMenu != null)
				{
					Point screenPt = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
					if ((int)(long)m.LParam == -1)
					{
						screenPt = PointToScreen(new Point(base.Width / 2, base.Height / 2));
					}
					_kryptonRichTextBox.KryptonContextMenu.Show(_kryptonRichTextBox, screenPt);
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

	public class RichTextBoxButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public RichTextBoxButtonSpecCollection(KryptonRichTextBox owner)
			: base((object)owner)
		{
		}
	}

	private ToolTipManager _toolTipManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ButtonSpecManagerLayout _buttonManager;

	private RichTextBoxButtonSpecCollection _buttonSpecs;

	private PaletteInputControlTripleRedirect _stateCommon;

	private PaletteInputControlTripleStates _stateDisabled;

	private PaletteInputControlTripleStates _stateNormal;

	private PaletteInputControlTripleStates _stateActive;

	private ViewLayoutDocker _drawDockerInner;

	private ViewDrawDocker _drawDockerOuter;

	private ViewLayoutFill _layoutFill;

	private InternalRichTextBox _richTextBox;

	private InputControlStyle _inputControlStyle;

	private bool? _fixedActive;

	private bool _inRibbonDesignMode;

	private bool _forcedLayout;

	private bool _autoSize;

	private bool _mouseOver;

	private bool _alwaysActive;

	private bool _allowButtonSpecToolTips;

	private bool _trackingMouseEnter;

	private bool _firstPaint;

	public new bool TabStop
	{
		get
		{
			return _richTextBox.TabStop;
		}
		set
		{
			_richTextBox.TabStop = value;
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
	public RichTextBox RichTextBox => _richTextBox;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public Control ContainedControl => RichTextBox;

	[Browsable(false)]
	public override bool Focused => RichTextBox.Focused;

	[Browsable(false)]
	public override bool AllowDrop
	{
		get
		{
			return base.AllowDrop;
		}
		set
		{
			base.AllowDrop = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue(false)]
	public override bool AutoSize
	{
		get
		{
			return _autoSize;
		}
		set
		{
			_autoSize = value;
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

	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public override string Text
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

	public override ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return base.ContextMenuStrip;
		}
		set
		{
			base.ContextMenuStrip = value;
			_richTextBox.ContextMenuStrip = value;
		}
	}

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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
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
			PerformNeedPaint(needLayout: true);
			_richTextBox.SelectionTabs = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RichTextBoxSelectionTypes SelectionType => _richTextBox.SelectionType;

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
			return _richTextBox.Lines;
		}
		set
		{
			_richTextBox.Lines = value;
		}
	}

	[Category("Appearance")]
	[Description("Indicates, for multiline edit controls, which scroll bars will be shown for this control.")]
	[DefaultValue(typeof(RichTextBoxScrollBars), "Both")]
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
	[DefaultValue(true)]
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
	public RichTextBoxButtonSpecCollection ButtonSpecs => _buttonSpecs;

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
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver || _richTextBox.MouseOver;
		}
	}

	public override Rectangle DisplayRectangle
	{
		get
		{
			ForceViewLayout();
			return new Rectangle(_richTextBox.Location, _richTextBox.Size);
		}
	}

	protected override Size DefaultSize => new Size(100, 96);

	internal bool InTransparentDesignMode => InRibbonDesignMode;

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
	public event LinkClickedEventHandler LinkClicked;

	[Description("Occurs when the horizontal scroll bar is clicked.")]
	[Category("Behavior")]
	public event EventHandler HScroll;

	[Description("Occurs when the vertical scroll bar is clicked.")]
	[Category("Behavior")]
	public event EventHandler VScroll;

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

	public KryptonRichTextBox()
	{
		SetStyle(ControlStyles.ContainerControl, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		_autoSize = false;
		_alwaysActive = true;
		_allowButtonSpecToolTips = false;
		_firstPaint = true;
		_inputControlStyle = InputControlStyle.Standalone;
		_buttonSpecs = new RichTextBoxButtonSpecCollection(this);
		_stateCommon = new PaletteInputControlTripleRedirect(base.Redirector, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone, base.NeedPaintDelegate);
		_stateDisabled = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateActive = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_richTextBox = new InternalRichTextBox(this);
		_richTextBox.TrackMouseEnter += OnRichTextBoxMouseChange;
		_richTextBox.TrackMouseLeave += OnRichTextBoxMouseChange;
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
		_richTextBox.Validating += OnRichTextBoxValidating;
		_richTextBox.Validated += OnRichTextBoxValidated;
		_layoutFill = new ViewLayoutFill(_richTextBox);
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
		((KryptonReadOnlyControls)base.Controls).AddInternal(_richTextBox);
		UpdateStateAndPalettes();
		_richTextBox.BackColor = _stateActive.PaletteBack.GetBackColor1(PaletteState.Tracking);
		_richTextBox.ForeColor = _stateActive.PaletteContent.GetContentShortTextColor1(PaletteState.Tracking);
		if (_richTextBox.Handle != IntPtr.Zero)
		{
			_richTextBox.Font = _stateActive.PaletteContent.GetContentShortTextFont(PaletteState.Tracking);
		}
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

	private bool ShouldSerializeText()
	{
		return true;
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

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
	}

	public new bool Focus()
	{
		if (RichTextBox != null)
		{
			return RichTextBox.Focus();
		}
		return false;
	}

	public new void Select()
	{
		if (RichTextBox != null)
		{
			RichTextBox.Select();
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

	public int Print(int charFrom, int charTo, Graphics gr, Rectangle bounds)
	{
		return _richTextBox.Print(charFrom, charTo, gr, bounds);
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

	protected override void OnTabStopChanged(EventArgs e)
	{
		RichTextBox.TabStop = TabStop;
		base.OnTabStopChanged(e);
	}

	protected override void OnCausesValidationChanged(EventArgs e)
	{
		RichTextBox.CausesValidation = base.CausesValidation;
		base.OnCausesValidationChanged(e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (!base.IsDisposed && !base.Disposing)
		{
			Padding contentPadding = GetTripleState().PaletteContent.GetContentPadding(_drawDockerOuter.State);
			_layoutFill.DisplayPadding = contentPadding;
		}
		base.OnLayout(levent);
		if (!base.IsDisposed && !base.Disposing && (_forcedLayout || (base.DesignMode && _richTextBox != null)))
		{
			Rectangle fillRect = _layoutFill.FillRect;
			_richTextBox.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		_mouseOver = true;
		PerformNeedPaint(needLayout: true);
		_richTextBox.Invalidate();
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		_mouseOver = false;
		PerformNeedPaint(needLayout: true);
		_richTextBox.Invalidate();
		base.OnMouseLeave(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		_richTextBox.Focus();
	}

	protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (!e.NeedLayout)
		{
			_richTextBox.Invalidate();
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
			Color backColor = tripleState.PaletteBack.GetBackColor1(paletteState);
			if (_richTextBox.BackColor != backColor)
			{
				_richTextBox.BackColor = backColor;
			}
			Color contentShortTextColor = tripleState.PaletteContent.GetContentShortTextColor1(paletteState);
			if (_richTextBox.ForeColor != contentShortTextColor)
			{
				_richTextBox.ForeColor = contentShortTextColor;
			}
			Font contentShortTextFont = tripleState.PaletteContent.GetContentShortTextFont(paletteState);
			if (_richTextBox.Handle != IntPtr.Zero && !_richTextBox.Font.Equals(contentShortTextFont))
			{
				_richTextBox.Font = contentShortTextFont;
			}
		}
		base.OnNeedPaint(sender, e);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (_firstPaint)
		{
			_firstPaint = false;
			ForceControlLayout();
		}
		base.OnPaint(e);
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

	private IPaletteTriple GetTripleState()
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

	private void OnRichTextBoxMouseChange(object sender, EventArgs e)
	{
		if (_richTextBox.MouseOver != _trackingMouseEnter)
		{
			_trackingMouseEnter = _richTextBox.MouseOver;
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
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
		OnGotFocus(e);
	}

	private void OnRichTextBoxLostFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
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

	private void OnRichTextBoxValidated(object sender, EventArgs e)
	{
		OnValidated(e);
	}

	private void OnRichTextBoxValidating(object sender, CancelEventArgs e)
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
}

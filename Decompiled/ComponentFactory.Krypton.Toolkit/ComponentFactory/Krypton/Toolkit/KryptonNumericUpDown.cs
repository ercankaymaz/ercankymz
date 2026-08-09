using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonNumericUpDown), "ToolboxBitmaps.KryptonNumericUpDown.bmp")]
[DefaultEvent("ValueChanged")]
[DefaultProperty("Value")]
[DefaultBindingProperty("Value")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonNumericUpDownDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Represents a Windows spin box (also known as an up-down control) that displays numeric values.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonNumericUpDown : VisualControlBase, IContainedInputControl
{
	private class InternalNumericUpDown : NumericUpDown
	{
		private KryptonNumericUpDown _kryptonNumericUpDown;

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

		protected internal bool InternalUserEdit
		{
			get
			{
				return base.UserEdit;
			}
			set
			{
				base.UserEdit = value;
			}
		}

		public event EventHandler TrackMouseEnter;

		public event EventHandler TrackMouseLeave;

		public InternalNumericUpDown(KryptonNumericUpDown kryptonNumericUpDown)
		{
			_kryptonNumericUpDown = kryptonNumericUpDown;
			base.Size = Size.Empty;
			base.BorderStyle = BorderStyle.None;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 132:
				if (_kryptonNumericUpDown.InTransparentDesignMode)
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
				_kryptonNumericUpDown.PerformNeedPaint(needLayout: true);
				Invalidate();
				base.WndProc(ref m);
				break;
			case 512:
				if (!MouseOver)
				{
					MouseOver = true;
					_kryptonNumericUpDown.PerformNeedPaint(needLayout: true);
					Invalidate();
				}
				base.WndProc(ref m);
				break;
			case 123:
				if (_kryptonNumericUpDown.KryptonContextMenu != null)
				{
					Point screenPt = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
					if ((int)(long)m.LParam == -1)
					{
						screenPt = PointToScreen(new Point(base.Width / 2, base.Height / 2));
					}
					_kryptonNumericUpDown.KryptonContextMenu.Show(_kryptonNumericUpDown, screenPt);
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

	private class SubclassEdit : NativeWindow
	{
		private KryptonNumericUpDown _kryptonNumericUpDown;

		private InternalNumericUpDown _internalNumericUpDown;

		private bool _mouseOver;

		private Point _mousePoint;

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

		public Point MousePoint => _mousePoint;

		public bool Visible
		{
			set
			{
				PI.SetWindowPos(base.Handle, IntPtr.Zero, 0, 0, 0, 0, (uint)(3 | (value ? 64 : 128)));
			}
		}

		protected KryptonNumericUpDown NumericUpDown => _kryptonNumericUpDown;

		public event EventHandler TrackMouseEnter;

		public event EventHandler TrackMouseLeave;

		public SubclassEdit(IntPtr editControl, KryptonNumericUpDown kryptonNumericUpDown, InternalNumericUpDown internalNumericUpDown)
		{
			_kryptonNumericUpDown = kryptonNumericUpDown;
			_internalNumericUpDown = internalNumericUpDown;
			AssignHandle(editControl);
			_mousePoint = new Point(-2147483647, -2147483647);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 132:
				if (NumericUpDown.InTransparentDesignMode)
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
				_mousePoint = new Point(-2147483647, -2147483647);
				NumericUpDown.PerformNeedPaint(needLayout: true);
				base.WndProc(ref m);
				break;
			case 512:
				_mousePoint = new Point((int)m.LParam.ToInt64());
				if (!MouseOver)
				{
					PI.TRACKMOUSEEVENTS tme = new PI.TRACKMOUSEEVENTS
					{
						cbSize = (uint)Marshal.SizeOf(typeof(PI.TRACKMOUSEEVENTS)),
						dwHoverTime = 100u,
						dwFlags = 2u,
						hWnd = base.Handle
					};
					PI.TrackMouseEvent(ref tme);
					MouseOver = true;
					NumericUpDown.PerformNeedPaint(needLayout: true);
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
					PI.RECT lpRect2 = default(PI.RECT);
					PI.GetClientRect(base.Handle, out lpRect2);
					using (SolidBrush brush = new SolidBrush(_internalNumericUpDown.BackColor))
					{
						graphics.FillRectangle(brush, new Rectangle(lpRect2.left, lpRect2.top, lpRect2.right - lpRect2.left, lpRect2.bottom - lpRect2.top));
					}
					Size borderSize = SystemInformation.BorderSize;
					lpRect2.left -= borderSize.Width + 1;
					if (_kryptonNumericUpDown.Enabled)
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
						graphics.TextRenderingHint = CommonHelper.PaletteTextHintToRenderingHint(_kryptonNumericUpDown.StateDisabled.PaletteContent.GetContentShortTextHint(PaletteState.Disabled));
						StringFormat stringFormat = new StringFormat();
						stringFormat.LineAlignment = StringAlignment.Near;
						stringFormat.FormatFlags = StringFormatFlags.NoWrap;
						stringFormat.Trimming = StringTrimming.None;
						switch (_kryptonNumericUpDown.TextAlign)
						{
						case HorizontalAlignment.Left:
							if (_kryptonNumericUpDown.RightToLeft == RightToLeft.Yes)
							{
								stringFormat.Alignment = StringAlignment.Far;
							}
							else
							{
								stringFormat.Alignment = StringAlignment.Near;
							}
							break;
						case HorizontalAlignment.Right:
							if (_kryptonNumericUpDown.RightToLeft == RightToLeft.Yes)
							{
								stringFormat.Alignment = StringAlignment.Far;
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
						try
						{
							using SolidBrush brush2 = new SolidBrush(_internalNumericUpDown.ForeColor);
							graphics.DrawString(_internalNumericUpDown.Text, _internalNumericUpDown.Font, brush2, new RectangleF(lpRect2.left, lpRect2.top, lpRect2.right - lpRect2.left, lpRect2.bottom - lpRect2.top), stringFormat);
						}
						catch (ArgumentException)
						{
							using SolidBrush brush3 = new SolidBrush(_internalNumericUpDown.ForeColor);
							graphics.DrawString(_internalNumericUpDown.Text, _kryptonNumericUpDown.GetTripleState().PaletteContent.GetContentShortTextFont(PaletteState.Disabled), brush3, new RectangleF(lpRect2.left, lpRect2.top, lpRect2.right - lpRect2.left, lpRect2.bottom - lpRect2.top), stringFormat);
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
				if (NumericUpDown.KryptonContextMenu != null)
				{
					Point screenPt = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
					if ((int)(long)m.LParam == -1)
					{
						PI.GetClientRect(base.Handle, out var lpRect);
						screenPt = NumericUpDown.PointToScreen(new Point((lpRect.right - lpRect.left) / 2, (lpRect.bottom - lpRect.top) / 2));
					}
					NumericUpDown.KryptonContextMenu.Show(NumericUpDown, screenPt);
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

	private class SubclassButtons : SubclassEdit, IContentValues, IDisposable
	{
		private PaletteTripleToPalette _palette;

		private ViewDrawButton _viewButton;

		private IntPtr _screenDC;

		private Point _mousePressed;

		public SubclassButtons(IntPtr buttonsPtr, KryptonNumericUpDown kryptonNumericUpDown, InternalNumericUpDown internalNumericUpDown)
			: base(buttonsPtr, kryptonNumericUpDown, internalNumericUpDown)
		{
			_mousePressed = new Point(-2147483647, -2147483647);
			_screenDC = PI.CreateCompatibleDC(IntPtr.Zero);
		}

		public void Dispose()
		{
			if (_screenDC != IntPtr.Zero)
			{
				PI.DeleteDC(_screenDC);
				_screenDC = IntPtr.Zero;
			}
		}

		public virtual string GetShortText()
		{
			return string.Empty;
		}

		public virtual Image GetImage(PaletteState state)
		{
			return null;
		}

		public virtual Color GetImageTransparentColor(PaletteState state)
		{
			return Color.Empty;
		}

		public virtual string GetLongText()
		{
			return string.Empty;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 513:
			case 515:
				_mousePressed = new Point((int)m.LParam.ToInt64());
				base.WndProc(ref m);
				PI.RedrawWindow(base.Handle, IntPtr.Zero, IntPtr.Zero, 768u);
				break;
			case 514:
			case 516:
			case 517:
			case 519:
			case 520:
				_mousePressed = new Point(-2147483647, -2147483647);
				base.WndProc(ref m);
				PI.RedrawWindow(base.Handle, IntPtr.Zero, IntPtr.Zero, 768u);
				break;
			case 15:
			case 792:
			{
				PI.PAINTSTRUCT ps = default(PI.PAINTSTRUCT);
				IntPtr intPtr = ((!(m.WParam == IntPtr.Zero)) ? m.WParam : PI.BeginPaint(base.Handle, ref ps));
				PI.RECT lpRect = default(PI.RECT);
				PI.GetClientRect(base.Handle, out lpRect);
				Rectangle rect = new Rectangle(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top);
				try
				{
					IntPtr intPtr2 = PI.CreateCompatibleBitmap(intPtr, rect.Right, rect.Bottom);
					if (!(intPtr2 != IntPtr.Zero))
					{
						break;
					}
					try
					{
						PI.SelectObject(_screenDC, intPtr2);
						using Graphics graphics = Graphics.FromHdc(_screenDC);
						using (SolidBrush brush = new SolidBrush(base.NumericUpDown.NumericUpDown.BackColor))
						{
							graphics.FillRectangle(brush, rect);
						}
						DrawUpDownButtons(graphics, new Rectangle(rect.X, rect.Y, rect.Width, rect.Height - 1));
						PI.BitBlt(intPtr, rect.X, rect.Y, rect.Width, rect.Height, _screenDC, rect.X, rect.Y, 13369376);
						break;
					}
					finally
					{
						PI.DeleteObject(intPtr2);
					}
				}
				finally
				{
					if (m.WParam == IntPtr.Zero)
					{
						PI.EndPaint(base.Handle, ref ps);
					}
				}
			}
			default:
				base.WndProc(ref m);
				break;
			}
		}

		private void DrawUpDownButtons(Graphics g, Rectangle clientRect)
		{
			if (_viewButton == null)
			{
				_palette = new PaletteTripleToPalette(base.NumericUpDown.Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone);
				_viewButton = new ViewDrawButton(_palette, _palette, _palette, _palette, _palette, _palette, _palette, new PaletteMetricRedirect(base.NumericUpDown.Redirector), this, VisualOrientation.Top, useMnemonic: false);
			}
			_palette.SetStyles(base.NumericUpDown.UpDownButtonStyle);
			Rectangle rectangle = new Rectangle(clientRect.X, clientRect.Y, clientRect.Width, clientRect.Height / 2);
			Rectangle rectangle2 = new Rectangle(clientRect.X, rectangle.Bottom, clientRect.Width, clientRect.Bottom - rectangle.Bottom);
			using ViewLayoutContext viewLayoutContext = new ViewLayoutContext(base.NumericUpDown, base.NumericUpDown.Renderer);
			using RenderContext renderContext = new RenderContext(base.NumericUpDown, g, clientRect, base.NumericUpDown.Renderer);
			viewLayoutContext.DisplayRectangle = rectangle;
			_viewButton.ElementState = ButtonElementState(rectangle);
			_viewButton.Layout(viewLayoutContext);
			_viewButton.Render(renderContext);
			renderContext.Renderer.RenderGlyph.DrawInputControlNumericUpGlyph(renderContext, _viewButton.ClientRectangle, _palette.PaletteContent, _viewButton.ElementState);
			viewLayoutContext.DisplayRectangle = rectangle2;
			_viewButton.ElementState = ButtonElementState(rectangle2);
			_viewButton.Layout(viewLayoutContext);
			_viewButton.Render(renderContext);
			renderContext.Renderer.RenderGlyph.DrawInputControlNumericDownGlyph(renderContext, _viewButton.ClientRectangle, _palette.PaletteContent, _viewButton.ElementState);
		}

		private PaletteState ButtonElementState(Rectangle buttonRect)
		{
			if (base.NumericUpDown.Enabled)
			{
				if (base.MouseOver && buttonRect.Contains(base.MousePoint))
				{
					if (buttonRect.Contains(_mousePressed))
					{
						return PaletteState.Pressed;
					}
					if (_mousePressed.X == -2147483647)
					{
						return PaletteState.Tracking;
					}
				}
				if (base.NumericUpDown.IsActive || (base.NumericUpDown.IsFixedActive && base.NumericUpDown.InputControlStyle == InputControlStyle.Standalone))
				{
					if (base.NumericUpDown.InputControlStyle == InputControlStyle.Standalone)
					{
						return PaletteState.CheckedNormal;
					}
					return PaletteState.CheckedTracking;
				}
				return PaletteState.Normal;
			}
			return PaletteState.Disabled;
		}
	}

	public class NumericUpDownButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public NumericUpDownButtonSpecCollection(KryptonNumericUpDown owner)
			: base((object)owner)
		{
		}
	}

	private ToolTipManager _toolTipManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ButtonSpecManagerLayout _buttonManager;

	private NumericUpDownButtonSpecCollection _buttonSpecs;

	private PaletteInputControlTripleRedirect _stateCommon;

	private PaletteInputControlTripleStates _stateDisabled;

	private PaletteInputControlTripleStates _stateNormal;

	private PaletteInputControlTripleStates _stateActive;

	private ViewLayoutDocker _drawDockerInner;

	private ViewDrawDocker _drawDockerOuter;

	private ViewLayoutFill _layoutFill;

	private InternalNumericUpDown _numericUpDown;

	private InputControlStyle _inputControlStyle;

	private ButtonStyle _upDownButtonStyle;

	private SubclassEdit _subclassEdit;

	private SubclassButtons _subclassButtons;

	private bool? _fixedActive;

	private bool _inRibbonDesignMode;

	private bool _forcedLayout;

	private bool _mouseOver;

	private bool _alwaysActive;

	private bool _allowButtonSpecToolTips;

	private bool _trackingMouseEnter;

	private int _cachedHeight;

	public new bool TabStop
	{
		get
		{
			return _numericUpDown.TabStop;
		}
		set
		{
			_numericUpDown.TabStop = value;
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
	public NumericUpDown NumericUpDown => _numericUpDown;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public Control ContainedControl => NumericUpDown;

	[Browsable(false)]
	public override bool Focused => NumericUpDown.Focused;

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

	[Browsable(false)]
	[Localizable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	public override string Text
	{
		get
		{
			return _numericUpDown.Text;
		}
		set
		{
			_numericUpDown.Text = value;
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
			_numericUpDown.ContextMenuStrip = value;
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
	[Description("Up and down buttons style.")]
	public ButtonStyle UpDownButtonStyle
	{
		get
		{
			return _upDownButtonStyle;
		}
		set
		{
			if (_upDownButtonStyle != value)
			{
				_upDownButtonStyle = value;
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
	public NumericUpDownButtonSpecCollection ButtonSpecs => _buttonSpecs;

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
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver || _numericUpDown.MouseOver || (_subclassEdit != null && _subclassEdit.MouseOver) || (_subclassButtons != null && _subclassButtons.MouseOver);
		}
	}

	public override Rectangle DisplayRectangle
	{
		get
		{
			ForceViewLayout();
			return new Rectangle(_numericUpDown.Location, _numericUpDown.Size);
		}
	}

	protected bool UserEdit
	{
		get
		{
			return _numericUpDown.InternalUserEdit;
		}
		set
		{
			_numericUpDown.InternalUserEdit = value;
		}
	}

	protected override Size DefaultSize => new Size(120, PreferredHeight);

	internal bool InTransparentDesignMode => InRibbonDesignMode;

	internal bool IsFixedActive => _fixedActive.HasValue;

	private int PreferredHeight => GetPreferredSize(new Size(int.MaxValue, int.MaxValue)).Height;

	[Description("Occurs when the value of the Value property changes.")]
	[Category("Action")]
	public event EventHandler ValueChanged;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler TextChanged;

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

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler PaddingChanged;

	public KryptonNumericUpDown()
	{
		SetStyle(ControlStyles.ContainerControl, value: true);
		SetStyle(ControlStyles.FixedHeight, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		_inputControlStyle = InputControlStyle.Standalone;
		_upDownButtonStyle = ButtonStyle.InputControl;
		_cachedHeight = -1;
		_alwaysActive = true;
		_allowButtonSpecToolTips = false;
		_buttonSpecs = new NumericUpDownButtonSpecCollection(this);
		_stateCommon = new PaletteInputControlTripleRedirect(base.Redirector, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone, base.NeedPaintDelegate);
		_stateDisabled = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateActive = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_numericUpDown = new InternalNumericUpDown(this);
		_numericUpDown.TextChanged += OnNumericUpDownTextChanged;
		_numericUpDown.ValueChanged += OnNumericUpDownValueChanged;
		_numericUpDown.TrackMouseEnter += OnNumericUpDownMouseChange;
		_numericUpDown.TrackMouseLeave += OnNumericUpDownMouseChange;
		_numericUpDown.GotFocus += OnNumericUpDownGotFocus;
		_numericUpDown.LostFocus += OnNumericUpDownLostFocus;
		_numericUpDown.KeyDown += OnNumericUpDownKeyDown;
		_numericUpDown.KeyUp += OnNumericUpDownKeyUp;
		_numericUpDown.KeyPress += OnNumericUpDownKeyPress;
		_numericUpDown.PreviewKeyDown += OnNumericUpDownPreviewKeyDown;
		_numericUpDown.Validating += OnNumericUpDownValidating;
		_numericUpDown.Validated += OnNumericUpDownValidated;
		_layoutFill = new ViewLayoutFill(_numericUpDown);
		_layoutFill.DisplayPadding = new Padding(1, 1, 1, 0);
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
		((KryptonReadOnlyControls)base.Controls).AddInternal(_numericUpDown);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			OnCancelToolTip(this, EventArgs.Empty);
			_buttonManager.Destruct();
			if (_subclassButtons != null)
			{
				_subclassButtons.Dispose();
			}
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

	private void ResetUpDownButtonStyle()
	{
		UpDownButtonStyle = ButtonStyle.InputControl;
	}

	private bool ShouldSerializeUpDownButtonStyle()
	{
		return UpDownButtonStyle != ButtonStyle.InputControl;
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

	public void Select(int start, int length)
	{
		_numericUpDown.Select(start, length);
	}

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
	}

	public new bool Focus()
	{
		if (NumericUpDown != null)
		{
			return NumericUpDown.Focus();
		}
		return false;
	}

	public new void Select()
	{
		if (NumericUpDown != null)
		{
			NumericUpDown.Select();
		}
	}

	public void UpButton()
	{
		NumericUpDown.UpButton();
	}

	public void DownButton()
	{
		NumericUpDown.DownButton();
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
		if (!base.IsHandleCreated)
		{
			_forcedLayout = true;
			OnLayout(new LayoutEventArgs(null, null));
			_forcedLayout = false;
		}
	}

	protected virtual void OnValueChanged(EventArgs e)
	{
		if (this.ValueChanged != null)
		{
			this.ValueChanged(this, e);
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
		UpdateChildEditControl();
		SubclassButtonsControl();
		PerformNeedPaint(needLayout: false);
		InvokeLayout();
		base.Height = PreferredHeight;
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		UpdateStateAndPalettes();
		UpdateChildEditControl();
		_drawDockerInner.Enabled = base.Enabled;
		_drawDockerOuter.Enabled = base.Enabled;
		_buttonManager.RefreshButtons();
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnPaletteChanged(EventArgs e)
	{
		InvalidateChildren();
		base.OnPaletteChanged(e);
	}

	protected override void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		InvalidateChildren();
		base.OnPaletteChanged(e);
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
			SubclassEditControl();
			SubclassButtonsControl();
			base.Height = PreferredHeight;
			base.OnLayout(levent);
			if (base.IsHandleCreated || _forcedLayout || (base.DesignMode && _numericUpDown != null))
			{
				Rectangle fillRect = _layoutFill.FillRect;
				_numericUpDown.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
			}
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		_mouseOver = true;
		PerformNeedPaint(needLayout: true);
		InvalidateChildren();
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		_mouseOver = false;
		PerformNeedPaint(needLayout: true);
		InvalidateChildren();
		base.OnMouseLeave(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		_numericUpDown.Focus();
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height)
		{
			if (_cachedHeight == -1)
			{
				_cachedHeight = height;
			}
			height = PreferredHeight;
		}
		if ((specified & BoundsSpecified.Height) == BoundsSpecified.Height)
		{
			_cachedHeight = height;
		}
		base.SetBoundsCore(x, y, width, height, specified);
	}

	protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (base.IsHandleCreated && !e.NeedLayout)
		{
			InvalidateChildren();
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
			_numericUpDown.BackColor = tripleState.PaletteBack.GetBackColor1(paletteState);
			_numericUpDown.ForeColor = tripleState.PaletteContent.GetContentShortTextColor1(paletteState);
			Font contentShortTextFont = tripleState.PaletteContent.GetContentShortTextFont(paletteState);
			if (_numericUpDown.Handle != IntPtr.Zero && !_numericUpDown.Font.Equals(contentShortTextFont))
			{
				_numericUpDown.Font = contentShortTextFont;
			}
		}
		base.OnNeedPaint(sender, e);
	}

	protected override void OnPaddingChanged(EventArgs e)
	{
		if (this.PaddingChanged != null)
		{
			this.PaddingChanged(this, e);
		}
	}

	protected override void OnTabStopChanged(EventArgs e)
	{
		NumericUpDown.TabStop = TabStop;
		base.OnTabStopChanged(e);
	}

	protected override void OnCausesValidationChanged(EventArgs e)
	{
		NumericUpDown.CausesValidation = base.CausesValidation;
		base.OnCausesValidationChanged(e);
	}

	protected override void OnTextChanged(EventArgs e)
	{
		if (this.TextChanged != null)
		{
			this.TextChanged(this, e);
		}
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

	private void InvalidateChildren()
	{
		if (NumericUpDown != null)
		{
			NumericUpDown.Invalidate();
			PI.RedrawWindow(base.Handle, IntPtr.Zero, IntPtr.Zero, 133u);
		}
	}

	private void SubclassEditControl()
	{
		if (_subclassEdit != null && _numericUpDown.Controls.Count >= 2 && _subclassEdit.Handle != _numericUpDown.Controls[1].Handle)
		{
			_subclassEdit.TrackMouseEnter -= OnNumericUpDownMouseChange;
			_subclassEdit.TrackMouseLeave -= OnNumericUpDownMouseChange;
			_subclassEdit.ReleaseHandle();
			_subclassEdit = null;
		}
		if (_subclassEdit == null && _numericUpDown.Controls.Count >= 2)
		{
			_subclassEdit = new SubclassEdit(_numericUpDown.Controls[1].Handle, this, _numericUpDown);
			_subclassEdit.TrackMouseEnter += OnNumericUpDownMouseChange;
			_subclassEdit.TrackMouseLeave += OnNumericUpDownMouseChange;
		}
	}

	private void SubclassButtonsControl()
	{
		if (_subclassButtons != null && _numericUpDown.Controls.Count >= 1 && _subclassButtons.Handle != _numericUpDown.Controls[0].Handle)
		{
			_subclassButtons.TrackMouseEnter -= OnNumericUpDownMouseChange;
			_subclassButtons.TrackMouseLeave -= OnNumericUpDownMouseChange;
			_subclassButtons.ReleaseHandle();
			_subclassButtons = null;
		}
		if (_subclassButtons == null && _numericUpDown.Controls.Count >= 1)
		{
			_subclassButtons = new SubclassButtons(_numericUpDown.Controls[0].Handle, this, _numericUpDown);
			_subclassButtons.TrackMouseEnter += OnNumericUpDownMouseChange;
			_subclassButtons.TrackMouseLeave += OnNumericUpDownMouseChange;
		}
	}

	private void UpdateChildEditControl()
	{
		SubclassEditControl();
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

	private void OnNumericUpDownTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(e);
	}

	private void OnNumericUpDownValueChanged(object sender, EventArgs e)
	{
		OnValueChanged(e);
	}

	private void OnNumericUpDownGotFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
		InvalidateChildren();
		base.OnGotFocus(e);
	}

	private void OnNumericUpDownLostFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
		InvalidateChildren();
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

	private void OnNumericUpDownValidated(object sender, EventArgs e)
	{
		OnValidated(e);
	}

	private void OnNumericUpDownValidating(object sender, CancelEventArgs e)
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

	private void OnNumericUpDownMouseChange(object sender, EventArgs e)
	{
		bool flag = _numericUpDown.MouseOver || (_subclassEdit != null && _subclassEdit.MouseOver) || (_subclassButtons != null && _subclassButtons.MouseOver);
		if (flag != _trackingMouseEnter)
		{
			_trackingMouseEnter = flag;
			InvalidateChildren();
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

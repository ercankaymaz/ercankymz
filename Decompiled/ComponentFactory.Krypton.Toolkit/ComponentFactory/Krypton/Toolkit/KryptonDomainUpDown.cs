using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonDomainUpDown), "ToolboxBitmaps.KryptonDomainUpDown.bmp")]
[DefaultEvent("SelectedItemChanged")]
[DefaultProperty("Items")]
[DefaultBindingProperty("SelectedItem")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonDomainUpDownDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Represents a Windows spin box (also known as an up-down control) that displays string values.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonDomainUpDown : VisualControlBase, IContainedInputControl
{
	private class InternalDomainUpDown : DomainUpDown
	{
		private KryptonDomainUpDown _kryptonDomainUpDown;

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

		public InternalDomainUpDown(KryptonDomainUpDown kryptonDomainUpDown)
		{
			_kryptonDomainUpDown = kryptonDomainUpDown;
			base.Size = Size.Empty;
			base.BorderStyle = BorderStyle.None;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 132:
				if (_kryptonDomainUpDown.InTransparentDesignMode)
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
				_kryptonDomainUpDown.PerformNeedPaint(needLayout: true);
				Invalidate();
				base.WndProc(ref m);
				break;
			case 512:
				if (!MouseOver)
				{
					MouseOver = true;
					_kryptonDomainUpDown.PerformNeedPaint(needLayout: true);
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
					if (_kryptonDomainUpDown.Enabled)
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
						graphics.TextRenderingHint = CommonHelper.PaletteTextHintToRenderingHint(_kryptonDomainUpDown.StateDisabled.PaletteContent.GetContentShortTextHint(PaletteState.Disabled));
						StringFormat stringFormat = new StringFormat();
						stringFormat.LineAlignment = StringAlignment.Near;
						stringFormat.FormatFlags = StringFormatFlags.NoWrap;
						stringFormat.Trimming = StringTrimming.None;
						switch (_kryptonDomainUpDown.TextAlign)
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
						try
						{
							using SolidBrush brush2 = new SolidBrush(ForeColor);
							graphics.DrawString(Text, Font, brush2, new RectangleF(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top), stringFormat);
						}
						catch (ArgumentException)
						{
							using SolidBrush brush3 = new SolidBrush(ForeColor);
							graphics.DrawString(Text, _kryptonDomainUpDown.GetTripleState().PaletteContent.GetContentShortTextFont(PaletteState.Disabled), brush3, new RectangleF(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top), stringFormat);
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
				if (_kryptonDomainUpDown.KryptonContextMenu != null)
				{
					Point screenPt = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
					if ((int)(long)m.LParam == -1)
					{
						screenPt = PointToScreen(new Point(base.Width / 2, base.Height / 2));
					}
					_kryptonDomainUpDown.KryptonContextMenu.Show(_kryptonDomainUpDown, screenPt);
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
		private KryptonDomainUpDown _kryptonDomainUpDown;

		private InternalDomainUpDown _internalDomainUpDown;

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

		protected KryptonDomainUpDown DomainUpDown => _kryptonDomainUpDown;

		public event EventHandler TrackMouseEnter;

		public event EventHandler TrackMouseLeave;

		public SubclassEdit(IntPtr editControl, KryptonDomainUpDown kryptonDomainUpDown, InternalDomainUpDown internalDomainUpDown)
		{
			_kryptonDomainUpDown = kryptonDomainUpDown;
			_internalDomainUpDown = internalDomainUpDown;
			AssignHandle(editControl);
			_mousePoint = new Point(-2147483647, -2147483647);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 132:
				if (DomainUpDown.InTransparentDesignMode)
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
				DomainUpDown.PerformNeedPaint(needLayout: true);
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
					DomainUpDown.PerformNeedPaint(needLayout: true);
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
					using (SolidBrush brush = new SolidBrush(_internalDomainUpDown.BackColor))
					{
						graphics.FillRectangle(brush, new Rectangle(lpRect2.left, lpRect2.top, lpRect2.right - lpRect2.left, lpRect2.bottom - lpRect2.top));
					}
					if (_kryptonDomainUpDown.Enabled)
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
						graphics.TextRenderingHint = CommonHelper.PaletteTextHintToRenderingHint(_kryptonDomainUpDown.StateDisabled.PaletteContent.GetContentShortTextHint(PaletteState.Disabled));
						StringFormat stringFormat = new StringFormat();
						stringFormat.LineAlignment = StringAlignment.Center;
						stringFormat.FormatFlags = StringFormatFlags.NoWrap;
						stringFormat.Trimming = StringTrimming.None;
						switch (_kryptonDomainUpDown.TextAlign)
						{
						case HorizontalAlignment.Left:
							if (_kryptonDomainUpDown.RightToLeft == RightToLeft.Yes)
							{
								stringFormat.Alignment = StringAlignment.Far;
							}
							else
							{
								stringFormat.Alignment = StringAlignment.Near;
							}
							break;
						case HorizontalAlignment.Right:
							if (_kryptonDomainUpDown.RightToLeft == RightToLeft.Yes)
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
							using SolidBrush brush2 = new SolidBrush(_internalDomainUpDown.ForeColor);
							graphics.DrawString(_internalDomainUpDown.Text, _internalDomainUpDown.Font, brush2, new RectangleF(lpRect2.left, lpRect2.top, lpRect2.right - lpRect2.left, lpRect2.bottom - lpRect2.top), stringFormat);
						}
						catch (ArgumentException)
						{
							using SolidBrush brush3 = new SolidBrush(_internalDomainUpDown.ForeColor);
							graphics.DrawString(_internalDomainUpDown.Text, _kryptonDomainUpDown.GetTripleState().PaletteContent.GetContentShortTextFont(PaletteState.Disabled), brush3, new RectangleF(lpRect2.left, lpRect2.top, lpRect2.right - lpRect2.left, lpRect2.bottom - lpRect2.top), stringFormat);
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
				if (DomainUpDown.KryptonContextMenu != null)
				{
					Point screenPt = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
					if ((int)(long)m.LParam == -1)
					{
						PI.GetClientRect(base.Handle, out var lpRect);
						screenPt = DomainUpDown.PointToScreen(new Point((lpRect.right - lpRect.left) / 2, (lpRect.bottom - lpRect.top) / 2));
					}
					DomainUpDown.KryptonContextMenu.Show(DomainUpDown, screenPt);
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

		public SubclassButtons(IntPtr buttonsPtr, KryptonDomainUpDown kryptonDomainUpDown, InternalDomainUpDown internalDomainUpDown)
			: base(buttonsPtr, kryptonDomainUpDown, internalDomainUpDown)
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
						using (SolidBrush brush = new SolidBrush(base.DomainUpDown.DomainUpDown.BackColor))
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
				_palette = new PaletteTripleToPalette(base.DomainUpDown.Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone);
				_viewButton = new ViewDrawButton(_palette, _palette, _palette, _palette, _palette, _palette, _palette, new PaletteMetricRedirect(base.DomainUpDown.Redirector), this, VisualOrientation.Top, useMnemonic: false);
			}
			_palette.SetStyles(base.DomainUpDown.UpDownButtonStyle);
			Rectangle rectangle = new Rectangle(clientRect.X, clientRect.Y, clientRect.Width, clientRect.Height / 2);
			Rectangle rectangle2 = new Rectangle(clientRect.X, rectangle.Bottom, clientRect.Width, clientRect.Bottom - rectangle.Bottom);
			using ViewLayoutContext viewLayoutContext = new ViewLayoutContext(base.DomainUpDown, base.DomainUpDown.Renderer);
			using RenderContext renderContext = new RenderContext(base.DomainUpDown, g, clientRect, base.DomainUpDown.Renderer);
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
			if (base.DomainUpDown.Enabled)
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
				if (base.DomainUpDown.IsActive || (base.DomainUpDown.IsFixedActive && base.DomainUpDown.InputControlStyle == InputControlStyle.Standalone))
				{
					if (base.DomainUpDown.InputControlStyle == InputControlStyle.Standalone)
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

	public class DomainUpDownButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public DomainUpDownButtonSpecCollection(KryptonDomainUpDown owner)
			: base((object)owner)
		{
		}
	}

	private ToolTipManager _toolTipManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ButtonSpecManagerLayout _buttonManager;

	private DomainUpDownButtonSpecCollection _buttonSpecs;

	private PaletteInputControlTripleRedirect _stateCommon;

	private PaletteInputControlTripleStates _stateDisabled;

	private PaletteInputControlTripleStates _stateNormal;

	private PaletteInputControlTripleStates _stateActive;

	private ViewLayoutDocker _drawDockerInner;

	private ViewDrawDocker _drawDockerOuter;

	private ViewLayoutFill _layoutFill;

	private InternalDomainUpDown _domainUpDown;

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
			return DomainUpDown.TabStop;
		}
		set
		{
			DomainUpDown.TabStop = value;
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
	public DomainUpDown DomainUpDown => _domainUpDown;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public Control ContainedControl => DomainUpDown;

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
	public override bool Focused => DomainUpDown.Focused;

	public override string Text
	{
		get
		{
			return DomainUpDown.Text;
		}
		set
		{
			DomainUpDown.Text = value;
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
			DomainUpDown.ContextMenuStrip = value;
		}
	}

	[Category("Data")]
	[Description("The allowable items of the domain up down.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	public DomainUpDown.DomainUpDownItemCollection Items => DomainUpDown.Items;

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

	[Category("Appearance")]
	[Description("Indicates how the text should be aligned for edit controls.")]
	[DefaultValue(typeof(HorizontalAlignment), "Left")]
	[Localizable(true)]
	public HorizontalAlignment TextAlign
	{
		get
		{
			return DomainUpDown.TextAlign;
		}
		set
		{
			DomainUpDown.TextAlign = value;
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
			return DomainUpDown.UpDownAlign;
		}
		set
		{
			DomainUpDown.UpDownAlign = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the up-down control will increment and decrement the value when the UP ARROW and DOWN ARROW are used.")]
	[DefaultValue(true)]
	public bool InterceptArrowKeys
	{
		get
		{
			return DomainUpDown.InterceptArrowKeys;
		}
		set
		{
			DomainUpDown.InterceptArrowKeys = value;
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
			return DomainUpDown.ReadOnly;
		}
		set
		{
			DomainUpDown.ReadOnly = value;
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
	public DomainUpDownButtonSpecCollection ButtonSpecs => _buttonSpecs;

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
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver || _domainUpDown.MouseOver || (_subclassEdit != null && _subclassEdit.MouseOver) || (_subclassButtons != null && _subclassButtons.MouseOver);
		}
	}

	public override Rectangle DisplayRectangle
	{
		get
		{
			ForceViewLayout();
			return new Rectangle(DomainUpDown.Location, DomainUpDown.Size);
		}
	}

	protected bool UserEdit
	{
		get
		{
			return _domainUpDown.InternalUserEdit;
		}
		set
		{
			_domainUpDown.InternalUserEdit = value;
		}
	}

	protected override Size DefaultSize => new Size(120, PreferredHeight);

	internal bool InTransparentDesignMode => InRibbonDesignMode;

	internal bool IsFixedActive => _fixedActive.HasValue;

	private int PreferredHeight => GetPreferredSize(new Size(int.MaxValue, int.MaxValue)).Height;

	[Category("Behavior")]
	[Description("Occurs when the value of the SelectedItem property changes.")]
	public event EventHandler SelectedItemChanged;

	[Category("Action")]
	[Description("Occurs when the user scrolls the scroll box.")]
	public event ScrollEventHandler Scroll;

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

	public KryptonDomainUpDown()
	{
		SetStyle(ControlStyles.ContainerControl, value: true);
		SetStyle(ControlStyles.FixedHeight, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		_inputControlStyle = InputControlStyle.Standalone;
		_upDownButtonStyle = ButtonStyle.InputControl;
		_cachedHeight = -1;
		_alwaysActive = true;
		_allowButtonSpecToolTips = false;
		_buttonSpecs = new DomainUpDownButtonSpecCollection(this);
		_stateCommon = new PaletteInputControlTripleRedirect(base.Redirector, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone, base.NeedPaintDelegate);
		_stateDisabled = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_stateActive = new PaletteInputControlTripleStates(_stateCommon, base.NeedPaintDelegate);
		_domainUpDown = new InternalDomainUpDown(this);
		_domainUpDown.Scroll += OnDomainUpDownScroll;
		_domainUpDown.SelectedItemChanged += OnDomainUpDownSelectedItemChanged;
		_domainUpDown.TrackMouseEnter += OnDomainUpDownMouseChange;
		_domainUpDown.TrackMouseLeave += OnDomainUpDownMouseChange;
		_domainUpDown.GotFocus += OnDomainUpDownGotFocus;
		_domainUpDown.LostFocus += OnDomainUpDownLostFocus;
		_domainUpDown.KeyDown += OnDomainUpDownKeyDown;
		_domainUpDown.KeyUp += OnDomainUpDownKeyUp;
		_domainUpDown.KeyPress += OnDomainUpDownKeyPress;
		_domainUpDown.PreviewKeyDown += OnDomainUpDownPreviewKeyDown;
		_domainUpDown.TextChanged += OnDomainUpDownTextChanged;
		_domainUpDown.Validating += OnDomainUpDownValidating;
		_domainUpDown.Validated += OnDomainUpDownValidated;
		_layoutFill = new ViewLayoutFill(_domainUpDown);
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
		((KryptonReadOnlyControls)base.Controls).AddInternal(_domainUpDown);
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

	public void UpButton()
	{
		DomainUpDown.UpButton();
	}

	public void DownButton()
	{
		DomainUpDown.DownButton();
	}

	public void Select(int start, int length)
	{
		DomainUpDown.Select(start, length);
	}

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
	}

	public new bool Focus()
	{
		if (DomainUpDown != null)
		{
			return DomainUpDown.Focus();
		}
		return false;
	}

	public new void Select()
	{
		if (DomainUpDown != null)
		{
			DomainUpDown.Select();
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
		if (!base.IsHandleCreated)
		{
			_forcedLayout = true;
			OnLayout(new LayoutEventArgs(null, null));
			_forcedLayout = false;
		}
	}

	protected virtual void OnSelectedItemChanged(EventArgs e)
	{
		if (this.SelectedItemChanged != null)
		{
			this.SelectedItemChanged(this, e);
		}
	}

	protected virtual void OnScroll(ScrollEventArgs e)
	{
		if (this.Scroll != null)
		{
			this.Scroll(this, e);
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
			if (base.IsHandleCreated || _forcedLayout || (base.DesignMode && _domainUpDown != null))
			{
				Rectangle fillRect = _layoutFill.FillRect;
				_domainUpDown.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
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
		_domainUpDown.Focus();
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
			_domainUpDown.BackColor = tripleState.PaletteBack.GetBackColor1(paletteState);
			_domainUpDown.ForeColor = tripleState.PaletteContent.GetContentShortTextColor1(paletteState);
			Font contentShortTextFont = tripleState.PaletteContent.GetContentShortTextFont(paletteState);
			if (_domainUpDown.Handle != IntPtr.Zero && !_domainUpDown.Font.Equals(contentShortTextFont))
			{
				_domainUpDown.Font = contentShortTextFont;
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
		DomainUpDown.TabStop = TabStop;
		base.OnTabStopChanged(e);
	}

	protected override void OnCausesValidationChanged(EventArgs e)
	{
		DomainUpDown.CausesValidation = base.CausesValidation;
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

	private void InvalidateChildren()
	{
		if (DomainUpDown != null)
		{
			DomainUpDown.Invalidate();
			PI.RedrawWindow(base.Handle, IntPtr.Zero, IntPtr.Zero, 133u);
		}
	}

	private void SubclassEditControl()
	{
		if (_subclassEdit != null && _domainUpDown.Controls.Count >= 2 && _subclassEdit.Handle != _domainUpDown.Controls[1].Handle)
		{
			_subclassEdit.TrackMouseEnter -= OnDomainUpDownMouseChange;
			_subclassEdit.TrackMouseLeave -= OnDomainUpDownMouseChange;
			_subclassEdit.ReleaseHandle();
			_subclassEdit = null;
		}
		if (_subclassEdit == null && _domainUpDown.Controls.Count >= 2)
		{
			_subclassEdit = new SubclassEdit(_domainUpDown.Controls[1].Handle, this, _domainUpDown);
			_subclassEdit.TrackMouseEnter += OnDomainUpDownMouseChange;
			_subclassEdit.TrackMouseLeave += OnDomainUpDownMouseChange;
		}
	}

	private void SubclassButtonsControl()
	{
		if (_subclassButtons != null && _domainUpDown.Controls.Count >= 1 && _subclassButtons.Handle != _domainUpDown.Controls[0].Handle)
		{
			_subclassButtons.TrackMouseEnter -= OnDomainUpDownMouseChange;
			_subclassButtons.TrackMouseLeave -= OnDomainUpDownMouseChange;
			_subclassButtons.ReleaseHandle();
			_subclassButtons = null;
		}
		if (_subclassButtons == null && _domainUpDown.Controls.Count >= 1)
		{
			_subclassButtons = new SubclassButtons(_domainUpDown.Controls[0].Handle, this, _domainUpDown);
			_subclassButtons.TrackMouseEnter += OnDomainUpDownMouseChange;
			_subclassButtons.TrackMouseLeave += OnDomainUpDownMouseChange;
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

	private void OnDomainUpDownTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(e);
	}

	private void OnDomainUpDownScroll(object sender, ScrollEventArgs e)
	{
		OnScroll(e);
	}

	private void OnDomainUpDownSelectedItemChanged(object sender, EventArgs e)
	{
		OnSelectedItemChanged(e);
	}

	private void OnDomainUpDownGotFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
		InvalidateChildren();
		base.OnGotFocus(e);
	}

	private void OnDomainUpDownLostFocus(object sender, EventArgs e)
	{
		UpdateStateAndPalettes();
		PerformNeedPaint(needLayout: true);
		InvalidateChildren();
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

	private void OnDomainUpDownValidated(object sender, EventArgs e)
	{
		OnValidated(e);
	}

	private void OnDomainUpDownValidating(object sender, CancelEventArgs e)
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

	private void OnDomainUpDownMouseChange(object sender, EventArgs e)
	{
		bool flag = _domainUpDown.MouseOver || (_subclassEdit != null && _subclassEdit.MouseOver) || (_subclassButtons != null && _subclassButtons.MouseOver);
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

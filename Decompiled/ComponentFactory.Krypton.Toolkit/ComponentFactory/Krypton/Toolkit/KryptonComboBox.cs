using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonComboBox), "ToolboxBitmaps.KryptonComboBox.bmp")]
[DefaultEvent("SelectedIndexChanged")]
[DefaultProperty("Text")]
[DefaultBindingProperty("Text")]
[LookupBindingProperties("DataSource", "DisplayMember", "ValueMember", "SelectedValue")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonComboBoxDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Displays an editable textbox with a drop-down list of permitted values.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonComboBox : VisualControlBase, IContainedInputControl, ISupportInitializeNotification, ISupportInitialize
{
	private class InternalPanel : Panel
	{
		private KryptonComboBox _kryptonComboBox;

		public InternalPanel(KryptonComboBox kryptonComboBox)
		{
			_kryptonComboBox = kryptonComboBox;
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			Size empty = Size.Empty;
			foreach (Control control in base.Controls)
			{
				Size preferredSize = control.GetPreferredSize(proposedSize);
				empty.Width = Math.Max(empty.Width, preferredSize.Width);
				empty.Height = Math.Max(empty.Height, preferredSize.Height);
			}
			return new Size(empty.Width - 3, _kryptonComboBox._comboBox.ItemHeight + 4);
		}

		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			int num = msg;
			if (num == 132)
			{
				if (_kryptonComboBox.InTransparentDesignMode)
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
	}

	private class InternalComboBox : ComboBox, IContentValues
	{
		private KryptonComboBox _kryptonComboBox;

		private PaletteTripleToPalette _palette;

		private ViewDrawButton _viewButton;

		private bool? _appThemed;

		private bool _mouseTracking;

		private bool _mouseOver;

		private bool _dropped;

		public bool Dropped
		{
			get
			{
				return _dropped;
			}
			set
			{
				_dropped = value;
			}
		}

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

		private bool IsAppThemed
		{
			get
			{
				try
				{
					if (!_appThemed.HasValue)
					{
						_appThemed = PI.IsThemeActive() && PI.IsAppThemed();
					}
					return _appThemed.Value;
				}
				catch
				{
					return false;
				}
			}
		}

		public event EventHandler TrackMouseEnter;

		public event EventHandler TrackMouseLeave;

		public InternalComboBox(KryptonComboBox kryptonComboBox)
		{
			_kryptonComboBox = kryptonComboBox;
			base.ItemHeight = 15;
			base.DropDownHeight = 200;
			base.DrawMode = DrawMode.OwnerDrawVariable;
		}

		public void ClearAppThemed()
		{
			_appThemed = null;
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

		protected override void OnFontChanged(EventArgs e)
		{
			if (_osMajorVersion < 6)
			{
				base.ItemHeight = Font.Height + 1;
			}
			else if (IsAppThemed)
			{
				base.ItemHeight = Font.Height - 1;
			}
			else
			{
				base.ItemHeight = Font.Height;
			}
			base.OnFontChanged(e);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 132:
				if (_kryptonComboBox.InTransparentDesignMode)
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
				_mouseTracking = false;
				_kryptonComboBox.PerformNeedPaint(needLayout: false);
				Invalidate();
				break;
			case 512:
			{
				if (!MouseOver)
				{
					MouseOver = true;
					_kryptonComboBox.PerformNeedPaint(needLayout: false);
					Invalidate();
				}
				PI.RECT lpRect2 = default(PI.RECT);
				PI.GetClientRect(base.Handle, out lpRect2);
				int verticalScrollBarWidth2 = SystemInformation.VerticalScrollBarWidth;
				Size borderSize2 = SystemInformation.BorderSize;
				lpRect2.left += borderSize2.Width;
				lpRect2.right -= borderSize2.Width + verticalScrollBarWidth2;
				lpRect2.top += borderSize2.Height;
				lpRect2.bottom -= borderSize2.Height;
				Rectangle rectangle = new Rectangle(lpRect2.right + 2, lpRect2.top, verticalScrollBarWidth2 - 2, lpRect2.bottom - lpRect2.top);
				Point pt = new Point((int)m.LParam);
				bool flag = rectangle.Contains(pt);
				if (flag != _mouseTracking)
				{
					_mouseTracking = flag;
					_kryptonComboBox.PerformNeedPaint(needLayout: false);
					Invalidate();
				}
				break;
			}
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
					int verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
					Size borderSize = SystemInformation.BorderSize;
					lpRect.top += borderSize.Height;
					lpRect.bottom -= borderSize.Height;
					Rectangle drawRect;
					if (_kryptonComboBox.RightToLeft == RightToLeft.Yes)
					{
						drawRect = new Rectangle(lpRect.left + borderSize.Width + 1, lpRect.top + 1, verticalScrollBarWidth - 2, lpRect.bottom - lpRect.top - 2);
						lpRect.left += borderSize.Width + verticalScrollBarWidth;
						lpRect.right -= borderSize.Width;
					}
					else
					{
						lpRect.left += borderSize.Width;
						lpRect.right -= borderSize.Width + verticalScrollBarWidth;
						drawRect = new Rectangle(lpRect.right + 1, lpRect.top + 1, verticalScrollBarWidth - 2, lpRect.bottom - lpRect.top - 2);
					}
					PI.IntersectClipRect(intPtr, lpRect.left + 2, lpRect.top + 2, lpRect.right - 2, lpRect.bottom - 2);
					if (_kryptonComboBox.Enabled)
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
						graphics.TextRenderingHint = CommonHelper.PaletteTextHintToRenderingHint(_kryptonComboBox.StateDisabled.Item.PaletteContent.GetContentShortTextHint(PaletteState.Disabled));
						StringFormat stringFormat = new StringFormat();
						stringFormat.LineAlignment = StringAlignment.Center;
						stringFormat.FormatFlags = StringFormatFlags.NoWrap;
						stringFormat.Trimming = StringTrimming.None;
						if (_kryptonComboBox.RightToLeft == RightToLeft.Yes)
						{
							stringFormat.Alignment = StringAlignment.Far;
						}
						else
						{
							stringFormat.Alignment = StringAlignment.Near;
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
							graphics.DrawString(Text, _kryptonComboBox.GetComboBoxTripleState().PaletteContent.GetContentShortTextFont(PaletteState.Disabled), brush3, new RectangleF(lpRect.left, lpRect.top, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top), stringFormat);
						}
					}
					PI.SelectClipRgn(intPtr, IntPtr.Zero);
					DrawDropButton(graphics, drawRect);
				}
				if (m.WParam == IntPtr.Zero)
				{
					PI.EndPaint(base.Handle, ref ps);
				}
				break;
			}
			case 123:
				if (_kryptonComboBox.KryptonContextMenu != null)
				{
					Point screenPt = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
					if ((int)(long)m.LParam == -1)
					{
						screenPt = PointToScreen(new Point(base.Width / 2, base.Height / 2));
					}
					_kryptonComboBox.KryptonContextMenu.Show(_kryptonComboBox, screenPt);
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

		private void DrawDropButton(Graphics g, Rectangle drawRect)
		{
			if (_viewButton == null)
			{
				_palette = new PaletteTripleToPalette(_kryptonComboBox.Redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone);
				_viewButton = new ViewDrawButton(_palette, _palette, _palette, _palette, _palette, _palette, _palette, new PaletteMetricRedirect(_kryptonComboBox.Redirector), this, VisualOrientation.Top, useMnemonic: false);
			}
			_palette.SetStyles(_kryptonComboBox.DropButtonStyle);
			PaletteState elementState = ((!_kryptonComboBox.Enabled) ? PaletteState.Disabled : (Dropped ? PaletteState.Pressed : (_mouseTracking ? PaletteState.Tracking : ((!_kryptonComboBox.IsActive && (!_kryptonComboBox.IsFixedActive || _kryptonComboBox.InputControlStyle != InputControlStyle.Standalone)) ? PaletteState.Normal : ((_kryptonComboBox.InputControlStyle != InputControlStyle.Standalone) ? PaletteState.CheckedTracking : PaletteState.CheckedNormal)))));
			_viewButton.ElementState = elementState;
			using (ViewLayoutContext viewLayoutContext = new ViewLayoutContext(_kryptonComboBox, _kryptonComboBox.Renderer))
			{
				viewLayoutContext.DisplayRectangle = drawRect;
				_viewButton.Layout(viewLayoutContext);
			}
			using (SolidBrush brush = new SolidBrush(BackColor))
			{
				g.FillRectangle(brush, drawRect);
			}
			using RenderContext renderContext = new RenderContext(_kryptonComboBox, g, drawRect, _kryptonComboBox.Renderer);
			_viewButton.Render(renderContext);
			renderContext.Renderer.RenderGlyph.DrawInputControlDropDownGlyph(renderContext, _viewButton.ClientRectangle, _palette.PaletteContent, elementState);
		}
	}

	private class SubclassEdit : NativeWindow
	{
		private KryptonComboBox _kryptonComboBox;

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

		public bool Visible
		{
			set
			{
				PI.SetWindowPos(base.Handle, IntPtr.Zero, 0, 0, 0, 0, (uint)(3 | (value ? 64 : 128)));
			}
		}

		public event EventHandler TrackMouseEnter;

		public event EventHandler TrackMouseLeave;

		public SubclassEdit(IntPtr editControl, KryptonComboBox kryptonComboBox)
		{
			_kryptonComboBox = kryptonComboBox;
			AssignHandle(editControl);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 132:
				if (_kryptonComboBox.InTransparentDesignMode)
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
				_kryptonComboBox.PerformNeedPaint(needLayout: false);
				base.WndProc(ref m);
				break;
			case 512:
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
					_kryptonComboBox.PerformNeedPaint(needLayout: false);
				}
				base.WndProc(ref m);
				break;
			case 123:
				if (_kryptonComboBox.KryptonContextMenu != null)
				{
					Point screenPt = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
					if ((int)(long)m.LParam == -1)
					{
						PI.GetClientRect(base.Handle, out var lpRect);
						screenPt = new Point((lpRect.right - lpRect.left) / 2, (lpRect.bottom - lpRect.top) / 2);
					}
					_kryptonComboBox.KryptonContextMenu.Show(_kryptonComboBox, screenPt);
				}
				else
				{
					base.WndProc(ref m);
				}
				break;
			case 2:
				base.WndProc(ref m);
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

	public class ComboBoxButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public ComboBoxButtonSpecCollection(KryptonComboBox owner)
			: base((object)owner)
		{
		}
	}

	private static int _osMajorVersion;

	private ToolTipManager _toolTipManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ButtonSpecManagerLayout _buttonManager;

	private ComboBoxButtonSpecCollection _buttonSpecs;

	private PaletteComboBoxRedirect _stateCommon;

	private PaletteComboBoxStates _stateDisabled;

	private PaletteComboBoxStates _stateNormal;

	private PaletteComboBoxJustComboStates _stateActive;

	private PaletteComboBoxJustItemStates _stateTracking;

	private ViewLayoutDocker _drawDockerInner;

	private ViewDrawDocker _drawDockerOuter;

	private ViewLayoutFill _layoutFill;

	private InternalComboBox _comboBox;

	private InternalPanel _comboHolder;

	private SubclassEdit _subclassEdit;

	private ButtonStyle _dropButtonStyle;

	private PaletteBackStyle _dropBackStyle;

	private InputControlStyle _inputControlStyle;

	private bool? _fixedActive;

	private FixedContentValue _contentValues;

	private ButtonStyle _style;

	private ViewDrawButton _drawButton;

	private ViewDrawPanel _drawPanel;

	private AutoCompleteMode _autoCompleteMode;

	private AutoCompleteSource _autoCompleteSource;

	private Padding _layoutPadding;

	private IntPtr _screenDC;

	private bool _initializing;

	private bool _initialized;

	private bool _firstTimePaint;

	private bool _trackingMouseEnter;

	private bool _inRibbonDesignMode;

	private bool _forcedLayout;

	private bool _mouseOver;

	private bool _alwaysActive;

	private bool _allowButtonSpecToolTips;

	private int _cachedHeight;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsInitialized
	{
		[DebuggerStepThrough]
		get
		{
			return _initialized;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsInitializing
	{
		[DebuggerStepThrough]
		get
		{
			return _initializing;
		}
	}

	public new bool TabStop
	{
		get
		{
			return _comboBox.TabStop;
		}
		set
		{
			_comboBox.TabStop = value;
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
	public ComboBox ComboBox => _comboBox;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(false)]
	public Control ContainedControl => ComboBox;

	[Browsable(false)]
	public override bool Focused => ComboBox.Focused;

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

	public override string Text
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

	public override ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return base.ContextMenuStrip;
		}
		set
		{
			base.ContextMenuStrip = value;
			_comboBox.ContextMenuStrip = value;
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
			if (_comboBox.DropDownStyle != value)
			{
				if (value == ComboBoxStyle.Simple)
				{
					throw new ArgumentOutOfRangeException("KryptonComboBox does not support the DropDownStyle.Simple style.");
				}
				_comboBox.DropDownStyle = value;
				UpdateEditControl();
			}
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
	[Description("Do not use this property, it is provided for backwards compatability only.")]
	[Localizable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ItemHeight
	{
		get
		{
			return _comboBox.ItemHeight;
		}
		set
		{
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
	[Description("Item style.")]
	public ButtonStyle ItemStyle
	{
		get
		{
			return _style;
		}
		set
		{
			if (_style != value)
			{
				_style = value;
				_stateCommon.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("DropButton style.")]
	public ButtonStyle DropButtonStyle
	{
		get
		{
			return _dropButtonStyle;
		}
		set
		{
			if (_dropButtonStyle != value)
			{
				_dropButtonStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("DropButton style.")]
	public PaletteBackStyle DropBackStyle
	{
		get
		{
			return _dropBackStyle;
		}
		set
		{
			if (_dropBackStyle != value)
			{
				_dropBackStyle = value;
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
	public ComboBoxButtonSpecCollection ButtonSpecs => _buttonSpecs;

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
			_autoCompleteMode = value;
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
			_autoCompleteSource = value;
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
	[DefaultValue(false)]
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

	[Category("Visuals")]
	[Description("Overrides for defining common combobox appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteComboBoxRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled combobox appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteComboBoxStates StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal combobox appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteComboBoxStates StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining active combobox appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteComboBoxJustComboStates StateActive => _stateActive;

	[Category("Visuals")]
	[Description("Overrides for defining tracking combobox appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteComboBoxJustItemStates StateTracking => _stateTracking;

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
			return base.DesignMode || AlwaysActive || base.ContainsFocus || _mouseOver || _comboBox.MouseOver || (_subclassEdit != null && _subclassEdit.MouseOver);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolTipManager ToolTipManager => _toolTipManager;

	public override Rectangle DisplayRectangle
	{
		get
		{
			ForceViewLayout();
			return new Rectangle(_comboHolder.Location, _comboHolder.Size);
		}
	}

	protected override Size DefaultSize => new Size(121, PreferredHeight);

	internal bool InTransparentDesignMode => InRibbonDesignMode;

	internal bool IsFixedActive => _fixedActive.HasValue;

	private int PreferredHeight => GetPreferredSize(new Size(int.MaxValue, int.MaxValue)).Height;

	[Category("Behavior")]
	[Description("Occurs when the control has been fully initialized.")]
	public event EventHandler Initialized;

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
	public event ListControlConvertEventHandler Format;

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
	public new event EventHandler Paint;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler PaddingChanged;

	static KryptonComboBox()
	{
		_osMajorVersion = Environment.OSVersion.Version.Major;
	}

	public KryptonComboBox()
	{
		SetStyle(ControlStyles.ContainerControl, value: true);
		SetStyle(ControlStyles.FixedHeight, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		_alwaysActive = true;
		_allowButtonSpecToolTips = false;
		_cachedHeight = -1;
		_inputControlStyle = InputControlStyle.Standalone;
		_dropButtonStyle = ButtonStyle.InputControl;
		_dropBackStyle = PaletteBackStyle.ControlClient;
		_style = ButtonStyle.ListItem;
		_firstTimePaint = true;
		_autoCompleteMode = AutoCompleteMode.None;
		_autoCompleteSource = AutoCompleteSource.None;
		_buttonSpecs = new ComboBoxButtonSpecCollection(this);
		_stateCommon = new PaletteComboBoxRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateDisabled = new PaletteComboBoxStates(_stateCommon.ComboBox, _stateCommon.Item, base.NeedPaintDelegate);
		_stateNormal = new PaletteComboBoxStates(_stateCommon.ComboBox, _stateCommon.Item, base.NeedPaintDelegate);
		_stateActive = new PaletteComboBoxJustComboStates(_stateCommon.ComboBox, base.NeedPaintDelegate);
		_stateTracking = new PaletteComboBoxJustItemStates(_stateCommon.Item, base.NeedPaintDelegate);
		_contentValues = new FixedContentValue();
		_drawPanel = new ViewDrawPanel(_stateCommon.DropBack);
		_drawButton = new ViewDrawButton(_stateDisabled.Item, _stateNormal.Item, _stateTracking.Item, _stateTracking.Item, new PaletteMetricRedirect(base.Redirector), _contentValues, VisualOrientation.Top, useMnemonic: false);
		_comboBox = new InternalComboBox(this);
		_comboBox.DrawItem += OnComboBoxDrawItem;
		_comboBox.MeasureItem += OnComboBoxMeasureItem;
		_comboBox.TrackMouseEnter += OnComboBoxMouseChange;
		_comboBox.TrackMouseLeave += OnComboBoxMouseChange;
		_comboBox.DropDown += OnComboBoxDropDown;
		_comboBox.DropDownClosed += OnComboBoxDropDownClosed;
		_comboBox.DropDownStyleChanged += OnComboBoxDropDownStyleChanged;
		_comboBox.SelectedIndexChanged += OnComboBoxSelectedIndexChanged;
		_comboBox.SelectionChangeCommitted += OnComboBoxSelectionChangeCommitted;
		_comboBox.TextUpdate += OnComboBoxTextUpdate;
		_comboBox.TextChanged += OnComboBoxTextChanged;
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
		_comboBox.Validating += OnComboBoxValidating;
		_comboBox.Validated += OnComboBoxValidated;
		_comboHolder = new InternalPanel(this);
		_comboHolder.Controls.Add(_comboBox);
		_layoutFill = new ViewLayoutFill(_comboHolder);
		_drawDockerInner = new ViewLayoutDocker();
		_drawDockerInner.Add(_layoutFill, ViewDockStyle.Fill);
		_drawDockerOuter = new ViewDrawDocker(_stateNormal.ComboBox.Back, _stateNormal.ComboBox.Border);
		_drawDockerOuter.Add(_drawDockerInner, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDockerOuter);
		_buttonManager = new ButtonSpecManagerLayout(this, base.Redirector, _buttonSpecs, null, new ViewLayoutDocker[1] { _drawDockerInner }, new IPaletteMetric[1] { _stateCommon.ComboBox }, new PaletteMetricInt[1] { PaletteMetricInt.HeaderButtonEdgeInsetInputControl }, new PaletteMetricPadding[1] { PaletteMetricPadding.HeaderButtonPaddingInputControl }, base.CreateToolStripRenderer, base.NeedPaintDelegate);
		_toolTipManager = new ToolTipManager();
		_toolTipManager.ShowToolTip += OnShowToolTip;
		_toolTipManager.CancelToolTip += OnCancelToolTip;
		_buttonManager.ToolTipManager = _toolTipManager;
		_screenDC = PI.CreateCompatibleDC(IntPtr.Zero);
		((KryptonReadOnlyControls)base.Controls).AddInternal(_comboHolder);
		IPaletteTriple comboBox = _stateActive.ComboBox;
		_comboBox.BackColor = comboBox.PaletteBack.GetBackColor1(PaletteState.Tracking);
		_comboBox.ForeColor = comboBox.PaletteContent.GetContentShortTextColor1(PaletteState.Tracking);
		_comboBox.Font = comboBox.PaletteContent.GetContentShortTextFont(PaletteState.Tracking);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			DetachEditControl();
			OnCancelToolTip(this, EventArgs.Empty);
			_buttonManager.Destruct();
		}
		base.Dispose(disposing);
		if (_screenDC != IntPtr.Zero)
		{
			PI.DeleteDC(_screenDC);
			_screenDC = IntPtr.Zero;
		}
	}

	public virtual void BeginInit()
	{
		_initializing = true;
	}

	public virtual void EndInit()
	{
		_initialized = true;
		_initializing = false;
		_comboBox.DrawMode = DrawMode.OwnerDrawVariable;
		OnInitialized(EventArgs.Empty);
	}

	private void ResetInputControlStyle()
	{
		InputControlStyle = InputControlStyle.Standalone;
	}

	private bool ShouldSerializeInputControlStyle()
	{
		return InputControlStyle != InputControlStyle.Standalone;
	}

	private void ResetItemStyle()
	{
		ItemStyle = ButtonStyle.ListItem;
	}

	private bool ShouldSerializeItemStyle()
	{
		return ItemStyle != ButtonStyle.ListItem;
	}

	private void ResetDropButtonStyle()
	{
		DropButtonStyle = ButtonStyle.InputControl;
	}

	private bool ShouldSerializeDropButtonStyle()
	{
		return DropButtonStyle != ButtonStyle.InputControl;
	}

	private void ResetDropBackStyle()
	{
		DropBackStyle = PaletteBackStyle.ControlClient;
	}

	private bool ShouldSerializeDropBackStyle()
	{
		return DropBackStyle != PaletteBackStyle.ControlClient;
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

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
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

	public void BeginUpdate()
	{
		_comboBox.BeginUpdate();
	}

	public void EndUpdate()
	{
		_comboBox.EndUpdate();
	}

	public void SetFixedState(bool active)
	{
		_fixedActive = active;
	}

	public new bool Focus()
	{
		if (ComboBox != null)
		{
			return ComboBox.Focus();
		}
		return false;
	}

	public new void Select()
	{
		if (ComboBox != null)
		{
			ComboBox.Select();
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
		_layoutPadding = padding;
	}

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

	public Component DesignerComponentFromPoint(Point pt)
	{
		if (base.IsDisposed)
		{
			return null;
		}
		return base.ViewManager.ComponentFromPoint(pt);
	}

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

	protected virtual void OnInitialized(EventArgs e)
	{
		if (this.Initialized != null)
		{
			this.Initialized(this, EventArgs.Empty);
		}
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

	protected virtual void OnFormat(ListControlConvertEventArgs e)
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
		UpdateEditControl();
		PerformNeedPaint(needLayout: false);
		InvokeLayout();
		base.Height = PreferredHeight;
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		UpdateEditControl();
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

	protected override void OnPaddingChanged(EventArgs e)
	{
		if (this.PaddingChanged != null)
		{
			this.PaddingChanged(this, e);
		}
	}

	protected override void OnTabStopChanged(EventArgs e)
	{
		ComboBox.TabStop = TabStop;
		base.OnTabStopChanged(e);
	}

	protected override void OnCausesValidationChanged(EventArgs e)
	{
		ComboBox.CausesValidation = base.CausesValidation;
		base.OnCausesValidationChanged(e);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (_firstTimePaint)
		{
			_firstTimePaint = false;
			ForceControlLayout();
		}
		base.OnPaint(e);
		if (this.Paint != null)
		{
			this.Paint(this, e);
		}
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		ForceControlLayout();
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		_mouseOver = true;
		PerformNeedPaint(needLayout: false);
		_comboBox.Invalidate();
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		_mouseOver = false;
		PerformNeedPaint(needLayout: false);
		_comboBox.Invalidate();
		base.OnMouseLeave(e);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		base.OnGotFocus(e);
		_comboBox.Focus();
	}

	protected override void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		if (_comboBox != null)
		{
			UpdateStateAndPalettes();
			IPaletteTriple comboBoxTripleState = GetComboBoxTripleState();
			PaletteState paletteState = _drawDockerOuter.State;
			_comboBox.BackColor = comboBoxTripleState.PaletteBack.GetBackColor1(paletteState);
			_comboBox.ForeColor = comboBoxTripleState.PaletteContent.GetContentShortTextColor1(paletteState);
			_comboBox.Font = comboBoxTripleState.PaletteContent.GetContentShortTextFont(paletteState);
			_comboBox.ClearAppThemed();
			_comboHolder.BackColor = _comboBox.BackColor;
		}
		base.OnUserPreferenceChanged(sender, e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (base.IsDisposed || base.Disposing || DroppedDown)
		{
			return;
		}
		AttachEditControl();
		base.Height = PreferredHeight;
		base.OnLayout(levent);
		if ((_forcedLayout || (base.DesignMode && _comboHolder != null)) && _layoutFill.FillRect.Height > 0 && _layoutFill.FillRect.Width > 0)
		{
			Rectangle fillRect = _layoutFill.FillRect;
			if (fillRect != _comboHolder.Bounds)
			{
				_comboHolder.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
				_comboBox.SetBounds(-(1 + _layoutPadding.Left), -(1 + _layoutPadding.Top), fillRect.Width + 2 + _layoutPadding.Right, fillRect.Height + 2 + _layoutPadding.Bottom);
			}
		}
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
		if (!e.NeedLayout)
		{
			_comboBox.Invalidate();
		}
		else if (!DroppedDown)
		{
			ForceControlLayout();
		}
		if (!base.IsDisposed && !base.Disposing)
		{
			UpdateStateAndPalettes();
			IPaletteTriple comboBoxTripleState = GetComboBoxTripleState();
			PaletteState paletteState = _drawDockerOuter.State;
			_comboBox.BackColor = comboBoxTripleState.PaletteBack.GetBackColor1(paletteState);
			_comboBox.ForeColor = comboBoxTripleState.PaletteContent.GetContentShortTextColor1(paletteState);
			_comboBox.Font = comboBoxTripleState.PaletteContent.GetContentShortTextFont(paletteState);
			_comboHolder.BackColor = _comboBox.BackColor;
		}
		base.OnNeedPaint(sender, e);
	}

	protected override void OnPaletteChanged(EventArgs e)
	{
		base.OnPaletteChanged(e);
		_comboBox.Invalidate();
	}

	protected override void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		base.OnPaletteChanged(e);
		_comboBox.Invalidate();
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

	internal void DetachEditControl()
	{
		if (_subclassEdit != null)
		{
			_subclassEdit = null;
		}
	}

	private void AttachEditControl()
	{
		if (!base.IsDisposed && !base.Disposing && _subclassEdit == null)
		{
			IntPtr intPtr = PI.GetWindow(_comboBox.Handle, 5u);
			if (intPtr != IntPtr.Zero)
			{
				_subclassEdit = new SubclassEdit(intPtr, this);
				_subclassEdit.TrackMouseEnter += OnComboBoxMouseChange;
				_subclassEdit.TrackMouseLeave += OnComboBoxMouseChange;
			}
		}
	}

	private void UpdateEditControl()
	{
		AttachEditControl();
		if (_subclassEdit != null)
		{
			_subclassEdit.Visible = base.Enabled;
		}
	}

	private void UpdateStateAndPalettes()
	{
		IPaletteTriple comboBoxTripleState = GetComboBoxTripleState();
		_drawDockerOuter.SetPalettes(comboBoxTripleState.PaletteBack, comboBoxTripleState.PaletteBorder);
		_drawDockerOuter.Enabled = base.Enabled;
		PaletteState elementState = ((!IsActive) ? PaletteState.Normal : PaletteState.Tracking);
		_drawDockerOuter.ElementState = elementState;
	}

	internal IPaletteTriple GetComboBoxTripleState()
	{
		if (base.Enabled)
		{
			if (IsActive)
			{
				return _stateActive.ComboBox;
			}
			return _stateNormal.ComboBox;
		}
		return _stateDisabled.ComboBox;
	}

	private void OnComboBoxDrawItem(object sender, DrawItemEventArgs e)
	{
		Rectangle bounds = e.Bounds;
		if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
		{
			e.DrawBackground();
			Color foreColor = _comboBox.ForeColor;
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				foreColor = SystemColors.HighlightText;
			}
			Color backColor = _comboBox.BackColor;
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				backColor = SystemColors.Highlight;
			}
			if (e.Index >= 0)
			{
				e.Graphics.TextRenderingHint = CommonHelper.PaletteTextHintToRenderingHint(StateNormal.Item.PaletteContent.GetContentShortTextHint(PaletteState.Normal));
				TextFormatFlags textFormatFlags = TextFormatFlags.TextBoxControl | TextFormatFlags.NoPadding;
				textFormatFlags |= TextFormatFlags.NoPrefix;
				if (RightToLeft == RightToLeft.Yes)
				{
					textFormatFlags |= TextFormatFlags.Right;
				}
				TextRenderer.DrawText(e.Graphics, _comboBox.Text, _comboBox.Font, bounds, foreColor, backColor, textFormatFlags);
			}
		}
		else
		{
			if (e.Index < 0)
			{
				return;
			}
			UpdateContentFromItemIndex(e.Index);
			PaletteState elementState = PaletteState.Normal;
			if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled)
			{
				elementState = PaletteState.Disabled;
			}
			else if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				elementState = PaletteState.Tracking;
			}
			_drawButton.ElementState = elementState;
			IntPtr hdc = e.Graphics.GetHdc();
			try
			{
				IntPtr intPtr = PI.CreateCompatibleBitmap(hdc, bounds.Right, bounds.Bottom);
				if (!(intPtr != IntPtr.Zero))
				{
					return;
				}
				try
				{
					PI.SelectObject(_screenDC, intPtr);
					using Graphics graphics = Graphics.FromHdc(_screenDC);
					using (ViewLayoutContext viewLayoutContext = new ViewLayoutContext(this, base.Renderer))
					{
						viewLayoutContext.DisplayRectangle = bounds;
						_drawPanel.Layout(viewLayoutContext);
						_drawButton.Layout(viewLayoutContext);
					}
					using (RenderContext context = new RenderContext(this, graphics, bounds, base.Renderer))
					{
						_drawPanel.Render(context);
						_drawButton.Render(context);
					}
					PI.BitBlt(hdc, bounds.X, bounds.Y, bounds.Width, bounds.Height, _screenDC, bounds.X, bounds.Y, 13369376);
				}
				finally
				{
					PI.DeleteObject(intPtr);
				}
			}
			finally
			{
				e.Graphics.ReleaseHdc();
			}
		}
	}

	private void OnComboBoxMeasureItem(object sender, MeasureItemEventArgs e)
	{
		UpdateContentFromItemIndex(e.Index);
		using ViewLayoutContext context = new ViewLayoutContext(this, base.Renderer);
		Size preferredSize = _drawButton.GetPreferredSize(context);
		e.ItemWidth = preferredSize.Width;
		e.ItemHeight = preferredSize.Height;
	}

	private void UpdateContentFromItemIndex(int index)
	{
		if (Items[index] is IContentValues contentValues)
		{
			_contentValues.ShortText = contentValues.GetShortText();
			_contentValues.LongText = contentValues.GetLongText();
			_contentValues.Image = contentValues.GetImage(PaletteState.Normal);
			_contentValues.ImageTransparentColor = contentValues.GetImageTransparentColor(PaletteState.Normal);
		}
		else
		{
			_contentValues.ShortText = _comboBox.GetItemText(Items[index]);
			_contentValues.LongText = null;
			_contentValues.Image = null;
			_contentValues.ImageTransparentColor = Color.Empty;
		}
		if (string.IsNullOrEmpty(_contentValues.ShortText))
		{
			_contentValues.ShortText = " ";
		}
	}

	private void OnComboBoxMouseChange(object sender, EventArgs e)
	{
		bool flag = _comboBox.MouseOver || (_subclassEdit != null && _subclassEdit.MouseOver);
		if (flag != _trackingMouseEnter)
		{
			_trackingMouseEnter = flag;
			if (_trackingMouseEnter)
			{
				OnTrackMouseEnter(EventArgs.Empty);
			}
			else
			{
				OnTrackMouseLeave(EventArgs.Empty);
			}
		}
		PerformNeedPaint(needLayout: false);
		_comboBox.Invalidate();
	}

	private void OnComboBoxGotFocus(object sender, EventArgs e)
	{
		base.OnGotFocus(e);
		PerformNeedPaint(needLayout: false);
		_comboBox.Invalidate();
	}

	private void OnComboBoxLostFocus(object sender, EventArgs e)
	{
		OnLostFocus(e);
		PerformNeedPaint(needLayout: false);
		_comboBox.Invalidate();
	}

	private void OnComboBoxTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(e);
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
		_comboBox.Dropped = false;
		Refresh();
		OnDropDownClosed(e);
	}

	private void OnComboBoxDropDown(object sender, EventArgs e)
	{
		_comboBox.Dropped = true;
		Refresh();
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

	private void OnComboBoxValidated(object sender, EventArgs e)
	{
		OnValidated(e);
	}

	private void OnComboBoxValidating(object sender, CancelEventArgs e)
	{
		OnValidating(e);
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
		UpdateEditControl();
		PerformNeedPaint(needLayout: false);
		_comboBox.Invalidate();
		OnSelectedValueChanged(e);
	}

	private void OnComboBoxValueMemberChanged(object sender, EventArgs e)
	{
		OnValueMemberChanged(e);
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

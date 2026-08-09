using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonWrapLabel), "ToolboxBitmaps.KryptonWrapLabel.bmp")]
[DefaultProperty("Text")]
[DefaultBindingProperty("Text")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonWrapLabelDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Displays descriptive information.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonWrapLabel : Label
{
	private static MethodInfo _miPTB;

	private IPalette _localPalette;

	private IPalette _palette;

	private PaletteMode _paletteMode;

	private PaletteRedirect _redirector;

	private IRenderer _renderer;

	private LabelStyle _labelStyle;

	private PaletteContentStyle _labelContentStyle;

	private PaletteWrapLabel _stateCommon;

	private PaletteWrapLabel _stateNormal;

	private PaletteWrapLabel _stateDisabled;

	private KryptonContextMenu _kryptonContextMenu;

	private bool _globalEvents;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new int TabIndex
	{
		get
		{
			return base.TabIndex;
		}
		set
		{
			base.TabIndex = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool TabStop
	{
		get
		{
			return base.TabStop;
		}
		set
		{
			base.TabStop = value;
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
	[Bindable(false)]
	public override BorderStyle BorderStyle
	{
		get
		{
			return base.BorderStyle;
		}
		set
		{
			base.BorderStyle = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public new FlatStyle FlatStyle
	{
		get
		{
			return base.FlatStyle;
		}
		set
		{
			base.FlatStyle = value;
		}
	}

	[DefaultValue(true)]
	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			base.AutoSize = value;
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common wrap label appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteWrapLabel StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled wrap label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteWrapLabel StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal wrap label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteWrapLabel StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Label style.")]
	public LabelStyle LabelStyle
	{
		get
		{
			return _labelStyle;
		}
		set
		{
			if (_labelStyle != value)
			{
				_labelStyle = value;
				SetLabelStyle(_labelStyle);
				Refresh();
			}
		}
	}

	[Category("Visuals")]
	[Description("Palette applied to drawing.")]
	public PaletteMode PaletteMode
	{
		[DebuggerStepThrough]
		get
		{
			return _paletteMode;
		}
		set
		{
			if (_paletteMode != value)
			{
				if (value != PaletteMode.Custom)
				{
					_paletteMode = value;
					_localPalette = null;
					SetPalette(KryptonManager.GetPaletteForMode(_paletteMode));
					OnPaletteChanged(EventArgs.Empty);
					NeedPaint(layout: true);
				}
			}
		}
	}

	[Category("Visuals")]
	[Description("Custom palette applied to drawing.")]
	[DefaultValue(null)]
	public IPalette Palette
	{
		[DebuggerStepThrough]
		get
		{
			return _localPalette;
		}
		set
		{
			if (_localPalette != value)
			{
				IPalette localPalette = _localPalette;
				SetPalette(value);
				if (value == null)
				{
					_paletteMode = PaletteMode.Global;
					_localPalette = null;
					SetPalette(KryptonManager.GetPaletteForMode(_paletteMode));
				}
				else
				{
					_localPalette = value;
					_paletteMode = PaletteMode.Custom;
				}
				if (localPalette != _localPalette)
				{
					OnPaletteChanged(EventArgs.Empty);
					NeedPaint(layout: true);
				}
			}
		}
	}

	[Category("Behavior")]
	[Description("The shortcut menu to show when the user right-clicks the page.")]
	[DefaultValue(null)]
	public virtual KryptonContextMenu KryptonContextMenu
	{
		get
		{
			return _kryptonContextMenu;
		}
		set
		{
			if (_kryptonContextMenu != value)
			{
				if (_kryptonContextMenu != null)
				{
					_kryptonContextMenu.Closed -= OnContextMenuClosed;
					_kryptonContextMenu.Disposed -= OnKryptonContextMenuDisposed;
				}
				_kryptonContextMenu = value;
				if (_kryptonContextMenu != null)
				{
					_kryptonContextMenu.Closed += OnContextMenuClosed;
					_kryptonContextMenu.Disposed += OnKryptonContextMenuDisposed;
				}
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IRenderer Renderer
	{
		[DebuggerStepThrough]
		get
		{
			return _renderer;
		}
	}

	[Category("Property Changed")]
	[Description("Occurs when the value of the Palette property is changed.")]
	public event EventHandler PaletteChanged;

	public KryptonWrapLabel()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		DoubleBuffered = true;
		_stateCommon = new PaletteWrapLabel(this);
		_stateNormal = new PaletteWrapLabel(this);
		_stateDisabled = new PaletteWrapLabel(this);
		_localPalette = null;
		SetPalette(KryptonManager.CurrentGlobalPalette);
		_paletteMode = PaletteMode.Global;
		AttachGlobalEvents();
		_redirector = CreateRedirector();
		SetLabelStyle(LabelStyle.NormalControl);
		AutoSize = true;
		TabStop = false;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_palette != null)
			{
				_palette.PalettePaint -= OnPaletteNeedPaint;
				_palette.BasePaletteChanged -= OnBaseChanged;
				_palette.BaseRendererChanged -= OnBaseChanged;
			}
			UnattachGlobalEvents();
			_palette = null;
			_localPalette = null;
			_redirector.Target = null;
			_renderer = null;
		}
		base.Dispose(disposing);
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

	private bool ShouldSerializeLabelStyle()
	{
		return LabelStyle != LabelStyle.NormalControl;
	}

	private void ResetLabelStyle()
	{
		LabelStyle = LabelStyle.NormalControl;
	}

	private bool ShouldSerializePaletteMode()
	{
		return PaletteMode != PaletteMode.Global;
	}

	public void ResetPaletteMode()
	{
		PaletteMode = PaletteMode.Global;
	}

	public void ResetPalette()
	{
		PaletteMode = PaletteMode.Global;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IPalette GetResolvedPalette()
	{
		return _palette;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public ToolStripRenderer CreateToolStripRenderer()
	{
		return Renderer.RenderToolStrip(GetResolvedPalette());
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void UpdateFont()
	{
		Font font = null;
		Color empty = Color.Empty;
		PaletteTextHint paletteTextHint = PaletteTextHint.Inherit;
		PaletteState paletteState = PaletteState.Normal;
		if (base.Enabled)
		{
			font = _stateNormal.Font;
			empty = _stateNormal.TextColor;
			paletteTextHint = _stateNormal.Hint;
		}
		else
		{
			font = _stateDisabled.Font;
			empty = _stateDisabled.TextColor;
			paletteTextHint = _stateDisabled.Hint;
			paletteState = PaletteState.Disabled;
		}
		if (font == null)
		{
			font = _stateCommon.Font;
			if (font == null)
			{
				font = _redirector.GetContentShortTextFont(_labelContentStyle, paletteState);
			}
		}
		if (empty == Color.Empty)
		{
			empty = _stateCommon.TextColor;
			if (empty == Color.Empty)
			{
				empty = _redirector.GetContentShortTextColor1(_labelContentStyle, paletteState);
			}
		}
		if (paletteTextHint == PaletteTextHint.Inherit)
		{
			paletteTextHint = _stateCommon.Hint;
			if (paletteTextHint == PaletteTextHint.Inherit)
			{
				paletteTextHint = _redirector.GetContentShortTextHint(_labelContentStyle, paletteState);
			}
		}
		if (base.Handle != IntPtr.Zero)
		{
			Font = font;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void AttachGlobalEvents()
	{
		if (!_globalEvents)
		{
			UpdateGlobalEvents(attach: true);
			_globalEvents = true;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void UnattachGlobalEvents()
	{
		if (_globalEvents)
		{
			UpdateGlobalEvents(attach: false);
			_globalEvents = false;
		}
	}

	protected virtual void OnPaletteChanged(EventArgs e)
	{
		_redirector.Target = _palette;
		NeedPaint(layout: true);
		if (this.PaletteChanged != null)
		{
			this.PaletteChanged(this, e);
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Font font = null;
		Color empty = Color.Empty;
		PaletteTextHint paletteTextHint = PaletteTextHint.Inherit;
		PaletteState paletteState = PaletteState.Normal;
		if (base.Enabled)
		{
			font = _stateNormal.Font;
			empty = _stateNormal.TextColor;
			paletteTextHint = _stateNormal.Hint;
		}
		else
		{
			font = _stateDisabled.Font;
			empty = _stateDisabled.TextColor;
			paletteTextHint = _stateDisabled.Hint;
			paletteState = PaletteState.Disabled;
		}
		if (font == null)
		{
			font = _stateCommon.Font;
			if (font == null)
			{
				font = _redirector.GetContentShortTextFont(_labelContentStyle, paletteState);
			}
		}
		if (empty == Color.Empty)
		{
			empty = _stateCommon.TextColor;
			if (empty == Color.Empty)
			{
				empty = _redirector.GetContentShortTextColor1(_labelContentStyle, paletteState);
			}
		}
		if (paletteTextHint == PaletteTextHint.Inherit)
		{
			paletteTextHint = _stateCommon.Hint;
			if (paletteTextHint == PaletteTextHint.Inherit)
			{
				paletteTextHint = _redirector.GetContentShortTextHint(_labelContentStyle, paletteState);
			}
		}
		if (base.Handle != IntPtr.Zero)
		{
			Font = font;
		}
		ForeColor = empty;
		e.Graphics.TextRenderingHint = CommonHelper.PaletteTextHintToRenderingHint(paletteTextHint);
		base.OnPaint(e);
	}

	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
		if (base.Parent != null)
		{
			if (_miPTB == null)
			{
				_miPTB = typeof(Control).GetMethod("PaintTransparentBackground", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, CallingConventions.HasThis, new Type[3]
				{
					typeof(PaintEventArgs),
					typeof(Rectangle),
					typeof(Region)
				}, null);
			}
			_miPTB.Invoke(this, new object[3] { pevent, base.ClientRectangle, null });
		}
		else
		{
			base.OnPaintBackground(pevent);
		}
	}

	protected virtual PaletteRedirect CreateRedirector()
	{
		return new PaletteRedirect(_palette);
	}

	protected virtual void SetLabelStyle(LabelStyle style)
	{
		_labelContentStyle = CommonHelper.ContentStyleFromLabelStyle(style);
	}

	protected virtual void UpdateGlobalEvents(bool attach)
	{
		if (attach)
		{
			KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;
			SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
		}
		else
		{
			KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
			SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (KryptonContextMenu != null && KryptonContextMenu.ProcessShortcut(keyData))
		{
			return true;
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 123 && KryptonContextMenu != null)
		{
			Point p = new Point(PI.LOWORD(m.LParam), PI.HIWORD(m.LParam));
			if ((int)(long)m.LParam == -1)
			{
				p = new Point(base.Width / 2, base.Height / 2);
			}
			else
			{
				p = PointToClient(p);
				p.X--;
				p.Y--;
			}
			if (base.ClientRectangle.Contains(p))
			{
				KryptonContextMenu.Show(this, PointToScreen(p));
				return;
			}
		}
		base.WndProc(ref m);
	}

	protected virtual void ContextMenuClosed()
	{
	}

	private void SetPalette(IPalette palette)
	{
		if (palette != _palette)
		{
			if (_palette != null)
			{
				_palette.PalettePaint -= OnPaletteNeedPaint;
				_palette.BasePaletteChanged -= OnBaseChanged;
				_palette.BaseRendererChanged -= OnBaseChanged;
			}
			_palette = palette;
			_renderer = _palette.GetRenderer();
			if (_palette != null)
			{
				_palette.PalettePaint += OnPaletteNeedPaint;
				_palette.BasePaletteChanged += OnBaseChanged;
				_palette.BaseRendererChanged += OnBaseChanged;
			}
		}
	}

	private void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		NeedPaint(e);
	}

	private void OnBaseChanged(object sender, EventArgs e)
	{
		_renderer = _palette.GetRenderer();
	}

	private void OnGlobalPaletteChanged(object sender, EventArgs e)
	{
		if (PaletteMode == PaletteMode.Global)
		{
			_localPalette = null;
			SetPalette(KryptonManager.CurrentGlobalPalette);
			_redirector.Target = _palette;
			NeedPaint(layout: true);
			OnPaletteChanged(EventArgs.Empty);
		}
	}

	private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		NeedPaint(layout: true);
	}

	private void OnContextMenuStripOpening(object sender, CancelEventArgs e)
	{
		ContextMenuStrip contextMenuStrip = base.ContextMenuStrip;
		contextMenuStrip.Renderer = CreateToolStripRenderer();
	}

	private void OnKryptonContextMenuDisposed(object sender, EventArgs e)
	{
		KryptonContextMenu = null;
	}

	private void OnContextMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
	{
		ContextMenuClosed();
	}

	private void NeedPaint(bool layout)
	{
		NeedPaint(new NeedLayoutEventArgs(layout));
	}

	private void NeedPaint(NeedLayoutEventArgs e)
	{
		if (e.NeedLayout)
		{
			PerformLayout();
		}
		Invalidate();
	}
}

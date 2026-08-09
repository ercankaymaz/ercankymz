#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonHeader), "ToolboxBitmaps.KryptonHeader.bmp")]
[DefaultEvent("Paint")]
[DefaultProperty("Text")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonHeaderDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Display a descriptive caption.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonHeader : VisualSimpleBase
{
	public class HeaderButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public HeaderButtonSpecCollection(KryptonHeader owner)
			: base((object)owner)
		{
		}
	}

	private bool _allowButtonSpecToolTips;

	private HeaderStyle _style;

	private HeaderValues _headerValues;

	private VisualOrientation _orientation;

	private ViewDrawDocker _drawDocker;

	private ViewDrawContent _drawContent;

	private PaletteHeaderRedirect _stateCommon;

	private PaletteTripleMetric _stateDisabled;

	private PaletteTripleMetric _stateNormal;

	private HeaderButtonSpecCollection _buttonSpecs;

	private ButtonSpecManagerDraw _buttonManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ToolTipManager _toolTipManager;

	[Browsable(true)]
	[Localizable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[RefreshProperties(RefreshProperties.All)]
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

	[DefaultValue(typeof(AutoSizeMode), "GrowAndShrink")]
	public new AutoSizeMode AutoSizeMode
	{
		get
		{
			return base.AutoSizeMode;
		}
		set
		{
			base.AutoSizeMode = value;
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
			return _headerValues.Heading;
		}
		set
		{
			_headerValues.Heading = value;
		}
	}

	[Category("Visuals")]
	[Description("Visual orientation of the control.")]
	[DefaultValue(typeof(VisualOrientation), "Top")]
	public virtual VisualOrientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			if (_orientation != value)
			{
				_orientation = value;
				_drawDocker.Orientation = value;
				_drawContent.Orientation = value;
				_buttonManager.RecreateButtons();
				PerformNeedPaint(needLayout: true);
			}
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
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public HeaderButtonSpecCollection ButtonSpecs => _buttonSpecs;

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
	[Description("Header style.")]
	[DefaultValue(typeof(HeaderStyle), "Primary")]
	public HeaderStyle HeaderStyle
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
				_stateCommon.SetStyles(_style);
				switch (_style)
				{
				case HeaderStyle.Primary:
					_buttonManager.SetDockerMetrics(_drawDocker, _stateCommon, PaletteMetricInt.HeaderButtonEdgeInsetPrimary, PaletteMetricPadding.HeaderButtonPaddingPrimary);
					break;
				case HeaderStyle.Secondary:
					_buttonManager.SetDockerMetrics(_drawDocker, _stateCommon, PaletteMetricInt.HeaderButtonEdgeInsetSecondary, PaletteMetricPadding.HeaderButtonPaddingSecondary);
					break;
				case HeaderStyle.DockActive:
					_buttonManager.SetDockerMetrics(_drawDocker, _stateCommon, PaletteMetricInt.HeaderButtonEdgeInsetDockActive, PaletteMetricPadding.HeaderButtonPaddingDockActive);
					break;
				case HeaderStyle.DockInactive:
					_buttonManager.SetDockerMetrics(_drawDocker, _stateCommon, PaletteMetricInt.HeaderButtonEdgeInsetDockInactive, PaletteMetricPadding.HeaderButtonPaddingDockInactive);
					break;
				case HeaderStyle.Form:
					_buttonManager.SetDockerMetrics(_drawDocker, _stateCommon, PaletteMetricInt.HeaderButtonEdgeInsetForm, PaletteMetricPadding.HeaderButtonPaddingForm);
					break;
				case HeaderStyle.Calendar:
					_buttonManager.SetDockerMetrics(_drawDocker, _stateCommon, PaletteMetricInt.HeaderButtonEdgeInsetCalendar, PaletteMetricPadding.HeaderButtonPaddingCalendar);
					break;
				case HeaderStyle.Custom1:
					_buttonManager.SetDockerMetrics(_drawDocker, _stateCommon, PaletteMetricInt.HeaderButtonEdgeInsetCustom1, PaletteMetricPadding.HeaderButtonPaddingCustom1);
					break;
				case HeaderStyle.Custom2:
					_buttonManager.SetDockerMetrics(_drawDocker, _stateCommon, PaletteMetricInt.HeaderButtonEdgeInsetCustom2, PaletteMetricPadding.HeaderButtonPaddingCustom2);
					break;
				default:
					Debug.Assert(condition: false);
					break;
				}
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Header values")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public HeaderValues Values => _headerValues;

	[Category("Visuals")]
	[Description("Overrides for defining common header appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteHeaderRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleMetric StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleMetric StateNormal => _stateNormal;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolTipManager ToolTipManager => _toolTipManager;

	protected override Size DefaultSize => new Size(240, 30);

	public KryptonHeader()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		_style = HeaderStyle.Primary;
		_orientation = VisualOrientation.Top;
		_allowButtonSpecToolTips = false;
		_headerValues = new HeaderValues(base.NeedPaintDelegate);
		_headerValues.TextChanged += OnHeaderTextChanged;
		_buttonSpecs = new HeaderButtonSpecCollection(this);
		_stateCommon = new PaletteHeaderRedirect(base.Redirector, PaletteBackStyle.HeaderPrimary, PaletteBorderStyle.HeaderPrimary, PaletteContentStyle.HeaderPrimary, base.NeedPaintDelegate);
		_stateDisabled = new PaletteTripleMetric(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteTripleMetric(_stateCommon, base.NeedPaintDelegate);
		_drawDocker = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border, null);
		_drawContent = new ViewDrawContent(_stateNormal.Content, _headerValues, Orientation);
		_drawDocker.Add(_drawContent, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDocker);
		_buttonManager = new ButtonSpecManagerDraw(this, base.Redirector, _buttonSpecs, null, new ViewDrawDocker[1] { _drawDocker }, new IPaletteMetric[1] { _stateCommon }, new PaletteMetricInt[1] { PaletteMetricInt.HeaderButtonEdgeInsetPrimary }, new PaletteMetricPadding[1] { PaletteMetricPadding.HeaderButtonPaddingPrimary }, base.CreateToolStripRenderer, base.NeedPaintDelegate);
		_toolTipManager = new ToolTipManager();
		_toolTipManager.ShowToolTip += OnShowToolTip;
		_toolTipManager.CancelToolTip += OnCancelToolTip;
		_buttonManager.ToolTipManager = _toolTipManager;
		AutoSize = true;
		AutoSizeMode = AutoSizeMode.GrowAndShrink;
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
		return false;
	}

	public override void ResetText()
	{
		_headerValues.ResetHeading();
	}

	private void ResetHeaderStyle()
	{
		HeaderStyle = HeaderStyle.Primary;
	}

	private bool ShouldSerializeHeaderStyle()
	{
		return HeaderStyle != HeaderStyle.Primary;
	}

	private bool ShouldSerializeValues()
	{
		return !_headerValues.IsDefault;
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

	public virtual void SetFixedState(PaletteState state)
	{
		_drawDocker.FixedState = state;
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

	protected override bool ProcessMnemonic(char charCode)
	{
		if (UseMnemonic && CanProcessMnemonic() && _buttonManager.ProcessMnemonic(charCode))
		{
			return true;
		}
		return base.ProcessMnemonic(charCode);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		if (base.Enabled)
		{
			_drawDocker.SetPalettes(_stateNormal.Back, _stateNormal.Border);
			_drawContent.SetPalette(_stateNormal.Content);
		}
		else
		{
			_drawDocker.SetPalettes(_stateDisabled.Back, _stateDisabled.Border);
			_drawContent.SetPalette(_stateDisabled.Content);
		}
		_drawDocker.Enabled = base.Enabled;
		_drawContent.Enabled = base.Enabled;
		_buttonManager.RefreshButtons();
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnButtonSpecChanged(object sender, EventArgs e)
	{
		_buttonManager.RecreateButtons();
		base.OnButtonSpecChanged(sender, e);
	}

	private void OnHeaderTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(EventArgs.Empty);
	}

	private void OnShowToolTip(object sender, ToolTipEventArgs e)
	{
		if (base.IsDisposed)
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

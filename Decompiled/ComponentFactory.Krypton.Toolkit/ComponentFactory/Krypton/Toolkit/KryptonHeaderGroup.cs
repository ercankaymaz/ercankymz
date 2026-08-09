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
[ToolboxBitmap(typeof(KryptonHeaderGroup), "ToolboxBitmaps.KryptonHeaderGroup.bmp")]
[DefaultEvent("Paint")]
[DefaultProperty("ValuesPrimary")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonHeaderGroupDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Group a collection of controls with a descriptive caption.")]
[Docking(DockingBehavior.Ask)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonHeaderGroup : VisualControlContainment
{
	public class HeaderGroupButtonSpecCollection : ButtonSpecCollection<ButtonSpecHeaderGroup>
	{
		public HeaderGroupButtonSpecCollection(KryptonHeaderGroup owner)
			: base((object)owner)
		{
		}
	}

	private HeaderStyle _style1;

	private HeaderStyle _style2;

	private VisualOrientation _position1;

	private VisualOrientation _position2;

	private HeaderGroupValuesPrimary _headerValues1;

	private HeaderGroupValuesSecondary _headerValues2;

	private HeaderGroupCollapsedTarget _collapsedTarget;

	private ViewDrawDocker _drawDocker;

	private ViewDrawDocker _drawHeading1;

	private ViewDrawContent _drawContent1;

	private ViewDrawDocker _drawHeading2;

	private ViewDrawContent _drawContent2;

	private ViewLayoutFill _layoutFill;

	private KryptonGroupPanel _panel;

	private PaletteHeaderGroupRedirect _stateCommon;

	private PaletteHeaderGroup _stateDisabled;

	private PaletteHeaderGroup _stateNormal;

	private HeaderGroupButtonSpecCollection _buttonSpecs;

	private ButtonSpecManagerDraw _buttonManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ToolTipManager _toolTipManager;

	private ScreenObscurer _obscurer;

	private EventHandler _removeObscurer;

	private bool _forcedLayout;

	private bool _visiblePrimary;

	private bool _visibleSecondary;

	private bool _autoCollapseArrow;

	private bool _collapsed;

	private bool _ignoreLayout;

	private bool _allowButtonSpecToolTips;

	private bool _layingOut;

	[Browsable(false)]
	public new string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
			_panel.Name = value + ".Panel";
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

	[Category("Layout")]
	[Description("Specifies if the control grows and shrinks to fit the contents exactly.")]
	[DefaultValue(typeof(AutoSizeMode), "GrowAndShrink")]
	public AutoSizeMode AutoSizeMode
	{
		get
		{
			return GetAutoSizeMode();
		}
		set
		{
			if (value != GetAutoSizeMode())
			{
				SetAutoSizeMode(value);
				if (AutoSize)
				{
					PerformNeedPaint(needLayout: true);
				}
			}
		}
	}

	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public override string Text
	{
		get
		{
			return _headerValues1.Heading;
		}
		set
		{
			_headerValues1.Heading = value;
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

	[Localizable(false)]
	[Category("Appearance")]
	[Description("The internal panel that contains group content.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonGroupPanel Panel => _panel;

	[Category("Visuals")]
	[Description("Clicking an arrow button spec should toggle collapse state.")]
	[DefaultValue(true)]
	public bool AutoCollapseArrow
	{
		get
		{
			return _autoCollapseArrow;
		}
		set
		{
			_autoCollapseArrow = value;
		}
	}

	[Category("Visuals")]
	[Description("Specifies if the appearance is collapsed.")]
	[DefaultValue(false)]
	public bool Collapsed
	{
		get
		{
			return _collapsed;
		}
		set
		{
			if (_collapsed != value)
			{
				SuspendLayout();
				try
				{
					_collapsed = value;
					_layoutFill.Visible = !value;
					_panel.Visible = !value;
					ReapplyVisible();
					OnCollapsedChanged(EventArgs.Empty);
					PerformNeedPaint(needLayout: false);
				}
				finally
				{
					ResumeLayout(performLayout: true);
				}
			}
		}
	}

	[Category("Visuals")]
	[Description("Specifies how to collapsed the appearance when entering collapse mode.")]
	public HeaderGroupCollapsedTarget CollapseTarget
	{
		get
		{
			return _collapsedTarget;
		}
		set
		{
			if (_collapsedTarget != value)
			{
				_collapsedTarget = value;
				ReapplyVisible();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Collection of button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public HeaderGroupButtonSpecCollection ButtonSpecs => _buttonSpecs;

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
	[Description("Border style.")]
	public PaletteBorderStyle GroupBorderStyle
	{
		get
		{
			return _stateCommon.BorderStyle;
		}
		set
		{
			if (_stateCommon.BorderStyle != value)
			{
				_stateCommon.BorderStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Background style.")]
	public PaletteBackStyle GroupBackStyle
	{
		get
		{
			return _stateCommon.BackStyle;
		}
		set
		{
			if (_stateCommon.BackStyle != value)
			{
				_stateCommon.BackStyle = value;
				_panel.PanelBackStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Primary header style.")]
	public HeaderStyle HeaderStylePrimary
	{
		get
		{
			return _style1;
		}
		set
		{
			if (_style1 != value)
			{
				_style1 = value;
				SetHeaderStyle(_drawHeading1, _stateCommon.HeaderPrimary, _style1);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Secondary header style.")]
	public HeaderStyle HeaderStyleSecondary
	{
		get
		{
			return _style2;
		}
		set
		{
			if (_style2 != value)
			{
				_style2 = value;
				SetHeaderStyle(_drawHeading2, _stateCommon.HeaderSecondary, _style2);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Edge position of the primary header.")]
	[DefaultValue(typeof(VisualOrientation), "Top")]
	public VisualOrientation HeaderPositionPrimary
	{
		get
		{
			return _position1;
		}
		set
		{
			if (_position1 != value)
			{
				_position1 = value;
				SetHeaderPosition(_drawHeading1, _drawContent1, _position1);
				_buttonManager.RecreateButtons();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Edge position of the secondary header.")]
	[DefaultValue(typeof(VisualOrientation), "Bottom")]
	public VisualOrientation HeaderPositionSecondary
	{
		get
		{
			return _position2;
		}
		set
		{
			if (_position2 != value)
			{
				_position2 = value;
				SetHeaderPosition(_drawHeading2, _drawContent2, _position2);
				_buttonManager.RecreateButtons();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Primary header visibility.")]
	[DefaultValue(true)]
	public bool HeaderVisiblePrimary
	{
		get
		{
			return _visiblePrimary;
		}
		set
		{
			if (_visiblePrimary != value)
			{
				_visiblePrimary = value;
				ReapplyVisible();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Secondary header visibility.")]
	[DefaultValue(true)]
	public bool HeaderVisibleSecondary
	{
		get
		{
			return _visibleSecondary;
		}
		set
		{
			if (_visibleSecondary != value)
			{
				_visibleSecondary = value;
				ReapplyVisible();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common header group appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteHeaderGroupRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled header group appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteHeaderGroup StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal header group appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteHeaderGroup StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Primary header values")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public HeaderGroupValuesPrimary ValuesPrimary => _headerValues1;

	[Category("Visuals")]
	[Description("Secondary header values")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public HeaderGroupValuesSecondary ValuesSecondary => _headerValues2;

	public override Rectangle DisplayRectangle
	{
		get
		{
			ForceViewLayout();
			return new Rectangle(Panel.Location, Panel.Size);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolTipManager ToolTipManager => _toolTipManager;

	[Category("Property Changed")]
	[Description("Occurs when the value of the Collapsed property is changed.")]
	public event EventHandler CollapsedChanged;

	public KryptonHeaderGroup()
	{
		_style1 = HeaderStyle.Primary;
		_style2 = HeaderStyle.Secondary;
		_position1 = VisualOrientation.Top;
		_position2 = VisualOrientation.Bottom;
		_collapsedTarget = HeaderGroupCollapsedTarget.CollapsedToPrimary;
		_collapsed = false;
		_autoCollapseArrow = true;
		_allowButtonSpecToolTips = false;
		_visiblePrimary = true;
		_visibleSecondary = true;
		_headerValues1 = new HeaderGroupValuesPrimary(base.NeedPaintDelegate);
		_headerValues1.TextChanged += OnHeaderGroupTextChanged;
		_headerValues2 = new HeaderGroupValuesSecondary(base.NeedPaintDelegate);
		_buttonSpecs = new HeaderGroupButtonSpecCollection(this);
		_buttonSpecs.Inserted += OnButtonSpecInserted;
		_buttonSpecs.Removed += OnButtonSpecRemoved;
		_stateCommon = new PaletteHeaderGroupRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateDisabled = new PaletteHeaderGroup(_stateCommon, _stateCommon.HeaderPrimary, _stateCommon.HeaderSecondary, base.NeedPaintDelegate);
		_stateNormal = new PaletteHeaderGroup(_stateCommon, _stateCommon.HeaderPrimary, _stateCommon.HeaderSecondary, base.NeedPaintDelegate);
		_panel = new KryptonGroupPanel(this, _stateCommon, _stateDisabled, _stateNormal, OnGroupPanelPaint);
		_panel.PanelBackStyle = PaletteBackStyle.ControlClient;
		_drawHeading1 = new ViewDrawDocker(_stateNormal.HeaderPrimary.Back, _stateNormal.HeaderPrimary.Border, _stateNormal.HeaderPrimary, PaletteMetricBool.None, PaletteMetricPadding.HeaderGroupPaddingPrimary, VisualOrientation.Top);
		_drawContent1 = new ViewDrawContent(_stateNormal.HeaderPrimary.Content, _headerValues1, VisualOrientation.Top);
		_drawHeading1.Add(_drawContent1, ViewDockStyle.Fill);
		_drawHeading2 = new ViewDrawDocker(_stateNormal.HeaderSecondary.Back, _stateNormal.HeaderSecondary.Border, _stateNormal.HeaderSecondary, PaletteMetricBool.None, PaletteMetricPadding.HeaderGroupPaddingSecondary, VisualOrientation.Top);
		_drawContent2 = new ViewDrawContent(_stateNormal.HeaderSecondary.Content, _headerValues2, VisualOrientation.Top);
		_drawHeading2.Add(_drawContent2, ViewDockStyle.Fill);
		_drawDocker = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border, _stateNormal, PaletteMetricBool.HeaderGroupOverlay);
		_drawDocker.IgnoreBorderSpace = true;
		_drawDocker.RemoveChildBorders = true;
		_layoutFill = new ViewLayoutFill(_panel);
		_drawDocker.Add(_drawHeading2, ViewDockStyle.Bottom);
		_drawDocker.Add(_drawHeading1, ViewDockStyle.Top);
		_drawDocker.Add(_layoutFill, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDocker);
		_buttonManager = new ButtonSpecManagerDraw(this, base.Redirector, _buttonSpecs, null, new ViewDrawDocker[2] { _drawHeading1, _drawHeading2 }, new IPaletteMetric[2] { _stateCommon.HeaderPrimary, _stateCommon.HeaderSecondary }, new PaletteMetricInt[2]
		{
			PaletteMetricInt.HeaderButtonEdgeInsetPrimary,
			PaletteMetricInt.HeaderButtonEdgeInsetSecondary
		}, new PaletteMetricPadding[2]
		{
			PaletteMetricPadding.HeaderButtonPaddingPrimary,
			PaletteMetricPadding.HeaderButtonPaddingSecondary
		}, base.CreateToolStripRenderer, base.NeedPaintDelegate);
		_toolTipManager = new ToolTipManager();
		_toolTipManager.ShowToolTip += OnShowToolTip;
		_toolTipManager.CancelToolTip += OnCancelToolTip;
		_buttonManager.ToolTipManager = _toolTipManager;
		AutoSizeMode = AutoSizeMode.GrowAndShrink;
		_removeObscurer = OnRemoveObscurer;
		_ignoreLayout = true;
		((KryptonReadOnlyControls)base.Controls).AddInternal(_panel);
		_ignoreLayout = false;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_obscurer != null)
			{
				try
				{
					_obscurer.Uncover();
					_obscurer.Dispose();
					_obscurer = null;
				}
				catch
				{
				}
			}
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
		_headerValues1.ResetHeading();
	}

	private void ResetCollapseTarget()
	{
		CollapseTarget = HeaderGroupCollapsedTarget.CollapsedToPrimary;
	}

	private bool ShouldSerializeCollapseTarget()
	{
		return CollapseTarget != HeaderGroupCollapsedTarget.CollapsedToPrimary;
	}

	private void ResetGroupBorderStyle()
	{
		GroupBorderStyle = PaletteBorderStyle.ControlClient;
	}

	private bool ShouldSerializeGroupBorderStyle()
	{
		return GroupBorderStyle != PaletteBorderStyle.ControlClient;
	}

	private void ResetGroupBackStyle()
	{
		GroupBackStyle = PaletteBackStyle.ControlClient;
	}

	private bool ShouldSerializeGroupBackStyle()
	{
		return GroupBackStyle != PaletteBackStyle.ControlClient;
	}

	private void ResetHeaderStylePrimary()
	{
		HeaderStylePrimary = HeaderStyle.Primary;
	}

	private bool ShouldSerializeHeaderStylePrimary()
	{
		return HeaderStylePrimary != HeaderStyle.Primary;
	}

	private void ResetHeaderStyleSecondary()
	{
		HeaderStyleSecondary = HeaderStyle.Secondary;
	}

	private bool ShouldSerializeHeaderStyleSecondary()
	{
		return HeaderStyleSecondary != HeaderStyle.Secondary;
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

	private bool ShouldSerializeValuesPrimary()
	{
		return !_headerValues1.IsDefault;
	}

	private bool ShouldSerializeValuesSecondary()
	{
		return !_headerValues2.IsDefault;
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

	public virtual void SetFixedState(PaletteState state)
	{
		_drawDocker.FixedState = state;
		_panel.SetFixedState(state);
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
		if (!base.IsInitialized)
		{
			_forcedLayout = true;
			OnLayout(new LayoutEventArgs(null, null));
			_forcedLayout = false;
		}
	}

	protected virtual void OnCollapsedChanged(EventArgs e)
	{
		if (this.CollapsedChanged != null)
		{
			this.CollapsedChanged(this, e);
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
		InvokeLayout();
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		OnLayout(new LayoutEventArgs(null, null));
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		_layingOut = true;
		if (!_ignoreLayout)
		{
			base.OnLayout(levent);
			if (base.IsInitialized || _forcedLayout || (base.DesignMode && _panel != null))
			{
				Rectangle fillRect = _layoutFill.FillRect;
				_panel.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
			}
		}
		_layingOut = false;
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
			_drawHeading1.SetPalettes(_stateNormal.HeaderPrimary.Back, _stateNormal.HeaderPrimary.Border, _stateNormal.HeaderPrimary);
			_drawContent1.SetPalette(_stateNormal.HeaderPrimary.Content);
			_drawHeading2.SetPalettes(_stateNormal.HeaderSecondary.Back, _stateNormal.HeaderSecondary.Border, _stateNormal.HeaderSecondary);
			_drawContent2.SetPalette(_stateNormal.HeaderSecondary.Content);
			_drawDocker.SetPalettes(_stateNormal.Back, _stateNormal.Border, _stateNormal);
		}
		else
		{
			_drawHeading1.SetPalettes(_stateDisabled.HeaderPrimary.Back, _stateDisabled.HeaderPrimary.Border, _stateDisabled.HeaderPrimary);
			_drawContent1.SetPalette(_stateDisabled.HeaderPrimary.Content);
			_drawHeading2.SetPalettes(_stateDisabled.HeaderSecondary.Back, _stateDisabled.HeaderSecondary.Border, _stateDisabled.HeaderSecondary);
			_drawContent2.SetPalette(_stateDisabled.HeaderSecondary.Content);
			_drawDocker.SetPalettes(_stateDisabled.Back, _stateNormal.Border, _stateNormal);
		}
		_drawHeading1.Enabled = base.Enabled;
		_drawContent1.Enabled = base.Enabled;
		_drawHeading2.Enabled = base.Enabled;
		_drawContent2.Enabled = base.Enabled;
		_drawDocker.Enabled = base.Enabled;
		_buttonManager.RefreshButtons();
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		ForceControlLayout();
	}

	protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (base.IsInitialized || !e.NeedLayout)
		{
			_panel.PerformNeedPaint(e.NeedLayout);
		}
		else
		{
			ForceControlLayout();
		}
		base.OnNeedPaint(sender, e);
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 70)
		{
			if (_obscurer == null)
			{
				_obscurer = new ScreenObscurer();
			}
			if (!base.IsDisposed && base.IsHandleCreated && !base.DesignMode)
			{
				_obscurer.Cover(this);
			}
			BeginInvoke(_removeObscurer);
		}
		if (m.Msg == 71 && _obscurer != null)
		{
			_obscurer.Uncover();
		}
		base.WndProc(ref m);
	}

	protected override void OnButtonSpecChanged(object sender, EventArgs e)
	{
		_buttonManager.RecreateButtons();
		base.OnButtonSpecChanged(sender, e);
	}

	private void OnRemoveObscurer(object sender, EventArgs e)
	{
		if (_obscurer != null)
		{
			_obscurer.Uncover();
		}
	}

	private void OnHeaderGroupTextChanged(object sender, EventArgs e)
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

	private void OnButtonSpecInserted(object sender, ButtonSpecEventArgs e)
	{
		e.ButtonSpec.Click += OnButtonSpecClicked;
	}

	private void OnButtonSpecRemoved(object sender, ButtonSpecEventArgs e)
	{
		e.ButtonSpec.Click -= OnButtonSpecClicked;
	}

	private void OnButtonSpecClicked(object sender, EventArgs e)
	{
		if (AutoCollapseArrow)
		{
			ButtonSpecHeaderGroup buttonSpecHeaderGroup = (ButtonSpecHeaderGroup)sender;
			switch (buttonSpecHeaderGroup.Type)
			{
			case PaletteButtonSpecStyle.ArrowLeft:
				buttonSpecHeaderGroup.Type = PaletteButtonSpecStyle.ArrowRight;
				Collapsed = !Collapsed;
				break;
			case PaletteButtonSpecStyle.ArrowRight:
				buttonSpecHeaderGroup.Type = PaletteButtonSpecStyle.ArrowLeft;
				Collapsed = !Collapsed;
				break;
			case PaletteButtonSpecStyle.ArrowUp:
				buttonSpecHeaderGroup.Type = PaletteButtonSpecStyle.ArrowDown;
				Collapsed = !Collapsed;
				break;
			case PaletteButtonSpecStyle.ArrowDown:
				buttonSpecHeaderGroup.Type = PaletteButtonSpecStyle.ArrowUp;
				Collapsed = !Collapsed;
				break;
			}
		}
	}

	private void OnGroupPanelPaint(object sender, NeedLayoutEventArgs e)
	{
		if (e.NeedLayout && !_layingOut && AutoSize)
		{
			PerformNeedPaint(needLayout: true);
		}
	}

	private void SetHeaderPosition(ViewDrawCanvas canvas, ViewDrawContent content, VisualOrientation position)
	{
		switch (position)
		{
		case VisualOrientation.Top:
			_drawDocker.SetDock(canvas, ViewDockStyle.Top);
			canvas.Orientation = VisualOrientation.Top;
			content.Orientation = VisualOrientation.Top;
			break;
		case VisualOrientation.Bottom:
			_drawDocker.SetDock(canvas, ViewDockStyle.Bottom);
			canvas.Orientation = VisualOrientation.Top;
			content.Orientation = VisualOrientation.Top;
			break;
		case VisualOrientation.Left:
			_drawDocker.SetDock(canvas, ViewDockStyle.Left);
			canvas.Orientation = VisualOrientation.Left;
			content.Orientation = VisualOrientation.Left;
			break;
		case VisualOrientation.Right:
			_drawDocker.SetDock(canvas, ViewDockStyle.Right);
			canvas.Orientation = VisualOrientation.Right;
			content.Orientation = VisualOrientation.Right;
			break;
		}
	}

	private void SetHeaderStyle(ViewDrawDocker drawDocker, PaletteTripleMetricRedirect palette, HeaderStyle style)
	{
		palette.SetStyles(style);
		switch (style)
		{
		case HeaderStyle.Primary:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetPrimary, PaletteMetricPadding.HeaderButtonPaddingPrimary);
			break;
		case HeaderStyle.Secondary:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetSecondary, PaletteMetricPadding.HeaderButtonPaddingSecondary);
			break;
		case HeaderStyle.DockActive:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetDockActive, PaletteMetricPadding.HeaderButtonPaddingDockActive);
			break;
		case HeaderStyle.DockInactive:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetDockInactive, PaletteMetricPadding.HeaderButtonPaddingDockInactive);
			break;
		case HeaderStyle.Form:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetForm, PaletteMetricPadding.HeaderButtonPaddingForm);
			break;
		case HeaderStyle.Calendar:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetCalendar, PaletteMetricPadding.HeaderButtonPaddingCalendar);
			break;
		case HeaderStyle.Custom1:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetCustom1, PaletteMetricPadding.HeaderButtonPaddingCustom1);
			break;
		case HeaderStyle.Custom2:
			_buttonManager.SetDockerMetrics(drawDocker, palette, PaletteMetricInt.HeaderButtonEdgeInsetCustom2, PaletteMetricPadding.HeaderButtonPaddingCustom2);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	private void ReapplyVisible()
	{
		bool visible = _visiblePrimary;
		bool visible2 = _visibleSecondary;
		if (Collapsed)
		{
			switch (CollapseTarget)
			{
			case HeaderGroupCollapsedTarget.CollapsedToPrimary:
				visible = true;
				visible2 = false;
				break;
			case HeaderGroupCollapsedTarget.CollapsedToSecondary:
				visible = false;
				visible2 = true;
				break;
			case HeaderGroupCollapsedTarget.CollapsedToBoth:
				visible = true;
				visible2 = true;
				break;
			default:
				Debug.Assert(condition: false);
				break;
			}
		}
		_drawHeading1.Visible = visible;
		_drawHeading2.Visible = visible2;
	}

	private static int PaddingEdgeNeeded(int padding, int client)
	{
		if (padding < client)
		{
			return 0;
		}
		return padding - client;
	}
}

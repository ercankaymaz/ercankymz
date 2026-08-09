using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonBreadCrumb), "ToolboxBitmaps.KryptonBreadCrumb.bmp")]
[DefaultEvent("SelectedItemChanged")]
[DefaultProperty("RootItem")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Flat navigation of hierarchical data.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonBreadCrumb : VisualSimpleBase, ISupportInitializeNotification, ISupportInitialize
{
	public class BreadCrumbButtonSpecCollection : ButtonSpecCollection<ButtonSpecAny>
	{
		public BreadCrumbButtonSpecCollection(KryptonBreadCrumb owner)
			: base((object)owner)
		{
		}
	}

	private bool _initializing;

	private bool _initialized;

	private bool _allowButtonSpecToolTips;

	private bool _dropDownNavigaton;

	private ViewDrawDocker _drawDocker;

	private PaletteBreadCrumbRedirect _stateCommon;

	private PaletteBreadCrumbDoubleState _stateDisabled;

	private PaletteBreadCrumbDoubleState _stateNormal;

	private PaletteBreadCrumbState _stateTracking;

	private PaletteBreadCrumbState _statePressed;

	private BreadCrumbButtonSpecCollection _buttonSpecs;

	private ButtonSpecManagerDraw _buttonManager;

	private VisualPopupToolTip _visualPopupToolTip;

	private ToolTipManager _toolTipManager;

	private KryptonBreadCrumbItem _rootItem;

	private KryptonBreadCrumbItem _selectedItem;

	private ViewLayoutCrumbs _layoutCrumbs;

	private ButtonStyle _buttonStyle;

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

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[Browsable(true)]
	[Localizable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[RefreshProperties(RefreshProperties.All)]
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
	public BreadCrumbButtonSpecCollection ButtonSpecs => _buttonSpecs;

	[Category("Visuals")]
	[Description("Should drop down buttons allow navigation to children.")]
	[DefaultValue(true)]
	public bool DropDownNavigation
	{
		get
		{
			return _dropDownNavigaton;
		}
		set
		{
			if (_dropDownNavigaton != value)
			{
				_dropDownNavigaton = value;
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
	[Description("Background style for the control.")]
	public PaletteBackStyle ControlBackStyle
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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Button style used for drawing each bread crumb.")]
	public ButtonStyle CrumbButtonStyle
	{
		get
		{
			return _buttonStyle;
		}
		set
		{
			if (_buttonStyle != value)
			{
				_buttonStyle = value;
				_stateCommon.BreadCrumb.SetStyles(value);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Border style for the control.")]
	[DefaultValue(typeof(PaletteBorderStyle), "Control - Client")]
	public PaletteBorderStyle ControlBorderStyle
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

	[Category("Data")]
	[Description("Root bread crumb item.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonBreadCrumbItem RootItem => _rootItem;

	[Category("Data")]
	[Description("Currently selected bread crumb item.")]
	[DefaultValue(null)]
	public KryptonBreadCrumbItem SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			if (value != _selectedItem)
			{
				KryptonBreadCrumbItem kryptonBreadCrumbItem = value;
				while (kryptonBreadCrumbItem != null && kryptonBreadCrumbItem != RootItem)
				{
					kryptonBreadCrumbItem = kryptonBreadCrumbItem.Parent;
				}
				if (value != null && kryptonBreadCrumbItem == null)
				{
					throw new ArgumentOutOfRangeException("value", "Item must be inside the RootItem hierarchy.");
				}
				_selectedItem = value;
				OnSelectedItemChanged(EventArgs.Empty);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common bread crumb appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBreadCrumbRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBreadCrumbDoubleState StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBreadCrumbDoubleState StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining tracking bread crumb appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBreadCrumbState StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed bread crumb appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBreadCrumbState StatePressed => _statePressed;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolTipManager ToolTipManager => _toolTipManager;

	protected override Size DefaultSize => new Size(200, 28);

	[Category("Behavior")]
	[Description("Occurs when the control has been fully initialized.")]
	public event EventHandler Initialized;

	[Category("Action")]
	[Description("Occurs when the drop down portion of a bread crumb is pressed.")]
	public event EventHandler<BreadCrumbMenuArgs> CrumbDropDown;

	[Category("Action")]
	[Description("Occurs when the drop down portion of the overflow button is pressed.")]
	public event EventHandler<ContextPositionMenuArgs> OverflowDropDown;

	[Category("Property Changed")]
	[Description("Occurs when the value of the SelectedItem property changes.")]
	public event EventHandler SelectedItemChanged;

	public KryptonBreadCrumb()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		_selectedItem = null;
		_dropDownNavigaton = true;
		_buttonStyle = ButtonStyle.BreadCrumb;
		_rootItem = new KryptonBreadCrumbItem("Root");
		_rootItem.PropertyChanged += OnCrumbItemChanged;
		_allowButtonSpecToolTips = false;
		_buttonSpecs = new BreadCrumbButtonSpecCollection(this);
		_stateCommon = new PaletteBreadCrumbRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateDisabled = new PaletteBreadCrumbDoubleState(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteBreadCrumbDoubleState(_stateCommon, base.NeedPaintDelegate);
		_stateTracking = new PaletteBreadCrumbState(_stateCommon, base.NeedPaintDelegate);
		_statePressed = new PaletteBreadCrumbState(_stateCommon, base.NeedPaintDelegate);
		_layoutCrumbs = new ViewLayoutCrumbs(this, base.NeedPaintDelegate);
		_drawDocker = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border, null);
		_drawDocker.Add(_layoutCrumbs, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDocker);
		_buttonManager = new ButtonSpecManagerDraw(this, base.Redirector, _buttonSpecs, null, new ViewDrawDocker[1] { _drawDocker }, new IPaletteMetric[1] { _stateCommon }, new PaletteMetricInt[1] { PaletteMetricInt.HeaderButtonEdgeInsetPrimary }, new PaletteMetricPadding[1], base.CreateToolStripRenderer, base.NeedPaintDelegate);
		_toolTipManager = new ToolTipManager();
		_toolTipManager.ShowToolTip += OnShowToolTip;
		_toolTipManager.CancelToolTip += OnCancelToolTip;
		_buttonManager.ToolTipManager = _toolTipManager;
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

	public virtual void BeginInit()
	{
		_initializing = true;
	}

	public virtual void EndInit()
	{
		_initialized = true;
		_initializing = false;
		if (SelectedItem == null)
		{
			SelectedItem = RootItem;
		}
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout: true));
		OnInitialized(EventArgs.Empty);
	}

	private bool ShouldSerializeControlBackStyle()
	{
		return ControlBackStyle != PaletteBackStyle.PanelAlternate;
	}

	private void ResetControlBackStyle()
	{
		ControlBackStyle = PaletteBackStyle.PanelAlternate;
	}

	private bool ShouldSerializeCrumbButtonStyle()
	{
		return CrumbButtonStyle != ButtonStyle.BreadCrumb;
	}

	private void ResetCrumbButtonStyle()
	{
		CrumbButtonStyle = ButtonStyle.BreadCrumb;
	}

	private bool ShouldSerializeControlBorderStyle()
	{
		return ControlBorderStyle != PaletteBorderStyle.ControlClient;
	}

	private void ResetControlBorderStyle()
	{
		ControlBorderStyle = PaletteBorderStyle.ControlClient;
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

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
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

	protected override PaletteRedirect CreateRedirector()
	{
		return new PaletteRedirectBreadCrumb(base.CreateRedirector());
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
		}
		else
		{
			_drawDocker.SetPalettes(_stateDisabled.Back, _stateDisabled.Border);
		}
		_drawDocker.Enabled = base.Enabled;
		_buttonManager.RefreshButtons();
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnButtonSpecChanged(object sender, EventArgs e)
	{
		_buttonManager.RecreateButtons();
		base.OnButtonSpecChanged(sender, e);
	}

	protected internal virtual void OnCrumbDropDown(BreadCrumbMenuArgs e)
	{
		if (this.CrumbDropDown != null)
		{
			this.CrumbDropDown(this, e);
		}
	}

	protected internal virtual void OnOverflowDropDown(ContextPositionMenuArgs e)
	{
		if (this.OverflowDropDown != null)
		{
			this.OverflowDropDown(this, e);
		}
	}

	protected virtual void OnSelectedItemChanged(EventArgs e)
	{
		if (this.SelectedItemChanged != null)
		{
			this.SelectedItemChanged(this, e);
		}
	}

	protected virtual void OnInitialized(EventArgs e)
	{
		if (this.Initialized != null)
		{
			this.Initialized(this, EventArgs.Empty);
		}
	}

	internal PaletteBreadCrumbRedirect GetStateCommon()
	{
		return _stateCommon;
	}

	internal PaletteRedirect GetRedirector()
	{
		return base.Redirector;
	}

	private void OnCrumbItemChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Items" && SelectedItem != null)
		{
			KryptonBreadCrumbItem selectedItem = SelectedItem;
			while (selectedItem != null && selectedItem != RootItem)
			{
				selectedItem = selectedItem.Parent;
			}
			if (selectedItem == null)
			{
				SelectedItem = null;
			}
		}
		PerformNeedPaint(needLayout: true);
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

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonCheckBox), "ToolboxBitmaps.KryptonCheckBox.bmp")]
[DefaultEvent("CheckedChanged")]
[DefaultProperty("Text")]
[DefaultBindingProperty("CheckState")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonCheckBoxDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Allow user to set or clear the associated option.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonCheckBox : VisualSimpleBase, IContentValues
{
	private LabelStyle _style;

	private LabelValues _labelValues;

	private VisualOrientation _orientation;

	private CheckBoxController _controller;

	private ViewLayoutDocker _layoutDocker;

	private ViewLayoutCenter _layoutCenter;

	private ViewDrawCheckBox _drawCheckBox;

	private ViewDrawContent _drawContent;

	private PaletteContentInheritRedirect _paletteCommonRedirect;

	private PaletteRedirectCheckBox _paletteCheckBoxImages;

	private PaletteContent _stateCommon;

	private PaletteContent _stateDisabled;

	private PaletteContent _stateNormal;

	private PaletteContent _stateFocus;

	private PaletteContentInheritOverride _overrideNormal;

	private KryptonCommand _command;

	private CheckBoxImages _images;

	private VisualOrientation _checkPosition;

	private CheckState _checkState;

	private CheckState _wasCheckState;

	private bool _wasEnabled;

	private bool _checked;

	private bool _threeState;

	private bool _autoCheck;

	private bool _useMnemonic;

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

	[Browsable(false)]
	[Localizable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
			return _labelValues.Text;
		}
		set
		{
			_labelValues.Text = value;
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
				_drawContent.Orientation = value;
				UpdateForOrientation();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Visual position of the check box.")]
	[DefaultValue(typeof(VisualOrientation), "Left")]
	[Localizable(true)]
	public virtual VisualOrientation CheckPosition
	{
		get
		{
			return _checkPosition;
		}
		set
		{
			if (_checkPosition != value)
			{
				_checkPosition = value;
				UpdateForOrientation();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Label style.")]
	public LabelStyle LabelStyle
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
				SetLabelStyle(_style);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Label values")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public LabelValues Values => _labelValues;

	[Category("Visuals")]
	[Description("Image value overrides.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public CheckBoxImages Images => _images;

	[Category("Visuals")]
	[Description("Overrides for defining common label appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining label appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideFocus => _stateFocus;

	[Category("Appearance")]
	[Description("When true the first character after an ampersand will be used as a mnemonic.")]
	[DefaultValue(true)]
	public bool UseMnemonic
	{
		get
		{
			return _useMnemonic;
		}
		set
		{
			if (_useMnemonic != value)
			{
				_useMnemonic = value;
				_drawContent.UseMnemonic = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Appearance")]
	[Description("Indicates if the component is in the checked state.")]
	[DefaultValue(false)]
	[Bindable(true)]
	public bool Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			if (_checked != value)
			{
				_checked = value;
				_checkState = (_checked ? CheckState.Checked : CheckState.Unchecked);
				OnCheckedChanged(EventArgs.Empty);
				OnCheckStateChanged(EventArgs.Empty);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Causes the check box to automatically change state when clicked.")]
	[DefaultValue(true)]
	public bool AutoCheck
	{
		get
		{
			return _autoCheck;
		}
		set
		{
			_autoCheck = value;
		}
	}

	[Category("Behavior")]
	[Description("Indicates if the component allows three states instead of two.")]
	[DefaultValue(false)]
	public bool ThreeState
	{
		get
		{
			return _threeState;
		}
		set
		{
			if (_threeState != value)
			{
				_threeState = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Appearance")]
	[Description("Indicates the checked state of the component.")]
	[DefaultValue(typeof(CheckState), "Unchecked")]
	[Bindable(true)]
	public CheckState CheckState
	{
		get
		{
			return _checkState;
		}
		set
		{
			if (_checkState != value)
			{
				_checkState = value;
				bool flag = _checkState != CheckState.Unchecked;
				bool flag2 = _checked != flag;
				_checked = flag;
				if (flag2)
				{
					OnCheckedChanged(EventArgs.Empty);
				}
				OnCheckStateChanged(EventArgs.Empty);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the check button.")]
	[DefaultValue(null)]
	public virtual KryptonCommand KryptonCommand
	{
		get
		{
			return _command;
		}
		set
		{
			if (_command != value)
			{
				if (_command != null)
				{
					_command.PropertyChanged -= OnCommandPropertyChanged;
				}
				else
				{
					_wasEnabled = base.Enabled;
					_wasCheckState = CheckState;
				}
				_command = value;
				OnKryptonCommandChanged(EventArgs.Empty);
				if (_command != null)
				{
					_command.PropertyChanged += OnCommandPropertyChanged;
					return;
				}
				base.Enabled = _wasEnabled;
				CheckState = _wasCheckState;
			}
		}
	}

	protected override Size DefaultSize => new Size(90, 25);

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler DoubleClick;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler MouseDoubleClick;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler ImeModeChanged;

	[Category("Misc")]
	[Description("Occurs whenever the Checked property has changed.")]
	public event EventHandler CheckedChanged;

	[Category("Misc")]
	[Description("Occurs whenever the CheckState property has changed.")]
	public event EventHandler CheckStateChanged;

	[Category("Property Changed")]
	[Description("Occurs when the value of the KryptonCommand property changes.")]
	public event EventHandler KryptonCommandChanged;

	public KryptonCheckBox()
	{
		SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, value: false);
		_style = LabelStyle.NormalControl;
		_orientation = VisualOrientation.Top;
		_checkPosition = VisualOrientation.Left;
		_checked = false;
		_threeState = false;
		_checkState = CheckState.Unchecked;
		_useMnemonic = true;
		_autoCheck = true;
		_labelValues = new LabelValues(base.NeedPaintDelegate);
		_labelValues.TextChanged += OnCheckBoxTextChanged;
		_images = new CheckBoxImages(base.NeedPaintDelegate);
		_paletteCommonRedirect = new PaletteContentInheritRedirect(base.Redirector, PaletteContentStyle.LabelNormalControl);
		_paletteCheckBoxImages = new PaletteRedirectCheckBox(base.Redirector, _images);
		_stateCommon = new PaletteContent(_paletteCommonRedirect, base.NeedPaintDelegate);
		_stateDisabled = new PaletteContent(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteContent(_stateCommon, base.NeedPaintDelegate);
		_stateFocus = new PaletteContent(_paletteCommonRedirect, base.NeedPaintDelegate);
		_overrideNormal = new PaletteContentInheritOverride(_stateFocus, _stateNormal, PaletteState.FocusOverride, apply: false);
		_drawContent = new ViewDrawContent(_overrideNormal, this, VisualOrientation.Top);
		_drawContent.UseMnemonic = _useMnemonic;
		_drawContent.TestForFocusCues = true;
		_drawCheckBox = new ViewDrawCheckBox(_paletteCheckBoxImages);
		_drawCheckBox.CheckState = _checkState;
		_layoutCenter = new ViewLayoutCenter();
		_layoutCenter.Add(_drawCheckBox);
		_layoutDocker = new ViewLayoutDocker();
		_layoutDocker.Add(_layoutCenter, ViewDockStyle.Left);
		_layoutDocker.Add(_drawContent, ViewDockStyle.Fill);
		_controller = new CheckBoxController(_drawCheckBox, _layoutDocker, base.NeedPaintDelegate);
		_controller.Click += OnControllerClick;
		_controller.Enabled = true;
		_layoutDocker.MouseController = _controller;
		_layoutDocker.KeyController = _controller;
		UpdateForOrientation();
		base.ViewManager = new ViewManager(this, _layoutDocker);
		AutoSize = true;
		AutoSizeMode = AutoSizeMode.GrowAndShrink;
	}

	private bool ShouldSerializeText()
	{
		return false;
	}

	public override void ResetText()
	{
		_labelValues.ResetText();
	}

	private void ResetLabelStyle()
	{
		LabelStyle = LabelStyle.NormalControl;
	}

	private bool ShouldSerializeLabelStyle()
	{
		return LabelStyle != LabelStyle.NormalControl;
	}

	private bool ShouldSerializeValues()
	{
		return !_labelValues.IsDefault;
	}

	private bool ShouldSerializeImages()
	{
		return !_images.IsDefault;
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

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}

	public virtual void SetFixedState(bool focus, bool enabled, bool tracking, bool pressed)
	{
		_controller.Enabled = false;
		_overrideNormal.Apply = focus;
		_drawContent.FixedState = ((!enabled) ? PaletteState.Disabled : PaletteState.Normal);
		_drawCheckBox.Enabled = enabled;
		_drawCheckBox.Tracking = tracking;
		_drawCheckBox.Pressed = pressed;
	}

	public string GetShortText()
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.Text;
		}
		return _labelValues.GetShortText();
	}

	public string GetLongText()
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.ExtraText;
		}
		return _labelValues.GetLongText();
	}

	public Image GetImage(PaletteState state)
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.ImageSmall;
		}
		return _labelValues.GetImage(state);
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		if (KryptonCommand != null)
		{
			return KryptonCommand.ImageTransparentColor;
		}
		return _labelValues.GetImageTransparentColor(state);
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		if (this.DoubleClick != null)
		{
			this.DoubleClick(this, e);
		}
	}

	protected virtual void OnMouseDoubleClick(EventArgs e)
	{
		if (this.MouseDoubleClick != null)
		{
			this.MouseDoubleClick(this, e);
		}
	}

	protected virtual void OnMouseImeModeChanged(EventArgs e)
	{
		if (this.ImeModeChanged != null)
		{
			this.ImeModeChanged(this, e);
		}
	}

	protected virtual void OnCheckedChanged(EventArgs e)
	{
		if (this.CheckedChanged != null)
		{
			this.CheckedChanged(this, e);
		}
	}

	protected virtual void OnCheckStateChanged(EventArgs e)
	{
		_drawCheckBox.CheckState = _checkState;
		if (this.CheckStateChanged != null)
		{
			this.CheckStateChanged(this, e);
		}
		if (KryptonCommand != null)
		{
			KryptonCommand.CheckState = CheckState;
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		if (!_drawContent.IsFixed)
		{
			_overrideNormal.Apply = true;
			PerformNeedPaint(needLayout: false);
		}
		base.OnGotFocus(e);
	}

	protected virtual void OnKryptonCommandChanged(EventArgs e)
	{
		if (this.KryptonCommandChanged != null)
		{
			this.KryptonCommandChanged(this, e);
		}
		if (KryptonCommand != null)
		{
			base.Enabled = KryptonCommand.Enabled;
			CheckState = KryptonCommand.CheckState;
		}
		PerformNeedPaint(needLayout: true);
	}

	protected virtual void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "Enabled":
			base.Enabled = KryptonCommand.Enabled;
			break;
		case "CheckState":
			CheckState = KryptonCommand.CheckState;
			break;
		case "Text":
		case "ExtraText":
		case "ImageSmall":
		case "ImageTransparentColor":
			PerformNeedPaint(needLayout: true);
			break;
		}
	}

	protected override void OnLostFocus(EventArgs e)
	{
		if (!_drawContent.IsFixed)
		{
			_overrideNormal.Apply = false;
			PerformNeedPaint(needLayout: false);
		}
		base.OnLostFocus(e);
	}

	protected override void OnClick(EventArgs e)
	{
		if (AutoCheck)
		{
			switch (CheckState)
			{
			case CheckState.Unchecked:
				CheckState = CheckState.Checked;
				break;
			case CheckState.Checked:
				CheckState = (ThreeState ? CheckState.Indeterminate : CheckState.Unchecked);
				break;
			case CheckState.Indeterminate:
				CheckState = CheckState.Unchecked;
				break;
			}
		}
		base.OnClick(e);
		if (KryptonCommand != null)
		{
			KryptonCommand.PerformExecute();
		}
	}

	protected virtual void SetLabelStyle(LabelStyle style)
	{
		_paletteCommonRedirect.Style = CommonHelper.ContentStyleFromLabelStyle(style);
	}

	protected override bool ProcessMnemonic(char charCode)
	{
		if (UseMnemonic && AutoCheck && CanProcessMnemonic() && Control.IsMnemonic(charCode, Values.Text))
		{
			if (!base.ContainsFocus)
			{
				Focus();
			}
			OnClick(EventArgs.Empty);
			return true;
		}
		return base.ProcessMnemonic(charCode);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		if (base.Enabled)
		{
			_drawContent.SetPalette(_overrideNormal);
		}
		else
		{
			_drawContent.SetPalette(_stateDisabled);
		}
		_drawContent.Enabled = base.Enabled;
		_drawCheckBox.Enabled = base.Enabled;
		MarkLayoutDirty();
		base.OnEnabledChanged(e);
	}

	protected override void OnRightToLeftChanged(EventArgs e)
	{
		UpdateForOrientation();
		base.OnRightToLeftChanged(e);
	}

	protected override bool EvalTransparentPaint()
	{
		return true;
	}

	private void OnCheckBoxTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(EventArgs.Empty);
	}

	private void OnControllerClick(object sender, EventArgs e)
	{
		OnClick(e);
	}

	private void UpdateForOrientation()
	{
		ViewDockStyle dock = CheckPosition switch
		{
			VisualOrientation.Right => Orientation switch
			{
				VisualOrientation.Bottom => (RightToLeft != RightToLeft.Yes) ? ViewDockStyle.Left : ViewDockStyle.Right, 
				VisualOrientation.Left => ViewDockStyle.Top, 
				VisualOrientation.Right => ViewDockStyle.Bottom, 
				_ => (RightToLeft != RightToLeft.Yes) ? ViewDockStyle.Right : ViewDockStyle.Left, 
			}, 
			VisualOrientation.Top => Orientation switch
			{
				VisualOrientation.Bottom => ViewDockStyle.Bottom, 
				VisualOrientation.Left => ViewDockStyle.Left, 
				VisualOrientation.Right => ViewDockStyle.Right, 
				_ => ViewDockStyle.Top, 
			}, 
			VisualOrientation.Bottom => Orientation switch
			{
				VisualOrientation.Bottom => ViewDockStyle.Top, 
				VisualOrientation.Left => ViewDockStyle.Right, 
				VisualOrientation.Right => ViewDockStyle.Left, 
				_ => ViewDockStyle.Bottom, 
			}, 
			_ => Orientation switch
			{
				VisualOrientation.Bottom => (RightToLeft != RightToLeft.Yes) ? ViewDockStyle.Right : ViewDockStyle.Left, 
				VisualOrientation.Left => ViewDockStyle.Bottom, 
				VisualOrientation.Right => ViewDockStyle.Top, 
				_ => (RightToLeft != RightToLeft.Yes) ? ViewDockStyle.Left : ViewDockStyle.Right, 
			}, 
		};
		_layoutDocker.SetDock(_layoutCenter, dock);
	}
}

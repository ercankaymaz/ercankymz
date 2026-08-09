using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonLabel), "ToolboxBitmaps.KryptonLabel.bmp")]
[DefaultEvent("Paint")]
[DefaultProperty("Text")]
[DefaultBindingProperty("Text")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonLabelDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Displays descriptive information.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonLabel : VisualSimpleBase, IContentValues
{
	private LabelStyle _style;

	private LabelValues _labelValues;

	private VisualOrientation _orientation;

	private ViewDrawContent _drawContent;

	private PaletteContentInheritRedirect _paletteCommonRedirect;

	private PaletteContent _stateCommon;

	private PaletteContent _stateDisabled;

	private PaletteContent _stateNormal;

	private KryptonCommand _command;

	private bool _useMnemonic;

	private bool _enabledTarget;

	private bool _wasEnabled;

	private Control _target;

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
	[Localizable(false)]
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

	[Category("Visuals")]
	[Description("Target control for mnemonic and click actions.")]
	[DefaultValue(null)]
	public virtual Control Target
	{
		get
		{
			return _target;
		}
		set
		{
			_target = value;
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the label.")]
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
				}
				_command = value;
				OnKryptonCommandChanged(EventArgs.Empty);
				if (_command != null)
				{
					_command.PropertyChanged += OnCommandPropertyChanged;
				}
				else
				{
					base.Enabled = _wasEnabled;
				}
			}
		}
	}

	protected virtual ViewDrawContent ViewDrawContent => _drawContent;

	protected bool EnabledTarget
	{
		get
		{
			return _enabledTarget;
		}
		set
		{
			_enabledTarget = value;
		}
	}

	protected override Size DefaultSize => new Size(90, 25);

	[Category("Property Changed")]
	[Description("Occurs when the value of the KryptonCommand property changes.")]
	public event EventHandler KryptonCommandChanged;

	public KryptonLabel()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		_style = LabelStyle.NormalControl;
		_useMnemonic = true;
		_orientation = VisualOrientation.Top;
		_target = null;
		_enabledTarget = true;
		_labelValues = new LabelValues(base.NeedPaintDelegate);
		_labelValues.TextChanged += OnLabelTextChanged;
		_paletteCommonRedirect = new PaletteContentInheritRedirect(base.Redirector, PaletteContentStyle.LabelNormalControl);
		_stateCommon = new PaletteContent(_paletteCommonRedirect, base.NeedPaintDelegate);
		_stateDisabled = new PaletteContent(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteContent(_stateCommon, base.NeedPaintDelegate);
		_drawContent = new ViewDrawContent(_stateNormal, this, VisualOrientation.Top);
		_drawContent.UseMnemonic = _useMnemonic;
		base.ViewManager = new ViewManager(this, _drawContent);
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

	private bool ShouldSerializeLabelStyle()
	{
		return LabelStyle != LabelStyle.NormalControl;
	}

	private void ResetLabelStyle()
	{
		LabelStyle = LabelStyle.NormalControl;
	}

	private bool ShouldSerializeValues()
	{
		return !_labelValues.IsDefault;
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
		_drawContent.FixedState = state;
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

	protected virtual void SetLabelStyle(LabelStyle style)
	{
		_paletteCommonRedirect.Style = CommonHelper.ContentStyleFromLabelStyle(style);
	}

	protected override bool ProcessMnemonic(char charCode)
	{
		if (UseMnemonic && CanProcessMnemonic() && Control.IsMnemonic(charCode, Values.Text) && EnabledTarget && Target != null && Target.CanFocus)
		{
			Target.Focus();
			return true;
		}
		return base.ProcessMnemonic(charCode);
	}

	protected override void OnClick(EventArgs e)
	{
		if (EnabledTarget && Target != null && Target.CanFocus)
		{
			Target.Focus();
		}
		base.OnClick(e);
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
		case "Text":
		case "ExtraText":
		case "ImageSmall":
		case "ImageTransparentColor":
			PerformNeedPaint(needLayout: true);
			break;
		}
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		if (base.Enabled)
		{
			_drawContent.SetPalette(_stateNormal);
		}
		else
		{
			_drawContent.SetPalette(_stateDisabled);
		}
		_drawContent.Enabled = base.Enabled;
		MarkLayoutDirty();
		base.OnEnabledChanged(e);
	}

	protected override bool EvalTransparentPaint()
	{
		return true;
	}

	private void OnLabelTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(EventArgs.Empty);
	}
}

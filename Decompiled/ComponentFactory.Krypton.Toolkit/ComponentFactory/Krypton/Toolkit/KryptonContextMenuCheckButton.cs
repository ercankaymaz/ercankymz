using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuCheckButton), "ToolboxBitmaps.KryptonCheckButton.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Text")]
[DefaultEvent("CheckedChanged")]
public class KryptonContextMenuCheckButton : KryptonContextMenuItemBase
{
	private bool _autoCheck;

	private bool _autoClose;

	private bool _checked;

	private bool _enabled;

	private string _text;

	private string _extraText;

	private Image _image;

	private Color _imageTransparentColor;

	private ButtonStyle _style;

	private PaletteTripleRedirect _stateCommon;

	private PaletteTripleRedirect _stateFocus;

	private PaletteTriple _stateDisabled;

	private PaletteTriple _stateNormal;

	private PaletteTriple _stateTracking;

	private PaletteTriple _statePressed;

	private PaletteTriple _stateCheckedNormal;

	private PaletteTriple _stateCheckedTracking;

	private PaletteTriple _stateCheckedPressed;

	private PaletteTripleOverride _overrideCheckedNormal;

	private PaletteTripleOverride _overrideCheckedTracking;

	private PaletteTripleOverride _overrideCheckedPressed;

	private PaletteTripleOverride _overrideNormal;

	private PaletteTripleOverride _overrideTracking;

	private PaletteTripleOverride _overridePressed;

	private PaletteTripleOverride _overrideDisabled;

	private KryptonCommand _command;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => null;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates if clicking the check box automatically closes the context menu.")]
	[DefaultValue(false)]
	public bool AutoClose
	{
		get
		{
			return _autoClose;
		}
		set
		{
			if (_autoClose != value)
			{
				_autoClose = value;
				OnPropertyChanged(new PropertyChangedEventArgs("AutoClose"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Main check box text.")]
	[DefaultValue("CheckBox")]
	[Localizable(true)]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (_text != value)
			{
				_text = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Text"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Check box extra text.")]
	[DefaultValue("")]
	[Localizable(true)]
	public string ExtraText
	{
		get
		{
			return _extraText;
		}
		set
		{
			if (_extraText != value)
			{
				_extraText = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ExtraText"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Check box image.")]
	[DefaultValue(null)]
	[Localizable(true)]
	public Image Image
	{
		get
		{
			return _image;
		}
		set
		{
			if (_image != value)
			{
				_image = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Image"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Check box image color to make transparent.")]
	[Localizable(true)]
	public Color ImageTransparentColor
	{
		get
		{
			return _imageTransparentColor;
		}
		set
		{
			if (_imageTransparentColor != value)
			{
				_imageTransparentColor = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageTransparentColor"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Check button style.")]
	[DefaultValue(typeof(ButtonStyle), "Standalone")]
	public ButtonStyle ButtonStyle
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
				SetCheckButtonStyle(_style);
				OnPropertyChanged(new PropertyChangedEventArgs("ButtonStyle"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates whether the check box is enabled.")]
	[DefaultValue(true)]
	[Bindable(true)]
	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (_enabled != value)
			{
				_enabled = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Enabled"));
			}
		}
	}

	[KryptonPersist]
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
				OnCheckedChanged(EventArgs.Empty);
				OnPropertyChanged(new PropertyChangedEventArgs("Checked"));
			}
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Causes the check box to automatically change state when clicked.")]
	[DefaultValue(false)]
	public bool AutoCheck
	{
		get
		{
			return _autoCheck;
		}
		set
		{
			if (_autoCheck != value)
			{
				_autoCheck = value;
				OnPropertyChanged(new PropertyChangedEventArgs("AutoCheck"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common button appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StatePressed => _statePressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tracking button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateTracking => _stateTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal checked button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedNormal => _stateCheckedNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining hot tracking checked button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedTracking => _stateCheckedTracking;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pressed checked button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedPressed => _stateCheckedPressed;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining button appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect OverrideFocus => _stateFocus;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Command associated with the menu check button.")]
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
				_command = value;
				OnPropertyChanged(new PropertyChangedEventArgs("KryptonCommand"));
			}
		}
	}

	internal PaletteTripleOverride OverrideCheckedNormal => _overrideCheckedNormal;

	internal PaletteTripleOverride OverrideCheckedTracking => _overrideCheckedTracking;

	internal PaletteTripleOverride OverrideCheckedPressed => _overrideCheckedPressed;

	internal PaletteTripleOverride OverrideDisabled => _overrideDisabled;

	internal PaletteTripleOverride OverrideNormal => _overrideNormal;

	internal PaletteTripleOverride OverrideTracking => _overrideTracking;

	internal PaletteTripleOverride OverridePressed => _overridePressed;

	[Category("Action")]
	[Description("Occurs when the check box item is clicked.")]
	public event EventHandler Click;

	[Category("Misc")]
	[Description("Occurs whenever the Checked property has changed.")]
	public event EventHandler CheckedChanged;

	public KryptonContextMenuCheckButton()
		: this("CheckButton")
	{
	}

	public KryptonContextMenuCheckButton(string initialText)
	{
		_enabled = true;
		_autoClose = false;
		_text = initialText;
		_extraText = string.Empty;
		_image = null;
		_imageTransparentColor = Color.Empty;
		_checked = false;
		_autoCheck = false;
		_style = ButtonStyle.Standalone;
		_stateCommon = new PaletteTripleRedirect(PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone);
		_stateFocus = new PaletteTripleRedirect(PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone);
		_stateDisabled = new PaletteTriple(_stateCommon);
		_stateNormal = new PaletteTriple(_stateCommon);
		_stateTracking = new PaletteTriple(_stateCommon);
		_statePressed = new PaletteTriple(_stateCommon);
		_stateCheckedNormal = new PaletteTriple(_stateCommon);
		_stateCheckedTracking = new PaletteTriple(_stateCommon);
		_stateCheckedPressed = new PaletteTriple(_stateCommon);
		_overrideDisabled = new PaletteTripleOverride(_stateFocus, _stateDisabled, PaletteState.FocusOverride);
		_overrideNormal = new PaletteTripleOverride(_stateFocus, _stateNormal, PaletteState.FocusOverride);
		_overrideTracking = new PaletteTripleOverride(_stateFocus, _stateTracking, PaletteState.FocusOverride);
		_overridePressed = new PaletteTripleOverride(_stateFocus, _statePressed, PaletteState.FocusOverride);
		_overrideCheckedNormal = new PaletteTripleOverride(_stateFocus, _stateCheckedNormal, PaletteState.FocusOverride);
		_overrideCheckedTracking = new PaletteTripleOverride(_stateFocus, _stateCheckedTracking, PaletteState.FocusOverride);
		_overrideCheckedPressed = new PaletteTripleOverride(_stateFocus, _stateCheckedPressed, PaletteState.FocusOverride);
	}

	public override string ToString()
	{
		return Text;
	}

	public override bool ProcessShortcut(Keys keyData)
	{
		return false;
	}

	public override ViewBase GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		return new ViewDrawMenuCheckButton(provider, this);
	}

	private bool ShouldSerializeImageTransparentColor()
	{
		_ = _imageTransparentColor;
		return !_imageTransparentColor.Equals(Color.Empty);
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

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
	}

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStateCheckedNormal()
	{
		return !_stateCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateCheckedTracking()
	{
		return !_stateCheckedTracking.IsDefault;
	}

	private bool ShouldSerializeStateCheckedPressed()
	{
		return !_stateCheckedPressed.IsDefault;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}

	public void PerformClick()
	{
		OnClick(EventArgs.Empty);
	}

	protected virtual void OnClick(EventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
		if (KryptonCommand != null)
		{
			KryptonCommand.PerformExecute();
		}
	}

	protected virtual void OnCheckedChanged(EventArgs e)
	{
		if (this.CheckedChanged != null)
		{
			this.CheckedChanged(this, e);
		}
	}

	internal void SetPaletteRedirect(PaletteRedirect redirector)
	{
		_stateCommon.SetRedirector(redirector);
		_stateFocus.SetRedirector(redirector);
	}

	private void SetCheckButtonStyle(ButtonStyle style)
	{
		_stateCommon.SetStyles(style);
		_stateFocus.SetStyles(style);
	}
}

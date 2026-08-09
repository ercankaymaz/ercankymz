using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuRadioButton), "ToolboxBitmaps.KryptonRadioButton.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("Text")]
[DefaultEvent("CheckedChanged")]
public class KryptonContextMenuRadioButton : KryptonContextMenuItemBase
{
	private bool _autoCheck;

	private bool _autoClose;

	private bool _checked;

	private bool _enabled;

	private string _text;

	private string _extraText;

	private Image _image;

	private Color _imageTransparentColor;

	private PaletteContentInheritRedirect _stateCommonRedirect;

	private PaletteContent _stateCommon;

	private PaletteContent _stateDisabled;

	private PaletteContent _stateNormal;

	private PaletteContent _stateFocus;

	private PaletteContentInheritOverride _overrideNormal;

	private PaletteContentInheritOverride _overrideDisabled;

	private PaletteRedirectRadioButton _stateRadioButtonImages;

	private RadioButtonImages _images;

	private LabelStyle _style;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => null;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates if clicking the cradio button automatically closes the context menu.")]
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
	[Description("Main radio button text.")]
	[DefaultValue("RadioButton")]
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
	[Description("Radio button extra text.")]
	[DefaultValue(null)]
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
	[Description("Radio button image.")]
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
	[Description("Radio button image color to make transparent.")]
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
	[Description("Radio button label style.")]
	[DefaultValue(typeof(LabelStyle), "NormalControl")]
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
				SetRadioButtonStyle(_style);
				OnPropertyChanged(new PropertyChangedEventArgs("LabelStyle"));
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Image value overrides.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public RadioButtonImages Images => _images;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates whether the radio button is enabled.")]
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
	[Description("Causes the radio button to automatically change state when clicked.")]
	[DefaultValue(true)]
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
	[Description("Overrides for defining common radio button appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled radio button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal radio button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining radio button appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideFocus => _stateFocus;

	internal PaletteContentInheritOverride OverrideNormal => _overrideNormal;

	internal PaletteContentInheritOverride OverrideDisabled => _overrideDisabled;

	internal PaletteRedirectRadioButton StateRadioButtonImages => _stateRadioButtonImages;

	[Category("Action")]
	[Description("Occurs when the radio button is clicked.")]
	public event EventHandler Click;

	[Category("Misc")]
	[Description("Occurs whenever the Checked property has changed.")]
	public event EventHandler CheckedChanged;

	public KryptonContextMenuRadioButton()
		: this("RadioButton")
	{
	}

	public KryptonContextMenuRadioButton(string initialText)
	{
		_enabled = true;
		_autoClose = false;
		_text = initialText;
		_extraText = string.Empty;
		_image = null;
		_imageTransparentColor = Color.Empty;
		_checked = false;
		_autoCheck = true;
		_style = LabelStyle.NormalControl;
		_images = new RadioButtonImages();
		_stateCommonRedirect = new PaletteContentInheritRedirect(PaletteContentStyle.LabelNormalControl);
		_stateRadioButtonImages = new PaletteRedirectRadioButton(_images);
		_stateCommon = new PaletteContent(_stateCommonRedirect);
		_stateDisabled = new PaletteContent(_stateCommon);
		_stateNormal = new PaletteContent(_stateCommon);
		_stateFocus = new PaletteContent(_stateCommonRedirect);
		_overrideNormal = new PaletteContentInheritOverride(_stateFocus, _stateNormal, PaletteState.FocusOverride, apply: false);
		_overrideDisabled = new PaletteContentInheritOverride(_stateFocus, _stateDisabled, PaletteState.FocusOverride, apply: false);
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
		return new ViewDrawMenuRadioButton(provider, this);
	}

	private bool ShouldSerializeImageTransparentColor()
	{
		_ = _imageTransparentColor;
		return !_imageTransparentColor.Equals(Color.Empty);
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
		_stateCommonRedirect.SetRedirector(redirector);
		_stateRadioButtonImages.Target = redirector;
	}

	private void SetRadioButtonStyle(LabelStyle style)
	{
		_stateCommonRedirect.Style = CommonHelper.ContentStyleFromLabelStyle(style);
	}
}

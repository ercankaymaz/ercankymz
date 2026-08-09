using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteButtonSpecTyped : KryptonPaletteButtonSpecBase
{
	private Image _image;

	private string _text;

	private string _extraText;

	private string _toolTipTitle;

	private Color _colorMap;

	private bool _allowInheritImage;

	private bool _allowInheritText;

	private bool _allowInheritExtraText;

	private bool _allowInheritToolTipTitle;

	private CheckButtonImageStates _imageStates;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _imageStates.IsDefault && Image == null && Text == string.Empty && ExtraText == string.Empty && ToolTipTitle == string.Empty && ColorMap == Color.Empty && AllowInheritImage && AllowInheritText && AllowInheritExtraText && AllowInheritToolTipTitle;

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button image.")]
	[DefaultValue(null)]
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
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("State specific images for the button.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public CheckButtonImageStates ImageStates => _imageStates;

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
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
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button extra text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
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
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button tooltip title text.")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public string ToolTipTitle
	{
		get
		{
			return _toolTipTitle;
		}
		set
		{
			if (_toolTipTitle != value)
			{
				_toolTipTitle = value;
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Image color to remap to container foreground.")]
	[KryptonDefaultColor]
	public Color ColorMap
	{
		get
		{
			return _colorMap;
		}
		set
		{
			if (_colorMap != value)
			{
				_colorMap = value;
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Should button image be inherited if defined as null.")]
	[DefaultValue(true)]
	public bool AllowInheritImage
	{
		get
		{
			return _allowInheritImage;
		}
		set
		{
			if (_allowInheritImage != value)
			{
				_allowInheritImage = value;
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Should button text be inherited if defined as empty.")]
	[DefaultValue(true)]
	public bool AllowInheritText
	{
		get
		{
			return _allowInheritText;
		}
		set
		{
			if (_allowInheritText != value)
			{
				_allowInheritText = value;
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Should button extra text be inherited if defined as empty.")]
	[DefaultValue(true)]
	public bool AllowInheritExtraText
	{
		get
		{
			return _allowInheritExtraText;
		}
		set
		{
			if (_allowInheritExtraText != value)
			{
				_allowInheritExtraText = value;
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Should button tooltip title text be inherited if defined as empty.")]
	[DefaultValue(true)]
	public bool AllowInheritToolTipTitle
	{
		get
		{
			return _allowInheritToolTipTitle;
		}
		set
		{
			if (_allowInheritToolTipTitle != value)
			{
				_allowInheritToolTipTitle = value;
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	internal KryptonPaletteButtonSpecTyped(PaletteRedirect redirector)
		: base(redirector)
	{
		_image = null;
		_text = string.Empty;
		_extraText = string.Empty;
		_toolTipTitle = string.Empty;
		_colorMap = Color.Empty;
		_allowInheritImage = true;
		_allowInheritText = true;
		_allowInheritExtraText = true;
		_allowInheritToolTipTitle = true;
		_imageStates = new CheckButtonImageStates();
		_imageStates.NeedPaint = OnImageStateChanged;
	}

	public override void PopulateFromBase(PaletteButtonSpecStyle style)
	{
		base.PopulateFromBase(style);
		Image = base.Redirector.GetButtonSpecImage(style, PaletteState.Normal);
		ImageStates.ImageDisabled = base.Redirector.GetButtonSpecImage(style, PaletteState.Disabled);
		ImageStates.ImageNormal = base.Redirector.GetButtonSpecImage(style, PaletteState.Normal);
		ImageStates.ImageTracking = base.Redirector.GetButtonSpecImage(style, PaletteState.Tracking);
		ImageStates.ImagePressed = base.Redirector.GetButtonSpecImage(style, PaletteState.Pressed);
		ImageStates.ImageCheckedNormal = base.Redirector.GetButtonSpecImage(style, PaletteState.CheckedNormal);
		ImageStates.ImageCheckedTracking = base.Redirector.GetButtonSpecImage(style, PaletteState.CheckedTracking);
		ImageStates.ImageCheckedPressed = base.Redirector.GetButtonSpecImage(style, PaletteState.CheckedPressed);
		Text = base.Redirector.GetButtonSpecShortText(style);
		ExtraText = base.Redirector.GetButtonSpecLongText(style);
		ColorMap = base.Redirector.GetButtonSpecColorMap(style);
	}

	private bool ShouldSerializeImage()
	{
		return Image != null;
	}

	public void ResetImage()
	{
		Image = null;
	}

	private bool ShouldSerializeImageStates()
	{
		return !_imageStates.IsDefault;
	}

	private bool ShouldSerializeText()
	{
		return Text != string.Empty;
	}

	public void ResetText()
	{
		Text = string.Empty;
	}

	private bool ShouldSerializeExtraText()
	{
		return ExtraText != string.Empty;
	}

	public void ResetExtraText()
	{
		ExtraText = string.Empty;
	}

	private bool ShouldSerializeToolTipTitle()
	{
		return ToolTipTitle != string.Empty;
	}

	public void ResetToolTipTitle()
	{
		ToolTipTitle = string.Empty;
	}

	private bool ShouldSerializeColorMap()
	{
		return ColorMap != Color.Empty;
	}

	public void ResetColorMap()
	{
		ColorMap = Color.Empty;
	}

	public void ResetAllowInheritImage()
	{
		AllowInheritImage = true;
	}

	public void ResetAllowInheritText()
	{
		AllowInheritText = true;
	}

	public void ResetAllowInheritExtraText()
	{
		AllowInheritExtraText = true;
	}

	public void ResetAllowInheritToolTipTitle()
	{
		AllowInheritToolTipTitle = true;
	}

	public override Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state)
	{
		Image image = null;
		switch (state)
		{
		case PaletteState.Disabled:
			image = ImageStates.ImageDisabled;
			break;
		case PaletteState.Normal:
			image = ImageStates.ImageNormal;
			break;
		case PaletteState.Pressed:
			image = ImageStates.ImagePressed;
			break;
		case PaletteState.Tracking:
			image = ImageStates.ImageTracking;
			break;
		case PaletteState.CheckedNormal:
			image = ImageStates.ImageCheckedNormal;
			break;
		case PaletteState.CheckedPressed:
			image = ImageStates.ImageCheckedPressed;
			break;
		case PaletteState.CheckedTracking:
			image = ImageStates.ImageCheckedTracking;
			break;
		}
		if (image == null)
		{
			image = Image;
		}
		if (image != null || !AllowInheritImage)
		{
			return image;
		}
		return base.GetButtonSpecImage(style, state);
	}

	public override string GetButtonSpecShortText(PaletteButtonSpecStyle style)
	{
		if (Text.Length > 0 || !AllowInheritText)
		{
			return Text;
		}
		return base.GetButtonSpecShortText(style);
	}

	public override string GetButtonSpecLongText(PaletteButtonSpecStyle style)
	{
		if (ExtraText.Length > 0 || !AllowInheritExtraText)
		{
			return ExtraText;
		}
		return base.GetButtonSpecLongText(style);
	}

	public override string GetButtonSpecToolTipTitle(PaletteButtonSpecStyle style)
	{
		if (ToolTipTitle.Length > 0 || !AllowInheritToolTipTitle)
		{
			return ToolTipTitle;
		}
		return base.GetButtonSpecToolTipTitle(style);
	}

	public override Color GetButtonSpecColorMap(PaletteButtonSpecStyle style)
	{
		if (ColorMap != Color.Empty)
		{
			return ColorMap;
		}
		return base.GetButtonSpecColorMap(style);
	}

	private void OnImageStateChanged(object sender, NeedLayoutEventArgs e)
	{
		OnButtonSpecChanged(sender, EventArgs.Empty);
	}
}

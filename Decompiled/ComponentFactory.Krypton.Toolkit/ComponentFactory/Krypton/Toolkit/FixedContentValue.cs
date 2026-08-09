using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class FixedContentValue : IContentValues
{
	private string _shortText;

	private string _longText;

	private Image _image;

	private Color _imageTransparentColor;

	[Category("Appearance")]
	[Description("Main text.")]
	[Localizable(true)]
	[DefaultValue("")]
	public string ShortText
	{
		get
		{
			return _shortText;
		}
		set
		{
			_shortText = value;
		}
	}

	[Category("Appearance")]
	[Description("Supplementary text.")]
	[Localizable(true)]
	[DefaultValue("")]
	public string LongText
	{
		get
		{
			return _longText;
		}
		set
		{
			_longText = value;
		}
	}

	[Category("Appearance")]
	[Description("Image associated with item.")]
	[Localizable(true)]
	public Image Image
	{
		get
		{
			return _image;
		}
		set
		{
			_image = value;
		}
	}

	[Category("Appearance")]
	[Description("Color to treat as transparent in the Image.")]
	[Localizable(true)]
	public Color ImageTransparentColor
	{
		get
		{
			return _imageTransparentColor;
		}
		set
		{
			_imageTransparentColor = value;
		}
	}

	public FixedContentValue()
		: this(string.Empty, string.Empty, null, Color.Empty)
	{
	}

	public FixedContentValue(string shortText, string longText, Image image, Color imageTransparentColor)
	{
		_shortText = shortText;
		_longText = longText;
		_image = image;
		_imageTransparentColor = imageTransparentColor;
	}

	private bool ShouldSerializeShortText()
	{
		return !string.IsNullOrEmpty(_shortText);
	}

	private bool ShouldSerializeLongText()
	{
		return !string.IsNullOrEmpty(_longText);
	}

	private bool ShouldSerializeImage()
	{
		return _image != null;
	}

	private bool ShouldSerializeImageTransparentColor()
	{
		return _imageTransparentColor != Color.Empty;
	}

	public string GetShortText()
	{
		return _shortText;
	}

	public Image GetImage(PaletteState state)
	{
		return _image;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return _imageTransparentColor;
	}

	public string GetLongText()
	{
		return _longText;
	}
}

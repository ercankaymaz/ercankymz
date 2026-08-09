using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class KryptonListItem : Component, IContentValues
{
	private string _shortText;

	private string _longText;

	private Image _image;

	private Color _imageTransparentColor;

	private object _tag;

	[Category("Appearance")]
	[Description("Main text.")]
	[Localizable(true)]
	public string ShortText
	{
		get
		{
			return _shortText;
		}
		set
		{
			if (_shortText != value)
			{
				_shortText = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ShortText"));
			}
		}
	}

	[Category("Appearance")]
	[Description("Supplementary text.")]
	[Localizable(true)]
	public string LongText
	{
		get
		{
			return _longText;
		}
		set
		{
			if (_longText != value)
			{
				_longText = value;
				OnPropertyChanged(new PropertyChangedEventArgs("LongText"));
			}
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
			if (_image != value)
			{
				_image = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Image"));
			}
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
			if (_imageTransparentColor != value)
			{
				_imageTransparentColor = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ImageTransparentColor"));
			}
		}
	}

	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[DefaultValue(null)]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	[Category("Property Changed")]
	[Description("Occurs when the value of property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	public KryptonListItem()
		: this("ListItem", null, null, Color.Empty)
	{
	}

	public KryptonListItem(string shortText)
		: this(shortText, null, null, Color.Empty)
	{
	}

	public KryptonListItem(string shortText, string longText)
		: this(shortText, longText, null, Color.Empty)
	{
	}

	public KryptonListItem(string shortText, string longText, Image image)
		: this(shortText, longText, image, Color.Empty)
	{
	}

	public KryptonListItem(string shortText, string longText, Image image, Color imageTransparentColor)
	{
		_shortText = shortText;
		_longText = longText;
		_image = image;
		_imageTransparentColor = imageTransparentColor;
	}

	public override string ToString()
	{
		return ShortText;
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

	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, e);
		}
	}
}

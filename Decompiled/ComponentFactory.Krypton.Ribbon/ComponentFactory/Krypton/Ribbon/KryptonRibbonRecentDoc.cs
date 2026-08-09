using System;
using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonRecentDoc), "ToolboxBitmaps.KryptonRibbonRecentDoc.png")]
[DefaultProperty("Text")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public class KryptonRibbonRecentDoc : Component
{
	private Image _image;

	private Color _imageTransparentColor;

	private string _text;

	private string _extraText;

	private object _tag;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Main text for the recent document entry.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("Recent Document")]
	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "Recent Document";
			}
			if (value != _text)
			{
				_text = value;
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Extra text for the recent document entry.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("")]
	public string ExtraText
	{
		get
		{
			return _extraText;
		}
		set
		{
			if (value != _extraText)
			{
				_extraText = value;
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Image for the recent document entry.")]
	[RefreshProperties(RefreshProperties.All)]
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
			}
		}
	}

	[Category("Appearance")]
	[Description("Image color to make transparent.")]
	[DefaultValue(typeof(Color), "")]
	[Localizable(true)]
	[Bindable(true)]
	public Color ImageTransparentColor
	{
		get
		{
			return _imageTransparentColor;
		}
		set
		{
			if (value != _imageTransparentColor)
			{
				_imageTransparentColor = value;
			}
		}
	}

	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[Bindable(true)]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			if (value != _tag)
			{
				_tag = value;
			}
		}
	}

	[Category("Action")]
	[Description("Occurs when the recent document item is clicked.")]
	public event EventHandler Click;

	public KryptonRibbonRecentDoc()
	{
		_text = "Recent Document";
		_extraText = string.Empty;
		_imageTransparentColor = Color.Empty;
	}

	private bool ShouldSerializeTag()
	{
		return Tag != null;
	}

	private void ResetTag()
	{
		Tag = null;
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
}

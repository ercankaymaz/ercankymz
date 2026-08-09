using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonValues : Storage, IContentValues
{
	private const string _defaultText = "Button";

	private static readonly string _defaultExtraText = string.Empty;

	private Image _image;

	private Color _transparent;

	private string _text;

	private string _extraText;

	private ButtonImageStates _imageStates;

	[Browsable(false)]
	public override bool IsDefault => ImageStates.IsDefault && Image == null && ImageTransparentColor == Color.Empty && Text == "Button" && ExtraText == _defaultExtraText;

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button image.")]
	[RefreshProperties(RefreshProperties.All)]
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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Label image transparent color.")]
	[RefreshProperties(RefreshProperties.All)]
	[KryptonDefaultColor]
	public Color ImageTransparentColor
	{
		get
		{
			return _transparent;
		}
		set
		{
			if (_transparent != value)
			{
				_transparent = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("State specific images for the button.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public ButtonImageStates ImageStates => _imageStates;

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button text.")]
	[RefreshProperties(RefreshProperties.All)]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
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
				PerformNeedPaint(needLayout: true);
				if (this.TextChanged != null)
				{
					this.TextChanged(this, EventArgs.Empty);
				}
			}
		}
	}

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button extra text.")]
	[RefreshProperties(RefreshProperties.All)]
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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public event EventHandler TextChanged;

	public ButtonValues(NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_image = null;
		_transparent = Color.Empty;
		_text = "Button";
		_extraText = _defaultExtraText;
		_imageStates = CreateImageStates();
		_imageStates.NeedPaint = needPaint;
	}

	private bool ShouldSerializeImage()
	{
		return Image != null;
	}

	public void ResetImage()
	{
		Image = null;
	}

	private bool ShouldSerializeImageTransparentColor()
	{
		return ImageTransparentColor != Color.Empty;
	}

	public void ResetImageTransparentColor()
	{
		ImageTransparentColor = Color.Empty;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return ImageTransparentColor;
	}

	private bool ShouldSerializeImageStates()
	{
		return !_imageStates.IsDefault;
	}

	private bool ShouldSerializeText()
	{
		return Text != "Button";
	}

	public void ResetText()
	{
		Text = "Button";
	}

	private bool ShouldSerializeExtraText()
	{
		return ExtraText != _defaultExtraText;
	}

	public void ResetExtraText()
	{
		ExtraText = _defaultExtraText;
	}

	protected virtual ButtonImageStates CreateImageStates()
	{
		return new ButtonImageStates();
	}

	public virtual Image GetImage(PaletteState state)
	{
		Image image = null;
		switch (state)
		{
		case PaletteState.Disabled:
			image = _imageStates.ImageDisabled;
			break;
		case PaletteState.Normal:
			image = _imageStates.ImageNormal;
			break;
		case PaletteState.Pressed:
			image = _imageStates.ImagePressed;
			break;
		case PaletteState.Tracking:
			image = _imageStates.ImageTracking;
			break;
		}
		if (image == null)
		{
			image = Image;
		}
		return image;
	}

	public virtual string GetShortText()
	{
		return Text;
	}

	public virtual string GetLongText()
	{
		return ExtraText;
	}
}

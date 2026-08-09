using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class ColorButtonValues : Storage, IContentValues
{
	private const string _defaultText = "Color";

	private static readonly string _defaultExtraText = string.Empty;

	private static readonly Image _defaultImage = Resources.ButtonColorImageSmall;

	private Image _image;

	private Image _sourceImage;

	private Image _compositeImage;

	private Color _transparent;

	private string _text;

	private string _extraText;

	private ButtonImageStates _imageStates;

	private Color _selectedColor;

	private Color _emptyBorderColor;

	private Rectangle _selectedRect;

	[Browsable(false)]
	public override bool IsDefault => ImageStates.IsDefault && Image == _defaultImage && ImageTransparentColor == Color.Empty && Text == "Color" && ExtraText == _defaultExtraText;

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

	internal Color SelectedColor
	{
		get
		{
			return _selectedColor;
		}
		set
		{
			_selectedColor = value;
			_compositeImage = null;
		}
	}

	internal Color EmptyBorderColor
	{
		get
		{
			return _emptyBorderColor;
		}
		set
		{
			_emptyBorderColor = value;
			_compositeImage = null;
		}
	}

	internal Rectangle SelectedRect
	{
		get
		{
			return _selectedRect;
		}
		set
		{
			_selectedRect = value;
			_compositeImage = null;
		}
	}

	public event EventHandler TextChanged;

	public ColorButtonValues(NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_image = _defaultImage;
		_transparent = Color.Empty;
		_text = "Color";
		_extraText = _defaultExtraText;
		_imageStates = CreateImageStates();
		_imageStates.NeedPaint = needPaint;
		_emptyBorderColor = Color.Gray;
		_selectedColor = Color.Red;
		_selectedRect = new Rectangle(0, 12, 16, 4);
	}

	private bool ShouldSerializeImage()
	{
		return Image != _defaultImage;
	}

	public void ResetImage()
	{
		Image = _defaultImage;
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
		return Text != "Color";
	}

	public void ResetText()
	{
		Text = "Color";
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
		if (_sourceImage != image || _compositeImage == null)
		{
			_sourceImage = image;
			if (image == null)
			{
				_compositeImage = null;
			}
			else
			{
				Bitmap bitmap = new Bitmap(image);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					if (_selectedColor.Equals(Color.Empty))
					{
						using Pen pen = new Pen(_emptyBorderColor);
						graphics.DrawRectangle(pen, new Rectangle(_selectedRect.X, _selectedRect.Y, _selectedRect.Width - 1, _selectedRect.Height - 1));
					}
					else
					{
						using SolidBrush brush = new SolidBrush(_selectedColor);
						graphics.FillRectangle(brush, _selectedRect);
					}
				}
				_compositeImage = bitmap;
			}
		}
		return _compositeImage;
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

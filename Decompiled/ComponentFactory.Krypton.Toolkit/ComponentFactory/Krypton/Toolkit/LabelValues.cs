using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace ComponentFactory.Krypton.Toolkit;

public class LabelValues : Storage, IContentValues
{
	private const string _defaultText = "Label";

	private static readonly string _defaultExtraText = string.Empty;

	private Image _image;

	private Color _transparent;

	private string _text;

	private string _extraText;

	[Browsable(false)]
	public override bool IsDefault => Image == null && ImageTransparentColor == Color.Empty && Text == "Label" && ExtraText == _defaultExtraText;

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Label image.")]
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

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Label text.")]
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
	[Description("Label extra text.")]
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

	public LabelValues(NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_image = null;
		_transparent = Color.Empty;
		_text = "Label";
		_extraText = _defaultExtraText;
	}

	private bool ShouldSerializeImage()
	{
		return Image != null;
	}

	public void ResetImage()
	{
		Image = null;
	}

	public Image GetImage(PaletteState state)
	{
		return Image;
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

	private bool ShouldSerializeText()
	{
		return Text != "Label";
	}

	public void ResetText()
	{
		Text = "Label";
	}

	public string GetShortText()
	{
		return Text;
	}

	private bool ShouldSerializeExtraText()
	{
		return ExtraText != _defaultExtraText;
	}

	public void ResetExtraText()
	{
		ExtraText = ExtraText;
	}

	public string GetLongText()
	{
		return ExtraText;
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class HeaderValuesBase : Storage, IContentValues
{
	private static readonly Image _defaultImage = Resources.ComponentYellow;

	private Image _image;

	private Color _transparent;

	private string _heading;

	private string _description;

	[Browsable(false)]
	public override bool IsDefault => Image == GetImageDefault() && ImageTransparentColor == Color.Empty && Heading == GetHeadingDefault() && Description == GetDescriptionDefault();

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Heading image.")]
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
	[Description("Heading image transparent color.")]
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
	[Description("Heading text.")]
	[RefreshProperties(RefreshProperties.All)]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public virtual string Heading
	{
		get
		{
			return _heading;
		}
		set
		{
			if (_heading != value)
			{
				_heading = value;
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
	[Description("Header description text.")]
	[RefreshProperties(RefreshProperties.All)]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public virtual string Description
	{
		get
		{
			return _description;
		}
		set
		{
			if (_description != value)
			{
				_description = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public event EventHandler TextChanged;

	protected HeaderValuesBase(NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_image = GetImageDefault();
		_transparent = Color.Empty;
		_heading = GetHeadingDefault();
		_description = GetDescriptionDefault();
	}

	protected virtual Image GetImageDefault()
	{
		return _defaultImage;
	}

	protected abstract string GetHeadingDefault();

	protected abstract string GetDescriptionDefault();

	private bool ShouldSerializeImage()
	{
		return Image != GetImageDefault();
	}

	public void ResetImage()
	{
		Image = GetImageDefault();
	}

	public virtual Image GetImage(PaletteState state)
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

	public virtual Color GetImageTransparentColor(PaletteState state)
	{
		return ImageTransparentColor;
	}

	private bool ShouldSerializeHeading()
	{
		return Heading != GetHeadingDefault();
	}

	public void ResetHeading()
	{
		Heading = GetHeadingDefault();
	}

	public virtual string GetShortText()
	{
		return Heading;
	}

	private bool ShouldSerializeDescription()
	{
		return Description != GetDescriptionDefault();
	}

	public void ResetDescription()
	{
		Description = GetDescriptionDefault();
	}

	public virtual string GetLongText()
	{
		return Description;
	}
}

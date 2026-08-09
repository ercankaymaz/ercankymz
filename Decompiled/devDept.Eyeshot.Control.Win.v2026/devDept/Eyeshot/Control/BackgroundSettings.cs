using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(BackgroundConverter))]
public class BackgroundSettings : IBackgroundSettings, ICloneable
{
	private Viewport _parentViewport;

	private TextureBase _texture;

	private Color _bottomColor;

	private Color _intermediateColor;

	private Color _topColor;

	private double _intermediateColorPosition;

	internal int texture1DLength;

	private bool _isBrightnessFrozen;

	private int _brightnessFrozenStatus;

	protected internal virtual Viewport ParentViewport
	{
		get
		{
			return _parentViewport;
		}
		set
		{
			_parentViewport = value;
		}
	}

	[Description("The background style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public backgroundStyleType StyleMode { get; set; }

	[Description("The bottom color, applies only to Gradient styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color BottomColor
	{
		get
		{
			return _bottomColor;
		}
		set
		{
			_bottomColor = value;
		}
	}

	[Description("The intermediate color, applies only to Gradient styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color IntermediateColor
	{
		get
		{
			return _intermediateColor;
		}
		set
		{
			_intermediateColor = value;
		}
	}

	[Description("The top color, applies only to Gradient styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color TopColor
	{
		get
		{
			return _topColor;
		}
		set
		{
			_topColor = value;
		}
	}

	[Description("Intermediate color position expressed in percent of viewport height from top (range 0-1).")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[TypeConverter(typeof(OpacityConverter))]
	public double IntermediateColorPosition
	{
		get
		{
			return _intermediateColorPosition;
		}
		set
		{
			_intermediateColorPosition = value;
		}
	}

	[Description("Button hover status, progress bar, view cube ring (when the ViewCubeIcon.Lighting property is false), zoom window and selection boxes transparency level (range 0-1).")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[TypeConverter(typeof(OpacityConverter))]
	public double ColorThemeTransparency { get; set; }

	[Description("Image, applies only to Image style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image Image { get; set; }

	[Description("The UI elements color theme.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public colorThemeType ColorTheme { get; set; }

	public TextureBase Texture => _texture;

	public bool IsDark => (_isBrightnessFrozen ? _brightnessFrozenStatus : _0023_003Dzpr9_NdLiNiLSz65png_003D_003D()) < 130;

	static BackgroundSettings()
	{
		_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D _0023_003DzL07WkTo_003D = (_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D)0;
		object[] array = null;
		array = new object[1] { _0023_003DzL07WkTo_003D };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "M#I>Qq\"ad(", array);
	}

	public BackgroundSettings()
		: this(_0023_003DzCp6SpVT8Q9QG(), _0023_003Dznt6fRDzSS_Uu(), _0023_003Dzuv1T2_00246smxFY(), _0023_003DzeBSAOgJFNIX6(), _0023_003DzFKHyQDhXYBQMBDn2FA_003D_003D(), _0023_003DznYWOeKNePhve(), _0023_003Dzx1KiAsuA1zo0(), _0023_003DzpQGzPRRj5YNoSi9OUA_003D_003D())
	{
	}

	public BackgroundSettings(backgroundStyleType styleMode, Color bottomColor, Color intermediateColor, Color topColor, double intermediateColorPosition, Image image, colorThemeType colorTheme, double colorThemeTransparency)
	{
		StyleMode = styleMode;
		BottomColor = RenderContextUtility.ConvertColor(bottomColor);
		IntermediateColor = RenderContextUtility.ConvertColor(intermediateColor);
		TopColor = RenderContextUtility.ConvertColor(topColor);
		IntermediateColorPosition = intermediateColorPosition;
		Image = image;
		ColorTheme = colorTheme;
		ColorThemeTransparency = colorThemeTransparency;
	}

	public BackgroundSettings(backgroundStyleType styleMode, Color bottomColor, Color intermediateColor, Color topColor, double intermediateColorPosition, Image image)
		: this(styleMode, bottomColor, intermediateColor, topColor, intermediateColorPosition, image, _0023_003Dzx1KiAsuA1zo0(), _0023_003DzpQGzPRRj5YNoSi9OUA_003D_003D())
	{
		StyleMode = styleMode;
		BottomColor = RenderContextUtility.ConvertColor(bottomColor);
		IntermediateColor = RenderContextUtility.ConvertColor(intermediateColor);
		TopColor = RenderContextUtility.ConvertColor(topColor);
		IntermediateColorPosition = intermediateColorPosition;
		Image = image;
	}

	public BackgroundSettings(BackgroundSettings another)
		: this(another.StyleMode, RenderContextUtility.ConvertColor(another.BottomColor), RenderContextUtility.ConvertColor(another.IntermediateColor), RenderContextUtility.ConvertColor(another.TopColor), another.IntermediateColorPosition, another.Image, another.ColorTheme, another.ColorThemeTransparency)
	{
	}

	void IBackgroundSettings.SetTexture(RenderContextBase renderContext, TextureBase.textureUnitType textureUnit)
	{
		_0023_003DzMdkgcnE_003D(renderContext, textureUnit);
	}

	public virtual object Clone()
	{
		return new BackgroundSettings(this);
	}

	private bool _0023_003DzuooydjCMSwlZPpsh1w_003D_003D()
	{
		return StyleMode != _0023_003DzCp6SpVT8Q9QG();
	}

	internal void _0023_003DzyUvVZflI9bLt()
	{
		StyleMode = _0023_003DzCp6SpVT8Q9QG();
	}

	private bool _0023_003Dz0xRhvVad5bYl()
	{
		return _bottomColor.ToArgb() != _0023_003Dznt6fRDzSS_Uu().ToArgb();
	}

	private void _0023_003DzEMhqFSkLGhzg()
	{
		BottomColor = _0023_003Dznt6fRDzSS_Uu();
	}

	private bool _0023_003Dzjwuyw9wwEsib()
	{
		return _intermediateColor.ToArgb() != _0023_003Dzuv1T2_00246smxFY().ToArgb();
	}

	private void _0023_003DzwJs6oVw4AbHe()
	{
		IntermediateColor = _0023_003Dzuv1T2_00246smxFY();
	}

	private bool _0023_003DzFDUkog5fF3U_0024()
	{
		return _topColor.ToArgb() != _0023_003DzeBSAOgJFNIX6().ToArgb();
	}

	private void _0023_003DztcqN_NjlHx_c()
	{
		TopColor = _0023_003DzeBSAOgJFNIX6();
	}

	private bool _0023_003DzNgUazSfIYcW_0024b3O5yw_003D_003D()
	{
		return IntermediateColorPosition != _0023_003DzFKHyQDhXYBQMBDn2FA_003D_003D();
	}

	private void _0023_003Dzm80d7DEJ45Zq()
	{
		IntermediateColorPosition = _0023_003DzFKHyQDhXYBQMBDn2FA_003D_003D();
	}

	private bool _0023_003Dz90BrVLXLa81yHh7Y2Q_003D_003D()
	{
		return ColorThemeTransparency != _0023_003DzpQGzPRRj5YNoSi9OUA_003D_003D();
	}

	private void _0023_003DzAvJOUpDAW9f0()
	{
		ColorThemeTransparency = _0023_003DzpQGzPRRj5YNoSi9OUA_003D_003D();
	}

	private bool _0023_003DzCZlQDubFVGj1()
	{
		return Image != _0023_003DznYWOeKNePhve();
	}

	private void _0023_003Dz6zqt53PVMvO7()
	{
		Image = _0023_003DznYWOeKNePhve();
	}

	private static colorThemeType _0023_003Dzx1KiAsuA1zo0()
	{
		return colorThemeType.Auto;
	}

	private static double _0023_003DzpQGzPRRj5YNoSi9OUA_003D_003D()
	{
		return 0.33;
	}

	private bool _0023_003DzWu28x684YHUO()
	{
		return ColorTheme != _0023_003Dzx1KiAsuA1zo0();
	}

	private void _0023_003Dz_GrDEIfs6j_P()
	{
		ColorTheme = _0023_003Dzx1KiAsuA1zo0();
	}

	private static backgroundStyleType _0023_003DzCp6SpVT8Q9QG()
	{
		return backgroundStyleType.Solid;
	}

	private static Color _0023_003DzeBSAOgJFNIX6()
	{
		return Color.WhiteSmoke;
	}

	private static Color _0023_003Dzuv1T2_00246smxFY()
	{
		return Color.DodgerBlue;
	}

	private static Color _0023_003Dznt6fRDzSS_Uu()
	{
		return Color.DeepSkyBlue;
	}

	private static double _0023_003DzFKHyQDhXYBQMBDn2FA_003D_003D()
	{
		return 0.75;
	}

	private static Image _0023_003DznYWOeKNePhve()
	{
		return null;
	}

	internal void _0023_003DzG7_0024fT88_0024REjz(TextureBase _0023_003DzsLHxXyo_003D)
	{
		if (_texture != null)
		{
			_texture.Dispose();
		}
		_texture = _0023_003DzsLHxXyo_003D;
	}

	public bool ShouldSerialize(BackgroundSettings reference)
	{
		if (StyleMode == reference.StyleMode && !(BottomColor != reference.BottomColor) && !(IntermediateColor != reference.IntermediateColor) && !(TopColor != reference.TopColor) && IntermediateColorPosition == reference.IntermediateColorPosition && Image == reference.Image && ColorTheme == reference.ColorTheme)
		{
			return ColorThemeTransparency != reference.ColorThemeTransparency;
		}
		return true;
	}

	internal void _0023_003DzMdkgcnE_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, TextureBase.textureUnitType _0023_003Dz6FK5Z_V8Q85h)
	{
		backgroundStyleType styleMode = StyleMode;
		if ((uint)(styleMode - 3) <= 1u)
		{
			_0023_003DzmNZD0Zs_003D.SetTexture(Texture, _0023_003Dz6FK5Z_V8Q85h);
		}
	}

	public float GetImageScale(int cameraWidth, int cameraHeight, out float bmpWidth, out float bmpHeight)
	{
		bmpWidth = Texture.Size.Width;
		bmpHeight = Texture.Size.Height;
		float val = (float)cameraWidth / bmpWidth;
		float val2 = (float)cameraHeight / bmpHeight;
		return Math.Max(val, val2);
	}

	public Color GetSelectionBoxColor(Color color)
	{
		bool num = ColorTheme == colorThemeType.Dark || IsDark;
		_0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D2 = new _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D(color);
		if (num)
		{
			_0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D2._0023_003DzJRAeP5bZBG5K(192.0);
		}
		_0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D2._0023_003DzJRAeP5bZBG5K(64.0);
		return Color.FromArgb(color.A, _0023_003Dz2jGoybW16AiJRQ2VxQWPuXwIKOsepHfSpg_003D_003D2);
	}

	public Color GetContrastColorSemiTransparent()
	{
		return Color.FromArgb((int)(255.0 * ColorThemeTransparency), GetContrastColor());
	}

	public Color GetContrastColor()
	{
		return ColorTheme switch
		{
			colorThemeType.Dark => Color.Black, 
			colorThemeType.Light => Color.White, 
			_ => IsDark ? Color.White : Color.Black, 
		};
	}

	public Color GetContrastColorInverted()
	{
		Color contrastColor = GetContrastColor();
		return Color.FromArgb(255 - contrastColor.R, 255 - contrastColor.G, 255 - contrastColor.B);
	}

	public void FreezeBrightness(bool freeze)
	{
		if (!_isBrightnessFrozen)
		{
			_brightnessFrozenStatus = _0023_003Dzpr9_NdLiNiLSz65png_003D_003D();
		}
		_isBrightnessFrozen = freeze;
	}

	internal int _0023_003Dzpr9_NdLiNiLSz65png_003D_003D()
	{
		double num = 0.0;
		int num2 = 0;
		switch (StyleMode)
		{
		case backgroundStyleType.None:
			num = 0.0;
			num2 = 1;
			break;
		case backgroundStyleType.Solid:
			num += _0023_003Dzpr9_NdLiNiLSz65png_003D_003D(TopColor);
			num2 = 1;
			break;
		case backgroundStyleType.LinearGradient:
			num += _0023_003Dzpr9_NdLiNiLSz65png_003D_003D(TopColor);
			num += _0023_003Dzpr9_NdLiNiLSz65png_003D_003D(BottomColor);
			num2 = 2;
			break;
		case backgroundStyleType.CubicGradient:
			num += _0023_003Dzpr9_NdLiNiLSz65png_003D_003D(TopColor);
			num += _0023_003Dzpr9_NdLiNiLSz65png_003D_003D(IntermediateColor);
			num += _0023_003Dzpr9_NdLiNiLSz65png_003D_003D(BottomColor);
			num2 = 3;
			break;
		case backgroundStyleType.Image:
		{
			int num3 = 4;
			Bitmap bitmap = new Bitmap(Image);
			try
			{
				for (int i = 0; i <= 3; i++)
				{
					for (int j = 0; j <= 3; j++)
					{
						Color pixel = bitmap.GetPixel(j * bitmap.Width / (num3 + 1), j * bitmap.Height / (num3 + 1));
						num += _0023_003Dzpr9_NdLiNiLSz65png_003D_003D(RenderContextUtility.ConvertColor(pixel));
					}
				}
			}
			finally
			{
				((IDisposable)bitmap).Dispose();
			}
			num2 = num3 * num3;
			break;
		}
		}
		return (int)(num / (double)num2);
	}

	private double _0023_003Dzpr9_NdLiNiLSz65png_003D_003D(Color _0023_003Dzhpb8QNg_003D)
	{
		return Math.Sqrt(0.299 * (double)(int)_0023_003Dzhpb8QNg_003D.R * (double)(int)_0023_003Dzhpb8QNg_003D.R + 0.587 * (double)(int)_0023_003Dzhpb8QNg_003D.G * (double)(int)_0023_003Dzhpb8QNg_003D.G + 0.114 * (double)(int)_0023_003Dzhpb8QNg_003D.B * (double)(int)_0023_003Dzhpb8QNg_003D.B);
	}
}

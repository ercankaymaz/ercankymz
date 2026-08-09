using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteCargo : Storage
{
	private Color _color1;

	private Color _color2;

	private Color _color3;

	private Color _color4;

	private Color _color5;

	private Font _font1;

	private Font _font2;

	[Browsable(false)]
	public override bool IsDefault => _color1 == Color.Empty && _color2 == Color.Empty && _color3 == Color.Empty && _color4 == Color.Empty && _color5 == Color.Empty && _font1 == null && _font2 == null;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("User supplied color value.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public Color Color1
	{
		get
		{
			return _color1;
		}
		set
		{
			_color1 = value;
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("User supplied color value.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public Color Color2
	{
		get
		{
			return _color2;
		}
		set
		{
			_color2 = value;
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("User supplied color value.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public Color Color3
	{
		get
		{
			return _color3;
		}
		set
		{
			_color3 = value;
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("User supplied color value.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public Color Color4
	{
		get
		{
			return _color4;
		}
		set
		{
			_color4 = value;
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("User supplied color value.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public Color Color5
	{
		get
		{
			return _color5;
		}
		set
		{
			_color5 = value;
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("User supplied font value.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Font Font1
	{
		get
		{
			return _font1;
		}
		set
		{
			_font1 = value;
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("User supplied font value.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Font Font2
	{
		get
		{
			return _font2;
		}
		set
		{
			_font2 = value;
		}
	}

	public KryptonPaletteCargo(NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_color1 = Color.Empty;
		_color2 = Color.Empty;
		_color3 = Color.Empty;
		_color4 = Color.Empty;
		_color5 = Color.Empty;
	}

	public void ResetColor1()
	{
		Color1 = Color.Empty;
	}

	public void ResetColor2()
	{
		Color2 = Color.Empty;
	}

	public void ResetColor3()
	{
		Color3 = Color.Empty;
	}

	public void ResetColor4()
	{
		Color4 = Color.Empty;
	}

	public void ResetColor5()
	{
		Color5 = Color.Empty;
	}

	public void ResetFont1()
	{
		Font1 = null;
	}

	public void ResetFont2()
	{
		Font2 = null;
	}
}

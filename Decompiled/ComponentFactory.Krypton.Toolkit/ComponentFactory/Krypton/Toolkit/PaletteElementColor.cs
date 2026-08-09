using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteElementColor : Storage, IPaletteElementColor
{
	private IPaletteElementColor _inheritElementColor;

	private Color _color1;

	private Color _color2;

	private Color _color3;

	private Color _color4;

	private Color _color5;

	[Browsable(false)]
	public override bool IsDefault => Color1 == Color.Empty && Color2 == Color.Empty && Color3 == Color.Empty && Color4 == Color.Empty && Color5 == Color.Empty;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("First element color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color Color1
	{
		get
		{
			return _color1;
		}
		set
		{
			if (_color1 != value)
			{
				_color1 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Second element color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color Color2
	{
		get
		{
			return _color2;
		}
		set
		{
			if (_color2 != value)
			{
				_color2 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Third element color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color Color3
	{
		get
		{
			return _color3;
		}
		set
		{
			if (_color3 != value)
			{
				_color3 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Fourth element color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color Color4
	{
		get
		{
			return _color4;
		}
		set
		{
			if (_color4 != value)
			{
				_color4 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Fifth element color.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color Color5
	{
		get
		{
			return _color5;
		}
		set
		{
			if (_color5 != value)
			{
				_color5 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public PaletteElementColor(IPaletteElementColor inheritElementColor, NeedPaintHandler needPaint)
	{
		_inheritElementColor = inheritElementColor;
		NeedPaint = needPaint;
		_color1 = Color.Empty;
		_color2 = Color.Empty;
		_color3 = Color.Empty;
		_color4 = Color.Empty;
		_color5 = Color.Empty;
	}

	public void SetInherit(IPaletteElementColor inheritElementColor)
	{
		_inheritElementColor = inheritElementColor;
	}

	public void PopulateFromBase(PaletteState state)
	{
		Color1 = GetElementColor1(state);
		Color2 = GetElementColor2(state);
		Color3 = GetElementColor3(state);
		Color4 = GetElementColor4(state);
		Color5 = GetElementColor5(state);
	}

	public void ResetColor1()
	{
		Color1 = Color.Empty;
	}

	public Color GetElementColor1(PaletteState state)
	{
		if (Color1 != Color.Empty)
		{
			return Color1;
		}
		return _inheritElementColor.GetElementColor1(state);
	}

	public void ResetColor2()
	{
		Color2 = Color.Empty;
	}

	public Color GetElementColor2(PaletteState state)
	{
		if (Color2 != Color.Empty)
		{
			return Color2;
		}
		return _inheritElementColor.GetElementColor2(state);
	}

	public void ResetColor3()
	{
		Color3 = Color.Empty;
	}

	public Color GetElementColor3(PaletteState state)
	{
		if (Color3 != Color.Empty)
		{
			return Color3;
		}
		return _inheritElementColor.GetElementColor3(state);
	}

	public void ResetColor4()
	{
		Color4 = Color.Empty;
	}

	public Color GetElementColor4(PaletteState state)
	{
		if (Color4 != Color.Empty)
		{
			return Color4;
		}
		return _inheritElementColor.GetElementColor4(state);
	}

	public void ResetColor5()
	{
		Color5 = Color.Empty;
	}

	public Color GetElementColor5(PaletteState state)
	{
		if (Color5 != Color.Empty)
		{
			return Color5;
		}
		return _inheritElementColor.GetElementColor5(state);
	}
}

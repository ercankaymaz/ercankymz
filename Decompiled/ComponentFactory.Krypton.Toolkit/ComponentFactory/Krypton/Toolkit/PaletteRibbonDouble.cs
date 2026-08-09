#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRibbonDouble : Storage, IPaletteRibbonBack, IPaletteRibbonText
{
	private IPaletteRibbonBack _inheritBack;

	private IPaletteRibbonText _inheritText;

	private Color _backColor1;

	private Color _backColor2;

	private Color _backColor3;

	private Color _backColor4;

	private Color _backColor5;

	private Color _textColor;

	[Browsable(false)]
	public override bool IsDefault => BackColor1 == Color.Empty && BackColor2 == Color.Empty && BackColor3 == Color.Empty && BackColor4 == Color.Empty && BackColor5 == Color.Empty && TextColor == Color.Empty;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("First background color for the ribbon item.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color BackColor1
	{
		get
		{
			return _backColor1;
		}
		set
		{
			if (_backColor1 != value)
			{
				_backColor1 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Second background color for the ribbon item.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color BackColor2
	{
		get
		{
			return _backColor2;
		}
		set
		{
			if (_backColor2 != value)
			{
				_backColor2 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Third background color for the ribbon item.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color BackColor3
	{
		get
		{
			return _backColor3;
		}
		set
		{
			if (_backColor3 != value)
			{
				_backColor3 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Fourth background color for the ribbon item.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color BackColor4
	{
		get
		{
			return _backColor4;
		}
		set
		{
			if (_backColor4 != value)
			{
				_backColor4 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Fifth background color for the ribbon item.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color BackColor5
	{
		get
		{
			return _backColor5;
		}
		set
		{
			if (_backColor5 != value)
			{
				_backColor5 = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Tab color for the tab text.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color TextColor
	{
		get
		{
			return _textColor;
		}
		set
		{
			if (_textColor != value)
			{
				_textColor = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public PaletteRibbonDouble(IPaletteRibbonBack inheritBack, IPaletteRibbonText inheritText, NeedPaintHandler needPaint)
	{
		Debug.Assert(inheritBack != null);
		Debug.Assert(inheritText != null);
		_inheritBack = inheritBack;
		_inheritText = inheritText;
		NeedPaint = needPaint;
		_backColor1 = Color.Empty;
		_backColor2 = Color.Empty;
		_backColor3 = Color.Empty;
		_backColor4 = Color.Empty;
		_backColor5 = Color.Empty;
		_textColor = Color.Empty;
	}

	public void SetInherit(IPaletteRibbonBack inheritBack, IPaletteRibbonText inheritText)
	{
		_inheritBack = inheritBack;
		_inheritText = inheritText;
	}

	public void PopulateFromBase(PaletteState state)
	{
		BackColor1 = GetRibbonBackColor1(state);
		BackColor2 = GetRibbonBackColor2(state);
		BackColor3 = GetRibbonBackColor3(state);
		BackColor4 = GetRibbonBackColor4(state);
		BackColor5 = GetRibbonBackColor5(state);
		TextColor = GetRibbonTextColor(state);
	}

	public PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteState state)
	{
		return _inheritBack.GetRibbonBackColorStyle(state);
	}

	public void ResetBackColor1()
	{
		BackColor1 = Color.Empty;
	}

	public Color GetRibbonBackColor1(PaletteState state)
	{
		if (BackColor1 != Color.Empty)
		{
			return BackColor1;
		}
		return _inheritBack.GetRibbonBackColor1(state);
	}

	public void ResetBackColor2()
	{
		BackColor2 = Color.Empty;
	}

	public Color GetRibbonBackColor2(PaletteState state)
	{
		if (BackColor2 != Color.Empty)
		{
			return BackColor2;
		}
		return _inheritBack.GetRibbonBackColor2(state);
	}

	public void ResetBackColor3()
	{
		BackColor3 = Color.Empty;
	}

	public Color GetRibbonBackColor3(PaletteState state)
	{
		if (BackColor3 != Color.Empty)
		{
			return BackColor3;
		}
		return _inheritBack.GetRibbonBackColor3(state);
	}

	public void ResetBackColor4()
	{
		BackColor4 = Color.Empty;
	}

	public Color GetRibbonBackColor4(PaletteState state)
	{
		if (BackColor4 != Color.Empty)
		{
			return BackColor4;
		}
		return _inheritBack.GetRibbonBackColor4(state);
	}

	public void ResetBackColor5()
	{
		BackColor5 = Color.Empty;
	}

	public Color GetRibbonBackColor5(PaletteState state)
	{
		if (BackColor5 != Color.Empty)
		{
			return BackColor5;
		}
		return _inheritBack.GetRibbonBackColor5(state);
	}

	public void ResetTextColor()
	{
		TextColor = Color.Empty;
	}

	public Color GetRibbonTextColor(PaletteState state)
	{
		if (TextColor != Color.Empty)
		{
			return TextColor;
		}
		return _inheritText.GetRibbonTextColor(state);
	}
}

#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteInputControlBackStates : Storage, IPaletteBack
{
	private IPaletteBack _inherit;

	private Color _color1;

	[Browsable(false)]
	public override bool IsDefault => Color1 == Color.Empty;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Main background color.")]
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
			if (value != _color1)
			{
				_color1 = value;
				PerformNeedPaint();
			}
		}
	}

	protected IPaletteBack Inherit => _inherit;

	public PaletteInputControlBackStates(IPaletteBack inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
		NeedPaint = needPaint;
		_color1 = Color.Empty;
	}

	public void SetInherit(IPaletteBack inherit)
	{
		_inherit = inherit;
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		Color1 = GetBackColor1(state);
	}

	public InheritBool GetBackDraw(PaletteState state)
	{
		return _inherit.GetBackDraw(state);
	}

	public PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		return _inherit.GetBackGraphicsHint(state);
	}

	public Color GetBackColor1(PaletteState state)
	{
		if (Color1 != Color.Empty)
		{
			return Color1;
		}
		return _inherit.GetBackColor1(state);
	}

	public Color GetBackColor2(PaletteState state)
	{
		return _inherit.GetBackColor2(state);
	}

	public PaletteColorStyle GetBackColorStyle(PaletteState state)
	{
		return _inherit.GetBackColorStyle(state);
	}

	public PaletteRectangleAlign GetBackColorAlign(PaletteState state)
	{
		return _inherit.GetBackColorAlign(state);
	}

	public float GetBackColorAngle(PaletteState state)
	{
		return _inherit.GetBackColorAngle(state);
	}

	public Image GetBackImage(PaletteState state)
	{
		return _inherit.GetBackImage(state);
	}

	public PaletteImageStyle GetBackImageStyle(PaletteState state)
	{
		return _inherit.GetBackImageStyle(state);
	}

	public PaletteRectangleAlign GetBackImageAlign(PaletteState state)
	{
		return _inherit.GetBackImageAlign(state);
	}
}

#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBorderEdge : PaletteBack
{
	private PaletteBorderEdgeRedirect _inherit;

	private int _borderWidth;

	[Browsable(false)]
	public override bool IsDefault => _borderWidth == -1 && base.IsDefault;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border width.")]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.All)]
	public int Width
	{
		get
		{
			return _borderWidth;
		}
		set
		{
			if (value != _borderWidth)
			{
				_borderWidth = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public PaletteBorderEdge(PaletteBorderEdgeRedirect inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
		_borderWidth = -1;
	}

	public int GetBorderWidth(PaletteState state)
	{
		if (Width != -1)
		{
			return Width;
		}
		return _inherit.GetBorderWidth(state);
	}
}

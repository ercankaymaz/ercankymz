#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBorderEdgeRedirect : PaletteBack, IPaletteBorder
{
	internal class BackToBorder : IPaletteBack
	{
		private IPaletteBorder _parent;

		public BackToBorder(IPaletteBorder parent)
		{
			Debug.Assert(parent != null);
			_parent = parent;
		}

		public InheritBool GetBackDraw(PaletteState state)
		{
			return _parent.GetBorderDraw(state);
		}

		public PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
		{
			return PaletteGraphicsHint.None;
		}

		public Color GetBackColor1(PaletteState state)
		{
			return _parent.GetBorderColor1(state);
		}

		public Color GetBackColor2(PaletteState state)
		{
			return _parent.GetBorderColor2(state);
		}

		public PaletteColorStyle GetBackColorStyle(PaletteState state)
		{
			return _parent.GetBorderColorStyle(state);
		}

		public PaletteRectangleAlign GetBackColorAlign(PaletteState state)
		{
			return _parent.GetBorderColorAlign(state);
		}

		public float GetBackColorAngle(PaletteState state)
		{
			return _parent.GetBorderColorAngle(state);
		}

		public Image GetBackImage(PaletteState state)
		{
			return _parent.GetBorderImage(state);
		}

		public PaletteImageStyle GetBackImageStyle(PaletteState state)
		{
			return _parent.GetBorderImageStyle(state);
		}

		public PaletteRectangleAlign GetBackImageAlign(PaletteState state)
		{
			return _parent.GetBorderImageAlign(state);
		}
	}

	private IPaletteBorder _inherit;

	private BackToBorder _translate;

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

	public PaletteBorderEdgeRedirect(IPaletteBorder inherit, NeedPaintHandler needPaint)
		: base(null, needPaint)
	{
		_inherit = inherit;
		_borderWidth = -1;
		_translate = new BackToBorder(this);
		SetInherit(_translate);
	}

	public virtual void SetPalette(IPaletteBorder paletteBorder)
	{
		_inherit = paletteBorder;
	}

	public InheritBool GetBorderDraw(PaletteState state)
	{
		return _inherit.GetBorderDraw(state);
	}

	public PaletteDrawBorders GetBorderDrawBorders(PaletteState state)
	{
		return _inherit.GetBorderDrawBorders(state);
	}

	public PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state)
	{
		return _inherit.GetBorderGraphicsHint(state);
	}

	public Color GetBorderColor1(PaletteState state)
	{
		return _inherit.GetBorderColor1(state);
	}

	public Color GetBorderColor2(PaletteState state)
	{
		return _inherit.GetBorderColor2(state);
	}

	public PaletteColorStyle GetBorderColorStyle(PaletteState state)
	{
		return _inherit.GetBorderColorStyle(state);
	}

	public PaletteRectangleAlign GetBorderColorAlign(PaletteState state)
	{
		return _inherit.GetBorderColorAlign(state);
	}

	public float GetBorderColorAngle(PaletteState state)
	{
		return _inherit.GetBorderColorAngle(state);
	}

	public int GetBorderWidth(PaletteState state)
	{
		if (Width != -1)
		{
			return Width;
		}
		return _inherit.GetBorderWidth(state);
	}

	public int GetBorderRounding(PaletteState state)
	{
		return _inherit.GetBorderRounding(state);
	}

	public Image GetBorderImage(PaletteState state)
	{
		return _inherit.GetBorderImage(state);
	}

	public PaletteImageStyle GetBorderImageStyle(PaletteState state)
	{
		return _inherit.GetBorderImageStyle(state);
	}

	public PaletteRectangleAlign GetBorderImageAlign(PaletteState state)
	{
		return _inherit.GetBorderImageAlign(state);
	}
}

#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteDataGridViewBackInherit : PaletteBackInherit
{
	private IPaletteBack _inherit;

	private DataGridViewCellStyle _cellStyle;

	public void SetInherit(IPaletteBack inherit, DataGridViewCellStyle cellStyle)
	{
		Debug.Assert(inherit != null);
		Debug.Assert(cellStyle != null);
		_inherit = inherit;
		_cellStyle = cellStyle;
	}

	public override InheritBool GetBackDraw(PaletteState state)
	{
		return _inherit.GetBackDraw(state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		return _inherit.GetBackGraphicsHint(state);
	}

	public override Color GetBackColor1(PaletteState state)
	{
		return state switch
		{
			PaletteState.Normal => _cellStyle.BackColor, 
			PaletteState.CheckedNormal => _cellStyle.SelectionBackColor, 
			_ => _inherit.GetBackColor1(state), 
		};
	}

	public override Color GetBackColor2(PaletteState state)
	{
		return _inherit.GetBackColor2(state);
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteState state)
	{
		return _inherit.GetBackColorStyle(state);
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteState state)
	{
		return _inherit.GetBackColorAlign(state);
	}

	public override float GetBackColorAngle(PaletteState state)
	{
		return _inherit.GetBackColorAngle(state);
	}

	public override Image GetBackImage(PaletteState state)
	{
		return _inherit.GetBackImage(state);
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteState state)
	{
		return _inherit.GetBackImageStyle(state);
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteState state)
	{
		return _inherit.GetBackImageAlign(state);
	}
}

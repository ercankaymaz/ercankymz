#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteDataGridViewContentInherit : PaletteContentInherit
{
	private IPaletteContent _inherit;

	private DataGridViewCellStyle _cellStyle;

	public void SetInherit(IPaletteContent inherit, DataGridViewCellStyle cellStyle)
	{
		Debug.Assert(inherit != null);
		Debug.Assert(cellStyle != null);
		_inherit = inherit;
		_cellStyle = cellStyle;
	}

	public override InheritBool GetContentDraw(PaletteState state)
	{
		return _inherit.GetContentDraw(state);
	}

	public override InheritBool GetContentDrawFocus(PaletteState state)
	{
		return _inherit.GetContentDrawFocus(state);
	}

	public override PaletteRelativeAlign GetContentImageH(PaletteState state)
	{
		return _inherit.GetContentImageH(state);
	}

	public override PaletteRelativeAlign GetContentImageV(PaletteState state)
	{
		return _inherit.GetContentImageV(state);
	}

	public override PaletteImageEffect GetContentImageEffect(PaletteState state)
	{
		return _inherit.GetContentImageEffect(state);
	}

	public override Color GetContentImageColorMap(PaletteState state)
	{
		return _inherit.GetContentImageColorMap(state);
	}

	public override Color GetContentImageColorTo(PaletteState state)
	{
		return _inherit.GetContentImageColorTo(state);
	}

	public override Font GetContentShortTextFont(PaletteState state)
	{
		if (_cellStyle != null)
		{
			return _cellStyle.Font;
		}
		return SystemFonts.DefaultFont;
	}

	public override Font GetContentShortTextNewFont(PaletteState state)
	{
		if (_cellStyle != null)
		{
			return _cellStyle.Font;
		}
		return SystemFonts.DefaultFont;
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		return _inherit.GetContentShortTextHint(state);
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		return _inherit.GetContentShortTextPrefix(state);
	}

	public override InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
		return _inherit.GetContentShortTextMultiLine(state);
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		return _inherit.GetContentShortTextTrim(state);
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		switch (_cellStyle.Alignment)
		{
		case DataGridViewContentAlignment.TopLeft:
		case DataGridViewContentAlignment.MiddleLeft:
		case DataGridViewContentAlignment.BottomLeft:
			return PaletteRelativeAlign.Near;
		case DataGridViewContentAlignment.TopCenter:
		case DataGridViewContentAlignment.MiddleCenter:
		case DataGridViewContentAlignment.BottomCenter:
			return PaletteRelativeAlign.Center;
		case DataGridViewContentAlignment.TopRight:
		case DataGridViewContentAlignment.MiddleRight:
		case DataGridViewContentAlignment.BottomRight:
			return PaletteRelativeAlign.Far;
		default:
			return _inherit.GetContentShortTextH(state);
		}
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		switch (_cellStyle.Alignment)
		{
		case DataGridViewContentAlignment.TopLeft:
		case DataGridViewContentAlignment.TopCenter:
		case DataGridViewContentAlignment.TopRight:
			return PaletteRelativeAlign.Near;
		case DataGridViewContentAlignment.MiddleLeft:
		case DataGridViewContentAlignment.MiddleCenter:
		case DataGridViewContentAlignment.MiddleRight:
			return PaletteRelativeAlign.Center;
		case DataGridViewContentAlignment.BottomLeft:
		case DataGridViewContentAlignment.BottomCenter:
		case DataGridViewContentAlignment.BottomRight:
			return PaletteRelativeAlign.Far;
		default:
			return _inherit.GetContentShortTextV(state);
		}
	}

	public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state)
	{
		return _inherit.GetContentShortTextMultiLineH(state);
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		return state switch
		{
			PaletteState.Normal => _cellStyle.ForeColor, 
			PaletteState.CheckedNormal => _cellStyle.SelectionForeColor, 
			_ => _inherit.GetContentShortTextColor1(state), 
		};
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		return _inherit.GetContentShortTextColor2(state);
	}

	public override PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		return _inherit.GetContentShortTextColorStyle(state);
	}

	public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		return _inherit.GetContentShortTextColorAlign(state);
	}

	public override float GetContentShortTextColorAngle(PaletteState state)
	{
		return _inherit.GetContentShortTextColorAngle(state);
	}

	public override Image GetContentShortTextImage(PaletteState state)
	{
		return _inherit.GetContentShortTextImage(state);
	}

	public override PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		return _inherit.GetContentShortTextImageStyle(state);
	}

	public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
		return _inherit.GetContentShortTextImageAlign(state);
	}

	public override Font GetContentLongTextFont(PaletteState state)
	{
		return _cellStyle.Font;
	}

	public override Font GetContentLongTextNewFont(PaletteState state)
	{
		return _cellStyle.Font;
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		return _inherit.GetContentLongTextHint(state);
	}

	public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state)
	{
		return _inherit.GetContentLongTextPrefix(state);
	}

	public override InheritBool GetContentLongTextMultiLine(PaletteState state)
	{
		return _inherit.GetContentLongTextMultiLine(state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return _inherit.GetContentLongTextTrim(state);
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		switch (_cellStyle.Alignment)
		{
		case DataGridViewContentAlignment.TopLeft:
		case DataGridViewContentAlignment.MiddleLeft:
		case DataGridViewContentAlignment.BottomLeft:
			return PaletteRelativeAlign.Near;
		case DataGridViewContentAlignment.TopCenter:
		case DataGridViewContentAlignment.MiddleCenter:
		case DataGridViewContentAlignment.BottomCenter:
			return PaletteRelativeAlign.Center;
		case DataGridViewContentAlignment.TopRight:
		case DataGridViewContentAlignment.MiddleRight:
		case DataGridViewContentAlignment.BottomRight:
			return PaletteRelativeAlign.Far;
		default:
			return _inherit.GetContentLongTextH(state);
		}
	}

	public override PaletteRelativeAlign GetContentLongTextV(PaletteState state)
	{
		switch (_cellStyle.Alignment)
		{
		case DataGridViewContentAlignment.TopLeft:
		case DataGridViewContentAlignment.MiddleLeft:
		case DataGridViewContentAlignment.BottomLeft:
			return PaletteRelativeAlign.Near;
		case DataGridViewContentAlignment.TopCenter:
		case DataGridViewContentAlignment.MiddleCenter:
		case DataGridViewContentAlignment.BottomCenter:
			return PaletteRelativeAlign.Center;
		case DataGridViewContentAlignment.TopRight:
		case DataGridViewContentAlignment.MiddleRight:
		case DataGridViewContentAlignment.BottomRight:
			return PaletteRelativeAlign.Far;
		default:
			return _inherit.GetContentLongTextV(state);
		}
	}

	public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state)
	{
		return _inherit.GetContentLongTextMultiLineH(state);
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		return _inherit.GetContentLongTextColor1(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		return _inherit.GetContentLongTextColor2(state);
	}

	public override PaletteColorStyle GetContentLongTextColorStyle(PaletteState state)
	{
		return _inherit.GetContentLongTextColorStyle(state);
	}

	public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state)
	{
		return _inherit.GetContentLongTextColorAlign(state);
	}

	public override float GetContentLongTextColorAngle(PaletteState state)
	{
		return _inherit.GetContentLongTextColorAngle(state);
	}

	public override Image GetContentLongTextImage(PaletteState state)
	{
		return _inherit.GetContentLongTextImage(state);
	}

	public override PaletteImageStyle GetContentLongTextImageStyle(PaletteState state)
	{
		return _inherit.GetContentLongTextImageStyle(state);
	}

	public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state)
	{
		return _inherit.GetContentLongTextImageAlign(state);
	}

	public override Padding GetContentPadding(PaletteState state)
	{
		return _cellStyle.Padding;
	}

	public override int GetContentAdjacentGap(PaletteState state)
	{
		return _inherit.GetContentAdjacentGap(state);
	}

	public override PaletteContentStyle GetContentStyle()
	{
		return _inherit.GetContentStyle();
	}
}

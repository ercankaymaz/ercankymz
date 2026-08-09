#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectGrids : PaletteRedirect
{
	private KryptonPaletteGrid _grid;

	public PaletteRedirectGrids(IPalette target, KryptonPaletteGrid grid)
		: base(target)
	{
		Debug.Assert(grid != null);
		_grid = grid;
	}

	public override InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state)
	{
		return GetInheritBack(style, state)?.GetBackDraw(state) ?? Target.GetBackDraw(style, state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state)
	{
		return GetInheritBack(style, state)?.GetBackGraphicsHint(state) ?? Target.GetBackGraphicsHint(style, state);
	}

	public override Color GetBackColor1(PaletteBackStyle style, PaletteState state)
	{
		return GetInheritBack(style, state)?.GetBackColor1(state) ?? Target.GetBackColor1(style, state);
	}

	public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		return GetInheritBack(style, state)?.GetBackColor2(state) ?? Target.GetBackColor2(style, state);
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetInheritBack(style, state)?.GetBackColorStyle(state) ?? Target.GetBackColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetInheritBack(style, state)?.GetBackColorAlign(state) ?? Target.GetBackColorAlign(style, state);
	}

	public override float GetBackColorAngle(PaletteBackStyle style, PaletteState state)
	{
		return GetInheritBack(style, state)?.GetBackColorAngle(state) ?? Target.GetBackColorAngle(style, state);
	}

	public override Image GetBackImage(PaletteBackStyle style, PaletteState state)
	{
		IPaletteBack inheritBack = GetInheritBack(style, state);
		if (inheritBack != null)
		{
			return inheritBack.GetBackImage(state);
		}
		return Target.GetBackImage(style, state);
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetInheritBack(style, state)?.GetBackImageStyle(state) ?? Target.GetBackImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetInheritBack(style, state)?.GetBackImageAlign(state) ?? Target.GetBackImageAlign(style, state);
	}

	public override InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderDraw(state) ?? Target.GetBorderDraw(style, state);
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderDrawBorders(state) ?? Target.GetBorderDrawBorders(style, state);
	}

	public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderGraphicsHint(state) ?? Target.GetBorderGraphicsHint(style, state);
	}

	public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderColor1(state) ?? Target.GetBorderColor1(style, state);
	}

	public override Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderColor2(state) ?? Target.GetBorderColor2(style, state);
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderColorStyle(state) ?? Target.GetBorderColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderColorAlign(state) ?? Target.GetBorderColorAlign(style, state);
	}

	public override float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderColorAngle(state) ?? Target.GetBorderColorAngle(style, state);
	}

	public override int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderWidth(state) ?? Target.GetBorderWidth(style, state);
	}

	public override int GetBorderRounding(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderRounding(state) ?? Target.GetBorderRounding(style, state);
	}

	public override Image GetBorderImage(PaletteBorderStyle style, PaletteState state)
	{
		IPaletteBorder inheritBorder = GetInheritBorder(style, state);
		if (inheritBorder != null)
		{
			return inheritBorder.GetBorderImage(state);
		}
		return Target.GetBorderImage(style, state);
	}

	public override PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderImageStyle(state) ?? Target.GetBorderImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInheritBorder(style, state)?.GetBorderImageAlign(state) ?? Target.GetBorderImageAlign(style, state);
	}

	public override InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentDraw(state) ?? Target.GetContentDraw(style, state);
	}

	public override InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentDrawFocus(state) ?? Target.GetContentDrawFocus(style, state);
	}

	public override PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentImageH(state) ?? Target.GetContentImageH(style, state);
	}

	public override PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentImageV(state) ?? Target.GetContentImageV(style, state);
	}

	public override PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentImageEffect(state) ?? Target.GetContentImageEffect(style, state);
	}

	public override Font GetContentShortTextFont(PaletteContentStyle style, PaletteState state)
	{
		IPaletteContent inheritContent = GetInheritContent(style, state);
		if (inheritContent != null)
		{
			return inheritContent.GetContentShortTextFont(state);
		}
		return Target.GetContentShortTextFont(style, state);
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextHint(state) ?? Target.GetContentShortTextHint(style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextPrefix(state) ?? Target.GetContentShortTextPrefix(style, state);
	}

	public override InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextMultiLine(state) ?? Target.GetContentShortTextMultiLine(style, state);
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextTrim(state) ?? Target.GetContentShortTextTrim(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextH(state) ?? Target.GetContentShortTextH(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextV(state) ?? Target.GetContentShortTextV(style, state);
	}

	public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextMultiLineH(state) ?? Target.GetContentShortTextMultiLineH(style, state);
	}

	public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextColor1(state) ?? Target.GetContentShortTextColor1(style, state);
	}

	public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextColor2(state) ?? Target.GetContentShortTextColor2(style, state);
	}

	public override PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextColorStyle(state) ?? Target.GetContentShortTextColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextColorAlign(state) ?? Target.GetContentShortTextColorAlign(style, state);
	}

	public override float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextColorAngle(state) ?? Target.GetContentShortTextColorAngle(style, state);
	}

	public override Image GetContentShortTextImage(PaletteContentStyle style, PaletteState state)
	{
		IPaletteContent inheritContent = GetInheritContent(style, state);
		if (inheritContent != null)
		{
			return inheritContent.GetContentShortTextImage(state);
		}
		return Target.GetContentShortTextImage(style, state);
	}

	public override PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextImageStyle(state) ?? Target.GetContentShortTextImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentShortTextImageAlign(state) ?? Target.GetContentShortTextImageAlign(style, state);
	}

	public override Font GetContentLongTextFont(PaletteContentStyle style, PaletteState state)
	{
		IPaletteContent inheritContent = GetInheritContent(style, state);
		if (inheritContent != null)
		{
			return inheritContent.GetContentLongTextFont(state);
		}
		return Target.GetContentLongTextFont(style, state);
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextHint(state) ?? Target.GetContentLongTextHint(style, state);
	}

	public override InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextMultiLine(state) ?? Target.GetContentLongTextMultiLine(style, state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextTrim(state) ?? Target.GetContentLongTextTrim(style, state);
	}

	public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextPrefix(state) ?? Target.GetContentLongTextPrefix(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextH(state) ?? Target.GetContentLongTextH(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextV(state) ?? Target.GetContentLongTextV(style, state);
	}

	public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextMultiLineH(state) ?? Target.GetContentLongTextMultiLineH(style, state);
	}

	public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextColor1(state) ?? Target.GetContentLongTextColor1(style, state);
	}

	public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextColor2(state) ?? Target.GetContentLongTextColor2(style, state);
	}

	public override PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextColorStyle(state) ?? Target.GetContentLongTextColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextColorAlign(state) ?? Target.GetContentLongTextColorAlign(style, state);
	}

	public override float GetContentLongTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextColorAngle(state) ?? Target.GetContentLongTextColorAngle(style, state);
	}

	public override Image GetContentLongTextImage(PaletteContentStyle style, PaletteState state)
	{
		IPaletteContent inheritContent = GetInheritContent(style, state);
		if (inheritContent != null)
		{
			return inheritContent.GetContentLongTextImage(state);
		}
		return Target.GetContentLongTextImage(style, state);
	}

	public override PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextImageStyle(state) ?? Target.GetContentLongTextImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentLongTextImageAlign(state) ?? Target.GetContentLongTextImageAlign(style, state);
	}

	public override Padding GetContentPadding(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentPadding(state) ?? Target.GetContentPadding(style, state);
	}

	public override int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state)
	{
		return GetInheritContent(style, state)?.GetContentAdjacentGap(state) ?? Target.GetContentAdjacentGap(style, state);
	}

	private IPaletteBack GetInheritBack(PaletteBackStyle style, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			switch (style)
			{
			case PaletteBackStyle.GridBackgroundList:
			case PaletteBackStyle.GridBackgroundSheet:
			case PaletteBackStyle.GridBackgroundCustom1:
				return _grid.StateDisabled.Background;
			case PaletteBackStyle.GridDataCellList:
			case PaletteBackStyle.GridDataCellSheet:
			case PaletteBackStyle.GridDataCellCustom1:
				return _grid.StateDisabled.DataCell.Back;
			case PaletteBackStyle.GridHeaderColumnList:
			case PaletteBackStyle.GridHeaderColumnSheet:
			case PaletteBackStyle.GridHeaderColumnCustom1:
				return _grid.StateDisabled.HeaderColumn.Back;
			case PaletteBackStyle.GridHeaderRowList:
			case PaletteBackStyle.GridHeaderRowSheet:
			case PaletteBackStyle.GridHeaderRowCustom1:
				return _grid.StateDisabled.HeaderRow.Back;
			}
			break;
		case PaletteState.Normal:
			switch (style)
			{
			case PaletteBackStyle.GridBackgroundList:
			case PaletteBackStyle.GridBackgroundSheet:
			case PaletteBackStyle.GridBackgroundCustom1:
				return _grid.StateNormal.Background;
			case PaletteBackStyle.GridDataCellList:
			case PaletteBackStyle.GridDataCellSheet:
			case PaletteBackStyle.GridDataCellCustom1:
				return _grid.StateNormal.DataCell.Back;
			case PaletteBackStyle.GridHeaderColumnList:
			case PaletteBackStyle.GridHeaderColumnSheet:
			case PaletteBackStyle.GridHeaderColumnCustom1:
				return _grid.StateNormal.HeaderColumn.Back;
			case PaletteBackStyle.GridHeaderRowList:
			case PaletteBackStyle.GridHeaderRowSheet:
			case PaletteBackStyle.GridHeaderRowCustom1:
				return _grid.StateNormal.HeaderRow.Back;
			}
			break;
		case PaletteState.Pressed:
			switch (style)
			{
			case PaletteBackStyle.GridHeaderColumnList:
			case PaletteBackStyle.GridHeaderColumnSheet:
			case PaletteBackStyle.GridHeaderColumnCustom1:
				return _grid.StatePressed.HeaderColumn.Back;
			case PaletteBackStyle.GridHeaderRowList:
			case PaletteBackStyle.GridHeaderRowSheet:
			case PaletteBackStyle.GridHeaderRowCustom1:
				return _grid.StatePressed.HeaderRow.Back;
			}
			break;
		case PaletteState.Tracking:
			switch (style)
			{
			case PaletteBackStyle.GridHeaderColumnList:
			case PaletteBackStyle.GridHeaderColumnSheet:
			case PaletteBackStyle.GridHeaderColumnCustom1:
				return _grid.StateTracking.HeaderColumn.Back;
			case PaletteBackStyle.GridHeaderRowList:
			case PaletteBackStyle.GridHeaderRowSheet:
			case PaletteBackStyle.GridHeaderRowCustom1:
				return _grid.StateTracking.HeaderRow.Back;
			}
			break;
		case PaletteState.CheckedNormal:
			switch (style)
			{
			case PaletteBackStyle.GridDataCellList:
			case PaletteBackStyle.GridDataCellSheet:
			case PaletteBackStyle.GridDataCellCustom1:
				return _grid.StateSelected.DataCell.Back;
			case PaletteBackStyle.GridHeaderColumnList:
			case PaletteBackStyle.GridHeaderColumnSheet:
			case PaletteBackStyle.GridHeaderColumnCustom1:
				return _grid.StateSelected.HeaderColumn.Back;
			case PaletteBackStyle.GridHeaderRowList:
			case PaletteBackStyle.GridHeaderRowSheet:
			case PaletteBackStyle.GridHeaderRowCustom1:
				return _grid.StateSelected.HeaderRow.Back;
			}
			break;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private IPaletteBorder GetInheritBorder(PaletteBorderStyle style, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			switch (style)
			{
			case PaletteBorderStyle.GridDataCellList:
			case PaletteBorderStyle.GridDataCellSheet:
			case PaletteBorderStyle.GridDataCellCustom1:
				return _grid.StateDisabled.DataCell.Border;
			case PaletteBorderStyle.GridHeaderColumnList:
			case PaletteBorderStyle.GridHeaderColumnSheet:
			case PaletteBorderStyle.GridHeaderColumnCustom1:
				return _grid.StateDisabled.HeaderColumn.Border;
			case PaletteBorderStyle.GridHeaderRowList:
			case PaletteBorderStyle.GridHeaderRowSheet:
			case PaletteBorderStyle.GridHeaderRowCustom1:
				return _grid.StateDisabled.HeaderRow.Border;
			}
			break;
		case PaletteState.Normal:
			switch (style)
			{
			case PaletteBorderStyle.GridDataCellList:
			case PaletteBorderStyle.GridDataCellSheet:
			case PaletteBorderStyle.GridDataCellCustom1:
				return _grid.StateNormal.DataCell.Border;
			case PaletteBorderStyle.GridHeaderColumnList:
			case PaletteBorderStyle.GridHeaderColumnSheet:
			case PaletteBorderStyle.GridHeaderColumnCustom1:
				return _grid.StateNormal.HeaderColumn.Border;
			case PaletteBorderStyle.GridHeaderRowList:
			case PaletteBorderStyle.GridHeaderRowSheet:
			case PaletteBorderStyle.GridHeaderRowCustom1:
				return _grid.StateNormal.HeaderRow.Border;
			}
			break;
		case PaletteState.Pressed:
			switch (style)
			{
			case PaletteBorderStyle.GridHeaderColumnList:
			case PaletteBorderStyle.GridHeaderColumnSheet:
			case PaletteBorderStyle.GridHeaderColumnCustom1:
				return _grid.StatePressed.HeaderColumn.Border;
			case PaletteBorderStyle.GridHeaderRowList:
			case PaletteBorderStyle.GridHeaderRowSheet:
			case PaletteBorderStyle.GridHeaderRowCustom1:
				return _grid.StatePressed.HeaderRow.Border;
			}
			break;
		case PaletteState.Tracking:
			switch (style)
			{
			case PaletteBorderStyle.GridHeaderColumnList:
			case PaletteBorderStyle.GridHeaderColumnSheet:
			case PaletteBorderStyle.GridHeaderColumnCustom1:
				return _grid.StateTracking.HeaderColumn.Border;
			case PaletteBorderStyle.GridHeaderRowList:
			case PaletteBorderStyle.GridHeaderRowSheet:
			case PaletteBorderStyle.GridHeaderRowCustom1:
				return _grid.StateTracking.HeaderRow.Border;
			}
			break;
		case PaletteState.CheckedNormal:
			switch (style)
			{
			case PaletteBorderStyle.GridDataCellList:
			case PaletteBorderStyle.GridDataCellSheet:
			case PaletteBorderStyle.GridDataCellCustom1:
				return _grid.StateSelected.DataCell.Border;
			case PaletteBorderStyle.GridHeaderColumnList:
			case PaletteBorderStyle.GridHeaderColumnSheet:
			case PaletteBorderStyle.GridHeaderColumnCustom1:
				return _grid.StateSelected.HeaderColumn.Border;
			case PaletteBorderStyle.GridHeaderRowList:
			case PaletteBorderStyle.GridHeaderRowSheet:
			case PaletteBorderStyle.GridHeaderRowCustom1:
				return _grid.StateSelected.HeaderRow.Border;
			}
			break;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private IPaletteContent GetInheritContent(PaletteContentStyle style, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			switch (style)
			{
			case PaletteContentStyle.GridDataCellList:
			case PaletteContentStyle.GridDataCellSheet:
			case PaletteContentStyle.GridDataCellCustom1:
				return _grid.StateDisabled.DataCell.Content;
			case PaletteContentStyle.GridHeaderColumnList:
			case PaletteContentStyle.GridHeaderColumnSheet:
			case PaletteContentStyle.GridHeaderColumnCustom1:
				return _grid.StateDisabled.HeaderColumn.Content;
			case PaletteContentStyle.GridHeaderRowList:
			case PaletteContentStyle.GridHeaderRowSheet:
			case PaletteContentStyle.GridHeaderRowCustom1:
				return _grid.StateDisabled.HeaderRow.Content;
			}
			break;
		case PaletteState.Normal:
			switch (style)
			{
			case PaletteContentStyle.GridDataCellList:
			case PaletteContentStyle.GridDataCellSheet:
			case PaletteContentStyle.GridDataCellCustom1:
				return _grid.StateNormal.DataCell.Content;
			case PaletteContentStyle.GridHeaderColumnList:
			case PaletteContentStyle.GridHeaderColumnSheet:
			case PaletteContentStyle.GridHeaderColumnCustom1:
				return _grid.StateNormal.HeaderColumn.Content;
			case PaletteContentStyle.GridHeaderRowList:
			case PaletteContentStyle.GridHeaderRowSheet:
			case PaletteContentStyle.GridHeaderRowCustom1:
				return _grid.StateNormal.HeaderRow.Content;
			}
			break;
		case PaletteState.Pressed:
			switch (style)
			{
			case PaletteContentStyle.GridHeaderColumnList:
			case PaletteContentStyle.GridHeaderColumnSheet:
			case PaletteContentStyle.GridHeaderColumnCustom1:
				return _grid.StatePressed.HeaderColumn.Content;
			case PaletteContentStyle.GridHeaderRowList:
			case PaletteContentStyle.GridHeaderRowSheet:
			case PaletteContentStyle.GridHeaderRowCustom1:
				return _grid.StatePressed.HeaderRow.Content;
			}
			break;
		case PaletteState.Tracking:
			switch (style)
			{
			case PaletteContentStyle.GridHeaderColumnList:
			case PaletteContentStyle.GridHeaderColumnSheet:
			case PaletteContentStyle.GridHeaderColumnCustom1:
				return _grid.StateTracking.HeaderColumn.Content;
			case PaletteContentStyle.GridHeaderRowList:
			case PaletteContentStyle.GridHeaderRowSheet:
			case PaletteContentStyle.GridHeaderRowCustom1:
				return _grid.StateTracking.HeaderRow.Content;
			}
			break;
		case PaletteState.CheckedNormal:
			switch (style)
			{
			case PaletteContentStyle.GridDataCellList:
			case PaletteContentStyle.GridDataCellSheet:
			case PaletteContentStyle.GridDataCellCustom1:
				return _grid.StateSelected.DataCell.Content;
			case PaletteContentStyle.GridHeaderColumnList:
			case PaletteContentStyle.GridHeaderColumnSheet:
			case PaletteContentStyle.GridHeaderColumnCustom1:
				return _grid.StateSelected.HeaderColumn.Content;
			case PaletteContentStyle.GridHeaderRowList:
			case PaletteContentStyle.GridHeaderRowSheet:
			case PaletteContentStyle.GridHeaderRowCustom1:
				return _grid.StateSelected.HeaderRow.Content;
			}
			break;
		}
		Debug.Assert(condition: false);
		return null;
	}
}

#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class CalculatedValues
{
	private static readonly int FONT_HEIGHT_EXTRA = 2;

	private static readonly int DIALOG_MIN_HEIGHT = 14;

	private static readonly int GROUP_LINE_CONTENT_MIN = 18;

	private static readonly int GROUP_LINE_CONTENT_EXTRA = 4;

	private static readonly int GROUP_INSIDE_BOTTOM_GAP = 1;

	private static readonly int GROUP_TOP_BORDER = 2;

	private static readonly int GROUPS_TOP_GAP = 3;

	private static readonly int GROUPS_BOTTOM_GAP = 2;

	private static readonly int TABS_TOP_GAP = 5;

	private static readonly int KEYTIP_HOFFSET = 16;

	private static readonly int KEYTIP_VOFFSET_LINE2 = 1;

	private static readonly int KEYTIP_VOFFSET_LINE4 = 8;

	private static readonly int KEYTIP_VOFFSET_LINE5 = 8;

	private PaletteRibbonShape _lastShape;

	private KryptonRibbon _ribbon;

	private int _rawFontHeight;

	private int _drawFontHeight;

	private int _tabHeight;

	private int _groupTitleHeight;

	private int _groupLineContentHeight;

	private int _groupLineHeight;

	private int _groupLineGapHeight;

	private int _groupTripleHeight;

	private int _groupHeight;

	private int _groupsHeight;

	private int _groupHeightModifier;

	private int _groupsHeightModifier;

	public int RawFontHeight => _rawFontHeight;

	public int DrawFontHeight => _drawFontHeight;

	public int TabHeight => _tabHeight;

	public int GroupTitleHeight => _groupTitleHeight;

	public int GroupLineContentHeight => _groupLineContentHeight;

	public int GroupLineHeight => _groupLineHeight;

	public int GroupLineGapHeight => _groupLineGapHeight;

	public int GroupTripleHeight => _groupTripleHeight;

	public int GroupHeight => _groupHeight;

	public int GroupsHeight => _groupsHeight;

	public CalculatedValues(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_lastShape = PaletteRibbonShape.Inherit;
	}

	public void Recalculate()
	{
		if (_lastShape != _ribbon.RibbonShape)
		{
			_lastShape = _ribbon.RibbonShape;
			PaletteRibbonShape lastShape = _lastShape;
			PaletteRibbonShape paletteRibbonShape = lastShape;
			if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
			{
				_groupHeightModifier = 0;
				_groupsHeightModifier = 0;
			}
			else
			{
				_groupHeightModifier = -3;
				_groupsHeightModifier = -3;
			}
		}
		Font ribbonTextFont = _ribbon.StateCommon.RibbonGeneral.GetRibbonTextFont(PaletteState.Normal);
		_rawFontHeight = ribbonTextFont.Height;
		_drawFontHeight = _rawFontHeight + FONT_HEIGHT_EXTRA;
		_tabHeight = _drawFontHeight + TABS_TOP_GAP;
		_groupTitleHeight = Math.Max(_drawFontHeight, DIALOG_MIN_HEIGHT);
		_groupLineContentHeight = Math.Max(_drawFontHeight, GROUP_LINE_CONTENT_MIN);
		_groupLineHeight = _groupLineContentHeight + GROUP_LINE_CONTENT_EXTRA;
		_groupTripleHeight = _groupLineHeight * 3;
		_groupLineGapHeight = _groupLineHeight / 3;
		_groupHeight = _groupTripleHeight + GROUP_INSIDE_BOTTOM_GAP + _groupTitleHeight + GROUP_TOP_BORDER;
		_groupsHeight = _groupHeight + GROUPS_BOTTOM_GAP + GROUPS_TOP_GAP;
		_groupHeight += _groupHeightModifier;
		_groupsHeight += _groupsHeightModifier;
	}

	public Point KeyTipRectToPoint(Rectangle viewRect, int groupLine)
	{
		Point result;
		switch (groupLine)
		{
		case 1:
			result = new Point(viewRect.Left + KEYTIP_HOFFSET, viewRect.Top);
			break;
		case 2:
			result = new Point(viewRect.Left + KEYTIP_HOFFSET, viewRect.Top + viewRect.Height / 2 + KEYTIP_VOFFSET_LINE2);
			break;
		case 3:
			result = new Point(viewRect.Left + KEYTIP_HOFFSET, viewRect.Bottom);
			break;
		case 4:
			result = new Point(viewRect.Left + KEYTIP_HOFFSET, viewRect.Top - KEYTIP_VOFFSET_LINE4);
			break;
		case 5:
			result = new Point(viewRect.Left + KEYTIP_HOFFSET, viewRect.Bottom + KEYTIP_VOFFSET_LINE5);
			break;
		default:
			Debug.Assert(condition: false);
			result = new Point(viewRect.X, viewRect.Y);
			break;
		}
		return result;
	}
}

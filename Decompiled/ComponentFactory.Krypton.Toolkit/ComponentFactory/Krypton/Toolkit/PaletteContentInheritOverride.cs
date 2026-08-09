#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContentInheritOverride : PaletteContentInherit
{
	private bool _apply;

	private bool _override;

	private PaletteState _state;

	private IPaletteContent _primary;

	private IPaletteContent _backup;

	public bool Apply
	{
		get
		{
			return _apply;
		}
		set
		{
			_apply = value;
		}
	}

	public bool Override
	{
		get
		{
			return _override;
		}
		set
		{
			_override = value;
		}
	}

	public PaletteState OverrideState
	{
		get
		{
			return _state;
		}
		set
		{
			_state = value;
		}
	}

	public PaletteContentInheritOverride(IPaletteContent primary, IPaletteContent backup)
		: this(primary, backup, PaletteState.Normal, apply: true)
	{
	}

	public PaletteContentInheritOverride(IPaletteContent primary, IPaletteContent backup, PaletteState overrideState, bool apply)
	{
		Debug.Assert(primary != null);
		Debug.Assert(backup != null);
		_primary = primary;
		_backup = backup;
		_apply = apply;
		_state = overrideState;
		_override = true;
	}

	public void SetPalettes(IPaletteContent primary, IPaletteContent backup)
	{
		_primary = primary;
		_backup = backup;
	}

	public override InheritBool GetContentDraw(PaletteState state)
	{
		if (_apply)
		{
			InheritBool contentDraw = _primary.GetContentDraw(_override ? _state : state);
			if (contentDraw == InheritBool.Inherit)
			{
				contentDraw = _backup.GetContentDraw(state);
			}
			return contentDraw;
		}
		return _backup.GetContentDraw(state);
	}

	public override InheritBool GetContentDrawFocus(PaletteState state)
	{
		if (_apply)
		{
			InheritBool contentDrawFocus = _primary.GetContentDrawFocus(_override ? _state : state);
			if (contentDrawFocus == InheritBool.Inherit)
			{
				contentDrawFocus = _backup.GetContentDrawFocus(state);
			}
			return contentDrawFocus;
		}
		return _backup.GetContentDrawFocus(state);
	}

	public override PaletteRelativeAlign GetContentImageH(PaletteState state)
	{
		if (_apply)
		{
			PaletteRelativeAlign contentImageH = _primary.GetContentImageH(_override ? _state : state);
			if (contentImageH == PaletteRelativeAlign.Inherit)
			{
				contentImageH = _backup.GetContentImageH(state);
			}
			return contentImageH;
		}
		return _backup.GetContentImageH(state);
	}

	public override PaletteRelativeAlign GetContentImageV(PaletteState state)
	{
		if (_apply)
		{
			PaletteRelativeAlign contentImageV = _primary.GetContentImageV(_override ? _state : state);
			if (contentImageV == PaletteRelativeAlign.Inherit)
			{
				contentImageV = _backup.GetContentImageV(state);
			}
			return contentImageV;
		}
		return _backup.GetContentImageV(state);
	}

	public override PaletteImageEffect GetContentImageEffect(PaletteState state)
	{
		if (_apply)
		{
			PaletteImageEffect contentImageEffect = _primary.GetContentImageEffect(_override ? _state : state);
			if (contentImageEffect == PaletteImageEffect.Inherit)
			{
				contentImageEffect = _backup.GetContentImageEffect(state);
			}
			return contentImageEffect;
		}
		return _backup.GetContentImageEffect(state);
	}

	public override Color GetContentImageColorMap(PaletteState state)
	{
		if (_apply)
		{
			Color contentImageColorMap = _primary.GetContentImageColorMap(_override ? _state : state);
			if (contentImageColorMap == Color.Empty)
			{
				contentImageColorMap = _backup.GetContentImageColorMap(state);
			}
			return contentImageColorMap;
		}
		return _backup.GetContentImageColorMap(state);
	}

	public override Color GetContentImageColorTo(PaletteState state)
	{
		if (_apply)
		{
			Color contentImageColorTo = _primary.GetContentImageColorTo(_override ? _state : state);
			if (contentImageColorTo == Color.Empty)
			{
				contentImageColorTo = _backup.GetContentImageColorTo(state);
			}
			return contentImageColorTo;
		}
		return _backup.GetContentImageColorTo(state);
	}

	public override Font GetContentShortTextFont(PaletteState state)
	{
		if (_apply)
		{
			Font contentShortTextFont = _primary.GetContentShortTextFont(_override ? _state : state);
			if (contentShortTextFont == null)
			{
				contentShortTextFont = _backup.GetContentShortTextFont(state);
			}
			return contentShortTextFont;
		}
		return _backup.GetContentShortTextFont(state);
	}

	public override Font GetContentShortTextNewFont(PaletteState state)
	{
		if (_apply)
		{
			Font contentShortTextNewFont = _primary.GetContentShortTextNewFont(_override ? _state : state);
			if (contentShortTextNewFont == null)
			{
				contentShortTextNewFont = _backup.GetContentShortTextNewFont(state);
			}
			return contentShortTextNewFont;
		}
		return _backup.GetContentShortTextNewFont(state);
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		if (_apply)
		{
			PaletteTextHint contentShortTextHint = _primary.GetContentShortTextHint(_override ? _state : state);
			if (contentShortTextHint == PaletteTextHint.Inherit)
			{
				contentShortTextHint = _backup.GetContentShortTextHint(state);
			}
			return contentShortTextHint;
		}
		return _backup.GetContentShortTextHint(state);
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteState state)
	{
		if (_apply)
		{
			PaletteTextHotkeyPrefix contentShortTextPrefix = _primary.GetContentShortTextPrefix(_override ? _state : state);
			if (contentShortTextPrefix == PaletteTextHotkeyPrefix.Inherit)
			{
				contentShortTextPrefix = _backup.GetContentShortTextPrefix(state);
			}
			return contentShortTextPrefix;
		}
		return _backup.GetContentShortTextPrefix(state);
	}

	public override InheritBool GetContentShortTextMultiLine(PaletteState state)
	{
		if (_apply)
		{
			InheritBool contentShortTextMultiLine = _primary.GetContentShortTextMultiLine(_override ? _state : state);
			if (contentShortTextMultiLine == InheritBool.Inherit)
			{
				contentShortTextMultiLine = _backup.GetContentShortTextMultiLine(state);
			}
			return contentShortTextMultiLine;
		}
		return _backup.GetContentShortTextMultiLine(state);
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		if (_apply)
		{
			PaletteTextTrim contentShortTextTrim = _primary.GetContentShortTextTrim(_override ? _state : state);
			if (contentShortTextTrim == PaletteTextTrim.Inherit)
			{
				contentShortTextTrim = _backup.GetContentShortTextTrim(state);
			}
			return contentShortTextTrim;
		}
		return _backup.GetContentShortTextTrim(state);
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		if (_apply)
		{
			PaletteRelativeAlign contentShortTextH = _primary.GetContentShortTextH(_override ? _state : state);
			if (contentShortTextH == PaletteRelativeAlign.Inherit)
			{
				contentShortTextH = _backup.GetContentShortTextH(state);
			}
			return contentShortTextH;
		}
		return _backup.GetContentShortTextH(state);
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		if (_apply)
		{
			PaletteRelativeAlign contentShortTextV = _primary.GetContentShortTextV(_override ? _state : state);
			if (contentShortTextV == PaletteRelativeAlign.Inherit)
			{
				contentShortTextV = _backup.GetContentShortTextV(state);
			}
			return contentShortTextV;
		}
		return _backup.GetContentShortTextV(state);
	}

	public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteState state)
	{
		if (_apply)
		{
			PaletteRelativeAlign contentShortTextMultiLineH = _primary.GetContentShortTextMultiLineH(_override ? _state : state);
			if (contentShortTextMultiLineH == PaletteRelativeAlign.Inherit)
			{
				contentShortTextMultiLineH = _backup.GetContentShortTextMultiLineH(state);
			}
			return contentShortTextMultiLineH;
		}
		return _backup.GetContentShortTextMultiLineH(state);
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		if (_apply)
		{
			Color contentShortTextColor = _primary.GetContentShortTextColor1(_override ? _state : state);
			if (contentShortTextColor == Color.Empty)
			{
				contentShortTextColor = _backup.GetContentShortTextColor1(state);
			}
			return contentShortTextColor;
		}
		return _backup.GetContentShortTextColor1(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		if (_apply)
		{
			Color contentShortTextColor = _primary.GetContentShortTextColor2(_override ? _state : state);
			if (contentShortTextColor == Color.Empty)
			{
				contentShortTextColor = _backup.GetContentShortTextColor2(state);
			}
			return contentShortTextColor;
		}
		return _backup.GetContentShortTextColor2(state);
	}

	public override PaletteColorStyle GetContentShortTextColorStyle(PaletteState state)
	{
		if (_apply)
		{
			PaletteColorStyle contentShortTextColorStyle = _primary.GetContentShortTextColorStyle(_override ? _state : state);
			if (contentShortTextColorStyle == PaletteColorStyle.Inherit)
			{
				contentShortTextColorStyle = _backup.GetContentShortTextColorStyle(state);
			}
			return contentShortTextColorStyle;
		}
		return _backup.GetContentShortTextColorStyle(state);
	}

	public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteState state)
	{
		if (_apply)
		{
			PaletteRectangleAlign contentShortTextColorAlign = _primary.GetContentShortTextColorAlign(_override ? _state : state);
			if (contentShortTextColorAlign == PaletteRectangleAlign.Inherit)
			{
				contentShortTextColorAlign = _backup.GetContentShortTextColorAlign(state);
			}
			return contentShortTextColorAlign;
		}
		return _backup.GetContentShortTextColorAlign(state);
	}

	public override float GetContentShortTextColorAngle(PaletteState state)
	{
		if (_apply)
		{
			float contentShortTextColorAngle = _primary.GetContentShortTextColorAngle(_override ? _state : state);
			if (contentShortTextColorAngle == -1f)
			{
				contentShortTextColorAngle = _backup.GetContentShortTextColorAngle(state);
			}
			return contentShortTextColorAngle;
		}
		return _backup.GetContentShortTextColorAngle(state);
	}

	public override Image GetContentShortTextImage(PaletteState state)
	{
		if (_apply)
		{
			Image contentShortTextImage = _primary.GetContentShortTextImage(_override ? _state : state);
			if (contentShortTextImage == null)
			{
				contentShortTextImage = _backup.GetContentShortTextImage(state);
			}
			return contentShortTextImage;
		}
		return _backup.GetContentShortTextImage(state);
	}

	public override PaletteImageStyle GetContentShortTextImageStyle(PaletteState state)
	{
		if (_apply)
		{
			PaletteImageStyle contentShortTextImageStyle = _primary.GetContentShortTextImageStyle(_override ? _state : state);
			if (contentShortTextImageStyle == PaletteImageStyle.Inherit)
			{
				contentShortTextImageStyle = _backup.GetContentShortTextImageStyle(state);
			}
			return contentShortTextImageStyle;
		}
		return _backup.GetContentShortTextImageStyle(state);
	}

	public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteState state)
	{
		if (_apply)
		{
			PaletteRectangleAlign contentShortTextImageAlign = _primary.GetContentShortTextImageAlign(_override ? _state : state);
			if (contentShortTextImageAlign == PaletteRectangleAlign.Inherit)
			{
				contentShortTextImageAlign = _backup.GetContentShortTextImageAlign(state);
			}
			return contentShortTextImageAlign;
		}
		return _backup.GetContentShortTextImageAlign(state);
	}

	public override Font GetContentLongTextFont(PaletteState state)
	{
		if (_apply)
		{
			Font contentLongTextFont = _primary.GetContentLongTextFont(_override ? _state : state);
			if (contentLongTextFont == null)
			{
				contentLongTextFont = _backup.GetContentLongTextFont(state);
			}
			return contentLongTextFont;
		}
		return _backup.GetContentLongTextFont(state);
	}

	public override Font GetContentLongTextNewFont(PaletteState state)
	{
		if (_apply)
		{
			Font contentLongTextNewFont = _primary.GetContentLongTextNewFont(_override ? _state : state);
			if (contentLongTextNewFont == null)
			{
				contentLongTextNewFont = _backup.GetContentLongTextNewFont(state);
			}
			return contentLongTextNewFont;
		}
		return _backup.GetContentLongTextNewFont(state);
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		if (_apply)
		{
			PaletteTextHint contentLongTextHint = _primary.GetContentLongTextHint(_override ? _state : state);
			if (contentLongTextHint == PaletteTextHint.Inherit)
			{
				contentLongTextHint = _backup.GetContentLongTextHint(state);
			}
			return contentLongTextHint;
		}
		return _backup.GetContentLongTextHint(state);
	}

	public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteState state)
	{
		if (_apply)
		{
			PaletteTextHotkeyPrefix contentLongTextPrefix = _primary.GetContentLongTextPrefix(_override ? _state : state);
			if (contentLongTextPrefix == PaletteTextHotkeyPrefix.Inherit)
			{
				contentLongTextPrefix = _backup.GetContentLongTextPrefix(state);
			}
			return contentLongTextPrefix;
		}
		return _backup.GetContentLongTextPrefix(state);
	}

	public override InheritBool GetContentLongTextMultiLine(PaletteState state)
	{
		if (_apply)
		{
			InheritBool contentLongTextMultiLine = _primary.GetContentLongTextMultiLine(_override ? _state : state);
			if (contentLongTextMultiLine == InheritBool.Inherit)
			{
				contentLongTextMultiLine = _backup.GetContentLongTextMultiLine(state);
			}
			return contentLongTextMultiLine;
		}
		return _backup.GetContentLongTextMultiLine(state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		if (_apply)
		{
			PaletteTextTrim contentLongTextTrim = _primary.GetContentLongTextTrim(_override ? _state : state);
			if (contentLongTextTrim == PaletteTextTrim.Inherit)
			{
				contentLongTextTrim = _backup.GetContentLongTextTrim(state);
			}
			return contentLongTextTrim;
		}
		return _backup.GetContentLongTextTrim(state);
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteState state)
	{
		if (_apply)
		{
			PaletteRelativeAlign contentLongTextH = _primary.GetContentLongTextH(_override ? _state : state);
			if (contentLongTextH == PaletteRelativeAlign.Inherit)
			{
				contentLongTextH = _backup.GetContentLongTextH(state);
			}
			return contentLongTextH;
		}
		return _backup.GetContentLongTextH(state);
	}

	public override PaletteRelativeAlign GetContentLongTextV(PaletteState state)
	{
		if (_apply)
		{
			PaletteRelativeAlign contentLongTextV = _primary.GetContentLongTextV(_override ? _state : state);
			if (contentLongTextV == PaletteRelativeAlign.Inherit)
			{
				contentLongTextV = _backup.GetContentLongTextV(state);
			}
			return contentLongTextV;
		}
		return _backup.GetContentLongTextV(state);
	}

	public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteState state)
	{
		if (_apply)
		{
			PaletteRelativeAlign contentLongTextMultiLineH = _primary.GetContentLongTextMultiLineH(_override ? _state : state);
			if (contentLongTextMultiLineH == PaletteRelativeAlign.Inherit)
			{
				contentLongTextMultiLineH = _backup.GetContentLongTextMultiLineH(state);
			}
			return contentLongTextMultiLineH;
		}
		return _backup.GetContentLongTextMultiLineH(state);
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		if (_apply)
		{
			Color contentLongTextColor = _primary.GetContentLongTextColor1(_override ? _state : state);
			if (contentLongTextColor == Color.Empty)
			{
				contentLongTextColor = _backup.GetContentLongTextColor1(state);
			}
			return contentLongTextColor;
		}
		return _backup.GetContentLongTextColor1(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		if (_apply)
		{
			Color contentLongTextColor = _primary.GetContentLongTextColor2(_override ? _state : state);
			if (contentLongTextColor == Color.Empty)
			{
				contentLongTextColor = _backup.GetContentLongTextColor2(state);
			}
			return contentLongTextColor;
		}
		return _backup.GetContentLongTextColor2(state);
	}

	public override PaletteColorStyle GetContentLongTextColorStyle(PaletteState state)
	{
		if (_apply)
		{
			PaletteColorStyle contentLongTextColorStyle = _primary.GetContentLongTextColorStyle(_override ? _state : state);
			if (contentLongTextColorStyle == PaletteColorStyle.Inherit)
			{
				contentLongTextColorStyle = _backup.GetContentLongTextColorStyle(state);
			}
			return contentLongTextColorStyle;
		}
		return _backup.GetContentLongTextColorStyle(state);
	}

	public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteState state)
	{
		if (_apply)
		{
			PaletteRectangleAlign contentLongTextColorAlign = _primary.GetContentLongTextColorAlign(_override ? _state : state);
			if (contentLongTextColorAlign == PaletteRectangleAlign.Inherit)
			{
				contentLongTextColorAlign = _backup.GetContentLongTextColorAlign(state);
			}
			return contentLongTextColorAlign;
		}
		return _backup.GetContentLongTextColorAlign(state);
	}

	public override float GetContentLongTextColorAngle(PaletteState state)
	{
		if (_apply)
		{
			float contentLongTextColorAngle = _primary.GetContentLongTextColorAngle(_override ? _state : state);
			if (contentLongTextColorAngle == -1f)
			{
				contentLongTextColorAngle = _backup.GetContentLongTextColorAngle(state);
			}
			return contentLongTextColorAngle;
		}
		return _backup.GetContentLongTextColorAngle(state);
	}

	public override Image GetContentLongTextImage(PaletteState state)
	{
		if (_apply)
		{
			Image contentLongTextImage = _primary.GetContentLongTextImage(_override ? _state : state);
			if (contentLongTextImage == null)
			{
				contentLongTextImage = _backup.GetContentLongTextImage(state);
			}
			return contentLongTextImage;
		}
		return _backup.GetContentLongTextImage(state);
	}

	public override PaletteImageStyle GetContentLongTextImageStyle(PaletteState state)
	{
		if (_apply)
		{
			PaletteImageStyle contentLongTextImageStyle = _primary.GetContentLongTextImageStyle(_override ? _state : state);
			if (contentLongTextImageStyle == PaletteImageStyle.Inherit)
			{
				contentLongTextImageStyle = _backup.GetContentLongTextImageStyle(state);
			}
			return contentLongTextImageStyle;
		}
		return _backup.GetContentLongTextImageStyle(state);
	}

	public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteState state)
	{
		if (_apply)
		{
			PaletteRectangleAlign contentLongTextImageAlign = _primary.GetContentLongTextImageAlign(_override ? _state : state);
			if (contentLongTextImageAlign == PaletteRectangleAlign.Inherit)
			{
				contentLongTextImageAlign = _backup.GetContentLongTextImageAlign(state);
			}
			return contentLongTextImageAlign;
		}
		return _backup.GetContentLongTextImageAlign(state);
	}

	public override Padding GetContentPadding(PaletteState state)
	{
		if (_apply)
		{
			Padding contentPadding = _primary.GetContentPadding(_override ? _state : state);
			if (contentPadding.All == -1)
			{
				contentPadding = _backup.GetContentPadding(state);
			}
			return contentPadding;
		}
		return _backup.GetContentPadding(state);
	}

	public override int GetContentAdjacentGap(PaletteState state)
	{
		if (_apply)
		{
			int contentAdjacentGap = _primary.GetContentAdjacentGap(_override ? _state : state);
			if (contentAdjacentGap == -1)
			{
				contentAdjacentGap = _backup.GetContentAdjacentGap(state);
			}
			return contentAdjacentGap;
		}
		return _backup.GetContentAdjacentGap(state);
	}

	public override PaletteContentStyle GetContentStyle()
	{
		if (_apply)
		{
			return _primary.GetContentStyle();
		}
		return _backup.GetContentStyle();
	}
}

#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBackInheritOverride : PaletteBackInherit
{
	private bool _apply;

	private bool _override;

	private PaletteState _state;

	private IPaletteBack _primary;

	private IPaletteBack _backup;

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

	public PaletteBackInheritOverride(IPaletteBack primary, IPaletteBack backup)
	{
		Debug.Assert(primary != null);
		Debug.Assert(backup != null);
		_primary = primary;
		_backup = backup;
		_apply = true;
		_override = true;
		_state = PaletteState.Normal;
	}

	public void SetPalettes(IPaletteBack primary, IPaletteBack backup)
	{
		_primary = primary;
		_backup = backup;
	}

	public override InheritBool GetBackDraw(PaletteState state)
	{
		if (_apply)
		{
			InheritBool backDraw = _primary.GetBackDraw(_override ? _state : state);
			if (backDraw == InheritBool.Inherit)
			{
				backDraw = _backup.GetBackDraw(state);
			}
			return backDraw;
		}
		return _backup.GetBackDraw(state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		if (_apply)
		{
			PaletteGraphicsHint backGraphicsHint = _primary.GetBackGraphicsHint(_override ? _state : state);
			if (backGraphicsHint == PaletteGraphicsHint.Inherit)
			{
				backGraphicsHint = _backup.GetBackGraphicsHint(state);
			}
			return backGraphicsHint;
		}
		return _backup.GetBackGraphicsHint(state);
	}

	public override Color GetBackColor1(PaletteState state)
	{
		if (_apply)
		{
			Color backColor = _primary.GetBackColor1(_override ? _state : state);
			if (backColor == Color.Empty)
			{
				backColor = _backup.GetBackColor1(state);
			}
			return backColor;
		}
		return _backup.GetBackColor1(state);
	}

	public override Color GetBackColor2(PaletteState state)
	{
		if (_apply)
		{
			Color backColor = _primary.GetBackColor2(_override ? _state : state);
			if (backColor == Color.Empty)
			{
				backColor = _backup.GetBackColor2(state);
			}
			return backColor;
		}
		return _backup.GetBackColor2(state);
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteState state)
	{
		if (_apply)
		{
			PaletteColorStyle backColorStyle = _primary.GetBackColorStyle(_override ? _state : state);
			if (backColorStyle == PaletteColorStyle.Inherit)
			{
				backColorStyle = _backup.GetBackColorStyle(state);
			}
			return backColorStyle;
		}
		return _backup.GetBackColorStyle(state);
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteState state)
	{
		if (_apply)
		{
			PaletteRectangleAlign backColorAlign = _primary.GetBackColorAlign(_override ? _state : state);
			if (backColorAlign == PaletteRectangleAlign.Inherit)
			{
				backColorAlign = _backup.GetBackColorAlign(state);
			}
			return backColorAlign;
		}
		return _backup.GetBackColorAlign(state);
	}

	public override float GetBackColorAngle(PaletteState state)
	{
		if (_apply)
		{
			float backColorAngle = _primary.GetBackColorAngle(_override ? _state : state);
			if (backColorAngle == -1f)
			{
				backColorAngle = _backup.GetBackColorAngle(state);
			}
			return backColorAngle;
		}
		return _backup.GetBackColorAngle(state);
	}

	public override Image GetBackImage(PaletteState state)
	{
		if (_apply)
		{
			Image backImage = _primary.GetBackImage(_override ? _state : state);
			if (backImage == null)
			{
				backImage = _backup.GetBackImage(state);
			}
			return backImage;
		}
		return _backup.GetBackImage(state);
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteState state)
	{
		if (_apply)
		{
			PaletteImageStyle backImageStyle = _primary.GetBackImageStyle(_override ? _state : state);
			if (backImageStyle == PaletteImageStyle.Inherit)
			{
				backImageStyle = _backup.GetBackImageStyle(state);
			}
			return backImageStyle;
		}
		return _backup.GetBackImageStyle(state);
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteState state)
	{
		if (_apply)
		{
			PaletteRectangleAlign backImageAlign = _primary.GetBackImageAlign(_override ? _state : state);
			if (backImageAlign == PaletteRectangleAlign.Inherit)
			{
				backImageAlign = _backup.GetBackImageAlign(state);
			}
			return backImageAlign;
		}
		return _backup.GetBackImageAlign(state);
	}
}

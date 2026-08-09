#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBorderInheritOverride : PaletteBorderInherit
{
	private bool _apply;

	private bool _override;

	private PaletteState _state;

	private IPaletteBorder _primary;

	private IPaletteBorder _backup;

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

	public PaletteBorderInheritOverride(IPaletteBorder primary, IPaletteBorder backup)
	{
		Debug.Assert(primary != null);
		Debug.Assert(backup != null);
		_primary = primary;
		_backup = backup;
		_apply = true;
		_override = true;
		_state = PaletteState.Normal;
	}

	public void SetPalettes(IPaletteBorder primary, IPaletteBorder backup)
	{
		_primary = primary;
		_backup = backup;
	}

	public override InheritBool GetBorderDraw(PaletteState state)
	{
		if (_apply)
		{
			InheritBool borderDraw = _primary.GetBorderDraw(_override ? _state : state);
			if (borderDraw == InheritBool.Inherit)
			{
				borderDraw = _backup.GetBorderDraw(state);
			}
			return borderDraw;
		}
		return _backup.GetBorderDraw(state);
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteState state)
	{
		if (_apply)
		{
			PaletteDrawBorders borderDrawBorders = _primary.GetBorderDrawBorders(_override ? _state : state);
			if (borderDrawBorders == PaletteDrawBorders.Inherit)
			{
				borderDrawBorders = _backup.GetBorderDrawBorders(state);
			}
			return borderDrawBorders;
		}
		return _backup.GetBorderDrawBorders(state);
	}

	public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state)
	{
		if (_apply)
		{
			PaletteGraphicsHint borderGraphicsHint = _primary.GetBorderGraphicsHint(_override ? _state : state);
			if (borderGraphicsHint == PaletteGraphicsHint.Inherit)
			{
				borderGraphicsHint = _backup.GetBorderGraphicsHint(state);
			}
			return borderGraphicsHint;
		}
		return _backup.GetBorderGraphicsHint(state);
	}

	public override Color GetBorderColor1(PaletteState state)
	{
		if (_apply)
		{
			Color borderColor = _primary.GetBorderColor1(_override ? _state : state);
			if (borderColor == Color.Empty)
			{
				borderColor = _backup.GetBorderColor1(state);
			}
			return borderColor;
		}
		return _backup.GetBorderColor1(state);
	}

	public override Color GetBorderColor2(PaletteState state)
	{
		if (_apply)
		{
			Color borderColor = _primary.GetBorderColor2(_override ? _state : state);
			if (borderColor == Color.Empty)
			{
				borderColor = _backup.GetBorderColor2(state);
			}
			return borderColor;
		}
		return _backup.GetBorderColor2(state);
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteState state)
	{
		if (_apply)
		{
			PaletteColorStyle borderColorStyle = _primary.GetBorderColorStyle(_override ? _state : state);
			if (borderColorStyle == PaletteColorStyle.Inherit)
			{
				borderColorStyle = _backup.GetBorderColorStyle(state);
			}
			return borderColorStyle;
		}
		return _backup.GetBorderColorStyle(state);
	}

	public override PaletteRectangleAlign GetBorderColorAlign(PaletteState state)
	{
		if (_apply)
		{
			PaletteRectangleAlign borderColorAlign = _primary.GetBorderColorAlign(_override ? _state : state);
			if (borderColorAlign == PaletteRectangleAlign.Inherit)
			{
				borderColorAlign = _backup.GetBorderColorAlign(state);
			}
			return borderColorAlign;
		}
		return _backup.GetBorderColorAlign(state);
	}

	public override float GetBorderColorAngle(PaletteState state)
	{
		if (_apply)
		{
			float borderColorAngle = _primary.GetBorderColorAngle(_override ? _state : state);
			if (borderColorAngle == -1f)
			{
				borderColorAngle = _backup.GetBorderColorAngle(state);
			}
			return borderColorAngle;
		}
		return _backup.GetBorderColorAngle(state);
	}

	public override int GetBorderWidth(PaletteState state)
	{
		if (_apply)
		{
			int borderWidth = _primary.GetBorderWidth(_override ? _state : state);
			if (borderWidth == -1)
			{
				borderWidth = _backup.GetBorderWidth(state);
			}
			return borderWidth;
		}
		return _backup.GetBorderWidth(state);
	}

	public override int GetBorderRounding(PaletteState state)
	{
		if (_apply)
		{
			int borderRounding = _primary.GetBorderRounding(_override ? _state : state);
			if (borderRounding == -1)
			{
				borderRounding = _backup.GetBorderRounding(state);
			}
			return borderRounding;
		}
		return _backup.GetBorderRounding(state);
	}

	public override Image GetBorderImage(PaletteState state)
	{
		if (_apply)
		{
			Image borderImage = _primary.GetBorderImage(_override ? _state : state);
			if (borderImage == null)
			{
				borderImage = _backup.GetBorderImage(state);
			}
			return borderImage;
		}
		return _backup.GetBorderImage(state);
	}

	public override PaletteImageStyle GetBorderImageStyle(PaletteState state)
	{
		if (_apply)
		{
			PaletteImageStyle borderImageStyle = _primary.GetBorderImageStyle(_override ? _state : state);
			if (borderImageStyle == PaletteImageStyle.Inherit)
			{
				borderImageStyle = _backup.GetBorderImageStyle(state);
			}
			return borderImageStyle;
		}
		return _backup.GetBorderImageStyle(state);
	}

	public override PaletteRectangleAlign GetBorderImageAlign(PaletteState state)
	{
		if (_apply)
		{
			PaletteRectangleAlign borderImageAlign = _primary.GetBorderImageAlign(_override ? _state : state);
			if (borderImageAlign == PaletteRectangleAlign.Inherit)
			{
				borderImageAlign = _backup.GetBorderImageAlign(state);
			}
			return borderImageAlign;
		}
		return _backup.GetBorderImageAlign(state);
	}
}

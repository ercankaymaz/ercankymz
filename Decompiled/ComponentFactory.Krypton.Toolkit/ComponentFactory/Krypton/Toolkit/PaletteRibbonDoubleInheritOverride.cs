#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRibbonDoubleInheritOverride : PaletteRibbonDoubleInherit
{
	private bool _apply;

	private bool _override;

	private PaletteState _state;

	private IPaletteRibbonBack _primaryBack;

	private IPaletteRibbonBack _backupBack;

	private IPaletteRibbonText _primaryText;

	private IPaletteRibbonText _backupText;

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

	public PaletteRibbonDoubleInheritOverride(IPaletteRibbonBack primaryBack, IPaletteRibbonText primaryText, IPaletteRibbonBack backupBack, IPaletteRibbonText backupText, PaletteState state)
	{
		Debug.Assert(primaryBack != null);
		Debug.Assert(primaryText != null);
		Debug.Assert(backupBack != null);
		Debug.Assert(backupText != null);
		_primaryBack = primaryBack;
		_primaryText = primaryText;
		_backupBack = backupBack;
		_backupText = backupText;
		_apply = false;
		_override = true;
		_state = state;
	}

	public override PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteState state)
	{
		if (_apply)
		{
			PaletteRibbonColorStyle ribbonBackColorStyle = _primaryBack.GetRibbonBackColorStyle(_override ? _state : state);
			if (ribbonBackColorStyle == PaletteRibbonColorStyle.Inherit)
			{
				ribbonBackColorStyle = _backupBack.GetRibbonBackColorStyle(state);
			}
			return ribbonBackColorStyle;
		}
		return _backupBack.GetRibbonBackColorStyle(state);
	}

	public override Color GetRibbonBackColor1(PaletteState state)
	{
		if (_apply)
		{
			Color ribbonBackColor = _primaryBack.GetRibbonBackColor1(_override ? _state : state);
			if (ribbonBackColor == Color.Empty)
			{
				ribbonBackColor = _backupBack.GetRibbonBackColor1(state);
			}
			return ribbonBackColor;
		}
		return _backupBack.GetRibbonBackColor1(state);
	}

	public override Color GetRibbonBackColor2(PaletteState state)
	{
		if (_apply)
		{
			Color ribbonBackColor = _primaryBack.GetRibbonBackColor2(_override ? _state : state);
			if (ribbonBackColor == Color.Empty)
			{
				ribbonBackColor = _backupBack.GetRibbonBackColor2(state);
			}
			return ribbonBackColor;
		}
		return _backupBack.GetRibbonBackColor2(state);
	}

	public override Color GetRibbonBackColor3(PaletteState state)
	{
		if (_apply)
		{
			Color ribbonBackColor = _primaryBack.GetRibbonBackColor3(_override ? _state : state);
			if (ribbonBackColor == Color.Empty)
			{
				ribbonBackColor = _backupBack.GetRibbonBackColor3(state);
			}
			return ribbonBackColor;
		}
		return _backupBack.GetRibbonBackColor3(state);
	}

	public override Color GetRibbonBackColor4(PaletteState state)
	{
		if (_apply)
		{
			Color ribbonBackColor = _primaryBack.GetRibbonBackColor4(_override ? _state : state);
			if (ribbonBackColor == Color.Empty)
			{
				ribbonBackColor = _backupBack.GetRibbonBackColor4(state);
			}
			return ribbonBackColor;
		}
		return _backupBack.GetRibbonBackColor4(state);
	}

	public override Color GetRibbonBackColor5(PaletteState state)
	{
		if (_apply)
		{
			Color ribbonBackColor = _primaryBack.GetRibbonBackColor5(_override ? _state : state);
			if (ribbonBackColor == Color.Empty)
			{
				ribbonBackColor = _backupBack.GetRibbonBackColor5(state);
			}
			return ribbonBackColor;
		}
		return _backupBack.GetRibbonBackColor5(state);
	}

	public override Color GetRibbonTextColor(PaletteState state)
	{
		if (_apply)
		{
			Color ribbonTextColor = _primaryText.GetRibbonTextColor(_override ? _state : state);
			if (ribbonTextColor == Color.Empty)
			{
				ribbonTextColor = _backupText.GetRibbonTextColor(state);
			}
			return ribbonTextColor;
		}
		return _backupText.GetRibbonTextColor(state);
	}
}

#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteElementColorInheritOverride : PaletteElementColorInherit
{
	private bool _apply;

	private bool _override;

	private PaletteState _state;

	private IPaletteElementColor _primary;

	private IPaletteElementColor _backup;

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

	public PaletteElementColorInheritOverride(IPaletteElementColor primary, IPaletteElementColor backup)
	{
		Debug.Assert(primary != null);
		Debug.Assert(backup != null);
		_primary = primary;
		_backup = backup;
		_apply = true;
		_override = true;
		_state = PaletteState.Normal;
	}

	public void SetPalettes(IPaletteElementColor primary, IPaletteElementColor backup)
	{
		_primary = primary;
		_backup = backup;
	}

	public override Color GetElementColor1(PaletteState state)
	{
		if (_apply)
		{
			Color elementColor = _primary.GetElementColor1(_override ? _state : state);
			if (elementColor == Color.Empty)
			{
				elementColor = _backup.GetElementColor1(state);
			}
			return elementColor;
		}
		return _backup.GetElementColor1(state);
	}

	public override Color GetElementColor2(PaletteState state)
	{
		if (_apply)
		{
			Color elementColor = _primary.GetElementColor2(_override ? _state : state);
			if (elementColor == Color.Empty)
			{
				elementColor = _backup.GetElementColor2(state);
			}
			return elementColor;
		}
		return _backup.GetElementColor2(state);
	}

	public override Color GetElementColor3(PaletteState state)
	{
		if (_apply)
		{
			Color elementColor = _primary.GetElementColor3(_override ? _state : state);
			if (elementColor == Color.Empty)
			{
				elementColor = _backup.GetElementColor3(state);
			}
			return elementColor;
		}
		return _backup.GetElementColor3(state);
	}

	public override Color GetElementColor4(PaletteState state)
	{
		if (_apply)
		{
			Color elementColor = _primary.GetElementColor4(_override ? _state : state);
			if (elementColor == Color.Empty)
			{
				elementColor = _backup.GetElementColor4(state);
			}
			return elementColor;
		}
		return _backup.GetElementColor4(state);
	}

	public override Color GetElementColor5(PaletteState state)
	{
		if (_apply)
		{
			Color elementColor = _primary.GetElementColor5(_override ? _state : state);
			if (elementColor == Color.Empty)
			{
				elementColor = _backup.GetElementColor5(state);
			}
			return elementColor;
		}
		return _backup.GetElementColor5(state);
	}
}

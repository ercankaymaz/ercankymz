using System.Windows.Forms;
using devDept.Eyeshot.Control;

internal sealed class _0023_003DzoFrj_j4xP7LR4PzpMFSwbLcZc_0024wi
{
	public int _0023_003DzP2rgSdKF4mfb;

	private bool[] _0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D;

	private bool[] _0023_003Dz8fhrV4UQDr2wMF0RWQ_003D_003D;

	public _0023_003DzoFrj_j4xP7LR4PzpMFSwbLcZc_0024wi()
	{
		_0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D = new bool[259];
		_0023_003Dz8fhrV4UQDr2wMF0RWQ_003D_003D = new bool[259];
	}

	public bool _0023_003DzETD8ckar3LuB(Keys _0023_003DzchTpoW0_003D)
	{
		if (_0023_003DzsV4VrnyKh2WN(_0023_003DzchTpoW0_003D))
		{
			return false;
		}
		if (_0023_003DzchTpoW0_003D == Keys.None)
		{
			return true;
		}
		return _0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[(int)_0023_003DzchTpoW0_003D];
	}

	public void _0023_003DzGFXEo09621gi(Keys _0023_003DzchTpoW0_003D, Keys _0023_003DzdL4RD84_003D)
	{
		if (!_0023_003DzsV4VrnyKh2WN(_0023_003DzchTpoW0_003D) && (!_0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[(int)_0023_003DzchTpoW0_003D] || !_0023_003DzznhADp4uitmH(_0023_003DzdL4RD84_003D)))
		{
			_0023_003Dz8fhrV4UQDr2wMF0RWQ_003D_003D[(int)_0023_003DzchTpoW0_003D] = _0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[(int)_0023_003DzchTpoW0_003D];
			_0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[(int)_0023_003DzchTpoW0_003D] = true;
			_0023_003Dzbq3xszLKRWPL(_0023_003DzdL4RD84_003D, _0023_003Dz_H763Oc_003D: true);
		}
	}

	private void _0023_003Dzbq3xszLKRWPL(Keys _0023_003DzdL4RD84_003D, bool _0023_003Dz_H763Oc_003D)
	{
		if (_0023_003Dz_H763Oc_003D)
		{
			_0023_003DzYf2MhSwHqFdW(_0023_003DzdL4RD84_003D, Keys.Alt);
			_0023_003DzYf2MhSwHqFdW(_0023_003DzdL4RD84_003D, Keys.Shift);
			_0023_003DzYf2MhSwHqFdW(_0023_003DzdL4RD84_003D, Keys.Control);
		}
		else
		{
			_0023_003Dz3z5x6CfEgxSrSwVG_g_003D_003D(Keys.Alt, _0023_003Dz_H763Oc_003D: false);
			_0023_003Dz3z5x6CfEgxSrSwVG_g_003D_003D(Keys.Shift, _0023_003Dz_H763Oc_003D: false);
			_0023_003Dz3z5x6CfEgxSrSwVG_g_003D_003D(Keys.Control, _0023_003Dz_H763Oc_003D: false);
		}
	}

	private void _0023_003DzYf2MhSwHqFdW(Keys _0023_003DzhDQm_0024HY_003D, Keys _0023_003DzAbAO3f4_003D)
	{
		if ((_0023_003DzhDQm_0024HY_003D & _0023_003DzAbAO3f4_003D) == _0023_003DzAbAO3f4_003D)
		{
			_0023_003Dz3z5x6CfEgxSrSwVG_g_003D_003D(_0023_003DzAbAO3f4_003D, _0023_003Dz_H763Oc_003D: true);
		}
	}

	private void _0023_003Dz3z5x6CfEgxSrSwVG_g_003D_003D(Keys _0023_003DzAbAO3f4_003D, bool _0023_003Dz_H763Oc_003D)
	{
		int num = _0023_003DzjNNtK4EOlMYJ(_0023_003DzAbAO3f4_003D);
		_0023_003Dz8fhrV4UQDr2wMF0RWQ_003D_003D[num] = _0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[num];
		_0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[num] = _0023_003Dz_H763Oc_003D;
	}

	private bool _0023_003DzznhADp4uitmH(Keys _0023_003DzdL4RD84_003D)
	{
		if (!_0023_003DzPvql0WUvFXYk(_0023_003DzdL4RD84_003D, Keys.Control))
		{
			return false;
		}
		if (!_0023_003DzPvql0WUvFXYk(_0023_003DzdL4RD84_003D, Keys.Shift))
		{
			return false;
		}
		if (!_0023_003DzPvql0WUvFXYk(_0023_003DzdL4RD84_003D, Keys.Alt))
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzPvql0WUvFXYk(Keys _0023_003DzhDQm_0024HY_003D, Keys _0023_003DzAbAO3f4_003D)
	{
		if ((_0023_003DzhDQm_0024HY_003D & _0023_003DzAbAO3f4_003D) == _0023_003DzAbAO3f4_003D)
		{
			return _0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[_0023_003DzjNNtK4EOlMYJ(_0023_003DzAbAO3f4_003D)];
		}
		return true;
	}

	public void _0023_003DzFPaftSc0Gyt2(Keys _0023_003DzchTpoW0_003D, Keys _0023_003DzdL4RD84_003D)
	{
		if (!_0023_003DzsV4VrnyKh2WN(_0023_003DzchTpoW0_003D) && (_0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[(int)_0023_003DzchTpoW0_003D] || _0023_003DzznhADp4uitmH(_0023_003DzdL4RD84_003D)))
		{
			_0023_003Dz8fhrV4UQDr2wMF0RWQ_003D_003D[(int)_0023_003DzchTpoW0_003D] = _0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[(int)_0023_003DzchTpoW0_003D];
			_0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[(int)_0023_003DzchTpoW0_003D] = false;
			_0023_003Dzbq3xszLKRWPL(_0023_003DzdL4RD84_003D, _0023_003Dz_H763Oc_003D: false);
		}
	}

	private int _0023_003DzjNNtK4EOlMYJ(Keys _0023_003DzchTpoW0_003D)
	{
		return _0023_003DzchTpoW0_003D switch
		{
			Keys.Control => 256, 
			Keys.Shift => 257, 
			Keys.Alt => 258, 
			_ => -1, 
		};
	}

	private bool _0023_003DzsV4VrnyKh2WN(Keys _0023_003DzchTpoW0_003D)
	{
		if (_0023_003DzchTpoW0_003D < Keys.None || _0023_003DzchTpoW0_003D >= (Keys)256)
		{
			return true;
		}
		return false;
	}

	public bool _0023_003DzSU7lXGSQfvMl(Keys _0023_003DzchTpoW0_003D)
	{
		if (_0023_003DzsV4VrnyKh2WN(_0023_003DzchTpoW0_003D))
		{
			return false;
		}
		return !_0023_003DzETD8ckar3LuB(_0023_003DzchTpoW0_003D);
	}

	internal bool _0023_003DzETD8ckar3LuB(modifierKeys _0023_003DzhDQm_0024HY_003D)
	{
		switch (_0023_003DzhDQm_0024HY_003D)
		{
		case modifierKeys.Alt:
			return _0023_003DzznhADp4uitmH(Keys.Alt);
		case modifierKeys.Shift:
			return _0023_003DzznhADp4uitmH(Keys.Shift);
		case modifierKeys.Ctrl:
			return _0023_003DzznhADp4uitmH(Keys.Control);
		case modifierKeys.CtrlAlt:
			return _0023_003DzznhADp4uitmH(Keys.Control | Keys.Alt);
		case modifierKeys.CtrlShift:
			return _0023_003DzznhADp4uitmH(Keys.Shift | Keys.Control);
		case modifierKeys.ShiftAlt:
			return _0023_003DzznhADp4uitmH(Keys.Shift | Keys.Alt);
		case modifierKeys.CtrlShiftAlt:
			return _0023_003DzznhADp4uitmH(Keys.Shift | Keys.Control | Keys.Alt);
		case modifierKeys.None:
			if (!_0023_003DzznhADp4uitmH(Keys.Control) && !_0023_003DzznhADp4uitmH(Keys.Shift))
			{
				return !_0023_003DzznhADp4uitmH(Keys.Alt);
			}
			return false;
		default:
			return true;
		}
	}

	internal bool _0023_003DzSU7lXGSQfvMl(modifierKeys _0023_003DzhDQm_0024HY_003D)
	{
		return !_0023_003DzETD8ckar3LuB(_0023_003DzhDQm_0024HY_003D);
	}

	internal void _0023_003DzvUkLDVo88jah()
	{
		for (int i = 0; i < _0023_003Dz8fhrV4UQDr2wMF0RWQ_003D_003D.Length; i++)
		{
			_0023_003Dz8fhrV4UQDr2wMF0RWQ_003D_003D[i] = _0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[i];
			_0023_003Dzk6wSAkcVp3XwEhxTOw_003D_003D[i] = false;
		}
	}
}

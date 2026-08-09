using System;
using System.Collections.Generic;
using System.Diagnostics;

internal sealed class _0023_003DzVJ0PLdBRVLHq7GXxTiA7sJcIGe4cSCrAjA_003D_003D : global::_0023_003Dzr9RDJSF5RunGVb9n_00242mcWpbmGgi_R6ljXQ_003D_003D<uint>
{
	internal sealed class _0023_003Dz1ovLhYe5Y_0024bz : IComparer<uint>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D _0023_003DzHNhJsg50rGXa;

		public _0023_003Dz1ovLhYe5Y_0024bz(_0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D _0023_003DzV_0024Ui4m7SpXBg)
		{
			_0023_003DzHNhJsg50rGXa = _0023_003DzV_0024Ui4m7SpXBg;
		}

		private bool _0023_003Dz9HLpJMc_003D(uint _0023_003Dz437_00244ak_003D, uint _0023_003DzTSeNR8Q_003D)
		{
			double num = _0023_003DzHNhJsg50rGXa._0023_003DzYBaDcXE_003D(_0023_003Dz437_00244ak_003D);
			double num2 = _0023_003DzHNhJsg50rGXa._0023_003DzYBaDcXE_003D(_0023_003DzTSeNR8Q_003D);
			if (!(num < num2))
			{
				if (num == num2)
				{
					return _0023_003Dz437_00244ak_003D < _0023_003DzTSeNR8Q_003D;
				}
				return false;
			}
			return true;
		}

		private int _0023_003DzKotpe_0024WgI9u9qwSzsLw0OGcmt1_0024GoGi97BA7S64_003D(uint _0023_003DzBJFJHwk_003D, uint _0023_003Dz40R7bAU_003D)
		{
			if (_0023_003Dz9HLpJMc_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D))
			{
				return -1;
			}
			return 1;
		}

		int IComparer<uint>.Compare(uint _0023_003DzBJFJHwk_003D, uint _0023_003Dz40R7bAU_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zKotpe$WgI9u9qwSzsLw0OGcmt1$GoGi97BA7S64=
			return this._0023_003DzKotpe_0024WgI9u9qwSzsLw0OGcmt1_0024GoGi97BA7S64_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		}
	}

	public _0023_003DzVJ0PLdBRVLHq7GXxTiA7sJcIGe4cSCrAjA_003D_003D()
	{
	}

	public _0023_003DzVJ0PLdBRVLHq7GXxTiA7sJcIGe4cSCrAjA_003D_003D(uint _0023_003DzoMNiNRw_003D)
		: base(_0023_003DzoMNiNRw_003D)
	{
	}

	public _0023_003DzVJ0PLdBRVLHq7GXxTiA7sJcIGe4cSCrAjA_003D_003D(uint _0023_003DzoMNiNRw_003D, uint _0023_003DzMkd41wQ_003D)
		: base(_0023_003DzoMNiNRw_003D, _0023_003DzMkd41wQ_003D)
	{
	}

	internal void _0023_003DzoQcRoMY_003D(uint _0023_003DzAqOpw0w_003D, uint _0023_003Dzfsn580w_003D, _0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D _0023_003DzV_0024Ui4m7SpXBg)
	{
		Array.Sort(_0023_003DzNiAIh8U_003D, Convert.ToInt32(_0023_003DzAqOpw0w_003D), Convert.ToInt32(_0023_003Dzfsn580w_003D), new _0023_003Dz1ovLhYe5Y_0024bz(_0023_003DzV_0024Ui4m7SpXBg));
	}
}

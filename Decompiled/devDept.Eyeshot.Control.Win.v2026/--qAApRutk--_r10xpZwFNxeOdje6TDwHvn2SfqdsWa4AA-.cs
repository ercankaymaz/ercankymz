using System.Runtime.CompilerServices;

internal sealed class _0023_003DqAApRutk_0024_0024_r10xpZwFNxeOdje6TDwHvn2SfqdsWa4AA_003D : _0023_003Dqa6z9PFIiJLOfR0XkEA_0024LQQEzVX1yZe1B1VYTr_0024prpIE_003D
{
	public void _0023_003Dzgo1kwdA4V28mP04wTFqkBEemHkFwexX9W_c4VzCf_0024t5neZc39VJDuMRlzb2S88gZWpnkjVg_xcBY()
	{
	}

	[SpecialName]
	public string _0023_003DzPurzisEXubVkYahd6Yo4UN7HQIOaXMy3Da4dsObsLg1kgbc7VNxXjXOHFXTwQZfmXeam1UV7_0024yhMBAqbiGfIYSnCmsWQ()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619172);
	}

	public int _0023_003DzvPSacFJ_oOOFZsSW2QwPOzh6gp5sJntE1dSeUhc86_Wb_0024NRKo3kK8iGqExBbizm4sCes7t8_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		byte b = (byte)(_0023_003DzjYYAPCA_003D.Length - _0023_003DzVC9FBdo_003D);
		while (_0023_003DzVC9FBdo_003D < _0023_003DzjYYAPCA_003D.Length)
		{
			_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D] = b;
			_0023_003DzVC9FBdo_003D++;
		}
		return b;
	}

	public int _0023_003DzQ__GZ2heyCNI7i32cg8tPOo4LUqahls_Xa9wkgzAJp_2RavwCWsIkt2fHedAAIQj5E4I9IdYU_0024CT(byte[] _0023_003DzjYYAPCA_003D)
	{
		int num = _0023_003DzjYYAPCA_003D[_0023_003DzjYYAPCA_003D.Length - 1];
		if (num < 1 || num > _0023_003DzjYYAPCA_003D.Length)
		{
			throw new _0023_003Dqb1QIyuS8QOki0iL4NUD1SbnXZyIWmUUOLNWUN3kAcqw_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619192));
		}
		for (int i = 1; i <= num; i++)
		{
			if (_0023_003DzjYYAPCA_003D[_0023_003DzjYYAPCA_003D.Length - i] != num)
			{
				throw new _0023_003Dqb1QIyuS8QOki0iL4NUD1SbnXZyIWmUUOLNWUN3kAcqw_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619192));
			}
		}
		return num;
	}
}

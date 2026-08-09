using System.Collections.Generic;

internal sealed class _0023_003DzMdd6jN4OSxmCAakGXVbFMGvoB4MveOE6MRjrxuWKF8Bs446D4A_003D_003D
{
	private List<_0023_003DzWlmKuFR_25v2I6VwXJh2123Fn76gsQGqnHEsEDgHfipNOlo3VyG9Ork_003D> _0023_003DzqQno2DY_003D;

	public _0023_003DzMdd6jN4OSxmCAakGXVbFMGvoB4MveOE6MRjrxuWKF8Bs446D4A_003D_003D()
	{
		_0023_003DzqQno2DY_003D = new List<_0023_003DzWlmKuFR_25v2I6VwXJh2123Fn76gsQGqnHEsEDgHfipNOlo3VyG9Ork_003D>();
	}

	public virtual int _0023_003Dz14lzA48_003D()
	{
		return _0023_003DzqQno2DY_003D.Count;
	}

	public virtual void _0023_003Dz1l0EiMs_003D(_0023_003DzWlmKuFR_25v2I6VwXJh2123Fn76gsQGqnHEsEDgHfipNOlo3VyG9Ork_003D _0023_003DzUNDYC4bcTSrE)
	{
		_0023_003DzqQno2DY_003D.Add(_0023_003DzUNDYC4bcTSrE);
		int num = _0023_003DzqQno2DY_003D.Count;
		while (num != 1 && _0023_003DzqQno2DY_003D[num / 2 - 1]._0023_003Dzwr6gDhQCZ2hQ() > _0023_003DzUNDYC4bcTSrE._0023_003Dzwr6gDhQCZ2hQ())
		{
			_0023_003DzqQno2DY_003D[num - 1] = _0023_003DzqQno2DY_003D[num / 2 - 1];
			num /= 2;
		}
		_0023_003DzqQno2DY_003D[num - 1] = _0023_003DzUNDYC4bcTSrE;
	}

	private void _0023_003DzMusAlMc_003D()
	{
		if (_0023_003DzqQno2DY_003D.Count == 0)
		{
			return;
		}
		int count = _0023_003DzqQno2DY_003D.Count;
		_0023_003DzWlmKuFR_25v2I6VwXJh2123Fn76gsQGqnHEsEDgHfipNOlo3VyG9Ork_003D _0023_003DzWlmKuFR_25v2I6VwXJh2123Fn76gsQGqnHEsEDgHfipNOlo3VyG9Ork_003D2 = _0023_003DzqQno2DY_003D[count - 1];
		int num = 1;
		int num2 = 2;
		count--;
		while (num2 <= count)
		{
			if (num2 < count && _0023_003DzqQno2DY_003D[num2 - 1]._0023_003Dzwr6gDhQCZ2hQ() > _0023_003DzqQno2DY_003D[num2]._0023_003Dzwr6gDhQCZ2hQ())
			{
				num2++;
			}
			if (_0023_003DzWlmKuFR_25v2I6VwXJh2123Fn76gsQGqnHEsEDgHfipNOlo3VyG9Ork_003D2._0023_003Dzwr6gDhQCZ2hQ() < _0023_003DzqQno2DY_003D[num2 - 1]._0023_003Dzwr6gDhQCZ2hQ())
			{
				break;
			}
			_0023_003DzqQno2DY_003D[num - 1] = _0023_003DzqQno2DY_003D[num2 - 1];
			num = num2;
			num2 *= 2;
		}
		_0023_003DzqQno2DY_003D[num - 1] = _0023_003DzWlmKuFR_25v2I6VwXJh2123Fn76gsQGqnHEsEDgHfipNOlo3VyG9Ork_003D2;
		_0023_003DzqQno2DY_003D.RemoveAt(_0023_003DzqQno2DY_003D.Count - 1);
	}

	public virtual _0023_003DzWlmKuFR_25v2I6VwXJh2123Fn76gsQGqnHEsEDgHfipNOlo3VyG9Ork_003D _0023_003Dze5l_0024RiEBG8Fu()
	{
		if (_0023_003DzqQno2DY_003D.Count == 0)
		{
			return null;
		}
		_0023_003DzWlmKuFR_25v2I6VwXJh2123Fn76gsQGqnHEsEDgHfipNOlo3VyG9Ork_003D result = _0023_003DzqQno2DY_003D[0];
		_0023_003DzMusAlMc_003D();
		return result;
	}
}

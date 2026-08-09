using System.Collections.Generic;

internal sealed class _0023_003Dz7_Q_00247lH14RB0e4Sc7IUOMRW8_AjhZHAJh_u4_e9b6cvX8VHKTd4XNEk_003D
{
	private _0023_003DzyfH_0024BuBhgX13GvuUpa_d5jbewHjMQyR2N_0024IZlwJccyb3 _0023_003Dz_0024L7n4VNDq0nlbxQz5w_003D_003D;

	private List<int> _0023_003Dzu6htKUZ1CPMC;

	private List<SortedList<int, int>> _0023_003Dzz9_0024BO0oIocLQLtLjB2su23w_003D;

	public _0023_003Dz7_Q_00247lH14RB0e4Sc7IUOMRW8_AjhZHAJh_u4_e9b6cvX8VHKTd4XNEk_003D(_0023_003DzyfH_0024BuBhgX13GvuUpa_d5jbewHjMQyR2N_0024IZlwJccyb3 _0023_003DzDkWkecG7DHfasDKiSw_003D_003D)
	{
		_0023_003Dz_0024L7n4VNDq0nlbxQz5w_003D_003D = _0023_003DzDkWkecG7DHfasDKiSw_003D_003D;
		_0023_003Dzu6htKUZ1CPMC = new List<int>();
		_0023_003Dzz9_0024BO0oIocLQLtLjB2su23w_003D = new List<SortedList<int, int>>();
		for (int i = 0; i < _0023_003Dz_0024L7n4VNDq0nlbxQz5w_003D_003D._0023_003DzV6pvI40pvKaa(); i++)
		{
			int num = 0;
			_0023_003Dzz9_0024BO0oIocLQLtLjB2su23w_003D.Add(new SortedList<int, int>());
			for (int j = 0; j < _0023_003Dz_0024L7n4VNDq0nlbxQz5w_003D_003D._0023_003DzGL7SbYaiXQOo(i); j++)
			{
				_0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb _0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2 = _0023_003Dz_0024L7n4VNDq0nlbxQz5w_003D_003D._0023_003DzLhpOdgNmR1hN(i, j);
				num += _0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2._0023_003DzzkMMMpLuvADm();
				_0023_003Dzz9_0024BO0oIocLQLtLjB2su23w_003D[i][num - 1] = j;
			}
			_0023_003Dzu6htKUZ1CPMC.Add(num);
		}
	}

	private static int _0023_003Dzbee4VnaRyEjO(IList<int> _0023_003DzcDEsV8s_003D, int _0023_003DzPzO_0024GUk_003D)
	{
		int num = 0;
		int num2 = _0023_003DzcDEsV8s_003D.Count - 1;
		while (num < num2)
		{
			int num3 = (num2 + num) / 2;
			if (_0023_003DzcDEsV8s_003D[num3] < _0023_003DzPzO_0024GUk_003D)
			{
				num = num3 + 1;
				continue;
			}
			if (_0023_003DzcDEsV8s_003D[num3] > _0023_003DzPzO_0024GUk_003D)
			{
				num2 = num3 - 1;
				continue;
			}
			return _0023_003DzPzO_0024GUk_003D;
		}
		if (_0023_003DzcDEsV8s_003D[num] < _0023_003DzPzO_0024GUk_003D)
		{
			num++;
		}
		return _0023_003DzcDEsV8s_003D[num];
	}

	public virtual _0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb _0023_003Dz5Ri1wxim4MXu08sLxEGkI3NXDE36(int _0023_003Dzp6tlVKg_003D, int _0023_003Dz_gNfoeFb9NXerzA4Jw_003D_003D, int[] _0023_003DzpQ7iHc96vXL_0024)
	{
		SortedList<int, int> sortedList = _0023_003Dzz9_0024BO0oIocLQLtLjB2su23w_003D[_0023_003Dzp6tlVKg_003D];
		int num = _0023_003Dzbee4VnaRyEjO(sortedList.Keys, _0023_003Dz_gNfoeFb9NXerzA4Jw_003D_003D);
		int _0023_003DzyzK8swU_003D = sortedList[num];
		_0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb _0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2 = _0023_003Dz_0024L7n4VNDq0nlbxQz5w_003D_003D._0023_003DzLhpOdgNmR1hN(_0023_003Dzp6tlVKg_003D, _0023_003DzyzK8swU_003D);
		_0023_003DzpQ7iHc96vXL_0024[0] = num + 1 - _0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2._0023_003DzzkMMMpLuvADm();
		_0023_003DzpQ7iHc96vXL_0024[1] = num + 1;
		_0023_003DzpQ7iHc96vXL_0024[2] = _0023_003Dzu6htKUZ1CPMC[_0023_003Dzp6tlVKg_003D];
		return _0023_003DzHAezStP_00247HHUTE1RE6BUhSJjAqiX8XVal0boMrZBItyb2;
	}

	public virtual int _0023_003DzhCDbTTHDLgi_(int _0023_003Dzp6tlVKg_003D)
	{
		return _0023_003Dzu6htKUZ1CPMC[_0023_003Dzp6tlVKg_003D];
	}
}

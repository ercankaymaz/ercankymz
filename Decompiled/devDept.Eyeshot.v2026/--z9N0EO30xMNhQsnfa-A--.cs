using System.Collections.Generic;
using devDept.Geometry;

internal sealed class _0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D
{
	internal string _0023_003DzS_00246o7tc_003D;

	internal int _0023_003DzoiYtBx0_003D;

	internal List<_0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D> _0023_003DzaeJGUlKH3YHY;

	private List<string> _0023_003Dz3AXmTxXwirhJ;

	private List<bool> _0023_003DzSC08cHefRDhERJrLMg_003D_003D;

	private List<List<double>> _0023_003DzjW50fyPfFwrS;

	private List<List<int>> _0023_003DzeRYnVR0_7_Z_0024;

	public _0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D(string _0023_003DzS_00246o7tc_003D)
	{
		this._0023_003DzS_00246o7tc_003D = _0023_003DzS_00246o7tc_003D;
		_0023_003DzoiYtBx0_003D = -1;
		_0023_003DzaeJGUlKH3YHY = new List<_0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D>();
		_0023_003Dz3AXmTxXwirhJ = new List<string>();
		_0023_003DzSC08cHefRDhERJrLMg_003D_003D = new List<bool>();
		_0023_003DzjW50fyPfFwrS = new List<List<double>>();
		_0023_003DzeRYnVR0_7_Z_0024 = new List<List<int>>();
	}

	internal void _0023_003Dz4_00247ECHrbDnj3(string _0023_003Dz7TFjJCU_003D, ref bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003Dz7TFjJCU_003D = _0023_003Dz7TFjJCU_003D.Trim();
		int num = _0023_003Dz7TFjJCU_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083)) + 1;
		int num2 = _0023_003Dz7TFjJCU_003D.Length - 1;
		while (num != num2)
		{
			string _0023_003DzjMrG45Y5bb_o = string.Empty;
			int num3 = _0023_003Dz12F_Um1QdsUY(_0023_003Dz7TFjJCU_003D, num, ref _0023_003DzjMrG45Y5bb_o);
			if (num3 >= 0)
			{
				int num4 = _0023_003DzjMrG45Y5bb_o.IndexOf('(');
				if (num4 > -1)
				{
					string text = _0023_003DzjMrG45Y5bb_o.Substring(0, num4);
					text = text.Trim();
					_0023_003Dz0cCjg9B5UMsA._0023_003DzF2NAsQQgiJGh(ref text, ref _0023_003Dzm4CSmX5Y3o6Q);
					_0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D _0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D2 = new _0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D(text);
					_0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D2._0023_003DzZm31BS8_003D(_0023_003DzjMrG45Y5bb_o);
					_0023_003Dz4zTZ_0024zfXNd87(_0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D2);
				}
				num = num3 + 1;
				continue;
			}
			break;
		}
	}

	internal void _0023_003DzZm31BS8_003D(string _0023_003DzWt1kNcgV8zF_0024)
	{
		int num = 0;
		int num2 = _0023_003DzWt1kNcgV8zF_0024.IndexOf('\'');
		int num3 = _0023_003DzWt1kNcgV8zF_0024.IndexOf('(');
		num = ((num2 <= 0 || num3 <= num2) ? num3 : num2);
		List<double> list = new List<double>();
		List<int> list2 = new List<int>();
		while (num < _0023_003DzWt1kNcgV8zF_0024.Length && _0023_003DzWt1kNcgV8zF_0024[num] != ';')
		{
			string text = string.Empty;
			if (_0023_003DzWt1kNcgV8zF_0024[num] == '\'')
			{
				for (; num < _0023_003DzWt1kNcgV8zF_0024.Length - 1 && _0023_003DzWt1kNcgV8zF_0024[num + 1] != '\''; num++)
				{
					text += _0023_003DzWt1kNcgV8zF_0024[num + 1];
				}
				num++;
				if (text.Length > 0)
				{
					_0023_003DzjYQAgv8_003D(text);
					text = text.Remove(0);
					if (num == _0023_003DzWt1kNcgV8zF_0024.Length)
					{
						break;
					}
				}
			}
			if (_0023_003DzWt1kNcgV8zF_0024[num] != '#')
			{
				int num4 = _0023_003DzWt1kNcgV8zF_0024.IndexOfAny(new char[8] { ',', '#', ' ', '(', ')', '\n', '\'', ';' }, num);
				text = _0023_003DzWt1kNcgV8zF_0024.Substring(num, num4 - num);
				num += num4 - num;
				if (text.Length > 0)
				{
					if (Utility.DoubleTryParse(text, out var result))
					{
						list.Add(result);
					}
					else if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920531)))
					{
						_0023_003DzKRDYQC4_003D(_0023_003DzB68dg9Q_003D: false);
					}
					else if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930068)))
					{
						_0023_003DzKRDYQC4_003D(_0023_003DzB68dg9Q_003D: false);
					}
					else if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920778)))
					{
						_0023_003DzKRDYQC4_003D(_0023_003DzB68dg9Q_003D: true);
					}
					else if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920575)))
					{
						_0023_003DzjYQAgv8_003D(text);
					}
					else if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302930078)))
					{
						_0023_003DzjYQAgv8_003D(text);
					}
					else
					{
						_0023_003DzjYQAgv8_003D(text);
					}
				}
			}
			else
			{
				int num5 = _0023_003DzWt1kNcgV8zF_0024.IndexOfAny(new char[3] { ',', ' ', ')' }, num + 1);
				text = _0023_003DzWt1kNcgV8zF_0024.Substring(num + 1, num5 - (num + 1));
				num += num5 - (num + 1);
				text = text.Trim();
				if (int.TryParse(text, out var result2))
				{
					list2.Add(result2);
				}
			}
			if (_0023_003DzWt1kNcgV8zF_0024[num] == ')' || _0023_003DzWt1kNcgV8zF_0024[num] == '(')
			{
				if (list.Count > 0)
				{
					_0023_003DzPc6lk1BF85j3(list);
					list.Clear();
				}
				if (list2.Count > 0)
				{
					_0023_003DzaOLv07KWubtW(list2);
					list2.Clear();
				}
			}
			num++;
		}
	}

	private void _0023_003DzaOLv07KWubtW(List<int> _0023_003DzyG_0024Hbnqtk43E)
	{
		List<int> item = new List<int>(_0023_003DzyG_0024Hbnqtk43E);
		_0023_003DzeRYnVR0_7_Z_0024.Add(item);
	}

	private void _0023_003DzPc6lk1BF85j3(List<double> _0023_003Dz8J9xzDnOpbjL)
	{
		List<double> item = new List<double>(_0023_003Dz8J9xzDnOpbjL);
		_0023_003DzjW50fyPfFwrS.Add(item);
	}

	private void _0023_003DzKRDYQC4_003D(bool _0023_003DzB68dg9Q_003D)
	{
		_0023_003DzSC08cHefRDhERJrLMg_003D_003D.Add(_0023_003DzB68dg9Q_003D);
	}

	private void _0023_003DzjYQAgv8_003D(string _0023_003DzGHaanH_QIeMa)
	{
		_0023_003Dz3AXmTxXwirhJ.Add(_0023_003DzGHaanH_QIeMa);
	}

	private void _0023_003Dz4zTZ_0024zfXNd87(_0023_003Dz9N0EO30xMNhQsnfa_0024A_003D_003D _0023_003DzUT8peiU_003D)
	{
		_0023_003DzaeJGUlKH3YHY.Add(_0023_003DzUT8peiU_003D);
	}

	private int _0023_003Dz12F_Um1QdsUY(string _0023_003Dz7TFjJCU_003D, int _0023_003DzCREyuzFnGFhJ, ref string _0023_003DzjMrG45Y5bb_o)
	{
		int num = -1;
		int num2 = -1;
		for (int i = _0023_003DzCREyuzFnGFhJ + 1; i < _0023_003Dz7TFjJCU_003D.Length; i++)
		{
			char num3 = _0023_003Dz7TFjJCU_003D[i];
			if (num3 == '(')
			{
				num2++;
			}
			if (num3 == ')')
			{
				if (num2 == 0)
				{
					num = i;
					break;
				}
				num2--;
			}
		}
		int num4 = num + 1 - _0023_003DzCREyuzFnGFhJ;
		if (num4 > 0)
		{
			_0023_003DzjMrG45Y5bb_o = _0023_003Dz7TFjJCU_003D.Substring(_0023_003DzCREyuzFnGFhJ, num4);
			_0023_003DzjMrG45Y5bb_o = _0023_003DzjMrG45Y5bb_o.Trim();
		}
		return num;
	}

	internal string _0023_003Dzs_7kVZ4_003D(int _0023_003DzyzK8swU_003D)
	{
		if (_0023_003Dz3AXmTxXwirhJ.Count > _0023_003DzyzK8swU_003D)
		{
			return _0023_003Dz3AXmTxXwirhJ[_0023_003DzyzK8swU_003D];
		}
		return string.Empty;
	}

	internal void _0023_003Dz0vOs44Q_003D(int _0023_003DzyzK8swU_003D, ref List<double> _0023_003DzHSO_00246A0_003D)
	{
		if (_0023_003DzyzK8swU_003D < _0023_003DzjW50fyPfFwrS.Count)
		{
			_0023_003DzHSO_00246A0_003D = _0023_003DzjW50fyPfFwrS[_0023_003DzyzK8swU_003D];
		}
	}

	internal double _0023_003DzmBXNosU_003D(int _0023_003DzQp_0024wQHw_003D, int _0023_003DzyzK8swU_003D)
	{
		double result = -1.0;
		if (_0023_003DzQp_0024wQHw_003D < _0023_003DzjW50fyPfFwrS.Count && _0023_003DzyzK8swU_003D < _0023_003DzjW50fyPfFwrS[_0023_003DzQp_0024wQHw_003D].Count)
		{
			result = _0023_003DzjW50fyPfFwrS[_0023_003DzQp_0024wQHw_003D][_0023_003DzyzK8swU_003D];
		}
		return result;
	}

	internal int _0023_003Dz8_0024KpxIVpKxQE(int _0023_003DzQp_0024wQHw_003D, int _0023_003DzyzK8swU_003D)
	{
		int result = -1;
		if (_0023_003DzQp_0024wQHw_003D < _0023_003DzeRYnVR0_7_Z_0024.Count && _0023_003DzyzK8swU_003D < _0023_003DzeRYnVR0_7_Z_0024[_0023_003DzQp_0024wQHw_003D].Count)
		{
			result = _0023_003DzeRYnVR0_7_Z_0024[_0023_003DzQp_0024wQHw_003D][_0023_003DzyzK8swU_003D];
		}
		return result;
	}

	internal void _0023_003DzQxqI35v79ybX(int _0023_003DzyzK8swU_003D, ref List<int> _0023_003Dz0TrLnyZ0bqj_0024)
	{
		if (_0023_003DzyzK8swU_003D < _0023_003DzeRYnVR0_7_Z_0024.Count)
		{
			_0023_003Dz0TrLnyZ0bqj_0024 = _0023_003DzeRYnVR0_7_Z_0024[_0023_003DzyzK8swU_003D];
		}
	}
}

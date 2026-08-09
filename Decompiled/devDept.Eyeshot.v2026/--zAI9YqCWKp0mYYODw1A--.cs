using System;
using System.Collections.Generic;
using System.IO;

internal sealed class _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	internal _0023_003DzgpK4H7ZVNTkyNrFi4w_003D_003D _0023_003DzbHkkNl4_003D;

	public List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003DzJ9shYljglKVu;

	private int _0023_003DzVAGVASk_003D;

	internal _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzVAGVASk_003D = -1;
		_0023_003DzbHkkNl4_003D = null;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D()
	{
		_0023_003DzJ9shYljglKVu = new List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D>();
		_0023_003DzbHkkNl4_003D = null;
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzpXqcGaz7sKJt = false;
		switch (_0023_003Dz7duJoMQ_003D)
		{
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)0:
		{
			string _0023_003DzgPsOl1A_003D = _0023_003DziHtkvmE_003D;
			for (int num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083)); num > -1; num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083)))
			{
				_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(0, 1);
			}
			for (int num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091)); num > -1; num = _0023_003DzgPsOl1A_003D.IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091)))
			{
				_0023_003DzgPsOl1A_003D = _0023_003DzgPsOl1A_003D.Remove(num, 1);
			}
			string _0023_003DzD5YCi2M_003D = string.Empty;
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
			if (int.TryParse(_0023_003DzD5YCi2M_003D, out var result))
			{
				_0023_003DzVAGVASk_003D = result;
			}
			else
			{
				_0023_003DzVAGVASk_003D = -1;
			}
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
			_0023_003DzbHkkNl4_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzVAGVASk_003D, _0023_003Dz9UNAzE0_003D) as _0023_003DzgpK4H7ZVNTkyNrFi4w_003D_003D;
			if (_0023_003DzbHkkNl4_003D != null)
			{
				_0023_003DzpXqcGaz7sKJt = true;
				_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
			}
			break;
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2:
			_0023_003DzpXqcGaz7sKJt = true;
			break;
		}
	}

	internal void _0023_003DzTTXbw2AOoGGhr7C_00246oHxqA0_003D(string _0023_003DznkMU43c_003D, List<int> _0023_003DzrX94jc5RnuZi, ref int _0023_003DzzCdq1Rw_003D, _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		List<int> list = new List<int>();
		StreamWriter streamWriter = _0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc();
		try
		{
			int num = 1;
			for (int i = 0; i < num; i++)
			{
				int _0023_003DzXzzdUNI_003D = 0;
				_0023_003DziO3oKbRGO3CiBXdKuw_003D_003D(ref _0023_003DzXzzdUNI_003D, _0023_003DzmDt2hY3pmRst);
				list.Add(_0023_003DzXzzdUNI_003D);
			}
			foreach (int item in list)
			{
				string _0023_003DznXG736c_003D = string.Empty;
				int num2 = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921748), ref _0023_003DznXG736c_003D);
				string text = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921736), _0023_003DznkMU43c_003D, item);
				_0023_003DznXG736c_003D += text;
				streamWriter.WriteLine(_0023_003DznXG736c_003D);
				_0023_003DzzCdq1Rw_003D = num2;
				_0023_003DzrX94jc5RnuZi.Add(num2);
			}
		}
		catch (Exception)
		{
		}
	}

	private void _0023_003DziO3oKbRGO3CiBXdKuw_003D_003D(ref int _0023_003DzXzzdUNI_003D, _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		List<int> list = new List<int>();
		List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> list2 = _0023_003DzJ9shYljglKVu;
		int _0023_003Dz7wrDJ0zDrFkl = 0;
		foreach (_0023_003DzbykJA36oCfUxYTgeaw_003D_003D item in list2)
		{
			item._0023_003DzKX9_h2E_003D(ref _0023_003Dz7wrDJ0zDrFkl, _0023_003DzmDt2hY3pmRst);
			list.Add(_0023_003Dz7wrDJ0zDrFkl);
		}
		string _0023_003DznXG736c_003D = string.Empty;
		_0023_003DzXzzdUNI_003D = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921977), ref _0023_003DznXG736c_003D);
		string _0023_003Dzf_00247a57H8L4S = string.Empty;
		_0023_003Dz0cCjg9B5UMsA._0023_003DzwjRq6xeLBWXe(list, ref _0023_003Dzf_00247a57H8L4S);
		_0023_003DznXG736c_003D += _0023_003Dzf_00247a57H8L4S;
		_0023_003DznXG736c_003D += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920352);
		_0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc().WriteLine(_0023_003DznXG736c_003D);
	}
}

using System.Collections.Generic;
using StepTranslator;
using devDept.Geometry;

internal sealed class _0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	internal double _0023_003DzEGKj_0024SNUUihi;

	internal _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D _0023_003DzjN7uSQk_003D;

	internal _0023_003DzGSG3uqUKk1FQ_00245V_r_0024ONrfw_003D _0023_003Dzhwq1ng0_003D;

	private int _0023_003DzGF8LB_0024c_003D;

	internal _0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzGF8LB_0024c_003D = -1;
		_0023_003DzEGKj_0024SNUUihi = 0.0;
		_0023_003DzjN7uSQk_003D = null;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public _0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D(double[] _0023_003DzbUvT9Pc_003D, double _0023_003DzEGKj_0024SNUUihi, double[] _0023_003Dztv6hMfw_003D, double[] _0023_003Dztg84lvw_003D)
	{
		_0023_003DzjN7uSQk_003D = new _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D(_0023_003DzbUvT9Pc_003D, new double[3]
		{
			_0023_003Dztv6hMfw_003D[1] * _0023_003Dztg84lvw_003D[2] - _0023_003Dztv6hMfw_003D[2] * _0023_003Dztg84lvw_003D[1],
			_0023_003Dztv6hMfw_003D[2] * _0023_003Dztg84lvw_003D[0] - _0023_003Dztv6hMfw_003D[0] * _0023_003Dztg84lvw_003D[2],
			_0023_003Dztv6hMfw_003D[0] * _0023_003Dztg84lvw_003D[1] - _0023_003Dztv6hMfw_003D[1] * _0023_003Dztg84lvw_003D[0]
		}, _0023_003Dztv6hMfw_003D);
		this._0023_003DzEGKj_0024SNUUihi = _0023_003DzEGKj_0024SNUUihi;
	}

	public _0023_003DzzfpbUn2I9sPZMFRC_HseTLs_003D(double[] _0023_003DzbUvT9Pc_003D, double[] _0023_003Dz01D6GuJZybqtlX5q6A_003D_003D, double[] _0023_003Dz6aC3o3IKZkfc, double _0023_003DzEGKj_0024SNUUihi)
	{
		_0023_003DzjN7uSQk_003D = new _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D(_0023_003DzbUvT9Pc_003D, _0023_003Dz01D6GuJZybqtlX5q6A_003D_003D, _0023_003Dz6aC3o3IKZkfc);
		this._0023_003DzEGKj_0024SNUUihi = _0023_003DzEGKj_0024SNUUihi;
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
				_0023_003DzGF8LB_0024c_003D = result;
			}
			else
			{
				_0023_003DzGF8LB_0024c_003D = -1;
			}
			string _0023_003DzD5YCi2M_003D2 = string.Empty;
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D2);
			_0023_003DzD5YCi2M_003D2 = _0023_003DzD5YCi2M_003D2.Trim();
			if (Utility.DoubleTryParse(_0023_003DzD5YCi2M_003D2, out var result2))
			{
				_0023_003DzEGKj_0024SNUUihi = result2;
			}
			else
			{
				_0023_003DzEGKj_0024SNUUihi = 0.0;
			}
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
			_0023_003DzjN7uSQk_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzGF8LB_0024c_003D, _0023_003Dz9UNAzE0_003D) as _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D;
			if (_0023_003DzjN7uSQk_003D == null)
			{
				_0023_003Dzhwq1ng0_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzGF8LB_0024c_003D, _0023_003Dz9UNAzE0_003D) as _0023_003DzGSG3uqUKk1FQ_00245V_r_0024ONrfw_003D;
			}
			if (_0023_003DzjN7uSQk_003D != null || _0023_003Dzhwq1ng0_003D != null)
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

	internal int _0023_003DzgKwg_hHotaUa(_0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		double value = _0023_003DzEGKj_0024SNUUihi;
		int num = -1;
		if (_0023_003DzjN7uSQk_003D != null)
		{
			num = _0023_003DzjN7uSQk_003D._0023_003Dz20zrKxr_0024DcSEDF7Wvg_003D_003D(_0023_003DzmDt2hY3pmRst);
		}
		else if (_0023_003Dzhwq1ng0_003D != null)
		{
			num = _0023_003Dzhwq1ng0_003D._0023_003Dzm9Dsnv_CoPbCC1jUrA_003D_003D(_0023_003DzmDt2hY3pmRst);
		}
		string _0023_003DznXG736c_003D = string.Empty;
		int result = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926802), ref _0023_003DznXG736c_003D);
		_0023_003DznXG736c_003D = string.Concat(str1: string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926785), num, value.ToStringStep()), str0: _0023_003DznXG736c_003D);
		_0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc().WriteLine(_0023_003DznXG736c_003D);
		return result;
	}
}

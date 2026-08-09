using System.Collections.Generic;
using System.Globalization;
using devDept.Geometry;

internal sealed class _0023_003DzqAV_0024vo2TCVnninySAg_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	internal _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzWd_MwxQ_003D;

	private int _0023_003DzR0xk_0024Gzi2Cb6;

	internal double _0023_003DzVo6wtX6w5kHE;

	public _0023_003DzqAV_0024vo2TCVnninySAg_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzR0xk_0024Gzi2Cb6 = -1;
		_0023_003DzVo6wtX6w5kHE = 0.0;
		_0023_003Dzwtld1NM_003D = new double[3];
		_0023_003Dzwtld1NM_003D[0] = -1.0;
		_0023_003Dzwtld1NM_003D[1] = -1.0;
		_0023_003Dzwtld1NM_003D[2] = -1.0;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public _0023_003DzqAV_0024vo2TCVnninySAg_003D_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzRykxkrrKx49Q, double _0023_003DzYUMqwZQ_003D)
	{
		_0023_003DzWd_MwxQ_003D = _0023_003DzRykxkrrKx49Q._0023_003DzyXmKbtw_003D;
		_0023_003DzVo6wtX6w5kHE = _0023_003DzYUMqwZQ_003D;
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzpXqcGaz7sKJt = false;
		switch (_0023_003Dz7duJoMQ_003D)
		{
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)0:
		{
			string _0023_003DzgPsOl1A_003D = _0023_003DziHtkvmE_003D;
			string _0023_003DzD5YCi2M_003D = string.Empty;
			int result = -1;
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
			if (int.TryParse(_0023_003DzD5YCi2M_003D, out result))
			{
				_0023_003DzR0xk_0024Gzi2Cb6 = result;
			}
			else
			{
				_0023_003DzR0xk_0024Gzi2Cb6 = -1;
			}
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
			_0023_003DzVo6wtX6w5kHE = Utility.DoubleParse(_0023_003DzD5YCi2M_003D);
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
			_0023_003DzWd_MwxQ_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzR0xk_0024Gzi2Cb6, _0023_003Dz9UNAzE0_003D);
			if (_0023_003DzWd_MwxQ_003D != null)
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

	internal int _0023_003DzQqxv3uua1TfU(_0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		int num = -1;
		if (_0023_003DzWd_MwxQ_003D is _0023_003Dz0UuyzKeWoftDid2rHh7d4tc_003D)
		{
			num = (_0023_003DzWd_MwxQ_003D as _0023_003Dz0UuyzKeWoftDid2rHh7d4tc_003D)._0023_003DzcB9JyLA_003D(_0023_003DzmDt2hY3pmRst);
		}
		else if (_0023_003DzWd_MwxQ_003D is _0023_003DzvcL9S1cC2_0024_0024JP7l0IJjLCS0_003D)
		{
			num = (_0023_003DzWd_MwxQ_003D as _0023_003DzvcL9S1cC2_0024_0024JP7l0IJjLCS0_003D)._0023_003DzIcqwBkyPNe4TdhKZlA_003D_003D(_0023_003DzmDt2hY3pmRst);
		}
		else if (_0023_003DzWd_MwxQ_003D is _0023_003DzkYSEO_0024NlMVTAsLSzRbxE3OA_003D)
		{
			num = (_0023_003DzWd_MwxQ_003D as _0023_003DzkYSEO_0024NlMVTAsLSzRbxE3OA_003D)._0023_003Dz0rv8e8J9UosG(_0023_003DzmDt2hY3pmRst);
		}
		else if (_0023_003DzWd_MwxQ_003D is _0023_003DziK6_0024_0024WtAgJYnGTXXUA_003D_003D)
		{
			num = (_0023_003DzWd_MwxQ_003D as _0023_003DziK6_0024_0024WtAgJYnGTXXUA_003D_003D)._0023_003Dz0lHaBmipcGio(_0023_003DzmDt2hY3pmRst);
		}
		else if (_0023_003DzWd_MwxQ_003D is _0023_003DziDLa2nEzO1_D7f4BwoHclZk_003D)
		{
			num = (_0023_003DzWd_MwxQ_003D as _0023_003DziDLa2nEzO1_D7f4BwoHclZk_003D)._0023_003DznfO9dTnjWJ_0024manVIbQ_003D_003D(_0023_003DzmDt2hY3pmRst);
		}
		else if (_0023_003DzWd_MwxQ_003D is _0023_003DzT_00244wPCXj2G_Q3t3aXcyx0a9GtpA4)
		{
			num = (_0023_003DzWd_MwxQ_003D as _0023_003DzT_00244wPCXj2G_Q3t3aXcyx0a9GtpA4)._0023_003DzMwOPBCbwuHtTMlLaTUicrACvnuJzgfvq0A_003D_003D(_0023_003DzmDt2hY3pmRst);
		}
		else if (_0023_003DzWd_MwxQ_003D is _0023_003DzlYF8Kvtf_cKkUNnYKB_0024_twt3kb0a)
		{
			num = (_0023_003DzWd_MwxQ_003D as _0023_003DzlYF8Kvtf_cKkUNnYKB_0024_twt3kb0a)._0023_003DzdeddOLygM2PQKDytcgKQgYc_003D(_0023_003DzmDt2hY3pmRst);
		}
		string _0023_003DznXG736c_003D = string.Empty;
		int result = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921930), ref _0023_003DznXG736c_003D);
		_0023_003DznXG736c_003D = string.Concat(str1: string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921889), num, _0023_003DzVo6wtX6w5kHE.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat)), str0: _0023_003DznXG736c_003D);
		_0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc().WriteLine(_0023_003DznXG736c_003D);
		return result;
	}
}

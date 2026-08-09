using System;
using System.Collections.Generic;
using System.IO;
using StepTranslator;
using devDept.Geometry;

internal sealed class _0023_003DzG9_0024QNM8Ikh4XnXfUBw_003D_003D : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	private int _0023_003DzULvfV3s_003D;

	internal double _0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D;

	public _0023_003DzcFDrygywXpaPUO4ISg_003D_003D _0023_003Dz6hQ2Ons_003D;

	internal _0023_003DzG9_0024QNM8Ikh4XnXfUBw_003D_003D(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DzULvfV3s_003D = -1;
		_0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D = 0.0;
		_0023_003Dz6hQ2Ons_003D = null;
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	internal _0023_003DzG9_0024QNM8Ikh4XnXfUBw_003D_003D(ref double _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D, ref double[] _0023_003DzbIIdMFuNXKsO)
	{
		_0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D = _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D;
		_0023_003Dz6hQ2Ons_003D = new _0023_003DzcFDrygywXpaPUO4ISg_003D_003D(_0023_003DzbIIdMFuNXKsO);
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
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Remove(0, 1);
			if (!int.TryParse(_0023_003DzD5YCi2M_003D, out _0023_003DzULvfV3s_003D))
			{
				_0023_003DzULvfV3s_003D = -1;
			}
			_0023_003Dz0cCjg9B5UMsA._0023_003DzohBaW6OtXTjN(ref _0023_003DzgPsOl1A_003D, ref _0023_003DzD5YCi2M_003D);
			_0023_003DzD5YCi2M_003D = _0023_003DzD5YCi2M_003D.Trim();
			_0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D = Utility.DoubleParse(_0023_003DzD5YCi2M_003D);
			_0023_003DzpXqcGaz7sKJt = false;
			_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1;
			break;
		}
		case (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)1:
			_0023_003Dz6hQ2Ons_003D = _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D._0023_003Dzi25acTKdSsWw(_0023_003DzULvfV3s_003D, _0023_003Dz9UNAzE0_003D) as _0023_003DzcFDrygywXpaPUO4ISg_003D_003D;
			if (_0023_003Dz6hQ2Ons_003D != null)
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

	internal static void _0023_003DzMy_0024_0024Nck_003D(double[] _0023_003DzY5pSLwI_003D, ref int _0023_003Dz5_0024BiNfc_003D, _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		if (_0023_003DzY5pSLwI_003D != null)
		{
			double num = _0023_003DzY5pSLwI_003D[0];
			double num2 = _0023_003DzY5pSLwI_003D[1];
			double num3 = _0023_003DzY5pSLwI_003D[2];
			double num4 = _0023_003Dzo00msafBf7Nc(_0023_003DzY5pSLwI_003D);
			if (num4 > 1E-09)
			{
				num /= num4;
				num2 /= num4;
				num3 /= num4;
			}
			int num5 = _0023_003DzmDt2hY3pmRst._0023_003Dz0C_00246iHndCo2u();
			string value = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926294), num5, num.ToStringStep(), num2.ToStringStep(), num3.ToStringStep());
			StreamWriter streamWriter = _0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc();
			streamWriter.WriteLine(value);
			string _0023_003DznXG736c_003D = string.Empty;
			_0023_003Dz5_0024BiNfc_003D = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928497), ref _0023_003DznXG736c_003D);
			_0023_003DznXG736c_003D = string.Concat(str1: string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926785), num5, num4.ToStringStep()), str0: _0023_003DznXG736c_003D);
			streamWriter.WriteLine(_0023_003DznXG736c_003D);
		}
	}

	internal static void _0023_003DzMy_0024_0024Nck_003D(double[] _0023_003DzY5pSLwI_003D, double _0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D, ref int _0023_003Dz5_0024BiNfc_003D, _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		if (_0023_003DzY5pSLwI_003D != null)
		{
			double value = _0023_003DzY5pSLwI_003D[0];
			double value2 = _0023_003DzY5pSLwI_003D[1];
			double value3 = _0023_003DzY5pSLwI_003D[2];
			int num = _0023_003DzmDt2hY3pmRst._0023_003Dz0C_00246iHndCo2u();
			string value4 = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926294), num, value.ToStringStep(), value2.ToStringStep(), value3.ToStringStep());
			StreamWriter streamWriter = _0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc();
			streamWriter.WriteLine(value4);
			string _0023_003DznXG736c_003D = string.Empty;
			_0023_003Dz5_0024BiNfc_003D = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928497), ref _0023_003DznXG736c_003D);
			_0023_003DznXG736c_003D = string.Concat(str1: string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926785), num, _0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D.ToStringStep()), str0: _0023_003DznXG736c_003D);
			streamWriter.WriteLine(_0023_003DznXG736c_003D);
		}
	}

	private static double _0023_003Dzo00msafBf7Nc(double[] _0023_003DzY5pSLwI_003D)
	{
		double num = _0023_003DzY5pSLwI_003D[0];
		double num2 = _0023_003DzY5pSLwI_003D[1];
		double num3 = _0023_003DzY5pSLwI_003D[2];
		return Math.Sqrt(num * num + num2 * num2 + num3 * num3);
	}

	internal int _0023_003DzMy_0024_0024Nck_003D(_0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		double value = _0023_003Dz6hQ2Ons_003D._0023_003DzqdOG1COev7La[0];
		double value2 = _0023_003Dz6hQ2Ons_003D._0023_003DzqdOG1COev7La[1];
		double value3 = _0023_003Dz6hQ2Ons_003D._0023_003DzqdOG1COev7La[2];
		int num = _0023_003DzmDt2hY3pmRst._0023_003Dz0C_00246iHndCo2u();
		string value4 = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926294), num, value.ToStringStep(), value2.ToStringStep(), value3.ToStringStep());
		StreamWriter streamWriter = _0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc();
		streamWriter.WriteLine(value4);
		string _0023_003DznXG736c_003D = string.Empty;
		int result = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928497), ref _0023_003DznXG736c_003D);
		_0023_003DznXG736c_003D = string.Concat(str1: string.Format(arg1: _0023_003Dz_QIWZfz_FlrL_00243I_0024Yg_003D_003D.ToStringStep(), format: _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926785), arg0: num), str0: _0023_003DznXG736c_003D);
		streamWriter.WriteLine(_0023_003DznXG736c_003D);
		return result;
	}
}

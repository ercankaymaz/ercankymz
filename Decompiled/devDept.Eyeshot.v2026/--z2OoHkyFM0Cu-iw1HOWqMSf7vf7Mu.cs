using System.Collections.Generic;
using StepTranslator;
using devDept.Geometry;

internal sealed class _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu : _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D
{
	private double[] _0023_003Dz2iyAqy9oMvj07ZMNyw_003D_003D;

	public _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(double[] _0023_003DzLiDbFtubATq7)
	{
		_0023_003Dz2tDRAbgt6hAk(_0023_003DzLiDbFtubATq7);
	}

	internal _0023_003Dz2OoHkyFM0Cu_0024iw1HOWqMSf7vf7Mu(int _0023_003DzkXQ_IWk_003D, string _0023_003DzY4oh8qo_003D, string _0023_003DzPzO_0024GUk_003D, Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, ref int _0023_003DzJjVQTzpKI4Ni, bool _0023_003Dzm4CSmX5Y3o6Q)
		: base(_0023_003DzkXQ_IWk_003D, _0023_003DzY4oh8qo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz9UNAzE0_003D, ref _0023_003DzJjVQTzpKI4Ni, _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003Dz9GKXKtrg_0024MPY(_0023_003Dz9UNAzE0_003D, _0023_003Dzm4CSmX5Y3o6Q);
	}

	public double[] _0023_003Dzfj_WbJ59_mOa()
	{
		return _0023_003Dz2iyAqy9oMvj07ZMNyw_003D_003D;
	}

	public void _0023_003Dz2tDRAbgt6hAk(double[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz2iyAqy9oMvj07ZMNyw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal override void _0023_003Dz9GKXKtrg_0024MPY(Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz9UNAzE0_003D, bool _0023_003Dzm4CSmX5Y3o6Q)
	{
		_0023_003DziHtkvmE_003D = _0023_003DziHtkvmE_003D.Trim('(', ' ', ')');
		string[] array = _0023_003DziHtkvmE_003D.Split(',');
		double num = Utility.DoubleParse(array[0]);
		double num2 = Utility.DoubleParse(array[1]);
		double num3 = 0.0;
		if (array.Length > 2)
		{
			num3 = Utility.DoubleParse(array[2]);
		}
		_0023_003Dz2iyAqy9oMvj07ZMNyw_003D_003D = new double[3] { num, num2, num3 };
		_0023_003DzpXqcGaz7sKJt = true;
		_0023_003Dz7duJoMQ_003D = (_0023_003DzyPjMV3hYmPOOmhGI9w_003D_003D)2;
	}

	internal static int _0023_003DzuXztUSYcR_Yh_0024879s0ykZ2A_003D(double[] _0023_003DzuV5p_uA_003D, _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		double value = _0023_003DzuV5p_uA_003D[0];
		double value2 = _0023_003DzuV5p_uA_003D[1];
		double value3 = _0023_003DzuV5p_uA_003D[2];
		string _0023_003DznXG736c_003D = string.Empty;
		int result = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921666), ref _0023_003DznXG736c_003D);
		_0023_003DznXG736c_003D = string.Concat(str1: string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921660), value.ToStringStep(), value2.ToStringStep(), value3.ToStringStep()), str0: _0023_003DznXG736c_003D);
		_0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc().WriteLine(_0023_003DznXG736c_003D);
		return result;
	}

	internal static int _0023_003Dz9h4EbhioUP30uwU9HndE6lc_003D(double[] _0023_003DzuV5p_uA_003D, _0023_003DzccZz_2h5nX81BJCYyQ_003D_003D _0023_003DzmDt2hY3pmRst)
	{
		double value = _0023_003DzuV5p_uA_003D[0];
		double value2 = _0023_003DzuV5p_uA_003D[1];
		string _0023_003DznXG736c_003D = string.Empty;
		int result = _0023_003DzmDt2hY3pmRst._0023_003DzVQ_00245cboWSpXy(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921666), ref _0023_003DznXG736c_003D);
		_0023_003DznXG736c_003D = string.Concat(str1: string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921618), value.ToStringStep(), value2.ToStringStep()), str0: _0023_003DznXG736c_003D);
		_0023_003DzmDt2hY3pmRst._0023_003DzuB_0024_MMO2FDGc().WriteLine(_0023_003DznXG736c_003D);
		return result;
	}
}

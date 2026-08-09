using System;
using System.Collections.Generic;
using System.IO;

internal abstract class _0023_003Dz7EU3jafgrAIj0FjRJ8wRX1Q_003D : _0023_003Dz6kM6VXzbbWX0JZN30g_003D_003D
{
	protected ulong _0023_003Dz2F1zp4WtKF3x;

	protected ulong _0023_003DziZiYS_Z2g6V4;

	protected _0023_003Dz3l7Ztn_p96wPMxjjBg_003D_003D _0023_003Dzc_00245BnRNRPPXZ;

	protected byte[] _0023_003Dz9sKZ9PHz8Ffc;

	protected ulong _0023_003DzOd5CfukXmb4j6iYm0g_003D_003D;

	protected ulong _0023_003DzUmHxlBh2ZSmoTFH7Aw_003D_003D;

	protected uint _0023_003DzbjEb2DprcGBMa9lOjA_003D_003D;

	protected uint _0023_003DzodMbknGRQ4dL;

	protected uint _0023_003DzJ8mo6CtnYuOH;

	protected _0023_003Dz7EU3jafgrAIj0FjRJ8wRX1Q_003D(uint _0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D, _0023_003Dzx5fE0Zn26f8WRpa4yw_003D_003D _0023_003DzHFWw_0024Winsv58, uint _0023_003DzaBqMvIM_003D, ulong _0023_003DzOexSNccKtJF3ctwInA_003D_003D)
		: base(_0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D)
	{
		_0023_003DziZiYS_Z2g6V4 = _0023_003DzOexSNccKtJF3ctwInA_003D_003D;
		_0023_003Dzc_00245BnRNRPPXZ = _0023_003DzHFWw_0024Winsv58._0023_003Dz8o203vM_003D();
		_0023_003Dz9sKZ9PHz8Ffc = new byte[1024];
		_0023_003DzbjEb2DprcGBMa9lOjA_003D_003D = _0023_003DzaBqMvIM_003D;
		_0023_003DzodMbknGRQ4dL = 8 * _0023_003DzaBqMvIM_003D;
		_0023_003DzJ8mo6CtnYuOH = _0023_003DzaBqMvIM_003D;
	}

	public override void _0023_003DzMg9bxbfatU4O(List<_0023_003Dzx5fE0Zn26f8WRpa4yw_003D_003D> _0023_003DzyNW3mwgz7siS)
	{
		throw new NotImplementedException();
	}

	public override ulong _0023_003DzZkJvuMa2VlcO()
	{
		return _0023_003Dz2F1zp4WtKF3x;
	}

	public override void _0023_003Dz5jgTNkw_003D()
	{
		throw new NotImplementedException();
	}

	public override ulong _0023_003Dzhg1xWL4_003D(byte[] _0023_003Dzb7SPTpc_003D, ulong _0023_003DzFJclkK7lBGxx)
	{
		ulong num = _0023_003DzFJclkK7lBGxx;
		ulong num2 = 0uL;
		int num3 = 0;
		do
		{
			ulong val = (ulong)(_0023_003Dz9sKZ9PHz8Ffc.Length - (int)_0023_003DzUmHxlBh2ZSmoTFH7Aw_003D_003D);
			ulong num4 = Math.Min(num, val);
			if (num4 != 0 && _0023_003Dzb7SPTpc_003D != null)
			{
				Buffer.BlockCopy(_0023_003Dzb7SPTpc_003D, num3, _0023_003Dz9sKZ9PHz8Ffc, (int)_0023_003DzUmHxlBh2ZSmoTFH7Aw_003D_003D, (int)num4);
				_0023_003DzUmHxlBh2ZSmoTFH7Aw_003D_003D += num4;
				num -= num4;
				num3 += (int)num4;
			}
			ulong num5 = _0023_003DzOd5CfukXmb4j6iYm0g_003D_003D / _0023_003DzodMbknGRQ4dL;
			ulong num6 = num5 * _0023_003DzodMbknGRQ4dL;
			ulong num7 = _0023_003DzUmHxlBh2ZSmoTFH7Aw_003D_003D * 8;
			int num8 = (int)(num5 * _0023_003DzJ8mo6CtnYuOH);
			int length = _0023_003Dz9sKZ9PHz8Ffc.Length - num8;
			Span<byte> span = new Span<byte>(_0023_003Dz9sKZ9PHz8Ffc, num8, length);
			ulong _0023_003DzNYxlP17PRu = _0023_003DzOd5CfukXmb4j6iYm0g_003D_003D - num6;
			ulong _0023_003Dzv1TeLYMxx2me = num7 - num6;
			num2 = _0023_003DzlR6_0024bFKxIO9L(span.ToArray(), _0023_003DzNYxlP17PRu, _0023_003Dzv1TeLYMxx2me);
			if (num2 > num7 - _0023_003DzOd5CfukXmb4j6iYm0g_003D_003D)
			{
				throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302741716));
			}
			_0023_003DzOd5CfukXmb4j6iYm0g_003D_003D += num2;
			_0023_003DzPRsv9IEQNtPapOpR9Q_003D_003D();
		}
		while (num != 0 && num2 != 0);
		return _0023_003DzFJclkK7lBGxx - num;
	}

	public abstract ulong _0023_003DzlR6_0024bFKxIO9L(byte[] _0023_003DzK42AOhaAnl4C, ulong _0023_003DzNYxlP17PRu00, ulong _0023_003Dzv1TeLYMxx2me);

	protected void _0023_003DzPRsv9IEQNtPapOpR9Q_003D_003D()
	{
		int num = (int)((int)(_0023_003DzOd5CfukXmb4j6iYm0g_003D_003D / _0023_003DzodMbknGRQ4dL) * _0023_003DzJ8mo6CtnYuOH);
		ulong num2 = _0023_003DzUmHxlBh2ZSmoTFH7Aw_003D_003D - (ulong)num;
		if (num2 != 0)
		{
			Buffer.BlockCopy(_0023_003Dz9sKZ9PHz8Ffc, num, _0023_003Dz9sKZ9PHz8Ffc, 0, (int)num2);
		}
		_0023_003DzUmHxlBh2ZSmoTFH7Aw_003D_003D = num2;
		_0023_003DzOd5CfukXmb4j6iYm0g_003D_003D %= _0023_003DzodMbknGRQ4dL;
	}

	public override void _0023_003Dzg2_DE0s_003D(int _0023_003Dz2gwSqZQ_003D = 0, TextWriter _0023_003DzDdJAEBo_003D = null)
	{
		_0023_003DzDdJAEBo_003D.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302741691), _0023_003DzTmjmTPw_003D(_0023_003Dz2gwSqZQ_003D), _0023_003Dz3odrLmAOqmwqjh5ckysR1iQ_003D));
		_0023_003DzDdJAEBo_003D.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302741634), _0023_003DzTmjmTPw_003D(_0023_003Dz2gwSqZQ_003D), _0023_003Dz2F1zp4WtKF3x));
		_0023_003DzDdJAEBo_003D.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742375), _0023_003DzTmjmTPw_003D(_0023_003Dz2gwSqZQ_003D), _0023_003DziZiYS_Z2g6V4));
		_0023_003DzDdJAEBo_003D.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742342), _0023_003DzTmjmTPw_003D(_0023_003Dz2gwSqZQ_003D), _0023_003DzOd5CfukXmb4j6iYm0g_003D_003D));
		_0023_003DzDdJAEBo_003D.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742336), _0023_003DzTmjmTPw_003D(_0023_003Dz2gwSqZQ_003D), _0023_003DzUmHxlBh2ZSmoTFH7Aw_003D_003D));
		_0023_003DzDdJAEBo_003D.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742304), _0023_003DzTmjmTPw_003D(_0023_003Dz2gwSqZQ_003D), _0023_003DzbjEb2DprcGBMa9lOjA_003D_003D));
		_0023_003DzDdJAEBo_003D.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742510), _0023_003DzTmjmTPw_003D(_0023_003Dz2gwSqZQ_003D), _0023_003DzodMbknGRQ4dL));
		_0023_003DzDdJAEBo_003D.WriteLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742450), _0023_003DzTmjmTPw_003D(_0023_003Dz2gwSqZQ_003D), _0023_003DzJ8mo6CtnYuOH));
		_0023_003DzDdJAEBo_003D.WriteLine(_0023_003DzTmjmTPw_003D(_0023_003Dz2gwSqZQ_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742421));
	}

	public static string _0023_003DzTmjmTPw_003D(int _0023_003DzoMNiNRw_003D)
	{
		return new string(' ', _0023_003DzoMNiNRw_003D);
	}
}

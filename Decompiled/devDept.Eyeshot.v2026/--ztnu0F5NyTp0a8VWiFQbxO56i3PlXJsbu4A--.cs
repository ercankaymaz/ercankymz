using System;

internal sealed class _0023_003Dztnu0F5NyTp0a8VWiFQbxO56i3PlXJsbu4A_003D_003D
{
	public static _0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D _0023_003DzQMOprrfIjwmiNAjVAOKC9Fc_003D(_0023_003DzcQiRB3Mv_00246WF _0023_003DzDVubtvo_003D, _0023_003DzcQiRB3Mv_00246WF _0023_003DzFj_0024IqDQ_003D, double _0023_003DzEGKj_0024SNUUihi, _0023_003DzcQiRB3Mv_00246WF _0023_003Dzf_Rt84OefYwvXlaqiw_003D_003D)
	{
		_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D _0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2 = new _0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D();
		double num = _0023_003DzDVubtvo_003D._0023_003DzR216mFc_003D();
		double num2 = _0023_003DzDVubtvo_003D._0023_003DzqJqZpJk_003D();
		double num3 = _0023_003DzFj_0024IqDQ_003D._0023_003DzR216mFc_003D() - _0023_003DzDVubtvo_003D._0023_003DzR216mFc_003D();
		double num4 = _0023_003DzFj_0024IqDQ_003D._0023_003DzqJqZpJk_003D() - _0023_003DzDVubtvo_003D._0023_003DzqJqZpJk_003D();
		double num5 = _0023_003Dzf_Rt84OefYwvXlaqiw_003D_003D._0023_003DzR216mFc_003D();
		double num6 = _0023_003Dzf_Rt84OefYwvXlaqiw_003D_003D._0023_003DzqJqZpJk_003D();
		if (Math.Abs(num3) < Math.Abs(num4))
		{
			double num7 = num4;
			num4 = num3;
			num3 = num7;
			double num8 = num6;
			num6 = num5;
			num5 = num8;
			double num9 = num2;
			num2 = num;
			num = num9;
		}
		double num10 = num4 / num3;
		double num11 = num2 - num10 * num;
		double num12 = 1.0 + num10 * num10;
		if (Math.Abs(num12) < 1E-08)
		{
			double num13 = num - num5;
			double num14 = num2 - num6;
			if (_0023_003Dz4bQB7f9e8mCtX_ivosmY4ynvt_I_0024VHY6ew_003D_003D._0023_003Dzgr6OWgJnCIU5(num13 * num13 + num14 * num14, _0023_003DzEGKj_0024SNUUihi * _0023_003DzEGKj_0024SNUUihi))
			{
				_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2._0023_003DzacztcRTIKBEG = 1;
				_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2._0023_003DzDSaZWik_003D = 0.0;
			}
			else
			{
				_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2._0023_003DzacztcRTIKBEG = 0;
			}
		}
		else
		{
			double num15 = 2.0 * num10 * num11 - 2.0 * num5 - 2.0 * num10 * num6;
			double num16 = num5 * num5 + num6 * num6 + num11 * num11 - 2.0 * num11 * num6 - _0023_003DzEGKj_0024SNUUihi * _0023_003DzEGKj_0024SNUUihi;
			double num17 = num15 * num15 - 4.0 * num12 * num16;
			if (Math.Abs(num17) < 1E-08)
			{
				_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2._0023_003DzacztcRTIKBEG = 1;
				double num18 = (0.0 - num15) / (2.0 * num12);
				_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2._0023_003DzDSaZWik_003D = (num18 - num) / num3;
			}
			else if (num17 < 0.0)
			{
				_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2._0023_003DzacztcRTIKBEG = 0;
			}
			else
			{
				_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2._0023_003DzacztcRTIKBEG = 2;
				Tuple<double, double> tuple = _0023_003Dz4bQB7f9e8mCtX_ivosmY4ynvt_I_0024VHY6ew_003D_003D._0023_003DzpCFqicifCRJ_3loCCg_003D_003D(num12, num15, num16, num17);
				_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2._0023_003DzDSaZWik_003D = (tuple.Item1 - num) / num3;
				_0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2._0023_003DzsK_Xndk_003D = (tuple.Item2 - num) / num3;
			}
		}
		return _0023_003DzhSn1zNkWcox22Uhx10UDVSY16Z8iKfytXQ_003D_003D2;
	}
}

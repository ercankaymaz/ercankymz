using System;
using System.Threading;

internal static class _0023_003DqPacQ3FeX7fTjZ97pVfwPYdJkKvJzPRiAfEjIywVKiXU_003D
{
	public static _0023_003DqokHK_cUOtnj3sNXR4_J_JGyd7MWVblsGDjoZNXi163k_003D _0023_003DzFfJhDHlzLVznJVkql7v3xglNsHzUeTvJGg_003D_003D()
	{
		return _0023_003Dz8HOMNe_0024LHExWfLDcYg1fcrU_003D() ?? new _0023_003DqqA_0024mLT03a6Jqga8x0590_1sfM3HeFP4P_0024mYLkg9xVRU_003D();
	}

	private static _0023_003DqokHK_cUOtnj3sNXR4_J_JGyd7MWVblsGDjoZNXi163k_003D _0023_003Dz8HOMNe_0024LHExWfLDcYg1fcrU_003D()
	{
		try
		{
			_0023_003DqCYtpYjw7PR14CpnIyTweyqubn1nOzmY2x19_mw_JyQA_003D _0023_003DqCYtpYjw7PR14CpnIyTweyqubn1nOzmY2x19_mw_JyQA_003D2 = new _0023_003DqCYtpYjw7PR14CpnIyTweyqubn1nOzmY2x19_mw_JyQA_003D();
			if (!_0023_003Dz59Pc9aY5YNzUQVolJvTx1rKY_t17(_0023_003DqCYtpYjw7PR14CpnIyTweyqubn1nOzmY2x19_mw_JyQA_003D2))
			{
				_0023_003DqCYtpYjw7PR14CpnIyTweyqubn1nOzmY2x19_mw_JyQA_003D2.Dispose();
				return null;
			}
			return _0023_003DqCYtpYjw7PR14CpnIyTweyqubn1nOzmY2x19_mw_JyQA_003D2;
		}
		catch (Exception _0023_003DzjYYAPCA_003D) when (!_0023_003Dz7buxMZj38Z_UK6lozgNNj0Levi3S(_0023_003DzjYYAPCA_003D))
		{
			return null;
		}
	}

	private static bool _0023_003Dz7buxMZj38Z_UK6lozgNNj0Levi3S(Exception _0023_003DzjYYAPCA_003D)
	{
		if (!(_0023_003DzjYYAPCA_003D is ThreadAbortException))
		{
			return _0023_003DzjYYAPCA_003D is ThreadInterruptedException;
		}
		return true;
	}

	private static bool _0023_003Dz59Pc9aY5YNzUQVolJvTx1rKY_t17(_0023_003DqokHK_cUOtnj3sNXR4_J_JGyd7MWVblsGDjoZNXi163k_003D _0023_003DzjYYAPCA_003D)
	{
		byte[] array = new byte[3] { 0, 130, 255 };
		for (int i = 0; i < array.Length; i++)
		{
			byte _0023_003DzVC9FBdo_003D = array[i];
			_0023_003DzjYYAPCA_003D._0023_003DzvNQqK_0024BjjIY9Y4ldB7rODa1hFaVzgq_0024DYF5Zw_0024NFAtSTZErtmcA_HBAYIrz9NhS_00242flOuq_7UUXMTIV6CM1rar0_003D(i, ref _0023_003DzVC9FBdo_003D);
		}
		if (_0023_003DzjYYAPCA_003D._0023_003DzfVLl9guJQ11BDKy_LRjFuxAYjkZtCfNnn1k1JSFtuUZAshlHeNxmseO4LkYMQXwKRRyAxp2yh9YNtWFUM1SeEPeqBslu() != array.Length)
		{
			return false;
		}
		for (int j = 0; j < array.Length; j++)
		{
			_0023_003DzjYYAPCA_003D._0023_003Dz6Sd4lL7SfNtIRvzJ9lKZPCaYmAgOgAXs_GdbjiPIpKRdYtzCSSW17G_ZdlNdoy3lOsSgAXX6JE6h(j, out var _0023_003DzVC9FBdo_003D2);
			if (_0023_003DzVC9FBdo_003D2 != array[j])
			{
				return false;
			}
		}
		_0023_003DzjYYAPCA_003D._0023_003DzgHzfCf7k7OzyB2e4cb6VXV9cubUORtGgF1wy122mmEHUuDsbwUTny4WLbyyooEla15_0024EWI8_003D();
		if (_0023_003DzjYYAPCA_003D._0023_003DzfVLl9guJQ11BDKy_LRjFuxAYjkZtCfNnn1k1JSFtuUZAshlHeNxmseO4LkYMQXwKRRyAxp2yh9YNtWFUM1SeEPeqBslu() != 0)
		{
			return false;
		}
		return true;
	}
}

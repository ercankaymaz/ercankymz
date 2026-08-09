using System;
using System.Threading;

internal static class _0023_003DqtbJxvJw6M0U0jdSJFXU4FjFuVjh9ZHFKmIHW3YEgOmo_003D
{
	public static _0023_003DqI_0024qdFH6tAfuROz8_nUFyO5dNm2DCLf_0024KwxG_1CUeCc0_003D _0023_003DzuwiOCLWsteq3Y3SHKb1JMdVMrP6sAJr7qg_003D_003D()
	{
		return _0023_003Dz7ElnjgZ1wYcLCvJs3qo4SJc_003D() ?? new _0023_003Dq1eZmN4_0024GSvLD2ByEbZhhvpT2Nxn3vT40rOk2ZcJZ4vM_003D();
	}

	private static _0023_003DqI_0024qdFH6tAfuROz8_nUFyO5dNm2DCLf_0024KwxG_1CUeCc0_003D _0023_003Dz7ElnjgZ1wYcLCvJs3qo4SJc_003D()
	{
		try
		{
			_0023_003DqBfza9v7YChMLWqd8ZuVriNjsq_YZLcoLnX4ZgZ1hpWc_003D _0023_003DqBfza9v7YChMLWqd8ZuVriNjsq_YZLcoLnX4ZgZ1hpWc_003D2 = new _0023_003DqBfza9v7YChMLWqd8ZuVriNjsq_YZLcoLnX4ZgZ1hpWc_003D();
			if (!_0023_003DzGH9pyYwnSYNJxdClh7alrmg_Apvr(_0023_003DqBfza9v7YChMLWqd8ZuVriNjsq_YZLcoLnX4ZgZ1hpWc_003D2))
			{
				_0023_003DqBfza9v7YChMLWqd8ZuVriNjsq_YZLcoLnX4ZgZ1hpWc_003D2.Dispose();
				return null;
			}
			return _0023_003DqBfza9v7YChMLWqd8ZuVriNjsq_YZLcoLnX4ZgZ1hpWc_003D2;
		}
		catch (Exception _0023_003DziDLVpbY_003D) when (!_0023_003Dz7fGH_0024xvpm_lI8HYS2G0JqhWEvN5X(_0023_003DziDLVpbY_003D))
		{
			return null;
		}
	}

	private static bool _0023_003Dz7fGH_0024xvpm_lI8HYS2G0JqhWEvN5X(Exception _0023_003DziDLVpbY_003D)
	{
		if (!(_0023_003DziDLVpbY_003D is ThreadAbortException))
		{
			return _0023_003DziDLVpbY_003D is ThreadInterruptedException;
		}
		return true;
	}

	private static bool _0023_003DzGH9pyYwnSYNJxdClh7alrmg_Apvr(_0023_003DqI_0024qdFH6tAfuROz8_nUFyO5dNm2DCLf_0024KwxG_1CUeCc0_003D _0023_003DziDLVpbY_003D)
	{
		byte[] array = new byte[3] { 0, 130, 255 };
		for (int i = 0; i < array.Length; i++)
		{
			byte _0023_003Dz5rQzobg_003D = array[i];
			_0023_003DziDLVpbY_003D._0023_003Dz6be2z7fYqX2PEDwC0r7GHQRYTC_0024i47u6CragQyPAO224uxzC95BUOZZayzbk87k_dY20GHpDKJ3dQ0MVRypsYFc_003D(i, ref _0023_003Dz5rQzobg_003D);
		}
		if (_0023_003DziDLVpbY_003D._0023_003DzX67Fgyn0f8jfep_0024QyxTcb0WDhzzd3D47UExChgN5NonIRwIhuJ7EwC78_0024QuqUYNLW_0024sxA0f1cQFs_l1j5rUBPUiu2HAq() != array.Length)
		{
			return false;
		}
		for (int j = 0; j < array.Length; j++)
		{
			_0023_003DziDLVpbY_003D._0023_003DzRxycHi1jY4j_wp8cfffJtRdGTXkCFnOnbXcszMUbQJbjxjPhzjNHdHW_Yyms65JuwDxCsqFeoaOL(j, out var _0023_003Dz5rQzobg_003D2);
			if (_0023_003Dz5rQzobg_003D2 != array[j])
			{
				return false;
			}
		}
		_0023_003DziDLVpbY_003D._0023_003Dz0GOe4nZ54B4Hs8VL7hNOyjyIYNB9dJAcWXPfYkqHTdDRzrBNx_0024_OZj6it0mp_0024qzwrzTaE6c_003D();
		if (_0023_003DziDLVpbY_003D._0023_003DzX67Fgyn0f8jfep_0024QyxTcb0WDhzzd3D47UExChgN5NonIRwIhuJ7EwC78_0024QuqUYNLW_0024sxA0f1cQFs_l1j5rUBPUiu2HAq() != 0)
		{
			return false;
		}
		return true;
	}
}

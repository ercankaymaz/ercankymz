using System;
using System.Threading;

internal static class _0023_003DqER3f_gxDAqhvJuR_0024dnNr_bfAzNwT_73IKmoIa16Tp68_003D
{
	public static _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCRfBVkIJ6g7sMnXA5H8CU9w_003D _0023_003Dz_7vVhDUGvtas_00241mVIgU_OCPN3ssV3eQwJA_003D_003D()
	{
		return _0023_003DzHNdGBEAy9oN1ynvCdeP22k4_003D() ?? new _0023_003DqluIhkfU76QJuQlzV2eZsN8hvJgHBWV8_00244yclO7fYPpQ_003D();
	}

	private static _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCRfBVkIJ6g7sMnXA5H8CU9w_003D _0023_003DzHNdGBEAy9oN1ynvCdeP22k4_003D()
	{
		try
		{
			_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdfkDlolsJuW2U2RYw17s5j0_003D _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdfkDlolsJuW2U2RYw17s5j0_003D2 = new _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdfkDlolsJuW2U2RYw17s5j0_003D();
			if (!_0023_003DzSJ0qiOs08ayeS5qRYwAh13jjXaj_(_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdfkDlolsJuW2U2RYw17s5j0_003D2))
			{
				_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdfkDlolsJuW2U2RYw17s5j0_003D2.Dispose();
				return null;
			}
			return _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdfkDlolsJuW2U2RYw17s5j0_003D2;
		}
		catch (Exception _0023_003Dzq80RbjQ_003D) when (!_0023_003Dz9u_4XGZ_kM8ctDDq7_0024tV0dzb9u5J(_0023_003Dzq80RbjQ_003D))
		{
			return null;
		}
	}

	private static bool _0023_003Dz9u_4XGZ_kM8ctDDq7_0024tV0dzb9u5J(Exception _0023_003Dzq80RbjQ_003D)
	{
		if (!(_0023_003Dzq80RbjQ_003D is ThreadAbortException))
		{
			return _0023_003Dzq80RbjQ_003D is ThreadInterruptedException;
		}
		return true;
	}

	private static bool _0023_003DzSJ0qiOs08ayeS5qRYwAh13jjXaj_(_0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCRfBVkIJ6g7sMnXA5H8CU9w_003D _0023_003Dzq80RbjQ_003D)
	{
		byte[] array = new byte[3] { 0, 130, 255 };
		for (int i = 0; i < array.Length; i++)
		{
			byte _0023_003DzZzVr6_0024U_003D = array[i];
			_0023_003Dzq80RbjQ_003D._0023_003DznuGnbDrfmx_0024J0fjFtOULWj4_E76__00243bC66oqcos5vODkk66EtFukcnpeFM6UCBnXQPDu4bnhXef8uKg7LR1fE1w_003D(i, ref _0023_003DzZzVr6_0024U_003D);
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzIQalVa_aHfzVUQ3sYhbar_Ni62EZeZpf6UgqP7i2m42SUid_ZFLEZaMQxAbTpULH8r1y2JDeT61FxKPKgpApviA2CLz8() != array.Length)
		{
			return false;
		}
		for (int j = 0; j < array.Length; j++)
		{
			_0023_003Dzq80RbjQ_003D._0023_003DzuExStp_0024rmmlysNxz4DRwMvkk7nCfcrnBvgBIDaV_IiRtycy6Z94SpM7etFS22iedgWtajcHK1ElY(j, out var _0023_003DzZzVr6_0024U_003D2);
			if (_0023_003DzZzVr6_0024U_003D2 != array[j])
			{
				return false;
			}
		}
		_0023_003Dzq80RbjQ_003D._0023_003DzXCtz2cJOCM0S8YNTRzENhFoYOLMACGWGCx0qUJKL2LukaKYnpBR_0024lwc4MTgbUAks1lWGL8s_003D();
		if (_0023_003Dzq80RbjQ_003D._0023_003DzIQalVa_aHfzVUQ3sYhbar_Ni62EZeZpf6UgqP7i2m42SUid_ZFLEZaMQxAbTpULH8r1y2JDeT61FxKPKgpApviA2CLz8() != 0)
		{
			return false;
		}
		return true;
	}
}

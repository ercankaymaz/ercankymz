using System;

internal sealed class _0023_003DqHG1TmG_0024dSF7XquINMc2Zz70dWtTQ2CxWuU2XR_0024MiL8c_003D : _0023_003Dq6ddeMh0jPjn0m3HHEFyd_UzyP04hcfbzuH_iOk0_4Fk_003D
{
	public _0023_003DqHG1TmG_0024dSF7XquINMc2Zz70dWtTQ2CxWuU2XR_0024MiL8c_003D(byte[] _0023_003Dzq80RbjQ_003D, long _0023_003DzZzVr6_0024U_003D)
		: base(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D)
	{
	}

	public byte[] _0023_003Dz7GzVKHigmAjHE5FVN5SuT1iQo6K1(_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003Dzq80RbjQ_003D, _0023_003DqVLE856NmzWhU_bIXHFUSoDjqdfF7lwkwCPJ5_X5_0024J1M_003D _0023_003DzZzVr6_0024U_003D)
	{
		byte[] array = new byte[4];
		_0023_003Dz8Zr2TyQwQXtkcxW1uw_003D_003D(_0023_003Dzq80RbjQ_003D, array, 0, array.Length);
		int num = _0023_003Dq6ddeMh0jPjn0m3HHEFyd_UzyP04hcfbzuH_iOk0_4Fk_003D._0023_003DzrjUa6ufn96h0LfoNASi2lhZjv4UqxBJdLQ_003D_003D(_0023_003DzzbA91WKeCBMbNibzdeL7HDfdb_00246qUxDBRjg_00247zDof9N4(array, _0023_003DzZzVr6_0024U_003D: false), 0);
		int num2 = _0023_003Dq6ddeMh0jPjn0m3HHEFyd_UzyP04hcfbzuH_iOk0_4Fk_003D._0023_003DzPfA3Uw7vkcjX8tmk6mF4leo_003D(num);
		int value = num2 - 4;
		byte[] array2 = new byte[num2];
		_0023_003Dz8Zr2TyQwQXtkcxW1uw_003D_003D(_0023_003Dzq80RbjQ_003D, array2, 4, value);
		Buffer.BlockCopy(array, 0, array2, 0, 4);
		byte[] src = _0023_003DzzbA91WKeCBMbNibzdeL7HDfdb_00246qUxDBRjg_00247zDof9N4(array2, _0023_003DzZzVr6_0024U_003D: false);
		byte[] array3 = new byte[num];
		Buffer.BlockCopy(src, 4, array3, 0, num);
		return array3;
	}

	public byte[] _0023_003DzvW1Tj3yhaCWILuhfYlt_ReQ4x9e5(byte[] _0023_003Dzq80RbjQ_003D)
	{
		byte[] src = _0023_003DzzbA91WKeCBMbNibzdeL7HDfdb_00246qUxDBRjg_00247zDof9N4(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D: false);
		int num = _0023_003Dq6ddeMh0jPjn0m3HHEFyd_UzyP04hcfbzuH_iOk0_4Fk_003D._0023_003DzrjUa6ufn96h0LfoNASi2lhZjv4UqxBJdLQ_003D_003D(src, 0);
		byte[] array = new byte[num];
		Buffer.BlockCopy(src, 4, array, 0, num);
		return array;
	}

	private static void _0023_003Dz8Zr2TyQwQXtkcxW1uw_003D_003D(_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, int? _0023_003DzcbLoSrg_003D)
	{
		int num = _0023_003DzcbLoSrg_003D ?? (_0023_003DzZzVr6_0024U_003D.Length - _0023_003Dz7hRN5Rg_003D);
		int num2;
		while ((num2 = _0023_003Dzq80RbjQ_003D._0023_003DzJOoT4gsPGoibAzkPGQ31PpiYn_hZ3qvRCOxibWgYa3KnAQHxK9Wt69jVIDs25kwu05DuT1KcBeXXwLt8kA_003D_003D(_0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, num)) > 0)
		{
			_0023_003Dz7hRN5Rg_003D += num2;
			num -= num2;
		}
	}
}

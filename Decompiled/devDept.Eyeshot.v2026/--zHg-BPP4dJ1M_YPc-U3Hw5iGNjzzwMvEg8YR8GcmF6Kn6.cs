using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using devDept;

internal sealed class _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<string, string[]> _0023_003Dz1_0024Aj5hrJaAa4ofcrCw_003D_003D;

		public static Func<string[], int> _0023_003Dzn4WoGQzxG5TqtWY9sA_003D_003D;

		internal string[] _0023_003Dz5sNJLDZzvbjrL7nZdw_003D_003D(string _0023_003DzuwH5j5s_003D)
		{
			return _0023_003DzuwH5j5s_003D.Split(_0023_003DzMPj1xH0USdrb);
		}

		internal int _0023_003Dz1H_HCjlbgzn_ZMpgbQ_003D_003D(string[] _0023_003DzxwaSN1c_003D)
		{
			return _0023_003DzxwaSN1c_003D.Length;
		}
	}

	private static readonly char[] _0023_003DzMPj1xH0USdrb = new char[2] { '/', '\\' };

	internal static string _0023_003Dzz6JDud_0024u1ojF(string _0023_003Dzsuiz4uo_003D, bool _0023_003Dzmyw8uNw_003D)
	{
		string _0023_003Dzsuiz4uo_003D2 = _0023_003Dzsuiz4uo_003D;
		_0023_003DzaWKgHquahf_0024G(ref _0023_003Dzsuiz4uo_003D2, _0023_003Dzmyw8uNw_003D);
		return _0023_003Dzsuiz4uo_003D2;
	}

	internal static bool _0023_003DzaWKgHquahf_0024G(ref string _0023_003Dzsuiz4uo_003D, bool _0023_003Dzmyw8uNw_003D)
	{
		bool result = true;
		try
		{
			_0023_003Dzsuiz4uo_003D = Path.GetFullPath(_0023_003Dzsuiz4uo_003D);
		}
		catch
		{
			if (_0023_003Dzmyw8uNw_003D)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998269) + _0023_003Dzsuiz4uo_003D);
			}
			result = false;
		}
		return result;
	}

	internal static string _0023_003Dz1iP7XTo_003D(string _0023_003DzDRLR64c_003D, string[] _0023_003DzWsbHO94_003D)
	{
		string[][] array = _0023_003DzWsbHO94_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz5sNJLDZzvbjrL7nZdw_003D_003D).ToArray();
		string[] array2 = new string[((IEnumerable<string[]>)array).Sum((Func<string[], int>)_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz1H_HCjlbgzn_ZMpgbQ_003D_003D) + 1];
		array2[0] = _0023_003DzDRLR64c_003D;
		int num = 0;
		string[][] array3 = array;
		foreach (string[] array4 in array3)
		{
			foreach (string text in array4)
			{
				num++;
				array2[num] = text;
			}
		}
		return Path.Combine(array2);
	}
}

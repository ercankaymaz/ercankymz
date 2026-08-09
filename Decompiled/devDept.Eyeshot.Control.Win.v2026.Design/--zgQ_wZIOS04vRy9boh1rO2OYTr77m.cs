using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

internal static class _0023_003DzgQ_wZIOS04vRy9boh1rO2OYTr77m
{
	private sealed class _0023_003Dz1MA8u1E9_0024CGzU2AwLmVLuVaXBfba
	{
		private readonly string _0023_003DzoGlXBGsRZUcI_zyJcSIKXEhH1KvE;

		private volatile Assembly _0023_003Dz64f7xe7bgm4n9p6KtGmoeR3aBpAc;

		internal _0023_003Dz1MA8u1E9_0024CGzU2AwLmVLuVaXBfba(string _0023_003DzsHryZoG7DRB9qrEsF5nwSMMiPevr)
		{
			_0023_003DzoGlXBGsRZUcI_zyJcSIKXEhH1KvE = _0023_003DzsHryZoG7DRB9qrEsF5nwSMMiPevr;
		}

		internal Assembly _0023_003Dzy1x699zIf_0024cD6wefr4VUsWmOV_00248h()
		{
			if ((object)_0023_003Dz64f7xe7bgm4n9p6KtGmoeR3aBpAc == null)
			{
				lock (this)
				{
					if ((object)_0023_003Dz64f7xe7bgm4n9p6KtGmoeR3aBpAc == null)
					{
						_0023_003Dz64f7xe7bgm4n9p6KtGmoeR3aBpAc = _0023_003DzvGIpV8NPhqbe_0024FIbj12ouXvrmR5Z(_0023_003DzoGlXBGsRZUcI_zyJcSIKXEhH1KvE);
					}
				}
			}
			return _0023_003Dz64f7xe7bgm4n9p6KtGmoeR3aBpAc;
		}

		private static Assembly _0023_003DzvGIpV8NPhqbe_0024FIbj12ouXvrmR5Z(string _0023_003DzDiqVVd7yDyPaYcTOplQCLbA_003D)
		{
			return _0023_003DzfjT7Eit3rFpkIqO_0024WhOaMOr8PS8G._0023_003DzCR5Jlyc_003D(_0023_003DzDiqVVd7yDyPaYcTOplQCLbA_003D) ?? Assembly.Load(_0023_003DzDiqVVd7yDyPaYcTOplQCLbA_003D);
		}
	}

	private static readonly Assembly _0023_003Dz64f7xe7bgm4n9p6KtGmoeR3aBpAc;

	private static volatile Dictionary<string, _0023_003Dz1MA8u1E9_0024CGzU2AwLmVLuVaXBfba> _0023_003DzU5VOq6qs2hkgb4wJ6O_0024Sw1bxdxIq;

	[ThreadStatic]
	private static bool _0023_003DzWuKJJNwNz8BNpuPF38VJV12VTFxs;

	static _0023_003DzgQ_wZIOS04vRy9boh1rO2OYTr77m()
	{
		_0023_003Dz64f7xe7bgm4n9p6KtGmoeR3aBpAc = typeof(_0023_003DzgQ_wZIOS04vRy9boh1rO2OYTr77m).Assembly;
	}

	internal static void _0023_003Dznx1EMIs_003D()
	{
		AppDomain.CurrentDomain.ResourceResolve += _0023_003Dz3VV4dL7zrGNoTAVbuXUyK8HFCDMh;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0023_003Dz3VV4dL7zrGNoTAVbuXUyK8HFCDMh(object _0023_003DzKAXfcvL5A5zxisKcphxDmn47sgAY, ResolveEventArgs _0023_003DzzWEv9tgqAMJbrkH3VRHaWcXKm05t)
	{
		if ((object)_0023_003DzzWEv9tgqAMJbrkH3VRHaWcXKm05t.RequestingAssembly != _0023_003Dz64f7xe7bgm4n9p6KtGmoeR3aBpAc)
		{
			return null;
		}
		if (_0023_003DzWuKJJNwNz8BNpuPF38VJV12VTFxs)
		{
			return null;
		}
		return _0023_003DzQaLBHS6oJELZTeUyZh_SyJKG6b9t(_0023_003DzzWEv9tgqAMJbrkH3VRHaWcXKm05t.Name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0023_003DzQaLBHS6oJELZTeUyZh_SyJKG6b9t(string _0023_003Dz9Jf_0024xv0_003D)
	{
		_0023_003DzWuKJJNwNz8BNpuPF38VJV12VTFxs = true;
		try
		{
			_0023_003DzV_0024DCht10Z0eX9nZmKOcZhecUxA8t();
			if (!_0023_003DzU5VOq6qs2hkgb4wJ6O_0024Sw1bxdxIq.TryGetValue(_0023_003Dz9Jf_0024xv0_003D, out var value))
			{
				return null;
			}
			return value._0023_003Dzy1x699zIf_0024cD6wefr4VUsWmOV_00248h();
		}
		finally
		{
			_0023_003DzWuKJJNwNz8BNpuPF38VJV12VTFxs = false;
		}
	}

	private static void _0023_003DzV_0024DCht10Z0eX9nZmKOcZhecUxA8t()
	{
		if (_0023_003DzU5VOq6qs2hkgb4wJ6O_0024Sw1bxdxIq != null)
		{
			return;
		}
		lock (_0023_003Dz64f7xe7bgm4n9p6KtGmoeR3aBpAc)
		{
			if (_0023_003DzU5VOq6qs2hkgb4wJ6O_0024Sw1bxdxIq != null)
			{
				return;
			}
			string text = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564315978);
			string[] array = text.Split(':');
			int num = array.Length;
			Dictionary<string, _0023_003Dz1MA8u1E9_0024CGzU2AwLmVLuVaXBfba> dictionary = new Dictionary<string, _0023_003Dz1MA8u1E9_0024CGzU2AwLmVLuVaXBfba>(3, StringComparer.Ordinal);
			for (int i = 0; i != num; i++)
			{
				string text2 = array[i];
				string[] array2 = text2.Split('|');
				_0023_003Dz1MA8u1E9_0024CGzU2AwLmVLuVaXBfba value = new _0023_003Dz1MA8u1E9_0024CGzU2AwLmVLuVaXBfba(array2[0]);
				int num2 = array2.Length;
				for (int j = 1; j != num2; j++)
				{
					string key = array2[j];
					dictionary.Add(key, value);
				}
			}
			_0023_003DzU5VOq6qs2hkgb4wJ6O_0024Sw1bxdxIq = dictionary;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

internal static class _0023_003DzbgJPRJR9RQcanjv8_0024d91sDUu_00244yX
{
	private sealed class _0023_003Dz4hJpxeKEbUofjxFZYCcrPoSvLKW_0024
	{
		private readonly string _0023_003DzE0ZG1y33N64li0_OycvOYFBY91rR;

		private volatile Assembly _0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU;

		internal _0023_003Dz4hJpxeKEbUofjxFZYCcrPoSvLKW_0024(string _0023_003DzZ92HEzgY0NtIA55GThtwzYcooEcJ)
		{
			_0023_003DzE0ZG1y33N64li0_OycvOYFBY91rR = _0023_003DzZ92HEzgY0NtIA55GThtwzYcooEcJ;
		}

		internal Assembly _0023_003DzwQ0mbBaV1wfD6kEmLMcMbWRoH5vT()
		{
			if ((object)_0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU == null)
			{
				lock (this)
				{
					if ((object)_0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU == null)
					{
						_0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU = _0023_003DzqbJ822Ku6fB_6MBCogJgH6KqsbuB(_0023_003DzE0ZG1y33N64li0_OycvOYFBY91rR);
					}
				}
			}
			return _0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU;
		}

		private static Assembly _0023_003DzqbJ822Ku6fB_6MBCogJgH6KqsbuB(string _0023_003Dz8epo6K_0024_0024pyCnhVht1PcTlPk_003D)
		{
			return _0023_003Dzo2vT_xDsdJ7qFMhM_0024AerELgo9GU6._0023_003Dz6It9KyA_003D(_0023_003Dz8epo6K_0024_0024pyCnhVht1PcTlPk_003D) ?? Assembly.Load(_0023_003Dz8epo6K_0024_0024pyCnhVht1PcTlPk_003D);
		}
	}

	private static readonly Assembly _0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU;

	private static volatile Dictionary<string, _0023_003Dz4hJpxeKEbUofjxFZYCcrPoSvLKW_0024> _0023_003DzDx_0024P8TI4Lu3BVQa66lH4lNzZMRqC;

	[ThreadStatic]
	private static bool _0023_003Dzcbmw73GlRCGl6Hk1Wyr7EkKPCAzz;

	static _0023_003DzbgJPRJR9RQcanjv8_0024d91sDUu_00244yX()
	{
		_0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU = typeof(_0023_003DzbgJPRJR9RQcanjv8_0024d91sDUu_00244yX).Assembly;
	}

	internal static void _0023_003DzDw__wI8_003D()
	{
		AppDomain.CurrentDomain.ResourceResolve += [MethodImpl(MethodImplOptions.NoInlining)] (object _0023_003Dza3fcDTAfu020h_0024bcWnrpqTHmAEJl, ResolveEventArgs _0023_003DzrcBo5aS4kumY8olSDSafADeNd3y5) =>
		{
			if ((object)_0023_003DzrcBo5aS4kumY8olSDSafADeNd3y5.RequestingAssembly != _0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU)
			{
				return (Assembly)null;
			}
			return _0023_003Dzcbmw73GlRCGl6Hk1Wyr7EkKPCAzz ? null : _0023_003DzF1H6_0024DhhDF9eMaMpNY4aiR2KfdkG(_0023_003DzrcBo5aS4kumY8olSDSafADeNd3y5.Name);
		};
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0023_003DzjxRMy9oNMgDblGlOAH20UaMRMh_0024N(object _0023_003Dza3fcDTAfu020h_0024bcWnrpqTHmAEJl, ResolveEventArgs _0023_003DzrcBo5aS4kumY8olSDSafADeNd3y5)
	{
		if ((object)_0023_003DzrcBo5aS4kumY8olSDSafADeNd3y5.RequestingAssembly != _0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU)
		{
			return null;
		}
		if (_0023_003Dzcbmw73GlRCGl6Hk1Wyr7EkKPCAzz)
		{
			return null;
		}
		return _0023_003DzF1H6_0024DhhDF9eMaMpNY4aiR2KfdkG(_0023_003DzrcBo5aS4kumY8olSDSafADeNd3y5.Name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0023_003DzF1H6_0024DhhDF9eMaMpNY4aiR2KfdkG(string _0023_003DzYQvHPFc_003D)
	{
		_0023_003Dzcbmw73GlRCGl6Hk1Wyr7EkKPCAzz = true;
		try
		{
			_0023_003DzAoVsvuxV20wIJPP8XYnhyX82TJX6();
			if (!_0023_003DzDx_0024P8TI4Lu3BVQa66lH4lNzZMRqC.TryGetValue(_0023_003DzYQvHPFc_003D, out var value))
			{
				return null;
			}
			return value._0023_003DzwQ0mbBaV1wfD6kEmLMcMbWRoH5vT();
		}
		finally
		{
			_0023_003Dzcbmw73GlRCGl6Hk1Wyr7EkKPCAzz = false;
		}
	}

	private static void _0023_003DzAoVsvuxV20wIJPP8XYnhyX82TJX6()
	{
		if (_0023_003DzDx_0024P8TI4Lu3BVQa66lH4lNzZMRqC != null)
		{
			return;
		}
		lock (_0023_003DzkDsDDcAOvqcjP4bLt9S30C6AYtOU)
		{
			if (_0023_003DzDx_0024P8TI4Lu3BVQa66lH4lNzZMRqC != null)
			{
				return;
			}
			string text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348611299);
			string[] array = text.Split(':');
			int num = array.Length;
			Dictionary<string, _0023_003Dz4hJpxeKEbUofjxFZYCcrPoSvLKW_0024> dictionary = new Dictionary<string, _0023_003Dz4hJpxeKEbUofjxFZYCcrPoSvLKW_0024>(7, StringComparer.Ordinal);
			for (int i = 0; i != num; i++)
			{
				string text2 = array[i];
				string[] array2 = text2.Split('|');
				_0023_003Dz4hJpxeKEbUofjxFZYCcrPoSvLKW_0024 value = new _0023_003Dz4hJpxeKEbUofjxFZYCcrPoSvLKW_0024(array2[0]);
				int num2 = array2.Length;
				for (int j = 1; j != num2; j++)
				{
					string key = array2[j];
					dictionary.Add(key, value);
				}
			}
			_0023_003DzDx_0024P8TI4Lu3BVQa66lH4lNzZMRqC = dictionary;
		}
	}
}

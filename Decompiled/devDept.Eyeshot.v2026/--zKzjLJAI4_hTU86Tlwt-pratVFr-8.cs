using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

internal static class _0023_003DzKzjLJAI4_hTU86Tlwt_0024pratVFr_00248
{
	private sealed class _0023_003Dzi7QyZ3o7dURXP23xfoXmvzM3xIvL
	{
		private readonly string _0023_003DzVNkYC3g0M4viCMnUWS09HgihTbi4;

		private volatile Assembly _0023_003Dz9TFyduZ_0024V8U1TP1cocuivLJKxOZN;

		internal _0023_003Dzi7QyZ3o7dURXP23xfoXmvzM3xIvL(string _0023_003DzIAAAOpXOJdYXkGfJwN4Bx6l3jnwK)
		{
			_0023_003DzVNkYC3g0M4viCMnUWS09HgihTbi4 = _0023_003DzIAAAOpXOJdYXkGfJwN4Bx6l3jnwK;
		}

		internal Assembly _0023_003Dz_bqgS4xep4qz7TcUh_6NBYq2VVX9()
		{
			if ((object)_0023_003Dz9TFyduZ_0024V8U1TP1cocuivLJKxOZN == null)
			{
				lock (this)
				{
					if ((object)_0023_003Dz9TFyduZ_0024V8U1TP1cocuivLJKxOZN == null)
					{
						_0023_003Dz9TFyduZ_0024V8U1TP1cocuivLJKxOZN = _0023_003DzU4R_00248KBItLLkHJJBRRW_s3HuDm93(_0023_003DzVNkYC3g0M4viCMnUWS09HgihTbi4);
					}
				}
			}
			return _0023_003Dz9TFyduZ_0024V8U1TP1cocuivLJKxOZN;
		}

		private static Assembly _0023_003DzU4R_00248KBItLLkHJJBRRW_s3HuDm93(string _0023_003Dzeh82_KsFXro6dSUUVB75nQY_003D)
		{
			return _0023_003DzlKA2LHz43UvxZCVdqwc8LqoqXCz9._0023_003DzjbqS1qE_003D(_0023_003Dzeh82_KsFXro6dSUUVB75nQY_003D) ?? Assembly.Load(_0023_003Dzeh82_KsFXro6dSUUVB75nQY_003D);
		}
	}

	private static readonly Assembly _0023_003Dz9TFyduZ_0024V8U1TP1cocuivLJKxOZN;

	private static volatile Dictionary<string, _0023_003Dzi7QyZ3o7dURXP23xfoXmvzM3xIvL> _0023_003DzXK6qWWf4UuQZp26YkN9aZwfwNzCN;

	[ThreadStatic]
	private static bool _0023_003DzHYOm1QLSNWMTO95cUzs4JG6_kpP8;

	static _0023_003DzKzjLJAI4_hTU86Tlwt_0024pratVFr_00248()
	{
		_0023_003Dz9TFyduZ_0024V8U1TP1cocuivLJKxOZN = typeof(_0023_003DzKzjLJAI4_hTU86Tlwt_0024pratVFr_00248).Assembly;
	}

	internal static void _0023_003DzE8QrneA_003D()
	{
		AppDomain.CurrentDomain.ResourceResolve += _0023_003DzqM2wopLbBpmvjAkKSLcV2OjRYud2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0023_003DzqM2wopLbBpmvjAkKSLcV2OjRYud2(object _0023_003DzSUA4KsXj7hv0oDhnpK6D2Z8HVRId, ResolveEventArgs _0023_003DzZ5oX7o1ziWrUT9beFjegND4Np5Gs)
	{
		if ((object)_0023_003DzZ5oX7o1ziWrUT9beFjegND4Np5Gs.RequestingAssembly != _0023_003Dz9TFyduZ_0024V8U1TP1cocuivLJKxOZN)
		{
			return null;
		}
		if (_0023_003DzHYOm1QLSNWMTO95cUzs4JG6_kpP8)
		{
			return null;
		}
		return _0023_003DzwjkcJyKoUpA6J5Usd8fPj0F02R0D(_0023_003DzZ5oX7o1ziWrUT9beFjegND4Np5Gs.Name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0023_003DzwjkcJyKoUpA6J5Usd8fPj0F02R0D(string _0023_003DzS_00246o7tc_003D)
	{
		_0023_003DzHYOm1QLSNWMTO95cUzs4JG6_kpP8 = true;
		try
		{
			_0023_003DzZ5SMAi6ukw76wJRdK6GUqv01xGnS();
			if (!_0023_003DzXK6qWWf4UuQZp26YkN9aZwfwNzCN.TryGetValue(_0023_003DzS_00246o7tc_003D, out var value))
			{
				return null;
			}
			return value._0023_003Dz_bqgS4xep4qz7TcUh_6NBYq2VVX9();
		}
		finally
		{
			_0023_003DzHYOm1QLSNWMTO95cUzs4JG6_kpP8 = false;
		}
	}

	private static void _0023_003DzZ5SMAi6ukw76wJRdK6GUqv01xGnS()
	{
		if (_0023_003DzXK6qWWf4UuQZp26YkN9aZwfwNzCN != null)
		{
			return;
		}
		lock (_0023_003Dz9TFyduZ_0024V8U1TP1cocuivLJKxOZN)
		{
			if (_0023_003DzXK6qWWf4UuQZp26YkN9aZwfwNzCN != null)
			{
				return;
			}
			string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302748183);
			string[] array = text.Split(':');
			int num = array.Length;
			Dictionary<string, _0023_003Dzi7QyZ3o7dURXP23xfoXmvzM3xIvL> dictionary = new Dictionary<string, _0023_003Dzi7QyZ3o7dURXP23xfoXmvzM3xIvL>(1, StringComparer.Ordinal);
			for (int i = 0; i != num; i++)
			{
				string text2 = array[i];
				string[] array2 = text2.Split('|');
				_0023_003Dzi7QyZ3o7dURXP23xfoXmvzM3xIvL value = new _0023_003Dzi7QyZ3o7dURXP23xfoXmvzM3xIvL(array2[0]);
				int num2 = array2.Length;
				for (int j = 1; j != num2; j++)
				{
					string key = array2[j];
					dictionary.Add(key, value);
				}
			}
			_0023_003DzXK6qWWf4UuQZp26YkN9aZwfwNzCN = dictionary;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Security;
using System.Threading;

internal sealed class _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D
{
	private static class _0023_003Dz5QkdKZk_003D
	{
		private static readonly Dictionary<MethodBase, MethodInfo> _0023_003Dzq80RbjQ_003D = new Dictionary<MethodBase, MethodInfo>();

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase _0023_003Dz0XWS4j1Vldv5HPdX3cWziHrG_0024ijmCmR2Bw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D _0023_003DzZzVr6_0024U_003D, MethodBase _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
		{
			lock (_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003Dz5QkdKZk_003D._0023_003Dzq80RbjQ_003D)
			{
				if (_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003Dz5QkdKZk_003D._0023_003Dzq80RbjQ_003D.TryGetValue(_0023_003Dz7hRN5Rg_003D, out var value))
				{
					return value;
				}
				Type returnType = ((!(_0023_003Dz7hRN5Rg_003D is MethodInfo methodInfo)) ? _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzLaPeX80_003D : methodInfo.ReturnType);
				ParameterInfo[] parameters = _0023_003Dz7hRN5Rg_003D.GetParameters();
				Type[] array;
				if (_0023_003Dz7hRN5Rg_003D.IsStatic)
				{
					array = new Type[parameters.Length];
					for (int i = 0; i < parameters.Length; i++)
					{
						array[i] = parameters[i].ParameterType;
					}
				}
				else
				{
					array = new Type[parameters.Length + 1];
					Type type = _0023_003Dz7hRN5Rg_003D.DeclaringType;
					if (type.IsValueType)
					{
						type = type.MakeByRefType();
						_0023_003DzcbLoSrg_003D = false;
					}
					array[0] = type;
					for (int j = 0; j < parameters.Length; j++)
					{
						array[j + 1] = parameters[j].ParameterType;
					}
				}
				string empty = string.Empty;
				if (value == null)
				{
					value = new DynamicMethod(empty, returnType, array, _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DzZzVr6_0024U_003D._0023_003DzeFmYRYvMy4A0IhX6fIHDEUwm_00242cyzi_3XQ_003D_003D(), _0023_003DzZzVr6_0024U_003D: true), skipVisibility: true);
				}
				ILGenerator iLGenerator = ((DynamicMethod)value).GetILGenerator();
				for (int k = 0; k < array.Length; k++)
				{
					iLGenerator.Emit(OpCodes.Ldarg, k);
				}
				if (_0023_003Dz7hRN5Rg_003D is ConstructorInfo con)
				{
					iLGenerator.Emit(_0023_003DzcbLoSrg_003D ? OpCodes.Callvirt : OpCodes.Call, con);
				}
				else
				{
					iLGenerator.Emit(_0023_003DzcbLoSrg_003D ? OpCodes.Callvirt : OpCodes.Call, (MethodInfo)_0023_003Dz7hRN5Rg_003D);
				}
				iLGenerator.Emit(OpCodes.Ret);
				_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003Dz5QkdKZk_003D._0023_003Dzq80RbjQ_003D.Add(_0023_003Dz7hRN5Rg_003D, value);
				return value;
			}
		}
	}

	private struct _0023_003Dz7hRN5Rg_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dzq80RbjQ_003D;
	}

	private sealed class _0023_003DzAXvW_0024Kw_003D<_0023_003Dzq80RbjQ_003D> : IComparer<KeyValuePair<int, _0023_003Dzq80RbjQ_003D>>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Comparison<_0023_003Dzq80RbjQ_003D> _0023_003Dzq80RbjQ_003D;

		public _0023_003DzAXvW_0024Kw_003D(Comparison<_0023_003Dzq80RbjQ_003D> _0023_003Dzq80RbjQ_003D)
		{
			this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
		}

		public int Compare(KeyValuePair<int, _0023_003Dzq80RbjQ_003D> _0023_003Dzq80RbjQ_003D, KeyValuePair<int, _0023_003Dzq80RbjQ_003D> _0023_003DzZzVr6_0024U_003D)
		{
			int num = this._0023_003Dzq80RbjQ_003D(_0023_003Dzq80RbjQ_003D.Value, _0023_003DzZzVr6_0024U_003D.Value);
			if (num == 0)
			{
				return _0023_003DzZzVr6_0024U_003D.Key.CompareTo(_0023_003Dzq80RbjQ_003D.Key);
			}
			return num;
		}
	}

	private struct _0023_003DzKyPCKaY_003D(_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqn00L3j_fTKypT_0024po0xhHEU_003D _0023_003Dzq80RbjQ_003D, _0023_003DzLaPeX80_003D _0023_003DzZzVr6_0024U_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte _0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D._0023_003Dz45KmVm8NJf_XRukwlNCtp2biNenhBiNfuzJ6wmf_2nhM();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly _0023_003DzLaPeX80_003D _0023_003DzZzVr6_0024U_003D = _0023_003DzZzVr6_0024U_003D;
	}

	private delegate void _0023_003DzLaPeX80_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D);

	private sealed class _0023_003DzUH03yec_003D : IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D _0023_003Dzq80RbjQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003DzZzVr6_0024U_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003Dz7hRN5Rg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _0023_003DzcbLoSrg_003D;

		public void Dispose()
		{
			IDisposable disposable = _0023_003DzZzVr6_0024U_003D;
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
			if (_0023_003Dz7hRN5Rg_003D != null)
			{
				_0023_003Dz7hRN5Rg_003D.Dispose();
				_0023_003Dz7hRN5Rg_003D = null;
			}
		}
	}

	[Serializable]
	private sealed class _0023_003DzZzVr6_0024U_003D
	{
		public static readonly _0023_003DzZzVr6_0024U_003D _0023_003Dzq80RbjQ_003D = new _0023_003DzZzVr6_0024U_003D();

		public static Comparison<_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D> _0023_003DzZzVr6_0024U_003D;

		internal int _0023_003DzQgBWE0TPv_00243cHwG3mI_jBYWKTXwKRSwfkx6JfWPj9CGQ(_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D _0023_003Dzq80RbjQ_003D, _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D _0023_003DzZzVr6_0024U_003D)
		{
			if (_0023_003Dzq80RbjQ_003D._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw() == _0023_003DzZzVr6_0024U_003D._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw())
			{
				return _0023_003DzZzVr6_0024U_003D._0023_003DzPQUNNKOX2HDwNDSQ4BUJN_esq0Wmy5BYBg_003D_003D().CompareTo(_0023_003Dzq80RbjQ_003D._0023_003DzPQUNNKOX2HDwNDSQ4BUJN_esq0Wmy5BYBg_003D_003D());
			}
			return _0023_003Dzq80RbjQ_003D._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw().CompareTo(_0023_003DzZzVr6_0024U_003D._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw());
		}
	}

	private static class _0023_003DzcbLoSrg_003D
	{
		public static readonly bool _0023_003Dzq80RbjQ_003D;

		static _0023_003DzcbLoSrg_003D()
		{
			try
			{
				_0023_003Dzq80RbjQ_003D = _0023_003DzYG_0024GjNwqv_diu301pwgbKM0_003D();
			}
			catch
			{
				_0023_003Dzq80RbjQ_003D = false;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _0023_003DzYG_0024GjNwqv_diu301pwgbKM0_003D()
		{
			if (typeof(DynamicMethod).IsAbstract)
			{
				return false;
			}
			try
			{
				new DynamicMethod(string.Empty, typeof(void), Type.EmptyTypes);
			}
			catch (PlatformNotSupportedException)
			{
				return false;
			}
			return true;
		}
	}

	private struct _0023_003DzkJp9o4I_003D(MethodBase _0023_003Dzq80RbjQ_003D, bool _0023_003DzZzVr6_0024U_003D) : IEquatable<_0023_003DzkJp9o4I_003D>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly MethodBase _0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly bool _0023_003DzZzVr6_0024U_003D = _0023_003DzZzVr6_0024U_003D;

		[_0023_003Dqf_1TygBFcnFf0K9AFFRX5lT1_0024S5WaxudL4Z64MWZsR8_003D]
		public MethodBase _0023_003Dz5FQSKSm6B3sKlUlrhmg1z7BQAoRYhH4XkeDioNw_003D()
		{
			return _0023_003Dzq80RbjQ_003D;
		}

		[_0023_003Dqf_1TygBFcnFf0K9AFFRX5lT1_0024S5WaxudL4Z64MWZsR8_003D]
		public bool _0023_003Dz5I6xus_DQeKRDBxdDd4yTIuOFHZ89NZXe1lxOlg_003D()
		{
			return _0023_003DzZzVr6_0024U_003D;
		}

		public override int GetHashCode()
		{
			return _0023_003Dz5FQSKSm6B3sKlUlrhmg1z7BQAoRYhH4XkeDioNw_003D().GetHashCode() ^ _0023_003Dz5I6xus_DQeKRDBxdDd4yTIuOFHZ89NZXe1lxOlg_003D().GetHashCode();
		}

		public override bool Equals(object _0023_003Dzq80RbjQ_003D)
		{
			if (_0023_003Dzq80RbjQ_003D is _0023_003DzkJp9o4I_003D _0023_003DzkJp9o4I_003D2)
			{
				return Equals(_0023_003DzkJp9o4I_003D2);
			}
			return false;
		}

		public bool Equals(_0023_003DzkJp9o4I_003D _0023_003Dzq80RbjQ_003D)
		{
			if (_0023_003Dz5FQSKSm6B3sKlUlrhmg1z7BQAoRYhH4XkeDioNw_003D() == _0023_003Dzq80RbjQ_003D._0023_003Dz5FQSKSm6B3sKlUlrhmg1z7BQAoRYhH4XkeDioNw_003D())
			{
				return _0023_003Dz5I6xus_DQeKRDBxdDd4yTIuOFHZ89NZXe1lxOlg_003D() == _0023_003Dzq80RbjQ_003D._0023_003Dz5I6xus_DQeKRDBxdDd4yTIuOFHZ89NZXe1lxOlg_003D();
			}
			return false;
		}
	}

	private sealed class _0023_003Dzkl7CXTo_003D
	{
	}

	private static class _0023_003DzoVpU9JU_003D
	{
		private delegate _0023_003DzLaPeX80_003D _0023_003Dz349QwgY_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D, in _0023_003DzuwE9t4w_003D, in _0023_003DzoyRBT1A_003D, out _0023_003DzLaPeX80_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D _0023_003DzuwE9t4w_003D, _0023_003DzoyRBT1A_003D _0023_003DzoyRBT1A_003D);

		private delegate _0023_003Dzq80RbjQ_003D _0023_003Dz5QkdKZk_003D<out _0023_003Dzq80RbjQ_003D>();

		private delegate _0023_003DzoyRBT1A_003D _0023_003Dz61IPlm0_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D, in _0023_003DzuwE9t4w_003D, out _0023_003DzoyRBT1A_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D _0023_003DzuwE9t4w_003D);

		private delegate void _0023_003Dz7hRN5Rg_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D);

		private delegate _0023_003DzcbLoSrg_003D _0023_003DzAXvW_0024Kw_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, out _0023_003DzcbLoSrg_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D);

		private delegate void _0023_003DzKyPCKaY_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D, in _0023_003DzuwE9t4w_003D, in _0023_003DzoyRBT1A_003D, in _0023_003DzLaPeX80_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D _0023_003DzuwE9t4w_003D, _0023_003DzoyRBT1A_003D _0023_003DzoyRBT1A_003D, _0023_003DzLaPeX80_003D _0023_003DzLaPeX80_003D);

		private delegate void _0023_003DzLaPeX80_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D, in _0023_003DzuwE9t4w_003D, in _0023_003DzoyRBT1A_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D _0023_003DzuwE9t4w_003D, _0023_003DzoyRBT1A_003D _0023_003DzoyRBT1A_003D);

		private delegate _0023_003DzqMLoHoQ_003D _0023_003DzLi0XoCY_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, out _0023_003DzqMLoHoQ_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D);

		private delegate _0023_003Dz7hRN5Rg_003D _0023_003DzUH03yec_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, out _0023_003Dz7hRN5Rg_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D);

		private delegate void _0023_003DzZzVr6_0024U_003D<in _0023_003Dzq80RbjQ_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D);

		private delegate void _0023_003DzcbLoSrg_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D);

		private delegate _0023_003DzuwE9t4w_003D _0023_003DzkEXSfPc_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D, out _0023_003DzuwE9t4w_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D);

		private delegate _0023_003DzoVpU9JU_003D _0023_003DzkJp9o4I_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D, in _0023_003DzuwE9t4w_003D, in _0023_003DzoyRBT1A_003D, in _0023_003DzLaPeX80_003D, in _0023_003DzKyPCKaY_003D, out _0023_003DzoVpU9JU_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D _0023_003DzuwE9t4w_003D, _0023_003DzoyRBT1A_003D _0023_003DzoyRBT1A_003D, _0023_003DzLaPeX80_003D _0023_003DzLaPeX80_003D, _0023_003DzKyPCKaY_003D _0023_003DzKyPCKaY_003D);

		private delegate _0023_003DzZzVr6_0024U_003D _0023_003Dzkl7CXTo_003D<in _0023_003Dzq80RbjQ_003D, out _0023_003DzZzVr6_0024U_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D);

		private delegate void _0023_003DzoVpU9JU_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D, in _0023_003DzuwE9t4w_003D, in _0023_003DzoyRBT1A_003D, in _0023_003DzLaPeX80_003D, in _0023_003DzKyPCKaY_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D _0023_003DzuwE9t4w_003D, _0023_003DzoyRBT1A_003D _0023_003DzoyRBT1A_003D, _0023_003DzLaPeX80_003D _0023_003DzLaPeX80_003D, _0023_003DzKyPCKaY_003D _0023_003DzKyPCKaY_003D);

		private delegate void _0023_003DzoyRBT1A_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D, in _0023_003DzuwE9t4w_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D _0023_003DzuwE9t4w_003D);

		private delegate void _0023_003Dzq80RbjQ_003D();

		private delegate void _0023_003DzqMLoHoQ_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D);

		private delegate _0023_003DzKyPCKaY_003D _0023_003DzrhEG9Ic_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D, in _0023_003DzuwE9t4w_003D, in _0023_003DzoyRBT1A_003D, in _0023_003DzLaPeX80_003D, out _0023_003DzKyPCKaY_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D _0023_003DzuwE9t4w_003D, _0023_003DzoyRBT1A_003D _0023_003DzoyRBT1A_003D, _0023_003DzLaPeX80_003D _0023_003DzLaPeX80_003D);

		private delegate void _0023_003DzuwE9t4w_003D<in _0023_003Dzq80RbjQ_003D, in _0023_003DzZzVr6_0024U_003D, in _0023_003Dz7hRN5Rg_003D, in _0023_003DzcbLoSrg_003D, in _0023_003DzqMLoHoQ_003D>(_0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D);

		private static readonly Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> m__0023_003Dzq80RbjQ_003D;

		static _0023_003DzoVpU9JU_003D()
		{
			_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003DzoVpU9JU_003D.m__0023_003Dzq80RbjQ_003D = new Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>>();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static object _0023_003Dzt0Sa1EkMEFGHDIuef_0024X3COqmJZ2T2bmDzdjUILo_003D(object _0023_003Dzq80RbjQ_003D, MethodBase _0023_003DzZzVr6_0024U_003D, out MethodInfo _0023_003Dz7hRN5Rg_003D)
		{
			KeyValuePair<Type, MethodInfo> keyValuePair = _0023_003DzZq5vC5wHKJJOkAAtBbFXma_0024dPhvL(_0023_003DzZzVr6_0024U_003D);
			Delegate result = (Delegate)Activator.CreateInstance(keyValuePair.Key, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D.MethodHandle.GetFunctionPointer());
			_0023_003Dz7hRN5Rg_003D = keyValuePair.Value;
			return result;
		}

		private static KeyValuePair<Type, MethodInfo> _0023_003DzZq5vC5wHKJJOkAAtBbFXma_0024dPhvL(MethodBase _0023_003Dzq80RbjQ_003D)
		{
			lock (_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003DzoVpU9JU_003D.m__0023_003Dzq80RbjQ_003D)
			{
				if (_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003DzoVpU9JU_003D.m__0023_003Dzq80RbjQ_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out var value))
				{
					return value;
				}
				Type type = (_0023_003Dzq80RbjQ_003D as MethodInfo)?.ReturnType ?? _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzLaPeX80_003D;
				bool flag = type != _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzLaPeX80_003D;
				ParameterInfo[] parameters = _0023_003Dzq80RbjQ_003D.GetParameters();
				if (parameters.Length > 9)
				{
					throw new Exception(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526073), parameters.Length));
				}
				Type[] array = new Type[parameters.Length + (flag ? 1 : 0)];
				for (int i = 0; i < parameters.Length; i++)
				{
					Type parameterType = parameters[i].ParameterType;
					if (parameterType.IsByRef || parameterType.IsPointer)
					{
						throw new Exception(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526087));
					}
					array[i] = parameterType;
				}
				if (flag)
				{
					array[array.Length - 1] = type;
				}
				Type type2 = (flag ? _0023_003DzZQI84m_0024hu2QIFKZUPIVrlyI_003D(array) : _0023_003DzVPQRszwVX_0024HQ7ZiHPL8kM_A_003D(array));
				MethodInfo method = type2.GetMethod(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525654));
				value = new KeyValuePair<Type, MethodInfo>(type2, method);
				_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003DzoVpU9JU_003D.m__0023_003Dzq80RbjQ_003D.Add(_0023_003Dzq80RbjQ_003D, value);
				return value;
			}
		}

		private static Type _0023_003DzZQI84m_0024hu2QIFKZUPIVrlyI_003D(Type[] _0023_003Dzq80RbjQ_003D)
		{
			return _0023_003Dzq80RbjQ_003D.Length switch
			{
				1 => typeof(_0023_003Dz5QkdKZk_003D<>).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				2 => typeof(_0023_003Dzkl7CXTo_003D<, >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				3 => typeof(_0023_003DzUH03yec_003D<, , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				4 => typeof(_0023_003DzAXvW_0024Kw_003D<, , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				5 => typeof(_0023_003DzLi0XoCY_003D<, , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				6 => typeof(_0023_003DzkEXSfPc_003D<, , , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				7 => typeof(_0023_003Dz61IPlm0_003D<, , , , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				8 => typeof(_0023_003Dz349QwgY_003D<, , , , , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				9 => typeof(_0023_003DzrhEG9Ic_003D<, , , , , , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				10 => typeof(_0023_003DzkJp9o4I_003D<, , , , , , , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				_ => null, 
			};
		}

		private static Type _0023_003DzVPQRszwVX_0024HQ7ZiHPL8kM_A_003D(Type[] _0023_003Dzq80RbjQ_003D)
		{
			return _0023_003Dzq80RbjQ_003D.Length switch
			{
				0 => typeof(_0023_003Dzq80RbjQ_003D), 
				1 => typeof(_0023_003DzZzVr6_0024U_003D<>).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				2 => typeof(_0023_003Dz7hRN5Rg_003D<, >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				3 => typeof(_0023_003DzcbLoSrg_003D<, , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				4 => typeof(_0023_003DzqMLoHoQ_003D<, , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				5 => typeof(_0023_003DzuwE9t4w_003D<, , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				6 => typeof(_0023_003DzoyRBT1A_003D<, , , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				7 => typeof(_0023_003DzLaPeX80_003D<, , , , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				8 => typeof(_0023_003DzKyPCKaY_003D<, , , , , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				9 => typeof(_0023_003DzoVpU9JU_003D<, , , , , , , , >).MakeGenericType(_0023_003Dzq80RbjQ_003D), 
				_ => null, 
			};
		}
	}

	private sealed class _0023_003DzoyRBT1A_003D
	{
		private string _0023_003Dzq80RbjQ_003D;

		private Type _0023_003DzZzVr6_0024U_003D;

		public string _0023_003DzSLbCvhyhd6EA0sCwGklx75CDwRmgylZMQG39ekE_003D()
		{
			return _0023_003Dzq80RbjQ_003D;
		}

		public void _0023_003DzYVxNFGrPxTS0qpoCsMqDDXBNBo6xkQQlsA_003D_003D(string _0023_003Dzq80RbjQ_003D)
		{
			this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
		}

		public Type _0023_003DzXoigHLqFI57EuRRUs4EXmuB1eH8nftAdKQ_003D_003D()
		{
			return _0023_003DzZzVr6_0024U_003D;
		}

		public void _0023_003DzNWxgxpczmnVTcUpA8I2IiYDiPdVmFkJtsA_003D_003D(Type _0023_003Dzq80RbjQ_003D)
		{
			_0023_003DzZzVr6_0024U_003D = _0023_003Dzq80RbjQ_003D;
		}
	}

	private static class _0023_003Dzq80RbjQ_003D
	{
		public static _0023_003DzLaPeX80_003D _0023_003Dzq80RbjQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzZzVr6_0024U_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz7hRN5Rg_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzcbLoSrg_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzqMLoHoQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzuwE9t4w_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzoyRBT1A_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzLaPeX80_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzKyPCKaY_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzoVpU9JU_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz5QkdKZk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzkJp9o4I_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzkl7CXTo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzUH03yec_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzAXvW_0024Kw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzLi0XoCY_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzkEXSfPc_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz61IPlm0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz349QwgY_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzrhEG9Ic_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzAwa9dP4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz0Ht_0024Sk0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzuUxvxmo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzF6BhvwY_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzaG3DPu0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzvup4kCA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzTiqx__00240_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzBa3Kf5Y_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzxHwNxiw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzxhN3bEo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzmZNu_pI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz1j2rMNI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz5SBVqVA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz4A3Alm0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzQ94e_m4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzdLjJal4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzX_VRnyU_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzROtQTt4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzeJLIX5w_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzwLLvGQs_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzqxgM70s_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzixve3yE_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzBAOlweI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzvOTbM3Y_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzv0iXCdI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzgCCmJLk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz_0024qvd3Jk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DznA0KbrY_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzpDG_0024bAk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzzkz90iI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzMCVMYmM_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzZ1Nd0wk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzuW1CqYA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzuXsnuWU_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzbtij9_00248_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzwzL6DAY_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzuaKKESU_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzxP03bpw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzaNzIkdM_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz3BbTphQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzUawOijg_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzyc0iBLA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzd8qN_0024fo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzemKTiT8_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzHAARMLg_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzPjbPPps_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzHVPXXvQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzzNw7Y4Q_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dztc_0024ann8_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz62FWXc8_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzjV5qBvw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzzxDPBsQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzWTgsPi0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzFKB94gU_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzBjvPP_0024w_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzVeJ4EnE_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzWQ7kZWw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzUp6r3Y0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzp758Cuo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzbmCgwUo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzO94BUrs_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzbNUssNo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzheXyabQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzjnY9xUw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz1LTqqwY_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzzYs24lA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzZsyxWik_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzAtYak7o_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dztzj32iA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzmLyIuNI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzewRUSA4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzXhlLPyI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzmMmUef0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzjF3U8_0024w_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz0FF8FKw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzJCMPY20_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzDOe3VCY_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzFikN25c_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzD66eVW4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dze1SxUho_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz9cUgz_s_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzWtMw7JM_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzHbUo3O0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzsaghmf0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzeTjUjYE_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzw617K6k_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzZRjZoiI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz_00245S1SHE_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzqAY1jyo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzWQeOcdQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzfyTcB9E_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzPAYs7f4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzaSf_0024Uuo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzhcgD8IQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzx_f8XLg_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzAWMGxQs_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzH_00242zw_0024c_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzVUOOffo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzkWKsrvw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzhvB7zF0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz6_0024GU_0024Fc_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzOzh68Jk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz8oxZp4M_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzxH_UWC4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz2CpLTfo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzNZPSV9I_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz8NlYRoQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzC4Sydfw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzfMBGV_00240_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz0xDSfi4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz6_0024t9doE_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzG_0024GQjQU_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzHM9TetA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz7j67dw4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzlq1zGZM_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzb8NOAOw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dze_0024TX6wc_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzG_LDriQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzKAFKdck_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzxPEqRbs_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzv_0024Sjmdk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzBVWf310_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzj0si6zk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzh9LSz4s_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzS4vjrVk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzNTGnOiI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzJBhSeAM_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzZsIH_0024YA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzPnY1qG0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzE75m7_0024c_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzmelcEjk_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzEtyP29c_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzRdhcDdg_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz1RBgr_00244_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzR7bPUlA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzmsT1xI8_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzn2ncZyI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzoYDTc8U_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz1HLmZ4c_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DznppgqLs_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzzDP2VK4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzOrMR9qY_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz5qKRdzI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzbGeCb4Q_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzzq_0024ktm0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzr7zegGI_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzz7VpMuo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzxA7xepw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzUvjxD1c_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzvTxN1os_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzmIdb15c_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzen5bzmA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz_0024Qw3zuA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzdUS5IM4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzycQEg40_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzDoFU9f0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzWqEE4_g_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzG_Z_SWU_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzu4t07PM_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzPRVED4s_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzT5j73_0024M_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzvOp8rOA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzUrhsklQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzYg2nCqE_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz_00246tDw_0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzJYjSKV4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzW4Qrpao_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzd8oBCP0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzYL7wouc_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzA7hfB1A_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzjhZqSy0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz8OpgbN4_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzX7Gt1Sw_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzH9Cfb_0024c_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzR6Gfg9E_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzJsdpqPo_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzC0zaoyA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz_0024RKF2QA_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dz5Z4gvtc_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzgaXPHWs_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzOAtZ2r0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003Dzik4eDVg_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzBLw5YM0_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzAZ_00241IwQ_003D;

		public static _0023_003DzLaPeX80_003D _0023_003DzLi3Klnc_003D;
	}

	private struct _0023_003DzqMLoHoQ_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly uint _0023_003Dzq80RbjQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly object _0023_003DzZzVr6_0024U_003D;

		public _0023_003DzqMLoHoQ_003D(uint _0023_003Dzq80RbjQ_003D)
		{
			this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
			_0023_003DzZzVr6_0024U_003D = null;
		}

		public _0023_003DzqMLoHoQ_003D(uint _0023_003Dzq80RbjQ_003D, object _0023_003DzZzVr6_0024U_003D)
		{
			this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
			this._0023_003DzZzVr6_0024U_003D = _0023_003DzZzVr6_0024U_003D;
		}

		[_0023_003Dqf_1TygBFcnFf0K9AFFRX5lT1_0024S5WaxudL4Z64MWZsR8_003D]
		public uint _0023_003Dzm9VpQhRD9rpmsnXR3GK29eEH0kyJ()
		{
			return _0023_003Dzq80RbjQ_003D;
		}

		[_0023_003Dqf_1TygBFcnFf0K9AFFRX5lT1_0024S5WaxudL4Z64MWZsR8_003D]
		public object _0023_003DzdwE39exGeF5INW684okNqdI_003D()
		{
			return _0023_003DzZzVr6_0024U_003D;
		}
	}

	private delegate object _0023_003DzuwE9t4w_003D(object _0023_003Dzq80RbjQ_003D, object[] _0023_003DzZzVr6_0024U_003D);

	private static Type _0023_003DzROtQTt4_003D;

	private long _0023_003DzQ94e_m4_003D;

	private readonly Module m__0023_003DzkJp9o4I_003D;

	private _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D[] _0023_003DzF6BhvwY_003D;

	private Type[] _0023_003DzuUxvxmo_003D;

	private _0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D m__0023_003DzAXvW_0024Kw_003D;

	private object _0023_003Dz0Ht_0024Sk0_003D;

	private static Type _0023_003DzkEXSfPc_003D;

	private readonly _0023_003DqUR7_0024aTHoiijy1rATVvJvahY_rqH1dc0o22bEKz0H3wo_003D _0023_003DzeJLIX5w_003D;

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D m__0023_003DzqMLoHoQ_003D;

	private Type[] m__0023_003DzcbLoSrg_003D;

	private static readonly Dictionary<_0023_003DzkJp9o4I_003D, _0023_003DzuwE9t4w_003D> _0023_003DzBa3Kf5Y_003D = new Dictionary<_0023_003DzkJp9o4I_003D, _0023_003DzuwE9t4w_003D>(256);

	private bool m__0023_003DzuwE9t4w_003D;

	private readonly Stack<_0023_003DzqMLoHoQ_003D> m__0023_003Dzq80RbjQ_003D = new Stack<_0023_003DzqMLoHoQ_003D>();

	private static readonly Dictionary<int, object> _0023_003DzxHwNxiw_003D;

	private Type _0023_003DzaG3DPu0_003D;

	private static Type _0023_003Dz1j2rMNI_003D;

	private static Type m__0023_003DzZzVr6_0024U_003D;

	private readonly Stack<_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D> _0023_003Dz349QwgY_003D = new Stack<_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D>(16);

	private static readonly Dictionary<MethodBase, int> m__0023_003Dz7hRN5Rg_003D;

	private _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003DzAwa9dP4_003D;

	private Stream m__0023_003DzoyRBT1A_003D;

	private static Type m__0023_003DzUH03yec_003D;

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dz4A3Alm0_003D;

	private object[] m__0023_003DzKyPCKaY_003D;

	private static Type m__0023_003DzLaPeX80_003D;

	private bool _0023_003DzrhEG9Ic_003D;

	private _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003DzLi0XoCY_003D;

	private static Type _0023_003Dzvup4kCA_003D;

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] m__0023_003Dz5QkdKZk_003D;

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] _0023_003DzxhN3bEo_003D;

	private byte[] m__0023_003DzoVpU9JU_003D;

	private Stack<_0023_003DzUH03yec_003D> _0023_003DzTiqx__00240_003D;

	private uint? _0023_003Dz5SBVqVA_003D;

	private static object _0023_003DzX_VRnyU_003D = new object();

	private uint m__0023_003Dzkl7CXTo_003D;

	private static Dictionary<int, _0023_003DzKyPCKaY_003D> _0023_003Dz61IPlm0_003D;

	private uint _0023_003DzmZNu_pI_003D;

	private static readonly Dictionary<MethodBase, object> _0023_003DzwLLvGQs_003D;

	private uint _0023_003DzdLjJal4_003D;

	public _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D(_0023_003DqUR7_0024aTHoiijy1rATVvJvahY_rqH1dc0o22bEKz0H3wo_003D _0023_003Dzq80RbjQ_003D, Module _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DzeJLIX5w_003D = _0023_003Dzq80RbjQ_003D;
		this.m__0023_003DzkJp9o4I_003D = _0023_003DzZzVr6_0024U_003D;
		_0023_003DzNqBlPyvD2MRLn7i5upltHvZYYJEqFOOO2w_003D_003D();
	}

	public _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D(_0023_003DqUR7_0024aTHoiijy1rATVvJvahY_rqH1dc0o22bEKz0H3wo_003D _0023_003Dzq80RbjQ_003D)
		: this(_0023_003Dzq80RbjQ_003D, typeof(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D).Module)
	{
	}

	static _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D()
	{
		_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003Dz7hRN5Rg_003D = new Dictionary<MethodBase, int>(256);
		_0023_003DzwLLvGQs_003D = new Dictionary<MethodBase, object>();
		_0023_003DzxHwNxiw_003D = new Dictionary<int, object>();
		_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzUH03yec_003D = typeof(_0023_003Dzkl7CXTo_003D);
		_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzLaPeX80_003D = typeof(void);
		_0023_003DzkEXSfPc_003D = typeof(object[]);
		_0023_003Dzvup4kCA_003D = typeof(IntPtr);
		_0023_003Dz1j2rMNI_003D = typeof(Assembly);
		_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzZzVr6_0024U_003D = typeof(MethodBase);
		_0023_003DzROtQTt4_003D = typeof(RuntimeHelpers);
	}

	private void _0023_003DzFPuHHafPEG92XM_0024gYatOtrw_0024UnVJ(bool _0023_003Dzq80RbjQ_003D, bool _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzKLjjiPIGmT8tT3KeXc7dfbpJbR3xSWCsmQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D));
	}

	private static void _0023_003DzozftuLhHQFpq9HCy2Ypr8JX0BuDL8EPIDVuvhl_iEfdt(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		bool flag = false;
		if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() == 0, 
			13 => ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() == 0, 
			0 => ((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr() == IntPtr.Zero, 
			20 => ((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D() == UIntPtr.Zero, 
			7 => ((_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzvPsFwllF9YUejQF68VzjbUs4hENNmXLLhEVR500jpyde() == null, 
			19 => !Convert.ToBoolean(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			_ => _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() == null, 
		})
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private static void _0023_003Dzvp9mEq0Zy21dtX3hLxtV0J3Qsgge7wcRgDY7wZQ_003D(Exception _0023_003Dzq80RbjQ_003D)
	{
		ExceptionDispatchInfo.Capture(_0023_003Dzq80RbjQ_003D).Throw();
	}

	private static void _0023_003DzJDeqiGerlaon5b5FVHXgouU5WHR8XZufIg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		FieldInfo fieldInfo = _0023_003Dzq80RbjQ_003D._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D(fieldInfo, null));
	}

	private static void _0023_003DzsiGT2MDUl9QBIO6XdFy14kydp_qrD3oM_g_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzoSOcA_xIir7qj1v7MWszdx8_003D(((_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D());
	}

	private static void _0023_003DzcFCVx1FI0B2wM0fJ_0024MSbrU_0024OVf_002461vh7ng_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		checked
		{
			_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
			{
				1 => unchecked((uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
				13 => (long)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
				19 => (long)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
				8 => (long)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
				0 => (IntPtr.Size != 4) ? ((long)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : unchecked((uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
				_ => throw new InvalidOperationException(), 
			}));
		}
	}

	private void _0023_003DzV9O_RLTL01ApHujuxKX_0024HiFnV99c(bool _0023_003Dzq80RbjQ_003D)
	{
		uint num = _0023_003DzdLjJal4_003D;
		while (true)
		{
			try
			{
				while (!_0023_003DzrhEG9Ic_003D)
				{
					if (_0023_003Dz5SBVqVA_003D.HasValue)
					{
						_0023_003DzmZNu_pI_003D = _0023_003Dz5SBVqVA_003D.Value;
						_0023_003Dz_0024AVDGBkSTbtVZvD9e2JWltw_003D(_0023_003DzmZNu_pI_003D);
						_0023_003Dz5SBVqVA_003D = null;
					}
					else if (_0023_003DzmZNu_pI_003D >= num)
					{
						break;
					}
					_0023_003DziqxPRZhHz6K5QX9uIRB_0024_o4eIiLe();
				}
				break;
			}
			catch (object obj)
			{
				_0023_003DzMw7_0024EO1zJL4MyDs5_00243DxjS_NGViU1FlGfkRm6d8_003D(obj, 0u);
				if (!_0023_003Dzq80RbjQ_003D)
				{
					_0023_003DzV9O_RLTL01ApHujuxKX_0024HiFnV99c(_0023_003Dzq80RbjQ_003D: true);
					break;
				}
			}
		}
	}

	private void _0023_003DzNqBlPyvD2MRLn7i5upltHvZYYJEqFOOO2w_003D_003D()
	{
		if (!_0023_003DzeJLIX5w_003D._0023_003DzcrRCoCfhr_0024_00244EZjPWVTD85tgLmwZWrTX_g_003D_003D())
		{
			lock (_0023_003DzeJLIX5w_003D)
			{
				if (!_0023_003DzeJLIX5w_003D._0023_003DzcrRCoCfhr_0024_00244EZjPWVTD85tgLmwZWrTX_g_003D_003D())
				{
					_0023_003Dz61IPlm0_003D = _0023_003DzyqIdOhbNg64V0ecLy5ctHtNw6HE2(_0023_003DzeJLIX5w_003D);
					_0023_003DzPHiIf3KRk8uGovgzQUP7QfXxitAzyyw_00241A_003D_003D();
					_0023_003DzeJLIX5w_003D._0023_003DzwngqkhbDrXfZ1vDU6kw0g0TAWS0V(_0023_003Dzq80RbjQ_003D: true);
				}
			}
		}
		if (_0023_003Dz61IPlm0_003D == null)
		{
			_0023_003Dz61IPlm0_003D = _0023_003DzyqIdOhbNg64V0ecLy5ctHtNw6HE2(_0023_003DzeJLIX5w_003D);
		}
	}

	private static void _0023_003DzNxlONioPLlYmTCbjA7hYUEIDoHI6HqobAw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525040));
	}

	private static void _0023_003DzZRP8pjH_sY5FpFyIsqrGkqTHK0xkfw6uPLQNs9I_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003Dz0Ht_0024Sk0_003D == null)
		{
			throw new InvalidOperationException();
		}
		_0023_003Dzq80RbjQ_003D._0023_003DzYdwOeQ6ohJIqRySc0WL8wF8xQ56H(_0023_003Dzq80RbjQ_003D._0023_003Dz0Ht_0024Sk0_003D);
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzV2E0EoqrR8a7GE1oX_kC97_00244eG4fhAMhmw_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				if (!_0023_003Dz7hRN5Rg_003D)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num >> num2);
				}
				int num3 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				int num4 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num3 >>> num4);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzV2E0EoqrR8a7GE1oX_kC97_00244eG4fhAMhmw_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				if (!_0023_003Dz7hRN5Rg_003D)
				{
					long num5 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
					int num6 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num5 >> num6);
				}
				long num7 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				int num8 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num7 >>> num8);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzV2E0EoqrR8a7GE1oX_kC97_00244eG4fhAMhmw_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzV2E0EoqrR8a7GE1oX_kC97_00244eG4fhAMhmw_003D_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			}
			return _0023_003DzV2E0EoqrR8a7GE1oX_kC97_00244eG4fhAMhmw_003D_003D(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzxUX7rtOex1S_8nsaFFVDdrdJ3ist(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(5);
	}

	private static void _0023_003DzHtxvGyRZEb1MW_0024bDtAKLBjg_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D _0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D2 = (_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003DzZzVr6_0024U_003D;
		_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D obj = new _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D();
		obj._0023_003DzzYzgkSraKLDKGhNE6_isGLbZYUM4(_0023_003Dzq80RbjQ_003D._0023_003DzxhN3bEo_003D[_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D2._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D()]);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dz7WD6zOl6VlqdZylFMuS5P6NR2Tn8(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D();
				obj._0023_003DzYFXWifrsG3fRPmCVbL0axdi3r_0024DS(num & num2);
				return obj;
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				int num3 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num3 & num4);
				}
				int num5 = Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj2 = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D();
				obj2._0023_003DzYFXWifrsG3fRPmCVbL0axdi3r_0024DS(num3 & num5);
				return obj2;
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				long num6 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				long num7 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D obj3 = new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D();
				obj3._0023_003DzgAt1mNmNuxVumV4R3YlFedE_003D(num6 & num7);
				return obj3;
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				int num8 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				long num9 = Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num8 & num9);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				int num10 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D()) & num10);
				}
				int num11 = Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj4 = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D();
				obj4._0023_003DzYFXWifrsG3fRPmCVbL0axdi3r_0024DS(num11 & num10);
				return obj4;
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				long num12 = Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				long num13 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D obj5 = new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D();
				obj5._0023_003DzgAt1mNmNuxVumV4R3YlFedE_003D(num12 & num13);
				return obj5;
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num14 = Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
					long num15 = Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num14 & num15);
				}
				int num16 = Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				int num17 = Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num16 & num17);
			}
		}
		throw new InvalidOperationException();
	}

	private bool _0023_003DzId474V6_002414Tv8fbnOURjPhw_003D(_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003Dzq80RbjQ_003D._0023_003DzVi5MXbrt8BXDXKmnYfbx7oiBSVGN().IsInitOnly)
		{
			return true;
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzVi5MXbrt8BXDXKmnYfbx7oiBSVGN().IsStatic != m__0023_003DzAXvW_0024Kw_003D._0023_003DzkElAVltokaRsq2qyltgIIyTvyqwv())
		{
			return false;
		}
		if (m__0023_003DzAXvW_0024Kw_003D._0023_003DzkElAVltokaRsq2qyltgIIyTvyqwv() && m__0023_003DzAXvW_0024Kw_003D._0023_003Dzijy_0024YuRSbTXlhC2ah706rnKCny8J() != _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525181))
		{
			return false;
		}
		Type type = _0023_003Dzq80RbjQ_003D._0023_003DzVi5MXbrt8BXDXKmnYfbx7oiBSVGN().DeclaringType;
		if (type.IsGenericType)
		{
			type = type.GetGenericTypeDefinition();
		}
		return _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(m__0023_003DzAXvW_0024Kw_003D._0023_003DzeFmYRYvMy4A0IhX6fIHDEUwm_00242cyzi_3XQ_003D_003D(), _0023_003DzZzVr6_0024U_003D: true) == type;
	}

	private static void _0023_003DzB_I0Cpdn82zMTQbngo20IxZe2DZ2vbcG5H1Xm73K_0024txj(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		Array array = (Array)_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(array.Length));
	}

	private void _0023_003Dz_0024AVDGBkSTbtVZvD9e2JWltw_003D(long _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzLi0XoCY_003D._0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D()._0023_003DzeAfqD85UAYY1g8prJCu4S9JwzuyBHOSQrVdSiwf3Lj4Gqu9mD0yaZmrEmeHhlRxoawLGCBo_003D(_0023_003Dzq80RbjQ_003D - _0023_003DzQ94e_m4_003D);
	}

	private bool _0023_003DzlcZ7as0cgsqN2QBjyn5wNa3Xb44CdEM7CQ_003D_003D(MethodBase _0023_003Dzq80RbjQ_003D, object _0023_003DzZzVr6_0024U_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] _0023_003Dz7hRN5Rg_003D, object[] _0023_003DzcbLoSrg_003D, bool _0023_003DzqMLoHoQ_003D, ref object _0023_003DzuwE9t4w_003D)
	{
		Type declaringType = _0023_003Dzq80RbjQ_003D.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (declaringType == _0023_003DzROtQTt4_003D && _0023_003Dzq80RbjQ_003D.Name == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525134) && _0023_003DzcbLoSrg_003D.Length == 2 && _0023_003Dzq80RbjQ_003D.ToString() == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525144))
		{
			_0023_003DqP99fuuOnAyhRKsayApRlnBMHKOOsMQGif97C_0024lQsbE4_003D._0023_003DzHfcHlpl4BqH_72J3Qa1WacSSm3Ms((Array)_0023_003DzcbLoSrg_003D[0], (RuntimeFieldHandle)_0023_003DzcbLoSrg_003D[1]);
			return true;
		}
		return false;
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dz6qpmpu8_00246GSUBpQjDrynoGJugrDNnltEnnGK9oQmwM5l(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				if (!_0023_003Dz7hRN5Rg_003D)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num % num2);
				}
				int num3 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				uint num4 = (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D((int)((uint)num3 % num4));
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzLuGlqWLl4cVPDKnZDQJHTuR2Wj2N02X5PLkfS5Q_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzLuGlqWLl4cVPDKnZDQJHTuR2Wj2N02X5PLkfS5Q_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
				}
				return _0023_003Dz6qpmpu8_00246GSUBpQjDrynoGJugrDNnltEnnGK9oQmwM5l(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzLuGlqWLl4cVPDKnZDQJHTuR2Wj2N02X5PLkfS5Q_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				return _0023_003DzLuGlqWLl4cVPDKnZDQJHTuR2Wj2N02X5PLkfS5Q_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003Dz7hRN5Rg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzLuGlqWLl4cVPDKnZDQJHTuR2Wj2N02X5PLkfS5Q_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
				}
				return _0023_003DzLuGlqWLl4cVPDKnZDQJHTuR2Wj2N02X5PLkfS5Q_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8 && _0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8)
		{
			_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
			obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D() % ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D());
			return obj;
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003Dz6qpmpu8_00246GSUBpQjDrynoGJugrDNnltEnnGK9oQmwM5l(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			}
			return _0023_003Dz6qpmpu8_00246GSUBpQjDrynoGJugrDNnltEnnGK9oQmwM5l(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
		}
		throw new InvalidOperationException();
	}

	private static bool _0023_003DzTrgTcTMfYB_0024_0024FAHVo8gUnnYGCc_0024m5Xkirg_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		bool result = false;
		switch (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
		{
		case 1:
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzTrgTcTMfYB_0024_0024FAHVo8gUnnYGCc_0024m5Xkirg_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())));
			}
			result = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() < ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
			break;
		case 13:
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzTrgTcTMfYB_0024_0024FAHVo8gUnnYGCc_0024m5Xkirg_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())));
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				return _0023_003DzTrgTcTMfYB_0024_0024FAHVo8gUnnYGCc_0024m5Xkirg_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()));
			}
			result = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() < ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			break;
		case 19:
			return _0023_003DzTrgTcTMfYB_0024_0024FAHVo8gUnnYGCc_0024m5Xkirg_003D_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), _0023_003DzZzVr6_0024U_003D);
		case 8:
			result = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D() < ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			break;
		}
		return result;
	}

	private MethodBase _0023_003DzyP50za2r3Cs8j4vEScuXoXIwmtKksc6pHqJxYG0_003D(_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D _0023_003Dzq80RbjQ_003D)
	{
		Type type = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003Dzq80RbjQ_003D._0023_003DzKdh11n0m88d_fpxANJjitRDG7epdVc5LAHf1XAY_003D()._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U(), _0023_003DzZzVr6_0024U_003D: false);
		BindingFlags bindingAttr = _0023_003DzCSHSVURxeddLciIcy_MROeX6xPuiKKpWmw_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzx_8whzdQOUZcw5LhCApjFMQ_003D());
		Type[] array = null;
		_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D[] array2 = _0023_003Dzq80RbjQ_003D._0023_003Dz3lC_0024Wjfyk4ghB256hH6dsHMuzwS45iW3n7EJINQ_003D();
		if (array2 != null)
		{
			array = new Type[array2.Length];
			for (int i = 0; i < array.Length; i++)
			{
				_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = array2[i];
				if (_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 != null)
				{
					array[i] = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U(), _0023_003DzZzVr6_0024U_003D: true);
				}
			}
		}
		MemberInfo[] member = type.GetMember(_0023_003Dzq80RbjQ_003D._0023_003DzYFISnatzWsztmppzzq1Q_K0gf2EF(), MemberTypes.Method, bindingAttr);
		MethodInfo methodInfo = null;
		int num = -1;
		MemberInfo[] array3 = member;
		for (int j = 0; j < array3.Length; j++)
		{
			MethodInfo methodInfo2 = (MethodInfo)array3[j];
			if (_0023_003DznUKOR0RU11ixCPFSXkMOp20_003D(methodInfo2, _0023_003Dzq80RbjQ_003D, array, out var num2) && num2 > num)
			{
				methodInfo = methodInfo2;
				num = num2;
			}
		}
		if (methodInfo == null)
		{
			throw new Exception(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525882), type.Name, _0023_003Dzq80RbjQ_003D._0023_003DzYFISnatzWsztmppzzq1Q_K0gf2EF()));
		}
		return methodInfo.MakeGenericMethod(array);
	}

	private void _0023_003DzMw7_0024EO1zJL4MyDs5_00243DxjS_NGViU1FlGfkRm6d8_003D(object _0023_003Dzq80RbjQ_003D, uint _0023_003DzZzVr6_0024U_003D)
	{
		bool flag = _0023_003Dzq80RbjQ_003D != null;
		_0023_003Dz0Ht_0024Sk0_003D = _0023_003Dzq80RbjQ_003D;
		if (flag)
		{
			this.m__0023_003Dzq80RbjQ_003D.Clear();
		}
		this.m__0023_003DzuwE9t4w_003D = flag;
		if (!flag)
		{
			this.m__0023_003Dzq80RbjQ_003D.Push(new _0023_003DzqMLoHoQ_003D(_0023_003DzZzVr6_0024U_003D));
		}
		_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D[] array = _0023_003DzF6BhvwY_003D;
		foreach (_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2 in array)
		{
			if (!_0023_003DzJbnsx8OjDsJ5RheGt9UV6NE_003D(this.m__0023_003Dzkl7CXTo_003D, _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw(), _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003DzPQUNNKOX2HDwNDSQ4BUJN_esq0Wmy5BYBg_003D_003D()))
			{
				continue;
			}
			switch (_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003Dzs9q2vFzh7MwWZjwRi_0024XYt3koyWHIgWGMKuIH6TWZ13oK())
			{
			case 2:
				if (flag || !_0023_003DzJbnsx8OjDsJ5RheGt9UV6NE_003D(_0023_003DzZzVr6_0024U_003D, _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw(), _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003DzPQUNNKOX2HDwNDSQ4BUJN_esq0Wmy5BYBg_003D_003D()))
				{
					this.m__0023_003Dzq80RbjQ_003D.Push(new _0023_003DzqMLoHoQ_003D(_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003Dz1NCi5yXDMjK9ywjfuA_003D_003D()));
				}
				break;
			case 1:
				if (flag)
				{
					this.m__0023_003Dzq80RbjQ_003D.Push(new _0023_003DzqMLoHoQ_003D(_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003Dz1NCi5yXDMjK9ywjfuA_003D_003D()));
				}
				break;
			case 4:
				if (flag)
				{
					this.m__0023_003Dzq80RbjQ_003D.Push(new _0023_003DzqMLoHoQ_003D(_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003Dz_0024uw8DCphnXCbUhknM7b4qXw_003D(), _0023_003Dzq80RbjQ_003D));
				}
				break;
			case 0:
				if (flag)
				{
					Type type = _0023_003Dzq80RbjQ_003D.GetType();
					Type type2 = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003DzhwYjvJfKTfcrQloEyDALz_0024zZX58ECoQZZQ_003D_003D(), _0023_003DzZzVr6_0024U_003D: true);
					if (type == type2 || type.IsSubclassOf(type2))
					{
						this.m__0023_003Dzq80RbjQ_003D.Push(new _0023_003DzqMLoHoQ_003D(_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003Dz1NCi5yXDMjK9ywjfuA_003D_003D(), _0023_003Dzq80RbjQ_003D));
						this.m__0023_003DzuwE9t4w_003D = false;
					}
				}
				break;
			}
		}
		_0023_003DzDpNz_0024ws8Z8wzT_0024TQLl8uOeAxUIl9();
	}

	private static bool _0023_003DzzSxlP7p7A1i7hCkzVLOALyccn0F3(object _0023_003Dzq80RbjQ_003D)
	{
		return RemotingServices.IsTransparentProxy(_0023_003Dzq80RbjQ_003D);
	}

	private static void _0023_003DzupRoQGJO4og5Auiiqa83x9ZmEYrgTBN5Ag_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzbkB7sMGOzoMZR1tZ5x8adrEVlhbHCkoa9w_003D_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private static void _0023_003DzULYgVkJrgYJZLEG_sG_0024y0g7GaxzphXQpSw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2 = _0023_003Dzmjx3IYVmxm4H_sfJfSlPWXT2veAi(_0023_003Dzq80RbjQ_003D);
		_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003DzLi0XoCY_003D._0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D();
		long num = _0023_003Dzq80RbjQ_003D._0023_003DzeE3jiLrpSvA9TWmZ_0024_0024gF_00_003D();
		byte[] array = new _0023_003DqHG1TmG_0024dSF7XquINMc2Zz70dWtTQ2CxWuU2XR_0024MiL8c_003D(_0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2._0023_003Dz_0024zQo_0024B75Ge1AkfsQnDYeN3Sw3u9O03TL5qVPqBfr02F4UIiat3oe3Nr1wA_00246eyvumJMd5jDMPJu2XR21SQ_003D_003D(), _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2._0023_003DzrLViyGP3d5fPD8YJiovkCFoTRTt56uOzWY0hG_0024UlewBKZjtAezweZoQGAhz6_08VuSfhDKc_dvr9Btl5qBCDQzs_003D())._0023_003Dz7GzVKHigmAjHE5FVN5SuT1iQo6K1(_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D2, _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2);
		_0023_003DzUH03yec_003D _0023_003DzUH03yec_003D2 = new _0023_003DzUH03yec_003D
		{
			_0023_003Dzq80RbjQ_003D = _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2,
			_0023_003DzcbLoSrg_003D = num
		};
		_0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2._0023_003Dz_vEj4OwnFcwGRmsKmXLdsTKLz3BfOqLGo03HpMs_003D(_0023_003Dq6ddeMh0jPjn0m3HHEFyd_UzyP04hcfbzuH_iOk0_4Fk_003D._0023_003DzPfA3Uw7vkcjX8tmk6mF4leo_003D(array.Length) - array.Length);
		_0023_003DzUH03yec_003D2._0023_003DzZzVr6_0024U_003D = new _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D(_0023_003DzUH03yec_003D2._0023_003Dz7hRN5Rg_003D = new _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D(array, 0, array.Length, _0023_003DzcbLoSrg_003D: false));
		_0023_003Dzq80RbjQ_003D._0023_003DzbKacmMjJlAozzsmL94D6Uq6kYdq6().Push(_0023_003DzUH03yec_003D2);
		_0023_003Dzq80RbjQ_003D._0023_003DzmSUiy7sPdkHWa_kpgPiolyyCqWUwmeU_lBOK610_003D(_0023_003DzUH03yec_003D2);
	}

	private static void _0023_003Dz7SM5Jq7Sn9usAsrlmUP_qoAXEo6P(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DztP7PBX2bGr9qR_8NV2HJNQoKwjzAZkYaog_003D_003D(0);
	}

	private static void _0023_003Dzc0K_0024LvVv018XpthMcunUS_0024GsFo64(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(4);
	}

	private static void _0023_003DzOTfcEAzNEmX8tQo6BwpN5Nc_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzcHX5J0_BxaBvebV44eNBFeg_003D(2);
	}

	private static void _0023_003DzS_cFdMV_5cxE_0024umF5IEAKCU_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
	}

	private string _0023_003DznMMoGwkuIQcygw5U_0024AEZNRBpmYc2MOYYByXiysPYi1HR(int _0023_003Dzq80RbjQ_003D)
	{
		lock (_0023_003DzxHwNxiw_003D)
		{
			bool flag = true;
			if (flag && _0023_003DzxHwNxiw_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out var value))
			{
				return (string)value;
			}
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = _0023_003Dz2VVL65ZUV4mNemmPJRTlKGJnuqYG(_0023_003Dzq80RbjQ_003D);
			if (_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003Dzip8yWLvtIndlQqoIuur_x1i0otdXn27UJQ_003D_003D() == 0)
			{
				return this.m__0023_003DzkJp9o4I_003D.ResolveString(_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U());
			}
			string text = ((_0023_003DqH5eXSVTJbmcb779MRNN3P8JeW_Ou9lYKwJ3hWlIm56g_003D)_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003DzqZLvK7FhPMHAcJUCHWtKXWMzPckK())._0023_003Dz_6h_WCKjl2e91zvQ_qjlEhLt2en88PbG9w_003D_003D();
			if (flag)
			{
				_0023_003DzxHwNxiw_003D.Add(_0023_003Dzq80RbjQ_003D, text);
			}
			return text;
		}
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzV3inriSZO20nAilFUfefq9Z1GNCidoulXQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num ^ num2);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				int num3 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num3 ^ num4);
				}
				int num5 = Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num3 ^ num5);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				long num6 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				long num7 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num6 ^ num7);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				int num8 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				long num9 = Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num8 ^ num9);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				int num10 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D()) ^ num10);
				}
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D()) ^ num10);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				long num11 = Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				long num12 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num11 ^ num12);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num13 = Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
					long num14 = Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num13 ^ num14);
				}
				int num15 = Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				int num16 = Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num15 ^ num16);
			}
		}
		throw new InvalidOperationException();
	}

	private void _0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D()
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 = (_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D)_0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
	}

	private void _0023_003DzVxxOU20Y14TmVDpN8nwBlbY_003D(_0023_003DqIYwamc_0024xa95DzIZnwgV16GUGEnPX47klc5OnsJ5eGRU_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = _0023_003Dz2VVL65ZUV4mNemmPJRTlKGJnuqYG(_0023_003Dzq80RbjQ_003D._0023_003DzjGR5DEzTJR6IfkrHTaw2P9YOQznstlhv2A_003D_003D());
		MethodBase methodBase = _0023_003DzceSsf__0024vYBWVlbSQGwq0O1iA1r3ZVmzrJbM9ET8_003D(_0023_003Dzq80RbjQ_003D._0023_003DzjGR5DEzTJR6IfkrHTaw2P9YOQznstlhv2A_003D_003D(), _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2);
		int num = _0023_003Dzq80RbjQ_003D._0023_003DzGf3tou7cBOrcpin0mvOeewn2CkE66dUv9arV_0E_003D();
		bool flag = (num & 0x40000000) != 0;
		num &= -1073741825;
		Type[] array = _0023_003DzuUxvxmo_003D;
		Type[] array2 = this.m__0023_003DzcbLoSrg_003D;
		try
		{
			_0023_003DzuUxvxmo_003D = ((methodBase is ConstructorInfo) ? null : methodBase.GetGenericArguments());
			this.m__0023_003DzcbLoSrg_003D = methodBase.DeclaringType.GetGenericArguments();
			_0023_003DzkSoK2ou7NfSIMX60M6qb_0024GQxFe4n(num, _0023_003DzuUxvxmo_003D, this.m__0023_003DzcbLoSrg_003D, flag);
		}
		finally
		{
			_0023_003DzuUxvxmo_003D = array;
			this.m__0023_003DzcbLoSrg_003D = array2;
		}
	}

	private static void _0023_003Dz3qWP4c1DvJ_0024mPpeOwUVPFpcExenfCcmz_qQPSGU_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzwwYHocafLvZVCJjHxDwZ0C6f7DiZFaT1uyucXN4_003D(((_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzjMeEJ3HfdiVVM9FdsA_003D_003D());
	}

	private static byte[] _0023_003DzpYs7mVJ9Stj5X_U7NKxVDmKXKEtSKshy0FpZr1g_003D(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
		int num = _0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D();
		byte[] result = new byte[num];
		_0023_003Dzq80RbjQ_003D._0023_003DzSlkabk59KHIoAbDGK_0024tNGSk_0024dqH_qsBGNg_003D_003D(result, 0, num);
		return result;
	}

	private static void _0023_003DzEORZFgJLZzrNpMBigbc6ozDwwwIx(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOUcX6xmBJPIP_7C2l8V5J1Q_TYlNJSFdIg_003D_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	private bool _0023_003DzD17J_00249nyBtvNWVsxsinCvvg_003D(MethodBase _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003Dzq80RbjQ_003D.IsVirtual)
		{
			return false;
		}
		if (_0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(m__0023_003DzAXvW_0024Kw_003D._0023_003DzeFmYRYvMy4A0IhX6fIHDEUwm_00242cyzi_3XQ_003D_003D(), _0023_003DzZzVr6_0024U_003D: true).IsSubclassOf(_0023_003Dzq80RbjQ_003D.DeclaringType))
		{
			return true;
		}
		return false;
	}

	private static void _0023_003DzwWQxGw7tMn54A_IbLDJpSEglaSmvIW9QVw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dzq80RbjQ_003D._0023_003DzyjHfiEuMPYll0RDob6zl0keHOmlFMAbbcQMHClc_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2));
	}

	private void _0023_003DzbkB7sMGOzoMZR1tZ5x8adrEVlhbHCkoa9w_003D_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		bool flag = IntPtr.Size == 4;
		IntPtr intPtr;
		switch (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
		{
		case 1:
		{
			int value = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
			intPtr = ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr(value) : new IntPtr(value));
			break;
		}
		case 13:
		{
			long num = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			intPtr = ((!flag) ? ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr(num) : new IntPtr(num)) : ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr((int)num) : new IntPtr(checked((int)num))));
			break;
		}
		case 8:
		{
			double num2 = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			intPtr = ((!flag) ? ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr((long)num2) : new IntPtr(checked((long)num2))) : ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr((int)num2) : new IntPtr(checked((int)num2))));
			break;
		}
		case 19:
			intPtr = ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr((long)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())) : new IntPtr(checked((long)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()))));
			break;
		default:
			throw new InvalidOperationException();
		}
		_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D obj = new _0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D();
		obj._0023_003Dz_0024eT0u_00244AlLxv9vzC5bag2xx1uYIycKqC7_Qs0Bo_003D(intPtr);
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D[] _0023_003Dz3Q8ivFZzYWihyo2kkBx62nzPp3j36PUShvWFrds_003D(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
		int num = _0023_003Dzq80RbjQ_003D._0023_003DzAT5B_0024KrVlUL38D8pF9i1EEk_003D();
		_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D[] array = new _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = _0023_003Dzx65u8Kf6xtbuj_EnDGkijiRXjMXp_00249jBfm2Dlfo_003D(_0023_003Dzq80RbjQ_003D);
		}
		return array;
	}

	private static void _0023_003DzjO11umMCAzf9GqzG4kLFHr75TAOK(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (_0023_003DzTrgTcTMfYB_0024_0024FAHVo8gUnnYGCc_0024m5Xkirg_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private static void _0023_003DzUJbiAwdQqdFzYo_yiXOysOWjJmOqkyxkJTu0WCI_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(sbyte));
	}

	private static void _0023_003DzjPhLzJE6PevUjK8mybmqbwJSMa43PgW1W64Gewk_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524789));
	}

	private static void _0023_003DzKhkJn5TKJBMIZ213_0024AJ6ItKJNWLP(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DziOj6_RXYwX3_0024SFIeNVIQ1jxYOaZqJwP14A_003D_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	private static void _0023_003DzwnSzJsLRNX47hBMdniaU7HjbgBVl(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type elementType = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		int length;
		if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 is _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2)
		{
			length = _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		}
		else if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 is _0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D _0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D2)
		{
			length = _0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D2._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr().ToInt32();
		}
		else
		{
			if (!(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 is _0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D _0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D2))
			{
				throw new Exception();
			}
			length = (int)_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D2._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D().ToUInt32();
		}
		Array array = Array.CreateInstance(elementType, length);
		_0023_003Dq7Y_X1LJ_wwdl9r12hZAPJQpn7cOzytFyKfE_0024WrTLigc_003D obj = new _0023_003Dq7Y_X1LJ_wwdl9r12hZAPJQpn7cOzytFyKfE_0024WrTLigc_003D();
		obj._0023_003Dzx6Cy9POBb2O5o9K6QwUi_yapCuB_0024R_0024hYM6kuXhU_003D(array);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static void _0023_003DzatYrshQK7CmwDe29ij7k8f32_OdPqLrartR9wlg_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(uint));
	}

	private static void _0023_003DzIzPpIcM75vjX0_AV5K6_0024NB3KncyyLw0Iiw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzvQQP5BELn8vLJ6Gf7XVrZxFAvcN15nzHnA_003D_003D(_0023_003DzZzVr6_0024U_003D);
	}

	private static void _0023_003Dz9ePHpdeeK_0024qiQw_zCTvLNtw_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(2);
	}

	private static void _0023_003DzUfkGPJiBrG97H40RleXTJdI_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzUcfwXkVt2OiFJi6klqPNUOc_003D(_0023_003Dzq80RbjQ_003D: true, _0023_003DzZzVr6_0024U_003D: true);
	}

	private static Exception _0023_003DzaWqfW1XbxjFJHEqe2NyQ60ah4dXEb3g5kWwI2p2LZ38J(string _0023_003Dzq80RbjQ_003D, string _0023_003DzZzVr6_0024U_003D)
	{
		return new MethodAccessException(_0023_003DzW9inGhxh3D5B3aHEojMGBQ4wP7uXJo8QviUuDOA_003D(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526647) + _0023_003Dzq80RbjQ_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526611), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526144) + _0023_003DzZzVr6_0024U_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526611)));
	}

	private static _0023_003DzuwE9t4w_003D _0023_003DzKLApn_uNcxCYi0_0024FfFrg_0024grx_00242pDREUTbw_003D_003D(_0023_003DzkJp9o4I_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzuwE9t4w_003D value;
		lock (_0023_003DzBa3Kf5Y_003D)
		{
			_0023_003DzBa3Kf5Y_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out value);
		}
		if (value != null)
		{
			return value;
		}
		MethodBase key = _0023_003Dzq80RbjQ_003D._0023_003Dz5FQSKSm6B3sKlUlrhmg1z7BQAoRYhH4XkeDioNw_003D();
		lock (_0023_003DzwLLvGQs_003D)
		{
			while (_0023_003DzwLLvGQs_003D.ContainsKey(key))
			{
				Monitor.Wait(_0023_003DzwLLvGQs_003D);
			}
			_0023_003DzwLLvGQs_003D[key] = null;
		}
		try
		{
			lock (_0023_003DzBa3Kf5Y_003D)
			{
				_0023_003DzBa3Kf5Y_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out value);
			}
			if (value == null)
			{
				value = _0023_003DzjG2c_0024HiqBDADYewlgSyJ0QjjuE0U(key, _0023_003Dzq80RbjQ_003D._0023_003Dz5I6xus_DQeKRDBxdDd4yTIuOFHZ89NZXe1lxOlg_003D());
				lock (_0023_003DzBa3Kf5Y_003D)
				{
					_0023_003DzBa3Kf5Y_003D[_0023_003Dzq80RbjQ_003D] = value;
				}
			}
			return value;
		}
		finally
		{
			lock (_0023_003DzwLLvGQs_003D)
			{
				_0023_003DzwLLvGQs_003D.Remove(key);
				Monitor.PulseAll(_0023_003DzwLLvGQs_003D);
			}
		}
	}

	private static void _0023_003DzZS_rhl4K7iNTi60ADiKudawjx7wWmjgjh3u4MJg_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525705));
	}

	private static void _0023_003DznD3OC_vD3i2ZHIykaAoMUcXhZJLxWt3muw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(checked(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (sbyte)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (sbyte)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => (sbyte)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			8 => (sbyte)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((sbyte)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((sbyte)(uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private void _0023_003DzD2uSK_0024mBXXfGbn5bMRWJScc_003D(MethodBase _0023_003Dzq80RbjQ_003D, bool _0023_003DzZzVr6_0024U_003D)
	{
		bool flag = !_0023_003DzZzVr6_0024U_003D && _0023_003DzD17J_00249nyBtvNWVsxsinCvvg_003D(_0023_003Dzq80RbjQ_003D);
		if (flag && _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003DzcbLoSrg_003D._0023_003Dzq80RbjQ_003D)
		{
			_0023_003Dzq80RbjQ_003D = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003Dz5QkdKZk_003D._0023_003Dz0XWS4j1Vldv5HPdX3cWziHrG_0024ijmCmR2Bw_003D_003D(this, m__0023_003DzAXvW_0024Kw_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
		}
		ParameterInfo[] parameters = _0023_003Dzq80RbjQ_003D.GetParameters();
		int num = parameters.Length;
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] array = new _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[num];
		object[] array2 = new object[num];
		_0023_003Dz7hRN5Rg_003D _0023_003Dz7hRN5Rg_003D2 = default(_0023_003Dz7hRN5Rg_003D);
		try
		{
			_0023_003Dzfq_0024PZ9sR_1WJjmN7UTu1nCM61IyKGWqi1C4Qpos_003D(ref _0023_003Dz7hRN5Rg_003D2, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = (array[num2] = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D());
				if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2);
				}
				if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D() != null)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D())._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
				}
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, parameters[num2].ParameterType)._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
				array2[num2] = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
			}
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 = null;
			if (!_0023_003Dzq80RbjQ_003D.IsStatic)
			{
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
				if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 != null && _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D() != null)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D())._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4);
				}
			}
			object obj = null;
			object obj2 = null;
			try
			{
				if (_0023_003Dzq80RbjQ_003D.IsConstructor)
				{
					obj = Activator.CreateInstance(_0023_003Dzq80RbjQ_003D.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, array2, null);
					if (!(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D))
					{
						throw new InvalidOperationException();
					}
					obj2 = obj;
				}
				else
				{
					if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 != null)
					{
						_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D5 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4;
						if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D3)
						{
							_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D5 = _0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D3);
						}
						obj2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D5._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					}
					try
					{
						if (!_0023_003DzD_Gu1XgYdlFBskkd4_0024QxuMSX96L4mNU5TQcY1pg_003D(_0023_003Dzq80RbjQ_003D, obj2, ref obj, array2))
						{
							if (_0023_003DzZzVr6_0024U_003D && !_0023_003Dzq80RbjQ_003D.IsStatic && obj2 == null)
							{
								throw new NullReferenceException();
							}
							if (!_0023_003DzlcZ7as0cgsqN2QBjyn5wNa3Xb44CdEM7CQ_003D_003D(_0023_003Dzq80RbjQ_003D, obj2, array, array2, _0023_003DzZzVr6_0024U_003D, ref obj))
							{
								MethodBase methodBase = _0023_003Dzq80RbjQ_003D;
								object obj3 = obj2;
								if (flag && !_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003DzcbLoSrg_003D._0023_003Dzq80RbjQ_003D)
								{
									obj3 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003DzoVpU9JU_003D._0023_003Dzt0Sa1EkMEFGHDIuef_0024X3COqmJZ2T2bmDzdjUILo_003D(obj2, _0023_003Dzq80RbjQ_003D, out var methodInfo);
									methodBase = methodInfo;
								}
								obj = _0023_003Dzn6drv421fV0O5urB0a70eJS0cc7fu428Yw_003D_003D(methodBase, obj3, array2, _0023_003DzZzVr6_0024U_003D);
							}
						}
					}
					catch (TargetInvocationException ex)
					{
						Exception ex2 = ex.InnerException ?? ex;
						_0023_003DzYdwOeQ6ohJIqRySc0WL8wF8xQ56H(ex2);
					}
				}
			}
			finally
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D4)
					{
						object obj4 = array2[i];
						_0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D4, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj4, null));
					}
				}
				if (obj2 != null && _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D5)
				{
					bool flag2 = true;
					if (_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D5 is _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2)
					{
						flag2 = _0023_003DzId474V6_002414Tv8fbnOURjPhw_003D(_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2);
					}
					if (flag2)
					{
						_0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D5, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj2, _0023_003Dzq80RbjQ_003D.DeclaringType));
					}
				}
			}
			MethodInfo methodInfo2 = _0023_003Dzq80RbjQ_003D as MethodInfo;
			if (methodInfo2 != null)
			{
				Type returnType = methodInfo2.ReturnType;
				if (returnType != _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzLaPeX80_003D)
				{
					_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, returnType));
				}
			}
		}
		finally
		{
			_0023_003Dz8dAiRnC0PuZ5ifCo_bCVFSS81KMh(ref _0023_003Dz7hRN5Rg_003D2);
		}
	}

	private _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003Dz2VVL65ZUV4mNemmPJRTlKGJnuqYG(int _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003DzAwa9dP4_003D == null)
		{
			throw new InvalidOperationException();
		}
		lock (_0023_003DzAwa9dP4_003D._0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D())
		{
			_0023_003DzAwa9dP4_003D._0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D()._0023_003DzI4vE0RkXfN1pne8gbSVDgBlALYg3vbbRkBocu_0024P6sDNdA9J9PRaszMCsJP8vkAvSyWXjY_0024fkw_sdJCJA_0024Q_003D_003D(_0023_003Dzq80RbjQ_003D, 0);
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D();
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003DzWK2CB4P4S43UhAF7Ohcvad6TBRB8(_0023_003DzAwa9dP4_003D._0023_003Dzgie8dX3wQlY8J8uAg8gyr39CXYW8L0PGHZYb0G4_003D());
			if (_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003Dzip8yWLvtIndlQqoIuur_x1i0otdXn27UJQ_003D_003D() == 0)
			{
				_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003DzhRZDIQHIxirWOYKyfQ_003D_003D(_0023_003DzAwa9dP4_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			}
			else
			{
				_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003Dz1qEMUqHcbDMQyy6In4C4_W2RVJjFMnZ5QS8qTjCeCPKb(_0023_003DzyCQ_1sSPuE7Y9nTFceT7ATo_00242T0jPpq67rirGSEJR_1M(_0023_003DzAwa9dP4_003D));
			}
			return _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2;
		}
	}

	private static void _0023_003DzL3COyLSGB6YouaE4Szo2ycfnKwwDF4qy_0024w_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzubfuoE_0024ivGL5iSuJj7CdjY8akdxBogEezQYRU10_003D(_0023_003DzZzVr6_0024U_003D);
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzNyPpvtkyCbUFL4rR9_0024JNDX33Hx21x3_0024WX77zFZf8Xk5Y(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		if (!_0023_003DzcbLoSrg_003D)
		{
			long num = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			long num2 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			long num3 = ((!_0023_003Dz7hRN5Rg_003D) ? (num + num2) : checked(num + num2));
			return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		ulong num5 = (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		ulong num6 = ((!_0023_003Dz7hRN5Rg_003D) ? (num4 + num5) : checked(num4 + num5));
		return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D((long)num6);
	}

	private static void _0023_003DzgR00JgM9ObtiyPMUrTu_WStYaLm5(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525080));
	}

	private void _0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(uint _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dz5SBVqVA_003D = _0023_003Dzq80RbjQ_003D;
	}

	private static void _0023_003DzGnZSL_00247n73ZJNABC32XlOuc7tJQz_0024cGKgQ_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DziOj6_RXYwX3_0024SFIeNVIQ1jxYOaZqJwP14A_003D_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private static object _0023_003DzgCnHr6_0024NKsiKffk0iw_003D_003D(MethodBase _0023_003Dzq80RbjQ_003D, object _0023_003DzZzVr6_0024U_003D, object[] _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D.IsConstructor)
		{
			try
			{
				return Activator.CreateInstance(_0023_003Dzq80RbjQ_003D.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0023_003Dz7hRN5Rg_003D, null);
			}
			catch (AmbiguousMatchException)
			{
				return ((ConstructorInfo)_0023_003Dzq80RbjQ_003D).Invoke(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0023_003Dz7hRN5Rg_003D, null);
			}
		}
		return _0023_003Dzq80RbjQ_003D.Invoke(_0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
	}

	private static void _0023_003DzsFFDStjA_R9nrAiXFtslC9EC53rjTr8Iiw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		Debugger.Break();
	}

	[Conditional("DEBUG")]
	public static void _0023_003DzCtHt9wDRIMWeuRn0EYqt9DnZHc_Y(string _0023_003Dzq80RbjQ_003D)
	{
	}

	private static Dictionary<int, _0023_003DzKyPCKaY_003D> _0023_003DzyqIdOhbNg64V0ecLy5ctHtNw6HE2(_0023_003DqUR7_0024aTHoiijy1rATVvJvahY_rqH1dc0o22bEKz0H3wo_003D _0023_003Dzq80RbjQ_003D)
	{
		return new Dictionary<int, _0023_003DzKyPCKaY_003D>(256)
		{
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzYL7wouc_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzYL7wouc_003D, _0023_003DzRQyIhIIrrG2vD4A4u5x_3Nc68vq7)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz5Z4gvtc_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz5Z4gvtc_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzubfuoE_0024ivGL5iSuJj7CdjY8akdxBogEezQYRU10_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz5qKRdzI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz5qKRdzI_003D, _0023_003Dz1U_RBk3JnoEBw6QBa93gVavPvCWc)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzZzVr6_0024U_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzZzVr6_0024U_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					if (!_0023_003DzTrgTcTMfYB_0024_0024FAHVo8gUnnYGCc_0024m5Xkirg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
					{
						uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
					}
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz4A3Alm0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz4A3Alm0_003D, _0023_003DzKBNvdUv3unYDfjrfFtRfV9NlORN7)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzd8oBCP0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzd8oBCP0_003D, _0023_003DzF9QRcvt3zS3hQlqwPzlgEqn_ppnzHWVbqg_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzH_00242zw_0024c_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzH_00242zw_0024c_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzEuJaDpmLytpSBTEoXDVyq_o_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003Dz048eNPCCLNNmZFIiW7pSmsLry714y0ieZoaY0obA2vjaWKhL_0024Ft9HlWoFrDEcPmBFkeHbqme9OIi());
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzuwE9t4w_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzuwE9t4w_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz6uwpXMENmglaFBA5cfbtfP3Gde20_280x37pdP0_003D(_0023_003Dzq80RbjQ_003D: true);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzH9Cfb_0024c_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzH9Cfb_0024c_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					MethodBase methodBase = ((_0023_003Dqqr0fJcmNHD_002426q7CfYl3TIKslsTynyI2_0024uUSOUtw4jk_003D)_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D())._0023_003DzhPsFl9DgX11KA9Mha_0024sgPXE_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzD2uSK_0024mBXXfGbn5bMRWJScc_003D(methodBase, _0023_003DzZzVr6_0024U_003D: false);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzA7hfB1A_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzA7hfB1A_003D, _0023_003DzZ6Cpf9Lk2os2WdTipDtbn3xlujHbhXi0C49Q2tc_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzbtij9_00248_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzbtij9_00248_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzmJcTjZMU20gnWIs5PUtcynYB9r4_0024tmr4dl3qxi0_003D(_0023_003Dzq80RbjQ_003D: true);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzoYDTc8U_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzoYDTc8U_003D, _0023_003Dz8rlusmH1LHFia1LJyVAOPmCBI8vZwND1vpfWsX5tToJL)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzaSf_0024Uuo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzaSf_0024Uuo_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
					{
						1 => (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
						13 => ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
						19 => (long)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
						8 => (long)checked((ulong)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
						0 => (IntPtr.Size != 4) ? ((long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
						_ => throw new InvalidOperationException(), 
					}));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzvOTbM3Y_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzvOTbM3Y_003D, _0023_003DzLz4EQy5GlM9zzeCPcfEaI5LC273zjcCk9alP09Q_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzX7Gt1Sw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzX7Gt1Sw_003D, _0023_003DzjPhLzJE6PevUjK8mybmqbwJSMa43PgW1W64Gewk_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzqMLoHoQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzqMLoHoQ_003D, _0023_003Dz7fEyAIRftNckR6dXW_ryUZQ_MkRi)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzHbUo3O0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzHbUo3O0_003D, _0023_003DzenLkeMckiNQ5N9KoMJWkpDiqaXeZbRMIKm4ik_s_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzUH03yec_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzUH03yec_003D, _0023_003DzqPEgj9aUtE7_OvGB2nLLe65iiW7b)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz_0024RKF2QA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz_0024RKF2QA_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4)
				{
					object obj = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					long num = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5();
					Array array = (Array)_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					Type elementType = array.GetType().GetElementType();
					if (elementType == typeof(int))
					{
						_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(int));
						((int[])array)[num] = (int)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					}
					else if (elementType == typeof(uint))
					{
						_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(uint));
						((uint[])array)[num] = (uint)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					}
					else if (elementType.IsEnum)
					{
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(elementType, obj, num, array);
					}
					else
					{
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(typeof(int), obj, num, array);
					}
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzuaKKESU_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzuaKKESU_003D, _0023_003DzMkjl5tvnsg6DfgcObDCO9klKUxR_3OUYjhHgDJRO8DbJ)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzeJLIX5w_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzeJLIX5w_003D, _0023_003DzGVoJlTJe8jBu0NafbQhvFX8_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzDoFU9f0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzDoFU9f0_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(2);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dztzj32iA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dztzj32iA_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(2);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzuW1CqYA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzuW1CqYA_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					FieldInfo fieldInfo = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num);
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2)
					{
						_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2);
					}
					object obj = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					if (obj == null)
					{
						throw new NullReferenceException();
					}
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(fieldInfo.GetValue(obj), fieldInfo.FieldType));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzyc0iBLA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzyc0iBLA_003D, _0023_003Dz8_vsmijeoGtimvm7Dgab31w_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzbNUssNo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzbNUssNo_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzwwYHocafLvZVCJjHxDwZ0C6f7DiZFaT1uyucXN4_003D(((_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzjMeEJ3HfdiVVM9FdsA_003D_003D());
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz_0024qvd3Jk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz_0024qvd3Jk_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DziOj6_RXYwX3_0024SFIeNVIQ1jxYOaZqJwP14A_003D_003D(_0023_003Dzq80RbjQ_003D: true);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzzYs24lA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzzYs24lA_003D, _0023_003DzxUX7rtOex1S_8nsaFFVDdrdJ3ist)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzv0iXCdI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzv0iXCdI_003D, _0023_003DzjO11umMCAzf9GqzG4kLFHr75TAOK)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dztc_0024ann8_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dztc_0024ann8_003D, _0023_003DzYH_n6W6t8O_NrvzMsj4WSSo2Uc7k)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz0Ht_0024Sk0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz0Ht_0024Sk0_003D, _0023_003DzzuMCglfRO3MHdQFVKPssCLjezarL2IGMlw_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzAZ_00241IwQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzAZ_00241IwQ_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzGK5WKeBvR9cWZYGHWewhHmFceBV2(_0023_003Dzq80RbjQ_003D: false, _0023_003DzZzVr6_0024U_003D: false);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzG_0024GQjQU_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzG_0024GQjQU_003D, _0023_003DzPOsbsKQW9CM2HhnXmTjyGvHxNtS24yG1vMUhG7k_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzd8qN_0024fo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzd8qN_0024fo_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(8);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz6_0024t9doE_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz6_0024t9doE_003D, _0023_003DzsFFDStjA_R9nrAiXFtslC9EC53rjTr8Iiw_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz6_0024GU_0024Fc_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz6_0024GU_0024Fc_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzUcfwXkVt2OiFJi6klqPNUOc_003D(_0023_003Dzq80RbjQ_003D: true, _0023_003DzZzVr6_0024U_003D: false);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz3kOEF2U_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz3kOEF2U_003D, _0023_003DzJtWQe_1UdTLJHnDeeFXaLLT7W0egraj_CQ_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzJCMPY20_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzJCMPY20_003D, _0023_003DzCcNqaKuG9WCaEPBQGcUX8TfCVuoC)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz8oxZp4M_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz8oxZp4M_003D, _0023_003DzZRP8pjH_sY5FpFyIsqrGkqTHK0xkfw6uPLQNs9I_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzI88heNE_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzI88heNE_003D, _0023_003DzozftuLhHQFpq9HCy2Ypr8JX0BuDL8EPIDVuvhl_iEfdt)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzkl7CXTo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzkl7CXTo_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzgvGx8MFmQfFwyuAFc7msZwqmhV7g(_0023_003Dzq80RbjQ_003D: true);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz3BbTphQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz3BbTphQ_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzPJCaFZeVnLaddax8TLiglvsSl8LBjm32MPmYr7H1LVhl(_0023_003Dzq80RbjQ_003D: true);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DznA0KbrY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DznA0KbrY_003D, _0023_003DzOxu07ljmyqjk9oMgrWF5mo1yIA_iLzBocCRvbYq5ozOE)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzROtQTt4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzROtQTt4_003D, _0023_003Dz8oUq136qcdKSyWMwemrkg2M_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz_00245S1SHE_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz_00245S1SHE_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(checked(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
					{
						1 => (ushort)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
						13 => (ushort)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
						19 => (ushort)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
						8 => (ushort)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((ushort)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((ushort)(uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzb8NOAOw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzb8NOAOw_003D, _0023_003Dz_wIsa1VOaxJ6xCR82CvMzXY_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzUvjxD1c_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzUvjxD1c_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					bool flag = false;
					if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
					{
						1 => ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() != 0, 
						13 => ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() != 0, 
						0 => ((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr() != IntPtr.Zero, 
						20 => ((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D() != UIntPtr.Zero, 
						19 => Convert.ToBoolean(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
						7 => ((_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzvPsFwllF9YUejQF68VzjbUs4hENNmXLLhEVR500jpyde() != null, 
						_ => _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() != null, 
					})
					{
						uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
					}
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzwzL6DAY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzwzL6DAY_003D, _0023_003Dz9Wf6VkzGlqXZNQ9bpJ_ZLZA_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzjhZqSy0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzjhZqSy0_003D, _0023_003Dzt74TV6cAWtutZoXohh0jW0E_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzOzh68Jk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzOzh68Jk_003D, _0023_003Dz7SM5Jq7Sn9usAsrlmUP_qoAXEo6P)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzWQeOcdQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzWQeOcdQ_003D, _0023_003DzreUbpGkRgf9zkfyXCTZxXuA_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzzDP2VK4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzzDP2VK4_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz2VVL65ZUV4mNemmPJRTlKGJnuqYG(num);
					object obj = ((_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003Dzip8yWLvtIndlQqoIuur_x1i0otdXn27UJQ_003D_003D() == 0) ? _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz3WMplEOlITZ12UoH9HOKn3udSV_acKBw3g_003D_003D(_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U()) : (_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003DzqZLvK7FhPMHAcJUCHWtKXWMzPckK()._0023_003DzqOu1TN1s3NS2hQUVPYsa_00244SKYkVab0KlLpt1jtZUdMgMAIWTGqK_0024tMpMMJ_fDsOKZJ9ioF1ZC4AWhKibZPHTf6Y_003D() switch
					{
						2 => _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true).TypeHandle, 
						0 => _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(num).MethodHandle, 
						1 => _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num).FieldHandle, 
						_ => throw new InvalidOperationException(), 
					}));
					_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D obj2 = new _0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D();
					obj2._0023_003DzTeWYaTS0cogWoCNsB7HPNo0_003D(obj);
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj2);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzufvRAV0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzufvRAV0_003D, _0023_003DzatYrshQK7CmwDe29ij7k8f32_OdPqLrartR9wlg_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzAwa9dP4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzAwa9dP4_003D, _0023_003DzGcd7mcr2H3A1MSVV7rqVVmf4oQOU)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz0xDSfi4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz0xDSfi4_003D, _0023_003DzyZ_trJHGDiHWc962Xvt9PTo_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzLaPeX80_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzLaPeX80_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(0);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz5QkdKZk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz5QkdKZk_003D, _0023_003DzM6joOyKYQHZabFhqf8JhjF4uafeP4c7hIg_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzjnY9xUw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzjnY9xUw_003D, _0023_003Dz9Ne9W5OFkzCU1uBfSMUCk2I_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzOrMR9qY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzOrMR9qY_003D, _0023_003DzUQ2blmXPH8jGs_jImlzo15tmRtZpu9q8AQ_ldpQ_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzTiqx__00240_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzTiqx__00240_003D, _0023_003Dzsro9YALfm2_kX4zEWoj0hc8_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzKAFKdck_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzKAFKdck_003D, _0023_003DzVIVbhuftSM_7RVbeO36D8xUiwnUShJbWw6tG_iIdvKP1)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzZ1Nd0wk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzZ1Nd0wk_003D, _0023_003DzLiVsjNcZKSVfU_UmpWuRvH23VZdFQd5XHWn_219I59c0)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz1RBgr_00244_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz1RBgr_00244_003D, _0023_003DzK_PGawVSQjI9cyj9jFBzsn8TKGwqGSGkrgJGrXw_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzx_f8XLg_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzx_f8XLg_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzaG3DPu0_003D = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzaNzIkdM_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzaNzIkdM_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					Type type = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D(), type);
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzgCCmJLk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzgCCmJLk_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzUcfwXkVt2OiFJi6klqPNUOc_003D(_0023_003Dzq80RbjQ_003D: false, _0023_003DzZzVr6_0024U_003D: false);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzemKTiT8_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzemKTiT8_003D, _0023_003DzWr74jZdGxGANJ9c60loKqI8_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzKyPCKaY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzKyPCKaY_003D, _0023_003DzUJbiAwdQqdFzYo_yiXOysOWjJmOqkyxkJTu0WCI_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzoyRBT1A_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzoyRBT1A_003D, _0023_003DzFjQpIIKr9jlKpKttFyzOIDLxoasfY20z4nwIQRQ_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzZRjZoiI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzZRjZoiI_003D, _0023_003DzAksaE4Xc4YfDxx7vswDFbNlc8VocFe5Gftg6yzE_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzD66eVW4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzD66eVW4_003D, _0023_003DzJDeqiGerlaon5b5FVHXgouU5WHR8XZufIg_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzLi0XoCY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzLi0XoCY_003D, _0023_003DzTW2KN655JQzBthpx_BK2gVc_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz5SBVqVA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz5SBVqVA_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzFPuHHafPEG92XM_0024gYatOtrw_0024UnVJ(_0023_003Dzq80RbjQ_003D: false, _0023_003DzZzVr6_0024U_003D: false);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzn2ncZyI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzn2ncZyI_003D, _0023_003DzHr22jfx_3Pif2gy3MtQLMhas2pfc)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzv_0024Sjmdk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzv_0024Sjmdk_003D, _0023_003DznPoZg_tqIVs8VcocjrJr7Gw_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzBjvPP_0024w_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzBjvPP_0024w_003D, _0023_003DzsiGT2MDUl9QBIO6XdFy14kydp_qrD3oM_g_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzvTxN1os_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzvTxN1os_003D, _0023_003DzMwgGnbGM047CRJvhKd4u2q36nj2H)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzT5j73_0024M_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzT5j73_0024M_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					Array array = (Array)_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(array.Length));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzbmCgwUo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzbmCgwUo_003D, _0023_003Dzy3LGo3AZjkba_TJUCp0SDWwEUhoJ)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzkJp9o4I_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzkJp9o4I_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					UIntPtr uIntPtr = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
					{
						1 => new UIntPtr((uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
						13 => new UIntPtr((ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()), 
						19 => new UIntPtr(Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
						8 => new UIntPtr((ulong)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
						_ => throw new InvalidOperationException(), 
					};
					_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D obj = new _0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D();
					obj._0023_003Dz2kixPGJySopLqOJCgTBxbSw_003D(uIntPtr);
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzmIdb15c_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzmIdb15c_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D _0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D2 = (_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2;
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D2._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D());
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzHAARMLg_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzHAARMLg_003D, _0023_003Dz4MQX7QQWeYDCfVDbLEauFMErjKAdmZwmktx0fUE_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzVeJ4EnE_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzVeJ4EnE_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2 = (_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2;
					MethodBase methodBase = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D());
					_0023_003Dqqr0fJcmNHD_002426q7CfYl3TIKslsTynyI2_0024uUSOUtw4jk_003D obj = new _0023_003Dqqr0fJcmNHD_002426q7CfYl3TIKslsTynyI2_0024uUSOUtw4jk_003D();
					obj._0023_003DzqC7E3Vn82TFeKA4OyRAe_dA_003D(methodBase);
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dze1SxUho_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dze1SxUho_003D, _0023_003Dz7lbSoR66JqDOKS0uMqIsQ6eIw_KKpK8EvUVwB00_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzHVPXXvQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzHVPXXvQ_003D, _0023_003DzShgdTHaf2FtEU_sdRX2zW64b3ixAWNwXlA_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzmLyIuNI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzmLyIuNI_003D, _0023_003DzZS_rhl4K7iNTi60ADiKudawjx7wWmjgjh3u4MJg_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzZsIH_0024YA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzZsIH_0024YA_003D, _0023_003DzonpecKJzZXL1M1VD4BIlJN4YkVWXAiNx8ebqVus_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzW4Qrpao_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzW4Qrpao_003D, _0023_003DzCtFDk2poPIRFXduyFUR1gIFaeBe4)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzAWMGxQs_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzAWMGxQs_003D, _0023_003DzON613Ok9sC7BTRlk_eXrxecfj1vF)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzewRUSA4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzewRUSA4_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					if (!_0023_003DzB_0024Rwap05HaolUNEYfZI197k_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
					{
						uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
					}
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzqAY1jyo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzqAY1jyo_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzGK5WKeBvR9cWZYGHWewhHmFceBV2(_0023_003Dzq80RbjQ_003D: true, _0023_003DzZzVr6_0024U_003D: false);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzXhlLPyI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzXhlLPyI_003D, _0023_003DzJHEzhSl4p0moe8vIdgHXhfYjnwQU)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzxA7xepw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzxA7xepw_003D, _0023_003DzsB0uw3YHhayEgwOo_4Bhl016q0YpPLZtjA_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzzq_0024ktm0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzzq_0024ktm0_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzulaHX73aw6pB0iqB9WTs0IBzl93L();
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzG_LDriQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzG_LDriQ_003D, delegate
				{
					throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525739));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzFikN25c_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzFikN25c_003D, _0023_003DzN7IPqgK52J8BpCKEjc7IOS17jqstLNOhLqJmv20_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz_0024Qw3zuA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz_0024Qw3zuA_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzvQQP5BELn8vLJ6Gf7XVrZxFAvcN15nzHnA_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzkEXSfPc_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzxA7xepw_003D, _0023_003DzFcXtJPINKhK7aA4O3WZrWno3X9CPq9KVWA_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzbGeCb4Q_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzbGeCb4Q_003D, _0023_003DzuyJq7QZQinGewHRepirRBVWqE7HnpLj3oYlJEJds7cb_)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzhcgD8IQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzhcgD8IQ_003D, _0023_003DzhA7cDijV2dhaqZcCOj2ifGU_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzBAOlweI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzBAOlweI_003D, _0023_003Dzor14kR5dv2TCbGZcYg_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzBa3Kf5Y_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzBa3Kf5Y_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(checked(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
					{
						1 => (int)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
						13 => (int)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
						19 => (int)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
						8 => (int)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((int)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((int)(uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzu4t07PM_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzu4t07PM_003D, _0023_003DzyRCW9ycIvsQeq8oGmw_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzYg2nCqE_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzYg2nCqE_003D, _0023_003DzwnSzJsLRNX47hBMdniaU7HjbgBVl)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzh9LSz4s_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzh9LSz4s_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzbkB7sMGOzoMZR1tZ5x8adrEVlhbHCkoa9w_003D_003D(_0023_003Dzq80RbjQ_003D: false);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzJsdpqPo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzJsdpqPo_003D, _0023_003Dz6WHb6TPjdZgSqRbNQRhSPzs4FVqo)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzG_Z_SWU_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzG_Z_SWU_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(checked(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
					{
						1 => (short)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
						13 => (short)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
						19 => (short)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
						8 => (short)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((short)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((short)(uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzr7zegGI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzr7zegGI_003D, _0023_003DzygZ4p6Nwr3vB8cg4OYix6zwk8kD2Fyh_GA_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzOzKTgQo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzOzKTgQo_003D, _0023_003DzVefJQ5ny_ZdbnTdluPSnCNyDIXm4sDsynSjLGp4_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzdUS5IM4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzdUS5IM4_003D, _0023_003Dz11ydhDvquMMfOCtxLw_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzPnY1qG0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzPnY1qG0_003D, _0023_003DzUfkGPJiBrG97H40RleXTJdI_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzpDG_0024bAk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzpDG_0024bAk_003D, _0023_003DzupRoQGJO4og5Auiiqa83x9ZmEYrgTBN5Ag_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DznppgqLs_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DznppgqLs_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzheXyabQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzheXyabQ_003D, _0023_003DzSa2BKUyFSF3EvpKQNg_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzLi3Klnc_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzLi3Klnc_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(4);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz_00246tDw_0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz_00246tDw_0_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzixve3yE_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzixve3yE_003D, _0023_003DzBujVW4p4qaNMzbKoQgaayLS14QUups0UvQ_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz8NlYRoQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz8NlYRoQ_003D, _0023_003DzNxlONioPLlYmTCbjA7hYUEIDoHI6HqobAw_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzAtYak7o_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzAtYak7o_003D, _0023_003DzwWQxGw7tMn54A_IbLDJpSEglaSmvIW9QVw_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzmZNu_pI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzmZNu_pI_003D, _0023_003DzJLyr9nAl8iUMAWpcdw_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzoVpU9JU_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzoVpU9JU_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D _0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D2 = (_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2;
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D2._0023_003DzjMeEJ3HfdiVVM9FdsA_003D_003D());
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzgaXPHWs_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzgaXPHWs_003D, _0023_003DzHAsqyf5KeWLVgL0QHQfnvNM_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzpwUxaJs_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzpwUxaJs_003D, _0023_003DzUkwZH8h3cbbP4fdOwmUyDtBii9cG)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzvup4kCA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzvup4kCA_003D, _0023_003DzxzEEcVAQweyEbNZJ_g6wa8s_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzC0zaoyA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzC0zaoyA_003D, _0023_003Dz8Ho0xTU083HsJyiwtb837CygAQdNosDbbTY2xrs_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzik4eDVg_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzik4eDVg_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzp758Cuo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzp758Cuo_003D, _0023_003Dz6AawaYZITVt4PvnlttLd9D6OkHZONJIlX177ZCI_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzGN5mCJ0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzGN5mCJ0_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzycQEg40_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzycQEg40_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					if (_0023_003DzwfAT8W8IYpR6ztTl1Vsa7rnoeEQiGi2vHCk_fc8_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
					{
						uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
					}
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzmelcEjk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzmelcEjk_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(short));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzRdhcDdg_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzRdhcDdg_003D, _0023_003DzK645WSI1cc6YYkScS9gqqmU_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzw617K6k_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzw617K6k_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzbnzi9JArhzTjZqiOIA_003D_003D(_0023_003Dzq80RbjQ_003D: true);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzE75m7_0024c_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzE75m7_0024c_003D, _0023_003DzTKNlwUGtp0s_fNRmdqSCIdM_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzeTjUjYE_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzeTjUjYE_003D, _0023_003DzEORZFgJLZzrNpMBigbc6ozDwwwIx)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz1HLmZ4c_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz1HLmZ4c_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					string text = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DznMMoGwkuIQcygw5U_0024AEZNRBpmYc2MOYYByXiysPYi1HR(num);
					_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqoLZu7ARGqk3sO900JropiQ_003D obj = new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqoLZu7ARGqk3sO900JropiQ_003D();
					obj._0023_003DzJ_aFWmcjx_0024KCUNQBacmKUQo_003D(text);
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzCvR3430_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzCvR3430_003D, _0023_003DzOXx0tBU_9sOCFRhlX4ifr6TQtEI6)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzS4vjrVk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzS4vjrVk_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzHM_5K2mtFT6DEcu86Qk9vLSKEKOX(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzjF3U8_0024w_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzjF3U8_0024w_003D, _0023_003DzMThMAl7jgaeIJhj8ldjBniiR11c7)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzrhEG9Ic_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzrhEG9Ic_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D _0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D2 = (_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2;
					_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D obj = new _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D();
					obj._0023_003DzzYzgkSraKLDKGhNE6_isGLbZYUM4(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzxhN3bEo_003D[_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D2._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D()]);
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzDOe3VCY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzDOe3VCY_003D, _0023_003Dz4l5pY53CPl5Sm5NGo9pCTiKjqVsa)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzhvB7zF0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzhvB7zF0_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					double num = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
					{
						1 => (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
						13 => (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
						19 => Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
						_ => throw new InvalidOperationException(), 
					};
					_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
					obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(num);
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzmMmUef0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzmMmUef0_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzsfG3IFcTKHi4W67Nrg_003D_003D(typeof(float));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzxhN3bEo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzxhN3bEo_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz349QwgY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz349QwgY_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzfyTcB9E_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzfyTcB9E_003D, _0023_003DzSCzrsZtO7NuRRUyPHaRnDCVtaB1K)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz5ngl1lY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz5ngl1lY_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(byte));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzaG3DPu0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzaG3DPu0_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					checked
					{
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
						{
							1 => unchecked((uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
							13 => (long)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
							19 => (long)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
							8 => (long)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
							0 => (IntPtr.Size != 4) ? ((long)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : unchecked((uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
							_ => throw new InvalidOperationException(), 
						}));
					}
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzUawOijg_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzUawOijg_003D, _0023_003Dz2eSx015vPRGF2MToboA8ZfM_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz2CpLTfo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz2CpLTfo_003D, _0023_003DzSbHnjQfm885pOUFnXYSgg5wPldkG)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzUp6r3Y0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzUp6r3Y0_003D, _0023_003DzwtxLx9QmzygaeGbIKHDONbje65Te)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzO94BUrs_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzO94BUrs_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzMw7_0024EO1zJL4MyDs5_00243DxjS_NGViU1FlGfkRm6d8_003D(null, num);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzQ94e_m4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzQ94e_m4_003D, _0023_003DzSQrapK17x7JWrGhbpH57ap4Z99NPQ1Pf9w_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzWtMw7JM_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzWtMw7JM_003D, _0023_003DzfOjavdDn84wcXkZxZdFcdXs_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzvOp8rOA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzvOp8rOA_003D, _0023_003DzFszEoaomGCsh0sl4bYgVb2dIBlB5o1x0soZwYaaEI_yZ)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzBLw5YM0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzBLw5YM0_003D, _0023_003DzJ8JCwIfLzQGXUktmLzI4Ya7pmkAt)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzxH_UWC4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzxH_UWC4_003D, _0023_003DzlobJCUIal0Cr2rU4wFKN9vshmzQjbEZpKnqKP8UBCT5K)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz61IPlm0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz61IPlm0_003D, _0023_003Dz3VqG6Fck84wFq4FtNmdO8efQAxowQLDzBA_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzR6Gfg9E_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzR6Gfg9E_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2 = _0023_003Dzmjx3IYVmxm4H_sfJfSlPWXT2veAi(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2);
					_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D2 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLi0XoCY_003D._0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D();
					long num = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzeE3jiLrpSvA9TWmZ_0024_0024gF_00_003D();
					byte[] array = new _0023_003DqHG1TmG_0024dSF7XquINMc2Zz70dWtTQ2CxWuU2XR_0024MiL8c_003D(_0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2._0023_003Dz_0024zQo_0024B75Ge1AkfsQnDYeN3Sw3u9O03TL5qVPqBfr02F4UIiat3oe3Nr1wA_00246eyvumJMd5jDMPJu2XR21SQ_003D_003D(), _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2._0023_003DzrLViyGP3d5fPD8YJiovkCFoTRTt56uOzWY0hG_0024UlewBKZjtAezweZoQGAhz6_08VuSfhDKc_dvr9Btl5qBCDQzs_003D())._0023_003Dz7GzVKHigmAjHE5FVN5SuT1iQo6K1(_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D2, _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2);
					_0023_003DzUH03yec_003D _0023_003DzUH03yec_003D2 = new _0023_003DzUH03yec_003D
					{
						_0023_003Dzq80RbjQ_003D = _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2,
						_0023_003DzcbLoSrg_003D = num
					};
					_0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D2._0023_003Dz_vEj4OwnFcwGRmsKmXLdsTKLz3BfOqLGo03HpMs_003D(_0023_003Dq6ddeMh0jPjn0m3HHEFyd_UzyP04hcfbzuH_iOk0_4Fk_003D._0023_003DzPfA3Uw7vkcjX8tmk6mF4leo_003D(array.Length) - array.Length);
					_0023_003DzUH03yec_003D2._0023_003DzZzVr6_0024U_003D = new _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D(_0023_003DzUH03yec_003D2._0023_003Dz7hRN5Rg_003D = new _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D(array, 0, array.Length, _0023_003DzcbLoSrg_003D: false));
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzbKacmMjJlAozzsmL94D6Uq6kYdq6().Push(_0023_003DzUH03yec_003D2);
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzmSUiy7sPdkHWa_kpgPiolyyCqWUwmeU_lBOK610_003D(_0023_003DzUH03yec_003D2);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzF6BhvwY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzF6BhvwY_003D, _0023_003Dz9XqjpSRTnoXBgbgasyWndi4_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzen5bzmA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzen5bzmA_003D, _0023_003DzI_dvmQDuKWlxVpaSx0Jv_lmojK3IXf9KuCbLskNBHcLZ)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzUrhsklQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzUrhsklQ_003D, _0023_003DzVpTGO2d_LeXvGtbBI9pnjvhuASk9hYo9ciTpqfM_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzBVWf310_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzBVWf310_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzClvFpnBhopC5aAjD7K31UNUSndWj_0024t_00248Ig_003D_003D(_0023_003Dzq80RbjQ_003D: false);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzj0si6zk_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzj0si6zk_003D, _0023_003DznD3OC_vD3i2ZHIykaAoMUcXhZJLxWt3muw_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz62FWXc8_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz62FWXc8_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D5)
				{
					object obj = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					long num = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5();
					Array array = (Array)_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					Type elementType = array.GetType().GetElementType();
					if (elementType == typeof(short))
					{
						_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(short));
						((short[])array)[num] = (short)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					}
					else if (elementType == typeof(ushort))
					{
						_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(ushort));
						((ushort[])array)[num] = (ushort)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					}
					else if (elementType == typeof(char))
					{
						_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(char));
						((char[])array)[num] = (char)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
					}
					else if (elementType.IsEnum)
					{
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(elementType, obj, num, array);
					}
					else
					{
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(typeof(short), obj, num, array);
					}
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzsaghmf0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzsaghmf0_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(float));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz1LTqqwY_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz1LTqqwY_003D, _0023_003Dzrzqsz5imbzLW0R0WptNJZhnZ_URMMkWWp1X35nQFblXU)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzR7bPUlA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzR7bPUlA_003D, _0023_003DzrK8d_bzEtJpdiC39RcLGoXrXLlglZ9ML4w_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzzNw7Y4Q_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzzNw7Y4Q_003D, _0023_003DzgR00JgM9ObtiyPMUrTu_WStYaLm5)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzq80RbjQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzq80RbjQ_003D, _0023_003DzipXRa2olforJzyPl2PUng_Q_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzJYjSKV4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzJYjSKV4_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzEMxuGbg_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzEMxuGbg_003D, _0023_003Dz0_fKfHybKgpGaRoTIF1Kx5Q_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzxPEqRbs_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzxPEqRbs_003D, _0023_003DzI6AntmTO8EJldrIPDt9YFMpdkWXFp_0m3RZM0wk_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzWQ7kZWw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzWQ7kZWw_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzbnzi9JArhzTjZqiOIA_003D_003D(_0023_003Dzq80RbjQ_003D: false);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dze_0024TX6wc_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dze_0024TX6wc_003D, _0023_003Dzkn2jUPILJecZ16C5aVCvagM_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzAXvW_0024Kw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzAXvW_0024Kw_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D());
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzzkz90iI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzzkz90iI_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzcHX5J0_BxaBvebV44eNBFeg_003D(((_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D());
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzHM9TetA_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzHM9TetA_003D, _0023_003DziKa9D3MjFUMmQdYLFDISo5k_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzxP03bpw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzxP03bpw_003D, _0023_003Dz8QMMwFl8Z0aw_nWEbHPYN2neiuQU)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzzxDPBsQ_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzzxDPBsQ_003D, delegate
				{
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzWqEE4_g_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzWqEE4_g_003D, _0023_003DztUTm0kvgEK1O05Sxojojgm0_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzlq1zGZM_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzlq1zGZM_003D, _0023_003DzCiBvWws6fxjLDJPoAM_H_lzwSqO7)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz1j2rMNI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz1j2rMNI_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					FieldInfo fieldInfo = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num);
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(fieldInfo.GetValue(null), fieldInfo.FieldType));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzNTGnOiI_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzNTGnOiI_003D, _0023_003DzR1jIbEgwLe1p06Nb7L0Y3SU_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzPRVED4s_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzPRVED4s_003D, _0023_003Dz5XqbKCNC_c0jdbkj0Q_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzjV5qBvw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzjV5qBvw_003D, _0023_003DzPB_64wVNmW777KYNNT1k2AzHbIaN)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dzz7VpMuo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzz7VpMuo_003D, _0023_003DzF_nQzSWOCYI0ZEip172b8UE_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzFKB94gU_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzFKB94gU_003D, _0023_003DzmoA0kfgeVVPPaPHYHygdFg2St3lt)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzPjbPPps_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzPjbPPps_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					Type type = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
					if (_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzzduiut2EAcwdZLUjAciHTs2MmRA0YfHi_0024Q_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, type))
					{
						_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3);
						return;
					}
					throw new InvalidCastException();
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzqxgM70s_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzqxgM70s_003D, delegate
				{
					throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525109));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzwLLvGQs_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzwLLvGQs_003D, _0023_003DzMtBm4377GUedudm3A0K9LQXPiNLueGke1Ek931c_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz0FF8FKw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz0FF8FKw_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(3);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzVUOOffo_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzVUOOffo_003D, _0023_003DzrL2eDExcmIcgfZaXpg_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzC4Sydfw_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzC4Sydfw_003D, _0023_003DzZhjKbXJTINjQYLMcYQXd3Lr_N5L6)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzuXsnuWU_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzuXsnuWU_003D, _0023_003DzWWqQafCp5nllxDJHW8EOF_COa6ixJO2mQIFPL9o_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzNZPSV9I_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzNZPSV9I_003D, _0023_003Dzf3Qc9xfSMphEkv6cVnzZQ7U0kvKsa19rlA_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzZsyxWik_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzZsyxWik_003D, _0023_003DztWRj3UNj5TytsotMFulSjEw_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz9Svqvws_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9Svqvws_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(int));
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003Dz8OpgbN4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz8OpgbN4_003D, _0023_003DzaSN230TpFkaylGJgydA8w6KQXtsq4KEomeRofArUrnKB)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzfMBGV_00240_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzfMBGV_00240_003D, _0023_003Dz6xubmFjtdWxFzsLYQNzgl_ltf7VOFt7ZDg_003D_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzPAYs7f4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzPAYs7f4_003D, _0023_003DzXJ69IQ8Q1qArH0EnefE328Q_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzmsT1xI8_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzmsT1xI8_003D, _0023_003Dz4BGE4ppsVM2b1HCzmAQKkIKG0kUlEpAmTpRvI5s_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzX_VRnyU_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzX_VRnyU_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzWTgsPi0_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzWTgsPi0_003D, _0023_003DzOTfcEAzNEmX8tQo6BwpN5Nc_003D)
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzdLjJal4_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzdLjJal4_003D, delegate
				{
				})
			},
			{
				_0023_003Dzq80RbjQ_003D._0023_003DzcbLoSrg_003D._0023_003DzPpv1DDRzaPIoFPqDPnx_EPysQeulFKhHFi4wJ4Nbk2qm(),
				new _0023_003DzKyPCKaY_003D(_0023_003Dzq80RbjQ_003D._0023_003DzcbLoSrg_003D, delegate(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DziOj6_RXYwX3_0024SFIeNVIQ1jxYOaZqJwP14A_003D_003D(_0023_003Dzq80RbjQ_003D: false);
				})
			}
		};
	}

	private static void _0023_003Dzsro9YALfm2_kX4zEWoj0hc8_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (_0023_003Dzq80RbjQ_003D._0023_003Dzzduiut2EAcwdZLUjAciHTs2MmRA0YfHi_0024Q_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2, type))
		{
			_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
		}
		else
		{
			_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D());
		}
	}

	private static void _0023_003Dz2eSx015vPRGF2MToboA8ZfM_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(3);
	}

	private void _0023_003DzLpNYyqiuDYKdUW0EcPmsEjI_003D()
	{
		_0023_003Dz4A3Alm0_003D = null;
		this.m__0023_003DzqMLoHoQ_003D = null;
		_0023_003Dz349QwgY_003D.Clear();
	}

	private static void _0023_003Dz63EA6jNhIGQwNi33cDMmwKWQZ7DqCblclxuolmT_0024egvP(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzGK5WKeBvR9cWZYGHWewhHmFceBV2(_0023_003Dzq80RbjQ_003D: false, _0023_003DzZzVr6_0024U_003D: false);
	}

	private static void _0023_003DzKBNvdUv3unYDfjrfFtRfV9NlORN7(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		long num2 = _0023_003Dzq80RbjQ_003D._0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5();
		Array array = (Array)_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		_0023_003Dq83txtBmFlxymCNA_sU7I_0024Y_00242vzeblXZXdVD0epGbyVQ_003D obj = new _0023_003Dq83txtBmFlxymCNA_sU7I_0024Y_00242vzeblXZXdVD0epGbyVQ_003D();
		obj._0023_003DzFUzVAuXZSCkvjiCEu2louC3Q9lM4hujkGwCO3Lo_003D(array);
		obj._0023_003DzSEy5G4lo_0024XBVGSpmZFEUg0fWCELZ(type);
		obj._0023_003DzyzBBTXT_jN_bK0SwCis9LZr2HaA5nclEGg_003D_003D(num2);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private void _0023_003Dz6v3cdJTvIl03MdLz0yM1irdLo3AWwBfzYPHLiadS3Iy7()
	{
		_0023_003DzV9O_RLTL01ApHujuxKX_0024HiFnV99c(_0023_003Dzq80RbjQ_003D: false);
	}

	private static void _0023_003DztUTm0kvgEK1O05Sxojojgm0_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003Dz6uwpXMENmglaFBA5cfbtfP3Gde20_280x37pdP0_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	private static void _0023_003Dz01Fy_00248_0024bVIt5yFE_0024U4kc2rYfxlhc(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
	}

	private static void _0023_003Dzf3Qc9xfSMphEkv6cVnzZQ7U0kvKsa19rlA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzsfG3IFcTKHi4W67Nrg_003D_003D(typeof(double));
	}

	private static void _0023_003DziKa9D3MjFUMmQdYLFDISo5k_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(uint));
	}

	private static void _0023_003Dzor14kR5dv2TCbGZcYg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003DzbLKMaSlao_0024AFofVihsr7cM7_DlQeb2LkIgPm0rY_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2) ? 1 : 0));
	}

	private static void _0023_003DzHZKPK_0024grCVJYexT_xRBO4useBlwT2Dw_0024ibSmrqk_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (!_0023_003DzB_0024Rwap05HaolUNEYfZI197k_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private static void _0023_003DzxzEEcVAQweyEbNZJ_g6wa8s_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzClvFpnBhopC5aAjD7K31UNUSndWj_0024t_00248Ig_003D_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private static void _0023_003DzUFBIcgn1omrKlviWjvCMEjgNf_0024y3_xTFo7QNukUk48YG(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(0);
	}

	private static void _0023_003DznPoZg_tqIVs8VcocjrJr7Gw_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
	}

	private long _0023_003DzJcb2qLOxhGvSUPXFlrHRD15WP60Zt0KmgiA_S5w_003D(string _0023_003Dzq80RbjQ_003D)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003Dq6BQK4POmdQSdOG1gXvn7D6Vb93mFNAt9_0024p9qLK7gUAk_003D._0023_003DzprwMdmBa0BaHEW4z1w_003D_003D(_0023_003Dzq80RbjQ_003D));
		long result = new _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D(new _0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D(memoryStream, _0023_003DzLlwjYw6G90e1tagGD7aboLs_003D()))._0023_003Dzp_l1PqLcSGPUHQ75iBvbWgkFJ8MX42NzxbPuGSryMcYN();
		memoryStream.Dispose();
		return result;
	}

	private static void _0023_003Dz6AawaYZITVt4PvnlttLd9D6OkHZONJIlX177ZCI_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DztP7PBX2bGr9qR_8NV2HJNQoKwjzAZkYaog_003D_003D(1);
	}

	private void _0023_003DzGK5WKeBvR9cWZYGHWewhHmFceBV2(bool _0023_003Dzq80RbjQ_003D, bool _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzoRqx5a7tJflZpkonX6uD3DHtIi6VdmHIbNC_jway4lKc(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D));
	}

	private void _0023_003DziOj6_RXYwX3_0024SFIeNVIQ1jxYOaZqJwP14A_003D_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		bool flag = IntPtr.Size == 4;
		checked
		{
			IntPtr intPtr;
			switch (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
			{
			case 1:
			{
				int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				intPtr = ((!flag) ? ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr(unchecked((uint)num)) : new IntPtr((uint)num)) : ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr(num) : new IntPtr((int)(uint)num)));
				break;
			}
			case 13:
			{
				long num2 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				intPtr = ((!flag) ? ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr(num2) : new IntPtr((long)(ulong)num2)) : ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr(unchecked((int)num2)) : new IntPtr((int)(ulong)num2)));
				break;
			}
			case 8:
			{
				double num3 = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
				intPtr = ((!flag) ? ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr(unchecked((long)num3)) : new IntPtr((long)(ulong)num3)) : ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr(unchecked((int)(ulong)num3)) : new IntPtr((int)(ulong)num3)));
				break;
			}
			case 19:
				intPtr = ((!_0023_003Dzq80RbjQ_003D) ? new IntPtr(Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())) : new IntPtr(Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D obj = new _0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D();
			obj._0023_003Dz_0024eT0u_00244AlLxv9vzC5bag2xx1uYIycKqC7_Qs0Bo_003D(intPtr);
			_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
		}
	}

	private static void _0023_003DzSG_aQNwbSdZVv7O93HkGZcjg_0024967(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzcHX5J0_BxaBvebV44eNBFeg_003D(((_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D());
	}

	private static bool _0023_003DzzCpJPhh58xxAI1_0024905lbqcuJYmci()
	{
		return false;
	}

	private static object _0023_003Dzn6drv421fV0O5urB0a70eJS0cc7fu428Yw_003D_003D(MethodBase _0023_003Dzq80RbjQ_003D, object _0023_003DzZzVr6_0024U_003D, object[] _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		if (!_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D._0023_003DzcbLoSrg_003D._0023_003Dzq80RbjQ_003D)
		{
			return _0023_003DzgCnHr6_0024NKsiKffk0iw_003D_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
		}
		return _0023_003DzwnjkX4jybFztBLWSLe4Xk2OZ0uxg9u1rb39dBATHMPXn(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
	}

	private static void _0023_003Dz9Wf6VkzGlqXZNQ9bpJ_ZLZA_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(type);
	}

	private static void _0023_003Dz30_0024wZtyy08KKTU2g38gubqlgopoH(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzaG3DPu0_003D = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
	}

	private static void _0023_003Dz8_vsmijeoGtimvm7Dgab31w_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DztP7PBX2bGr9qR_8NV2HJNQoKwjzAZkYaog_003D_003D(2);
	}

	private static void _0023_003Dz3VqG6Fck84wFq4FtNmdO8efQAxowQLDzBA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzsfG3IFcTKHi4W67Nrg_003D_003D(_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D);
	}

	private void _0023_003Dzfq_0024PZ9sR_1WJjmN7UTu1nCM61IyKGWqi1C4Qpos_003D(ref _0023_003Dz7hRN5Rg_003D _0023_003Dzq80RbjQ_003D, MethodBase _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D)
	{
		bool flag = false;
		if (_0023_003DzZzVr6_0024U_003D.DeclaringType == typeof(Interlocked) && _0023_003DzZzVr6_0024U_003D.IsStatic)
		{
			string name = _0023_003DzZzVr6_0024U_003D.Name;
			if (name == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524719) || name == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524709) || name == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524687) || name == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524703) || name == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524782) || name == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524798))
			{
				flag = true;
			}
		}
		if (flag)
		{
			try
			{
			}
			finally
			{
				Monitor.Enter(_0023_003DzX_VRnyU_003D);
				_0023_003Dzq80RbjQ_003D._0023_003Dzq80RbjQ_003D = true;
			}
		}
	}

	private static void _0023_003DzPVdSJYlfq3_0024uX_0024ew6SDqeRhWDfKAYy6_0024Mg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (_0023_003Dzq80RbjQ_003D._0023_003Dzzduiut2EAcwdZLUjAciHTs2MmRA0YfHi_0024Q_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2, type))
		{
			_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
			return;
		}
		throw new InvalidCastException();
	}

	private string _0023_003DzJgQM5CjFJ0TIbvJ5cbmQCTKZ_dmF(_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D _0023_003Dzq80RbjQ_003D)
	{
		Type type = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003Dzq80RbjQ_003D._0023_003DzeFmYRYvMy4A0IhX6fIHDEUwm_00242cyzi_3XQ_003D_003D(), _0023_003DzZzVr6_0024U_003D: false);
		_0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D[] array = _0023_003Dzq80RbjQ_003D._0023_003Dzk6NqcXocXPYbt5Kh5TxUvGSiFQOn();
		string[] array2 = new string[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(array[i]._0023_003DzMIf6Qcoa626dIfKdj06GAYVkuQnij6bPFMzPRpYqY31Y(), _0023_003DzZzVr6_0024U_003D: false)?.FullName;
		}
		string text = string.Join(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526241), array2);
		return type.FullName + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526571) + _0023_003Dzq80RbjQ_003D._0023_003Dzijy_0024YuRSbTXlhC2ah706rnKCny8J() + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526262) + text + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526222);
	}

	private static void _0023_003DzDQIJnmrKtmnEr9TM_0024uwyvXpAs3lyXax8DhFOwcs_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(byte));
	}

	private static void _0023_003DzON613Ok9sC7BTRlk_eXrxecfj1vF(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(-1);
	}

	private static bool _0023_003DzwfAT8W8IYpR6ztTl1Vsa7rnoeEQiGi2vHCk_fc8_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		bool flag = false;
		switch (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
		{
		case 1:
			return (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() > (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		case 13:
			return (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() > (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		case 8:
		{
			double num3 = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			double num4 = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			return num3 > num4 || double.IsNaN(num3) || double.IsNaN(num4);
		}
		case 0:
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 7 && _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() == null)
			{
				return ((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr() != IntPtr.Zero;
			}
			return ((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr() != ((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr();
		case 20:
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 7 && _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() == null)
			{
				return ((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D() != UIntPtr.Zero;
			}
			return ((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D() != ((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D();
		case 7:
			return ((_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzvPsFwllF9YUejQF68VzjbUs4hENNmXLLhEVR500jpyde() != ((_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzvPsFwllF9YUejQF68VzjbUs4hENNmXLLhEVR500jpyde();
		case 25:
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 7 && _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() == null)
			{
				return true;
			}
			return ((_0023_003DqIx7Es0991cC2X_00245IB4D_00241cF3l7JfNAZfP4L5w3s6Cp4_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz0JnUB3O4xCsib39IP97QRlnfMWXo() != ((_0023_003DqIx7Es0991cC2X_00245IB4D_00241cF3l7JfNAZfP4L5w3s6Cp4_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz0JnUB3O4xCsib39IP97QRlnfMWXo();
		case 19:
		{
			long num = Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D());
			long num2 = ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 1) ? Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()) : ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D());
			return num > num2;
		}
		default:
			return _0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() != _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
	}

	private static void _0023_003DzbucIMUD5hHhDiaxGDY_0024DhP9Y__nW8UYQIpkFQtLdd1s6(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzulaHX73aw6pB0iqB9WTs0IBzl93L();
	}

	private static void _0023_003DzjtkaQpl6j8L9PjIF_0024sIDMUNWsAiXxH8YBrE0Qqw_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(float));
	}

	private FieldInfo _0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(int _0023_003Dzq80RbjQ_003D)
	{
		lock (_0023_003DzxHwNxiw_003D)
		{
			bool flag = true;
			FieldInfo fieldInfo;
			if (flag && _0023_003DzxHwNxiw_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out var value))
			{
				fieldInfo = (FieldInfo)value;
			}
			else
			{
				_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = _0023_003Dz2VVL65ZUV4mNemmPJRTlKGJnuqYG(_0023_003Dzq80RbjQ_003D);
				fieldInfo = _0023_003Dz5g2tpOpzVoPYMWc_lWdB63_kgyn4dbrkPr_JsZyeceaT(_0023_003Dzq80RbjQ_003D, _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2, ref flag);
				if (flag)
				{
					_0023_003DzxHwNxiw_003D.Add(_0023_003Dzq80RbjQ_003D, fieldInfo);
				}
			}
			_0023_003DzkO3PJHhv6CGcBbCGk3WpSnPpLNzMif3JCQ_003D_003D(fieldInfo);
			return fieldInfo;
		}
	}

	private static void _0023_003DzR1jIbEgwLe1p06Nb7L0Y3SU_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(1);
	}

	private static bool _0023_003DzbLKMaSlao_0024AFofVihsr7cM7_DlQeb2LkIgPm0rY_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		bool result = false;
		switch (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
		{
		case 1:
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzbLKMaSlao_0024AFofVihsr7cM7_DlQeb2LkIgPm0rY_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())));
			}
			result = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() > ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
			break;
		case 13:
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzbLKMaSlao_0024AFofVihsr7cM7_DlQeb2LkIgPm0rY_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())));
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				return _0023_003DzbLKMaSlao_0024AFofVihsr7cM7_DlQeb2LkIgPm0rY_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()));
			}
			result = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() > ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			break;
		case 19:
			return _0023_003DzbLKMaSlao_0024AFofVihsr7cM7_DlQeb2LkIgPm0rY_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), _0023_003DzZzVr6_0024U_003D);
		case 8:
		{
			double num = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			double num2 = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			result = !double.IsNaN(num) && !double.IsNaN(num2) && num > num2;
			break;
		}
		}
		return result;
	}

	private static void _0023_003Dz0_fKfHybKgpGaRoTIF1Kx5Q_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzZzVr6_0024U_003D);
	}

	private static void _0023_003Dz8QMMwFl8Z0aw_nWEbHPYN2neiuQU(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(_0023_003Dzvup4kCA_003D);
	}

	private bool _0023_003DznUKOR0RU11ixCPFSXkMOp20_003D(MethodInfo _0023_003Dzq80RbjQ_003D, _0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D _0023_003DzZzVr6_0024U_003D, Type[] _0023_003Dz7hRN5Rg_003D, out int _0023_003DzcbLoSrg_003D)
	{
		_0023_003DzcbLoSrg_003D = 0;
		if (!_0023_003Dzq80RbjQ_003D.IsGenericMethodDefinition)
		{
			return false;
		}
		ParameterInfo[] parameters = _0023_003Dzq80RbjQ_003D.GetParameters();
		if (parameters.Length != _0023_003DzZzVr6_0024U_003D._0023_003DzXma8mp_0024a__0024RK2w1Q8lnydG_3_0024wKH().Length)
		{
			return false;
		}
		if (_0023_003Dzq80RbjQ_003D.GetGenericArguments().Length != _0023_003DzZzVr6_0024U_003D._0023_003Dz3lC_0024Wjfyk4ghB256hH6dsHMuzwS45iW3n7EJINQ_003D().Length)
		{
			return false;
		}
		for (int i = -1; i < parameters.Length; i++)
		{
			Type type = ((i == -1) ? _0023_003Dzq80RbjQ_003D.ReturnType : parameters[i].ParameterType);
			if (_0023_003Dz7hRN5Rg_003D != null && type.IsGenericParameter && type.DeclaringMethod != null)
			{
				type = _0023_003Dz7hRN5Rg_003D[type.GenericParameterPosition] ?? type;
			}
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = ((i == -1) ? _0023_003DzZzVr6_0024U_003D._0023_003Dz7Hkm9cwPT3L86VmdLdFR58VmHiUF() : _0023_003DzZzVr6_0024U_003D._0023_003DzXma8mp_0024a__0024RK2w1Q8lnydG_3_0024wKH()[i]);
			if (_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 != null)
			{
				if (!_0023_003DzQ39MwbzcCZ2kCX7d7E83rYI_003D(type, _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2, out var num))
				{
					return false;
				}
				if (i >= 0)
				{
					_0023_003DzcbLoSrg_003D += num;
				}
			}
		}
		return true;
	}

	public object _0023_003DzdBynfCK8oNJXn_rxK_rgOspqA_0024qzHYqdqekCWfw_003D(Stream _0023_003Dzq80RbjQ_003D, string _0023_003DzZzVr6_0024U_003D, object[] _0023_003Dz7hRN5Rg_003D, Type[] _0023_003DzcbLoSrg_003D, Type[] _0023_003DzqMLoHoQ_003D, object[] _0023_003DzuwE9t4w_003D)
	{
		this.m__0023_003DzoyRBT1A_003D = _0023_003Dzq80RbjQ_003D;
		_0023_003Dz5OMzZfMew032gXEU_00246l23UxgtnrcwVndYPIzBd7EUgHG(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
		return _0023_003DzIRjHpBT48wikHA3Dmt5vhwwkbEarj_0024ke3BpAkWqTQVzU(_0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D);
	}

	private static void _0023_003DzPOsbsKQW9CM2HhnXmTjyGvHxNtS24yG1vMUhG7k_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003DzwfAT8W8IYpR6ztTl1Vsa7rnoeEQiGi2vHCk_fc8_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2) ? 1 : 0));
	}

	private static void _0023_003DzW3FcDg6ILjuw4DvbJcX3H4dL_0024W2qG295BA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D _0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D2 = (_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D)_0023_003DzZzVr6_0024U_003D;
		_0023_003Dzq80RbjQ_003D._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D2._0023_003DzjMeEJ3HfdiVVM9FdsA_003D_003D());
	}

	private static void _0023_003Dz8oUq136qcdKSyWMwemrkg2M_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzJSi0qgGb_0024sI99c5pAmnGAJs_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	private static void _0023_003Dz6lvBD24B1e__00248Z_fy9myNIH7HmGi8vqnp_0024hEW24_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzZzVr6_0024U_003D);
	}

	private static void _0023_003DzonpecKJzZXL1M1VD4BIlJN4YkVWXAiNx8ebqVus_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzJSi0qgGb_0024sI99c5pAmnGAJs_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private static void _0023_003DzZhjKbXJTINjQYLMcYQXd3Lr_N5L6(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
	}

	private static void _0023_003DzFjQpIIKr9jlKpKttFyzOIDLxoasfY20z4nwIQRQ_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
	}

	private static void _0023_003DzN7IPqgK52J8BpCKEjc7IOS17jqstLNOhLqJmv20_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(long));
	}

	private static void _0023_003DzI_dvmQDuKWlxVpaSx0Jv_lmojK3IXf9KuCbLskNBHcLZ(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(ushort));
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzQdjeUYEe9Gd_kyvTmQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				if (!_0023_003DzcbLoSrg_003D)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					int num3 = ((!_0023_003Dz7hRN5Rg_003D) ? (num - num2) : checked(num - num2));
					return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num3);
				}
				uint num4 = (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				uint num5 = (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				uint num6 = ((!_0023_003Dz7hRN5Rg_003D) ? (num4 - num5) : checked(num4 - num5));
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D((int)num6);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzUUD5_0024Mg0aGk0N6sI6w_003D_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzUUD5_0024Mg0aGk0N6sI6w_003D_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
				}
				return _0023_003DzQdjeUYEe9Gd_kyvTmQ_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzUUD5_0024Mg0aGk0N6sI6w_003D_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				return _0023_003DzUUD5_0024Mg0aGk0N6sI6w_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzUUD5_0024Mg0aGk0N6sI6w_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
				}
				return _0023_003DzUUD5_0024Mg0aGk0N6sI6w_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8 && _0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8)
		{
			_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
			obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D() - ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D());
			return obj;
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzQdjeUYEe9Gd_kyvTmQ_003D_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			return _0023_003DzQdjeUYEe9Gd_kyvTmQ_003D_003D(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzHAsqyf5KeWLVgL0QHQfnvNM_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(byte));
	}

	private static void _0023_003Dz4MQX7QQWeYDCfVDbLEauFMErjKAdmZwmktx0fUE_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 = (_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D)_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (type.IsValueType)
		{
			object obj = _0023_003Dzq80RbjQ_003D._0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2)._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
			if (_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzYWGcjirBLOR1G3YpoMmbNyJEx1WWfXOuZmf7utk_003D(type))
			{
				_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D obj2 = new _0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D();
				obj2._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(type);
				_0023_003Dzq80RbjQ_003D._0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2, obj2);
				return;
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(obj, _0023_003Dzc_wLCDILL_0024YoX_0024viah_o7RRHVcZKUniJuB66bLg_003D(fieldInfo.FieldType));
			}
		}
		else
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2, new _0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D());
		}
	}

	private static string _0023_003DzjuBfKGhes_00246QlFOfOT_0024DNDV7kkerd8UbcOr50y0_003D(MethodBase _0023_003Dzq80RbjQ_003D)
	{
		Type declaringType = _0023_003Dzq80RbjQ_003D.DeclaringType;
		ParameterInfo[] parameters = _0023_003Dzq80RbjQ_003D.GetParameters();
		string[] array = new string[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			array[i] = string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524637), parameterInfo.ParameterType, parameterInfo.Name);
		}
		string text = string.Join(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526241), array);
		return declaringType.FullName + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526571) + _0023_003Dzq80RbjQ_003D.Name + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526262) + text + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526222);
	}

	private static void _0023_003DzSbHnjQfm885pOUFnXYSgg5wPldkG(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(6);
	}

	private static void _0023_003DzLiVsjNcZKSVfU_UmpWuRvH23VZdFQd5XHWn_219I59c0(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(checked(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (byte)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (byte)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => (byte)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			8 => (byte)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((byte)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((byte)(uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003Dz68WrFs5NZDQm8a5KGsxC3Q0NERj0LKDfV55r5p61_0024Gsc(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzsfG3IFcTKHi4W67Nrg_003D_003D(typeof(float));
	}

	private FieldInfo _0023_003Dz5g2tpOpzVoPYMWc_lWdB63_kgyn4dbrkPr_JsZyeceaT(int _0023_003Dzq80RbjQ_003D, _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DzZzVr6_0024U_003D, ref bool _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003DzZzVr6_0024U_003D._0023_003Dzip8yWLvtIndlQqoIuur_x1i0otdXn27UJQ_003D_003D() == 0)
		{
			_0023_003Dz7hRN5Rg_003D = false;
			return this.m__0023_003DzkJp9o4I_003D.ResolveField(_0023_003DzZzVr6_0024U_003D._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U());
		}
		_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKsoUgpxQFhiIIY_WtXJIUDQ_003D _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKsoUgpxQFhiIIY_WtXJIUDQ_003D2 = (_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKsoUgpxQFhiIIY_WtXJIUDQ_003D)_0023_003DzZzVr6_0024U_003D._0023_003DzqZLvK7FhPMHAcJUCHWtKXWMzPckK();
		Type type = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKsoUgpxQFhiIIY_WtXJIUDQ_003D2._0023_003DzwiwAdOMDh7ygMVKHFR_3XwPvhMtt64MKAw_003D_003D()._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U(), _0023_003DzZzVr6_0024U_003D: false);
		if (type.IsGenericType)
		{
			_0023_003Dz7hRN5Rg_003D = false;
		}
		return type.GetField(bindingAttr: _0023_003DzCSHSVURxeddLciIcy_MROeX6xPuiKKpWmw_003D_003D(_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKsoUgpxQFhiIIY_WtXJIUDQ_003D2._0023_003DzvWMwKXqQQI_0024dgaKCxuuQrf4_003D()), name: _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKsoUgpxQFhiIIY_WtXJIUDQ_003D2._0023_003Dzxz3z4sBny1bOtZOyVrj9CFcQ6Zdt());
	}

	private static void _0023_003DzYH_n6W6t8O_NrvzMsj4WSSo2Uc7k(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dzq80RbjQ_003D._0023_003Dz7WD6zOl6VlqdZylFMuS5P6NR2Tn8(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2));
	}

	private static void _0023_003DzkRsWz4Eq6dve_0024Z5TUUOjnV_olQhL(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzUcfwXkVt2OiFJi6klqPNUOc_003D(_0023_003Dzq80RbjQ_003D: false, _0023_003DzZzVr6_0024U_003D: false);
	}

	public object _0023_003DzIgKPz5OT94O_zSaBCYnBDdc_003D(Stream _0023_003Dzq80RbjQ_003D, string _0023_003DzZzVr6_0024U_003D, object[] _0023_003Dz7hRN5Rg_003D)
	{
		return _0023_003DzdBynfCK8oNJXn_rxK_rgOspqA_0024qzHYqdqekCWfw_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, null, null, null);
	}

	private static void _0023_003Dz5XqbKCNC_c0jdbkj0Q_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		double num = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			8 => ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
		obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(num);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzoRqx5a7tJflZpkonX6uD3DHtIi6VdmHIbNC_jway4lKc(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				if (!_0023_003DzcbLoSrg_003D)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					int num3 = ((!_0023_003Dz7hRN5Rg_003D) ? (num * num2) : checked(num * num2));
					return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num3);
				}
				uint num4 = (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				uint num5 = (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				uint num6 = ((!_0023_003Dz7hRN5Rg_003D) ? (num4 * num5) : checked(num4 * num5));
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D((int)num6);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzAWKEo3Qq47YSuChdubvmach1KCpK(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzAWKEo3Qq47YSuChdubvmach1KCpK(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
				}
				return _0023_003DzoRqx5a7tJflZpkonX6uD3DHtIi6VdmHIbNC_jway4lKc(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzAWKEo3Qq47YSuChdubvmach1KCpK(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				return _0023_003DzAWKEo3Qq47YSuChdubvmach1KCpK(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzAWKEo3Qq47YSuChdubvmach1KCpK(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
				}
				return _0023_003DzAWKEo3Qq47YSuChdubvmach1KCpK(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8 && _0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8)
		{
			_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
			obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D() * ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D());
			return obj;
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzoRqx5a7tJflZpkonX6uD3DHtIi6VdmHIbNC_jway4lKc(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			return _0023_003DzoRqx5a7tJflZpkonX6uD3DHtIi6VdmHIbNC_jway4lKc(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
		}
		throw new InvalidOperationException();
	}

	private static _0023_003DzuwE9t4w_003D _0023_003DzjG2c_0024HiqBDADYewlgSyJ0QjjuE0U(MethodBase _0023_003Dzq80RbjQ_003D, bool _0023_003DzZzVr6_0024U_003D)
	{
		DynamicMethod dynamicMethod = null;
		if (dynamicMethod == null)
		{
			dynamicMethod = new DynamicMethod(string.Empty, _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D, new Type[2]
			{
				_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D,
				_0023_003DzkEXSfPc_003D
			}, typeof(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D).Module, skipVisibility: true);
		}
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		ParameterInfo[] parameters = _0023_003Dzq80RbjQ_003D.GetParameters();
		Type[] array = new Type[parameters.Length];
		bool flag = false;
		for (int i = 0; i < parameters.Length; i++)
		{
			Type type = parameters[i].ParameterType;
			if (type.IsByRef)
			{
				flag = true;
				type = type.GetElementType();
			}
			array[i] = type;
		}
		LocalBuilder[] array2 = new LocalBuilder[array.Length];
		if (array2.Length != 0)
		{
			dynamicMethod.InitLocals = true;
		}
		for (int j = 0; j < array.Length; j++)
		{
			array2[j] = iLGenerator.DeclareLocal(array[j]);
		}
		for (int k = 0; k < array.Length; k++)
		{
			iLGenerator.Emit(OpCodes.Ldarg_1);
			_0023_003Dzp0XWyj3tqlRr7C12n_002488AaEfE_pLs3wExbISWSA_003D(iLGenerator, k);
			iLGenerator.Emit(OpCodes.Ldelem_Ref);
			_0023_003DzTQaLTHZ6ouRHHMkK0Q_003D_003D(iLGenerator, array[k]);
			iLGenerator.Emit(OpCodes.Stloc, array2[k]);
		}
		if (flag)
		{
			iLGenerator.BeginExceptionBlock();
		}
		if (!_0023_003Dzq80RbjQ_003D.IsStatic && !_0023_003Dzq80RbjQ_003D.IsConstructor)
		{
			iLGenerator.Emit(OpCodes.Ldarg_0);
			Type declaringType = _0023_003Dzq80RbjQ_003D.DeclaringType;
			if (declaringType.IsValueType)
			{
				iLGenerator.Emit(OpCodes.Unbox, declaringType);
				_0023_003DzZzVr6_0024U_003D = false;
			}
			else
			{
				_0023_003DzaTQyY1cvgPsW3zUyM6yKMUkLLh9d_0024cfTjmsR6Oc_003D(iLGenerator, declaringType);
			}
		}
		for (int l = 0; l < array.Length; l++)
		{
			if (parameters[l].ParameterType.IsByRef)
			{
				iLGenerator.Emit(OpCodes.Ldloca_S, array2[l]);
			}
			else
			{
				iLGenerator.Emit(OpCodes.Ldloc, array2[l]);
			}
		}
		if (_0023_003Dzq80RbjQ_003D.IsConstructor)
		{
			iLGenerator.Emit(OpCodes.Newobj, (ConstructorInfo)_0023_003Dzq80RbjQ_003D);
			_0023_003Dzn8QpwEGuvdshxw6Gp3bj_R8Hww4dxwJ5TCJ1OBVpUkpl(iLGenerator, _0023_003Dzq80RbjQ_003D.DeclaringType);
		}
		else
		{
			MethodInfo methodInfo = (MethodInfo)_0023_003Dzq80RbjQ_003D;
			if (!_0023_003DzZzVr6_0024U_003D || _0023_003Dzq80RbjQ_003D.IsStatic)
			{
				iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
			}
			else
			{
				iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
			}
			if (methodInfo.ReturnType == _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzLaPeX80_003D)
			{
				iLGenerator.Emit(OpCodes.Ldnull);
			}
			else
			{
				_0023_003Dzn8QpwEGuvdshxw6Gp3bj_R8Hww4dxwJ5TCJ1OBVpUkpl(iLGenerator, methodInfo.ReturnType);
			}
		}
		if (flag)
		{
			LocalBuilder local = iLGenerator.DeclareLocal(_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D);
			iLGenerator.Emit(OpCodes.Stloc, local);
			iLGenerator.BeginFinallyBlock();
			for (int m = 0; m < array.Length; m++)
			{
				if (parameters[m].ParameterType.IsByRef)
				{
					iLGenerator.Emit(OpCodes.Ldarg_1);
					_0023_003Dzp0XWyj3tqlRr7C12n_002488AaEfE_pLs3wExbISWSA_003D(iLGenerator, m);
					iLGenerator.Emit(OpCodes.Ldloc, array2[m]);
					if (array2[m].LocalType.IsValueType || _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzFkSVnloSTgfB_TuxgOff5OemKRrwlKQflVohFlutimzk(array2[m].LocalType).IsGenericParameter)
					{
						iLGenerator.Emit(OpCodes.Box, array2[m].LocalType);
					}
					iLGenerator.Emit(OpCodes.Stelem_Ref);
				}
			}
			iLGenerator.EndExceptionBlock();
			iLGenerator.Emit(OpCodes.Ldloc, local);
		}
		iLGenerator.Emit(OpCodes.Ret);
		return (_0023_003DzuwE9t4w_003D)dynamicMethod.CreateDelegate(typeof(_0023_003DzuwE9t4w_003D));
	}

	private static void _0023_003DzMThMAl7jgaeIJhj8ldjBniiR11c7(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzcHX5J0_BxaBvebV44eNBFeg_003D(((_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzjMeEJ3HfdiVVM9FdsA_003D_003D());
	}

	private static BindingFlags _0023_003DzCSHSVURxeddLciIcy_MROeX6xPuiKKpWmw_003D_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
		if (_0023_003Dzq80RbjQ_003D)
		{
			return bindingFlags | BindingFlags.Static;
		}
		return bindingFlags | BindingFlags.Instance;
	}

	private void _0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		switch (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
		{
		case 2:
			((_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzsg16MNLOFrIol9kAkfDFT25y5dmq()._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003DzZzVr6_0024U_003D);
			break;
		case 23:
			this.m__0023_003Dz5QkdKZk_003D[((_0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzyaPG31LUW61wDbz6or_0024_wKhVLOakW65jTE_0024juPit4kmE()]._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003DzZzVr6_0024U_003D);
			break;
		case 18:
		{
			_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2 = (_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D)_0023_003Dzq80RbjQ_003D;
			FieldInfo fieldInfo = _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2._0023_003DzVi5MXbrt8BXDXKmnYfbx7oiBSVGN();
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D(), fieldInfo.FieldType);
			fieldInfo.SetValue(_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2._0023_003DzcN50AjqFb2YG4rc00V_scr8LiJfHGEg8oQ_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
			_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 = _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2._0023_003DzjuTNzZAfWCvIVrQzFC0O9ks_003D();
			if (_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 != null && fieldInfo.DeclaringType.IsValueType)
			{
				_0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2._0023_003DzcN50AjqFb2YG4rc00V_scr8LiJfHGEg8oQ_003D_003D(), null));
			}
			break;
		}
		case 11:
		case 24:
		{
			_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D _0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D2 = (_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D)_0023_003Dzq80RbjQ_003D;
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D(), _0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D2._0023_003DzlFJtOqYzUjPQeO2z37bjadRijaoA_00243WorzZbzdw_003D());
			_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D2._0023_003DzPkVQQOSEgIlTnZ_zzXauPVjP2Rwb_0024vCdCe6NCPFrdr7yrp3NU6mLlET1bvT4BD9_00249vkPICIKiIxo_9BhCX47Jnngj1nk(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
			break;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void _0023_003DzL1lWLjrLTywcRSsj75BhRk4ld4f6(Stream _0023_003Dzq80RbjQ_003D, long _0023_003DzZzVr6_0024U_003D, string _0023_003Dz7hRN5Rg_003D)
	{
		int num = _0023_003DzWy1FBpPadXE02j_00248_k6mgGP1UU27();
		_0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D _0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D2 = new _0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D(_0023_003Dzq80RbjQ_003D, num);
		_0023_003DzAwa9dP4_003D = new _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D(_0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D2);
		if (_0023_003Dz7hRN5Rg_003D != null)
		{
			_0023_003DzZzVr6_0024U_003D = _0023_003DzJcb2qLOxhGvSUPXFlrHRD15WP60Zt0KmgiA_S5w_003D(_0023_003Dz7hRN5Rg_003D);
		}
		_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D2 = _0023_003DzAwa9dP4_003D._0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D();
		lock (_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D2)
		{
			_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D2._0023_003DzI4vE0RkXfN1pne8gbSVDgBlALYg3vbbRkBocu_0024P6sDNdA9J9PRaszMCsJP8vkAvSyWXjY_0024fkw_sdJCJA_0024Q_003D_003D(_0023_003DzZzVr6_0024U_003D, 0);
			_0023_003DzDKfGkY4WqaPLWUW63H1Yf5fdiP_0024F(_0023_003DzAwa9dP4_003D);
			m__0023_003DzAXvW_0024Kw_003D = _0023_003DzQTl7RhG9D_xvrZNM8TFjUM0_003D(_0023_003DzAwa9dP4_003D);
			_0023_003DzF6BhvwY_003D = _0023_003Dz3Q8ivFZzYWihyo2kkBx62nzPp3j36PUShvWFrds_003D(_0023_003DzAwa9dP4_003D);
			this.m__0023_003DzoVpU9JU_003D = _0023_003DzpYs7mVJ9Stj5X_U7NKxVDmKXKEtSKshy0FpZr1g_003D(_0023_003DzAwa9dP4_003D);
		}
		_0023_003DzjgzcRmU7k1760WeKvTJ3zwo8pNNmtm7_Aux4aCY_003D();
	}

	private void _0023_003Dz8dAiRnC0PuZ5ifCo_bCVFSS81KMh(ref _0023_003Dz7hRN5Rg_003D _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003Dzq80RbjQ_003D)
		{
			Monitor.Exit(_0023_003DzX_VRnyU_003D);
		}
	}

	private static void _0023_003DzF_nQzSWOCYI0ZEip172b8UE_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(long));
	}

	private void _0023_003DzPJCaFZeVnLaddax8TLiglvsSl8LBjm32MPmYr7H1LVhl(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzOBabv_0024CX_0024tbbIccpkA2g7gTsLvZCvQ1mCg_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2, _0023_003Dzq80RbjQ_003D));
	}

	private static void _0023_003Dz4l5pY53CPl5Sm5NGo9pCTiKjqVsa(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzaF2qAspOkBxepypZ_0024dOK8TK80mH6(_0023_003Dzq80RbjQ_003D: false);
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dz8NRW3xKX5s2pXubw5LwhRyf8GRbZUhORmhd4E1xK0vNX(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num | num2);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				int num3 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num3 | num4);
				}
				int num5 = Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num3 | num5);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				long num6 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				long num7 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num6 | num7);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				int num8 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				long num9 = Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num8 | num9);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				int num10 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D()) | num10);
				}
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D()) | num10);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				long num11 = Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				long num12 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num11 | num12);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num13 = Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
					long num14 = Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
					return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num13 | num14);
				}
				int num15 = Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				int num16 = Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num15 | num16);
			}
		}
		throw new InvalidOperationException();
	}

	private int _0023_003DzLlwjYw6G90e1tagGD7aboLs_003D()
	{
		return 1055444913;
	}

	private static void _0023_003DzTW2KN655JQzBthpx_BK2gVc_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525764));
	}

	private static void _0023_003Dzt74TV6cAWtutZoXohh0jW0E_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DztP7PBX2bGr9qR_8NV2HJNQoKwjzAZkYaog_003D_003D(((_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzjMeEJ3HfdiVVM9FdsA_003D_003D());
	}

	private static void _0023_003DzEXiO5L_0024jVAPCTimthCvlAEpKsYY_0024(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D(), type);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
	}

	private static void _0023_003DzLz4EQy5GlM9zzeCPcfEaI5LC273zjcCk9alP09Q_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(ushort));
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz4A3Alm0_003D;
		if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 != null)
		{
			_0023_003Dz4A3Alm0_003D = this.m__0023_003DzqMLoHoQ_003D;
			this.m__0023_003DzqMLoHoQ_003D = null;
			return _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2;
		}
		return _0023_003Dz349QwgY_003D.Pop();
	}

	private static void _0023_003DzL_0024alN3wg5LS_0024oDufmbdfUNxSbldt_00240VFiw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		UIntPtr uIntPtr = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => new UIntPtr((uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
			13 => new UIntPtr((ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()), 
			19 => new UIntPtr(Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => new UIntPtr((ulong)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D obj = new _0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D();
		obj._0023_003Dz2kixPGJySopLqOJCgTBxbSw_003D(uIntPtr);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static void _0023_003Dz03TaZ5Rvp52swoTYgLKo_00244w9yZzn(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
	}

	private static void _0023_003DzRwuD_0024q9Jem49_lkHC32cwMc0BPio(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525739));
	}

	private static void _0023_003Dz4xSO5gOznq4x4pPoVy5btBq3ujYziS4kHGSp_0024YetPe_P(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003Dz6uwpXMENmglaFBA5cfbtfP3Gde20_280x37pdP0_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private static Exception _0023_003DzhBmkzxy2X2zwT5BM8ZFsm3NEzCEG(string _0023_003Dzq80RbjQ_003D, string _0023_003DzZzVr6_0024U_003D)
	{
		return new TypeLoadException(_0023_003DzW9inGhxh3D5B3aHEojMGBQ4wP7uXJo8QviUuDOA_003D(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526647) + _0023_003Dzq80RbjQ_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526611), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526187) + _0023_003DzZzVr6_0024U_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526611)));
	}

	private static void _0023_003Dz6WHb6TPjdZgSqRbNQRhSPzs4FVqo(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type t = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Marshal.SizeOf(t)));
	}

	private static void _0023_003Dz7lbSoR66JqDOKS0uMqIsQ6eIw_KKpK8EvUVwB00_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzmJcTjZMU20gnWIs5PUtcynYB9r4_0024tmr4dl3qxi0_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	private void _0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526154));
		}
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2;
		if (_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D() != null)
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D;
		}
		else
		{
			switch (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
			{
			case 22:
			{
				_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj9 = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
				obj9._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(((_0023_003Dqn9vzRhA2ElEc1m7zxcM2lTvbOR_0024ZQ0P7_0024LxZWQMZVZ4_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzBuEITi7DMVp5zYufZYrk9Jp_00240bcuJbREYeG0iac_003D());
				obj9._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = obj9;
				break;
			}
			case 12:
			{
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj8 = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(((_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D());
				obj8._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = obj8;
				break;
			}
			case 26:
			{
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj7 = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(((_0023_003DqdNZUt_0024iJn5WNQtOH9gV2HPPfTj__0024T2JWbHYW_4UZP4I_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzqtsmetkNO0X0c4fOwM5KSE5JRboY1Jf9_0024suuhvwbVJRj());
				obj7._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = obj7;
				break;
			}
			case 17:
			{
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj10 = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(((_0023_003DqO9TEqm6qa7P6EAiT4EUfxPMmQ3zciexxzbCdgC_0024aWjI_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz806bIKoA6k8_oB7ZWXS7MWicU6IbkDlnHmFII04wj_0024_P());
				obj10._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = obj10;
				break;
			}
			case 16:
			{
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj5 = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(((_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzjMeEJ3HfdiVVM9FdsA_003D_003D());
				obj5._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = obj5;
				break;
			}
			case 3:
			{
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj4 = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D((int)((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D());
				obj4._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = obj4;
				break;
			}
			case 14:
			{
				_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D obj6 = new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D((long)((_0023_003DqtGizmq1hzhAS2kWo0eDWOZ_0024WiiBKi25W1_0024_AuDtqbDo_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz1Yg4eAUGPhIupAWATbUVuwf6FMFTbFeSNg_003D_003D());
				obj6._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = obj6;
				break;
			}
			case 15:
			{
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj3 = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(((_0023_003DqI9SEM_0024xY3_z7xlRX5ZGWocO9gZhA9acX9MDTcmTTOXM_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzgTEYsLwEsB7LQ4CtJ6ZprJzJ_l2b() ? 1 : 0);
				obj3._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = obj3;
				break;
			}
			case 6:
			{
				_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj2 = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(((_0023_003Dq3eydZg8QeNC29NwTbbJAKJf4gJlM5dK8pL8sPdUfv20_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzTYA1JY6le_0024tdtwZz8tyM41Y_003D());
				obj2._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(_0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D());
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = obj2;
				break;
			}
			case 7:
			{
				object obj = _0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
				if (obj == null)
				{
					_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D;
					break;
				}
				Type type = obj.GetType();
				if (type.HasElementType && !type.IsArray)
				{
					type = type.GetElementType();
				}
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = ((!(type != null) || type.IsValueType || type.IsEnum) ? _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, type) : _0023_003Dzq80RbjQ_003D);
				break;
			}
			default:
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D;
				break;
			}
		}
		if (_0023_003Dz4A3Alm0_003D != null)
		{
			if (this.m__0023_003DzqMLoHoQ_003D != null)
			{
				_0023_003Dz349QwgY_003D.Push(this.m__0023_003DzqMLoHoQ_003D);
			}
			this.m__0023_003DzqMLoHoQ_003D = _0023_003Dz4A3Alm0_003D;
		}
		_0023_003Dz4A3Alm0_003D = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2;
	}

	private static void _0023_003Dz8rlusmH1LHFia1LJyVAOPmCBI8vZwND1vpfWsX5tToJL(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzaF2qAspOkBxepypZ_0024dOK8TK80mH6(_0023_003Dzq80RbjQ_003D: true);
	}

	private _0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D _0023_003Dz9CN_7bwQXcC3D0ZW_0024jrgd_DCT_0024HU5u0mfw_003D_003D(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D obj = new _0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D();
		obj._0023_003Dz47sbffsjqDdJ6QR_0024QaJ8RJ02vpwu(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
		obj._0023_003Dz1d91cArbpWafTERDPcUW_0024TdIxmnZiu2lTA_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzu4XQE7baiUjLN0aaVp8iPQQ_003D());
		return obj;
	}

	private static void _0023_003DzUQ2blmXPH8jGs_jImlzo15tmRtZpu9q8AQ_ldpQ_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzsfG3IFcTKHi4W67Nrg_003D_003D(_0023_003Dzvup4kCA_003D);
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzUUD5_0024Mg0aGk0N6sI6w_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		if (!_0023_003DzcbLoSrg_003D)
		{
			long num = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			long num2 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			long num3 = ((!_0023_003Dz7hRN5Rg_003D) ? (num - num2) : checked(num - num2));
			return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		ulong num5 = (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		ulong num6 = ((!_0023_003Dz7hRN5Rg_003D) ? (num4 - num5) : checked(num4 - num5));
		return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D((long)num6);
	}

	private void _0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(Type _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 = (_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D)_0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2)._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D(), _0023_003Dzq80RbjQ_003D));
	}

	private static void _0023_003DzN9BukJyZm1PvCzwcO6Z_0024rB9l3A_0024bCJXPPcyoBPU_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzPJCaFZeVnLaddax8TLiglvsSl8LBjm32MPmYr7H1LVhl(_0023_003Dzq80RbjQ_003D: true);
	}

	private _0023_003Dqt1qrF59Q_0024wcdofgSAhBEqEXDJbUYu5MI_nuVtwlB69Y_003D _0023_003DzyCQ_1sSPuE7Y9nTFceT7ATo_00242T0jPpq67rirGSEJR_1M(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
		switch (_0023_003Dzq80RbjQ_003D._0023_003Dzgie8dX3wQlY8J8uAg8gyr39CXYW8L0PGHZYb0G4_003D())
		{
		case 2:
		{
			_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D obj6 = new _0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D();
			obj6._0023_003DznXbR6NG5LVsoVg8YTOoTc_00248_003D(_0023_003Dzq80RbjQ_003D._0023_003DzXDeO0ZPZHx72cYMmETLMlaj5qFonnk1sTAhKpy0_003D());
			obj6._0023_003DzmA65dhwH3FVcWWvtck75e4QZMkrS(_0023_003Dzq80RbjQ_003D._0023_003Dzu4XQE7baiUjLN0aaVp8iPQQ_003D());
			obj6._0023_003Dzxg2rmKX0E6fSzOZA_Q_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzu4XQE7baiUjLN0aaVp8iPQQ_003D());
			obj6._0023_003DzzCKPvhCGg8uv9IKgVGN78_0024Uy7JNN(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			obj6._0023_003Dz1HF60_GgYjpUoQYm24_0sYG9k3kcas4ftg_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D _0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2 = obj6;
			int num5 = _0023_003Dzq80RbjQ_003D._0023_003Dz2zeqxm_0024BvS1cRa9VitGV0MMzs8pL();
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D[] array3 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D[num5];
			for (int k = 0; k < num5; k++)
			{
				int num6 = k;
				_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D obj7 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D();
				obj7._0023_003DzWK2CB4P4S43UhAF7Ohcvad6TBRB8(1);
				obj7._0023_003DzhRZDIQHIxirWOYKyfQ_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
				array3[num6] = obj7;
			}
			_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003Dz6vijwfvnQFidWM_Yl8wjG9RlXIx3wFcxHfA6kcU_003D(array3);
			return _0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2;
		}
		case 1:
		{
			_0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKsoUgpxQFhiIIY_WtXJIUDQ_003D obj9 = new _0023_003Dq_0024fitmJlD_0024e3L2dCyl_0024RfKsoUgpxQFhiIIY_WtXJIUDQ_003D();
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D obj10 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D();
			obj10._0023_003DzWK2CB4P4S43UhAF7Ohcvad6TBRB8(1);
			obj10._0023_003DzhRZDIQHIxirWOYKyfQ_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			obj9._0023_003DzUeSjXuF_P6Rgn6RJXy2i5_0024o_003D(obj10);
			obj9._0023_003Dz9XDuex_iuLJVCGv6WbxuS1aKcdJ5rUub1lnGj2w_003D(_0023_003Dzq80RbjQ_003D._0023_003DzXDeO0ZPZHx72cYMmETLMlaj5qFonnk1sTAhKpy0_003D());
			obj9._0023_003Dzbq4u_0024YA_0024ExnVRQMcMf4ihEd4x1_0024D2ofcjA_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzu4XQE7baiUjLN0aaVp8iPQQ_003D());
			return obj9;
		}
		case 3:
		{
			_0023_003DqIYwamc_0024xa95DzIZnwgV16GUGEnPX47klc5OnsJ5eGRU_003D obj8 = new _0023_003DqIYwamc_0024xa95DzIZnwgV16GUGEnPX47klc5OnsJ5eGRU_003D();
			obj8._0023_003Dz4yguvi2RlTSTQiQ0Lg_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			obj8._0023_003Dz5vIKo4yKV5g8lIthPGyb1ZjBGBd2xTvf2zJmyQK3sfL8(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			return obj8;
		}
		case 0:
		{
			_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D _0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2 = new _0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D();
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D obj2 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D();
			obj2._0023_003DzWK2CB4P4S43UhAF7Ohcvad6TBRB8(1);
			obj2._0023_003DzhRZDIQHIxirWOYKyfQ_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzGXDivd7utKFdJPRjQ3LzuUmXot4J8AMSkA_003D_003D(obj2);
			_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzzPTmcRxJGSgZ0tm50wTHR9u0mY4f1f8VkNtJ6AQ_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzgie8dX3wQlY8J8uAg8gyr39CXYW8L0PGHZYb0G4_003D());
			_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzW7Ou0Bqsn_0024Vr5Tgn4TUzahy_Hu3c9oHy37zyg_c_003D(_0023_003Dzq80RbjQ_003D._0023_003DzXDeO0ZPZHx72cYMmETLMlaj5qFonnk1sTAhKpy0_003D());
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D obj3 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D();
			obj3._0023_003DzWK2CB4P4S43UhAF7Ohcvad6TBRB8(1);
			obj3._0023_003DzhRZDIQHIxirWOYKyfQ_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzYiwWqEBtz5pOkU_iN6jnIOA_003D(obj3);
			int num = _0023_003Dzq80RbjQ_003D._0023_003Dz2zeqxm_0024BvS1cRa9VitGV0MMzs8pL();
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D[] array = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = i;
				_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D obj4 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D();
				obj4._0023_003DzWK2CB4P4S43UhAF7Ohcvad6TBRB8(1);
				obj4._0023_003DzhRZDIQHIxirWOYKyfQ_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
				array[num2] = obj4;
			}
			_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzZWXjk5Md5VZCqCbywzo0W21rcxIyW0pYz153qcikJEOh(array);
			int num3 = _0023_003Dzq80RbjQ_003D._0023_003Dz2zeqxm_0024BvS1cRa9VitGV0MMzs8pL();
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D[] array2 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D[num3];
			for (int j = 0; j < num3; j++)
			{
				int num4 = j;
				_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D obj5 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D();
				obj5._0023_003DzWK2CB4P4S43UhAF7Ohcvad6TBRB8(1);
				obj5._0023_003DzhRZDIQHIxirWOYKyfQ_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
				array2[num4] = obj5;
			}
			_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003Dz1a95hl2ziZsWRKW4OyLaBKTXxuISEK6csuPpOWTmt66e(array2);
			return _0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2;
		}
		case 4:
		{
			_0023_003DqH5eXSVTJbmcb779MRNN3P8JeW_Ou9lYKwJ3hWlIm56g_003D obj = new _0023_003DqH5eXSVTJbmcb779MRNN3P8JeW_Ou9lYKwJ3hWlIm56g_003D();
			obj._0023_003DzPrX4JEw_0024ahjf3jRGHet6_SFmvakr_oFfadm6qi4_003D(_0023_003Dzq80RbjQ_003D._0023_003DzXDeO0ZPZHx72cYMmETLMlaj5qFonnk1sTAhKpy0_003D());
			return obj;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _0023_003DzVIVbhuftSM_7RVbeO36D8xUiwnUShJbWw6tG_iIdvKP1(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
	}

	private static void _0023_003DzJLyr9nAl8iUMAWpcdw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(sbyte));
	}

	private static void _0023_003Dz9Ne9W5OFkzCU1uBfSMUCk2I_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(float));
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzOBabv_0024CX_0024tbbIccpkA2g7gTsLvZCvQ1mCg_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				if (!_0023_003Dz7hRN5Rg_003D)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num / num2);
				}
				int num3 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				uint num4 = (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D((int)((uint)num3 / num4));
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzzMM48rKH687TiN9ZyUxHYyI_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzzMM48rKH687TiN9ZyUxHYyI_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
				}
				return _0023_003DzOBabv_0024CX_0024tbbIccpkA2g7gTsLvZCvQ1mCg_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzzMM48rKH687TiN9ZyUxHYyI_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				return _0023_003DzzMM48rKH687TiN9ZyUxHYyI_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003Dz7hRN5Rg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzzMM48rKH687TiN9ZyUxHYyI_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
				}
				return _0023_003DzzMM48rKH687TiN9ZyUxHYyI_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8 && _0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8)
		{
			_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
			obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D() / ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D());
			return obj;
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzOBabv_0024CX_0024tbbIccpkA2g7gTsLvZCvQ1mCg_003D_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			}
			return _0023_003DzOBabv_0024CX_0024tbbIccpkA2g7gTsLvZCvQ1mCg_003D_003D(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
		}
		throw new InvalidOperationException();
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzLuGlqWLl4cVPDKnZDQJHTuR2Wj2N02X5PLkfS5Q_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D)
	{
		if (!_0023_003Dz7hRN5Rg_003D)
		{
			long num = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			long num2 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num % num2);
		}
		long num3 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		ulong num4 = (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D((long)((ulong)num3 % num4));
	}

	private static void _0023_003DzOxu07ljmyqjk9oMgrWF5mo1yIA_iLzBocCRvbYq5ozOE(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003DzB_0024Rwap05HaolUNEYfZI197k_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2) ? 1 : 0));
	}

	private static _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D _0023_003Dzx65u8Kf6xtbuj_EnDGkijiRXjMXp_00249jBfm2Dlfo_003D(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D obj = new _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D();
		obj._0023_003Dz_0024u1hyMxB81DMBlOiPUHIuo9e2Gdj3KRWAw_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzgie8dX3wQlY8J8uAg8gyr39CXYW8L0PGHZYb0G4_003D());
		obj._0023_003DzajHfBdV7N3Iw1LjYelbmEPZY__00243rx1O_0024ZQ_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
		obj._0023_003DzRMUVfF_8SFkhPfeLYH7Mz6Mo2Xa6(_0023_003Dzq80RbjQ_003D._0023_003Dzxwm21_nmp2f5Ms_0024F4Fcqvf9_0024L1SjCRntwfAJwq4_003D());
		obj._0023_003DzJCio3O_kYjTL4iNAIKhvK8FNxD5I2kT3qQ_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzxwm21_nmp2f5Ms_0024F4Fcqvf9_0024L1SjCRntwfAJwq4_003D());
		obj._0023_003Dz0K7A8t47tOTMjHXI9ko5vxvJM2D_0024(_0023_003Dzq80RbjQ_003D._0023_003Dzxwm21_nmp2f5Ms_0024F4Fcqvf9_0024L1SjCRntwfAJwq4_003D());
		obj._0023_003Dz4pS7IBe5YpIvpr823UP0IPnwOi9pFiNhkd6ktHs_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzxwm21_nmp2f5Ms_0024F4Fcqvf9_0024L1SjCRntwfAJwq4_003D());
		return obj;
	}

	private static void _0023_003DzTQaLTHZ6ouRHHMkK0Q_003D_003D(ILGenerator _0023_003Dzq80RbjQ_003D, Type _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003DzZzVr6_0024U_003D.IsValueType || _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzFkSVnloSTgfB_TuxgOff5OemKRrwlKQflVohFlutimzk(_0023_003DzZzVr6_0024U_003D).IsGenericParameter)
		{
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Unbox_Any, _0023_003DzZzVr6_0024U_003D);
		}
		else
		{
			_0023_003DzaTQyY1cvgPsW3zUyM6yKMUkLLh9d_0024cfTjmsR6Oc_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
		}
	}

	private void _0023_003DzDKfGkY4WqaPLWUW63H1Yf5fdiP_0024F(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
	}

	private static void _0023_003DzqPEgj9aUtE7_OvGB2nLLe65iiW7b(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (_0023_003DzB_0024Rwap05HaolUNEYfZI197k_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private static void _0023_003Dzn8QpwEGuvdshxw6Gp3bj_R8Hww4dxwJ5TCJ1OBVpUkpl(ILGenerator _0023_003Dzq80RbjQ_003D, Type _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003DzZzVr6_0024U_003D.IsValueType || _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzFkSVnloSTgfB_TuxgOff5OemKRrwlKQflVohFlutimzk(_0023_003DzZzVr6_0024U_003D).IsGenericParameter)
		{
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Box, _0023_003DzZzVr6_0024U_003D);
		}
	}

	private static void _0023_003DzI6AntmTO8EJldrIPDt9YFMpdkWXFp_0m3RZM0wk_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		uint num = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (uint)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => (uint)Convert.ToInt64(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D[] array = (_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D[])((_0023_003Dq7Y_X1LJ_wwdl9r12hZAPJQpn7cOzytFyKfE_0024WrTLigc_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzvjGW_0024e7DXRUCe3ray8_hoDQ4k_0024PJPzV_MWPzgKlfZJXZ();
		if (num < array.Length)
		{
			uint num2 = (uint)array[num]._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num2);
		}
	}

	public void _0023_003DzcuxJrsHQF_Rj5c_67u2AJCIjdCLa(Stream _0023_003Dzq80RbjQ_003D, string _0023_003DzZzVr6_0024U_003D, object[] _0023_003Dz7hRN5Rg_003D)
	{
		_0023_003DzIgKPz5OT94O_zSaBCYnBDdc_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
	}

	[DebuggerNonUserCode]
	private MethodBase _0023_003DzceSsf__0024vYBWVlbSQGwq0O1iA1r3ZVmzrJbM9ET8_003D(int _0023_003Dzq80RbjQ_003D, _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DzZzVr6_0024U_003D)
	{
		lock (_0023_003DzxHwNxiw_003D)
		{
			bool flag = true;
			if (flag && _0023_003DzxHwNxiw_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out var value))
			{
				return (MethodBase)value;
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003Dzip8yWLvtIndlQqoIuur_x1i0otdXn27UJQ_003D_003D() == 0)
			{
				MethodBase methodBase = this.m__0023_003DzkJp9o4I_003D.ResolveMethod(_0023_003DzZzVr6_0024U_003D._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U());
				if (flag)
				{
					_0023_003DzxHwNxiw_003D.Add(_0023_003Dzq80RbjQ_003D, methodBase);
				}
				return methodBase;
			}
			_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D _0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2 = (_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D)_0023_003DzZzVr6_0024U_003D._0023_003DzqZLvK7FhPMHAcJUCHWtKXWMzPckK();
			if (_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003Dzd6d0PTYSWfHd6fU_0024pib9NQvWfQEVd1zcng_003D_003D())
			{
				return _0023_003DzyP50za2r3Cs8j4vEScuXoXIwmtKksc6pHqJxYG0_003D(_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2);
			}
			Type type = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzKdh11n0m88d_fpxANJjitRDG7epdVc5LAHf1XAY_003D()._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U(), _0023_003DzZzVr6_0024U_003D: false);
			Type type2 = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003Dz7Hkm9cwPT3L86VmdLdFR58VmHiUF()._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U(), _0023_003DzZzVr6_0024U_003D: true);
			Type[] array = new Type[_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzXma8mp_0024a__0024RK2w1Q8lnydG_3_0024wKH().Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzXma8mp_0024a__0024RK2w1Q8lnydG_3_0024wKH()[i]._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U(), _0023_003DzZzVr6_0024U_003D: true);
			}
			if (type.IsGenericType)
			{
				flag = false;
			}
			if (_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzYFISnatzWsztmppzzq1Q_K0gf2EF() == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525862))
			{
				ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.Any, array, null) ?? throw new Exception();
				if (flag)
				{
					_0023_003DzxHwNxiw_003D.Add(_0023_003Dzq80RbjQ_003D, constructorInfo);
				}
				return constructorInfo;
			}
			BindingFlags bindingAttr = _0023_003DzCSHSVURxeddLciIcy_MROeX6xPuiKKpWmw_003D_003D(_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003Dzx_8whzdQOUZcw5LhCApjFMQ_003D());
			MethodBase methodBase2 = null;
			try
			{
				methodBase2 = type.GetMethod(_0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzYFISnatzWsztmppzzq1Q_K0gf2EF(), bindingAttr, null, CallingConventions.Any, array, null);
			}
			catch (AmbiguousMatchException)
			{
				MethodInfo[] methods = type.GetMethods(bindingAttr);
				foreach (MethodInfo methodInfo in methods)
				{
					if (methodInfo.Name != _0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzYFISnatzWsztmppzzq1Q_K0gf2EF() || methodInfo.ReturnType != type2)
					{
						continue;
					}
					ParameterInfo[] parameters = methodInfo.GetParameters();
					if (parameters.Length != array.Length)
					{
						continue;
					}
					bool flag2 = false;
					for (int k = 0; k < array.Length; k++)
					{
						if (parameters[k].ParameterType != array[k])
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						methodBase2 = methodInfo;
						break;
					}
				}
			}
			if (methodBase2 == null)
			{
				throw new Exception(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525882), type.Name, _0023_003DqkFSllNsBiPRvMVij5CAGvB61Was7Jqle9F7cNDFgYFI_003D2._0023_003DzYFISnatzWsztmppzzq1Q_K0gf2EF()));
			}
			if (flag)
			{
				_0023_003DzxHwNxiw_003D.Add(_0023_003Dzq80RbjQ_003D, methodBase2);
			}
			return methodBase2;
		}
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzHM_5K2mtFT6DEcu86Qk9vLSKEKOX(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(-((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D());
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(-((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO());
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8)
		{
			_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
			obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(0.0 - ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D());
			return obj;
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzHM_5K2mtFT6DEcu86Qk9vLSKEKOX(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())));
			}
			return _0023_003DzHM_5K2mtFT6DEcu86Qk9vLSKEKOX(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())));
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzDsA_0024eBCaBK_LJSMRpE4YnIsh8x5wgxU_0024HaE8YA0_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzFPuHHafPEG92XM_0024gYatOtrw_0024UnVJ(_0023_003Dzq80RbjQ_003D: false, _0023_003DzZzVr6_0024U_003D: false);
	}

	private bool _0023_003Dzzduiut2EAcwdZLUjAciHTs2MmRA0YfHi_0024Q_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, Type _0023_003DzZzVr6_0024U_003D)
	{
		object obj = _0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		if (obj == null)
		{
			return true;
		}
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D() ?? obj.GetType();
		if (type == _0023_003DzZzVr6_0024U_003D || _0023_003DzZzVr6_0024U_003D.IsAssignableFrom(type))
		{
			return true;
		}
		if (!type.IsValueType && !_0023_003DzZzVr6_0024U_003D.IsValueType)
		{
			if (Marshal.IsComObject(obj))
			{
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.GetComInterfaceForObject(obj, _0023_003DzZzVr6_0024U_003D);
				}
				catch (ArgumentException)
				{
				}
				catch (InvalidCastException)
				{
				}
				if (intPtr != IntPtr.Zero)
				{
					try
					{
						Marshal.Release(intPtr);
					}
					catch
					{
					}
					return true;
				}
			}
			else if (_0023_003DzzSxlP7p7A1i7hCkzVLOALyccn0F3(obj))
			{
				return true;
			}
		}
		return false;
	}

	private static _0023_003DzuwE9t4w_003D _0023_003DzXOb4z00N8_8FLnE0SZgHJe4_003D(_0023_003DzkJp9o4I_003D _0023_003Dzq80RbjQ_003D)
	{
		lock (_0023_003DzBa3Kf5Y_003D)
		{
			_0023_003DzBa3Kf5Y_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out var value);
			return value;
		}
	}

	private static void _0023_003DzS1pA1NUa5o1EJlr_0024t4PdwTIcO1kMLSU3Lw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2 = (_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D;
		MethodBase methodBase = _0023_003Dzq80RbjQ_003D._0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D());
		_0023_003Dqqr0fJcmNHD_002426q7CfYl3TIKslsTynyI2_0024uUSOUtw4jk_003D obj = new _0023_003Dqqr0fJcmNHD_002426q7CfYl3TIKslsTynyI2_0024uUSOUtw4jk_003D();
		obj._0023_003DzqC7E3Vn82TFeKA4OyRAe_dA_003D(methodBase);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzKLjjiPIGmT8tT3KeXc7dfbpJbR3xSWCsmQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				if (!_0023_003DzcbLoSrg_003D)
				{
					int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
					int num3 = ((!_0023_003Dz7hRN5Rg_003D) ? (num + num2) : checked(num + num2));
					return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num3);
				}
				uint num4 = (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				uint num5 = (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				uint num6 = ((!_0023_003Dz7hRN5Rg_003D) ? (num4 + num5) : checked(num4 + num5));
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D((int)num6);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzNyPpvtkyCbUFL4rR9_0024JNDX33Hx21x3_0024WX77zFZf8Xk5Y(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzNyPpvtkyCbUFL4rR9_0024JNDX33Hx21x3_0024WX77zFZf8Xk5Y(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
				}
				return _0023_003DzKLjjiPIGmT8tT3KeXc7dfbpJbR3xSWCsmQ_003D_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
			{
				return _0023_003DzNyPpvtkyCbUFL4rR9_0024JNDX33Hx21x3_0024WX77zFZf8Xk5Y(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				return _0023_003DzNyPpvtkyCbUFL4rR9_0024JNDX33Hx21x3_0024WX77zFZf8Xk5Y(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzNyPpvtkyCbUFL4rR9_0024JNDX33Hx21x3_0024WX77zFZf8Xk5Y(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
				}
				return _0023_003DzNyPpvtkyCbUFL4rR9_0024JNDX33Hx21x3_0024WX77zFZf8Xk5Y(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8 && _0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 8)
		{
			_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
			obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D() + ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D());
			return obj;
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzKLjjiPIGmT8tT3KeXc7dfbpJbR3xSWCsmQ_003D_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
			}
			return _0023_003DzKLjjiPIGmT8tT3KeXc7dfbpJbR3xSWCsmQ_003D_003D(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003Dz8KdhWg0hTqjEP5Hx_0024qsvRVcd17gHMqhiKwWCXOM_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzbkB7sMGOzoMZR1tZ5x8adrEVlhbHCkoa9w_003D_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	private static void _0023_003DzmoA0kfgeVVPPaPHYHygdFg2St3lt(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dzq80RbjQ_003D._0023_003DzboxNZFRdW0op1ElE6xsFU1pvOx4MM8UJGzfZV2xS57hX(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2));
	}

	private static void _0023_003DzSa2BKUyFSF3EvpKQNg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		bool num2 = (num & int.MinValue) != 0;
		bool flag = (num & 0x40000000) != 0;
		num &= 0x3FFFFFFF;
		if (num2)
		{
			_0023_003Dzq80RbjQ_003D._0023_003DzkSoK2ou7NfSIMX60M6qb_0024GQxFe4n(num, null, null, flag);
			return;
		}
		_0023_003DqIYwamc_0024xa95DzIZnwgV16GUGEnPX47klc5OnsJ5eGRU_003D _0023_003DqIYwamc_0024xa95DzIZnwgV16GUGEnPX47klc5OnsJ5eGRU_003D2 = (_0023_003DqIYwamc_0024xa95DzIZnwgV16GUGEnPX47klc5OnsJ5eGRU_003D)_0023_003Dzq80RbjQ_003D._0023_003Dz2VVL65ZUV4mNemmPJRTlKGJnuqYG(num)._0023_003DzqZLvK7FhPMHAcJUCHWtKXWMzPckK();
		_0023_003Dzq80RbjQ_003D._0023_003DzVxxOU20Y14TmVDpN8nwBlbY_003D(_0023_003DqIYwamc_0024xa95DzIZnwgV16GUGEnPX47klc5OnsJ5eGRU_003D2);
	}

	private static void _0023_003DzWr74jZdGxGANJ9c60loKqI8_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzGK5WKeBvR9cWZYGHWewhHmFceBV2(_0023_003Dzq80RbjQ_003D: true, _0023_003DzZzVr6_0024U_003D: true);
	}

	private static void _0023_003DzUiFONH_JIoBW84u_0024oc5oAhjkO4gGZbq6zg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
	}

	private void _0023_003DzYdwOeQ6ohJIqRySc0WL8wF8xQ56H(object _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D is Exception ex)
		{
			_0023_003Dzvp9mEq0Zy21dtX3hLxtV0J3Qsgge7wcRgDY7wZQ_003D(ex);
		}
		_0023_003Dz_7PRtRA8l8tq7_UE7zHO83nFSqPH(_0023_003Dzq80RbjQ_003D);
	}

	private static void _0023_003DzF9QRcvt3zS3hQlqwPzlgEqn_ppnzHWVbqg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzFPuHHafPEG92XM_0024gYatOtrw_0024UnVJ(_0023_003Dzq80RbjQ_003D: true, _0023_003DzZzVr6_0024U_003D: true);
	}

	private void _0023_003DzkSoK2ou7NfSIMX60M6qb_0024GQxFe4n(int _0023_003Dzq80RbjQ_003D, Type[] _0023_003DzZzVr6_0024U_003D, Type[] _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		_0023_003DzAwa9dP4_003D._0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D()._0023_003DzI4vE0RkXfN1pne8gbSVDgBlALYg3vbbRkBocu_0024P6sDNdA9J9PRaszMCsJP8vkAvSyWXjY_0024fkw_sdJCJA_0024Q_003D_003D(_0023_003Dzq80RbjQ_003D, 0);
		_0023_003DzDKfGkY4WqaPLWUW63H1Yf5fdiP_0024F(_0023_003DzAwa9dP4_003D);
		_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D _0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D2 = _0023_003DzQTl7RhG9D_xvrZNM8TFjUM0_003D(_0023_003DzAwa9dP4_003D);
		_0023_003DzWWfxPaMVS9km2tSSY3Y4nG1g4A6wr3pzT0AiLc2bX_0024SJ(_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D2);
		int num = _0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D2._0023_003Dzk6NqcXocXPYbt5Kh5TxUvGSiFQOn().Length;
		object[] array = new object[num];
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] array2 = new _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[num];
		if (_0023_003DzaG3DPu0_003D != null && _0023_003DzcbLoSrg_003D)
		{
			int num2 = ((!_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D2._0023_003DzkElAVltokaRsq2qyltgIIyTvyqwv()) ? 1 : 0);
			Type[] array3 = new Type[num - num2];
			for (int num3 = num - 1; num3 >= num2; num3--)
			{
				array3[num3] = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D2._0023_003Dzk6NqcXocXPYbt5Kh5TxUvGSiFQOn()[num3]._0023_003DzMIf6Qcoa626dIfKdj06GAYVkuQnij6bPFMzPRpYqY31Y(), _0023_003DzZzVr6_0024U_003D: true);
			}
			MethodInfo method = _0023_003DzaG3DPu0_003D.GetMethod(_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D2._0023_003Dzijy_0024YuRSbTXlhC2ah706rnKCny8J(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array3, null);
			_0023_003DzaG3DPu0_003D = null;
			if (method != null)
			{
				_0023_003DzD2uSK_0024mBXXfGbn5bMRWJScc_003D(method, _0023_003DzZzVr6_0024U_003D: true);
				return;
			}
		}
		for (int num4 = num - 1; num4 >= 0; num4--)
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = (array2[num4] = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D());
			if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2)
			{
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2);
			}
			if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D() != null)
			{
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D())._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
			}
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D2._0023_003Dzk6NqcXocXPYbt5Kh5TxUvGSiFQOn()[num4]._0023_003DzMIf6Qcoa626dIfKdj06GAYVkuQnij6bPFMzPRpYqY31Y(), _0023_003DzZzVr6_0024U_003D: true))._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
			array[num4] = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
			if (num4 == 0 && _0023_003DzcbLoSrg_003D && !_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D2._0023_003DzkElAVltokaRsq2qyltgIIyTvyqwv() && array[num4] == null)
			{
				throw new NullReferenceException();
			}
		}
		_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2 = new _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D(_0023_003DzeJLIX5w_003D);
		object[] array4 = new object[1] { this.m__0023_003DzkJp9o4I_003D.Assembly };
		object obj;
		try
		{
			obj = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzCuczqEv4SH45QPwQF4DYmlQfcp7VmH_zcVziIvXYuW65(this.m__0023_003DzoyRBT1A_003D, _0023_003Dzq80RbjQ_003D, array, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, array4);
		}
		finally
		{
			bool flag = !_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D2._0023_003DzkElAVltokaRsq2qyltgIIyTvyqwv();
			for (int i = 0; i < num; i++)
			{
				int num5;
				if (flag)
				{
					num5 = i + 1;
					if (num5 == num)
					{
						num5 = 0;
					}
				}
				else
				{
					num5 = i;
				}
				if (array2[num5] is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D3)
				{
					_0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(array[num5], null));
				}
			}
		}
		Type type = _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2.m__0023_003DzAXvW_0024Kw_003D._0023_003DzLpSv0vHTW8_4lB2p8sQgRMe8pmaJ8yhiCg_003D_003D(), _0023_003DzZzVr6_0024U_003D: true);
		if (type != _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzLaPeX80_003D)
		{
			_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, type));
		}
	}

	private void _0023_003Dz6uwpXMENmglaFBA5cfbtfP3Gde20_280x37pdP0_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		long num = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (!_0023_003Dzq80RbjQ_003D) ? ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() : ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (!_0023_003Dzq80RbjQ_003D) ? ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() : ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => (!_0023_003Dzq80RbjQ_003D) ? ((long)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())) : checked((long)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => (!_0023_003Dzq80RbjQ_003D) ? ((long)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()) : checked((long)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			0 => (!_0023_003Dzq80RbjQ_003D) ? ((long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D obj = new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D();
		obj._0023_003DzgAt1mNmNuxVumV4R3YlFedE_003D(num);
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003Dzq80RbjQ_003D)
	{
		switch (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
		{
		case 2:
			return ((_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzsg16MNLOFrIol9kAkfDFT25y5dmq();
		case 23:
			return this.m__0023_003Dz5QkdKZk_003D[((_0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzyaPG31LUW61wDbz6or_0024_wKhVLOakW65jTE_0024juPit4kmE()];
		case 18:
		{
			_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2 = (_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D)_0023_003Dzq80RbjQ_003D;
			return _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2._0023_003DzVi5MXbrt8BXDXKmnYfbx7oiBSVGN().GetValue(_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2._0023_003DzcN50AjqFb2YG4rc00V_scr8LiJfHGEg8oQ_003D_003D()), null);
		}
		case 11:
		case 24:
		{
			_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D _0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D2 = (_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D)_0023_003Dzq80RbjQ_003D;
			return _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D2._0023_003DzcXsVhOewoJAkeimOANv4Y5_0024to7Zedife7e_0024F4NiZwMi2yUxxLIbnElEb7QICaGLAJ3gnYpI_003D(), _0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D2._0023_003DzlFJtOqYzUjPQeO2z37bjadRijaoA_00243WorzZbzdw_003D());
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _0023_003DzRcgrFjncJA0Oc_Xsb3VwVvqgTF_0024KHZKIng_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		string text = _0023_003Dzq80RbjQ_003D._0023_003DznMMoGwkuIQcygw5U_0024AEZNRBpmYc2MOYYByXiysPYi1HR(num);
		_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqoLZu7ARGqk3sO900JropiQ_003D obj = new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqoLZu7ARGqk3sO900JropiQ_003D();
		obj._0023_003DzJ_aFWmcjx_0024KCUNQBacmKUQo_003D(text);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static void _0023_003DzyZ_trJHGDiHWc962Xvt9PTo_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if ((_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 8) ? (!_0023_003DzbLKMaSlao_0024AFofVihsr7cM7_DlQeb2LkIgPm0rY_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)) : (!_0023_003DzwfAT8W8IYpR6ztTl1Vsa7rnoeEQiGi2vHCk_fc8_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private long _0023_003DzeE3jiLrpSvA9TWmZ_0024_0024gF_00_003D()
	{
		return _0023_003DzLi0XoCY_003D._0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D()._0023_003DzobG9IxqhwRDSPcfxNOqGyLk4ZhoGqGKIxRc5EwzLMnMXwgfZ90nCXR8JGEQLK55L4VFmzy0_003D() + _0023_003DzQ94e_m4_003D;
	}

	private static void _0023_003Dzm_PWo_0024nesXSPVRnS190fUMxv2pzx(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525109));
	}

	private static void _0023_003Dzx6K8Ge16ef7W_0024F6DYuPLDzo_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D _0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D2 = (_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003DzZzVr6_0024U_003D;
		_0023_003Dzq80RbjQ_003D._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D2._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D());
	}

	private static void _0023_003DzVpTGO2d_LeXvGtbBI9pnjvhuASk9hYo9ciTpqfM_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2 = (_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D;
		MethodBase methodBase = _0023_003Dzq80RbjQ_003D._0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D());
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] array = _0023_003Dzq80RbjQ_003D._0023_003DzxhN3bEo_003D;
		foreach (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 in array)
		{
			_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
		}
		_0023_003Dzq80RbjQ_003D._0023_003DzD2uSK_0024mBXXfGbn5bMRWJScc_003D(methodBase, _0023_003DzZzVr6_0024U_003D: false);
	}

	private static void _0023_003Dz7fEyAIRftNckR6dXW_ryUZQ_MkRi(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzcHX5J0_BxaBvebV44eNBFeg_003D(3);
	}

	private void _0023_003DzOUcX6xmBJPIP_7C2l8V5J1Q_TYlNJSFdIg_003D_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		sbyte b = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (!_0023_003Dzq80RbjQ_003D) ? ((sbyte)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()) : checked((sbyte)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
			13 => (!_0023_003Dzq80RbjQ_003D) ? ((sbyte)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()) : checked((sbyte)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()), 
			19 => (!_0023_003Dzq80RbjQ_003D) ? ((sbyte)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())) : checked((sbyte)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => (!_0023_003Dzq80RbjQ_003D) ? ((sbyte)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()) : checked((sbyte)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((sbyte)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((sbyte)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())) : ((!_0023_003Dzq80RbjQ_003D) ? ((sbyte)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((sbyte)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D();
		obj._0023_003DzYFXWifrsG3fRPmCVbL0axdi3r_0024DS(b);
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static void _0023_003DzUkwZH8h3cbbP4fdOwmUyDtBii9cG(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (!_0023_003Dz_kQL1hdRMpr2IqQAhsGNFwQ_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private static void _0023_003Dz4BGE4ppsVM2b1HCzmAQKkIKG0kUlEpAmTpRvI5s_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOUcX6xmBJPIP_7C2l8V5J1Q_TYlNJSFdIg_003D_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private static void _0023_003DzFBHnyTzp6Omxeq3SmYXF02XPQaOLC_0024_0024BxA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(int));
	}

	private long _0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5()
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		return _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			0 => ((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr().ToInt64(), 
			20 => (long)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D().ToUInt64(), 
			19 => Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			_ => throw new Exception(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525803)), 
		};
	}

	private static void _0023_003DzhKrqCrPyFdYScp1T_0024fJij2h7IAT66onw82JxqjQ_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(short));
	}

	private static void _0023_003DzTKNlwUGtp0s_fNRmdqSCIdM_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D _0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D2 = (_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D)_0023_003DzZzVr6_0024U_003D;
		_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D obj = new _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D();
		obj._0023_003DzzYzgkSraKLDKGhNE6_isGLbZYUM4(_0023_003Dzq80RbjQ_003D._0023_003DzxhN3bEo_003D[_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D2._0023_003DzjMeEJ3HfdiVVM9FdsA_003D_003D()]);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private void _0023_003DzNYr9S6dMDXOAp_0024ksZwcj62_edwiI38qlPAnnxDs_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		int num = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (!_0023_003Dzq80RbjQ_003D) ? ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() : ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (int)((!_0023_003Dzq80RbjQ_003D) ? ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() : checked((int)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO())), 
			19 => (!_0023_003Dzq80RbjQ_003D) ? ((int)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())) : checked((int)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => (!_0023_003Dzq80RbjQ_003D) ? ((int)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()) : checked((int)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			0 => (int)((IntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((int)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())) : ((!_0023_003Dzq80RbjQ_003D) ? ((int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()))), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D();
		obj._0023_003DzYFXWifrsG3fRPmCVbL0axdi3r_0024DS(num);
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private void _0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(int _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D)
		{
			this.m__0023_003Dz5QkdKZk_003D[_0023_003Dzq80RbjQ_003D] = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2;
		}
		else
		{
			this.m__0023_003Dz5QkdKZk_003D[_0023_003Dzq80RbjQ_003D]._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
		}
	}

	[_0023_003Dq3pUobS7gRU4PocUwxB9HRYowgS7sMsjW9FDO02FW3vk_003D(2)]
	private bool _0023_003DzD_Gu1XgYdlFBskkd4_0024QxuMSX96L4mNU5TQcY1pg_003D([_0023_003Dqhu8iWDnFsbbcNK8gRnbmYe9RgdJ2bjuG2Syc8f8xrvQ_003D(1)] MethodBase _0023_003Dzq80RbjQ_003D, object _0023_003DzZzVr6_0024U_003D, ref object _0023_003Dz7hRN5Rg_003D, [_0023_003Dqhu8iWDnFsbbcNK8gRnbmYe9RgdJ2bjuG2Syc8f8xrvQ_003D(new byte[] { 1, 2 })] object[] _0023_003DzcbLoSrg_003D)
	{
		Type declaringType = _0023_003Dzq80RbjQ_003D.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzYWGcjirBLOR1G3YpoMmbNyJEx1WWfXOuZmf7utk_003D(declaringType))
		{
			string name = _0023_003Dzq80RbjQ_003D.Name;
			if (name.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524848), StringComparison.Ordinal))
			{
				_0023_003Dz7hRN5Rg_003D = _0023_003DzZzVr6_0024U_003D != null;
			}
			else if (name.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524831), StringComparison.Ordinal))
			{
				if (_0023_003DzZzVr6_0024U_003D == null)
				{
					return ((bool?)null).Value;
				}
				_0023_003Dz7hRN5Rg_003D = _0023_003DzZzVr6_0024U_003D;
			}
			else if (name.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525423), StringComparison.Ordinal))
			{
				switch (_0023_003DzcbLoSrg_003D.Length)
				{
				case 0:
					_0023_003Dz7hRN5Rg_003D = _0023_003DzZzVr6_0024U_003D;
					break;
				case 1:
					if (_0023_003DzZzVr6_0024U_003D != null)
					{
						_0023_003Dz7hRN5Rg_003D = _0023_003DzZzVr6_0024U_003D;
					}
					else
					{
						_0023_003Dz7hRN5Rg_003D = _0023_003DzcbLoSrg_003D[0];
					}
					break;
				default:
					return false;
				}
			}
			else
			{
				if (_0023_003DzZzVr6_0024U_003D != null || _0023_003Dzq80RbjQ_003D.IsStatic)
				{
					return false;
				}
				_0023_003Dz7hRN5Rg_003D = null;
			}
			return true;
		}
		if (declaringType == _0023_003Dz1j2rMNI_003D)
		{
			string name2 = _0023_003Dzq80RbjQ_003D.Name;
			if (name2.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525431), StringComparison.Ordinal))
			{
				_0023_003Dz7hRN5Rg_003D = _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzuwE9t4w_003D;
				return true;
			}
			if (this.m__0023_003DzKyPCKaY_003D != null && name2.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525402), StringComparison.Ordinal))
			{
				object[] array = this.m__0023_003DzKyPCKaY_003D;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] is Assembly assembly)
					{
						_0023_003Dz7hRN5Rg_003D = assembly;
						return true;
					}
				}
			}
		}
		else if (declaringType == _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzZzVr6_0024U_003D)
		{
			if (_0023_003Dzq80RbjQ_003D.Name.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525475), StringComparison.Ordinal))
			{
				if (this.m__0023_003DzKyPCKaY_003D != null)
				{
					object[] array = this.m__0023_003DzKyPCKaY_003D;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] is MethodBase methodBase)
						{
							_0023_003Dz7hRN5Rg_003D = methodBase;
							return true;
						}
					}
				}
				_0023_003Dz7hRN5Rg_003D = MethodBase.GetCurrentMethod();
				return true;
			}
		}
		else if (declaringType.IsArray && declaringType.GetArrayRank() >= 2)
		{
			return _0023_003DzAvTsrJ7k_yxiFHYcHDZamLs_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, ref _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D);
		}
		return false;
	}

	private static void _0023_003DzMtBm4377GUedudm3A0K9LQXPiNLueGke1Ek931c_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dzq80RbjQ_003D._0023_003Dz8NRW3xKX5s2pXubw5LwhRyf8GRbZUhORmhd4E1xK0vNX(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2));
	}

	private static void _0023_003Dz_0024fARyEm2EXZmcVMC5ipjW5wKkrwt(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzmJcTjZMU20gnWIs5PUtcynYB9r4_0024tmr4dl3qxi0_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private static void _0023_003DzeIbrdrRS_00242unmILrnmjMFdCvyQQqjAiL4A_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzgvGx8MFmQfFwyuAFc7msZwqmhV7g(_0023_003Dzq80RbjQ_003D: true);
	}

	private static void _0023_003Dzk4h_0024JzAXDTEff59mGYZQSfq6tINhCG_0024v2rfCOz8_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(checked(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (int)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (int)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => (int)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			8 => (int)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((int)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((int)(uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzJ8JCwIfLzQGXUktmLzI4Ya7pmkAt(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if ((_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 8) ? (!_0023_003DzwfAT8W8IYpR6ztTl1Vsa7rnoeEQiGi2vHCk_fc8_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)) : (!_0023_003DzbLKMaSlao_0024AFofVihsr7cM7_DlQeb2LkIgPm0rY_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private static void _0023_003DzrL2eDExcmIcgfZaXpg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(typeof(double));
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzAWKEo3Qq47YSuChdubvmach1KCpK(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		if (!_0023_003DzcbLoSrg_003D)
		{
			long num = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			long num2 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			long num3 = ((!_0023_003Dz7hRN5Rg_003D) ? (num * num2) : checked(num * num2));
			return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		ulong num5 = (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		ulong num6 = ((!_0023_003Dz7hRN5Rg_003D) ? (num4 * num5) : checked(num4 * num5));
		return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D((long)num6);
	}

	private static void _0023_003DzRQyIhIIrrG2vD4A4u5x_3Nc68vq7(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		IntPtr intPtr = checked(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => new IntPtr((uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
			13 => new IntPtr((long)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()), 
			19 => new IntPtr((long)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => new IntPtr((long)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			_ => throw new InvalidOperationException(), 
		});
		_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D obj = new _0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D();
		obj._0023_003Dz_0024eT0u_00244AlLxv9vzC5bag2xx1uYIycKqC7_Qs0Bo_003D(intPtr);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static void _0023_003DzXtmtuEP_0024qZ9gk2CtoEBJ27Q_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzUcfwXkVt2OiFJi6klqPNUOc_003D(_0023_003Dzq80RbjQ_003D: true, _0023_003DzZzVr6_0024U_003D: false);
	}

	private static void _0023_003DzyRCW9ycIvsQeq8oGmw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003Dzq80RbjQ_003D._0023_003DzsfG3IFcTKHi4W67Nrg_003D_003D(type);
	}

	private void _0023_003DzoSOcA_xIir7qj1v7MWszdx8_003D(int _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D obj = new _0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D();
		obj._0023_003DzJKxdG3iYGaCfHZ7MazKp7gk19yRf5HJUaxPb07U_003D(_0023_003Dzq80RbjQ_003D);
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static void _0023_003DzCcNqaKuG9WCaEPBQGcUX8TfCVuoC(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(double));
	}

	private Type _0023_003Dz9yuOi6ipcItiiUygi4SIRn8QoJy9hhxz07vba7g_003D(int _0023_003Dzq80RbjQ_003D, _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DzZzVr6_0024U_003D, ref bool _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		if (_0023_003DzZzVr6_0024U_003D._0023_003Dzip8yWLvtIndlQqoIuur_x1i0otdXn27UJQ_003D_003D() == 0)
		{
			return this.m__0023_003DzkJp9o4I_003D.ResolveType(_0023_003DzZzVr6_0024U_003D._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U());
		}
		_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D _0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2 = (_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D)_0023_003DzZzVr6_0024U_003D._0023_003DzqZLvK7FhPMHAcJUCHWtKXWMzPckK();
		Type type = null;
		if (_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzQGR6O7hgteLiiE9slKiYbrg_003D())
		{
			if (_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzU4OVUekXXfD_jdwaa0HpOAD_3Czr() != -1)
			{
				if (_0023_003DzuUxvxmo_003D == null)
				{
					throw new InvalidOperationException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525552));
				}
				type = _0023_003DzuUxvxmo_003D[_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzU4OVUekXXfD_jdwaa0HpOAD_3Czr()];
			}
			else
			{
				if (_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzpOKctGSEqrA1HMRqu49Sjzc_00248_0024MQ5Q2nHg_003D_003D() == -1)
				{
					throw new Exception();
				}
				if (this.m__0023_003DzcbLoSrg_003D == null)
				{
					throw new InvalidOperationException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525505));
				}
				type = this.m__0023_003DzcbLoSrg_003D[_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzpOKctGSEqrA1HMRqu49Sjzc_00248_0024MQ5Q2nHg_003D_003D()];
			}
			Stack<_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D> stack = _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzsYo6xG8FqKmjeKuOtLTaTPw_003D(_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzAr04gFr0Rpyl23E_fbU1xrVGMFMzbHL23g_003D_003D());
			type = _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzGHlwp_0024Ivr07TXIwyhYJfDKc_003D(type, stack);
			_0023_003Dz7hRN5Rg_003D = false;
			return type;
		}
		string text = _0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzAr04gFr0Rpyl23E_fbU1xrVGMFMzbHL23g_003D_003D();
		try
		{
			type = Type.GetType(text);
		}
		catch (BadImageFormatException)
		{
		}
		if (type == null)
		{
			int num = text.IndexOf(',');
			string text2 = text.Substring(0, num);
			string text3 = text.Substring(num + 1).Trim();
			Assembly assembly = _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzuwE9t4w_003D;
			if (text3.Equals(assembly.FullName, StringComparison.OrdinalIgnoreCase))
			{
				type = ((!text2.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525614), StringComparison.Ordinal)) ? assembly.GetType(text2) : _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzUH03yec_003D);
			}
			else
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly2 in assemblies)
				{
					string value = null;
					try
					{
						value = assembly2.Location;
					}
					catch (NotSupportedException)
					{
					}
					if (string.IsNullOrEmpty(value) && assembly2.FullName.Equals(text3, StringComparison.OrdinalIgnoreCase))
					{
						type = assembly2.GetType(text2);
						if (type != null)
						{
							break;
						}
					}
				}
			}
			if (type == null && text2.StartsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525601), StringComparison.Ordinal) && text2.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526571)))
			{
				try
				{
					Type[] types = Assembly.Load(text3).GetTypes();
					foreach (Type type2 in types)
					{
						if (type2.FullName == text2)
						{
							type = type2;
							break;
						}
					}
				}
				catch
				{
				}
			}
		}
		if (type == null)
		{
			throw new TypeLoadException(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525595), text));
		}
		if (_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzXjjBx5pbFoZeXS2FGQ5G8xx5m10f())
		{
			if (_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzFPlkv8kn7EhqpRc13t0q77yEzEAi().Length != 0)
			{
				Type[] array = new Type[_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzFPlkv8kn7EhqpRc13t0q77yEzEAi().Length];
				for (int j = 0; j < _0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzFPlkv8kn7EhqpRc13t0q77yEzEAi().Length; j++)
				{
					array[j] = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzFPlkv8kn7EhqpRc13t0q77yEzEAi()[j]._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U(), _0023_003DzcbLoSrg_003D);
				}
				Type genericTypeDefinition = _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzFkSVnloSTgfB_TuxgOff5OemKRrwlKQflVohFlutimzk(type).GetGenericTypeDefinition();
				Stack<_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D> stack2 = _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzYl_0024a_yWqakc8AwZs01mSdGU_003D(type);
				type = genericTypeDefinition.MakeGenericType(array);
				type = _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzGHlwp_0024Ivr07TXIwyhYJfDKc_003D(type, stack2);
			}
			_0023_003Dz7hRN5Rg_003D = false;
		}
		return type;
	}

	private static void _0023_003DzaSN230TpFkaylGJgydA8w6KQXtsq4KEomeRofArUrnKB(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D);
	}

	private void _0023_003DzvQQP5BELn8vLJ6Gf7XVrZxFAvcN15nzHnA_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D)
	{
		if (((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D())._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() != 0)
		{
			this.m__0023_003Dzq80RbjQ_003D.Push(new _0023_003DzqMLoHoQ_003D(_0023_003DzmZNu_pI_003D, _0023_003Dz0Ht_0024Sk0_003D));
			this.m__0023_003DzuwE9t4w_003D = false;
		}
		_0023_003DzDpNz_0024ws8Z8wzT_0024TQLl8uOeAxUIl9();
	}

	private static void _0023_003DzJHEzhSl4p0moe8vIdgHXhfYjnwQU(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003Dz2Uq_uvZk7h8fhbsi9DJGFt8_003D(_0023_003DzZzVr6_0024U_003D);
	}

	private static void _0023_003DzrONcF5oeeckCc02tmqlo_0024ZOhe5Nt(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		double num = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
		obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(num);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	public static object _0023_003Dzc_wLCDILL_0024YoX_0024viah_o7RRHVcZKUniJuB66bLg_003D(Type _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D.IsValueType)
		{
			return Activator.CreateInstance(_0023_003Dzq80RbjQ_003D);
		}
		return null;
	}

	private static void _0023_003Dzy3LGo3AZjkba_TJUCp0SDWwEUhoJ(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] _0023_003DzUpbyuVdyI9_0024U_sls9mmOL6mRCsTgdcnxThL7nJk_003D(object[] _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D[] array = m__0023_003DzAXvW_0024Kw_003D._0023_003Dzk6NqcXocXPYbt5Kh5TxUvGSiFQOn();
		int num = array.Length;
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] array2 = new _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[num];
		for (int i = 0; i < num; i++)
		{
			object obj = _0023_003Dzq80RbjQ_003D[i];
			Type type = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(array[i]._0023_003DzMIf6Qcoa626dIfKdj06GAYVkuQnij6bPFMzPRpYqY31Y(), _0023_003DzZzVr6_0024U_003D: false);
			Type type2 = null;
			Type type3 = _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dz5m3WmfE4_0024lDVC2gOqxYhKVJiZIXs(type);
			type2 = ((!(type3 == _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D) && !_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzYWGcjirBLOR1G3YpoMmbNyJEx1WWfXOuZmf7utk_003D(type3)) ? ((obj != null) ? obj.GetType() : type) : type);
			if (obj != null && !type.IsAssignableFrom(type2) && type.IsByRef && !type.GetElementType().IsAssignableFrom(type2))
			{
				throw new ArgumentException(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525450), type2, type));
			}
			array2[i] = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, type2);
		}
		if (!m__0023_003DzAXvW_0024Kw_003D._0023_003DzkElAVltokaRsq2qyltgIIyTvyqwv() && _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(m__0023_003DzAXvW_0024Kw_003D._0023_003DzeFmYRYvMy4A0IhX6fIHDEUwm_00242cyzi_3XQ_003D_003D(), _0023_003DzZzVr6_0024U_003D: false).IsValueType)
		{
			_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D obj2 = new _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D();
			obj2._0023_003DzzYzgkSraKLDKGhNE6_isGLbZYUM4(array2[0]);
			array2[0] = obj2;
		}
		for (int j = 0; j < num; j++)
		{
			if (array[j]._0023_003DzqetEU5ZANX15xnSv7pWIdjRVzRHWuShl2g_003D_003D())
			{
				int num2 = j;
				_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D obj3 = new _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D();
				obj3._0023_003DzzYzgkSraKLDKGhNE6_isGLbZYUM4(array2[j]);
				array2[num2] = obj3;
			}
		}
		return array2;
	}

	private static bool _0023_003DzB_0024Rwap05HaolUNEYfZI197k_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		bool result = false;
		switch (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
		{
		case 1:
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzB_0024Rwap05HaolUNEYfZI197k_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())));
			}
			result = (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() < (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
			break;
		case 13:
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzB_0024Rwap05HaolUNEYfZI197k_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())));
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				return _0023_003DzB_0024Rwap05HaolUNEYfZI197k_003D(_0023_003Dzq80RbjQ_003D, new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()));
			}
			result = (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() < (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			break;
		case 19:
			return _0023_003DzB_0024Rwap05HaolUNEYfZI197k_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), _0023_003DzZzVr6_0024U_003D);
		case 8:
		{
			double num = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			double num2 = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			result = num < num2 || double.IsNaN(num) || double.IsNaN(num2);
			break;
		}
		}
		return result;
	}

	private static void _0023_003DzfOjavdDn84wcXkZxZdFcdXs_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(int));
	}

	private static void _0023_003DzHr22jfx_3Pif2gy3MtQLMhas2pfc(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D obj = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (obj._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 1)
		{
			throw new InvalidOperationException();
		}
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)obj)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Stack<_0023_003DzUH03yec_003D> stack = _0023_003Dzq80RbjQ_003D._0023_003DzbKacmMjJlAozzsmL94D6Uq6kYdq6();
		if (stack.Count < 2)
		{
			throw new InvalidOperationException();
		}
		using _0023_003DzUH03yec_003D _0023_003DzUH03yec_003D2 = stack.Pop();
		if (_0023_003DzUH03yec_003D2 == null || _0023_003DzUH03yec_003D2._0023_003Dzq80RbjQ_003D._0023_003DzCxb16E17coEGI1SUwsEO1JpW0Af6uOwABNm4AT6_ZC6h4s1CRNNIKmAWrkz0J3C0RxWkji5Fw9ki() != num)
		{
			throw new InvalidOperationException();
		}
		_0023_003DzUH03yec_003D _0023_003DzUH03yec_003D3 = stack.Peek();
		_0023_003Dzq80RbjQ_003D._0023_003DzmSUiy7sPdkHWa_kpgPiolyyCqWUwmeU_lBOK610_003D(_0023_003DzUH03yec_003D3);
		_0023_003Dzq80RbjQ_003D._0023_003DzmZNu_pI_003D += (uint)_0023_003DzUH03yec_003D2._0023_003Dzq80RbjQ_003D._0023_003DzZ5ju5HxB3HXgYCOAcQ_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003Dz_0024AVDGBkSTbtVZvD9e2JWltw_003D(_0023_003Dzq80RbjQ_003D._0023_003DzmZNu_pI_003D);
	}

	private static void _0023_003Dz9vK6JLWSJtaI1GnOrp_0024BeFGm_0024uJQP29OUMrG548_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(8);
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzjn_lOGw1LY78GVWwkyAJMw9qyzH17GIGlFoWNP8_003D(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D, byte _0023_003DzZzVr6_0024U_003D)
	{
		switch (_0023_003DzZzVr6_0024U_003D)
		{
		case 11:
			return null;
		case 0:
		{
			_0023_003DzmZNu_pI_003D++;
			_0023_003DqO9TEqm6qa7P6EAiT4EUfxPMmQ3zciexxzbCdgC_0024aWjI_003D obj2 = new _0023_003DqO9TEqm6qa7P6EAiT4EUfxPMmQ3zciexxzbCdgC_0024aWjI_003D();
			obj2._0023_003Dztd1x26phzNsG9_0024A6yOM1Xdc_003D(_0023_003Dzq80RbjQ_003D._0023_003DzYxwpE779ciLA4_0024V5CIlDrqo_003D());
			return obj2;
		}
		case 2:
		case 6:
			_0023_003DzmZNu_pI_003D += 4u;
			return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
		case 10:
			_0023_003DzmZNu_pI_003D += 8u;
			return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzp_l1PqLcSGPUHQ75iBvbWgkFJ8MX42NzxbPuGSryMcYN());
		case 3:
		case 7:
		{
			_0023_003DzmZNu_pI_003D++;
			_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D obj7 = new _0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D();
			obj7._0023_003DzyR8GDbkhAz7Y4w4fayxJEYtmvNm4(_0023_003Dzq80RbjQ_003D._0023_003Dzgie8dX3wQlY8J8uAg8gyr39CXYW8L0PGHZYb0G4_003D());
			return obj7;
		}
		case 5:
		case 12:
		{
			_0023_003DzmZNu_pI_003D += 2u;
			_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D obj6 = new _0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D();
			obj6._0023_003DzTEKOsEto13xRTg3_0024_Q_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003DzZghloTfY5RAcAlQwKAN5HyUxVKvn1iSd9jMNJ_3h2xTY());
			return obj6;
		}
		case 4:
		{
			_0023_003DzmZNu_pI_003D += 4u;
			_0023_003Dqn9vzRhA2ElEc1m7zxcM2lTvbOR_0024ZQ0P7_0024LxZWQMZVZ4_003D obj5 = new _0023_003Dqn9vzRhA2ElEc1m7zxcM2lTvbOR_0024ZQ0P7_0024LxZWQMZVZ4_003D();
			obj5._0023_003DzNSOwB_0024k4cBxS8HwSUR4LZBOphY9Km47xmQ_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003DzIbBE7KhlxKoTwpSpq6mcrXxuMo3nfqpAnbrSQUpbMyP3());
			return obj5;
		}
		case 8:
		{
			_0023_003DzmZNu_pI_003D += 8u;
			_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj4 = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
			obj4._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(_0023_003Dzq80RbjQ_003D._0023_003DzOhiaokG9hmf1w4nBvB5tb_vQVupd());
			return obj4;
		}
		case 1:
		{
			_0023_003DzmZNu_pI_003D += 4u;
			_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D obj3 = new _0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D();
			obj3._0023_003DzvymomgpVz45_0024_0024_BmRzGYpPc_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzxwm21_nmp2f5Ms_0024F4Fcqvf9_0024L1SjCRntwfAJwq4_003D());
			return obj3;
		}
		case 9:
		{
			int num = _0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D();
			_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D[] array = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			}
			_0023_003DzmZNu_pI_003D += (uint)((num + 1) * 4);
			_0023_003Dq7Y_X1LJ_wwdl9r12hZAPJQpn7cOzytFyKfE_0024WrTLigc_003D obj = new _0023_003Dq7Y_X1LJ_wwdl9r12hZAPJQpn7cOzytFyKfE_0024WrTLigc_003D();
			obj._0023_003Dzx6Cy9POBb2O5o9K6QwUi_yapCuB_0024R_0024hYM6kuXhU_003D(array);
			return obj;
		}
		default:
			throw new Exception(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524665));
		}
	}

	private static void _0023_003DzY_0024sertBx41sDalAtlUoybHc_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(2);
	}

	private static void _0023_003DzdmqLpr_0024W9xsoM7oKYa3FRz7mfDOw(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003Dzbnzi9JArhzTjZqiOIA_003D_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private int _0023_003DzWy1FBpPadXE02j_00248_k6mgGP1UU27()
	{
		return 1447513948;
	}

	private void _0023_003DzcHX5J0_BxaBvebV44eNBFeg_003D(int _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzxhN3bEo_003D[_0023_003Dzq80RbjQ_003D]._0023_003Dz048eNPCCLNNmZFIiW7pSmsLry714y0ieZoaY0obA2vjaWKhL_0024Ft9HlWoFrDEcPmBFkeHbqme9OIi());
	}

	private bool _0023_003DzQ39MwbzcCZ2kCX7d7E83rYI_003D(Type _0023_003Dzq80RbjQ_003D, _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DzZzVr6_0024U_003D, out int _0023_003Dz7hRN5Rg_003D)
	{
		_0023_003Dz7hRN5Rg_003D = 0;
		_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D _0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2 = (_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D)_0023_003DzZzVr6_0024U_003D._0023_003DzqZLvK7FhPMHAcJUCHWtKXWMzPckK();
		if (_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003DzFkSVnloSTgfB_TuxgOff5OemKRrwlKQflVohFlutimzk(_0023_003Dzq80RbjQ_003D).IsGenericParameter)
		{
			if (_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2 != null && !_0023_003DqluIhkfU76QJuQlzV2eZsN4Ebmdv0TWciB3lsqzyb_Go_003D2._0023_003DzQGR6O7hgteLiiE9slKiYbrg_003D())
			{
				return false;
			}
			return true;
		}
		Type type = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DzZzVr6_0024U_003D._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U(), _0023_003DzZzVr6_0024U_003D: false);
		if (!_0023_003DquMh_RbFIfA6Odscsrwq4H3C3B_PN5aFV9LjpwjudwDo_003D._0023_003Dz8Yz0iugz2KNfUBsFAIB8ZltgiORJ(_0023_003Dzq80RbjQ_003D, type, out _0023_003Dz7hRN5Rg_003D))
		{
			return false;
		}
		return true;
	}

	private static void _0023_003Dzl8NHajHglnaFUOS_00245XF8F8nFLYYL(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzGK5WKeBvR9cWZYGHWewhHmFceBV2(_0023_003Dzq80RbjQ_003D: true, _0023_003DzZzVr6_0024U_003D: false);
	}

	private static string _0023_003DzW9inGhxh3D5B3aHEojMGBQ4wP7uXJo8QviUuDOA_003D(string _0023_003Dzq80RbjQ_003D, string _0023_003DzZzVr6_0024U_003D)
	{
		string fullName = typeof(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D).Assembly.FullName;
		return _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526214) + _0023_003Dzq80RbjQ_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526228) + _0023_003DzZzVr6_0024U_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526306) + Environment.NewLine + Environment.NewLine + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526325) + fullName + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526274);
	}

	private void _0023_003DzmJcTjZMU20gnWIs5PUtcynYB9r4_0024tmr4dl3qxi0_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzV2E0EoqrR8a7GE1oX_kC97_00244eG4fhAMhmw_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2, _0023_003Dzq80RbjQ_003D));
	}

	[_0023_003Dq3pUobS7gRU4PocUwxB9HRYowgS7sMsjW9FDO02FW3vk_003D(2)]
	private bool _0023_003DzAvTsrJ7k_yxiFHYcHDZamLs_003D([_0023_003Dqhu8iWDnFsbbcNK8gRnbmYe9RgdJ2bjuG2Syc8f8xrvQ_003D(1)] MethodBase _0023_003Dzq80RbjQ_003D, object _0023_003DzZzVr6_0024U_003D, ref object _0023_003Dz7hRN5Rg_003D, [_0023_003Dqhu8iWDnFsbbcNK8gRnbmYe9RgdJ2bjuG2Syc8f8xrvQ_003D(new byte[] { 1, 2 })] object[] _0023_003DzcbLoSrg_003D)
	{
		if (!_0023_003Dzq80RbjQ_003D.IsStatic && _0023_003DzZzVr6_0024U_003D != null && _0023_003Dzq80RbjQ_003D.Name.Equals(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525204), StringComparison.Ordinal) && _0023_003Dzq80RbjQ_003D is MethodInfo { ReturnType: var returnType } && returnType.IsByRef)
		{
			Type elementType = returnType.GetElementType();
			int num = _0023_003DzcbLoSrg_003D.Length;
			if (num >= 1 && _0023_003DzcbLoSrg_003D[0] is int)
			{
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = (int)_0023_003DzcbLoSrg_003D[i];
				}
				_0023_003Dqqr0fJcmNHD_002426q7CfYl3TDteoEhaDlctRYhFuZN6t7U_003D obj = new _0023_003Dqqr0fJcmNHD_002426q7CfYl3TDteoEhaDlctRYhFuZN6t7U_003D();
				obj._0023_003Dze41w1f1Q2iLsbo4_00243SAbj2yvMVn9syHKFGz4tGhRvt9N((Array)_0023_003DzZzVr6_0024U_003D);
				obj._0023_003DzW40AD9bLX_0024ppegPZq_8tAR9yw0l8Rpqd_0024w_003D_003D(array);
				obj._0023_003DzSEy5G4lo_0024XBVGSpmZFEUg0fWCELZ(elementType);
				_0023_003Dz7hRN5Rg_003D = obj;
				return true;
			}
		}
		return false;
	}

	private static void _0023_003DzsB0uw3YHhayEgwOo_4Bhl016q0YpPLZtjA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
	}

	private static void _0023_003DzhA7cDijV2dhaqZcCOj2ifGU_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003DzTrgTcTMfYB_0024_0024FAHVo8gUnnYGCc_0024m5Xkirg_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2) ? 1 : 0));
	}

	private void _0023_003DzwwYHocafLvZVCJjHxDwZ0C6f7DiZFaT1uyucXN4_003D(int _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzxhN3bEo_003D[_0023_003Dzq80RbjQ_003D]._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
	}

	private static void _0023_003DzFszEoaomGCsh0sl4bYgVb2dIBlB5o1x0soZwYaaEI_yZ(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D(), type);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003Dz05CWvVBsjB3cxobQmNkHCwE5n_QA(type);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
	}

	private static void _0023_003DzuyJq7QZQinGewHRepirRBVWqE7HnpLj3oYlJEJds7cb_(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		FieldInfo fieldInfo = _0023_003Dzq80RbjQ_003D._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D obj = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 as _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D;
		object obj2 = ((_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 == null) ? _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() : _0023_003Dzq80RbjQ_003D._0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2)._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
		if (obj2 == null)
		{
			throw new NullReferenceException();
		}
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D(), fieldInfo.FieldType);
		fieldInfo.SetValue(obj2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
		if (_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 != null && obj2 != null && obj2.GetType().IsValueType)
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj2, null));
		}
	}

	private static Exception _0023_003Dz2CWZAMl0t70uDVrlr4_2WfGvp5v7gn0HzjLw36Y_003D(string _0023_003Dzq80RbjQ_003D, string _0023_003DzZzVr6_0024U_003D)
	{
		return new FieldAccessException(_0023_003DzW9inGhxh3D5B3aHEojMGBQ4wP7uXJo8QviUuDOA_003D(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526647) + _0023_003Dzq80RbjQ_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526611), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355524752) + _0023_003DzZzVr6_0024U_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526611)));
	}

	private static void _0023_003Dzkn2jUPILJecZ16C5aVCvagM_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		FieldInfo fieldInfo = _0023_003Dzq80RbjQ_003D._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D(), fieldInfo.FieldType);
		fieldInfo.SetValue(null, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
	}

	private static void _0023_003DzGmihiS8CEEt_0024kkjojlyPx0AKzyrP(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		object obj = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		long num = _0023_003Dzq80RbjQ_003D._0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5();
		Array array = (Array)_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(int))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(int));
			((int[])array)[num] = (int)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType == typeof(uint))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(uint));
			((uint[])array)[num] = (uint)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(elementType, obj, num, array);
		}
		else
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(typeof(int), obj, num, array);
		}
	}

	private void _0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(Type _0023_003Dzq80RbjQ_003D, object _0023_003DzZzVr6_0024U_003D, long _0023_003Dz7hRN5Rg_003D, Array _0023_003DzcbLoSrg_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(_0023_003DzZzVr6_0024U_003D, _0023_003Dzq80RbjQ_003D);
		_0023_003DzcbLoSrg_003D.SetValue(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D(), _0023_003Dz7hRN5Rg_003D);
	}

	private void _0023_003DzaF2qAspOkBxepypZ_0024dOK8TK80mH6(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (!_0023_003Dzq80RbjQ_003D) ? ((ushort)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()) : checked((ushort)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
			13 => (!_0023_003Dzq80RbjQ_003D) ? ((ushort)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()) : checked((ushort)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()), 
			19 => (!_0023_003Dzq80RbjQ_003D) ? ((ushort)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())) : checked((ushort)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => (!_0023_003Dzq80RbjQ_003D) ? ((ushort)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()) : checked((ushort)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((ushort)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((ushort)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())) : ((!_0023_003Dzq80RbjQ_003D) ? ((ushort)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((ushort)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())), 
			20 => (UIntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((ushort)(ulong)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()) : checked((ushort)(ulong)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D())) : ((!_0023_003Dzq80RbjQ_003D) ? ((ushort)(uint)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()) : checked((ushort)(uint)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D())), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private static void _0023_003Dz_0024MC_3CMRQfoMuvD4bJN1b7tfTyeiADnLPTNpcXcpD0h7(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzZzVr6_0024U_003D);
	}

	private _0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D[] _0023_003DzkestBVIXFQ3V4VcoxXKVMva7qhEP9qc1N6xk_0024OVRXoT6(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D[] array = new _0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D[_0023_003Dzq80RbjQ_003D._0023_003DzAT5B_0024KrVlUL38D8pF9i1EEk_003D()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003Dz9CN_7bwQXcC3D0ZW_0024jrgd_DCT_0024HU5u0mfw_003D_003D(_0023_003Dzq80RbjQ_003D);
		}
		return array;
	}

	private static void _0023_003DzeSSs5PdoREHhV6hqprU_0024kmf_0024VDljACY4y0Sw7H8_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		bool flag = false;
		if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() != 0, 
			13 => ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() != 0, 
			0 => ((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr() != IntPtr.Zero, 
			20 => ((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D() != UIntPtr.Zero, 
			19 => Convert.ToBoolean(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			7 => ((_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzvPsFwllF9YUejQF68VzjbUs4hENNmXLLhEVR500jpyde() != null, 
			_ => _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() != null, 
		})
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private _0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D _0023_003DzQTl7RhG9D_xvrZNM8TFjUM0_003D(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D obj = new _0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D();
		obj._0023_003DzwrTIxM_vKXA2O3KJ_KMBbBLKZfIm48TZzGdfJ_o_003D(_0023_003DzkestBVIXFQ3V4VcoxXKVMva7qhEP9qc1N6xk_0024OVRXoT6(_0023_003Dzq80RbjQ_003D));
		obj._0023_003DziahRvynn7OVl6aT2s6ZfIm7_00240a7u(_0023_003DzYAMD8L5Q_0024i4SLp0naHwJXiLKJqr1Clws_vttK48_003D(_0023_003Dzq80RbjQ_003D));
		obj._0023_003DzTHgH4bWcnc_0024ofUc8EJAozc8_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
		obj._0023_003Dzjrm7_0024bALs1XK63wEMe_0024HMUdEHYq_Cw6eh1ptvdI_003D(_0023_003Dzq80RbjQ_003D._0023_003Dzgie8dX3wQlY8J8uAg8gyr39CXYW8L0PGHZYb0G4_003D());
		obj._0023_003Dzb3uNpT_0024ERzU3aiQw4M2ijI_0024Lo_ze_0024Ao4nGn_0024pWk_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
		obj._0023_003DzTUxp7dkkfU6dcDBTqlJ5_0024qDH5K07(_0023_003Dzq80RbjQ_003D._0023_003DzXDeO0ZPZHx72cYMmETLMlaj5qFonnk1sTAhKpy0_003D());
		return obj;
	}

	private static void _0023_003DzSQrapK17x7JWrGhbpH57ap4Z99NPQ1Pf9w_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DztP7PBX2bGr9qR_8NV2HJNQoKwjzAZkYaog_003D_003D(((_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D());
	}

	private static void _0023_003DzIm0kiy3caSAD97mxCw_0024ASnmYenQCuzZPiw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dzq80RbjQ_003D._0023_003DzHM_5K2mtFT6DEcu86Qk9vLSKEKOX(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2));
	}

	private static void _0023_003DzJtWQe_1UdTLJHnDeeFXaLLT7W0egraj_CQ_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true);
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(type);
	}

	private void _0023_003DzAOrwStx8zJJYrAkKfVBbAnY_003D()
	{
		if (m__0023_003DzAXvW_0024Kw_003D._0023_003DzkElAVltokaRsq2qyltgIIyTvyqwv())
		{
			Type type = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(m__0023_003DzAXvW_0024Kw_003D._0023_003DzeFmYRYvMy4A0IhX6fIHDEUwm_00242cyzi_3XQ_003D_003D(), _0023_003DzZzVr6_0024U_003D: false);
			if (type != null)
			{
				RuntimeHelpers.RunClassConstructor(type.TypeHandle);
			}
		}
	}

	private static void _0023_003DzwtxLx9QmzygaeGbIKHDONbje65Te(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
	}

	private static void _0023_003DzFcXtJPINKhK7aA4O3WZrWno3X9CPq9KVWA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		Thread.MemoryBarrier();
	}

	private static void _0023_003DzrW2_00246d_00244D72Ky_0024RfugLzfvZ31ut9jcYTCoX_H9Q_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		object obj = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		long num = _0023_003Dzq80RbjQ_003D._0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5();
		Array array = (Array)_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(short))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(short));
			((short[])array)[num] = (short)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType == typeof(ushort))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(ushort));
			((ushort[])array)[num] = (ushort)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType == typeof(char))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(char));
			((char[])array)[num] = (char)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(elementType, obj, num, array);
		}
		else
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(typeof(short), obj, num, array);
		}
	}

	private static void _0023_003DzaUSh0Z6j8Po5vDttTO9yqJbgSJJIrhC_0024Ig_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D());
	}

	private static void _0023_003DzenLkeMckiNQ5N9KoMJWkpDiqaXeZbRMIKm4ik_s_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzZzVr6_0024U_003D);
	}

	private static void _0023_003DzXmmvxQZKicxubzh858fq_0024bHmEDwaA3jdYw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		FieldInfo fieldInfo = _0023_003Dzq80RbjQ_003D._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2)
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2);
		}
		object obj = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		if (obj == null)
		{
			throw new NullReferenceException();
		}
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(fieldInfo.GetValue(obj), fieldInfo.FieldType));
	}

	private static void _0023_003DzM6joOyKYQHZabFhqf8JhjF4uafeP4c7hIg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzFPuHHafPEG92XM_0024gYatOtrw_0024UnVJ(_0023_003Dzq80RbjQ_003D: true, _0023_003DzZzVr6_0024U_003D: false);
	}

	private void _0023_003DzJSi0qgGb_0024sI99c5pAmnGAJs_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dz6qpmpu8_00246GSUBpQjDrynoGJugrDNnltEnnGK9oQmwM5l(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2, _0023_003Dzq80RbjQ_003D));
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzboxNZFRdW0op1ElE6xsFU1pvOx4MM8UJGzfZV2xS57hX(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
			_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D();
			obj._0023_003DzYFXWifrsG3fRPmCVbL0axdi3r_0024DS(~num);
			return obj;
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			long num2 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D obj2 = new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D();
			obj2._0023_003DzgAt1mNmNuxVumV4R3YlFedE_003D(~num2);
			return obj2;
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(~Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D()));
			}
			return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(~Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D()));
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzPB_64wVNmW777KYNNT1k2AzHbIaN(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
	}

	public static void _0023_003Dz_VJwijA1TwxWrhdE2raGRYuDu5D4F1Aq3w_003D_003D<T>(T[] _0023_003Dzq80RbjQ_003D, Comparison<T> _0023_003DzZzVr6_0024U_003D)
	{
		KeyValuePair<int, T>[] array = new KeyValuePair<int, T>[_0023_003Dzq80RbjQ_003D.Length];
		for (int i = 0; i < _0023_003Dzq80RbjQ_003D.Length; i++)
		{
			array[i] = new KeyValuePair<int, T>(i, _0023_003Dzq80RbjQ_003D[i]);
		}
		Array.Sort(array, _0023_003Dzq80RbjQ_003D, new _0023_003DzAXvW_0024Kw_003D<T>(_0023_003DzZzVr6_0024U_003D));
	}

	private void _0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(Type _0023_003Dzq80RbjQ_003D)
	{
		long index = _0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5();
		Array array = (Array)_0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(array.GetValue(index), _0023_003Dzq80RbjQ_003D));
	}

	private void _0023_003DztP7PBX2bGr9qR_8NV2HJNQoKwjzAZkYaog_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(this.m__0023_003Dz5QkdKZk_003D[_0023_003Dzq80RbjQ_003D]._0023_003Dz048eNPCCLNNmZFIiW7pSmsLry714y0ieZoaY0obA2vjaWKhL_0024Ft9HlWoFrDEcPmBFkeHbqme9OIi());
	}

	private static void _0023_003DzOXx0tBU_9sOCFRhlX4ifr6TQtEI6(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzPJCaFZeVnLaddax8TLiglvsSl8LBjm32MPmYr7H1LVhl(_0023_003Dzq80RbjQ_003D: false);
	}

	private static _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzzMM48rKH687TiN9ZyUxHYyI_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D)
	{
		if (!_0023_003Dz7hRN5Rg_003D)
		{
			long num = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			long num2 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
			return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num / num2);
		}
		long num3 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		ulong num4 = (ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D((long)((ulong)num3 / num4));
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzEuJaDpmLytpSBTEoXDVyq_o_003D()
	{
		return _0023_003Dz4A3Alm0_003D ?? _0023_003Dz349QwgY_003D.Peek();
	}

	private static void _0023_003DzCtFDk2poPIRFXduyFUR1gIFaeBe4(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzNYr9S6dMDXOAp_0024ksZwcj62_edwiI38qlPAnnxDs_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private void _0023_003DzPHiIf3KRk8uGovgzQUP7QfXxitAzyyw_00241A_003D_003D()
	{
	}

	private void _0023_003DzClvFpnBhopC5aAjD7K31UNUSndWj_0024t_00248Ig_003D_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (int)((!_0023_003Dzq80RbjQ_003D) ? ((ushort)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()) : checked((uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D())), 
			13 => (int)((!_0023_003Dzq80RbjQ_003D) ? ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() : checked((uint)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO())), 
			19 => (int)((!_0023_003Dzq80RbjQ_003D) ? Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()) : checked((uint)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()))), 
			8 => (int)((!_0023_003Dzq80RbjQ_003D) ? ((uint)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()) : checked((uint)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D())), 
			0 => (int)((IntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((uint)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())) : ((!_0023_003Dzq80RbjQ_003D) ? ((int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((int)checked((uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())))), 
			20 => (int)((UIntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((ulong)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()) : checked((uint)(ulong)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D())) : ((!_0023_003Dzq80RbjQ_003D) ? ((uint)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()) : ((uint)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()))), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DziqxPRZhHz6K5QX9uIRB_0024_o4eIiLe()
	{
		this.m__0023_003Dzkl7CXTo_003D = _0023_003DzmZNu_pI_003D;
		int key = _0023_003DzLi0XoCY_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D();
		_0023_003DzmZNu_pI_003D += 4u;
		_0023_003Dz61IPlm0_003D.TryGetValue(key, out var value);
		value._0023_003DzZzVr6_0024U_003D(this, _0023_003Dzjn_lOGw1LY78GVWwkyAJMw9qyzH17GIGlFoWNP8_003D(_0023_003DzLi0XoCY_003D, value._0023_003Dzq80RbjQ_003D));
	}

	private static void _0023_003DzGcd7mcr2H3A1MSVV7rqVVmf4oQOU(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D();
		obj._0023_003DzYFXWifrsG3fRPmCVbL0axdi3r_0024DS(_0023_003Dz_kQL1hdRMpr2IqQAhsGNFwQ_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2) ? 1 : 0);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private void _0023_003Dz5OMzZfMew032gXEU_00246l23UxgtnrcwVndYPIzBd7EUgHG(Stream _0023_003Dzq80RbjQ_003D, string _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DzL1lWLjrLTywcRSsj75BhRk4ld4f6(_0023_003Dzq80RbjQ_003D, 0L, _0023_003DzZzVr6_0024U_003D);
	}

	private static void _0023_003DzDKo_00245wpyfHKGxGJ6LN9jjfQ_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => (long)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			8 => (long)checked((ulong)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzulaHX73aw6pB0iqB9WTs0IBzl93L()
	{
		_0023_003DzrhEG9Ic_003D = true;
	}

	private static void _0023_003Dz_7PRtRA8l8tq7_UE7zHO83nFSqPH(object _0023_003Dzq80RbjQ_003D)
	{
		throw _0023_003Dzq80RbjQ_003D;
	}

	private static bool _0023_003Dz_kQL1hdRMpr2IqQAhsGNFwQ_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		bool result = false;
		switch (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D())
		{
		case 1:
			result = ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 19) ? ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 7 || _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() != null) ? (((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() == ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()) : (((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() == 0)) : (((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D() == Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())));
			break;
		case 13:
			result = ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 19) ? ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 7 || _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() != null) ? (((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() == ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()) : (((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() == 0)) : (((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() == Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())));
			break;
		case 0:
			result = ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 7 && _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() == null) ? (((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr() == IntPtr.Zero) : ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 1) ? ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 13) ? (((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr() == ((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : (((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr() == new IntPtr(((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()))) : (((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr() == new IntPtr(((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()))));
			break;
		case 20:
			result = ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 7 && _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() == null) ? (((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D() == UIntPtr.Zero) : ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 1) ? ((_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 13) ? (((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D() == ((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()) : (((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D() == new UIntPtr((ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()))) : (((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D() == new UIntPtr((uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()))));
			break;
		case 7:
			result = _0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() == _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
			break;
		case 25:
			result = (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 7 || _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() != null) && ((_0023_003DqIx7Es0991cC2X_00245IB4D_00241cF3l7JfNAZfP4L5w3s6Cp4_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz0JnUB3O4xCsib39IP97QRlnfMWXo() == ((_0023_003DqIx7Es0991cC2X_00245IB4D_00241cF3l7JfNAZfP4L5w3s6Cp4_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz0JnUB3O4xCsib39IP97QRlnfMWXo();
			break;
		case 19:
		{
			_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D _0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D2 = (_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dzq80RbjQ_003D;
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				result = Convert.ToInt64(_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D2._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()) == Convert.ToInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D());
			}
			else if (_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D2._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D() == null)
			{
				result = _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() == null;
			}
			else if (_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() != null)
			{
				result = Convert.ToInt64(_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D2._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()) == Convert.ToInt64(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
			}
			break;
		}
		case 8:
		{
			double d = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			double num = ((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D();
			result = !double.IsNaN(d) && !double.IsNaN(num) && d.Equals(num);
			break;
		}
		case 11:
		case 24:
		{
			_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D obj3 = (_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D)_0023_003Dzq80RbjQ_003D;
			_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D _0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D2 = (_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D)_0023_003DzZzVr6_0024U_003D;
			result = obj3._0023_003DzTFthhbQEjTPcHG7dZ1_0024Exp_0024OPYZcsejKlFiDcuAJemNDDT7MTjTWO1msEaKe1yxWsJ8n_00249gN1VvF4HwIhQ_003D_003D(_0023_003Dq83txtBmFlxymCNA_sU7I_0024RhZlYvEfVMK56DgfXWXRfM_003D2);
			break;
		}
		case 18:
		{
			_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2 = (_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D)_0023_003Dzq80RbjQ_003D;
			_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D3 = (_0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D)_0023_003DzZzVr6_0024U_003D;
			result = _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2._0023_003DzcN50AjqFb2YG4rc00V_scr8LiJfHGEg8oQ_003D_003D() == _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D3._0023_003DzcN50AjqFb2YG4rc00V_scr8LiJfHGEg8oQ_003D_003D() && _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D2._0023_003DzVi5MXbrt8BXDXKmnYfbx7oiBSVGN() == _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D3._0023_003DzVi5MXbrt8BXDXKmnYfbx7oiBSVGN();
			break;
		}
		case 23:
		{
			_0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D obj2 = (_0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D)_0023_003Dzq80RbjQ_003D;
			_0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D _0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D2 = (_0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D)_0023_003DzZzVr6_0024U_003D;
			result = obj2._0023_003DzyaPG31LUW61wDbz6or_0024_wKhVLOakW65jTE_0024juPit4kmE() == _0023_003Dqkfr58uYm3J6TSax_00245eZLimaNq9oWEu4RusjjfaSMAcc_003D2._0023_003DzyaPG31LUW61wDbz6or_0024_wKhVLOakW65jTE_0024juPit4kmE();
			break;
		}
		case 2:
		{
			_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D obj = (_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D)_0023_003Dzq80RbjQ_003D;
			result = _0023_003Dz_kQL1hdRMpr2IqQAhsGNFwQ_003D(((_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzsg16MNLOFrIol9kAkfDFT25y5dmq(), obj._0023_003Dzsg16MNLOFrIol9kAkfDFT25y5dmq());
			break;
		}
		default:
			result = _0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() == _0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
			break;
		}
		return result;
	}

	private static void _0023_003Dzrzqsz5imbzLW0R0WptNJZhnZ_URMMkWWp1X35nQFblXU(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(1);
	}

	private static void _0023_003DzAksaE4Xc4YfDxx7vswDFbNlc8VocFe5Gftg6yzE_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(_0023_003Dzvup4kCA_003D);
	}

	private static void _0023_003DzUMM4RO1qe5H0a0TdRxrAun9q1Yk0yChCBZoI4_002469eOgV(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
	}

	private static void _0023_003DzreUbpGkRgf9zkfyXCTZxXuA_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D2 = (_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (double.IsNaN(_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D2._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()) || double.IsInfinity(_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D2._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()))
		{
			throw new OverflowException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525848));
		}
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D2);
	}

	private static void _0023_003DzXJ69IQ8Q1qArH0EnefE328Q_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzOErZpVZ3V1MaU8xw4f6j_7A_003D(typeof(short));
	}

	private static void _0023_003DzthNSWs62A_0024hJpgmSNMaAqGM_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003DzEuJaDpmLytpSBTEoXDVyq_o_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003Dz048eNPCCLNNmZFIiW7pSmsLry714y0ieZoaY0obA2vjaWKhL_0024Ft9HlWoFrDEcPmBFkeHbqme9OIi());
	}

	private static void _0023_003Dz6UXvQF6n_0024ZPRFiZqqVjEhS3zQB1aTvSu5g_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzMw7_0024EO1zJL4MyDs5_00243DxjS_NGViU1FlGfkRm6d8_003D(null, num);
	}

	private static void _0023_003Dz1U_RBk3JnoEBw6QBa93gVavPvCWc(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (_0023_003DzbLKMaSlao_0024AFofVihsr7cM7_DlQeb2LkIgPm0rY_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private static void _0023_003DzOaeRj_0024p0QA9eiZHkEAQ_00243Jw_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzZzVr6_0024U_003D);
	}

	private static void _0023_003DzMwgGnbGM047CRJvhKd4u2q36nj2H(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		object obj = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		long num = _0023_003Dzq80RbjQ_003D._0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5();
		Array array = (Array)_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(sbyte))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(sbyte));
			((sbyte[])array)[num] = (sbyte)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType == typeof(byte))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(byte));
			((byte[])array)[num] = (byte)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType == typeof(bool))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(bool));
			((bool[])array)[num] = (bool)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D4._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(elementType, obj, num, array);
		}
		else
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(typeof(sbyte), obj, num, array);
		}
	}

	private void _0023_003DzsfG3IFcTKHi4W67Nrg_003D_003D(Type _0023_003Dzq80RbjQ_003D)
	{
		object obj = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		long num = _0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5();
		Array array = (Array)_0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		_0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(_0023_003Dzq80RbjQ_003D, obj, num, array);
	}

	private static void _0023_003DzGVoJlTJe8jBu0NafbQhvFX8_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2 = (_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D;
		MethodBase methodBase = _0023_003Dzq80RbjQ_003D._0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D());
		Type declaringType = methodBase.DeclaringType;
		Type type = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType();
		ParameterInfo[] parameters = methodBase.GetParameters();
		Type[] array = new Type[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		MethodBase methodBase2 = null;
		Type type2 = type;
		while (type2 != null && type2 != declaringType)
		{
			MethodInfo method = type2.GetMethod(methodBase.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.ExactBinding, null, CallingConventions.Any, array, null);
			if (method != null && method.GetBaseDefinition() == methodBase)
			{
				methodBase2 = method;
				break;
			}
			type2 = type2.BaseType;
		}
		if (methodBase2 == null)
		{
			methodBase2 = methodBase;
		}
		_0023_003Dqqr0fJcmNHD_002426q7CfYl3TIKslsTynyI2_0024uUSOUtw4jk_003D obj = new _0023_003Dqqr0fJcmNHD_002426q7CfYl3TIKslsTynyI2_0024uUSOUtw4jk_003D();
		obj._0023_003DzqC7E3Vn82TFeKA4OyRAe_dA_003D(methodBase2);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzyjHfiEuMPYll0RDob6zl0keHOmlFMAbbcQMHClc_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				int num2 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				return new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(num << num2);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzyjHfiEuMPYll0RDob6zl0keHOmlFMAbbcQMHClc_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())));
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 13)
		{
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 1)
			{
				long num3 = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dzq80RbjQ_003D)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
				int num4 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
				return new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(num3 << num4);
			}
			if (_0023_003DzZzVr6_0024U_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
			{
				return _0023_003DzyjHfiEuMPYll0RDob6zl0keHOmlFMAbbcQMHClc_003D(_0023_003Dzq80RbjQ_003D, new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003DzZzVr6_0024U_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())));
			}
		}
		if (_0023_003Dzq80RbjQ_003D._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzyjHfiEuMPYll0RDob6zl0keHOmlFMAbbcQMHClc_003D(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(Convert.ToInt64(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D);
			}
			return _0023_003DzyjHfiEuMPYll0RDob6zl0keHOmlFMAbbcQMHClc_003D(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(Convert.ToInt32(_0023_003Dzq80RbjQ_003D._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D())), _0023_003DzZzVr6_0024U_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003Dz_wIsa1VOaxJ6xCR82CvMzXY_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzNYr9S6dMDXOAp_0024ksZwcj62_edwiI38qlPAnnxDs_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	private _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] _0023_003Dzi3BtLz9ca4emEMUSHvZTuImhjfuptWcGJnnAKBg_003D()
	{
		_0023_003DqymTLvf3BrhQp_00245V_LtgjgTjxJNwJbW7z4ld0XpHCSus_003D[] array = m__0023_003DzAXvW_0024Kw_003D._0023_003Dzgb2ZZj8A1binB63joCxVQKFQYtxVh6D6mI7ZOBW4cZci();
		int num = array.Length;
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[] array2 = new _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(array[i]._0023_003DzlbIYnIbYKV4WKjxn0CXXm7s_003D(), _0023_003DzZzVr6_0024U_003D: false));
		}
		return array2;
	}

	private static void _0023_003DzCiBvWws6fxjLDJPoAM_H_lzwSqO7(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (_0023_003Dz_kQL1hdRMpr2IqQAhsGNFwQ_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private bool _0023_003Dz_ugnXtkWl3OOwSfSYMNS4_0024OF3SedPTFK5V1IrS4_003D()
	{
		if (_0023_003Dz4A3Alm0_003D == null)
		{
			return _0023_003Dz349QwgY_003D.Count != 0;
		}
		return true;
	}

	private void _0023_003DzkO3PJHhv6CGcBbCGk3WpSnPpLNzMif3JCQ_003D_003D(MemberInfo _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003DzMPgRDeEg4eaPMM9e6Yhl2NjUmZY6snRvMqp3h_M_003D() || m__0023_003DzAXvW_0024Kw_003D._0023_003DzJ6sEeU_QCXNQIL1Xb7GUYNIEmzb2j9fH1ej57ljYuZU_0024())
		{
			return;
		}
		bool flag = false;
		Assembly assembly = typeof(SecurityCriticalAttribute).Assembly;
		MemberInfo memberInfo = _0023_003Dzq80RbjQ_003D;
		while (memberInfo != null)
		{
			object[] customAttributes = memberInfo.GetCustomAttributes(inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				Type type = customAttributes[i].GetType();
				if (type.Assembly == assembly)
				{
					string fullName = type.FullName;
					if (_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526415).Equals(fullName, StringComparison.Ordinal))
					{
						flag = true;
						goto end_IL_009d;
					}
					if (_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526527).Equals(fullName, StringComparison.Ordinal))
					{
						goto end_IL_009d;
					}
				}
			}
			memberInfo = memberInfo.DeclaringType;
			continue;
			end_IL_009d:
			break;
		}
		if (flag)
		{
			if (_0023_003Dzq80RbjQ_003D is MethodBase)
			{
				string text = _0023_003DzjuBfKGhes_00246QlFOfOT_0024DNDV7kkerd8UbcOr50y0_003D((MethodBase)_0023_003Dzq80RbjQ_003D);
				throw _0023_003DzaWqfW1XbxjFJHEqe2NyQ60ah4dXEb3g5kWwI2p2LZ38J(_0023_003DzJgQM5CjFJ0TIbvJ5cbmQCTKZ_dmF(m__0023_003DzAXvW_0024Kw_003D), text);
			}
			if (_0023_003Dzq80RbjQ_003D is FieldInfo)
			{
				string text2 = _0023_003Dzq80RbjQ_003D.DeclaringType.FullName + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526571) + _0023_003Dzq80RbjQ_003D.Name;
				throw _0023_003Dz2CWZAMl0t70uDVrlr4_2WfGvp5v7gn0HzjLw36Y_003D(_0023_003DzJgQM5CjFJ0TIbvJ5cbmQCTKZ_dmF(m__0023_003DzAXvW_0024Kw_003D), text2);
			}
			if (_0023_003Dzq80RbjQ_003D is Type)
			{
				string fullName2 = ((Type)_0023_003Dzq80RbjQ_003D).FullName;
				throw _0023_003DzhBmkzxy2X2zwT5BM8ZFsm3NEzCEG(_0023_003DzJgQM5CjFJ0TIbvJ5cbmQCTKZ_dmF(m__0023_003DzAXvW_0024Kw_003D), fullName2);
			}
			throw new SecurityException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526563));
		}
	}

	private void _0023_003DzjgzcRmU7k1760WeKvTJ3zwo8pNNmtm7_Aux4aCY_003D()
	{
		_0023_003Dz_VJwijA1TwxWrhdE2raGRYuDu5D4F1Aq3w_003D_003D(_0023_003DzF6BhvwY_003D, (_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2, _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D3) => (_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw() == _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D3._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw()) ? _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D3._0023_003DzPQUNNKOX2HDwNDSQ4BUJN_esq0Wmy5BYBg_003D_003D().CompareTo(_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003DzPQUNNKOX2HDwNDSQ4BUJN_esq0Wmy5BYBg_003D_003D()) : _0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D2._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw().CompareTo(_0023_003DqtqC28f9aopCFosrw6MIZci4iJiVYJxODnzE_0024oOUBgdk_003D3._0023_003DzcmYAH1_0024kgTZIsm37rJAwkR2aPGOw()));
	}

	private void _0023_003DzUcfwXkVt2OiFJi6klqPNUOc_003D(bool _0023_003Dzq80RbjQ_003D, bool _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003DzQdjeUYEe9Gd_kyvTmQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D));
	}

	private static void _0023_003DzzuMCglfRO3MHdQFVKPssCLjezarL2IGMlw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzK6lBjrm1Y8KqG_Zbf6StalQ_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	private static void _0023_003Dz8Ho0xTU083HsJyiwtb837CygAQdNosDbbTY2xrs_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		FieldInfo fieldInfo = _0023_003Dzq80RbjQ_003D._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num);
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 as _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D;
		object obj = ((_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2 == null) ? _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D() : _0023_003Dzq80RbjQ_003D._0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(_0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2)._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003DqVcjta0_jSHC_KNEfba3YbmuD_0024UtLsMz5yO_0024_wvFwftc_003D(fieldInfo, obj, _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D2));
	}

	private static void _0023_003Dz_00240XF2Cj8rfbdMXQhvfb3WHrtucO3BAti2pBPel_0024jTNJK(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (!_0023_003DzTrgTcTMfYB_0024_0024FAHVo8gUnnYGCc_0024m5Xkirg_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private static void _0023_003Dz9XqjpSRTnoXBgbgasyWndi4_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DztP7PBX2bGr9qR_8NV2HJNQoKwjzAZkYaog_003D_003D(3);
	}

	private static void _0023_003DzNtSqxyA7IAHHEF_0024FR7l2YRMStQgaZeqlkA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz2VVL65ZUV4mNemmPJRTlKGJnuqYG(num);
		object obj = ((_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003Dzip8yWLvtIndlQqoIuur_x1i0otdXn27UJQ_003D_003D() == 0) ? _0023_003Dzq80RbjQ_003D._0023_003Dz3WMplEOlITZ12UoH9HOKn3udSV_acKBw3g_003D_003D(_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003DzCWZOPjSM8D3YL_0024OfiDo5TnXQ6F_U()) : (_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2._0023_003DzqZLvK7FhPMHAcJUCHWtKXWMzPckK()._0023_003DzqOu1TN1s3NS2hQUVPYsa_00244SKYkVab0KlLpt1jtZUdMgMAIWTGqK_0024tMpMMJ_fDsOKZJ9ioF1ZC4AWhKibZPHTf6Y_003D() switch
		{
			2 => _0023_003Dzq80RbjQ_003D._0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(num, _0023_003DzZzVr6_0024U_003D: true).TypeHandle, 
			0 => _0023_003Dzq80RbjQ_003D._0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(num).MethodHandle, 
			1 => _0023_003Dzq80RbjQ_003D._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num).FieldHandle, 
			_ => throw new InvalidOperationException(), 
		}));
		_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D obj2 = new _0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D();
		obj2._0023_003DzTeWYaTS0cogWoCNsB7HPNo0_003D(obj);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj2);
	}

	private static void _0023_003DzlobJCUIal0Cr2rU4wFKN9vshmzQjbEZpKnqKP8UBCT5K(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzcHX5J0_BxaBvebV44eNBFeg_003D(1);
	}

	private void _0023_003DzubfuoE_0024ivGL5iSuJj7CdjY8akdxBogEezQYRU10_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		MethodBase methodBase = _0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(num);
		Type declaringType = methodBase.DeclaringType;
		ParameterInfo[] parameters = methodBase.GetParameters();
		int num2 = parameters.Length;
		object[] array = new object[num2];
		Dictionary<int, _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D> dictionary = new Dictionary<int, _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D>();
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
			if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 is _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D value)
			{
				dictionary.Add(num3, value);
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003DzVKGrnWcI1IMKMZDCJ42cyF47feJMfr05OpzN_nsR80KP(value);
			}
			if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D() != null)
			{
				_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003Dzf66g2pe9JoHb867POLaHUYc_003D())._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
			}
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, parameters[num3].ParameterType)._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2);
			array[num3] = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		object obj;
		try
		{
			obj = _0023_003Dzn6drv421fV0O5urB0a70eJS0cc7fu428Yw_003D_003D(methodBase, null, array, _0023_003DzcbLoSrg_003D: false);
		}
		catch (TargetInvocationException ex)
		{
			Exception ex2 = ex.InnerException ?? ex;
			_0023_003DzYdwOeQ6ohJIqRySc0WL8wF8xQ56H(ex2);
			return;
		}
		foreach (KeyValuePair<int, _0023_003DqQ6UyaJUbdMWx9XeEXjd_0024_0024moFNSbcLywtyRILEay3coI_003D> item in dictionary)
		{
			_0023_003Dz8q6qeiuACNSROgwFPdQnEws_003D(item.Value, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(array[item.Key], null));
		}
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, declaringType));
	}

	private _0023_003DqymTLvf3BrhQp_00245V_LtgjgTjxJNwJbW7z4ld0XpHCSus_003D[] _0023_003DzYAMD8L5Q_0024i4SLp0naHwJXiLKJqr1Clws_vttK48_003D(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqymTLvf3BrhQp_00245V_LtgjgTjxJNwJbW7z4ld0XpHCSus_003D[] array = new _0023_003DqymTLvf3BrhQp_00245V_LtgjgTjxJNwJbW7z4ld0XpHCSus_003D[_0023_003Dzq80RbjQ_003D._0023_003DzAT5B_0024KrVlUL38D8pF9i1EEk_003D()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003Dzx3FQAbzdBQ2sGdOXzwIvxKjNiDDx(_0023_003Dzq80RbjQ_003D);
		}
		return array;
	}

	private static object _0023_003DzwnjkX4jybFztBLWSLe4Xk2OZ0uxg9u1rb39dBATHMPXn(MethodBase _0023_003Dzq80RbjQ_003D, object _0023_003DzZzVr6_0024U_003D, object[] _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
	{
		_0023_003DzkJp9o4I_003D _0023_003DzkJp9o4I_003D2 = new _0023_003DzkJp9o4I_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzcbLoSrg_003D);
		_0023_003DzuwE9t4w_003D _0023_003DzuwE9t4w_003D2 = _0023_003DzXOb4z00N8_8FLnE0SZgHJe4_003D(_0023_003DzkJp9o4I_003D2);
		if (_0023_003DzuwE9t4w_003D2 == null)
		{
			bool flag;
			lock (_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003Dz7hRN5Rg_003D)
			{
				_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003Dz7hRN5Rg_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out var value);
				flag = value >= 50;
				if (!flag)
				{
					_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003Dz7hRN5Rg_003D[_0023_003Dzq80RbjQ_003D] = value + 1;
				}
			}
			if (!flag && (_0023_003DzcbLoSrg_003D || _0023_003DzZzVr6_0024U_003D != null || _0023_003Dzq80RbjQ_003D.IsStatic || _0023_003Dzq80RbjQ_003D.IsConstructor) && !_0023_003DzL94hnqSnkldgtwyzxspfLJKoNrS5XaCzRiFvPiZe6uG4(_0023_003Dzq80RbjQ_003D) && (_0023_003Dzq80RbjQ_003D.CallingConvention & CallingConventions.Any) != CallingConventions.VarArgs)
			{
				return _0023_003DzgCnHr6_0024NKsiKffk0iw_003D_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			}
			_0023_003DzuwE9t4w_003D2 = _0023_003DzKLApn_uNcxCYi0_0024FfFrg_0024grx_00242pDREUTbw_003D_003D(_0023_003DzkJp9o4I_003D2);
			lock (_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003Dz7hRN5Rg_003D)
			{
				_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003Dz7hRN5Rg_003D.Remove(_0023_003Dzq80RbjQ_003D);
			}
		}
		return _0023_003DzuwE9t4w_003D2(_0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
	}

	private void _0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003Dzq80RbjQ_003D));
	}

	private static void _0023_003Dz_0024i5rrlYSfdRGAvizGVjxJTZ5HANJ2a4uJA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzrXP8FSNI2_0024eLDTdy0yuJSloq1FJOrMnzuRJ4ofw_003D();
	}

	private static void _0023_003DzK_PGawVSQjI9cyj9jFBzsn8TKGwqGSGkrgJGrXw_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		throw new NotSupportedException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525008));
	}

	private _0023_003DqymTLvf3BrhQp_00245V_LtgjgTjxJNwJbW7z4ld0XpHCSus_003D _0023_003Dzx3FQAbzdBQ2sGdOXzwIvxKjNiDDx(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqymTLvf3BrhQp_00245V_LtgjgTjxJNwJbW7z4ld0XpHCSus_003D obj = new _0023_003DqymTLvf3BrhQp_00245V_LtgjgTjxJNwJbW7z4ld0XpHCSus_003D();
		obj._0023_003DzifCpV1NnRzQpyxyacn4ka_00243OotPQA0bDVw_003D_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
		return obj;
	}

	private Stack<_0023_003DzUH03yec_003D> _0023_003DzbKacmMjJlAozzsmL94D6Uq6kYdq6()
	{
		Stack<_0023_003DzUH03yec_003D> stack = _0023_003DzTiqx__00240_003D;
		if (stack == null)
		{
			stack = (_0023_003DzTiqx__00240_003D = new Stack<_0023_003DzUH03yec_003D>());
			stack.Push(new _0023_003DzUH03yec_003D
			{
				_0023_003DzZzVr6_0024U_003D = _0023_003DzLi0XoCY_003D,
				_0023_003Dz7hRN5Rg_003D = _0023_003DzLi0XoCY_003D._0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D(),
				_0023_003DzcbLoSrg_003D = _0023_003DzQ94e_m4_003D
			});
		}
		return stack;
	}

	private static void _0023_003Dz11ydhDvquMMfOCtxLw_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dzq80RbjQ_003D._0023_003DzV3inriSZO20nAilFUfefq9Z1GNCidoulXQ_003D_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2));
	}

	private void _0023_003DzK6lBjrm1Y8KqG_Zbf6StalQ_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		short num = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (!_0023_003Dzq80RbjQ_003D) ? ((short)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()) : checked((short)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
			13 => (!_0023_003Dzq80RbjQ_003D) ? ((short)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()) : checked((short)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()), 
			19 => (!_0023_003Dzq80RbjQ_003D) ? ((short)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())) : checked((short)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => (!_0023_003Dzq80RbjQ_003D) ? ((short)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()) : checked((short)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((short)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((short)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())) : ((!_0023_003Dzq80RbjQ_003D) ? ((short)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((short)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D obj = new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D();
		obj._0023_003DzYFXWifrsG3fRPmCVbL0axdi3r_0024DS(num);
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	private static void _0023_003DzdglRuh5Q5nTPaUfn_0024NMmGGNi3WiX5xHlKZHmph4_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		int num = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		FieldInfo fieldInfo = _0023_003Dzq80RbjQ_003D._0023_003DzxTrOTgJxsgwLEm0zhP7uB_KyWOAvfVGhFhE2qmv9jlnq(num);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(fieldInfo.GetValue(null), fieldInfo.FieldType));
	}

	private static void _0023_003DzBujVW4p4qaNMzbKoQgaayLS14QUups0UvQ_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(0);
	}

	private static void _0023_003DzMjT56P1S7NbQOzcP3_00244JRsoR8v52LXp_0024fIz66tbngeC1(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzIYrGYJEZRyb_00246e5h2k_0024Qe3pcuiDnunnKS2bjUdK9lrK_0024(_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D);
	}

	private static void _0023_003DzipXRa2olforJzyPl2PUng_Q_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		float num = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			8 => (float)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D obj = new _0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D();
		obj._0023_003DzKX2ZrfrcVeNswXLZ75L2lQv52uiRGRJuM4lB8Xg_003D(num);
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
	}

	[DebuggerNonUserCode]
	private MethodBase _0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = _0023_003Dz2VVL65ZUV4mNemmPJRTlKGJnuqYG(_0023_003Dzq80RbjQ_003D);
		MethodBase result = _0023_003DzceSsf__0024vYBWVlbSQGwq0O1iA1r3ZVmzrJbM9ET8_003D(_0023_003Dzq80RbjQ_003D, _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2);
		_0023_003DzkO3PJHhv6CGcBbCGk3WpSnPpLNzMif3JCQ_003D_003D(result);
		return result;
	}

	private static void _0023_003DzYg_0024s9sEPNHdGw_0024wx5Uz84DvaPioLxZpOMQ_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003Dzbnzi9JArhzTjZqiOIA_003D_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	private static void _0023_003Dzp0XWyj3tqlRr7C12n_002488AaEfE_pLs3wExbISWSA_003D(ILGenerator _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		switch (_0023_003DzZzVr6_0024U_003D)
		{
		case -1:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_M1);
			return;
		case 0:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_0);
			return;
		case 1:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_1);
			return;
		case 2:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_2);
			return;
		case 3:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_3);
			return;
		case 4:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_4);
			return;
		case 5:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_5);
			return;
		case 6:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_6);
			return;
		case 7:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_7);
			return;
		case 8:
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_8);
			return;
		}
		if (_0023_003DzZzVr6_0024U_003D > -129 && _0023_003DzZzVr6_0024U_003D < 128)
		{
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4_S, (sbyte)_0023_003DzZzVr6_0024U_003D);
		}
		else
		{
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Ldc_I4, _0023_003DzZzVr6_0024U_003D);
		}
	}

	private object _0023_003DzIRjHpBT48wikHA3Dmt5vhwwkbEarj_0024ke3BpAkWqTQVzU(object[] _0023_003Dzq80RbjQ_003D, Type[] _0023_003DzZzVr6_0024U_003D, Type[] _0023_003Dz7hRN5Rg_003D, object[] _0023_003DzcbLoSrg_003D)
	{
		_0023_003DzAOrwStx8zJJYrAkKfVBbAnY_003D();
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			_0023_003Dzq80RbjQ_003D = global::_0023_003DqhPb_0024Tu3Z_v596mlNOKGvnYtvrZy33J77pR3ic6_0024nuNc_003D<object>._0023_003Dzq80RbjQ_003D;
		}
		this.m__0023_003DzKyPCKaY_003D = _0023_003DzcbLoSrg_003D;
		_0023_003DzuUxvxmo_003D = _0023_003DzZzVr6_0024U_003D;
		this.m__0023_003DzcbLoSrg_003D = _0023_003Dz7hRN5Rg_003D;
		_0023_003DzxhN3bEo_003D = _0023_003DzUpbyuVdyI9_0024U_sls9mmOL6mRCsTgdcnxThL7nJk_003D(_0023_003Dzq80RbjQ_003D);
		this.m__0023_003Dz5QkdKZk_003D = _0023_003Dzi3BtLz9ca4emEMUSHvZTuImhjfuptWcGJnnAKBg_003D();
		try
		{
			_0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D2 = new _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D(this.m__0023_003DzoVpU9JU_003D);
			try
			{
				using (_0023_003DzLi0XoCY_003D = new _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D(_0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D2))
				{
					_0023_003DzdLjJal4_003D = (uint)_0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D2._0023_003DzCw1_0024ldBjs0aUP3McccU_9Sjt_mWYXegwAz1XgjD5sZO2YJKkSww9WmC4Df0X_LF4W2M9EoA9a9fwM1Q04iTehag_003D();
					_0023_003DzrhEG9Ic_003D = false;
					_0023_003Dz5SBVqVA_003D = null;
					this.m__0023_003Dzkl7CXTo_003D = 0u;
					_0023_003DzmZNu_pI_003D = 0u;
					_0023_003DzLpNYyqiuDYKdUW0EcPmsEjI_003D();
					_0023_003Dz6v3cdJTvIl03MdLz0yM1irdLo3AWwBfzYPHLiadS3Iy7();
				}
			}
			finally
			{
				((IDisposable)_0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D2).Dispose();
			}
			Type type = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(m__0023_003DzAXvW_0024Kw_003D._0023_003DzLpSv0vHTW8_4lB2p8sQgRMe8pmaJ8yhiCg_003D_003D(), _0023_003DzZzVr6_0024U_003D: false);
			if (type != _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D.m__0023_003DzLaPeX80_003D && _0023_003Dz_ugnXtkWl3OOwSfSYMNS4_0024OF3SedPTFK5V1IrS4_003D())
			{
				return _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, type)._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D())._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
			}
			return null;
		}
		finally
		{
			for (int i = 0; i < m__0023_003DzAXvW_0024Kw_003D._0023_003Dzk6NqcXocXPYbt5Kh5TxUvGSiFQOn().Length; i++)
			{
				_0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D _0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D2 = m__0023_003DzAXvW_0024Kw_003D._0023_003Dzk6NqcXocXPYbt5Kh5TxUvGSiFQOn()[i];
				if (_0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D2._0023_003DzqetEU5ZANX15xnSv7pWIdjRVzRHWuShl2g_003D_003D())
				{
					_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D _0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D2 = (_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D)_0023_003DzxhN3bEo_003D[i];
					Type type2 = _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(_0023_003DqI6EWtn7_002464gNhfpc2l8JOWBvZMvT5Zk74YT6bEG7C38_003D2._0023_003DzMIf6Qcoa626dIfKdj06GAYVkuQnij6bPFMzPRpYqY31Y(), _0023_003DzZzVr6_0024U_003D: false);
					_0023_003Dzq80RbjQ_003D[i] = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(null, type2.GetElementType())._0023_003DzyXuMCKr5ollRSyGP77LhpIxltxI6fJCPk09Wc78CZkM1QMvfaSf1BHT_0TwgWPUF6hom1_0iwKoV7BcTFQ_003D_003D(_0023_003Dq5Kh1KFPacGgmvXUmsZ8pdYe_00247qav8fqJrDmEOfGvalg_003D2._0023_003Dzsg16MNLOFrIol9kAkfDFT25y5dmq())._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
				}
			}
			this.m__0023_003DzKyPCKaY_003D = null;
			_0023_003DzxhN3bEo_003D = null;
			this.m__0023_003Dz5QkdKZk_003D = null;
		}
	}

	private static void _0023_003DzaTQyY1cvgPsW3zUyM6yKMUkLLh9d_0024cfTjmsR6Oc_003D(ILGenerator _0023_003Dzq80RbjQ_003D, Type _0023_003DzZzVr6_0024U_003D)
	{
		if (!(_0023_003DzZzVr6_0024U_003D == _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D))
		{
			_0023_003Dzq80RbjQ_003D.Emit(OpCodes.Castclass, _0023_003DzZzVr6_0024U_003D);
		}
	}

	private static void _0023_003DzK645WSI1cc6YYkScS9gqqmU_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzwwYHocafLvZVCJjHxDwZ0C6f7DiZFaT1uyucXN4_003D(((_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnFZuTRJnaiMKIXoWIINRZpE_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzuTcJfhzDWIs6UevJEo5R39E_003D());
	}

	private Type _0023_003Dzr95zmn41JQSwJ3qoLZX2114qsdpD4gebCMqZZ78_003D(int _0023_003Dzq80RbjQ_003D, bool _0023_003DzZzVr6_0024U_003D)
	{
		Type type;
		lock (_0023_003DzxHwNxiw_003D)
		{
			bool flag = true;
			if (flag && _0023_003DzxHwNxiw_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out var value))
			{
				type = (Type)value;
			}
			else
			{
				_0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2 = _0023_003Dz2VVL65ZUV4mNemmPJRTlKGJnuqYG(_0023_003Dzq80RbjQ_003D);
				type = _0023_003Dz9yuOi6ipcItiiUygi4SIRn8QoJy9hhxz07vba7g_003D(_0023_003Dzq80RbjQ_003D, _0023_003DqO9TEqm6qa7P6EAiT4EUfxPT0iAGyzLKx_FONUNqoCIs_003D2, ref flag, _0023_003DzZzVr6_0024U_003D);
				if (flag)
				{
					_0023_003DzxHwNxiw_003D.Add(_0023_003Dzq80RbjQ_003D, type);
				}
			}
		}
		if (_0023_003DzZzVr6_0024U_003D)
		{
			_0023_003DzkO3PJHhv6CGcBbCGk3WpSnPpLNzMif3JCQ_003D_003D(type);
		}
		return type;
	}

	private static void _0023_003DzB_0024H_0024crXAQ7vpvnGOdmrNg3hOgRkrBtO_0024OBvHI9KrovZi(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(checked(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (ushort)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (ushort)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => (ushort)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			8 => (ushort)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((ushort)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((ushort)(uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003Dz5grbuSNnC4gAYKevCT4F_0024VjJZho_HAQCrg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		MethodBase methodBase = ((_0023_003Dqqr0fJcmNHD_002426q7CfYl3TIKslsTynyI2_0024uUSOUtw4jk_003D)_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D())._0023_003DzhPsFl9DgX11KA9Mha_0024sgPXE_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzD2uSK_0024mBXXfGbn5bMRWJScc_003D(methodBase, _0023_003DzZzVr6_0024U_003D: false);
	}

	private static _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D _0023_003Dzmjx3IYVmxm4H_sfJfSlPWXT2veAi(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D obj = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (obj._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 13)
		{
			throw new InvalidOperationException();
		}
		long num = ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)obj)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO();
		int num2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D();
		if (num2 != 7 && num2 != 9)
		{
			throw new InvalidOperationException();
		}
		byte[] array = _0023_003DqJTjaQmhkW8F60LVdPhnyDwADUWaHNqD2qYMVmbk_zcU_003D._0023_003DzhD38a3WXV0KK_0024tO1hPCGDpBbMFcy(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
		if (_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() != 1)
		{
			throw new InvalidOperationException();
		}
		int num3 = ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D();
		_0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D obj2 = new _0023_003DqG2j0vYyDwMuB3UfmWnsmaRkNUPvszCLv0iW9RiJVhHA_003D();
		obj2._0023_003DzpNkHSE_NjcXIyUaoq2L5pn0_003D(num3);
		obj2._0023_003DzK5hyjEOXaMaizNeAjaubSUPb8eGc(array);
		obj2._0023_003Dz4tjrJCsrdDkDXs30Y5v0nudSyZ02(num);
		return obj2;
	}

	private static void _0023_003DzygZ4p6Nwr3vB8cg4OYix6zwk8kD2Fyh_GA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzYdwOeQ6ohJIqRySc0WL8wF8xQ56H(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D());
	}

	private void _0023_003DzDpNz_0024ws8Z8wzT_0024TQLl8uOeAxUIl9()
	{
		if (this.m__0023_003Dzq80RbjQ_003D.Count == 0)
		{
			if (this.m__0023_003DzuwE9t4w_003D)
			{
				_0023_003DzYdwOeQ6ohJIqRySc0WL8wF8xQ56H(_0023_003Dz0Ht_0024Sk0_003D);
			}
			return;
		}
		_0023_003DzqMLoHoQ_003D _0023_003DzqMLoHoQ_003D2 = this.m__0023_003Dzq80RbjQ_003D.Pop();
		if (_0023_003DzqMLoHoQ_003D2._0023_003DzdwE39exGeF5INW684okNqdI_003D() != null)
		{
			_0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D obj = new _0023_003Dqwtg5wf2a70tRxUwrA7Np2qyDGi7k9M590mIUORvwIW8_003D();
			obj._0023_003Dzo33kGQXV675C6hNoF81XsSEYKksd3nOR_0024BTIt3_9Mzop3nbwVDhRzms9WcekcpYSeX_0024SmhxcEhkErzVIHbObpCA_003D(_0023_003DzqMLoHoQ_003D2._0023_003DzdwE39exGeF5INW684okNqdI_003D());
			_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(obj);
		}
		else
		{
			_0023_003DzLpNYyqiuDYKdUW0EcPmsEjI_003D();
		}
		_0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(_0023_003DzqMLoHoQ_003D2._0023_003Dzm9VpQhRD9rpmsnXR3GK29eEH0kyJ());
	}

	private static void _0023_003DzShgdTHaf2FtEU_sdRX2zW64b3ixAWNwXlA_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2 = (_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003DzZzVr6_0024U_003D;
		MethodBase methodBase = _0023_003Dzq80RbjQ_003D._0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D());
		_0023_003Dzq80RbjQ_003D._0023_003DzD2uSK_0024mBXXfGbn5bMRWJScc_003D(methodBase, _0023_003DzZzVr6_0024U_003D: false);
	}

	private static void _0023_003DzVefJQ5ny_ZdbnTdluPSnCNyDIXm4sDsynSjLGp4_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => ((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (int)checked((uint)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()), 
			19 => (int)checked((uint)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => (int)checked((uint)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((int)checked((uint)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())) : ((int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzWWfxPaMVS9km2tSSY3Y4nG1g4A6wr3pzT0AiLc2bX_0024SJ(_0023_003DqqAFF17CqR9tmgwcDOoVXDetMUSO2R358_0024Egq6_ALGIs_003D _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003DzMPgRDeEg4eaPMM9e6Yhl2NjUmZY6snRvMqp3h_M_003D() && !m__0023_003DzAXvW_0024Kw_003D._0023_003DzJ6sEeU_QCXNQIL1Xb7GUYNIEmzb2j9fH1ej57ljYuZU_0024() && _0023_003Dzq80RbjQ_003D._0023_003DzJ6sEeU_QCXNQIL1Xb7GUYNIEmzb2j9fH1ej57ljYuZU_0024() && !_0023_003Dzq80RbjQ_003D._0023_003Dzeg68hj9FCQ4kZ65IFZzdYWI00Jbg())
		{
			string text = _0023_003DzJgQM5CjFJ0TIbvJ5cbmQCTKZ_dmF(_0023_003Dzq80RbjQ_003D);
			throw _0023_003DzaWqfW1XbxjFJHEqe2NyQ60ah4dXEb3g5kWwI2p2LZ38J(_0023_003DzJgQM5CjFJ0TIbvJ5cbmQCTKZ_dmF(m__0023_003DzAXvW_0024Kw_003D), text);
		}
	}

	private object _0023_003Dz3WMplEOlITZ12UoH9HOKn3udSV_acKBw3g_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		switch (_0023_003DqlHKxxpFo09hpZGwDJtHF5RuTS_0024NF1_7HRYV7caxV3es_003D._0023_003DzRM37NjDbUaygXaz18mh1u2D2M8Qv(_0023_003Dzq80RbjQ_003D))
		{
		case 16777216:
		case 33554432:
		case 452984832:
			return this.m__0023_003DzkJp9o4I_003D.ModuleHandle.ResolveTypeHandle(_0023_003Dzq80RbjQ_003D);
		case 67108864:
			return this.m__0023_003DzkJp9o4I_003D.ModuleHandle.ResolveFieldHandle(_0023_003Dzq80RbjQ_003D);
		case 100663296:
		case 721420288:
			return this.m__0023_003DzkJp9o4I_003D.ModuleHandle.ResolveMethodHandle(_0023_003Dzq80RbjQ_003D);
		case 167772160:
			try
			{
				return this.m__0023_003DzkJp9o4I_003D.ModuleHandle.ResolveFieldHandle(_0023_003Dzq80RbjQ_003D);
			}
			catch
			{
				try
				{
					return this.m__0023_003DzkJp9o4I_003D.ModuleHandle.ResolveMethodHandle(_0023_003Dzq80RbjQ_003D);
				}
				catch
				{
					throw new InvalidOperationException();
				}
			}
		default:
			throw new InvalidOperationException();
		}
	}

	private static void _0023_003DznIZlcizAPpQJ_00246LcZw_PhxHQKccy(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzmDEs95gK8mfbul3vtWZKpK5myUkt(3);
	}

	private object _0023_003DzCuczqEv4SH45QPwQF4DYmlQfcp7VmH_zcVziIvXYuW65(Stream _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, object[] _0023_003Dz7hRN5Rg_003D, Type[] _0023_003DzcbLoSrg_003D, Type[] _0023_003DzqMLoHoQ_003D, object[] _0023_003DzuwE9t4w_003D)
	{
		this.m__0023_003DzoyRBT1A_003D = _0023_003Dzq80RbjQ_003D;
		_0023_003DzL1lWLjrLTywcRSsj75BhRk4ld4f6(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, null);
		return _0023_003DzIRjHpBT48wikHA3Dmt5vhwwkbEarj_0024ke3BpAkWqTQVzU(_0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D, _0023_003DzuwE9t4w_003D);
	}

	private void _0023_003DzgvGx8MFmQfFwyuAFc7msZwqmhV7g(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (!_0023_003Dzq80RbjQ_003D) ? ((uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()) : checked((uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
			13 => (!_0023_003Dzq80RbjQ_003D) ? ((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO() : ((long)checked((ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO())), 
			19 => (long)((!_0023_003Dzq80RbjQ_003D) ? Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()) : Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => (long)((!_0023_003Dzq80RbjQ_003D) ? ((ulong)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()) : checked((ulong)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D())), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((long)checked((ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()))) : ((!_0023_003Dzq80RbjQ_003D) ? ((uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())), 
			20 => (long)((UIntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((ulong)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()) : ((ulong)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D())) : ((!_0023_003Dzq80RbjQ_003D) ? ((uint)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()) : ((uint)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()))), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003Dz2Uq_uvZk7h8fhbsi9DJGFt8_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2 = (_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dzq80RbjQ_003D;
		MethodBase methodBase = _0023_003DzabfIWzYyhX2VBhaZi2_0024CNZecmSqyA2kM9w_003D_003D(_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D2._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D());
		if (_0023_003DzaG3DPu0_003D != null)
		{
			ParameterInfo[] parameters = methodBase.GetParameters();
			Type[] array = new Type[parameters.Length];
			int num = 0;
			ParameterInfo[] array2 = parameters;
			foreach (ParameterInfo parameterInfo in array2)
			{
				array[num++] = parameterInfo.ParameterType;
			}
			MethodInfo method = _0023_003DzaG3DPu0_003D.GetMethod(methodBase.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array, null);
			if (method != null)
			{
				methodBase = method;
			}
			_0023_003DzaG3DPu0_003D = null;
		}
		_0023_003DzD2uSK_0024mBXXfGbn5bMRWJScc_003D(methodBase, _0023_003DzZzVr6_0024U_003D: true);
	}

	private static void _0023_003DzWWqQafCp5nllxDJHW8EOF_COa6ixJO2mQIFPL9o_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzK6lBjrm1Y8KqG_Zbf6StalQ_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private static void _0023_003DzZ6Cpf9Lk2os2WdTipDtbn3xlujHbhXi0C49Q2tc_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzcHX5J0_BxaBvebV44eNBFeg_003D(0);
	}

	private static void _0023_003DzMkjl5tvnsg6DfgcObDCO9klKUxR_3OUYjhHgDJRO8DbJ(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		object obj = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		long num = _0023_003Dzq80RbjQ_003D._0023_003Dz70LbFB0wk27bIfU1WCbu9dh2fwf5();
		Array array = (Array)_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D()._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(long))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(long));
			((long[])array)[num] = (long)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType == typeof(ulong))
		{
			_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3 = _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D._0023_003DzFmFSpvu7JVxIiWJ_acs7z9gE_0024w_0024CfIwZAxIgweQ_003D(obj, typeof(ulong));
			((ulong[])array)[num] = (ulong)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D3._0023_003DzYMcWAkpRiuaD_qonO4GfkAYB3sEHqDL3_Q4tnY5IMjbGA3afiX7Vw_4CeWetnQ11w_002495A3E_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(elementType, obj, num, array);
		}
		else
		{
			_0023_003Dzq80RbjQ_003D._0023_003Dzexd61H2RusYX87XHPh8iJlL9hxGW(typeof(long), obj, num, array);
		}
	}

	private static void _0023_003Dz6xubmFjtdWxFzsLYQNzgl_ltf7VOFt7ZDg_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzDpNz_0024ws8Z8wzT_0024TQLl8uOeAxUIl9();
	}

	private void _0023_003Dzbnzi9JArhzTjZqiOIA_003D_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (!_0023_003Dzq80RbjQ_003D) ? ((byte)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()) : checked((byte)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D()), 
			13 => (!_0023_003Dzq80RbjQ_003D) ? ((byte)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()) : checked((byte)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO()), 
			19 => (!_0023_003Dzq80RbjQ_003D) ? ((byte)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())) : checked((byte)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D())), 
			8 => (!_0023_003Dzq80RbjQ_003D) ? ((byte)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()) : checked((byte)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((byte)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((byte)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())) : ((!_0023_003Dzq80RbjQ_003D) ? ((byte)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : checked((byte)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr())), 
			20 => (UIntPtr.Size != 4) ? ((!_0023_003Dzq80RbjQ_003D) ? ((byte)(ulong)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()) : checked((byte)(ulong)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D())) : ((!_0023_003Dzq80RbjQ_003D) ? ((byte)(uint)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D()) : checked((byte)(uint)((_0023_003DqkuIA1_bMmg_0024xhfRjWyd6zDoRcc_00249X5fV_VsIDrDdSh4_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzqnLjM8aurg_0024zRDDujZvHcFkI7dnpHqvkmg_003D_003D())), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private static void _0023_003DzAlgoLJZgMnWg21OQmgpFoX_00242JyKKp2EinPt7KiPYCvKn(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzLt_ISA_s_0024PYZg3Hh9F3Offjq_0024BRi(new _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D(checked(_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2._0023_003DzSc9BEm4yQ0_0024Kknkei2yM1sP76Bdbuq2mN_f70WU_003D() switch
		{
			1 => (short)(uint)((_0023_003Dqf6dX8MX3oDCSi1YT8GkIfKvfLnIuVWOcc6LA0ROdlZ0_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzrn0L3njPylzmIF_nfIhaK4dRcQXUdeAkvg_003D_003D(), 
			13 => (short)(ulong)((_0023_003DqPjU0as5GIhLtc26yxRodCrqbZ6d0PcAxtiuLpants80_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003DzGdCW3g0kJ48pwlL4gkuvGDC3Nexp5N8EkU1PfhYZsEYO(), 
			19 => (short)Convert.ToUInt64(((_0023_003DqQfI56JiinBVT8e_0024h_L7q1vyuTgVFltrRhNsrgx4dFxQ_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzn4_0024TuBctOMS490_0024Cbtb6Td4_003D()), 
			8 => (short)((_0023_003DqUR7_0024aTHoiijy1rATVvJvauBY_wNHLqNSKsplgvWTyS8_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dz34_0024tKDcm13KVpJSr7da6qqRX_0024t9nptIi6g_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((short)(ulong)(long)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()) : ((short)(uint)(int)((_0023_003Dqje8unbeuXWKDdxL8YmRQgV2rAC8ja5CCp36_AlVQ5pw_003D)_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2)._0023_003Dzzqxqhuwhf0Z_t6BJhRqsvgQUlGFr()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzycHTghsODfwJ_0024kToip16kTJXWof_0024LfSw5yNsJYZOA4S4(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2 = _0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D();
		if (_0023_003DzwfAT8W8IYpR6ztTl1Vsa7rnoeEQiGi2vHCk_fc8_003D(_0023_003Dzq80RbjQ_003D._0023_003Dz9ya1FQT7m3gCSSw_jw_003D_003D(), _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D2))
		{
			uint num = ((_0023_003DqtdOfWBQ1IWF7LpY14n4YH7fVSWmBsa_ytZXinvxeKfo_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzZ6CLQoBpD74qEyzi8k2qS5pTukBnSYTCmw_003D_003D();
			_0023_003Dzq80RbjQ_003D._0023_003DzxYXPAnjwhp_BZ7uJNAVSTIc_003D(num);
		}
	}

	private void _0023_003DzmSUiy7sPdkHWa_kpgPiolyyCqWUwmeU_lBOK610_003D(_0023_003DzUH03yec_003D _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzLi0XoCY_003D = _0023_003Dzq80RbjQ_003D._0023_003DzZzVr6_0024U_003D;
		_0023_003DzQ94e_m4_003D = _0023_003Dzq80RbjQ_003D._0023_003DzcbLoSrg_003D;
	}

	private static bool _0023_003DzMPgRDeEg4eaPMM9e6Yhl2NjUmZY6snRvMqp3h_M_003D()
	{
		return false;
	}

	private static bool _0023_003DzL94hnqSnkldgtwyzxspfLJKoNrS5XaCzRiFvPiZe6uG4(MethodBase _0023_003Dzq80RbjQ_003D)
	{
		ParameterInfo[] parameters = _0023_003Dzq80RbjQ_003D.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			if (parameters[i].ParameterType.IsByRef)
			{
				return true;
			}
		}
		return false;
	}

	private static void _0023_003DzSCzrsZtO7NuRRUyPHaRnDCVtaB1K(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzgvGx8MFmQfFwyuAFc7msZwqmhV7g(_0023_003Dzq80RbjQ_003D: false);
	}

	private static void _0023_003DztWRj3UNj5TytsotMFulSjEw_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzCEuz7AYVmVvV4DPlYw_003D_003D(7);
	}

	private static void _0023_003DzrK8d_bzEtJpdiC39RcLGoXrXLlglZ9ML4w_003D_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzoSOcA_xIir7qj1v7MWszdx8_003D(((_0023_003DqJTjaQmhkW8F60LVdPhnyD1vew7HMhmkJ8IjSifKnsRU_003D)_0023_003DzZzVr6_0024U_003D)._0023_003DzjMeEJ3HfdiVVM9FdsA_003D_003D());
	}

	private static void _0023_003DzqfvuNKy8l_0024z_y9hJUL8jenIIRbFqZ9YrTTVhi5Y_003D(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003Dzq80RbjQ_003D, _0023_003Dq9o_OPfa_DuRpdjQlVA0aikQBglJvnKXy_XHJM32RhTg_003D _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003Dzq80RbjQ_003D._0023_003DzClvFpnBhopC5aAjD7K31UNUSndWj_0024t_00248Ig_003D_003D(_0023_003Dzq80RbjQ_003D: false);
	}

	[Conditional("DEBUG")]
	private void _0023_003DzIjO_NOn7k4GtV_PGUeZyyFt31Oy4(object _0023_003Dzq80RbjQ_003D)
	{
	}

	private static bool _0023_003DzJbnsx8OjDsJ5RheGt9UV6NE_003D(uint _0023_003Dzq80RbjQ_003D, uint _0023_003DzZzVr6_0024U_003D, uint _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D >= _0023_003DzZzVr6_0024U_003D)
		{
			return _0023_003Dzq80RbjQ_003D <= _0023_003DzZzVr6_0024U_003D + _0023_003Dz7hRN5Rg_003D;
		}
		return false;
	}
}

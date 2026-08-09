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

internal sealed class _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D
{
	private sealed class _0023_003Dz437_00244ak_003D : IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D _0023_003DziDLVpbY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003Dz5rQzobg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DzAvn2b38_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long _0023_003DzR58imxw_003D;

		public void Dispose()
		{
			IDisposable disposable = _0023_003Dz5rQzobg_003D;
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
			if (_0023_003DzAvn2b38_003D != null)
			{
				_0023_003DzAvn2b38_003D.Dispose();
				_0023_003DzAvn2b38_003D = null;
			}
		}
	}

	[Serializable]
	private sealed class _0023_003Dz5rQzobg_003D
	{
		public static readonly _0023_003Dz5rQzobg_003D _0023_003DziDLVpbY_003D = new _0023_003Dz5rQzobg_003D();

		public static Comparison<_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D> _0023_003Dz5rQzobg_003D;

		internal int _0023_003Dz7vxntvgQqf6Ye8_AHoedaZl1nYc3fwNyN5zY3utG9_002478(_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D _0023_003DziDLVpbY_003D, _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D _0023_003Dz5rQzobg_003D)
		{
			if (_0023_003DziDLVpbY_003D._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK() == _0023_003Dz5rQzobg_003D._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK())
			{
				return _0023_003Dz5rQzobg_003D._0023_003DzrRpn5KHjaIKRa2Vs_0024HZe4YswX1zq_0024V2Y6w_003D_003D().CompareTo(_0023_003DziDLVpbY_003D._0023_003DzrRpn5KHjaIKRa2Vs_0024HZe4YswX1zq_0024V2Y6w_003D_003D());
			}
			return _0023_003DziDLVpbY_003D._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK().CompareTo(_0023_003Dz5rQzobg_003D._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK());
		}
	}

	private sealed class _0023_003Dz8wjMonY_003D
	{
	}

	private struct _0023_003DzAvn2b38_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DziDLVpbY_003D;
	}

	private sealed class _0023_003DzEWLeis8_003D
	{
		private string _0023_003DziDLVpbY_003D;

		private Type _0023_003Dz5rQzobg_003D;

		public string _0023_003Dz3Lr4_LIp0qUzC2p4pOpJx7piN9DlZfvD5zuE5h8_003D()
		{
			return _0023_003DziDLVpbY_003D;
		}

		public void _0023_003DzWAEgKJbt6lkvtM6qJOgqokVOeGhkmQOKKg_003D_003D(string _0023_003DziDLVpbY_003D)
		{
			this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
		}

		public Type _0023_003DzkHK_00249krn0PDdyAlq5Vn0rhBxe8xwcwcKIQ_003D_003D()
		{
			return _0023_003Dz5rQzobg_003D;
		}

		public void _0023_003DzRGGEb4h9XjuoSbeUL__wXfU8mEvz2I_7Vw_003D_003D(Type _0023_003DziDLVpbY_003D)
		{
			_0023_003Dz5rQzobg_003D = _0023_003DziDLVpbY_003D;
		}
	}

	private static class _0023_003DzId5C3LA_003D
	{
		private delegate _0023_003DzAvn2b38_003D _0023_003Dz437_00244ak_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, out _0023_003DzAvn2b38_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D);

		private delegate void _0023_003Dz5rQzobg_003D<in _0023_003DziDLVpbY_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D);

		private delegate _0023_003DzEWLeis8_003D _0023_003Dz61IPlm0_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D, in _0023_003DzWYPqg2E_003D, out _0023_003DzEWLeis8_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D _0023_003DzWYPqg2E_003D);

		private delegate _0023_003Dz5rQzobg_003D _0023_003Dz8wjMonY_003D<in _0023_003DziDLVpbY_003D, out _0023_003Dz5rQzobg_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D);

		private delegate void _0023_003DzAvn2b38_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D);

		private delegate void _0023_003DzEWLeis8_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D, in _0023_003DzWYPqg2E_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D _0023_003DzWYPqg2E_003D);

		private delegate void _0023_003DzId5C3LA_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D, in _0023_003DzWYPqg2E_003D, in _0023_003DzEWLeis8_003D, in _0023_003DzbfrNXYE_003D, in _0023_003DzkKfJheA_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D _0023_003DzWYPqg2E_003D, _0023_003DzEWLeis8_003D _0023_003DzEWLeis8_003D, _0023_003DzbfrNXYE_003D _0023_003DzbfrNXYE_003D, _0023_003DzkKfJheA_003D _0023_003DzkKfJheA_003D);

		private delegate _0023_003DzWYPqg2E_003D _0023_003DzN6G05Lg_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D, out _0023_003DzWYPqg2E_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D);

		private delegate void _0023_003DzR58imxw_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D);

		private delegate _0023_003DzR58imxw_003D _0023_003DzTSeNR8Q_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, out _0023_003DzR58imxw_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D);

		private delegate void _0023_003DzWYPqg2E_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D);

		private delegate void _0023_003DzbfrNXYE_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D, in _0023_003DzWYPqg2E_003D, in _0023_003DzEWLeis8_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D _0023_003DzWYPqg2E_003D, _0023_003DzEWLeis8_003D _0023_003DzEWLeis8_003D);

		private delegate _0023_003DzkKfJheA_003D _0023_003DzfJFRO2o_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D, in _0023_003DzWYPqg2E_003D, in _0023_003DzEWLeis8_003D, in _0023_003DzbfrNXYE_003D, out _0023_003DzkKfJheA_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D _0023_003DzWYPqg2E_003D, _0023_003DzEWLeis8_003D _0023_003DzEWLeis8_003D, _0023_003DzbfrNXYE_003D _0023_003DzbfrNXYE_003D);

		private delegate void _0023_003DziDLVpbY_003D();

		private delegate _0023_003DzmQTFaQA_003D _0023_003DziP9fFuA_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, out _0023_003DzmQTFaQA_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D);

		private delegate void _0023_003DzkKfJheA_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D, in _0023_003DzWYPqg2E_003D, in _0023_003DzEWLeis8_003D, in _0023_003DzbfrNXYE_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D _0023_003DzWYPqg2E_003D, _0023_003DzEWLeis8_003D _0023_003DzEWLeis8_003D, _0023_003DzbfrNXYE_003D _0023_003DzbfrNXYE_003D);

		private delegate void _0023_003DzmQTFaQA_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D);

		private delegate _0023_003DzbfrNXYE_003D _0023_003DzoMNiNRw_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D, in _0023_003DzWYPqg2E_003D, in _0023_003DzEWLeis8_003D, out _0023_003DzbfrNXYE_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D _0023_003DzWYPqg2E_003D, _0023_003DzEWLeis8_003D _0023_003DzEWLeis8_003D);

		private delegate _0023_003DzId5C3LA_003D _0023_003DzshZYG54_003D<in _0023_003DziDLVpbY_003D, in _0023_003Dz5rQzobg_003D, in _0023_003DzAvn2b38_003D, in _0023_003DzR58imxw_003D, in _0023_003DzmQTFaQA_003D, in _0023_003DzWYPqg2E_003D, in _0023_003DzEWLeis8_003D, in _0023_003DzbfrNXYE_003D, in _0023_003DzkKfJheA_003D, out _0023_003DzId5C3LA_003D>(_0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D _0023_003DzWYPqg2E_003D, _0023_003DzEWLeis8_003D _0023_003DzEWLeis8_003D, _0023_003DzbfrNXYE_003D _0023_003DzbfrNXYE_003D, _0023_003DzkKfJheA_003D _0023_003DzkKfJheA_003D);

		private delegate _0023_003DziDLVpbY_003D _0023_003Dzt_m8zV0_003D<out _0023_003DziDLVpbY_003D>();

		private static readonly Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> m__0023_003DziDLVpbY_003D;

		static _0023_003DzId5C3LA_003D()
		{
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003DzId5C3LA_003D.m__0023_003DziDLVpbY_003D = new Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>>();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static object _0023_003Dz4OPzFUyg_0024rOcLVgUSZiIXf_0024afRjb4srGWRfrjLA_003D(object _0023_003DziDLVpbY_003D, MethodBase _0023_003Dz5rQzobg_003D, out MethodInfo _0023_003DzAvn2b38_003D)
		{
			KeyValuePair<Type, MethodInfo> keyValuePair = _0023_003DzzKOBmcOLTMcNncIYeqR5YJF__00241Xo(_0023_003Dz5rQzobg_003D);
			Delegate result = (Delegate)Activator.CreateInstance(keyValuePair.Key, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D.MethodHandle.GetFunctionPointer());
			_0023_003DzAvn2b38_003D = keyValuePair.Value;
			return result;
		}

		private static KeyValuePair<Type, MethodInfo> _0023_003DzzKOBmcOLTMcNncIYeqR5YJF__00241Xo(MethodBase _0023_003DziDLVpbY_003D)
		{
			lock (_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003DzId5C3LA_003D.m__0023_003DziDLVpbY_003D)
			{
				if (_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003DzId5C3LA_003D.m__0023_003DziDLVpbY_003D.TryGetValue(_0023_003DziDLVpbY_003D, out var value))
				{
					return value;
				}
				Type type = (_0023_003DziDLVpbY_003D as MethodInfo)?.ReturnType ?? _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzbfrNXYE_003D;
				bool flag = type != _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzbfrNXYE_003D;
				ParameterInfo[] parameters = _0023_003DziDLVpbY_003D.GetParameters();
				if (parameters.Length > 9)
				{
					throw new Exception(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907508), parameters.Length));
				}
				Type[] array = new Type[parameters.Length + (flag ? 1 : 0)];
				for (int i = 0; i < parameters.Length; i++)
				{
					Type parameterType = parameters[i].ParameterType;
					if (parameterType.IsByRef || parameterType.IsPointer)
					{
						throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907430));
					}
					array[i] = parameterType;
				}
				if (flag)
				{
					array[^1] = type;
				}
				Type type2 = (flag ? _0023_003DzJBi8HVGwR2DGWVzUe5URTEs_003D(array) : _0023_003Dza2arUi_geUnJBLUofL7Ei94_003D(array));
				MethodInfo method = type2.GetMethod(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907603));
				value = new KeyValuePair<Type, MethodInfo>(type2, method);
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003DzId5C3LA_003D.m__0023_003DziDLVpbY_003D.Add(_0023_003DziDLVpbY_003D, value);
				return value;
			}
		}

		private static Type _0023_003DzJBi8HVGwR2DGWVzUe5URTEs_003D(Type[] _0023_003DziDLVpbY_003D)
		{
			return _0023_003DziDLVpbY_003D.Length switch
			{
				1 => typeof(_0023_003Dzt_m8zV0_003D<>).MakeGenericType(_0023_003DziDLVpbY_003D), 
				2 => typeof(_0023_003Dz8wjMonY_003D<, >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				3 => typeof(_0023_003Dz437_00244ak_003D<, , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				4 => typeof(_0023_003DzTSeNR8Q_003D<, , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				5 => typeof(_0023_003DziP9fFuA_003D<, , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				6 => typeof(_0023_003DzN6G05Lg_003D<, , , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				7 => typeof(_0023_003Dz61IPlm0_003D<, , , , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				8 => typeof(_0023_003DzoMNiNRw_003D<, , , , , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				9 => typeof(_0023_003DzfJFRO2o_003D<, , , , , , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				10 => typeof(_0023_003DzshZYG54_003D<, , , , , , , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				_ => null, 
			};
		}

		private static Type _0023_003Dza2arUi_geUnJBLUofL7Ei94_003D(Type[] _0023_003DziDLVpbY_003D)
		{
			return _0023_003DziDLVpbY_003D.Length switch
			{
				0 => typeof(_0023_003DziDLVpbY_003D), 
				1 => typeof(_0023_003Dz5rQzobg_003D<>).MakeGenericType(_0023_003DziDLVpbY_003D), 
				2 => typeof(_0023_003DzAvn2b38_003D<, >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				3 => typeof(_0023_003DzR58imxw_003D<, , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				4 => typeof(_0023_003DzmQTFaQA_003D<, , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				5 => typeof(_0023_003DzWYPqg2E_003D<, , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				6 => typeof(_0023_003DzEWLeis8_003D<, , , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				7 => typeof(_0023_003DzbfrNXYE_003D<, , , , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				8 => typeof(_0023_003DzkKfJheA_003D<, , , , , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				9 => typeof(_0023_003DzId5C3LA_003D<, , , , , , , , >).MakeGenericType(_0023_003DziDLVpbY_003D), 
				_ => null, 
			};
		}
	}

	private static class _0023_003DzR58imxw_003D
	{
		public static readonly bool _0023_003DziDLVpbY_003D;

		static _0023_003DzR58imxw_003D()
		{
			try
			{
				_0023_003DziDLVpbY_003D = _0023_003DznB5n9I7EwUkkcx5VCmiBEgM_003D();
			}
			catch
			{
				_0023_003DziDLVpbY_003D = false;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _0023_003DznB5n9I7EwUkkcx5VCmiBEgM_003D()
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

	private sealed class _0023_003DzTSeNR8Q_003D<_0023_003DziDLVpbY_003D> : IComparer<KeyValuePair<int, _0023_003DziDLVpbY_003D>>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Comparison<_0023_003DziDLVpbY_003D> _0023_003DziDLVpbY_003D;

		public _0023_003DzTSeNR8Q_003D(Comparison<_0023_003DziDLVpbY_003D> _0023_003DziDLVpbY_003D)
		{
			this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
		}

		public int Compare(KeyValuePair<int, _0023_003DziDLVpbY_003D> _0023_003DziDLVpbY_003D, KeyValuePair<int, _0023_003DziDLVpbY_003D> _0023_003Dz5rQzobg_003D)
		{
			int num = this._0023_003DziDLVpbY_003D(_0023_003DziDLVpbY_003D.Value, _0023_003Dz5rQzobg_003D.Value);
			if (num == 0)
			{
				return _0023_003Dz5rQzobg_003D.Key.CompareTo(_0023_003DziDLVpbY_003D.Key);
			}
			return num;
		}
	}

	private delegate object _0023_003DzWYPqg2E_003D(object _0023_003DziDLVpbY_003D, object[] _0023_003Dz5rQzobg_003D);

	private delegate void _0023_003DzbfrNXYE_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D);

	private static class _0023_003DziDLVpbY_003D
	{
		public static _0023_003DzbfrNXYE_003D _0023_003DziDLVpbY_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz5rQzobg_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzAvn2b38_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzR58imxw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzmQTFaQA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzWYPqg2E_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzEWLeis8_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzbfrNXYE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzkKfJheA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzId5C3LA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzt_m8zV0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzshZYG54_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz8wjMonY_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz437_00244ak_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzTSeNR8Q_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DziP9fFuA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzN6G05Lg_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz61IPlm0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzoMNiNRw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzfJFRO2o_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz0yNzT9M_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzl3DhHgI_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzFmiij5k_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzjbqS1qE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzBJFJHwk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzDNpeQO0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzO_0024iiQ4U_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzhidJeNw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzHit7vU4_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzyk2fsPo_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzWWgGxds_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzDtqAooE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzxmoHVeQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzE8QrneA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzGcl_0024E9o_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzvXOLtKg_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzRpXgovo_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz40R7bAU_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzXrexKjY_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzpGjKR04_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzK_0024fbiW0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzNDQ_E88_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz_eY3Y4c_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzeV5N9i0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzuwH5j5s_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz1v6oPQk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz77g161c_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzQiBkG3c_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzH9VU2k0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzB68dg9Q_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzAYqOj_Y_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzNDN2q2o_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzbbgj2ug_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzid79q24_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzLZPCOtE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzgarqIgM_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzsmnG_0024Pw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzewVWOYw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz8SIpui0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzHfoUx4c_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz1I6x6SE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dza0dzd_g_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzZpYvsQY_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzf8ajBW4_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzqRxZg2s_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz2QVVx8s_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzqdGx8OQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz84e79_A_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzASowvPc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzuavd0rs_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzbKb3e8s_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzoETBmJI_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzN8NFk9A_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzGgKfey0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzhOmsmnE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzYuhN_00245o_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzAqD1TAk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzt_WRa1k_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz0Vs06u0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzqbYd9U4_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzSEAPreM_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzYcilwAA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzYTsLHdI_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzTscnhpk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz4ZkWMQk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz3sEi_MU_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzqeqS8vc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzy9OFgrU_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzJ4YrBuw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzq8bW3fw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzQspsrwQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzKnKylwk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzliCO384_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz1kuO9_w_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzgZHdv7k_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzNFh4IVA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzrtuC07k_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzmUsle0E_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz4OfLwgo_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzqM9Sn_A_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz9KdWmGI_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzEYRJDJs_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzt3zhI74_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzZfhKCX0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzlZ2EkUs_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzK_0024Y_Nd4_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzzmYZ0f0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzBexVt40_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzMnWcwEk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzH0C8Ewc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzfMP2yf8_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz3DflQIc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzPQygtNc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz2SgfTmE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzvMKCVbs_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzOhdXIPc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz_0024q36smI_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzHAesDUo_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzsrjtrJQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzEfxrPgY_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzxCVvHbo_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzxzOTZJ4_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzQhY3lC0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzcOktkYs_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzrunQPrg_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzAQHxNCU_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz_0024OCklCc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzbo_lp2U_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzJt0u35c_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz0vdLLss_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzwu97gS0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzBo2IvAU_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzn0TnzrA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzaf6c79c_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzPv1JAYc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzqUP22VQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzM_GteQk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz1_0024vBImE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzAqw2BjQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzCz_00242d48_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzpbGuOuw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz7gBnFV0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzD47R4_0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzZdPd6ZQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DznijNzwk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzPs8wg9E_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz3fjpBdE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzZW2idpI_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzVFvqE_Y_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzEYwU9Dk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzstAnAPw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzEqy0vIc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzQ0f3KNw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzOQfj4vI_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz9UcoK30_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzePJQjfk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzOi4CcJI_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz9HxCEmA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzc9xbcSw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzbz5dAAk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzSlGxeJk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzEoaRcZw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzEvUQrI0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzc7_pFlk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzwpDJ6Xg_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzR6XBRZw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzzrSNArA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz99o3e4E_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz1dZRnDk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzVHBhWrs_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzWKeuNLk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz61alSec_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzEOtpbcc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzE6TXui0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz4BKUbLs_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzL2rchZk_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz9sdVyIE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzrDAunR8_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzaoAKD8Y_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzxYmA4VA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzT805HFc_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzXgpr_CI_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzeIjHytw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzylMZqAM_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzlWaYL_0024Q_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzjE76fNQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzKlu7TUw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzkcCZFFw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DztFFtzuA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzCAS7SAA_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzE5gt1ko_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzBW_0024a6Uo_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzxH_6YFw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz9bKO1YQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dztcdhsic_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzJ8yEPpo_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz_0024TNCdoE_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dz0cKkDvw_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003Dzs989QDY_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzvQQcj9c_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzJ3z_9rg_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzPYVdveQ_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzvPZnhP0_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzuaCnQ5A_003D;

		public static _0023_003DzbfrNXYE_003D _0023_003DzYkWM45g_003D;
	}

	private struct _0023_003DzkKfJheA_003D(_0023_003DqVcjta0_jSHC_KNEfba3YbiYuOWLGbSZvN9lBLf9PmF0_003D _0023_003DziDLVpbY_003D, _0023_003DzbfrNXYE_003D _0023_003Dz5rQzobg_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly byte _0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D._0023_003Dzzgd_DblyNmOXsrLr8kvnTr_7GEWDe0l5m50ub8T2g6sA();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly _0023_003DzbfrNXYE_003D _0023_003Dz5rQzobg_003D = _0023_003Dz5rQzobg_003D;
	}

	private struct _0023_003DzmQTFaQA_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly uint _0023_003DziDLVpbY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly object _0023_003Dz5rQzobg_003D;

		public _0023_003DzmQTFaQA_003D(uint _0023_003DziDLVpbY_003D)
		{
			this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
			_0023_003Dz5rQzobg_003D = null;
		}

		public _0023_003DzmQTFaQA_003D(uint _0023_003DziDLVpbY_003D, object _0023_003Dz5rQzobg_003D)
		{
			this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
			this._0023_003Dz5rQzobg_003D = _0023_003Dz5rQzobg_003D;
		}

		[_0023_003DqQgR1JoCNy7ZrkrY2CEnHspFPtHDgFiVcGrGoOuUp5vI_003D]
		public uint _0023_003DzKa4gcSzQnqPstmrk1_0024FE9i7M1ChN()
		{
			return _0023_003DziDLVpbY_003D;
		}

		[_0023_003DqQgR1JoCNy7ZrkrY2CEnHspFPtHDgFiVcGrGoOuUp5vI_003D]
		public object _0023_003Dzrsahh8JhH1FOm_5VlQ5oZaE_003D()
		{
			return _0023_003Dz5rQzobg_003D;
		}
	}

	private struct _0023_003DzshZYG54_003D(MethodBase _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D) : IEquatable<_0023_003DzshZYG54_003D>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly MethodBase _0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly bool _0023_003Dz5rQzobg_003D = _0023_003Dz5rQzobg_003D;

		[_0023_003DqQgR1JoCNy7ZrkrY2CEnHspFPtHDgFiVcGrGoOuUp5vI_003D]
		public MethodBase _0023_003DzSCazhnWLtFwbNXNkU4fvLsOlmtlQpVMJL_6R00w_003D()
		{
			return _0023_003DziDLVpbY_003D;
		}

		[_0023_003DqQgR1JoCNy7ZrkrY2CEnHspFPtHDgFiVcGrGoOuUp5vI_003D]
		public bool _0023_003Dz39unlxS1lk4RllUZRdoKvXOiRnGEXvZy7cYTnc8_003D()
		{
			return _0023_003Dz5rQzobg_003D;
		}

		public override int GetHashCode()
		{
			return _0023_003DzSCazhnWLtFwbNXNkU4fvLsOlmtlQpVMJL_6R00w_003D().GetHashCode() ^ _0023_003Dz39unlxS1lk4RllUZRdoKvXOiRnGEXvZy7cYTnc8_003D().GetHashCode();
		}

		public override bool Equals(object _0023_003DziDLVpbY_003D)
		{
			if (_0023_003DziDLVpbY_003D is _0023_003DzshZYG54_003D _0023_003DzshZYG54_003D2)
			{
				return Equals(_0023_003DzshZYG54_003D2);
			}
			return false;
		}

		public bool Equals(_0023_003DzshZYG54_003D _0023_003DziDLVpbY_003D)
		{
			if (_0023_003DzSCazhnWLtFwbNXNkU4fvLsOlmtlQpVMJL_6R00w_003D() == _0023_003DziDLVpbY_003D._0023_003DzSCazhnWLtFwbNXNkU4fvLsOlmtlQpVMJL_6R00w_003D())
			{
				return _0023_003Dz39unlxS1lk4RllUZRdoKvXOiRnGEXvZy7cYTnc8_003D() == _0023_003DziDLVpbY_003D._0023_003Dz39unlxS1lk4RllUZRdoKvXOiRnGEXvZy7cYTnc8_003D();
			}
			return false;
		}
	}

	private static class _0023_003Dzt_m8zV0_003D
	{
		private static readonly Dictionary<MethodBase, MethodInfo> _0023_003DziDLVpbY_003D = new Dictionary<MethodBase, MethodInfo>();

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase _0023_003DzQY9CYytncsDwLeAt0AmxSpKqJpC5o35QIg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D _0023_003Dz5rQzobg_003D, MethodBase _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
		{
			lock (_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003Dzt_m8zV0_003D._0023_003DziDLVpbY_003D)
			{
				if (_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003Dzt_m8zV0_003D._0023_003DziDLVpbY_003D.TryGetValue(_0023_003DzAvn2b38_003D, out var value))
				{
					return value;
				}
				Type returnType = ((!(_0023_003DzAvn2b38_003D is MethodInfo methodInfo)) ? _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzbfrNXYE_003D : methodInfo.ReturnType);
				ParameterInfo[] parameters = _0023_003DzAvn2b38_003D.GetParameters();
				Type[] array;
				if (_0023_003DzAvn2b38_003D.IsStatic)
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
					Type type = _0023_003DzAvn2b38_003D.DeclaringType;
					if (type.IsValueType)
					{
						type = type.MakeByRefType();
						_0023_003DzR58imxw_003D = false;
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
					value = new DynamicMethod(empty, returnType, array, _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003Dz5rQzobg_003D._0023_003Dzx5X59GHDhQCY67nsHADQ8HctXRx6EilYiQ_003D_003D(), _0023_003Dz5rQzobg_003D: true), skipVisibility: true);
				}
				ILGenerator iLGenerator = ((DynamicMethod)value).GetILGenerator();
				for (int k = 0; k < array.Length; k++)
				{
					iLGenerator.Emit(OpCodes.Ldarg, k);
				}
				if (_0023_003DzAvn2b38_003D is ConstructorInfo con)
				{
					iLGenerator.Emit(_0023_003DzR58imxw_003D ? OpCodes.Callvirt : OpCodes.Call, con);
				}
				else
				{
					iLGenerator.Emit(_0023_003DzR58imxw_003D ? OpCodes.Callvirt : OpCodes.Call, (MethodInfo)_0023_003DzAvn2b38_003D);
				}
				iLGenerator.Emit(OpCodes.Ret);
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003Dzt_m8zV0_003D._0023_003DziDLVpbY_003D.Add(_0023_003DzAvn2b38_003D, value);
				return value;
			}
		}
	}

	private static Type _0023_003Dz40R7bAU_003D;

	private long _0023_003DzGcl_0024E9o_003D;

	private readonly Module m__0023_003DzshZYG54_003D;

	private _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D[] _0023_003DzjbqS1qE_003D;

	private Type[] _0023_003DzFmiij5k_003D;

	private _0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D m__0023_003DzTSeNR8Q_003D;

	private object _0023_003Dzl3DhHgI_003D;

	private static Type _0023_003DzN6G05Lg_003D;

	private readonly _0023_003DqN8nLWt7PRO2_0024YeQsFrvqJaHzlAjPhcpBYohGahsQEHA_003D _0023_003DzXrexKjY_003D;

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D m__0023_003DzmQTFaQA_003D;

	private Type[] m__0023_003DzR58imxw_003D;

	private static readonly Dictionary<_0023_003DzshZYG54_003D, _0023_003DzWYPqg2E_003D> _0023_003DzhidJeNw_003D = new Dictionary<_0023_003DzshZYG54_003D, _0023_003DzWYPqg2E_003D>(256);

	private bool m__0023_003DzWYPqg2E_003D;

	private readonly Stack<_0023_003DzmQTFaQA_003D> m__0023_003DziDLVpbY_003D = new Stack<_0023_003DzmQTFaQA_003D>();

	private static readonly Dictionary<int, object> _0023_003DzHit7vU4_003D;

	private Type _0023_003DzBJFJHwk_003D;

	private static Type _0023_003DzDtqAooE_003D;

	private static Type m__0023_003Dz5rQzobg_003D;

	private readonly Stack<_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D> _0023_003DzoMNiNRw_003D = new Stack<_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D>(16);

	private static readonly Dictionary<MethodBase, int> m__0023_003DzAvn2b38_003D;

	private _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003Dz0yNzT9M_003D;

	private Stream m__0023_003DzEWLeis8_003D;

	private static Type m__0023_003Dz437_00244ak_003D;

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzE8QrneA_003D;

	private object[] m__0023_003DzkKfJheA_003D;

	private static Type m__0023_003DzbfrNXYE_003D;

	private bool _0023_003DzfJFRO2o_003D;

	private _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziP9fFuA_003D;

	private static Type _0023_003DzDNpeQO0_003D;

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] m__0023_003Dzt_m8zV0_003D;

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] _0023_003Dzyk2fsPo_003D;

	private byte[] m__0023_003DzId5C3LA_003D;

	private Stack<_0023_003Dz437_00244ak_003D> _0023_003DzO_0024iiQ4U_003D;

	private uint? _0023_003DzxmoHVeQ_003D;

	private static object _0023_003DzRpXgovo_003D = new object();

	private uint m__0023_003Dz8wjMonY_003D;

	private static Dictionary<int, _0023_003DzkKfJheA_003D> _0023_003Dz61IPlm0_003D;

	private uint _0023_003DzWWgGxds_003D;

	private static readonly Dictionary<MethodBase, object> _0023_003DzpGjKR04_003D;

	private uint _0023_003DzvXOLtKg_003D;

	public _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D(_0023_003DqN8nLWt7PRO2_0024YeQsFrvqJaHzlAjPhcpBYohGahsQEHA_003D _0023_003DziDLVpbY_003D, Module _0023_003Dz5rQzobg_003D)
	{
		_0023_003DzXrexKjY_003D = _0023_003DziDLVpbY_003D;
		this.m__0023_003DzshZYG54_003D = _0023_003Dz5rQzobg_003D;
		_0023_003DzReNy_ltodLMk8iSxxnoAPPI6Z_0024U3Qa8_0024jw_003D_003D();
	}

	public _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D(_0023_003DqN8nLWt7PRO2_0024YeQsFrvqJaHzlAjPhcpBYohGahsQEHA_003D _0023_003DziDLVpbY_003D)
		: this(_0023_003DziDLVpbY_003D, typeof(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D).Module)
	{
	}

	static _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D()
	{
		_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzAvn2b38_003D = new Dictionary<MethodBase, int>(256);
		_0023_003DzpGjKR04_003D = new Dictionary<MethodBase, object>();
		_0023_003DzHit7vU4_003D = new Dictionary<int, object>();
		_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003Dz437_00244ak_003D = typeof(_0023_003Dz8wjMonY_003D);
		_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzbfrNXYE_003D = typeof(void);
		_0023_003DzN6G05Lg_003D = typeof(object[]);
		_0023_003DzDNpeQO0_003D = typeof(IntPtr);
		_0023_003DzDtqAooE_003D = typeof(Assembly);
		_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003Dz5rQzobg_003D = typeof(MethodBase);
		_0023_003Dz40R7bAU_003D = typeof(RuntimeHelpers);
	}

	private void _0023_003DzJAojZB2QIuH_jIxrACIzvilaDqHq(bool _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dz27o8WeFt2ozgeEqJvBNs8AnRaPziTpHvag_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D));
	}

	private static void _0023_003DzWLTb2pZoJDz0eIRFw_MrwjLc8FVxb3xlmc_0024_1_4A21qs(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		bool flag = false;
		if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() == 0, 
			13 => ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() == 0, 
			0 => ((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee() == IntPtr.Zero, 
			20 => ((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D() == UIntPtr.Zero, 
			7 => ((_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzP7k5Y6ukvcg_ixjUAKpLm2Y7IkNc3hTJEKeYFNObePLS() == null, 
			19 => !Convert.ToBoolean(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			_ => _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == null, 
		})
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private static void _0023_003Dz0Hf5cWDTnbY_0024d22_lrZrv_i72i0CP5IiPTe_0024dlQ_003D(Exception _0023_003DziDLVpbY_003D)
	{
		ExceptionDispatchInfo.Capture(_0023_003DziDLVpbY_003D).Throw();
	}

	private static void _0023_003DzkElEvIVypfNtM1gCSk7rh_ns6mhfRTjrrA_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		FieldInfo fieldInfo = _0023_003DziDLVpbY_003D._0023_003DzsH6I9ZDv5gPH5Am4bCK2nNxE2uzwyQ3uDe_00241OaRt2yRO(num);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D(fieldInfo, null));
	}

	private static void _0023_003DzPV70hKPecs9DfliYp0x9xCwoEOyrz5sLXQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz_zeDwWgrLqWqj6ECFFPZ7JQ_003D(((_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzwyKpuA_mNwWyADXJn6Q3N8s_003D());
	}

	private static void _0023_003DzBz0afg9Y8y0GGHawiMgEhDdBfuU0f1Xmng_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		checked
		{
			_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
			{
				1 => unchecked((uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), 
				13 => (long)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
				19 => (long)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
				8 => (long)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
				0 => (IntPtr.Size != 4) ? ((long)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : unchecked((uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
				_ => throw new InvalidOperationException(), 
			}));
		}
	}

	private void _0023_003DzvR_c2pbCw0UL9VDVLLpeUCzicJ3e(bool _0023_003DziDLVpbY_003D)
	{
		uint num = _0023_003DzvXOLtKg_003D;
		while (true)
		{
			try
			{
				while (!_0023_003DzfJFRO2o_003D)
				{
					if (_0023_003DzxmoHVeQ_003D.HasValue)
					{
						_0023_003DzWWgGxds_003D = _0023_003DzxmoHVeQ_003D.Value;
						_0023_003Dzo3_0024JD29gQ7XumqZQHo8tWU0_003D(_0023_003DzWWgGxds_003D);
						_0023_003DzxmoHVeQ_003D = null;
					}
					else if (_0023_003DzWWgGxds_003D >= num)
					{
						break;
					}
					_0023_003DzmWaS3k7fg9fLijZ1PD_0024zmcebsLUJ();
				}
				break;
			}
			catch (object obj)
			{
				_0023_003DzJ_0024HvPm_Ti0SZUguFjk9lMjv31F9kzigDH8FeRyY_003D(obj, 0u);
				if (!_0023_003DziDLVpbY_003D)
				{
					_0023_003DzvR_c2pbCw0UL9VDVLLpeUCzicJ3e(_0023_003DziDLVpbY_003D: true);
					break;
				}
			}
		}
	}

	private void _0023_003DzReNy_ltodLMk8iSxxnoAPPI6Z_0024U3Qa8_0024jw_003D_003D()
	{
		if (!_0023_003DzXrexKjY_003D._0023_003DzD0GqqFJEDUdSVm5DqGqrsNaii2XshV3ihw_003D_003D())
		{
			lock (_0023_003DzXrexKjY_003D)
			{
				if (!_0023_003DzXrexKjY_003D._0023_003DzD0GqqFJEDUdSVm5DqGqrsNaii2XshV3ihw_003D_003D())
				{
					_0023_003Dz61IPlm0_003D = _0023_003DzLAqK4qg99S4Lfp7hae_eWjWSwPq7(_0023_003DzXrexKjY_003D);
					_0023_003DzwN3jKP8RF7Y_0024fuRAYM1m3AvyXJT_00245xdFKg_003D_003D();
					_0023_003DzXrexKjY_003D._0023_003DzfVSYUJYla0jQHHT2zuqQhE5u11R9(_0023_003DziDLVpbY_003D: true);
				}
			}
		}
		if (_0023_003Dz61IPlm0_003D == null)
		{
			_0023_003Dz61IPlm0_003D = _0023_003DzLAqK4qg99S4Lfp7hae_eWjWSwPq7(_0023_003DzXrexKjY_003D);
		}
	}

	private static void _0023_003Dz0V9F1D81BccTkI_jTvVFjKjCDXC_0024IlJPXQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908537));
	}

	private static void _0023_003DzPF8nEd3Ue1oD1WYq5CaMZE3CMGmzm3xqyf_49Xg_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dzl3DhHgI_003D == null)
		{
			throw new InvalidOperationException();
		}
		_0023_003DziDLVpbY_003D._0023_003DzBobqTgiv7_0024qJTDQ7T1G4q1vlSWRN(_0023_003DziDLVpbY_003D._0023_003Dzl3DhHgI_003D);
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzpnBsbGvBvIQo6W6rrfRBrBxppTT_0024hu1nKg_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				if (!_0023_003DzAvn2b38_003D)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num >> num2);
				}
				int num3 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				int num4 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num3 >>> num4);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003DzpnBsbGvBvIQo6W6rrfRBrBxppTT_0024hu1nKg_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				if (!_0023_003DzAvn2b38_003D)
				{
					long num5 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
					int num6 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num5 >> num6);
				}
				long num7 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				int num8 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num7 >>> num8);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003DzpnBsbGvBvIQo6W6rrfRBrBxppTT_0024hu1nKg_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzpnBsbGvBvIQo6W6rrfRBrBxppTT_0024hu1nKg_003D_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			}
			return _0023_003DzpnBsbGvBvIQo6W6rrfRBrBxppTT_0024hu1nKg_003D_003D(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003Dzrr6Ay9h1vzwYckPYlyUYxI6FI7iU(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(5);
	}

	private static void _0023_003Dz3xnJZk0tsFncy7HfhEzqMZA_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D _0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D2 = (_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D)_0023_003Dz5rQzobg_003D;
		_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D obj = new _0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D();
		obj._0023_003Dz9U5c5UHrGsdu41UMG8qS86WqQ5Xq(_0023_003DziDLVpbY_003D._0023_003Dzyk2fsPo_003D[_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D2._0023_003DzwyKpuA_mNwWyADXJn6Q3N8s_003D()]);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzjVzO5UR0YUtHT_0024LzWi_0024gXSR8ejzL(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D();
				obj._0023_003DzI9gf1jAlM5PPTe_0024AK_G6hL0Q8r0D(num & num2);
				return obj;
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				int num3 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num3 & num4);
				}
				int num5 = Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj2 = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D();
				obj2._0023_003DzI9gf1jAlM5PPTe_0024AK_G6hL0Q8r0D(num3 & num5);
				return obj2;
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				long num6 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				long num7 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D obj3 = new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D();
				obj3._0023_003Dzy6HyfSoNxN_JAsWz2P6G9bk_003D(num6 & num7);
				return obj3;
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				int num8 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				long num9 = Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num8 & num9);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				int num10 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D()) & num10);
				}
				int num11 = Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj4 = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D();
				obj4._0023_003DzI9gf1jAlM5PPTe_0024AK_G6hL0Q8r0D(num11 & num10);
				return obj4;
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				long num12 = Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				long num13 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D obj5 = new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D();
				obj5._0023_003Dzy6HyfSoNxN_JAsWz2P6G9bk_003D(num12 & num13);
				return obj5;
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num14 = Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					long num15 = Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num14 & num15);
				}
				int num16 = Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				int num17 = Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num16 & num17);
			}
		}
		throw new InvalidOperationException();
	}

	private bool _0023_003DziEgqrdGGMod4268Ci8jWLdI_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DziDLVpbY_003D._0023_003DzddbcHyilBA8MndTeiRwzcmFqKumQ().IsInitOnly)
		{
			return true;
		}
		if (_0023_003DziDLVpbY_003D._0023_003DzddbcHyilBA8MndTeiRwzcmFqKumQ().IsStatic != m__0023_003DzTSeNR8Q_003D._0023_003DzEuJfM2g1v8Mcj9WVg4SiajPXq2cE())
		{
			return false;
		}
		if (m__0023_003DzTSeNR8Q_003D._0023_003DzEuJfM2g1v8Mcj9WVg4SiajPXq2cE() && m__0023_003DzTSeNR8Q_003D._0023_003DzFMr9dCVbs1HItIt4Lt5pQGuApOTN() != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908944))
		{
			return false;
		}
		Type type = _0023_003DziDLVpbY_003D._0023_003DzddbcHyilBA8MndTeiRwzcmFqKumQ().DeclaringType;
		if (type.IsGenericType)
		{
			type = type.GetGenericTypeDefinition();
		}
		return _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(m__0023_003DzTSeNR8Q_003D._0023_003Dzx5X59GHDhQCY67nsHADQ8HctXRx6EilYiQ_003D_003D(), _0023_003Dz5rQzobg_003D: true) == type;
	}

	private static void _0023_003DzYwykTfMEz6ZQUkdnn7kw50jTZi2T6SAkKOeTlLvCDnEL(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		Array array = (Array)_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(array.Length));
	}

	private void _0023_003Dzo3_0024JD29gQ7XumqZQHo8tWU0_003D(long _0023_003DziDLVpbY_003D)
	{
		_0023_003DziP9fFuA_003D._0023_003DzUXjbc9BY9W9m2seLWnn7jsJDEathvvwviQ_003D_003D()._0023_003DzQZ8To03pqmaE0_0024_s_0024MPn8tSR4QVXl_JNjN3rTa3mIQ_UWPJ027H8ZJC6fkO7HSABoir32uY_003D(_0023_003DziDLVpbY_003D - _0023_003DzGcl_0024E9o_003D);
	}

	private bool _0023_003Dz5z_hyFyh6I1JQF_w5njQIzDJmgi9UokI1A_003D_003D(MethodBase _0023_003DziDLVpbY_003D, object _0023_003Dz5rQzobg_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] _0023_003DzAvn2b38_003D, object[] _0023_003DzR58imxw_003D, bool _0023_003DzmQTFaQA_003D, ref object _0023_003DzWYPqg2E_003D)
	{
		Type declaringType = _0023_003DziDLVpbY_003D.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (declaringType == _0023_003Dz40R7bAU_003D && _0023_003DziDLVpbY_003D.Name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909179) && _0023_003DzR58imxw_003D.Length == 2 && _0023_003DziDLVpbY_003D.ToString() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909137))
		{
			_0023_003DqcPNgWZrHWoJl5uLGrkFcm2c_D_00245ujNN_00244GiKUUxtPwY_003D._0023_003DzjkWL_2xEpBYUoFMOOlXQ8BP24YR4((Array)_0023_003DzR58imxw_003D[0], (RuntimeFieldHandle)_0023_003DzR58imxw_003D[1]);
			return true;
		}
		return false;
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz00AhOF3fCtaT9RBe7pDI_0024dDnP1r2xP_7uCOaiJsp1AY4(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				if (!_0023_003DzAvn2b38_003D)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num % num2);
				}
				int num3 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				uint num4 = (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D((int)((uint)num3 % num4));
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003Dzb3wlRP4tdSNVDaJlG1f9UKj4OWfOXqv7uObBzU0_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003Dzb3wlRP4tdSNVDaJlG1f9UKj4OWfOXqv7uObBzU0_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
				}
				return _0023_003Dz00AhOF3fCtaT9RBe7pDI_0024dDnP1r2xP_7uCOaiJsp1AY4(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003Dzb3wlRP4tdSNVDaJlG1f9UKj4OWfOXqv7uObBzU0_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				return _0023_003Dzb3wlRP4tdSNVDaJlG1f9UKj4OWfOXqv7uObBzU0_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003DzAvn2b38_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003Dzb3wlRP4tdSNVDaJlG1f9UKj4OWfOXqv7uObBzU0_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
				}
				return _0023_003Dzb3wlRP4tdSNVDaJlG1f9UKj4OWfOXqv7uObBzU0_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8 && _0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8)
		{
			_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
			obj._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D() % ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D());
			return obj;
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003Dz00AhOF3fCtaT9RBe7pDI_0024dDnP1r2xP_7uCOaiJsp1AY4(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			}
			return _0023_003Dz00AhOF3fCtaT9RBe7pDI_0024dDnP1r2xP_7uCOaiJsp1AY4(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
		}
		throw new InvalidOperationException();
	}

	private static bool _0023_003Dz6HPSY_0024zpefu_0024sPp4tcYcOC6YvaQ_H1xKIg_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		bool result = false;
		switch (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
		{
		case 1:
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003Dz6HPSY_0024zpefu_0024sPp4tcYcOC6YvaQ_H1xKIg_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())));
			}
			result = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() < ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
			break;
		case 13:
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003Dz6HPSY_0024zpefu_0024sPp4tcYcOC6YvaQ_H1xKIg_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())));
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				return _0023_003Dz6HPSY_0024zpefu_0024sPp4tcYcOC6YvaQ_H1xKIg_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()));
			}
			result = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() < ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			break;
		case 19:
			return _0023_003Dz6HPSY_0024zpefu_0024sPp4tcYcOC6YvaQ_H1xKIg_003D_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DziDLVpbY_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), _0023_003Dz5rQzobg_003D);
		case 8:
			result = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D() < ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			break;
		}
		return result;
	}

	private MethodBase _0023_003DzBhJjluw81_HkWgBTK6EEN9EmMaMNOpnEBVrzub4_003D(_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D _0023_003DziDLVpbY_003D)
	{
		Type type = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003DziDLVpbY_003D._0023_003DzV0iv8Q9KOWeQbFeld4Ijr5RweOxnDgHv5UPRKwY_003D()._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p(), _0023_003Dz5rQzobg_003D: false);
		BindingFlags bindingAttr = _0023_003DzywBQyeN0kvmSlw6Yu1_0024kgx_0024lqk6alGjr4A_003D_003D(_0023_003DziDLVpbY_003D._0023_003Dzdmr3ulD800U42xZUUNfxw5s_003D());
		Type[] array = null;
		_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D[] array2 = _0023_003DziDLVpbY_003D._0023_003DzzetAtAYHtCQBku1Ez7JzQfSjQHSLJPus59etvPc_003D();
		if (array2 != null)
		{
			array = new Type[array2.Length];
			for (int i = 0; i < array.Length; i++)
			{
				_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 = array2[i];
				if (_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 != null)
				{
					array[i] = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p(), _0023_003Dz5rQzobg_003D: true);
				}
			}
		}
		MemberInfo[] member = type.GetMember(_0023_003DziDLVpbY_003D._0023_003Dzv0a3e_JnkHiTcgqmTRDr_0024AJGhiwL(), MemberTypes.Method, bindingAttr);
		MethodInfo methodInfo = null;
		int num = -1;
		MemberInfo[] array3 = member;
		for (int j = 0; j < array3.Length; j++)
		{
			MethodInfo methodInfo2 = (MethodInfo)array3[j];
			if (_0023_003DzW4gJFzQX7i_0024q1rfO9DorcU0_003D(methodInfo2, _0023_003DziDLVpbY_003D, array, out var num2) && num2 > num)
			{
				methodInfo = methodInfo2;
				num = num2;
			}
		}
		if (methodInfo == null)
		{
			throw new Exception(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908239), type.Name, _0023_003DziDLVpbY_003D._0023_003Dzv0a3e_JnkHiTcgqmTRDr_0024AJGhiwL()));
		}
		return methodInfo.MakeGenericMethod(array);
	}

	private void _0023_003DzJ_0024HvPm_Ti0SZUguFjk9lMjv31F9kzigDH8FeRyY_003D(object _0023_003DziDLVpbY_003D, uint _0023_003Dz5rQzobg_003D)
	{
		bool flag = _0023_003DziDLVpbY_003D != null;
		_0023_003Dzl3DhHgI_003D = _0023_003DziDLVpbY_003D;
		if (flag)
		{
			this.m__0023_003DziDLVpbY_003D.Clear();
		}
		this.m__0023_003DzWYPqg2E_003D = flag;
		if (!flag)
		{
			this.m__0023_003DziDLVpbY_003D.Push(new _0023_003DzmQTFaQA_003D(_0023_003Dz5rQzobg_003D));
		}
		_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D[] array = _0023_003DzjbqS1qE_003D;
		foreach (_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2 in array)
		{
			if (!_0023_003Dz8a7SqHy53Zb1B_LJHMe3m40_003D(this.m__0023_003Dz8wjMonY_003D, _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK(), _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzrRpn5KHjaIKRa2Vs_0024HZe4YswX1zq_0024V2Y6w_003D_003D()))
			{
				continue;
			}
			switch (_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzMcEtR3XgHPnchTSkujdAN3rl0vMhfBHLsKqdGU_nBNai())
			{
			case 2:
				if (flag || !_0023_003Dz8a7SqHy53Zb1B_LJHMe3m40_003D(_0023_003Dz5rQzobg_003D, _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK(), _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzrRpn5KHjaIKRa2Vs_0024HZe4YswX1zq_0024V2Y6w_003D_003D()))
				{
					this.m__0023_003DziDLVpbY_003D.Push(new _0023_003DzmQTFaQA_003D(_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzDfsDQRpUwM_0024PVAMLxw_003D_003D()));
				}
				break;
			case 1:
				if (flag)
				{
					this.m__0023_003DziDLVpbY_003D.Push(new _0023_003DzmQTFaQA_003D(_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzDfsDQRpUwM_0024PVAMLxw_003D_003D()));
				}
				break;
			case 4:
				if (flag)
				{
					this.m__0023_003DziDLVpbY_003D.Push(new _0023_003DzmQTFaQA_003D(_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzsezgIxL0wRp5ra1guguLpPk_003D(), _0023_003DziDLVpbY_003D));
				}
				break;
			case 0:
				if (flag)
				{
					Type type = _0023_003DziDLVpbY_003D.GetType();
					Type type2 = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzMIl8NkNU9rmkDgmjF8alsLs5XV_RvEW08w_003D_003D(), _0023_003Dz5rQzobg_003D: true);
					if (type == type2 || type.IsSubclassOf(type2))
					{
						this.m__0023_003DziDLVpbY_003D.Push(new _0023_003DzmQTFaQA_003D(_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzDfsDQRpUwM_0024PVAMLxw_003D_003D(), _0023_003DziDLVpbY_003D));
						this.m__0023_003DzWYPqg2E_003D = false;
					}
				}
				break;
			}
		}
		_0023_003DzYoHr_kaBP_0024C0cQWQednER91YDBHg();
	}

	private static bool _0023_003Dz9431O5LYjS8OrBgd0jywjR545Xki(object _0023_003DziDLVpbY_003D)
	{
		return RemotingServices.IsTransparentProxy(_0023_003DziDLVpbY_003D);
	}

	private static void _0023_003DzpXezgpIkxOlvuRaZlChG5D4u_wD5LWTlyQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz1ktQDyYgVRcDWtIkyhgZ1BaKF8X_ZGGS4A_003D_003D(_0023_003DziDLVpbY_003D: true);
	}

	private static void _0023_003DzP9wxLM15P5Rjd4ncOg0GwhEjEDGye4DU3g_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D _0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D2 = _0023_003DzKsNYm96Lj47ScEelzMJ01rs_0024SUcn(_0023_003DziDLVpbY_003D);
		_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D2 = _0023_003DziDLVpbY_003D._0023_003DziP9fFuA_003D._0023_003DzUXjbc9BY9W9m2seLWnn7jsJDEathvvwviQ_003D_003D();
		long num = _0023_003DziDLVpbY_003D._0023_003Dzc7lqRph1KlhUyDXq3k2To_Q_003D();
		byte[] array = new _0023_003Dq0svfXwLBXz8_0024BQss65LvE_0024cL_kRdO4CyORGuScf95Cw_003D(_0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D2._0023_003DzV2W13tDWeJi_0024xI4BmLnkJNT6g6r1CaNuhOk3BN7pYJlEz7haKVNoYGujcPm85NKQ0DC0zdQV0DV2zAho1w_003D_003D(), _0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D2._0023_003DzjO9i_WtKdAO6N9SD83hoa7HPxgZcyen7iBCZTWPoFEe2VLt7rylbICQSPYHluldGNdGGAZuays2lz860GydauDs_003D())._0023_003DzkV_0024NPHJtkeR5aZj4lW5jyPw059xj(_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D2, _0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D2);
		_0023_003Dz437_00244ak_003D _0023_003Dz437_00244ak_003D2 = new _0023_003Dz437_00244ak_003D
		{
			_0023_003DziDLVpbY_003D = _0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D2,
			_0023_003DzR58imxw_003D = num
		};
		_0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D2._0023_003DzKpaA2SHtkeg8sK9Q6J2UADw9wzsUG1KRH42llpY_003D(_0023_003DqpJzGvS9BBRbFYdUqQrKHOE18bcoZMb86GgAobmFLd5A_003D._0023_003DzDBXut6tCvgc0S1YNOJSraJU_003D(array.Length) - array.Length);
		_0023_003Dz437_00244ak_003D2._0023_003Dz5rQzobg_003D = new _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D(_0023_003Dz437_00244ak_003D2._0023_003DzAvn2b38_003D = new _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D(array, 0, array.Length, _0023_003DzR58imxw_003D: false));
		_0023_003DziDLVpbY_003D._0023_003DzmhNPwvYqeFIwGaYvUVC5r3pbe1W7().Push(_0023_003Dz437_00244ak_003D2);
		_0023_003DziDLVpbY_003D._0023_003DzF92XqHWM0mt_1xTngiTEH1HG1JGphapjovJeugQ_003D(_0023_003Dz437_00244ak_003D2);
	}

	private static void _0023_003Dzfj6_WsOE_0024nlEe0Ca07eRcRJZbgib(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzu0a9M9zXrZOr09UDVft0TcHevaFuOoyqag_003D_003D(0);
	}

	private static void _0023_003Dzail2JRd0zY19V0vIvs870iaYOJXS(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(4);
	}

	private static void _0023_003DzyuJikjH7anI_a6JxCCehy7g_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz0LZ3a2KNB2rgSf490RJHmy0_003D(2);
	}

	private static void _0023_003DzCxaByjPMo_zCGxnHCv6pQfc_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
	}

	private string _0023_003Dzd8NJjsIuNdDkK_0024Oj3YmRtDVRGwvLj5FHfBcM_0024LcoOJbt(int _0023_003DziDLVpbY_003D)
	{
		lock (_0023_003DzHit7vU4_003D)
		{
			bool flag = true;
			if (flag && _0023_003DzHit7vU4_003D.TryGetValue(_0023_003DziDLVpbY_003D, out var value))
			{
				return (string)value;
			}
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 = _0023_003DzLrd1XNI9dc0qU09uargDhdLHbDdl(_0023_003DziDLVpbY_003D);
			if (_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003DzOl4znCSQJV_o3jzYnD1EuZw5Wuu52ADXGg_003D_003D() == 0)
			{
				return this.m__0023_003DzshZYG54_003D.ResolveString(_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p());
			}
			string text = ((_0023_003DqM_0024kYe1N44aB_zQkdFrLc4AeQC8UfF2AAUn80a0CP3TU_003D)_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003DzpKaM9DJ9LSi0XInJkPIbPujKUbSQ())._0023_003DzC1Mi_AHWzIKrPig7TKI65dOvxY5gLW4iNA_003D_003D();
			if (flag)
			{
				_0023_003DzHit7vU4_003D.Add(_0023_003DziDLVpbY_003D, text);
			}
			return text;
		}
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziOyAZyrnhvMXTbVIv78SGaaMnLAOmEgk9A_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num ^ num2);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				int num3 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num3 ^ num4);
				}
				int num5 = Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num3 ^ num5);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				long num6 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				long num7 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num6 ^ num7);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				int num8 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				long num9 = Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num8 ^ num9);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				int num10 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D()) ^ num10);
				}
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D()) ^ num10);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				long num11 = Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				long num12 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num11 ^ num12);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num13 = Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					long num14 = Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num13 ^ num14);
				}
				int num15 = Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				int num16 = Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num15 ^ num16);
			}
		}
		throw new InvalidOperationException();
	}

	private void _0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D()
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 = (_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D)_0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
	}

	private void _0023_003Dz4Sg2qQARqp7k5eIqIZ_ETNk_003D(_0023_003DqNWCS8MTqiZMgZBpc9rePoD3Tf6ok_0024uTUh8pwkfYpM1M_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 = _0023_003DzLrd1XNI9dc0qU09uargDhdLHbDdl(_0023_003DziDLVpbY_003D._0023_003DzZW1cv77YeHAhq8fx_0024tcb75feh38ZSc25Sg_003D_003D());
		MethodBase methodBase = _0023_003DzxFCw4O0oSzz4ae_0024c90eLINeyH_agUXkmxGBC2IA_003D(_0023_003DziDLVpbY_003D._0023_003DzZW1cv77YeHAhq8fx_0024tcb75feh38ZSc25Sg_003D_003D(), _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2);
		int num = _0023_003DziDLVpbY_003D._0023_003DzNDtrCGy_H_rwOQZQ3gRLdjVUwRoFWlM2LO5zW8Q_003D();
		bool flag = (num & 0x40000000) != 0;
		num &= -1073741825;
		Type[] array = _0023_003DzFmiij5k_003D;
		Type[] array2 = this.m__0023_003DzR58imxw_003D;
		try
		{
			_0023_003DzFmiij5k_003D = ((methodBase is ConstructorInfo) ? null : methodBase.GetGenericArguments());
			this.m__0023_003DzR58imxw_003D = methodBase.DeclaringType.GetGenericArguments();
			_0023_003DzCTFfwLWymBiYtb4Scu0BdGsgh7un(num, _0023_003DzFmiij5k_003D, this.m__0023_003DzR58imxw_003D, flag);
		}
		finally
		{
			_0023_003DzFmiij5k_003D = array;
			this.m__0023_003DzR58imxw_003D = array2;
		}
	}

	private static void _0023_003Dzze_iqS_Bd6IAVhpAN_0024on7oHuoSOYCI4NWIlAsfc_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzmBzPgUk9Q3vqIKYOZAVqp0d_8pOa0et_0024JhW17JA_003D(((_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003Dz5rQzobg_003D)._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
	}

	private static byte[] _0023_003DzFB4MLVBUbFk99qK0uUZhT_wWrqPlGtcnZno5B4E_003D(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
		int num = _0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D();
		byte[] result = new byte[num];
		_0023_003DziDLVpbY_003D._0023_003DzEapvsYwOJ_U3XAvMNahAv_0024opFOBsF3NjYg_003D_003D(result, 0, num);
		return result;
	}

	private static void _0023_003DzYFj09gZzhjzWGr_yT7eW9AB29W9N(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzwLRSxOij2o4ipZ7oCq3reSIIXRgCXy6umQ_003D_003D(_0023_003DziDLVpbY_003D: false);
	}

	private bool _0023_003DzKINy2GFIwI24rQFwI38Xu_0024g_003D(MethodBase _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DziDLVpbY_003D.IsVirtual)
		{
			return false;
		}
		if (_0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(m__0023_003DzTSeNR8Q_003D._0023_003Dzx5X59GHDhQCY67nsHADQ8HctXRx6EilYiQ_003D_003D(), _0023_003Dz5rQzobg_003D: true).IsSubclassOf(_0023_003DziDLVpbY_003D.DeclaringType))
		{
			return true;
		}
		return false;
	}

	private static void _0023_003Dz7e4_0024GwzFqdTZT5O3hGmB7xSX1xzWV4onlw_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DziDLVpbY_003D._0023_003DzuIh3yneTRsQPaNb6hYtiEBjqYUsJXSYkC1OVG_Q_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2));
	}

	private void _0023_003Dz1ktQDyYgVRcDWtIkyhgZ1BaKF8X_ZGGS4A_003D_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		bool flag = IntPtr.Size == 4;
		IntPtr intPtr;
		switch (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
		{
		case 1:
		{
			int value = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
			intPtr = ((!_0023_003DziDLVpbY_003D) ? new IntPtr(value) : new IntPtr(value));
			break;
		}
		case 13:
		{
			long num = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			intPtr = ((!flag) ? ((!_0023_003DziDLVpbY_003D) ? new IntPtr(num) : new IntPtr(num)) : ((!_0023_003DziDLVpbY_003D) ? new IntPtr((int)num) : new IntPtr(checked((int)num))));
			break;
		}
		case 8:
		{
			double num2 = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			intPtr = ((!flag) ? ((!_0023_003DziDLVpbY_003D) ? new IntPtr((long)num2) : new IntPtr(checked((long)num2))) : ((!_0023_003DziDLVpbY_003D) ? new IntPtr((int)num2) : new IntPtr(checked((int)num2))));
			break;
		}
		case 19:
			intPtr = ((!_0023_003DziDLVpbY_003D) ? new IntPtr((long)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())) : new IntPtr(checked((long)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()))));
			break;
		default:
			throw new InvalidOperationException();
		}
		_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D obj = new _0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D();
		obj._0023_003DzbBdLl_0024ovIBkh8mMBtnusWhikQk0Aj3SNshCD9qg_003D(intPtr);
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D[] _0023_003Dzklbqkm1Y_0024hGwg5lLtsDsGCkqhPyrxyjp4gb4kfo_003D(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
		int num = _0023_003DziDLVpbY_003D._0023_003DzBLlGVMs_2v1_00240JsyU3F1qlk_003D();
		_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D[] array = new _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = _0023_003DzbGoKCkzXz67hSC9SkHu8YbWQf1z9o36uGFZKAXE_003D(_0023_003DziDLVpbY_003D);
		}
		return array;
	}

	private static void _0023_003Dzg3bMKvLXFekHD2uXgNBKxe_NyI6a(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (_0023_003Dz6HPSY_0024zpefu_0024sPp4tcYcOC6YvaQ_H1xKIg_003D_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private static void _0023_003DzcUU7s3siDmQGvTPIVoTqE3nRYQjlWT8WMurzR4U_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(sbyte));
	}

	private static void _0023_003DzvQm7VecVYyTQEapd7MMsyOrjO5U948kK03wOuM0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909304));
	}

	private static void _0023_003Dzm_wchFaM7lY9npSzrImbtTn_Xw80(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzQI1DNrfnDwMSgx6OhtwMTNL87lIO8dxcIA_003D_003D(_0023_003DziDLVpbY_003D: false);
	}

	private static void _0023_003DzFk_zEKZUiVJixBFBsHhV6xgqWiKw(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type elementType = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		int length;
		if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 is _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2)
		{
			length = _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		}
		else if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 is _0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D _0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D2)
		{
			length = _0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D2._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee().ToInt32();
		}
		else
		{
			if (!(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 is _0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D _0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D2))
			{
				throw new Exception();
			}
			length = (int)_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D2._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D().ToUInt32();
		}
		Array array = Array.CreateInstance(elementType, length);
		_0023_003DqiuPtUBEOXz5ixdMRvtXgU2Fko3XXNTLSxPaItseTVmc_003D obj = new _0023_003DqiuPtUBEOXz5ixdMRvtXgU2Fko3XXNTLSxPaItseTVmc_003D();
		obj._0023_003DzRLhxVKucVOF8eMuxSQgsrZwLjkAm_0024xL5cw3CIS8_003D(array);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static void _0023_003DzZO95ETklyMf734K6Sr0GQJKnsARnEoGDe_0024vehYA_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(uint));
	}

	private static void _0023_003DzARRzFq9wwVU9PwvqRYBZmyAX1_9KIo_JTQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzxhjBj1B0NmdPXqX0tYX1R3OzVXoNHdItjw_003D_003D(_0023_003Dz5rQzobg_003D);
	}

	private static void _0023_003Dz9ePHpdeeK_0024qiQw_zCTvLNtw_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(2);
	}

	private static void _0023_003DzSrRwphpiizl7nN_tXYmyMoM_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzZoHutE04P0sbCnLGpmJQ5GI_003D(_0023_003DziDLVpbY_003D: true, _0023_003Dz5rQzobg_003D: true);
	}

	private static Exception _0023_003DzFiW2vL9FCL2PzF1dLaOPOe8xYBzQm2pB2wskbIqR8xo7(string _0023_003DziDLVpbY_003D, string _0023_003Dz5rQzobg_003D)
	{
		return new MethodAccessException(_0023_003DzAWcPhgVgng7uZTM7bm7UobvPaQJpGckazA8wrdc_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907958) + _0023_003DziDLVpbY_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908137) + _0023_003Dz5rQzobg_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930)));
	}

	private static _0023_003DzWYPqg2E_003D _0023_003Dz1EPfP0_0024ESDIVU_I2vaBay0TLpLYMqnuNoQ_003D_003D(_0023_003DzshZYG54_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DzWYPqg2E_003D value;
		lock (_0023_003DzhidJeNw_003D)
		{
			_0023_003DzhidJeNw_003D.TryGetValue(_0023_003DziDLVpbY_003D, out value);
		}
		if (value != null)
		{
			return value;
		}
		MethodBase key = _0023_003DziDLVpbY_003D._0023_003DzSCazhnWLtFwbNXNkU4fvLsOlmtlQpVMJL_6R00w_003D();
		lock (_0023_003DzpGjKR04_003D)
		{
			while (_0023_003DzpGjKR04_003D.ContainsKey(key))
			{
				Monitor.Wait(_0023_003DzpGjKR04_003D);
			}
			_0023_003DzpGjKR04_003D[key] = null;
		}
		try
		{
			lock (_0023_003DzhidJeNw_003D)
			{
				_0023_003DzhidJeNw_003D.TryGetValue(_0023_003DziDLVpbY_003D, out value);
			}
			if (value == null)
			{
				value = _0023_003Dzlg8Ck8b2vxV2AHZt6Q7nMJQ2c7FQ(key, _0023_003DziDLVpbY_003D._0023_003Dz39unlxS1lk4RllUZRdoKvXOiRnGEXvZy7cYTnc8_003D());
				lock (_0023_003DzhidJeNw_003D)
				{
					_0023_003DzhidJeNw_003D[_0023_003DziDLVpbY_003D] = value;
				}
			}
			return value;
		}
		finally
		{
			lock (_0023_003DzpGjKR04_003D)
			{
				_0023_003DzpGjKR04_003D.Remove(key);
				Monitor.PulseAll(_0023_003DzpGjKR04_003D);
			}
		}
	}

	private static void _0023_003DzPmuQTIK7uT1BnKwUcrjQijptPYA755K8D5KUMR0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907556));
	}

	private static void _0023_003DzNk1VPEGh1_y5RJbUCJOLrgWCcfdcUZsnSw_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(checked(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (sbyte)(uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (sbyte)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => (sbyte)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			8 => (sbyte)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((sbyte)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((sbyte)(uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private void _0023_003DzRV6qj2VK8lvFF9bhLcko27s_003D(MethodBase _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D)
	{
		bool flag = !_0023_003Dz5rQzobg_003D && _0023_003DzKINy2GFIwI24rQFwI38Xu_0024g_003D(_0023_003DziDLVpbY_003D);
		if (flag && _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003DzR58imxw_003D._0023_003DziDLVpbY_003D)
		{
			_0023_003DziDLVpbY_003D = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003Dzt_m8zV0_003D._0023_003DzQY9CYytncsDwLeAt0AmxSpKqJpC5o35QIg_003D_003D(this, m__0023_003DzTSeNR8Q_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		}
		ParameterInfo[] parameters = _0023_003DziDLVpbY_003D.GetParameters();
		int num = parameters.Length;
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] array = new _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[num];
		object[] array2 = new object[num];
		_0023_003DzAvn2b38_003D _0023_003DzAvn2b38_003D2 = default(_0023_003DzAvn2b38_003D);
		try
		{
			_0023_003DzdjM_2jv3RJCvz2e7G8N4hr_tmbjLldgOzkQHpdc_003D(ref _0023_003DzAvn2b38_003D2, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = (array[num2] = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D());
				if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2);
				}
				if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D() != null)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D())._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
				}
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, parameters[num2].ParameterType)._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
				array2[num2] = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
			}
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 = null;
			if (!_0023_003DziDLVpbY_003D.IsStatic)
			{
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
				if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 != null && _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D() != null)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D())._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4);
				}
			}
			object obj = null;
			object obj2 = null;
			try
			{
				if (_0023_003DziDLVpbY_003D.IsConstructor)
				{
					obj = Activator.CreateInstance(_0023_003DziDLVpbY_003D.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, array2, null);
					if (!(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D))
					{
						throw new InvalidOperationException();
					}
					obj2 = obj;
				}
				else
				{
					if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 != null)
					{
						_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D5 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4;
						if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D3)
						{
							_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D5 = _0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D3);
						}
						obj2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D5._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					}
					try
					{
						if (!_0023_003DziK0DhWp2xj1RMiJal41JKdBPHgo_0024tuiZ_cZy3mI_003D(_0023_003DziDLVpbY_003D, obj2, ref obj, array2))
						{
							if (_0023_003Dz5rQzobg_003D && !_0023_003DziDLVpbY_003D.IsStatic && obj2 == null)
							{
								throw new NullReferenceException();
							}
							if (!_0023_003Dz5z_hyFyh6I1JQF_w5njQIzDJmgi9UokI1A_003D_003D(_0023_003DziDLVpbY_003D, obj2, array, array2, _0023_003Dz5rQzobg_003D, ref obj))
							{
								MethodBase methodBase = _0023_003DziDLVpbY_003D;
								object obj3 = obj2;
								if (flag && !_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003DzR58imxw_003D._0023_003DziDLVpbY_003D)
								{
									obj3 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003DzId5C3LA_003D._0023_003Dz4OPzFUyg_0024rOcLVgUSZiIXf_0024afRjb4srGWRfrjLA_003D(obj2, _0023_003DziDLVpbY_003D, out var methodInfo);
									methodBase = methodInfo;
								}
								obj = _0023_003Dzua402qH0PvFyh_SwU_t_0024Pt1hg0nvpQRf9w_003D_003D(methodBase, obj3, array2, _0023_003Dz5rQzobg_003D);
							}
						}
					}
					catch (TargetInvocationException ex)
					{
						Exception ex2 = ex.InnerException ?? ex;
						_0023_003DzBobqTgiv7_0024qJTDQ7T1G4q1vlSWRN(ex2);
					}
				}
			}
			finally
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D4)
					{
						object obj4 = array2[i];
						_0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D4, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj4, null));
					}
				}
				if (obj2 != null && _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D5)
				{
					bool flag2 = true;
					if (_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D5 is _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2)
					{
						flag2 = _0023_003DziEgqrdGGMod4268Ci8jWLdI_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2);
					}
					if (flag2)
					{
						_0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D5, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj2, _0023_003DziDLVpbY_003D.DeclaringType));
					}
				}
			}
			MethodInfo methodInfo2 = _0023_003DziDLVpbY_003D as MethodInfo;
			if (methodInfo2 != null)
			{
				Type returnType = methodInfo2.ReturnType;
				if (returnType != _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzbfrNXYE_003D)
				{
					_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, returnType));
				}
			}
		}
		finally
		{
			_0023_003DzMvb0RpkBv8lUDf_0024qVJCBuF1XVH_Z(ref _0023_003DzAvn2b38_003D2);
		}
	}

	private _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DzLrd1XNI9dc0qU09uargDhdLHbDdl(int _0023_003DziDLVpbY_003D)
	{
		if (_0023_003Dz0yNzT9M_003D == null)
		{
			throw new InvalidOperationException();
		}
		lock (_0023_003Dz0yNzT9M_003D._0023_003DzUXjbc9BY9W9m2seLWnn7jsJDEathvvwviQ_003D_003D())
		{
			_0023_003Dz0yNzT9M_003D._0023_003DzUXjbc9BY9W9m2seLWnn7jsJDEathvvwviQ_003D_003D()._0023_003DzUQ_bGErryTDpszeAu244IzixOQag9otlJo42_0024oeegDPivRgB6_0024XwD9KrkyM3tgZwAvXv4b_A7Pkg5OViPw_003D_003D(_0023_003DziDLVpbY_003D, 0);
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D();
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003DzscYqKpAjgfXYbEAcNGsZTQL6x5hx(_0023_003Dz0yNzT9M_003D._0023_003Dzde912cHpBbiEQCr8HB1DjQ0hCNmJS1u2_Avb9oE_003D());
			if (_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003DzOl4znCSQJV_o3jzYnD1EuZw5Wuu52ADXGg_003D_003D() == 0)
			{
				_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003DzXK2L99BqaqTFBJ_0024S_0024g_003D_003D(_0023_003Dz0yNzT9M_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			}
			else
			{
				_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003DzqhaYrqLn29Yo5YCz65jrfOG1aBNNYBezWAX4ZU_IjYxp(_0023_003DzhAbpAQZLxIlSoShIXCOKXa7_bq5INQfgau6CpDS99Y6B(_0023_003Dz0yNzT9M_003D));
			}
			return _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2;
		}
	}

	private static void _0023_003Dz1G0g_0024YXRY_x03pLhFfUURHL8znu9gtu8xw_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzaPUI9Skbf6ceOvYGSq43RNlVyMt5MZLDd8Aq2Rg_003D(_0023_003Dz5rQzobg_003D);
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzEujL_0024qmlUDGbJ7fYpKEKQsg61pySyI_0024TZhDreTgDMipj(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		if (!_0023_003DzR58imxw_003D)
		{
			long num = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			long num2 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			long num3 = ((!_0023_003DzAvn2b38_003D) ? (num + num2) : checked(num + num2));
			return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		ulong num5 = (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		ulong num6 = ((!_0023_003DzAvn2b38_003D) ? (num4 + num5) : checked(num4 + num5));
		return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D((long)num6);
	}

	private static void _0023_003DznUUxmR_0024cq2QGrVM6ov_6laDxpIyn(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908433));
	}

	private void _0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(uint _0023_003DziDLVpbY_003D)
	{
		_0023_003DzxmoHVeQ_003D = _0023_003DziDLVpbY_003D;
	}

	private static void _0023_003DzdqVqBVEbBb6STqvRxrm5RTSVJiCzoyV81w_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzQI1DNrfnDwMSgx6OhtwMTNL87lIO8dxcIA_003D_003D(_0023_003DziDLVpbY_003D: true);
	}

	private static object _0023_003Dz0SAYSWlBoo6DiPJ2iw_003D_003D(MethodBase _0023_003DziDLVpbY_003D, object _0023_003Dz5rQzobg_003D, object[] _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D.IsConstructor)
		{
			try
			{
				return Activator.CreateInstance(_0023_003DziDLVpbY_003D.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0023_003DzAvn2b38_003D, null);
			}
			catch (AmbiguousMatchException)
			{
				return ((ConstructorInfo)_0023_003DziDLVpbY_003D).Invoke(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0023_003DzAvn2b38_003D, null);
			}
		}
		return _0023_003DziDLVpbY_003D.Invoke(_0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
	}

	private static void _0023_003Dz8VDM29zAsIHl3T9cOA4wUXxf5flhR0Jxyw_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		Debugger.Break();
	}

	[Conditional("DEBUG")]
	public static void _0023_003Dzveibty_0024PxrqzN3hbJrr3LZe2y7J9(string _0023_003DziDLVpbY_003D)
	{
	}

	private static Dictionary<int, _0023_003DzkKfJheA_003D> _0023_003DzLAqK4qg99S4Lfp7hae_eWjWSwPq7(_0023_003DqN8nLWt7PRO2_0024YeQsFrvqJaHzlAjPhcpBYohGahsQEHA_003D _0023_003DziDLVpbY_003D)
	{
		return new Dictionary<int, _0023_003DzkKfJheA_003D>(256)
		{
			{
				_0023_003DziDLVpbY_003D._0023_003DztFFtzuA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DztFFtzuA_003D, _0023_003Dz21r1zpfdge2M3kLHzpHDdLPIpx8F)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzs989QDY_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzs989QDY_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzaPUI9Skbf6ceOvYGSq43RNlVyMt5MZLDd8Aq2Rg_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzEvUQrI0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzEvUQrI0_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					if (_0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
					{
						uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
					}
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz5rQzobg_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz5rQzobg_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					if (!_0023_003Dz6HPSY_0024zpefu_0024sPp4tcYcOC6YvaQ_H1xKIg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
					{
						uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
					}
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzE8QrneA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzE8QrneA_003D, _0023_003DzHQ3qGVaexpGA98EeComGKq3IarBc)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzkcCZFFw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzkcCZFFw_003D, _0023_003Dzr4b06ozk3I5UvBh0UCOddC1jZNlspFbS7Q_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz_0024q36smI_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz_0024q36smI_003D, _0023_003Dzu62BvHGyf6WyNPMrLWtDBNg_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzWYPqg2E_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzWYPqg2E_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz8CM8lG3MAfx_0024kqUlvJK4vBO75C6MuyZIio134ps_003D(_0023_003DziDLVpbY_003D: true);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz9bKO1YQ_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz9bKO1YQ_003D, _0023_003DzDkUw30QpMlbfTz6UWhINuuE3Tc7_iAgqTg_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzCAS7SAA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzCAS7SAA_003D, _0023_003DzaMmGzCfEtOEuOAf5il1LEMypDR3W9Tu_aMzGDQM_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzLZPCOtE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzLZPCOtE_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzvqLwvubv2Id3oqbIJDFL_KvV9rdFqVtTcKkVEDo_003D(_0023_003DziDLVpbY_003D: true);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz9HxCEmA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz9HxCEmA_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz97pidvc061He_0024DIu4r5pe6u1H3i1(_0023_003DziDLVpbY_003D: true);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzPQygtNc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzPQygtNc_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
					{
						1 => (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
						13 => ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
						19 => (long)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
						8 => (long)checked((ulong)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
						0 => (IntPtr.Size != 4) ? ((long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
						_ => throw new InvalidOperationException(), 
					}));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzeV5N9i0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzeV5N9i0_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(ushort));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzxH_6YFw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzxH_6YFw_003D, _0023_003DzvQm7VecVYyTQEapd7MMsyOrjO5U948kK03wOuM0_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzmQTFaQA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzmQTFaQA_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz0LZ3a2KNB2rgSf490RJHmy0_003D(3);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzt3zhI74_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzt3zhI74_003D, _0023_003DzenLkeMckiNQ5N9KoMJWkpDiqaXeZbRMIKm4ik_s_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz437_00244ak_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz437_00244ak_003D, _0023_003DzzkJgoXnU3jigR9FfEGBY2crtIGNx)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz0cKkDvw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz0cKkDvw_003D, _0023_003DzObr38oov3fOAF5I7PLtSrbzDRNZX)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzsmnG_0024Pw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzsmnG_0024Pw_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4)
				{
					object obj = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					long num = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt();
					Array array = (Array)_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					Type elementType = array.GetType().GetElementType();
					if (elementType == typeof(long))
					{
						_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(long));
						((long[])array)[num] = (long)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					}
					else if (elementType == typeof(ulong))
					{
						_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(ulong));
						((ulong[])array)[num] = (ulong)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					}
					else if (elementType.IsEnum)
					{
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(elementType, obj, num, array);
					}
					else
					{
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(typeof(long), obj, num, array);
					}
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzXrexKjY_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzXrexKjY_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2 = (_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2;
					MethodBase methodBase = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
					Type declaringType = methodBase.DeclaringType;
					Type type = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType();
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
					_0023_003DqVq2G06qUQtchgF1EnbfnvW94BfgqBHFxi7iIWrl2lfE_003D obj = new _0023_003DqVq2G06qUQtchgF1EnbfnvW94BfgqBHFxi7iIWrl2lfE_003D();
					obj._0023_003DztXPjv8jDiWmFW3sXs84MniY_003D(methodBase2);
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzL2rchZk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzL2rchZk_003D, _0023_003Dz8pKBIJO_UHy01GD931gFmbQ_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzJ4YrBuw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzJ4YrBuw_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(2);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzbbgj2ug_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzbbgj2ug_003D, _0023_003DzywNSYuuAWxr_6426XKRUDGIAqmqAIIwppg_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dza0dzd_g_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dza0dzd_g_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzu0a9M9zXrZOr09UDVft0TcHevaFuOoyqag_003D_003D(2);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzYcilwAA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzYcilwAA_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmBzPgUk9Q3vqIKYOZAVqp0d_8pOa0et_0024JhW17JA_003D(((_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz77g161c_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz77g161c_003D, _0023_003DzdqVqBVEbBb6STqvRxrm5RTSVJiCzoyV81w_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz3sEi_MU_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz3sEi_MU_003D, _0023_003Dzrr6Ay9h1vzwYckPYlyUYxI6FI7iU)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzuwH5j5s_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzuwH5j5s_003D, _0023_003Dzg3bMKvLXFekHD2uXgNBKxe_NyI6a)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzASowvPc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzASowvPc_003D, _0023_003DzMqNcyWq9m1mEW9HKP1uydnqGVlPU)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzl3DhHgI_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzl3DhHgI_003D, _0023_003Dz73h0QSLdYGwOYLow7aDZ8NMYYEjYrOoxyw_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzuaCnQ5A_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzuaCnQ5A_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzPdTWlMPHPkLHbDli9YvX_pdNomy6(_0023_003DziDLVpbY_003D: false, _0023_003Dz5rQzobg_003D: false);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzBo2IvAU_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzBo2IvAU_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003Dz8wovo1mlTaoN1g0g3IAMk1d7cQeEIOfYr3TuVio_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2) ? 1 : 0));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzZpYvsQY_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzZpYvsQY_003D, _0023_003DzjoZs8ymYEJ_NUjVtOH7VuF14vZDGbZSM5vOdgG0_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzwu97gS0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzwu97gS0_003D, _0023_003Dz8VDM29zAsIHl3T9cOA4wUXxf5flhR0Jxyw_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzxCVvHbo_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzxCVvHbo_003D, _0023_003Dzy8axZ8FPK_VZjQYqSNpW2ro_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzR8q4i70_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzR8q4i70_003D, _0023_003DzkuUk1uiSqWpGlLC4SnTgtwWheX2IolGUqg_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzNFh4IVA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzNFh4IVA_003D, _0023_003DzJtppk5hDV34exa1EWEAoGuv76SQY)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzQhY3lC0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzQhY3lC0_003D, _0023_003DzPF8nEd3Ue1oD1WYq5CaMZE3CMGmzm3xqyf_49Xg_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DztBKgiyk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DztBKgiyk_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					bool flag = false;
					if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
					{
						1 => ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() == 0, 
						13 => ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() == 0, 
						0 => ((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee() == IntPtr.Zero, 
						20 => ((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D() == UIntPtr.Zero, 
						7 => ((_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzP7k5Y6ukvcg_ixjUAKpLm2Y7IkNc3hTJEKeYFNObePLS() == null, 
						19 => !Convert.ToBoolean(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
						_ => _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == null, 
					})
					{
						uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
					}
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz8wjMonY_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz8wjMonY_003D, _0023_003DzctPL2fVn0UsPU9ev132QGjW4GNRvTR0Q6g_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzHfoUx4c_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzHfoUx4c_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzs12LFbj_0024U7TMDTjuE_0024QMr5V4WvhQPpLitMz_O0kJxSlJ(_0023_003DziDLVpbY_003D: true);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzQiBkG3c_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzQiBkG3c_003D, _0023_003DzN9_QYwTAeheE_CnryaY9ZPOnOHy_X5OTSYotOadu8Yvc)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz40R7bAU_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz40R7bAU_003D, _0023_003DzYJM7OEzFo9Uao6USz0xr5Uw_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzBexVt40_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzBexVt40_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(checked(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
					{
						1 => (ushort)(uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
						13 => (ushort)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
						19 => (ushort)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
						8 => (ushort)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((ushort)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((ushort)(uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzqUP22VQ_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzqUP22VQ_003D, _0023_003DzvlKuvw7JaHUd0IziVnC5F_s_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz1dZRnDk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz1dZRnDk_003D, _0023_003DzGQ4O1wKgXyk3SASc1w1onsfurje26nYucmH5SWo_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzgarqIgM_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzgarqIgM_003D, _0023_003DzbOSL4SqlRGdyzUt3eYTA554_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzE5gt1ko_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzE5gt1ko_003D, _0023_003DzgjJ6xTl0xLOq9ODIRH0PuZY_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzxzOTZJ4_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzxzOTZJ4_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzu0a9M9zXrZOr09UDVft0TcHevaFuOoyqag_003D_003D(0);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzH0C8Ewc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzH0C8Ewc_003D, _0023_003DzV1XDE18mH3R8HAzotUnZgaE_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzSlGxeJk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzSlGxeJk_003D, _0023_003DzDVw8osix5fMBRA6TSG05OixJ9mNCXIa33w_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzu1Fq9I8_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzu1Fq9I8_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(uint));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz0yNzT9M_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz0yNzT9M_003D, _0023_003DzoxSePKFe4ZasTxbqMfgChpqBcJST)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz0vdLLss_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz0vdLLss_003D, _0023_003DzSPvj9Mc2ecXWKhds22juOtQ_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzbfrNXYE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzbfrNXYE_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(0);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzt_m8zV0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzt_m8zV0_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzJAojZB2QIuH_jIxrACIzvilaDqHq(_0023_003DziDLVpbY_003D: true, _0023_003Dz5rQzobg_003D: false);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzTscnhpk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzTscnhpk_003D, _0023_003DzSxjMpfXe1CsV8Ozd_36OiAo_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzEoaRcZw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzEoaRcZw_003D, _0023_003DzlWzQ3E2OEdf2hbOVM2wdUMNjslCQVFQzYgKbf4A_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzO_0024iiQ4U_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzO_0024iiQ4U_003D, _0023_003DzEoNjRadYRewxV0FiooCIcG0_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzAqw2BjQ_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzAqw2BjQ_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzNDN2q2o_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzNDN2q2o_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(checked(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
					{
						1 => (byte)(uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
						13 => (byte)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
						19 => (byte)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
						8 => (byte)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
						0 => (IntPtr.Size != 4) ? ((byte)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((byte)(uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
						_ => throw new InvalidOperationException(), 
					})));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzOQfj4vI_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzOQfj4vI_003D, _0023_003Dz40sYtypX6bvk2ITmr4WpdakSgrw5j_v8BDtmnSw_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzvMKCVbs_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzvMKCVbs_003D, _0023_003DzP6eSZsPnVEManckWZ6lSXtLfSC79)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz8SIpui0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz8SIpui0_003D, _0023_003DzJPwz0GMwRg00zHaksVfNWMpM1hFi)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz1v6oPQk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz1v6oPQk_003D, _0023_003DzqCERRgWn1UAgxXgLK0NsYhZaoIjZ)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzf8ajBW4_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzf8ajBW4_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzPdTWlMPHPkLHbDli9YvX_pdNomy6(_0023_003DziDLVpbY_003D: true, _0023_003Dz5rQzobg_003D: true);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzkKfJheA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzkKfJheA_003D, _0023_003DzcUU7s3siDmQGvTPIVoTqE3nRYQjlWT8WMurzR4U_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzEWLeis8_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzEWLeis8_003D, _0023_003DzeY_Rq6DE2aXBYmaLhn29MnHJCyayO_z7vxE8Jkk_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzzmYZ0f0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzzmYZ0f0_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(_0023_003DzDNpeQO0_003D);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz4OfLwgo_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz4OfLwgo_003D, _0023_003DzkElEvIVypfNtM1gCSk7rh_ns6mhfRTjrrA_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DziP9fFuA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DziP9fFuA_003D, _0023_003DzjmBwJJBPJH9SielIhz2rIDI_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzxmoHVeQ_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzxmoHVeQ_003D, _0023_003DzVF4xXqLe0r8DdbTksJIhyF02Ko9kF3QCutItIrk_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzOi4CcJI_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzOi4CcJI_003D, _0023_003DzhNagC7r3GUiU3sRadfivnNKuEQDX)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzpbGuOuw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzpbGuOuw_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzhOmsmnE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzhOmsmnE_003D, _0023_003DzPV70hKPecs9DfliYp0x9xCwoEOyrz5sLXQ_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzVHBhWrs_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzVHBhWrs_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D5)
				{
					object obj = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					long num = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt();
					Array array = (Array)_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					Type elementType = array.GetType().GetElementType();
					if (elementType == typeof(sbyte))
					{
						_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(sbyte));
						((sbyte[])array)[num] = (sbyte)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					}
					else if (elementType == typeof(byte))
					{
						_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(byte));
						((byte[])array)[num] = (byte)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					}
					else if (elementType == typeof(bool))
					{
						_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(bool));
						((bool[])array)[num] = (bool)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
					}
					else if (elementType.IsEnum)
					{
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(elementType, obj, num, array);
					}
					else
					{
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(typeof(sbyte), obj, num, array);
					}
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzT805HFc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzT805HFc_003D, _0023_003DzYwykTfMEz6ZQUkdnn7kw50jTZi2T6SAkKOeTlLvCDnEL)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzqbYd9U4_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzqbYd9U4_003D, _0023_003DzIecD6ZbHownA_IYx14bnvXIlGpue)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzshZYG54_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzshZYG54_003D, _0023_003DzqaQXNyBbGKK1IN8PkWsTTAem1ERSUNfbNg_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzWKeuNLk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzWKeuNLk_003D, _0023_003DzoJNHPKdZL4HhlMIOEnGl7v0_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzqRxZg2s_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzqRxZg2s_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					Type type = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
					_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 = (_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D)_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					if (type.IsValueType)
					{
						object obj = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2)._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
						if (_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzoIht4H3MBiobPh2HDJb056MsRfdA_00245XIgOj_0024Oec_003D(type))
						{
							_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D obj2 = new _0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D();
							obj2._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(type);
							_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2, obj2);
						}
						else
						{
							FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
							foreach (FieldInfo fieldInfo in fields)
							{
								fieldInfo.SetValue(obj, _0023_003DzuNKSWtY_0024_0024ExI7KlNuM5gS_002417mtXjL3l3OMuckYc_003D(fieldInfo.FieldType));
							}
						}
					}
					else
					{
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2, new _0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D());
					}
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzYuhN_00245o_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzYuhN_00245o_003D, _0023_003Dz2tzKvJiTVx2DgtDT0NITtbtFNk_d0WhCBg_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzqM9Sn_A_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzqM9Sn_A_003D, _0023_003DzoLsqfqM4qD7t9yiP6EvFyXMTbSR8BOkQ3nVTKLs_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzqdGx8OQ_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzqdGx8OQ_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2 = (_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2;
					MethodBase methodBase = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzRV6qj2VK8lvFF9bhLcko27s_003D(methodBase, _0023_003Dz5rQzobg_003D: false);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzq8bW3fw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzq8bW3fw_003D, _0023_003DzPmuQTIK7uT1BnKwUcrjQijptPYA755K8D5KUMR0_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzZW2idpI_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzZW2idpI_003D, _0023_003DzeN9iOWRRxFVa_qwAsKDjqH3q09MCOnyFF8kMjkw_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzKlu7TUw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzKlu7TUw_003D, _0023_003DzEG9ru65ZRovJABJZBgJIZc2RPQK5)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzOhdXIPc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzOhdXIPc_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(-1);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzQspsrwQ_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzQspsrwQ_003D, _0023_003DzBKxs_3dM71tDNojxTSQCsguc0lrxoMFpmOEfh2A_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzMnWcwEk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzMnWcwEk_003D, _0023_003Dzr04AhMkN2HrCTrOjlzkf2HamevaX)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzKnKylwk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzKnKylwk_003D, _0023_003DzE0fRxTEv2bJciKjTTEP0d8lMNs4u)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz99o3e4E_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz99o3e4E_003D, _0023_003DztM3KKSZvlu_9yPwSB4IlQ21Uj79a8yrCBQ_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzwpDJ6Xg_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzwpDJ6Xg_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzFcd5b1NerPBv8Ji62_RSmeXGISQf();
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz1_0024vBImE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz1_0024vBImE_003D, _0023_003Dz6GaUsvitrYeChM2doHwOS_PxtOi4)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzmUsle0E_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzmUsle0E_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(long));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzEOtpbcc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzEOtpbcc_003D, _0023_003DzARRzFq9wwVU9PwvqRYBZmyAX1_9KIo_JTQ_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzN6G05Lg_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz99o3e4E_003D, _0023_003DznWSc8aFL1oKKDrAnzZfdbL5RZBxwQWpnSw_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzc7_pFlk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzc7_pFlk_003D, _0023_003DzFk2G1f_6rIvUpvGcFQneh85ggmRUxasSqcVPkvs7HwZK)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz2SgfTmE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz2SgfTmE_003D, _0023_003DzajqCr0KiHgojzc4vinwetyI_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz_eY3Y4c_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz_eY3Y4c_003D, _0023_003Dz9ostaHrPvlHk5cuiBQ_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzhidJeNw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzhidJeNw_003D, _0023_003Dz_l0AbuXGUnL4nnER6mMiAirANJzI4dYhYea4MRo_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzaoAKD8Y_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzaoAKD8Y_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					Type type = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzz9Rp_00249b6lGMYj_jZQQ_003D_003D(type);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzylMZqAM_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzylMZqAM_003D, _0023_003DzFk_zEKZUiVJixBFBsHhV6xgqWiKw)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzZdPd6ZQ_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzZdPd6ZQ_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz1ktQDyYgVRcDWtIkyhgZ1BaKF8X_ZGGS4A_003D_003D(_0023_003DziDLVpbY_003D: false);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzJ8yEPpo_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzJ8yEPpo_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					Type t = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Marshal.SizeOf(t)));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzrDAunR8_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzrDAunR8_003D, _0023_003Dz_tQNtU8fXyXAv2DS57m_EfZ44HfNgIfe_yzbzy81d9rY)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzR6XBRZw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzR6XBRZw_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzBobqTgiv7_0024qJTDQ7T1G4q1vlSWRN(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz8FzDawo_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz8FzDawo_003D, _0023_003DzC1RG0OP2Z50e4BqYCo_WE6k5v0ioCT2QbkCqLtk_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzE6TXui0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzE6TXui0_003D, _0023_003DznHzb6PXrEz_zYYcRtA_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzVFvqE_Y_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzVFvqE_Y_003D, _0023_003DzSrRwphpiizl7nN_tXYmyMoM_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzH9VU2k0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzH9VU2k0_003D, _0023_003DzpXezgpIkxOlvuRaZlChG5D4u_wD5LWTlyQ_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzbz5dAAk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzbz5dAAk_003D, _0023_003DzDl8s7f504vjxiFNoQpaKweo_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzYTsLHdI_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzYTsLHdI_003D, _0023_003DzIrLBcr2K_abPOlFDNA_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzYkWM45g_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzYkWM45g_003D, _0023_003Dzail2JRd0zY19V0vIvs870iaYOJXS)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzlWaYL_0024Q_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzlWaYL_0024Q_003D, _0023_003DzCxaByjPMo_zCGxnHCv6pQfc_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzNDQ_E88_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzNDQ_E88_003D, _0023_003DzZZvDHq5c4Ecbhl_iANPCIPySDlwY6MJQMQ_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz_0024OCklCc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz_0024OCklCc_003D, delegate
				{
					throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908537));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzy9OFgrU_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzy9OFgrU_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzuIh3yneTRsQPaNb6hYtiEBjqYUsJXSYkC1OVG_Q_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzWWgGxds_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzWWgGxds_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(sbyte));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzId5C3LA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzId5C3LA_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D _0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D2 = (_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2;
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzIkM3CaSWupD4_0024gmIh5V76vLJzMAa(_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D2._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzvQQcj9c_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzvQQcj9c_003D, _0023_003Dzc4opDCSZIz2bTrW6C5bCqoQ_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzoUfC4pw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzoUfC4pw_003D, _0023_003Dz_1IXjya1kcoZaSRLw66DpxZFdEIA)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzDNpeQO0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzDNpeQO0_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzY_Qho9G6NDOFx1ZRp_0024YDMpUtokq6aO_Vaw_003D_003D(_0023_003DziDLVpbY_003D: true);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz_0024TNCdoE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz_0024TNCdoE_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					FieldInfo fieldInfo = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzsH6I9ZDv5gPH5Am4bCK2nNxE2uzwyQ3uDe_00241OaRt2yRO(num);
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 as _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D;
					object obj = ((_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 == null) ? _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() : _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2)._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D(fieldInfo, obj, _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzPYVdveQ_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzPYVdveQ_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz0Vs06u0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz0Vs06u0_003D, _0023_003Dz8uDpc3J3w5vZL0g6NXgUyQEuknK3LbYl7iQmcc0_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzT9ziLyc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzT9ziLyc_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz4BKUbLs_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz4BKUbLs_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					if (_0023_003Dz8wovo1mlTaoN1g0g3IAMk1d7cQeEIOfYr3TuVio_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
					{
						uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
					}
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzstAnAPw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzstAnAPw_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(short));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzQ0f3KNw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzQ0f3KNw_003D, _0023_003DzL0ugPCGDi3vDh47IbrRTaZw_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzK_0024Y_Nd4_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzK_0024Y_Nd4_003D, _0023_003Dzi9WzZPfNKuF9RqZPZjSrue1moxGV)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzEYwU9Dk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzEYwU9Dk_003D, _0023_003DzgHnGOzow844ZX952mouOjT8_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzlZ2EkUs_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzlZ2EkUs_003D, _0023_003DzYFj09gZzhjzWGr_yT7eW9AB29W9N)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzc9xbcSw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzc9xbcSw_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					string text = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzd8NJjsIuNdDkK_0024Oj3YmRtDVRGwvLj5FHfBcM_0024LcoOJbt(num);
					_0023_003Dqu2lukaMdtknH99Y0fKPgR6p7bCuAeuFbcqraKzMEJ0M_003D obj = new _0023_003Dqu2lukaMdtknH99Y0fKPgR6p7bCuAeuFbcqraKzMEJ0M_003D();
					obj._0023_003Dz6jVBe9cH7_002498rFPT0mx0hQo_003D(text);
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzmZLq6iI_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzmZLq6iI_003D, _0023_003Dz3Y05bSqCbyfMtTrn3ZPqG1Ol6DDZ)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DznijNzwk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DznijNzwk_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzTYpttnKnXlCifeH26HfbGmzO2lm6(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz1kuO9_w_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz1kuO9_w_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz0LZ3a2KNB2rgSf490RJHmy0_003D(((_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzfJFRO2o_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzfJFRO2o_003D, _0023_003Dz3xnJZk0tsFncy7HfhEzqMZA_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzrtuC07k_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzrtuC07k_003D, _0023_003DzkUx9zDGBsWGA_ivebQoXmX8jrEOw)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzEfxrPgY_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzEfxrPgY_003D, _0023_003DzoTZGeXhIosOFo8fGPlKdXccH72kq)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzliCO384_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzliCO384_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzz9Rp_00249b6lGMYj_jZQQ_003D_003D(typeof(float));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzyk2fsPo_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzyk2fsPo_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzoMNiNRw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzoMNiNRw_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzfMP2yf8_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzfMP2yf8_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5qKhdgkaNPCdh71MH4BA2EhHZKb_(_0023_003DziDLVpbY_003D: false);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzO5GCmos_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzO5GCmos_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(byte));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzBJFJHwk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzBJFJHwk_003D, _0023_003DzBz0afg9Y8y0GGHawiMgEhDdBfuU0f1Xmng_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz1I6x6SE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz1I6x6SE_003D, _0023_003DzIyEToZFTaR0DwtZAjQCwgCo_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzrunQPrg_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzrunQPrg_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(6);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzt_WRa1k_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzt_WRa1k_003D, _0023_003DztFZ_XzNX5ojemalYDkihIYXDEUnR)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzSEAPreM_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzSEAPreM_003D, _0023_003DzLOgSGCTBCn7LXVmAw43jf0nmNER3yT0R8Q_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzGcl_0024E9o_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzGcl_0024E9o_003D, _0023_003Dzuibc_Ifna0U3bwijB6_MjcLRw0rYvMqiBg_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzEYRJDJs_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzEYRJDJs_003D, _0023_003DzPuggeVWnttFpBeEMG2ciU48_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzXgpr_CI_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzXgpr_CI_003D, _0023_003DzmkEJTn4IVDY2WAw9tlMGkhq1NGQP9VlJURiQJPhoAN1h)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzvPZnhP0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzvPZnhP0_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					if ((_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 8) ? (!_0023_003Dz8wovo1mlTaoN1g0g3IAMk1d7cQeEIOfYr3TuVio_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)) : (!_0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)))
					{
						uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
					}
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzcOktkYs_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzcOktkYs_003D, _0023_003DzmXNQtyq8_uKlNeY1wfjLCSHs6RZekBK6toBInbwl5swf)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz61IPlm0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz61IPlm0_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzz9Rp_00249b6lGMYj_jZQQ_003D_003D(_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dztcdhsic_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dztcdhsic_003D, _0023_003DzP9wxLM15P5Rjd4ncOg0GwhEjEDGye4DU3g_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzjbqS1qE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzjbqS1qE_003D, _0023_003DzLJc0BY2Oawi1GPRYGnuJVCQ_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz61alSec_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz61alSec_003D, _0023_003DzqfwSyegLEzwMxkE5jefoZRjoz4n7kvergxX8laenkcbt)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzeIjHytw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzeIjHytw_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2 = (_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2;
					MethodBase methodBase = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] array = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzyk2fsPo_003D;
					foreach (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 in array)
					{
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3);
					}
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzRV6qj2VK8lvFF9bhLcko27s_003D(methodBase, _0023_003Dz5rQzobg_003D: false);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz7gBnFV0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz7gBnFV0_003D, _0023_003DzeO74HApp_GQL8vpJZ3E3ot8UtDqt3tUi5pf1utA_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzD47R4_0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzD47R4_0_003D, _0023_003DzNk1VPEGh1_y5RJbUCJOLrgWCcfdcUZsnSw_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzuavd0rs_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzuavd0rs_003D, _0023_003DzqfgLU_fea9ZL67gRQJhT7iFJVKxe7egTRoatQsQ_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzZfhKCX0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzZfhKCX0_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(float));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz4ZkWMQk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz4ZkWMQk_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(1);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz9UcoK30_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz9UcoK30_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz_zeDwWgrLqWqj6ECFFPZ7JQ_003D(((_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz84e79_A_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz84e79_A_003D, delegate
				{
					throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908433));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DziDLVpbY_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DziDLVpbY_003D, _0023_003DzwXle8OA0jZf7dui1oEmvoAo_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzjE76fNQ_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzjE76fNQ_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzjvfbm6o_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzjvfbm6o_003D, _0023_003DzaWctMIij2WzYpOucpiI7ikw_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzCz_00242d48_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzCz_00242d48_003D, _0023_003Dzsvfb06pVrpsggeVZMjPq0vWuAtZyFR85IVAhaTk_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzAqD1TAk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzAqD1TAk_003D, _0023_003DzC2L_2PbykaPBuWKaP3INz7cw6oL7mqSmTA_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzM_GteQk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzM_GteQk_003D, _0023_003DzjPNsRUk2ojqHVwRhEK4cc5k_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzTSeNR8Q_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzTSeNR8Q_003D, _0023_003Dz4y9fziuq9Q7e3L7BImhoShqif7EWq0d6Sg_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzB68dg9Q_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzB68dg9Q_003D, _0023_003DzexpOTCnLSfXpA0hIPZ0xEGMgFEAu)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzn0TnzrA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzn0TnzrA_003D, _0023_003Dz4PYL9eIAHjsStBtG9DNqZgk_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzewVWOYw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzewVWOYw_003D, _0023_003DzDGEgL6g4OEdmxDsKm1B1pT1bdrEg)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzoETBmJI_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzoETBmJI_003D, _0023_003Dz2d0fAAaTBt5ILHKbk3UvGmltXyWF)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz9sdVyIE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz9sdVyIE_003D, _0023_003DzxPYxNadP3vTTJD5F7y8xcAU_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzPv1JAYc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzPv1JAYc_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					if (_0023_003DznPx5gMhR_0024wSvGh_pza5trRU_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
					{
						uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
						_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
					}
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzDtqAooE_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzDtqAooE_003D, _0023_003Dze3e48UT55GuFmYe61RJ7cgwWWedEO_5LmOfafbk_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzPs8wg9E_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzPs8wg9E_003D, _0023_003DzO6BJVMz2TXdlNtTcXYkMzdM_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzxYmA4VA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzxYmA4VA_003D, _0023_003Dz212J94WICL7Ors4WSg_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzbKb3e8s_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzbKb3e8s_003D, _0023_003DzqkbVaKEiMvEPw6sA0GcU8aVeotjz)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzzrSNArA_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzzrSNArA_003D, _0023_003DzzsoBcV3r6mw4o18WyJfWnck_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzGgKfey0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzGgKfey0_003D, _0023_003DzHliDIJHI_4jipcyu35IoIP0hI_jc)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz2QVVx8s_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz2QVVx8s_003D, _0023_003DzNe_wiEPYWTnP4GktEFXvcHUkhYTTKf5Udw_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzK_0024fbiW0_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzK_0024fbiW0_003D, _0023_003DzbHNLxOSzjTJyVRLnanWDop0aqbgi)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzpGjKR04_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzpGjKR04_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz9SI33zTg8BbNw3Q8Nws6S3wUpSIQLpQPMUJJdwedXwau(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzgZHdv7k_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzgZHdv7k_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzIkM3CaSWupD4_0024gmIh5V76vLJzMAa(3);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzHAesDUo_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzHAesDUo_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(double));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzbo_lp2U_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzbo_lp2U_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dzid79q24_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dzid79q24_003D, _0023_003Dztt7PqGWRgxdj8ZI8ugnABoUmgR9PDf4TUFhDcSU_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzAQHxNCU_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzAQHxNCU_003D, _0023_003DzKagkDd2_Od3kAfECwKVhIcinkyVnlcR2og_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzqeqS8vc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzqeqS8vc_003D, _0023_003DzCUzhyPdi1g5Vux_ZTx8Spt4_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz1lrYpwo_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz1lrYpwo_003D, _0023_003DzBeU6795zDgCxWQeKcGQBQzv5KYvqEnjNAw_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzBW_0024a6Uo_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzBW_0024a6Uo_003D, _0023_003Dzp_u01LYulmAKZ9DREyhIgdlH0ABc0uWJibxxXEPfClgt)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzJt0u35c_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzJt0u35c_003D, _0023_003DzDwjATMdYRoScyBEy_Ayp35xQSH7OeVpw3A_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003Dz3DflQIc_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003Dz3DflQIc_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(short));
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzePJQjfk_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzePJQjfk_003D, _0023_003DzYi8fIL8Y5jVwwsTZZhjYloJdvrOGqLGK3sPyu54_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzRpXgovo_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzRpXgovo_003D, delegate(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
				})
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzN8NFk9A_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzN8NFk9A_003D, _0023_003DzyuJikjH7anI_a6JxCCehy7g_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzvXOLtKg_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzvXOLtKg_003D, _0023_003DzzOtlf0l8q74fHVe3MauIcFTtWH14CTv6Lg_003D_003D)
			},
			{
				_0023_003DziDLVpbY_003D._0023_003DzR58imxw_003D._0023_003DzIpsKkurbnzgmjNTSTu5KwllfjFnbgCjl_0024ZnNc3vnfG_7(),
				new _0023_003DzkKfJheA_003D(_0023_003DziDLVpbY_003D._0023_003DzR58imxw_003D, _0023_003Dzm_wchFaM7lY9npSzrImbtTn_Xw80)
			}
		};
	}

	private static void _0023_003DzEoNjRadYRewxV0FiooCIcG0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (_0023_003DziDLVpbY_003D._0023_003Dz_00246_zqjGaTSjgbTyBE2pnCP8J5nm4uPBMYA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2, type))
		{
			_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
		}
		else
		{
			_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D());
		}
	}

	private static void _0023_003DzIyEToZFTaR0DwtZAjQCwgCo_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(3);
	}

	private void _0023_003DzLjSHuyrc9krN4Y1HFYpc27g_003D()
	{
		_0023_003DzE8QrneA_003D = null;
		this.m__0023_003DzmQTFaQA_003D = null;
		_0023_003DzoMNiNRw_003D.Clear();
	}

	private static void _0023_003DzpIqsaG5s_0024d77OMyFjMF_0024hwgWA_UEjjWYuuuCY3qM5Gt8(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzPdTWlMPHPkLHbDli9YvX_pdNomy6(_0023_003DziDLVpbY_003D: false, _0023_003Dz5rQzobg_003D: false);
	}

	private static void _0023_003DzHQ3qGVaexpGA98EeComGKq3IarBc(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		long num2 = _0023_003DziDLVpbY_003D._0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt();
		Array array = (Array)_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		_0023_003Dq6tsYctsQQ5GQ6RFr34KBs9K_00248csOlSsb_0024tvIZej_q5k_003D obj = new _0023_003Dq6tsYctsQQ5GQ6RFr34KBs9K_00248csOlSsb_0024tvIZej_q5k_003D();
		obj._0023_003Dz_0024MlHQD2GQN_0024zM83WHxOMvtGipXToz_rKPgSs8bQ_003D(array);
		obj._0023_003DzOwUeWsAv3XcZZAx1xnuuZLvugy_Y(type);
		obj._0023_003DzxOZP2EInPDlseRDwpwQpfo3VKZCtX_0024k0Cg_003D_003D(num2);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private void _0023_003DztqTBIbTo235VrTviboXsNvRcmLldAqEl8MFuUg5Jupve()
	{
		_0023_003DzvR_c2pbCw0UL9VDVLLpeUCzicJ3e(_0023_003DziDLVpbY_003D: false);
	}

	private static void _0023_003DzxPYxNadP3vTTJD5F7y8xcAU_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz8CM8lG3MAfx_0024kqUlvJK4vBO75C6MuyZIio134ps_003D(_0023_003DziDLVpbY_003D: false);
	}

	private static void _0023_003Dz2d0fAAaTBt5ILHKbk3UvGmltXyWF(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
	}

	private static void _0023_003DzKagkDd2_Od3kAfECwKVhIcinkyVnlcR2og_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzz9Rp_00249b6lGMYj_jZQQ_003D_003D(typeof(double));
	}

	private static void _0023_003Dz4PYL9eIAHjsStBtG9DNqZgk_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(uint));
	}

	private static void _0023_003Dz9ostaHrPvlHk5cuiBQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2) ? 1 : 0));
	}

	private static void _0023_003DzBKxs_3dM71tDNojxTSQCsguc0lrxoMFpmOEfh2A_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (!_0023_003DzpKI9ol7554_0024XWsqSrgmmMbA_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private static void _0023_003Dzl_0024zE3pX0HcChoFxhprVK1P0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzY_Qho9G6NDOFx1ZRp_0024YDMpUtokq6aO_Vaw_003D_003D(_0023_003DziDLVpbY_003D: true);
	}

	private static void _0023_003DztfhL_00241dL9u2gF_00245kXxCSV7MBeNkcRfkI4Kxg0Jx6u6o5(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(0);
	}

	private static void _0023_003Dzv_0024yNYO7rT6mOYePLvLUYD1k_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
	}

	private long _0023_003DzPrIFfKqBT5u3mkmueJsm7dVS7bx2hen_0024ghN2c2A_003D(string _0023_003DziDLVpbY_003D)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DqAApRutk_0024_0024_r10xpZwFNxeOMCEx717HEes7fYzQ03rIo_003D._0023_003DzhJNGWqlmO_0024AKQweBuA_003D_003D(_0023_003DziDLVpbY_003D));
		long result = new _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D(new _0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D(memoryStream, _0023_003Dzu4ZrJCpFVxUa7kb2HLo0s6o_003D()))._0023_003DzrHcBIDM_zm2DjlT8p4axEjulBRQCiKqBKgwhAFx8MtbF();
		memoryStream.Dispose();
		return result;
	}

	private static void _0023_003Dz8uDpc3J3w5vZL0g6NXgUyQEuknK3LbYl7iQmcc0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzu0a9M9zXrZOr09UDVft0TcHevaFuOoyqag_003D_003D(1);
	}

	private void _0023_003DzPdTWlMPHPkLHbDli9YvX_pdNomy6(bool _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DzTNPcvRRwg52w9eqd5hkODCWAgGmFIshRLYPQyqZFzGiA(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D));
	}

	private void _0023_003DzQI1DNrfnDwMSgx6OhtwMTNL87lIO8dxcIA_003D_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		bool flag = IntPtr.Size == 4;
		checked
		{
			IntPtr intPtr;
			switch (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
			{
			case 1:
			{
				int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				intPtr = ((!flag) ? ((!_0023_003DziDLVpbY_003D) ? new IntPtr(unchecked((uint)num)) : new IntPtr((uint)num)) : ((!_0023_003DziDLVpbY_003D) ? new IntPtr(num) : new IntPtr((int)(uint)num)));
				break;
			}
			case 13:
			{
				long num2 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				intPtr = ((!flag) ? ((!_0023_003DziDLVpbY_003D) ? new IntPtr(num2) : new IntPtr((long)(ulong)num2)) : ((!_0023_003DziDLVpbY_003D) ? new IntPtr(unchecked((int)num2)) : new IntPtr((int)(ulong)num2)));
				break;
			}
			case 8:
			{
				double num3 = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
				intPtr = ((!flag) ? ((!_0023_003DziDLVpbY_003D) ? new IntPtr(unchecked((long)num3)) : new IntPtr((long)(ulong)num3)) : ((!_0023_003DziDLVpbY_003D) ? new IntPtr(unchecked((int)(ulong)num3)) : new IntPtr((int)(ulong)num3)));
				break;
			}
			case 19:
				intPtr = ((!_0023_003DziDLVpbY_003D) ? new IntPtr(Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())) : new IntPtr(Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D obj = new _0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D();
			obj._0023_003DzbBdLl_0024ovIBkh8mMBtnusWhikQk0Aj3SNshCD9qg_003D(intPtr);
			_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
		}
	}

	private static void _0023_003DzexpOTCnLSfXpA0hIPZ0xEGMgFEAu(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz0LZ3a2KNB2rgSf490RJHmy0_003D(((_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzwyKpuA_mNwWyADXJn6Q3N8s_003D());
	}

	private static bool _0023_003DzXq_0024OCFvwIkktKeYS_wb7XWgWQpEC()
	{
		return false;
	}

	private static object _0023_003Dzua402qH0PvFyh_SwU_t_0024Pt1hg0nvpQRf9w_003D_003D(MethodBase _0023_003DziDLVpbY_003D, object _0023_003Dz5rQzobg_003D, object[] _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		if (!_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D._0023_003DzR58imxw_003D._0023_003DziDLVpbY_003D)
		{
			return _0023_003Dz0SAYSWlBoo6DiPJ2iw_003D_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
		}
		return _0023_003DzrOasWdkNxP5xSmuoAMTQ_0024Z6JHx0pW87i66jlGoS4sPoe(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
	}

	private static void _0023_003DzbOSL4SqlRGdyzUt3eYTA554_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(type);
	}

	private static void _0023_003DzP6eSZsPnVEManckWZ6lSXtLfSC79(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzBJFJHwk_003D = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
	}

	private static void _0023_003DzJsqhFzPH6TB_0024HWLf3uq3lV0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzu0a9M9zXrZOr09UDVft0TcHevaFuOoyqag_003D_003D(2);
	}

	private static void _0023_003Dzn9OcxySvMfThsY2qQ_0024a7cx2Kmf0RAhP0JQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzz9Rp_00249b6lGMYj_jZQQ_003D_003D(_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D);
	}

	private void _0023_003DzdjM_2jv3RJCvz2e7G8N4hr_tmbjLldgOzkQHpdc_003D(ref _0023_003DzAvn2b38_003D _0023_003DziDLVpbY_003D, MethodBase _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D)
	{
		bool flag = false;
		if (_0023_003Dz5rQzobg_003D.DeclaringType == typeof(Interlocked) && _0023_003Dz5rQzobg_003D.IsStatic)
		{
			string name = _0023_003Dz5rQzobg_003D.Name;
			if (name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908638) || name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908616) || name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908606) || name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908590) || name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908571) || name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908555))
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
				Monitor.Enter(_0023_003DzRpXgovo_003D);
				_0023_003DziDLVpbY_003D._0023_003DziDLVpbY_003D = true;
			}
		}
	}

	private static void _0023_003DzNe_wiEPYWTnP4GktEFXvcHUkhYTTKf5Udw_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (_0023_003DziDLVpbY_003D._0023_003Dz_00246_zqjGaTSjgbTyBE2pnCP8J5nm4uPBMYA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2, type))
		{
			_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
			return;
		}
		throw new InvalidCastException();
	}

	private string _0023_003DzAtENpYMCi0SVBdywzDDR6hQhtlnL(_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D _0023_003DziDLVpbY_003D)
	{
		Type type = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003DziDLVpbY_003D._0023_003Dzx5X59GHDhQCY67nsHADQ8HctXRx6EilYiQ_003D_003D(), _0023_003Dz5rQzobg_003D: false);
		_0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D[] array = _0023_003DziDLVpbY_003D._0023_003Dz2ab977dO_V4bp_0024NWmafMNKyu2B0c();
		string[] array2 = new string[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(array[i]._0023_003DzOwLa1TRtX2zG2yT751wGPiNvTQKexziEvVO416VO0KpQ(), _0023_003Dz5rQzobg_003D: false)?.FullName;
		}
		string text = string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108), array2);
		return type.FullName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + _0023_003DziDLVpbY_003D._0023_003DzFMr9dCVbs1HItIt4Lt5pQGuApOTN() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083) + text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091);
	}

	private static void _0023_003DzODh_0024MDRhHTFiHWvTKTCmFLGsMtH6n5mC1quGQ_A_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(byte));
	}

	private static void _0023_003DzUrgQ4nOlco8alJ_0024TqPH4_0024hlE20_0024O(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(-1);
	}

	private static bool _0023_003Dz8wovo1mlTaoN1g0g3IAMk1d7cQeEIOfYr3TuVio_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		bool flag = false;
		switch (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
		{
		case 1:
			return (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() > (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		case 13:
			return (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() > (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		case 8:
		{
			double num3 = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			double num4 = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			return num3 > num4 || double.IsNaN(num3) || double.IsNaN(num4);
		}
		case 0:
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 7 && _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == null)
			{
				return ((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DziDLVpbY_003D)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee() != IntPtr.Zero;
			}
			return ((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DziDLVpbY_003D)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee() != ((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003Dz5rQzobg_003D)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee();
		case 20:
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 7 && _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == null)
			{
				return ((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DziDLVpbY_003D)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D() != UIntPtr.Zero;
			}
			return ((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DziDLVpbY_003D)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D() != ((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003Dz5rQzobg_003D)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D();
		case 7:
			return ((_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D)_0023_003DziDLVpbY_003D)._0023_003DzP7k5Y6ukvcg_ixjUAKpLm2Y7IkNc3hTJEKeYFNObePLS() != ((_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D)_0023_003Dz5rQzobg_003D)._0023_003DzP7k5Y6ukvcg_ixjUAKpLm2Y7IkNc3hTJEKeYFNObePLS();
		case 25:
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 7 && _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == null)
			{
				return true;
			}
			return ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyRdZjLZLQVmvToKIwRdaQqc_003D)_0023_003DziDLVpbY_003D)._0023_003DzHAnywLNcTsWPY7155LurFcQcmnn8() != ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyRdZjLZLQVmvToKIwRdaQqc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzHAnywLNcTsWPY7155LurFcQcmnn8();
		case 19:
		{
			long num = Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DziDLVpbY_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D());
			long num2 = ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 1) ? Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()) : ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
			return num > num2;
		}
		default:
			return _0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() != _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
	}

	private static void _0023_003DzD_0024OQXoPLvXamI1I7JXB06H9k44oa2AIVIvG6UsCzOAIf(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzFcd5b1NerPBv8Ji62_RSmeXGISQf();
	}

	private static void _0023_003Dzkj47N3_EaGTjeUx_0024tnILwH4aF3_m1MKwhlePl5Q_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(float));
	}

	private FieldInfo _0023_003DzsH6I9ZDv5gPH5Am4bCK2nNxE2uzwyQ3uDe_00241OaRt2yRO(int _0023_003DziDLVpbY_003D)
	{
		lock (_0023_003DzHit7vU4_003D)
		{
			bool flag = true;
			FieldInfo fieldInfo;
			if (flag && _0023_003DzHit7vU4_003D.TryGetValue(_0023_003DziDLVpbY_003D, out var value))
			{
				fieldInfo = (FieldInfo)value;
			}
			else
			{
				_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 = _0023_003DzLrd1XNI9dc0qU09uargDhdLHbDdl(_0023_003DziDLVpbY_003D);
				fieldInfo = _0023_003DzsYBc2s1QQqKkdKJ2_0024__edoeAN1LNATrFlWF90ZFwwNz9(_0023_003DziDLVpbY_003D, _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2, ref flag);
				if (flag)
				{
					_0023_003DzHit7vU4_003D.Add(_0023_003DziDLVpbY_003D, fieldInfo);
				}
			}
			_0023_003Dzk9G2xiUurtSg1qn7uA3dhHyRVACuGPtfng_003D_003D(fieldInfo);
			return fieldInfo;
		}
	}

	private static void _0023_003DzO6BJVMz2TXdlNtTcXYkMzdM_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzIkM3CaSWupD4_0024gmIh5V76vLJzMAa(1);
	}

	private static bool _0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		bool result = false;
		switch (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
		{
		case 1:
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())));
			}
			result = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() > ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
			break;
		case 13:
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())));
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				return _0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()));
			}
			result = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() > ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			break;
		case 19:
			return _0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DziDLVpbY_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), _0023_003Dz5rQzobg_003D);
		case 8:
		{
			double num = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			double num2 = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			result = !double.IsNaN(num) && !double.IsNaN(num2) && num > num2;
			break;
		}
		}
		return result;
	}

	private static void _0023_003DzaWctMIij2WzYpOucpiI7ikw_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dz5rQzobg_003D);
	}

	private static void _0023_003DzDGEgL6g4OEdmxDsKm1B1pT1bdrEg(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(_0023_003DzDNpeQO0_003D);
	}

	private bool _0023_003DzW4gJFzQX7i_0024q1rfO9DorcU0_003D(MethodInfo _0023_003DziDLVpbY_003D, _0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D _0023_003Dz5rQzobg_003D, Type[] _0023_003DzAvn2b38_003D, out int _0023_003DzR58imxw_003D)
	{
		_0023_003DzR58imxw_003D = 0;
		if (!_0023_003DziDLVpbY_003D.IsGenericMethodDefinition)
		{
			return false;
		}
		ParameterInfo[] parameters = _0023_003DziDLVpbY_003D.GetParameters();
		if (parameters.Length != _0023_003Dz5rQzobg_003D._0023_003DzyX36d7w_gtlkHHtxkE7BCVaNs1sx().Length)
		{
			return false;
		}
		if (_0023_003DziDLVpbY_003D.GetGenericArguments().Length != _0023_003Dz5rQzobg_003D._0023_003DzzetAtAYHtCQBku1Ez7JzQfSjQHSLJPus59etvPc_003D().Length)
		{
			return false;
		}
		for (int i = -1; i < parameters.Length; i++)
		{
			Type type = ((i == -1) ? _0023_003DziDLVpbY_003D.ReturnType : parameters[i].ParameterType);
			if (_0023_003DzAvn2b38_003D != null && type.IsGenericParameter && type.DeclaringMethod != null)
			{
				type = _0023_003DzAvn2b38_003D[type.GenericParameterPosition] ?? type;
			}
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 = ((i == -1) ? _0023_003Dz5rQzobg_003D._0023_003Dz40KZulNImcDT8fkUqtaFuA8YdKEH() : _0023_003Dz5rQzobg_003D._0023_003DzyX36d7w_gtlkHHtxkE7BCVaNs1sx()[i]);
			if (_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 != null)
			{
				if (!_0023_003Dzl5d5naiggXQxbE_0024To77xnk4_003D(type, _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2, out var num))
				{
					return false;
				}
				if (i >= 0)
				{
					_0023_003DzR58imxw_003D += num;
				}
			}
		}
		return true;
	}

	public object _0023_003DzJQsHoaddAVu974s1TAfNzRQdzuuR91eo4TEdUIQ_003D(Stream _0023_003DziDLVpbY_003D, string _0023_003Dz5rQzobg_003D, object[] _0023_003DzAvn2b38_003D, Type[] _0023_003DzR58imxw_003D, Type[] _0023_003DzmQTFaQA_003D, object[] _0023_003DzWYPqg2E_003D)
	{
		this.m__0023_003DzEWLeis8_003D = _0023_003DziDLVpbY_003D;
		_0023_003Dz_n5BZhw_IK4Rr1iI39agUSqxM0VPWNeUpoJ8wdXTYDmh(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		return _0023_003Dzzo2beSOiRhkSPKWQjtSuTaysq4HG48olaRV1zc8CBAkO(_0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D);
	}

	private static void _0023_003Dzr0Ih4mbbifSvWBjMMqDMGze_1VvBMZOoiM_00247sC8_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003Dz8wovo1mlTaoN1g0g3IAMk1d7cQeEIOfYr3TuVio_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2) ? 1 : 0));
	}

	private static void _0023_003Dz_0024mElkK7sctwicDnOAEtkEH6Us5_B8qw0qQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D _0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D2 = (_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003Dz5rQzobg_003D;
		_0023_003DziDLVpbY_003D._0023_003DzIkM3CaSWupD4_0024gmIh5V76vLJzMAa(_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D2._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
	}

	private static void _0023_003DzYJM7OEzFo9Uao6USz0xr5Uw_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzs8e6IcKEHH3pzHTeTkSowk0_003D(_0023_003DziDLVpbY_003D: false);
	}

	private static void _0023_003DzMjr32Hx3KhdUlKAmy8F_0024maWEzryghh8yNI_QGz8_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dz5rQzobg_003D);
	}

	private static void _0023_003DzeN9iOWRRxFVa_qwAsKDjqH3q09MCOnyFF8kMjkw_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzs8e6IcKEHH3pzHTeTkSowk0_003D(_0023_003DziDLVpbY_003D: true);
	}

	private static void _0023_003Dz4LmjV5b_00245mxwTCXexH_GPB98j7vt(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
	}

	private static void _0023_003DzeY_Rq6DE2aXBYmaLhn29MnHJCyayO_z7vxE8Jkk_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
	}

	private static void _0023_003Dzpe2Wp_0024IfQypLZ_00248Yyf59ZrFcstNRI_0024lLBH8mJFY_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(long));
	}

	private static void _0023_003DzqfwSyegLEzwMxkE5jefoZRjoz4n7kvergxX8laenkcbt(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(ushort));
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzcsKUV375wg9IEHdp4A_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				if (!_0023_003DzR58imxw_003D)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					int num3 = ((!_0023_003DzAvn2b38_003D) ? (num - num2) : checked(num - num2));
					return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num3);
				}
				uint num4 = (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				uint num5 = (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				uint num6 = ((!_0023_003DzAvn2b38_003D) ? (num4 - num5) : checked(num4 - num5));
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D((int)num6);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003Dz4x2et3pxr8KgUQ2n8g_003D_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003Dz4x2et3pxr8KgUQ2n8g_003D_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
				}
				return _0023_003DzcsKUV375wg9IEHdp4A_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003Dz4x2et3pxr8KgUQ2n8g_003D_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				return _0023_003Dz4x2et3pxr8KgUQ2n8g_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003Dz4x2et3pxr8KgUQ2n8g_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
				}
				return _0023_003Dz4x2et3pxr8KgUQ2n8g_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8 && _0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8)
		{
			_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
			obj._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D() - ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D());
			return obj;
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzcsKUV375wg9IEHdp4A_003D_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			return _0023_003DzcsKUV375wg9IEHdp4A_003D_003D(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003Dzc4opDCSZIz2bTrW6C5bCqoQ_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(byte));
	}

	private static void _0023_003DzvMQ620k0mja8Lb_0024eF0N4QzrC5eg4iHqFXLHc1bQ_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 = (_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D)_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (type.IsValueType)
		{
			object obj = _0023_003DziDLVpbY_003D._0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2)._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
			if (_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzoIht4H3MBiobPh2HDJb056MsRfdA_00245XIgOj_0024Oec_003D(type))
			{
				_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D obj2 = new _0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D();
				obj2._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(type);
				_0023_003DziDLVpbY_003D._0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2, obj2);
				return;
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(obj, _0023_003DzuNKSWtY_0024_0024ExI7KlNuM5gS_002417mtXjL3l3OMuckYc_003D(fieldInfo.FieldType));
			}
		}
		else
		{
			_0023_003DziDLVpbY_003D._0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2, new _0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D());
		}
	}

	private static string _0023_003DzkQLjItqF_lIZYwJQbODeKCgUFOeXie_Nf8u4QtQ_003D(MethodBase _0023_003DziDLVpbY_003D)
	{
		Type declaringType = _0023_003DziDLVpbY_003D.DeclaringType;
		ParameterInfo[] parameters = _0023_003DziDLVpbY_003D.GetParameters();
		string[] array = new string[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			array[i] = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908656), parameterInfo.ParameterType, parameterInfo.Name);
		}
		string text = string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108), array);
		return declaringType.FullName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + _0023_003DziDLVpbY_003D.Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083) + text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091);
	}

	private static void _0023_003DzLhjpA_0024sz1iMVJeyWY7l1RQmNt2bY(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(6);
	}

	private static void _0023_003Dzxyb_AKcdLipt_0024iCEIrfYBLCDUeEOgFPSu1RWdLowZgv_0024(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(checked(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (byte)(uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (byte)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => (byte)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			8 => (byte)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((byte)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((byte)(uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003Dzg7fjnjqgMs7sAHkskp3zfnlJTKMwMP2UzA8q9OyRVP_00240(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzz9Rp_00249b6lGMYj_jZQQ_003D_003D(typeof(float));
	}

	private FieldInfo _0023_003DzsYBc2s1QQqKkdKJ2_0024__edoeAN1LNATrFlWF90ZFwwNz9(int _0023_003DziDLVpbY_003D, _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003Dz5rQzobg_003D, ref bool _0023_003DzAvn2b38_003D)
	{
		if (_0023_003Dz5rQzobg_003D._0023_003DzOl4znCSQJV_o3jzYnD1EuZw5Wuu52ADXGg_003D_003D() == 0)
		{
			_0023_003DzAvn2b38_003D = false;
			return this.m__0023_003DzshZYG54_003D.ResolveField(_0023_003Dz5rQzobg_003D._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p());
		}
		_0023_003DqcPNgWZrHWoJl5uLGrkFcm957xX4d5ohK1WUbm09rjfs_003D _0023_003DqcPNgWZrHWoJl5uLGrkFcm957xX4d5ohK1WUbm09rjfs_003D2 = (_0023_003DqcPNgWZrHWoJl5uLGrkFcm957xX4d5ohK1WUbm09rjfs_003D)_0023_003Dz5rQzobg_003D._0023_003DzpKaM9DJ9LSi0XInJkPIbPujKUbSQ();
		Type type = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003DqcPNgWZrHWoJl5uLGrkFcm957xX4d5ohK1WUbm09rjfs_003D2._0023_003DzsuaOMh5BcE4MZ0z9pH_0024wzHp8Hqjr_0024FW8Ig_003D_003D()._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p(), _0023_003Dz5rQzobg_003D: false);
		if (type.IsGenericType)
		{
			_0023_003DzAvn2b38_003D = false;
		}
		return type.GetField(bindingAttr: _0023_003DzywBQyeN0kvmSlw6Yu1_0024kgx_0024lqk6alGjr4A_003D_003D(_0023_003DqcPNgWZrHWoJl5uLGrkFcm957xX4d5ohK1WUbm09rjfs_003D2._0023_003DzsvtdEFDEPE5GttbK91jhsSI_003D()), name: _0023_003DqcPNgWZrHWoJl5uLGrkFcm957xX4d5ohK1WUbm09rjfs_003D2._0023_003DzrgX4v_0024kclD12CO_b7s33rti_0024xPIV());
	}

	private static void _0023_003DzMqNcyWq9m1mEW9HKP1uydnqGVlPU(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DziDLVpbY_003D._0023_003DzjVzO5UR0YUtHT_0024LzWi_0024gXSR8ejzL(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2));
	}

	private static void _0023_003DzqCERRgWn1UAgxXgLK0NsYhZaoIjZ(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzZoHutE04P0sbCnLGpmJQ5GI_003D(_0023_003DziDLVpbY_003D: false, _0023_003Dz5rQzobg_003D: false);
	}

	public object _0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(Stream _0023_003DziDLVpbY_003D, string _0023_003Dz5rQzobg_003D, object[] _0023_003DzAvn2b38_003D)
	{
		return _0023_003DzJQsHoaddAVu974s1TAfNzRQdzuuR91eo4TEdUIQ_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, null, null, null);
	}

	private static void _0023_003Dz212J94WICL7Ors4WSg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		double num = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			8 => ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
		obj._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(num);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzTNPcvRRwg52w9eqd5hkODCWAgGmFIshRLYPQyqZFzGiA(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				if (!_0023_003DzR58imxw_003D)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					int num3 = ((!_0023_003DzAvn2b38_003D) ? (num * num2) : checked(num * num2));
					return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num3);
				}
				uint num4 = (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				uint num5 = (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				uint num6 = ((!_0023_003DzAvn2b38_003D) ? (num4 * num5) : checked(num4 * num5));
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D((int)num6);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003DztXDI47kJ270znHgEobUi8OxUGAh7(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DztXDI47kJ270znHgEobUi8OxUGAh7(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
				}
				return _0023_003DzTNPcvRRwg52w9eqd5hkODCWAgGmFIshRLYPQyqZFzGiA(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003DztXDI47kJ270znHgEobUi8OxUGAh7(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				return _0023_003DztXDI47kJ270znHgEobUi8OxUGAh7(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DztXDI47kJ270znHgEobUi8OxUGAh7(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
				}
				return _0023_003DztXDI47kJ270znHgEobUi8OxUGAh7(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8 && _0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8)
		{
			_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
			obj._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D() * ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D());
			return obj;
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003DzTNPcvRRwg52w9eqd5hkODCWAgGmFIshRLYPQyqZFzGiA(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			return _0023_003DzTNPcvRRwg52w9eqd5hkODCWAgGmFIshRLYPQyqZFzGiA(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
		}
		throw new InvalidOperationException();
	}

	private static _0023_003DzWYPqg2E_003D _0023_003Dzlg8Ck8b2vxV2AHZt6Q7nMJQ2c7FQ(MethodBase _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D)
	{
		DynamicMethod dynamicMethod = null;
		if (dynamicMethod == null)
		{
			dynamicMethod = new DynamicMethod(string.Empty, _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D, new Type[2]
			{
				_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D,
				_0023_003DzN6G05Lg_003D
			}, typeof(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D).Module, skipVisibility: true);
		}
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		ParameterInfo[] parameters = _0023_003DziDLVpbY_003D.GetParameters();
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
			_0023_003DzLKxZANrFOB7hqYlyirh3OMGaxsZjF6VtDGqshSc_003D(iLGenerator, k);
			iLGenerator.Emit(OpCodes.Ldelem_Ref);
			_0023_003Dzf_16IKMGbD8J4FGV0w_003D_003D(iLGenerator, array[k]);
			iLGenerator.Emit(OpCodes.Stloc, array2[k]);
		}
		if (flag)
		{
			iLGenerator.BeginExceptionBlock();
		}
		if (!_0023_003DziDLVpbY_003D.IsStatic && !_0023_003DziDLVpbY_003D.IsConstructor)
		{
			iLGenerator.Emit(OpCodes.Ldarg_0);
			Type declaringType = _0023_003DziDLVpbY_003D.DeclaringType;
			if (declaringType.IsValueType)
			{
				iLGenerator.Emit(OpCodes.Unbox, declaringType);
				_0023_003Dz5rQzobg_003D = false;
			}
			else
			{
				_0023_003DzU6X488kkrEx__bUHUXBK3M6hWtGyw0YnfbtOTiQ_003D(iLGenerator, declaringType);
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
		if (_0023_003DziDLVpbY_003D.IsConstructor)
		{
			iLGenerator.Emit(OpCodes.Newobj, (ConstructorInfo)_0023_003DziDLVpbY_003D);
			_0023_003Dz_1PccnmcqfDsVxusMFIROD063EengSRmFQbRu_0024k2T1wY(iLGenerator, _0023_003DziDLVpbY_003D.DeclaringType);
		}
		else
		{
			MethodInfo methodInfo = (MethodInfo)_0023_003DziDLVpbY_003D;
			if (!_0023_003Dz5rQzobg_003D || _0023_003DziDLVpbY_003D.IsStatic)
			{
				iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
			}
			else
			{
				iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
			}
			if (methodInfo.ReturnType == _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzbfrNXYE_003D)
			{
				iLGenerator.Emit(OpCodes.Ldnull);
			}
			else
			{
				_0023_003Dz_1PccnmcqfDsVxusMFIROD063EengSRmFQbRu_0024k2T1wY(iLGenerator, methodInfo.ReturnType);
			}
		}
		if (flag)
		{
			LocalBuilder local = iLGenerator.DeclareLocal(_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D);
			iLGenerator.Emit(OpCodes.Stloc, local);
			iLGenerator.BeginFinallyBlock();
			for (int m = 0; m < array.Length; m++)
			{
				if (parameters[m].ParameterType.IsByRef)
				{
					iLGenerator.Emit(OpCodes.Ldarg_1);
					_0023_003DzLKxZANrFOB7hqYlyirh3OMGaxsZjF6VtDGqshSc_003D(iLGenerator, m);
					iLGenerator.Emit(OpCodes.Ldloc, array2[m]);
					if (array2[m].LocalType.IsValueType || _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzabUOCE0NIf0_0024ueqjA0946qu_00246SbMH3py0xa3ro4LUTfS(array2[m].LocalType).IsGenericParameter)
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
		return (_0023_003DzWYPqg2E_003D)dynamicMethod.CreateDelegate(typeof(_0023_003DzWYPqg2E_003D));
	}

	private static void _0023_003Dz_00246WTcJSIYKR332KOWKfMfGmKMeLF(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz0LZ3a2KNB2rgSf490RJHmy0_003D(((_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003Dz5rQzobg_003D)._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
	}

	private static BindingFlags _0023_003DzywBQyeN0kvmSlw6Yu1_0024kgx_0024lqk6alGjr4A_003D_003D(bool _0023_003DziDLVpbY_003D)
	{
		BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
		if (_0023_003DziDLVpbY_003D)
		{
			return bindingFlags | BindingFlags.Static;
		}
		return bindingFlags | BindingFlags.Instance;
	}

	private void _0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		switch (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
		{
		case 2:
			((_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D)_0023_003DziDLVpbY_003D)._0023_003DzHZ5NKvAS4A9t8ypYPcqODs_XKjmA()._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003Dz5rQzobg_003D);
			break;
		case 23:
			this.m__0023_003Dzt_m8zV0_003D[((_0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D)_0023_003DziDLVpbY_003D)._0023_003DzNAQX8ra3l1_0024XGAa1nNj6HCKZAd1O1wd8Wyz3ozD5SlgH()]._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003Dz5rQzobg_003D);
			break;
		case 18:
		{
			_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2 = (_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D)_0023_003DziDLVpbY_003D;
			FieldInfo fieldInfo = _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2._0023_003DzddbcHyilBA8MndTeiRwzcmFqKumQ();
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D(), fieldInfo.FieldType);
			fieldInfo.SetValue(_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2._0023_003DzdUxw3_0024V0zjE7LCNS0d6jNIXKeWTEQSZ1_Q_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
			_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 = _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2._0023_003DzZ2yGYRGp1t0bYVNa54m1sIU_003D();
			if (_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 != null && fieldInfo.DeclaringType.IsValueType)
			{
				_0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2._0023_003DzdUxw3_0024V0zjE7LCNS0d6jNIXKeWTEQSZ1_Q_003D_003D(), null));
			}
			break;
		}
		case 11:
		case 24:
		{
			_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D2 = (_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D)_0023_003DziDLVpbY_003D;
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D(), _0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D2._0023_003Dz5jUufOEVwSYnI8es2HjmwoYw68mRMVvpohfxSKo_003D());
			_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D2._0023_003Dzz8ITt_bpkzDd0GCMYerRwDmMHC1nn0MrPutecN0h66B4tayp1FX4ZdT0hKBUoRHIi3NvfxD5q0H6W58d3QSiA5tlgq3Z(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
			break;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void _0023_003DzcLVNAa8W3VqN1PrfdtyYkIx7DwC5(Stream _0023_003DziDLVpbY_003D, long _0023_003Dz5rQzobg_003D, string _0023_003DzAvn2b38_003D)
	{
		int num = _0023_003DznGtUd4B6Wfp8z__tmYb3_0024Raz5pOZ();
		_0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D _0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D2 = new _0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D(_0023_003DziDLVpbY_003D, num);
		_0023_003Dz0yNzT9M_003D = new _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D(_0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D2);
		if (_0023_003DzAvn2b38_003D != null)
		{
			_0023_003Dz5rQzobg_003D = _0023_003DzPrIFfKqBT5u3mkmueJsm7dVS7bx2hen_0024ghN2c2A_003D(_0023_003DzAvn2b38_003D);
		}
		_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D _0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D2 = _0023_003Dz0yNzT9M_003D._0023_003DzUXjbc9BY9W9m2seLWnn7jsJDEathvvwviQ_003D_003D();
		lock (_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D2)
		{
			_0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D2._0023_003DzUQ_bGErryTDpszeAu244IzixOQag9otlJo42_0024oeegDPivRgB6_0024XwD9KrkyM3tgZwAvXv4b_A7Pkg5OViPw_003D_003D(_0023_003Dz5rQzobg_003D, 0);
			_0023_003Dz1iNhYm_3WcC6odZhwRc2v96vbTh_0024(_0023_003Dz0yNzT9M_003D);
			m__0023_003DzTSeNR8Q_003D = _0023_003Dz_0024ZZdcvqTQ08_qGC5PugOjps_003D(_0023_003Dz0yNzT9M_003D);
			_0023_003DzjbqS1qE_003D = _0023_003Dzklbqkm1Y_0024hGwg5lLtsDsGCkqhPyrxyjp4gb4kfo_003D(_0023_003Dz0yNzT9M_003D);
			this.m__0023_003DzId5C3LA_003D = _0023_003DzFB4MLVBUbFk99qK0uUZhT_wWrqPlGtcnZno5B4E_003D(_0023_003Dz0yNzT9M_003D);
		}
		_0023_003Dzn38u8aV98_00242qJOrydP7_0024VPOja_0024MLD4YmdNsUKes_003D();
	}

	private void _0023_003DzMvb0RpkBv8lUDf_0024qVJCBuF1XVH_Z(ref _0023_003DzAvn2b38_003D _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003DziDLVpbY_003D)
		{
			Monitor.Exit(_0023_003DzRpXgovo_003D);
		}
	}

	private static void _0023_003DzzsoBcV3r6mw4o18WyJfWnck_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(long));
	}

	private void _0023_003Dzs12LFbj_0024U7TMDTjuE_0024QMr5V4WvhQPpLitMz_O0kJxSlJ(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dz0FXxuhu31qzow8Y4rr03gUdK5x8Lt026Ag_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2, _0023_003DziDLVpbY_003D));
	}

	private static void _0023_003DzkUx9zDGBsWGA_ivebQoXmX8jrEOw(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz97pidvc061He_0024DIu4r5pe6u1H3i1(_0023_003DziDLVpbY_003D: false);
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz9SI33zTg8BbNw3Q8Nws6S3wUpSIQLpQPMUJJdwedXwau(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num | num2);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				int num3 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					long num4 = Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num3 | num4);
				}
				int num5 = Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num3 | num5);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				long num6 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				long num7 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num6 | num7);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				int num8 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				long num9 = Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num8 | num9);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				int num10 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D()) | num10);
				}
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D()) | num10);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				long num11 = Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				long num12 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num11 | num12);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num13 = Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					long num14 = Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
					return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num13 | num14);
				}
				int num15 = Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				int num16 = Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num15 | num16);
			}
		}
		throw new InvalidOperationException();
	}

	private int _0023_003Dzu4ZrJCpFVxUa7kb2HLo0s6o_003D()
	{
		return 1055444913;
	}

	private static void _0023_003DzjmBwJJBPJH9SielIhz2rIDI_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908261));
	}

	private static void _0023_003DzgjJ6xTl0xLOq9ODIRH0PuZY_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzu0a9M9zXrZOr09UDVft0TcHevaFuOoyqag_003D_003D(((_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003Dz5rQzobg_003D)._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
	}

	private static void _0023_003DzJPwz0GMwRg00zHaksVfNWMpM1hFi(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D(), type);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
	}

	private static void _0023_003Dzii_CH5JYx4Ig_0024a0iSPk0ndSZR3CwyzWRvB2te4E_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(ushort));
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DzE8QrneA_003D;
		if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 != null)
		{
			_0023_003DzE8QrneA_003D = this.m__0023_003DzmQTFaQA_003D;
			this.m__0023_003DzmQTFaQA_003D = null;
			return _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2;
		}
		return _0023_003DzoMNiNRw_003D.Pop();
	}

	private static void _0023_003DzqaQXNyBbGKK1IN8PkWsTTAem1ERSUNfbNg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		UIntPtr uIntPtr = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => new UIntPtr((uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), 
			13 => new UIntPtr((ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()), 
			19 => new UIntPtr(Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => new UIntPtr((ulong)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D obj = new _0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D();
		obj._0023_003Dzxoi92Aw50_ocg_0024mxPSwSj5w_003D(uIntPtr);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static void _0023_003DzoHXVgVPiBJIAysXCdX6WhO_002450Z_7(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
	}

	private static void _0023_003Dz6GaUsvitrYeChM2doHwOS_PxtOi4(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907586));
	}

	private static void _0023_003DziR4W8T8XTgkp_0024rqp7r4Iy9mTM_3vZQlFFiiS7GSxYtGU(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz8CM8lG3MAfx_0024kqUlvJK4vBO75C6MuyZIio134ps_003D(_0023_003DziDLVpbY_003D: true);
	}

	private static Exception _0023_003DzkUNJcRRmj4K6rfgGEX_moeb6R5D_0024(string _0023_003DziDLVpbY_003D, string _0023_003Dz5rQzobg_003D)
	{
		return new TypeLoadException(_0023_003DzAWcPhgVgng7uZTM7bm7UobvPaQJpGckazA8wrdc_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907958) + _0023_003DziDLVpbY_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907906) + _0023_003Dz5rQzobg_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930)));
	}

	private static void _0023_003DzHmw47g0Qa1ROlxVcVwQRSsR2GSL_0024(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type t = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Marshal.SizeOf(t)));
	}

	private static void _0023_003DzoLsqfqM4qD7t9yiP6EvFyXMTbSR8BOkQ3nVTKLs_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzvqLwvubv2Id3oqbIJDFL_KvV9rdFqVtTcKkVEDo_003D(_0023_003DziDLVpbY_003D: false);
	}

	private void _0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908159));
		}
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2;
		if (_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D() != null)
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D;
		}
		else
		{
			switch (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
			{
			case 22:
			{
				_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj9 = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
				obj9._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(((_0023_003Dqc2b0YBioXegIu1gaJQSGraoGfjfP1vO_0024YGZjzm2GTrA_003D)_0023_003DziDLVpbY_003D)._0023_003Dz9fgWMhYJAzQII4rL6uJbeL36MMoW6hbkygjCbGw_003D());
				obj9._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = obj9;
				break;
			}
			case 12:
			{
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj8 = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(((_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D)_0023_003DziDLVpbY_003D)._0023_003DzwyKpuA_mNwWyADXJn6Q3N8s_003D());
				obj8._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = obj8;
				break;
			}
			case 26:
			{
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj7 = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(((_0023_003DqNRMsnRsOD6zmKIGS86f_zhQLlpZw3gLRJYOCYg7GPX8_003D)_0023_003DziDLVpbY_003D)._0023_003Dz8N_0024_00242hkAw1senTPCjH3t6gx95N1cl9NWZAuC1wAxnlAC());
				obj7._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = obj7;
				break;
			}
			case 17:
			{
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj10 = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(((_0023_003DqubUcAaZEWA6CJOJ0kia_0024ue97M_fGbzb_0024ksylKcCatwI_003D)_0023_003DziDLVpbY_003D)._0023_003Dz47Dc_0024nODgtMYB1KgFltIFloR0R4QLaqIIrtRYauRp56L());
				obj10._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = obj10;
				break;
			}
			case 16:
			{
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj5 = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(((_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003DziDLVpbY_003D)._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
				obj5._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = obj5;
				break;
			}
			case 3:
			{
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj4 = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D((int)((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003DziDLVpbY_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D());
				obj4._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = obj4;
				break;
			}
			case 14:
			{
				_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D obj6 = new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D((long)((_0023_003DqUwzBjw0UTwLX7f6bfoiplBUelfb0TFtlGvuP9w77axg_003D)_0023_003DziDLVpbY_003D)._0023_003DzQtobEM_0024mGFG4cJOd8N9nB6W9_0024EFR_00243Nduw_003D_003D());
				obj6._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = obj6;
				break;
			}
			case 15:
			{
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj3 = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(((_0023_003DqL8EtmP2ttHYv_0024qzi_0024UuDnI3Re75Q2TOejs8zsNquFkg_003D)_0023_003DziDLVpbY_003D)._0023_003DzImEcljninR5_0024UdPjovYUMVpXktUO() ? 1 : 0);
				obj3._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = obj3;
				break;
			}
			case 6:
			{
				_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj2 = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(((_0023_003DqER3f_gxDAqhvJuR_0024dnNr_XYt7WMp_BvdvlFKHhyi0p8_003D)_0023_003DziDLVpbY_003D)._0023_003Dz_FiiY_00248BQxLwUTlvfOwD_sY_003D());
				obj2._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = obj2;
				break;
			}
			case 7:
			{
				object obj = _0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
				if (obj == null)
				{
					_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D;
					break;
				}
				Type type = obj.GetType();
				if (type.HasElementType && !type.IsArray)
				{
					type = type.GetElementType();
				}
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = ((!(type != null) || type.IsValueType || type.IsEnum) ? _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, type) : _0023_003DziDLVpbY_003D);
				break;
			}
			default:
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D;
				break;
			}
		}
		if (_0023_003DzE8QrneA_003D != null)
		{
			if (this.m__0023_003DzmQTFaQA_003D != null)
			{
				_0023_003DzoMNiNRw_003D.Push(this.m__0023_003DzmQTFaQA_003D);
			}
			this.m__0023_003DzmQTFaQA_003D = _0023_003DzE8QrneA_003D;
		}
		_0023_003DzE8QrneA_003D = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2;
	}

	private static void _0023_003Dz_um2oIB_fagfMg1_0024Smy2JEWLy12Bqw0OTbf345z2U_Tm(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz97pidvc061He_0024DIu4r5pe6u1H3i1(_0023_003DziDLVpbY_003D: true);
	}

	private _0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D _0023_003Dzi_0024EAmjSWSPNwmRxq_SmndQ_C47LnidL2fQ_003D_003D(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D obj = new _0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D();
		obj._0023_003DzaRUIfPRN7KQWabBL_T0TpZuPLo4t(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
		obj._0023_003DzL2dw5_CjXGxVrJvb_PmSbPINXpgbtrVFXg_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzAtDVoioEB_pO76hvK76nIp4_003D());
		return obj;
	}

	private static void _0023_003DzlWzQ3E2OEdf2hbOVM2wdUMNjslCQVFQzYgKbf4A_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzz9Rp_00249b6lGMYj_jZQQ_003D_003D(_0023_003DzDNpeQO0_003D);
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz4x2et3pxr8KgUQ2n8g_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		if (!_0023_003DzR58imxw_003D)
		{
			long num = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			long num2 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			long num3 = ((!_0023_003DzAvn2b38_003D) ? (num - num2) : checked(num - num2));
			return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		ulong num5 = (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		ulong num6 = ((!_0023_003DzAvn2b38_003D) ? (num4 - num5) : checked(num4 - num5));
		return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D((long)num6);
	}

	private void _0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(Type _0023_003DziDLVpbY_003D)
	{
		_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 = (_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D)_0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2)._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D(), _0023_003DziDLVpbY_003D));
	}

	private static void _0023_003Dz60gSlaxhPbyFqhc92oabBnC_0024yoQ_0024mLvGzv_jhp4_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzs12LFbj_0024U7TMDTjuE_0024QMr5V4WvhQPpLitMz_O0kJxSlJ(_0023_003DziDLVpbY_003D: true);
	}

	private _0023_003DqiA1d0doSeLnh_VY97pG2QAmWnWfc7TGak_ZZVSLSjcU_003D _0023_003DzhAbpAQZLxIlSoShIXCOKXa7_bq5INQfgau6CpDS99Y6B(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
		switch (_0023_003DziDLVpbY_003D._0023_003Dzde912cHpBbiEQCr8HB1DjQ0hCNmJS1u2_Avb9oE_003D())
		{
		case 2:
		{
			_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D obj6 = new _0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D();
			obj6._0023_003DzcvtqbYG3VFfIpe_00248kf7nzgY_003D(_0023_003DziDLVpbY_003D._0023_003DzOwJERBVAuTqjh71jJLc2f5rPKwjwHUqx8z35g6c_003D());
			obj6._0023_003DzSy26GCxrA4L4RYVvo1TrM4YVpji_(_0023_003DziDLVpbY_003D._0023_003DzAtDVoioEB_pO76hvK76nIp4_003D());
			obj6._0023_003DzogI_bvEygbpyHnknpg_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzAtDVoioEB_pO76hvK76nIp4_003D());
			obj6._0023_003DzwJbAqPsDVKI9vLm16tYlsV3agKFi(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			obj6._0023_003DzAgXMkT9ECwC785yo9BTX_eyIx_0024lqWcpHBg_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D _0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2 = obj6;
			int num5 = _0023_003DziDLVpbY_003D._0023_003DzsEfwRuJlkmPK8_0024FnCHJmVsqM5fxi();
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D[] array3 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D[num5];
			for (int k = 0; k < num5; k++)
			{
				int num6 = k;
				_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D obj7 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D();
				obj7._0023_003DzscYqKpAjgfXYbEAcNGsZTQL6x5hx(1);
				obj7._0023_003DzXK2L99BqaqTFBJ_0024S_0024g_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
				array3[num6] = obj7;
			}
			_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzlcjR5JIRSzrAZQAZ3nRHGRdu8GgAePZCWC8Ot9c_003D(array3);
			return _0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2;
		}
		case 1:
		{
			_0023_003DqcPNgWZrHWoJl5uLGrkFcm957xX4d5ohK1WUbm09rjfs_003D obj9 = new _0023_003DqcPNgWZrHWoJl5uLGrkFcm957xX4d5ohK1WUbm09rjfs_003D();
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D obj10 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D();
			obj10._0023_003DzscYqKpAjgfXYbEAcNGsZTQL6x5hx(1);
			obj10._0023_003DzXK2L99BqaqTFBJ_0024S_0024g_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			obj9._0023_003Dz0yvqmrq82A8piWmXhxHzuv0_003D(obj10);
			obj9._0023_003DzGiyGqF29yku1i9sfmJjpjUPMgfNf8yJvCmP1Xyk_003D(_0023_003DziDLVpbY_003D._0023_003DzOwJERBVAuTqjh71jJLc2f5rPKwjwHUqx8z35g6c_003D());
			obj9._0023_003DzChG14j4bUkmhDndRlDW_0024wb21UdKjLyu6Ow_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzAtDVoioEB_pO76hvK76nIp4_003D());
			return obj9;
		}
		case 3:
		{
			_0023_003DqNWCS8MTqiZMgZBpc9rePoD3Tf6ok_0024uTUh8pwkfYpM1M_003D obj8 = new _0023_003DqNWCS8MTqiZMgZBpc9rePoD3Tf6ok_0024uTUh8pwkfYpM1M_003D();
			obj8._0023_003DzLGvndnWwJb3CP0er6w_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			obj8._0023_003Dz5vIKo4yKV5g8lIthPGyb1ZjBGBd2xTvf2zJmyQK3sfL8(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			return obj8;
		}
		case 0:
		{
			_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D _0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2 = new _0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D();
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D obj2 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D();
			obj2._0023_003DzscYqKpAjgfXYbEAcNGsZTQL6x5hx(1);
			obj2._0023_003DzXK2L99BqaqTFBJ_0024S_0024g_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003Dz888dcmUQv4O698sNoKVDqzHaYukVCDD80g_003D_003D(obj2);
			_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003DztmlE1S7thb5IGC7pZnbhAcsnvh1QCtfC0MszC6k_003D(_0023_003DziDLVpbY_003D._0023_003Dzde912cHpBbiEQCr8HB1DjQ0hCNmJS1u2_Avb9oE_003D());
			_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003DzZbBytNP43QhhcuM3u9ZzFFP9E_EA96IE5ezBd5s_003D(_0023_003DziDLVpbY_003D._0023_003DzOwJERBVAuTqjh71jJLc2f5rPKwjwHUqx8z35g6c_003D());
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D obj3 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D();
			obj3._0023_003DzscYqKpAjgfXYbEAcNGsZTQL6x5hx(1);
			obj3._0023_003DzXK2L99BqaqTFBJ_0024S_0024g_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003DzoZ4OKHZ8gTf7NhWBTq1IC1g_003D(obj3);
			int num = _0023_003DziDLVpbY_003D._0023_003DzsEfwRuJlkmPK8_0024FnCHJmVsqM5fxi();
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D[] array = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = i;
				_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D obj4 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D();
				obj4._0023_003DzscYqKpAjgfXYbEAcNGsZTQL6x5hx(1);
				obj4._0023_003DzXK2L99BqaqTFBJ_0024S_0024g_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
				array[num2] = obj4;
			}
			_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003Dzqpt_yMU3v7ufDmF08CxpYDaHulU_7rLdgIIooF0oxWC6(array);
			int num3 = _0023_003DziDLVpbY_003D._0023_003DzsEfwRuJlkmPK8_0024FnCHJmVsqM5fxi();
			_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D[] array2 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D[num3];
			for (int j = 0; j < num3; j++)
			{
				int num4 = j;
				_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D obj5 = new _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D();
				obj5._0023_003DzscYqKpAjgfXYbEAcNGsZTQL6x5hx(1);
				obj5._0023_003DzXK2L99BqaqTFBJ_0024S_0024g_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
				array2[num4] = obj5;
			}
			_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003DzspFXFFZEsRhed0yV2L3ZP5BeA3Y3Fvd1gnUggru0IzUv(array2);
			return _0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2;
		}
		case 4:
		{
			_0023_003DqM_0024kYe1N44aB_zQkdFrLc4AeQC8UfF2AAUn80a0CP3TU_003D obj = new _0023_003DqM_0024kYe1N44aB_zQkdFrLc4AeQC8UfF2AAUn80a0CP3TU_003D();
			obj._0023_003Dzcn7juRckaWGOyJOu8zEg2fu_1HhlMEFGj3GbYuA_003D(_0023_003DziDLVpbY_003D._0023_003DzOwJERBVAuTqjh71jJLc2f5rPKwjwHUqx8z35g6c_003D());
			return obj;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _0023_003Dzalpqgan0IZA60xlAp_0024vo4iwjs0qqnGVrGs_6tRRtKU1O(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
	}

	private static void _0023_003DzI46_0024BYBm5E73hPwU0w_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(sbyte));
	}

	private static void _0023_003DzSxjMpfXe1CsV8Ozd_36OiAo_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(float));
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz0FXxuhu31qzow8Y4rr03gUdK5x8Lt026Ag_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				if (!_0023_003DzAvn2b38_003D)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num / num2);
				}
				int num3 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				uint num4 = (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D((int)((uint)num3 / num4));
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003DzXpJ4YjM_OuoF7wsfWkRdLPw_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzXpJ4YjM_OuoF7wsfWkRdLPw_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
				}
				return _0023_003Dz0FXxuhu31qzow8Y4rr03gUdK5x8Lt026Ag_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003DzXpJ4YjM_OuoF7wsfWkRdLPw_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				return _0023_003DzXpJ4YjM_OuoF7wsfWkRdLPw_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003DzAvn2b38_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzXpJ4YjM_OuoF7wsfWkRdLPw_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
				}
				return _0023_003DzXpJ4YjM_OuoF7wsfWkRdLPw_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8 && _0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8)
		{
			_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
			obj._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D() / ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D());
			return obj;
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003Dz0FXxuhu31qzow8Y4rr03gUdK5x8Lt026Ag_003D_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			}
			return _0023_003Dz0FXxuhu31qzow8Y4rr03gUdK5x8Lt026Ag_003D_003D(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
		}
		throw new InvalidOperationException();
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dzb3wlRP4tdSNVDaJlG1f9UKj4OWfOXqv7uObBzU0_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D)
	{
		if (!_0023_003DzAvn2b38_003D)
		{
			long num = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			long num2 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num % num2);
		}
		long num3 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		ulong num4 = (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D((long)((ulong)num3 % num4));
	}

	private static void _0023_003DzN9_QYwTAeheE_CnryaY9ZPOnOHy_X5OTSYotOadu8Yvc(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003DzpKI9ol7554_0024XWsqSrgmmMbA_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2) ? 1 : 0));
	}

	private static _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D _0023_003DzbGoKCkzXz67hSC9SkHu8YbWQf1z9o36uGFZKAXE_003D(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D obj = new _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D();
		obj._0023_003Dzp5vzKE7nzR5I_XB4OHMvK_wPwOP0gMM8ug_003D_003D(_0023_003DziDLVpbY_003D._0023_003Dzde912cHpBbiEQCr8HB1DjQ0hCNmJS1u2_Avb9oE_003D());
		obj._0023_003DzGr_0024zlUtfZZBLpCurUNvbTwhUx6kg9TzSxQ_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
		obj._0023_003DzvvS0Z_0024k8bJcYpRzjn9o1E66Jmz8C(_0023_003DziDLVpbY_003D._0023_003Dz6FnwpulGEWQ9qGWIVYQmBS9naiYUtq7I761iDk4_003D());
		obj._0023_003DzB5vH_YTbBSax6U__IG_0024USpfRo9Q6L3jtuA_003D_003D(_0023_003DziDLVpbY_003D._0023_003Dz6FnwpulGEWQ9qGWIVYQmBS9naiYUtq7I761iDk4_003D());
		obj._0023_003DzgpHLaGy1S2UhLnzAymANhAwQ_0024dsy(_0023_003DziDLVpbY_003D._0023_003Dz6FnwpulGEWQ9qGWIVYQmBS9naiYUtq7I761iDk4_003D());
		obj._0023_003Dzm4MhXnAZTPhiLSlVHYhxXO1lpvHUZySv_0024Z_Kt7s_003D(_0023_003DziDLVpbY_003D._0023_003Dz6FnwpulGEWQ9qGWIVYQmBS9naiYUtq7I761iDk4_003D());
		return obj;
	}

	private static void _0023_003Dzf_16IKMGbD8J4FGV0w_003D_003D(ILGenerator _0023_003DziDLVpbY_003D, Type _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003Dz5rQzobg_003D.IsValueType || _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzabUOCE0NIf0_0024ueqjA0946qu_00246SbMH3py0xa3ro4LUTfS(_0023_003Dz5rQzobg_003D).IsGenericParameter)
		{
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Unbox_Any, _0023_003Dz5rQzobg_003D);
		}
		else
		{
			_0023_003DzU6X488kkrEx__bUHUXBK3M6hWtGyw0YnfbtOTiQ_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
		}
	}

	private void _0023_003Dz1iNhYm_3WcC6odZhwRc2v96vbTh_0024(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
	}

	private static void _0023_003DzzkJgoXnU3jigR9FfEGBY2crtIGNx(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (_0023_003DzpKI9ol7554_0024XWsqSrgmmMbA_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private static void _0023_003Dz_1PccnmcqfDsVxusMFIROD063EengSRmFQbRu_0024k2T1wY(ILGenerator _0023_003DziDLVpbY_003D, Type _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003Dz5rQzobg_003D.IsValueType || _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzabUOCE0NIf0_0024ueqjA0946qu_00246SbMH3py0xa3ro4LUTfS(_0023_003Dz5rQzobg_003D).IsGenericParameter)
		{
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Box, _0023_003Dz5rQzobg_003D);
		}
	}

	private static void _0023_003Dzsvfb06pVrpsggeVZMjPq0vWuAtZyFR85IVAhaTk_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		uint num = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (uint)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => (uint)Convert.ToInt64(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D[] array = (_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D[])((_0023_003DqiuPtUBEOXz5ixdMRvtXgU2Fko3XXNTLSxPaItseTVmc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dz3XbyVhAxPon6zcsBDv_qjl_00247uhLL8o4w8kv3q9m6_TPe();
		if (num < array.Length)
		{
			uint num2 = (uint)array[num]._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num2);
		}
	}

	public void _0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(Stream _0023_003DziDLVpbY_003D, string _0023_003Dz5rQzobg_003D, object[] _0023_003DzAvn2b38_003D)
	{
		_0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
	}

	[DebuggerNonUserCode]
	private MethodBase _0023_003DzxFCw4O0oSzz4ae_0024c90eLINeyH_agUXkmxGBC2IA_003D(int _0023_003DziDLVpbY_003D, _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003Dz5rQzobg_003D)
	{
		lock (_0023_003DzHit7vU4_003D)
		{
			bool flag = true;
			if (flag && _0023_003DzHit7vU4_003D.TryGetValue(_0023_003DziDLVpbY_003D, out var value))
			{
				return (MethodBase)value;
			}
			if (_0023_003Dz5rQzobg_003D._0023_003DzOl4znCSQJV_o3jzYnD1EuZw5Wuu52ADXGg_003D_003D() == 0)
			{
				MethodBase methodBase = this.m__0023_003DzshZYG54_003D.ResolveMethod(_0023_003Dz5rQzobg_003D._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p());
				if (flag)
				{
					_0023_003DzHit7vU4_003D.Add(_0023_003DziDLVpbY_003D, methodBase);
				}
				return methodBase;
			}
			_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D _0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2 = (_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D)_0023_003Dz5rQzobg_003D._0023_003DzpKaM9DJ9LSi0XInJkPIbPujKUbSQ();
			if (_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003DzOCQjw4pWLcTYS1urUXgvAGuNgAgV19dZPw_003D_003D())
			{
				return _0023_003DzBhJjluw81_HkWgBTK6EEN9EmMaMNOpnEBVrzub4_003D(_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2);
			}
			Type type = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003DzV0iv8Q9KOWeQbFeld4Ijr5RweOxnDgHv5UPRKwY_003D()._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p(), _0023_003Dz5rQzobg_003D: false);
			Type type2 = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003Dz40KZulNImcDT8fkUqtaFuA8YdKEH()._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p(), _0023_003Dz5rQzobg_003D: true);
			Type[] array = new Type[_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003DzyX36d7w_gtlkHHtxkE7BCVaNs1sx().Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003DzyX36d7w_gtlkHHtxkE7BCVaNs1sx()[i]._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p(), _0023_003Dz5rQzobg_003D: true);
			}
			if (type.IsGenericType)
			{
				flag = false;
			}
			if (_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003Dzv0a3e_JnkHiTcgqmTRDr_0024AJGhiwL() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908227))
			{
				ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.Any, array, null) ?? throw new Exception();
				if (flag)
				{
					_0023_003DzHit7vU4_003D.Add(_0023_003DziDLVpbY_003D, constructorInfo);
				}
				return constructorInfo;
			}
			BindingFlags bindingAttr = _0023_003DzywBQyeN0kvmSlw6Yu1_0024kgx_0024lqk6alGjr4A_003D_003D(_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003Dzdmr3ulD800U42xZUUNfxw5s_003D());
			MethodBase methodBase2 = null;
			try
			{
				methodBase2 = type.GetMethod(_0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003Dzv0a3e_JnkHiTcgqmTRDr_0024AJGhiwL(), bindingAttr, null, CallingConventions.Any, array, null);
			}
			catch (AmbiguousMatchException)
			{
				MethodInfo[] methods = type.GetMethods(bindingAttr);
				foreach (MethodInfo methodInfo in methods)
				{
					if (methodInfo.Name != _0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003Dzv0a3e_JnkHiTcgqmTRDr_0024AJGhiwL() || methodInfo.ReturnType != type2)
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
				throw new Exception(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908239), type.Name, _0023_003DqpOsddWbqwzI4Xv5sOvd5rhRxUP98CHSaEx7QkdbXHxM_003D2._0023_003Dzv0a3e_JnkHiTcgqmTRDr_0024AJGhiwL()));
			}
			if (flag)
			{
				_0023_003DzHit7vU4_003D.Add(_0023_003DziDLVpbY_003D, methodBase2);
			}
			return methodBase2;
		}
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzTYpttnKnXlCifeH26HfbGmzO2lm6(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(-((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(-((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ());
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8)
		{
			_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
			obj._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(0.0 - ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D());
			return obj;
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzTYpttnKnXlCifeH26HfbGmzO2lm6(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())));
			}
			return _0023_003DzTYpttnKnXlCifeH26HfbGmzO2lm6(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())));
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzVF4xXqLe0r8DdbTksJIhyF02Ko9kF3QCutItIrk_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzJAojZB2QIuH_jIxrACIzvilaDqHq(_0023_003DziDLVpbY_003D: false, _0023_003Dz5rQzobg_003D: false);
	}

	private bool _0023_003Dz_00246_zqjGaTSjgbTyBE2pnCP8J5nm4uPBMYA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, Type _0023_003Dz5rQzobg_003D)
	{
		object obj = _0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		if (obj == null)
		{
			return true;
		}
		Type type = _0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D() ?? obj.GetType();
		if (type == _0023_003Dz5rQzobg_003D || _0023_003Dz5rQzobg_003D.IsAssignableFrom(type))
		{
			return true;
		}
		if (!type.IsValueType && !_0023_003Dz5rQzobg_003D.IsValueType)
		{
			if (Marshal.IsComObject(obj))
			{
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.GetComInterfaceForObject(obj, _0023_003Dz5rQzobg_003D);
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
			else if (_0023_003Dz9431O5LYjS8OrBgd0jywjR545Xki(obj))
			{
				return true;
			}
		}
		return false;
	}

	private static _0023_003DzWYPqg2E_003D _0023_003DzTizJ17ML_00242gDpbz8RMs9BL4_003D(_0023_003DzshZYG54_003D _0023_003DziDLVpbY_003D)
	{
		lock (_0023_003DzhidJeNw_003D)
		{
			_0023_003DzhidJeNw_003D.TryGetValue(_0023_003DziDLVpbY_003D, out var value);
			return value;
		}
	}

	private static void _0023_003Dz2tzKvJiTVx2DgtDT0NITtbtFNk_d0WhCBg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2 = (_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D;
		MethodBase methodBase = _0023_003DziDLVpbY_003D._0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
		_0023_003DqVq2G06qUQtchgF1EnbfnvW94BfgqBHFxi7iIWrl2lfE_003D obj = new _0023_003DqVq2G06qUQtchgF1EnbfnvW94BfgqBHFxi7iIWrl2lfE_003D();
		obj._0023_003DztXPjv8jDiWmFW3sXs84MniY_003D(methodBase);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz27o8WeFt2ozgeEqJvBNs8AnRaPziTpHvag_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				if (!_0023_003DzR58imxw_003D)
				{
					int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
					int num3 = ((!_0023_003DzAvn2b38_003D) ? (num + num2) : checked(num + num2));
					return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num3);
				}
				uint num4 = (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				uint num5 = (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				uint num6 = ((!_0023_003DzAvn2b38_003D) ? (num4 + num5) : checked(num4 + num5));
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D((int)num6);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003DzEujL_0024qmlUDGbJ7fYpKEKQsg61pySyI_0024TZhDreTgDMipj(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0023_003DzEujL_0024qmlUDGbJ7fYpKEKQsg61pySyI_0024TZhDreTgDMipj(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
				}
				return _0023_003Dz27o8WeFt2ozgeEqJvBNs8AnRaPziTpHvag_003D_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
			{
				return _0023_003DzEujL_0024qmlUDGbJ7fYpKEKQsg61pySyI_0024TZhDreTgDMipj(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				return _0023_003DzEujL_0024qmlUDGbJ7fYpKEKQsg61pySyI_0024TZhDreTgDMipj(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0023_003DzEujL_0024qmlUDGbJ7fYpKEKQsg61pySyI_0024TZhDreTgDMipj(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
				}
				return _0023_003DzEujL_0024qmlUDGbJ7fYpKEKQsg61pySyI_0024TZhDreTgDMipj(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8 && _0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 8)
		{
			_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
			obj._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D() + ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D());
			return obj;
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0023_003Dz27o8WeFt2ozgeEqJvBNs8AnRaPziTpHvag_003D_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
			}
			return _0023_003Dz27o8WeFt2ozgeEqJvBNs8AnRaPziTpHvag_003D_003D(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzJWHqjB_0024VhiFNM6p0MXTS5JpIe5DcjaMuJ7VLaE0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz1ktQDyYgVRcDWtIkyhgZ1BaKF8X_ZGGS4A_003D_003D(_0023_003DziDLVpbY_003D: false);
	}

	private static void _0023_003DzHliDIJHI_4jipcyu35IoIP0hI_jc(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DziDLVpbY_003D._0023_003DzrUb_0024eeiP_0024JYAU47F_iKJcFstj2o1nrMCAbIY1qGm4AWs(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2));
	}

	private static void _0023_003DzIrLBcr2K_abPOlFDNA_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		bool num2 = (num & int.MinValue) != 0;
		bool flag = (num & 0x40000000) != 0;
		num &= 0x3FFFFFFF;
		if (num2)
		{
			_0023_003DziDLVpbY_003D._0023_003DzCTFfwLWymBiYtb4Scu0BdGsgh7un(num, null, null, flag);
			return;
		}
		_0023_003DqNWCS8MTqiZMgZBpc9rePoD3Tf6ok_0024uTUh8pwkfYpM1M_003D _0023_003DqNWCS8MTqiZMgZBpc9rePoD3Tf6ok_0024uTUh8pwkfYpM1M_003D2 = (_0023_003DqNWCS8MTqiZMgZBpc9rePoD3Tf6ok_0024uTUh8pwkfYpM1M_003D)_0023_003DziDLVpbY_003D._0023_003DzLrd1XNI9dc0qU09uargDhdLHbDdl(num)._0023_003DzpKaM9DJ9LSi0XInJkPIbPujKUbSQ();
		_0023_003DziDLVpbY_003D._0023_003Dz4Sg2qQARqp7k5eIqIZ_ETNk_003D(_0023_003DqNWCS8MTqiZMgZBpc9rePoD3Tf6ok_0024uTUh8pwkfYpM1M_003D2);
	}

	private static void _0023_003DzKvEkAi3qu9qxDeu2cz_0024qDmM_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzPdTWlMPHPkLHbDli9YvX_pdNomy6(_0023_003DziDLVpbY_003D: true, _0023_003Dz5rQzobg_003D: true);
	}

	private static void _0023_003DzzOtlf0l8q74fHVe3MauIcFTtWH14CTv6Lg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
	}

	private void _0023_003DzBobqTgiv7_0024qJTDQ7T1G4q1vlSWRN(object _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D is Exception ex)
		{
			_0023_003Dz0Hf5cWDTnbY_0024d22_lrZrv_i72i0CP5IiPTe_0024dlQ_003D(ex);
		}
		_0023_003DzYquLvIsYETUelqXjt6N0lmOlTqd3(_0023_003DziDLVpbY_003D);
	}

	private static void _0023_003Dzr4b06ozk3I5UvBh0UCOddC1jZNlspFbS7Q_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzJAojZB2QIuH_jIxrACIzvilaDqHq(_0023_003DziDLVpbY_003D: true, _0023_003Dz5rQzobg_003D: true);
	}

	private void _0023_003DzCTFfwLWymBiYtb4Scu0BdGsgh7un(int _0023_003DziDLVpbY_003D, Type[] _0023_003Dz5rQzobg_003D, Type[] _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		_0023_003Dz0yNzT9M_003D._0023_003DzUXjbc9BY9W9m2seLWnn7jsJDEathvvwviQ_003D_003D()._0023_003DzUQ_bGErryTDpszeAu244IzixOQag9otlJo42_0024oeegDPivRgB6_0024XwD9KrkyM3tgZwAvXv4b_A7Pkg5OViPw_003D_003D(_0023_003DziDLVpbY_003D, 0);
		_0023_003Dz1iNhYm_3WcC6odZhwRc2v96vbTh_0024(_0023_003Dz0yNzT9M_003D);
		_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D _0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D2 = _0023_003Dz_0024ZZdcvqTQ08_qGC5PugOjps_003D(_0023_003Dz0yNzT9M_003D);
		_0023_003Dzjb1IgTEveIeEC3vQIlQu6tyrFAl_0024jxDeuOZu9UWrmvrR(_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D2);
		int num = _0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D2._0023_003Dz2ab977dO_V4bp_0024NWmafMNKyu2B0c().Length;
		object[] array = new object[num];
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] array2 = new _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[num];
		if (_0023_003DzBJFJHwk_003D != null && _0023_003DzR58imxw_003D)
		{
			int num2 = ((!_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D2._0023_003DzEuJfM2g1v8Mcj9WVg4SiajPXq2cE()) ? 1 : 0);
			Type[] array3 = new Type[num - num2];
			for (int num3 = num - 1; num3 >= num2; num3--)
			{
				array3[num3] = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D2._0023_003Dz2ab977dO_V4bp_0024NWmafMNKyu2B0c()[num3]._0023_003DzOwLa1TRtX2zG2yT751wGPiNvTQKexziEvVO416VO0KpQ(), _0023_003Dz5rQzobg_003D: true);
			}
			MethodInfo method = _0023_003DzBJFJHwk_003D.GetMethod(_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D2._0023_003DzFMr9dCVbs1HItIt4Lt5pQGuApOTN(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array3, null);
			_0023_003DzBJFJHwk_003D = null;
			if (method != null)
			{
				_0023_003DzRV6qj2VK8lvFF9bhLcko27s_003D(method, _0023_003Dz5rQzobg_003D: true);
				return;
			}
		}
		for (int num4 = num - 1; num4 >= 0; num4--)
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = (array2[num4] = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D());
			if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2)
			{
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2);
			}
			if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D() != null)
			{
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D())._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
			}
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D2._0023_003Dz2ab977dO_V4bp_0024NWmafMNKyu2B0c()[num4]._0023_003DzOwLa1TRtX2zG2yT751wGPiNvTQKexziEvVO416VO0KpQ(), _0023_003Dz5rQzobg_003D: true))._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
			array[num4] = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
			if (num4 == 0 && _0023_003DzR58imxw_003D && !_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D2._0023_003DzEuJfM2g1v8Mcj9WVg4SiajPXq2cE() && array[num4] == null)
			{
				throw new NullReferenceException();
			}
		}
		_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = new _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D(_0023_003DzXrexKjY_003D);
		object[] array4 = new object[1] { this.m__0023_003DzshZYG54_003D.Assembly };
		object obj;
		try
		{
			obj = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzFi4th1xnYhbT_0024NKYB49Fc6YljtjReZ6rjh3NuvNysiD3(this.m__0023_003DzEWLeis8_003D, _0023_003DziDLVpbY_003D, array, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, array4);
		}
		finally
		{
			bool flag = !_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D2._0023_003DzEuJfM2g1v8Mcj9WVg4SiajPXq2cE();
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
				if (array2[num5] is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D3)
				{
					_0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(array[num5], null));
				}
			}
		}
		Type type = _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2.m__0023_003DzTSeNR8Q_003D._0023_003DzrG0pCaZ8KJKmelGhBBl061cZv1tyMGFbpw_003D_003D(), _0023_003Dz5rQzobg_003D: true);
		if (type != _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzbfrNXYE_003D)
		{
			_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, type));
		}
	}

	private void _0023_003Dz8CM8lG3MAfx_0024kqUlvJK4vBO75C6MuyZIio134ps_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		long num = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (!_0023_003DziDLVpbY_003D) ? ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() : ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (!_0023_003DziDLVpbY_003D) ? ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() : ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => (!_0023_003DziDLVpbY_003D) ? ((long)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())) : checked((long)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => (!_0023_003DziDLVpbY_003D) ? ((long)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()) : checked((long)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			0 => (!_0023_003DziDLVpbY_003D) ? ((long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D obj = new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D();
		obj._0023_003Dzy6HyfSoNxN_JAsWz2P6G9bk_003D(num);
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DziDLVpbY_003D)
	{
		switch (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
		{
		case 2:
			return ((_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D)_0023_003DziDLVpbY_003D)._0023_003DzHZ5NKvAS4A9t8ypYPcqODs_XKjmA();
		case 23:
			return this.m__0023_003Dzt_m8zV0_003D[((_0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D)_0023_003DziDLVpbY_003D)._0023_003DzNAQX8ra3l1_0024XGAa1nNj6HCKZAd1O1wd8Wyz3ozD5SlgH()];
		case 18:
		{
			_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2 = (_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D)_0023_003DziDLVpbY_003D;
			return _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2._0023_003DzddbcHyilBA8MndTeiRwzcmFqKumQ().GetValue(_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2._0023_003DzdUxw3_0024V0zjE7LCNS0d6jNIXKeWTEQSZ1_Q_003D_003D()), null);
		}
		case 11:
		case 24:
		{
			_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D2 = (_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D)_0023_003DziDLVpbY_003D;
			return _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D2._0023_003DzdBElxsF4mA__0024M_0024_GdxrYy4_0024kz6yG8VGmWg_00249KC6Uss6liit4nuITZ6_B1WcoQoD43oh0fZo_003D(), _0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D2._0023_003Dz5jUufOEVwSYnI8es2HjmwoYw68mRMVvpohfxSKo_003D());
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _0023_003DzH3BB8nsUwWPlETn_OSqhvL_0024c9EXj6kWSuQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		string text = _0023_003DziDLVpbY_003D._0023_003Dzd8NJjsIuNdDkK_0024Oj3YmRtDVRGwvLj5FHfBcM_0024LcoOJbt(num);
		_0023_003Dqu2lukaMdtknH99Y0fKPgR6p7bCuAeuFbcqraKzMEJ0M_003D obj = new _0023_003Dqu2lukaMdtknH99Y0fKPgR6p7bCuAeuFbcqraKzMEJ0M_003D();
		obj._0023_003Dz6jVBe9cH7_002498rFPT0mx0hQo_003D(text);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static void _0023_003DzSPvj9Mc2ecXWKhds22juOtQ_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if ((_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 8) ? (!_0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)) : (!_0023_003Dz8wovo1mlTaoN1g0g3IAMk1d7cQeEIOfYr3TuVio_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private long _0023_003Dzc7lqRph1KlhUyDXq3k2To_Q_003D()
	{
		return _0023_003DziP9fFuA_003D._0023_003DzUXjbc9BY9W9m2seLWnn7jsJDEathvvwviQ_003D_003D()._0023_003Dzwl9sCcsvR4k6PzVcPKWWotTJzm4oD4gNUyoQC7OJjpk_00241M08s70UvYFNG9PxA9cCifL33i8_003D() + _0023_003DzGcl_0024E9o_003D;
	}

	private static void _0023_003DzbHNLxOSzjTJyVRLnanWDop0aqbgi(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908472));
	}

	private static void _0023_003DzoJNHPKdZL4HhlMIOEnGl7v0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D _0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D2 = (_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D)_0023_003Dz5rQzobg_003D;
		_0023_003DziDLVpbY_003D._0023_003DzIkM3CaSWupD4_0024gmIh5V76vLJzMAa(_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D2._0023_003DzwyKpuA_mNwWyADXJn6Q3N8s_003D());
	}

	private static void _0023_003DzYgc2Upsu8yT4_0024bSil9fzk1Ioxq4kKjvQ6at2A_00248_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2 = (_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D;
		MethodBase methodBase = _0023_003DziDLVpbY_003D._0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] array = _0023_003DziDLVpbY_003D._0023_003Dzyk2fsPo_003D;
		foreach (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 in array)
		{
			_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
		}
		_0023_003DziDLVpbY_003D._0023_003DzRV6qj2VK8lvFF9bhLcko27s_003D(methodBase, _0023_003Dz5rQzobg_003D: false);
	}

	private static void _0023_003DzTHQqVXzXMv_XJpU2xB_00244kM1Y4TYG(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz0LZ3a2KNB2rgSf490RJHmy0_003D(3);
	}

	private void _0023_003DzwLRSxOij2o4ipZ7oCq3reSIIXRgCXy6umQ_003D_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		sbyte b = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (!_0023_003DziDLVpbY_003D) ? ((sbyte)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()) : checked((sbyte)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), 
			13 => (!_0023_003DziDLVpbY_003D) ? ((sbyte)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()) : checked((sbyte)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()), 
			19 => (!_0023_003DziDLVpbY_003D) ? ((sbyte)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())) : checked((sbyte)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => (!_0023_003DziDLVpbY_003D) ? ((sbyte)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()) : checked((sbyte)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((sbyte)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((sbyte)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())) : ((!_0023_003DziDLVpbY_003D) ? ((sbyte)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((sbyte)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D();
		obj._0023_003DzI9gf1jAlM5PPTe_0024AK_G6hL0Q8r0D(b);
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static void _0023_003Dz_1IXjya1kcoZaSRLw66DpxZFdEIA(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (!_0023_003DznPx5gMhR_0024wSvGh_pza5trRU_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private static void _0023_003DzYi8fIL8Y5jVwwsTZZhjYloJdvrOGqLGK3sPyu54_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzwLRSxOij2o4ipZ7oCq3reSIIXRgCXy6umQ_003D_003D(_0023_003DziDLVpbY_003D: true);
	}

	private static void _0023_003DzBeU6795zDgCxWQeKcGQBQzv5KYvqEnjNAw_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(int));
	}

	private long _0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt()
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		return _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			0 => ((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee().ToInt64(), 
			20 => (long)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D().ToUInt64(), 
			19 => Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			_ => throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907522)), 
		};
	}

	private static void _0023_003Dz0_U1gfUkbaq9RDZ0oMsyntu3kn_0024I_0024CcbrtFfhiI_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(short));
	}

	private static void _0023_003DzgHnGOzow844ZX952mouOjT8_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D _0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D2 = (_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003Dz5rQzobg_003D;
		_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D obj = new _0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D();
		obj._0023_003Dz9U5c5UHrGsdu41UMG8qS86WqQ5Xq(_0023_003DziDLVpbY_003D._0023_003Dzyk2fsPo_003D[_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D2._0023_003DzgpS1K1MBEpvciTK82A_003D_003D()]);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private void _0023_003DzZZIwdR7TQhtzyOKUBJPDlyxjF5gEFIonpplSp5o_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		int num = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (!_0023_003DziDLVpbY_003D) ? ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() : ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (int)((!_0023_003DziDLVpbY_003D) ? ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() : checked((int)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ())), 
			19 => (!_0023_003DziDLVpbY_003D) ? ((int)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())) : checked((int)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => (!_0023_003DziDLVpbY_003D) ? ((int)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()) : checked((int)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			0 => (int)((IntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((int)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())) : ((!_0023_003DziDLVpbY_003D) ? ((int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()))), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D();
		obj._0023_003DzI9gf1jAlM5PPTe_0024AK_G6hL0Q8r0D(num);
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private void _0023_003DzIkM3CaSWupD4_0024gmIh5V76vLJzMAa(int _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D)
		{
			this.m__0023_003Dzt_m8zV0_003D[_0023_003DziDLVpbY_003D] = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2;
		}
		else
		{
			this.m__0023_003Dzt_m8zV0_003D[_0023_003DziDLVpbY_003D]._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
		}
	}

	[_0023_003DqiuPtUBEOXz5ixdMRvtXgU5g8uaO43OmqQqHwsculF30_003D(2)]
	private bool _0023_003DziK0DhWp2xj1RMiJal41JKdBPHgo_0024tuiZ_cZy3mI_003D([_0023_003DqBfza9v7YChMLWqd8ZuVriGu71YnayR3p6drljdd0PmU_003D(1)] MethodBase _0023_003DziDLVpbY_003D, object _0023_003Dz5rQzobg_003D, ref object _0023_003DzAvn2b38_003D, [_0023_003DqBfza9v7YChMLWqd8ZuVriGu71YnayR3p6drljdd0PmU_003D(new byte[] { 1, 2 })] object[] _0023_003DzR58imxw_003D)
	{
		Type declaringType = _0023_003DziDLVpbY_003D.DeclaringType;
		if (declaringType == null)
		{
			return false;
		}
		if (_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzoIht4H3MBiobPh2HDJb056MsRfdA_00245XIgOj_0024Oec_003D(declaringType))
		{
			string name = _0023_003DziDLVpbY_003D.Name;
			if (name.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909241), StringComparison.Ordinal))
			{
				_0023_003DzAvn2b38_003D = _0023_003Dz5rQzobg_003D != null;
			}
			else if (name.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909230), StringComparison.Ordinal))
			{
				if (_0023_003Dz5rQzobg_003D == null)
				{
					return ((bool?)null).Value;
				}
				_0023_003DzAvn2b38_003D = _0023_003Dz5rQzobg_003D;
			}
			else if (name.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909214), StringComparison.Ordinal))
			{
				switch (_0023_003DzR58imxw_003D.Length)
				{
				case 0:
					_0023_003DzAvn2b38_003D = _0023_003Dz5rQzobg_003D;
					break;
				case 1:
					if (_0023_003Dz5rQzobg_003D != null)
					{
						_0023_003DzAvn2b38_003D = _0023_003Dz5rQzobg_003D;
					}
					else
					{
						_0023_003DzAvn2b38_003D = _0023_003DzR58imxw_003D[0];
					}
					break;
				default:
					return false;
				}
			}
			else
			{
				if (_0023_003Dz5rQzobg_003D != null || _0023_003DziDLVpbY_003D.IsStatic)
				{
					return false;
				}
				_0023_003DzAvn2b38_003D = null;
			}
			return true;
		}
		if (declaringType == _0023_003DzDtqAooE_003D)
		{
			string name2 = _0023_003DziDLVpbY_003D.Name;
			if (name2.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909430), StringComparison.Ordinal))
			{
				_0023_003DzAvn2b38_003D = _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzWYPqg2E_003D;
				return true;
			}
			if (this.m__0023_003DzkKfJheA_003D != null && name2.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909423), StringComparison.Ordinal))
			{
				object[] array = this.m__0023_003DzkKfJheA_003D;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] is Assembly assembly)
					{
						_0023_003DzAvn2b38_003D = assembly;
						return true;
					}
				}
			}
		}
		else if (declaringType == _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003Dz5rQzobg_003D)
		{
			if (_0023_003DziDLVpbY_003D.Name.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909386), StringComparison.Ordinal))
			{
				if (this.m__0023_003DzkKfJheA_003D != null)
				{
					object[] array = this.m__0023_003DzkKfJheA_003D;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] is MethodBase methodBase)
						{
							_0023_003DzAvn2b38_003D = methodBase;
							return true;
						}
					}
				}
				_0023_003DzAvn2b38_003D = MethodBase.GetCurrentMethod();
				return true;
			}
		}
		else if (declaringType.IsArray && declaringType.GetArrayRank() >= 2)
		{
			return _0023_003DzuxjAtrHQINmDpPn240chZv8_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, ref _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D);
		}
		return false;
	}

	private static void _0023_003DzJt9Fa_0024s1K6emGV0b74CfgcLnriAkp3Dz_MtQdF4_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DziDLVpbY_003D._0023_003Dz9SI33zTg8BbNw3Q8Nws6S3wUpSIQLpQPMUJJdwedXwau(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2));
	}

	private static void _0023_003DzPMTZQWmC_kxC4_00248Hi1yTyfjjEzDt(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzvqLwvubv2Id3oqbIJDFL_KvV9rdFqVtTcKkVEDo_003D(_0023_003DziDLVpbY_003D: true);
	}

	private static void _0023_003DzctPL2fVn0UsPU9ev132QGjW4GNRvTR0Q6g_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz5qKhdgkaNPCdh71MH4BA2EhHZKb_(_0023_003DziDLVpbY_003D: true);
	}

	private static void _0023_003Dz_l0AbuXGUnL4nnER6mMiAirANJzI4dYhYea4MRo_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(checked(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (int)(uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (int)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => (int)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			8 => (int)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((int)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((int)(uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzUlDDvb_0024cCetwDqYrpxli4X3RaF4F(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if ((_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 8) ? (!_0023_003Dz8wovo1mlTaoN1g0g3IAMk1d7cQeEIOfYr3TuVio_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)) : (!_0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private static void _0023_003Dz1RppsocN9kJ35M_0024HsA_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(typeof(double));
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DztXDI47kJ270znHgEobUi8OxUGAh7(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		if (!_0023_003DzR58imxw_003D)
		{
			long num = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			long num2 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			long num3 = ((!_0023_003DzAvn2b38_003D) ? (num * num2) : checked(num * num2));
			return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num3);
		}
		ulong num4 = (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		ulong num5 = (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		ulong num6 = ((!_0023_003DzAvn2b38_003D) ? (num4 * num5) : checked(num4 * num5));
		return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D((long)num6);
	}

	private static void _0023_003Dz21r1zpfdge2M3kLHzpHDdLPIpx8F(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		IntPtr intPtr = checked(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => new IntPtr((uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), 
			13 => new IntPtr((long)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()), 
			19 => new IntPtr((long)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => new IntPtr((long)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			_ => throw new InvalidOperationException(), 
		});
		_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D obj = new _0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D();
		obj._0023_003DzbBdLl_0024ovIBkh8mMBtnusWhikQk0Aj3SNshCD9qg_003D(intPtr);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static void _0023_003Dzy8axZ8FPK_VZjQYqSNpW2ro_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzZoHutE04P0sbCnLGpmJQ5GI_003D(_0023_003DziDLVpbY_003D: true, _0023_003Dz5rQzobg_003D: false);
	}

	private static void _0023_003Dzzri_00242x9vE3mnt8jCDQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DziDLVpbY_003D._0023_003Dzz9Rp_00249b6lGMYj_jZQQ_003D_003D(type);
	}

	private void _0023_003Dz_zeDwWgrLqWqj6ECFFPZ7JQ_003D(int _0023_003DziDLVpbY_003D)
	{
		_0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D obj = new _0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D();
		obj._0023_003DzvFc2xO_qhLCQgC2LgaRW2TMS28cqFDF19M2FD8Y_003D(_0023_003DziDLVpbY_003D);
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static void _0023_003DzJtppk5hDV34exa1EWEAoGuv76SQY(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(double));
	}

	private Type _0023_003Dz_0024TKtyUGnVMLD0Yl8e_0024aYMyc3E77sLwj5LlRErJc_003D(int _0023_003DziDLVpbY_003D, _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003Dz5rQzobg_003D, ref bool _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		if (_0023_003Dz5rQzobg_003D._0023_003DzOl4znCSQJV_o3jzYnD1EuZw5Wuu52ADXGg_003D_003D() == 0)
		{
			return this.m__0023_003DzshZYG54_003D.ResolveType(_0023_003Dz5rQzobg_003D._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p());
		}
		_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D _0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2 = (_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D)_0023_003Dz5rQzobg_003D._0023_003DzpKaM9DJ9LSi0XInJkPIbPujKUbSQ();
		Type type = null;
		if (_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzAz_WIX_00247vm_0024ecHH6YBQNNdg_003D())
		{
			if (_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzUq_0024ViFQLNuBvzkHHwcj_00240x2VVS73() != -1)
			{
				if (_0023_003DzFmiij5k_003D == null)
				{
					throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909049));
				}
				type = _0023_003DzFmiij5k_003D[_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzUq_0024ViFQLNuBvzkHHwcj_00240x2VVS73()];
			}
			else
			{
				if (_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzAQ85yP4iXai4PDN1Zn0ZohvyEbXbx7MRgg_003D_003D() == -1)
				{
					throw new Exception();
				}
				if (this.m__0023_003DzR58imxw_003D == null)
				{
					throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909036));
				}
				type = this.m__0023_003DzR58imxw_003D[_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzAQ85yP4iXai4PDN1Zn0ZohvyEbXbx7MRgg_003D_003D()];
			}
			Stack<_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D> stack = _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003Dz79D8nBufbe8GV8EWfy8sOOY_003D(_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003Dz_DXVYTYMzvn4WEv_jvw0_WJ4_0024A7fsimSYw_003D_003D());
			type = _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003Dzz0Px9L6Or2TxYjXunF_0024Eikk_003D(type, stack);
			_0023_003DzAvn2b38_003D = false;
			return type;
		}
		string text = _0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003Dz_DXVYTYMzvn4WEv_jvw0_WJ4_0024A7fsimSYw_003D_003D();
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
			Assembly assembly = _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzWYPqg2E_003D;
			if (text3.Equals(assembly.FullName, StringComparison.OrdinalIgnoreCase))
			{
				type = ((!text2.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909019), StringComparison.Ordinal)) ? assembly.GetType(text2) : _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003Dz437_00244ak_003D);
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
			if (type == null && text2.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909004), StringComparison.Ordinal) && text2.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290)))
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
			throw new TypeLoadException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908946), text));
		}
		if (_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzjT_0024L6Hv0as9MaEFfV7EwZ9Jz1sKB())
		{
			if (_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzPU8SY1H_0024TrGRiRHESsa4BNZVCysN().Length != 0)
			{
				Type[] array = new Type[_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzPU8SY1H_0024TrGRiRHESsa4BNZVCysN().Length];
				for (int j = 0; j < _0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzPU8SY1H_0024TrGRiRHESsa4BNZVCysN().Length; j++)
				{
					array[j] = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzPU8SY1H_0024TrGRiRHESsa4BNZVCysN()[j]._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p(), _0023_003DzR58imxw_003D);
				}
				Type genericTypeDefinition = _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzabUOCE0NIf0_0024ueqjA0946qu_00246SbMH3py0xa3ro4LUTfS(type).GetGenericTypeDefinition();
				Stack<_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D> stack2 = _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzKvttB_0024Sc4ndvnJM2qX_0024DIAk_003D(type);
				type = genericTypeDefinition.MakeGenericType(array);
				type = _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003Dzz0Px9L6Or2TxYjXunF_0024Eikk_003D(type, stack2);
			}
			_0023_003DzAvn2b38_003D = false;
		}
		return type;
	}

	private static void _0023_003Dzp_u01LYulmAKZ9DREyhIgdlH0ABc0uWJibxxXEPfClgt(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D);
	}

	private void _0023_003DzxhjBj1B0NmdPXqX0tYX1R3OzVXoNHdItjw_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D)
	{
		if (((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D())._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() != 0)
		{
			this.m__0023_003DziDLVpbY_003D.Push(new _0023_003DzmQTFaQA_003D(_0023_003DzWWgGxds_003D, _0023_003Dzl3DhHgI_003D));
			this.m__0023_003DzWYPqg2E_003D = false;
		}
		_0023_003DzYoHr_kaBP_0024C0cQWQednER91YDBHg();
	}

	private static void _0023_003DzE0fRxTEv2bJciKjTTEP0d8lMNs4u(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzn4biIlk8_0024QePVyQjAQYYX5s_003D(_0023_003Dz5rQzobg_003D);
	}

	private static void _0023_003DzoTZGeXhIosOFo8fGPlKdXccH72kq(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		double num = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
		obj._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(num);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	public static object _0023_003DzuNKSWtY_0024_0024ExI7KlNuM5gS_002417mtXjL3l3OMuckYc_003D(Type _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D.IsValueType)
		{
			return Activator.CreateInstance(_0023_003DziDLVpbY_003D);
		}
		return null;
	}

	private static void _0023_003DzIecD6ZbHownA_IYx14bnvXIlGpue(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] _0023_003Dz6wFjKAvlSUkKqqhBc6gazJ5IGNhBnOFc5c3c_JA_003D(object[] _0023_003DziDLVpbY_003D)
	{
		_0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D[] array = m__0023_003DzTSeNR8Q_003D._0023_003Dz2ab977dO_V4bp_0024NWmafMNKyu2B0c();
		int num = array.Length;
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] array2 = new _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[num];
		for (int i = 0; i < num; i++)
		{
			object obj = _0023_003DziDLVpbY_003D[i];
			Type type = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(array[i]._0023_003DzOwLa1TRtX2zG2yT751wGPiNvTQKexziEvVO416VO0KpQ(), _0023_003Dz5rQzobg_003D: false);
			Type type2 = null;
			Type type3 = _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003Dz4RFZlwTSA_0024OBIxXad_0024ubOycm4BxX(type);
			type2 = ((!(type3 == _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D) && !_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzoIht4H3MBiobPh2HDJb056MsRfdA_00245XIgOj_0024Oec_003D(type3)) ? ((obj != null) ? obj.GetType() : type) : type);
			if (obj != null && !type.IsAssignableFrom(type2) && type.IsByRef && !type.GetElementType().IsAssignableFrom(type2))
			{
				throw new ArgumentException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909375), type2, type));
			}
			array2[i] = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, type2);
		}
		if (!m__0023_003DzTSeNR8Q_003D._0023_003DzEuJfM2g1v8Mcj9WVg4SiajPXq2cE() && _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(m__0023_003DzTSeNR8Q_003D._0023_003Dzx5X59GHDhQCY67nsHADQ8HctXRx6EilYiQ_003D_003D(), _0023_003Dz5rQzobg_003D: false).IsValueType)
		{
			_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D obj2 = new _0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D();
			obj2._0023_003Dz9U5c5UHrGsdu41UMG8qS86WqQ5Xq(array2[0]);
			array2[0] = obj2;
		}
		for (int j = 0; j < num; j++)
		{
			if (array[j]._0023_003DzHxZONG5Od6vQ_crMT5iPpwf_0024Q_QeVh8xLg_003D_003D())
			{
				int num2 = j;
				_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D obj3 = new _0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D();
				obj3._0023_003Dz9U5c5UHrGsdu41UMG8qS86WqQ5Xq(array2[j]);
				array2[num2] = obj3;
			}
		}
		return array2;
	}

	private static bool _0023_003DzpKI9ol7554_0024XWsqSrgmmMbA_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		bool result = false;
		switch (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
		{
		case 1:
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003DzpKI9ol7554_0024XWsqSrgmmMbA_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())));
			}
			result = (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() < (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
			break;
		case 13:
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003DzpKI9ol7554_0024XWsqSrgmmMbA_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())));
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				return _0023_003DzpKI9ol7554_0024XWsqSrgmmMbA_003D(_0023_003DziDLVpbY_003D, new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()));
			}
			result = (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() < (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			break;
		case 19:
			return _0023_003DzpKI9ol7554_0024XWsqSrgmmMbA_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DziDLVpbY_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), _0023_003Dz5rQzobg_003D);
		case 8:
		{
			double num = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			double num2 = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			result = num < num2 || double.IsNaN(num) || double.IsNaN(num2);
			break;
		}
		}
		return result;
	}

	private static void _0023_003DzPuggeVWnttFpBeEMG2ciU48_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(int));
	}

	private static void _0023_003DzhNagC7r3GUiU3sRadfivnNKuEQDX(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D obj = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (obj._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 1)
		{
			throw new InvalidOperationException();
		}
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)obj)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Stack<_0023_003Dz437_00244ak_003D> stack = _0023_003DziDLVpbY_003D._0023_003DzmhNPwvYqeFIwGaYvUVC5r3pbe1W7();
		if (stack.Count < 2)
		{
			throw new InvalidOperationException();
		}
		using _0023_003Dz437_00244ak_003D _0023_003Dz437_00244ak_003D2 = stack.Pop();
		if (_0023_003Dz437_00244ak_003D2 == null || _0023_003Dz437_00244ak_003D2._0023_003DziDLVpbY_003D._0023_003Dzw4Rv47BiWa6fq_00240kjN28rswc4FhUhMaMkfDelptC31Wkombky0PE_0024O6P3lX890V6grzjjsXXFpJc() != num)
		{
			throw new InvalidOperationException();
		}
		_0023_003Dz437_00244ak_003D _0023_003Dz437_00244ak_003D3 = stack.Peek();
		_0023_003DziDLVpbY_003D._0023_003DzF92XqHWM0mt_1xTngiTEH1HG1JGphapjovJeugQ_003D(_0023_003Dz437_00244ak_003D3);
		_0023_003DziDLVpbY_003D._0023_003DzWWgGxds_003D += (uint)_0023_003Dz437_00244ak_003D2._0023_003DziDLVpbY_003D._0023_003DzSayMtCdxD_002491o5YxBA_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003Dzo3_0024JD29gQ7XumqZQHo8tWU0_003D(_0023_003DziDLVpbY_003D._0023_003DzWWgGxds_003D);
	}

	private static void _0023_003DzjoZs8ymYEJ_NUjVtOH7VuF14vZDGbZSM5vOdgG0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(8);
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DztdLtEFyQYOKh66UbjMcpn_sgPRbCaHovUAQYe_0024o_003D(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D, byte _0023_003Dz5rQzobg_003D)
	{
		switch (_0023_003Dz5rQzobg_003D)
		{
		case 11:
			return null;
		case 0:
		{
			_0023_003DzWWgGxds_003D++;
			_0023_003DqubUcAaZEWA6CJOJ0kia_0024ue97M_fGbzb_0024ksylKcCatwI_003D obj2 = new _0023_003DqubUcAaZEWA6CJOJ0kia_0024ue97M_fGbzb_0024ksylKcCatwI_003D();
			obj2._0023_003Dz1aXc5qEm5cdL5R85kb8_Ewk_003D(_0023_003DziDLVpbY_003D._0023_003DzfF7Q00tS_0024h8uJk_Aa9XsN5Y_003D());
			return obj2;
		}
		case 2:
		case 6:
			_0023_003DzWWgGxds_003D += 4u;
			return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
		case 10:
			_0023_003DzWWgGxds_003D += 8u;
			return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(_0023_003DziDLVpbY_003D._0023_003DzrHcBIDM_zm2DjlT8p4axEjulBRQCiKqBKgwhAFx8MtbF());
		case 3:
		case 7:
		{
			_0023_003DzWWgGxds_003D++;
			_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D obj7 = new _0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D();
			obj7._0023_003DzDf6iA6zkWNW4bpSnbP_00247hmglU0CM(_0023_003DziDLVpbY_003D._0023_003Dzde912cHpBbiEQCr8HB1DjQ0hCNmJS1u2_Avb9oE_003D());
			return obj7;
		}
		case 5:
		case 12:
		{
			_0023_003DzWWgGxds_003D += 2u;
			_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D obj6 = new _0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D();
			obj6._0023_003DzhYErpRAQUUdbA_johw_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzDXx_0024S1eebw0ZVvaacGg83AOxi3nphLEsbjBHduHOOP0A());
			return obj6;
		}
		case 4:
		{
			_0023_003DzWWgGxds_003D += 4u;
			_0023_003Dqc2b0YBioXegIu1gaJQSGraoGfjfP1vO_0024YGZjzm2GTrA_003D obj5 = new _0023_003Dqc2b0YBioXegIu1gaJQSGraoGfjfP1vO_0024YGZjzm2GTrA_003D();
			obj5._0023_003DztUBn8gjmsR0Wgi6WJ2gViZJdAzGZQQt59A_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzVyJrzRjgRb_6vFQcY3JSzTEWU7lSeQ5kFsxKQaacPqd3());
			return obj5;
		}
		case 8:
		{
			_0023_003DzWWgGxds_003D += 8u;
			_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj4 = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
			obj4._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(_0023_003DziDLVpbY_003D._0023_003DzgGOhcKuVrSSaTfjgj463_TcD0Nga());
			return obj4;
		}
		case 1:
		{
			_0023_003DzWWgGxds_003D += 4u;
			_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D obj3 = new _0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D();
			obj3._0023_003DzUlrL4CAcIkwRmR0nmPo7Q5s_003D(_0023_003DziDLVpbY_003D._0023_003Dz6FnwpulGEWQ9qGWIVYQmBS9naiYUtq7I761iDk4_003D());
			return obj3;
		}
		case 9:
		{
			int num = _0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D();
			_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D[] array = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			}
			_0023_003DzWWgGxds_003D += (uint)((num + 1) * 4);
			_0023_003DqiuPtUBEOXz5ixdMRvtXgU2Fko3XXNTLSxPaItseTVmc_003D obj = new _0023_003DqiuPtUBEOXz5ixdMRvtXgU2Fko3XXNTLSxPaItseTVmc_003D();
			obj._0023_003DzRLhxVKucVOF8eMuxSQgsrZwLjkAm_0024xL5cw3CIS8_003D(array);
			return obj;
		}
		default:
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908660));
		}
	}

	private static void _0023_003Dz8pKBIJO_UHy01GD931gFmbQ_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzIkM3CaSWupD4_0024gmIh5V76vLJzMAa(2);
	}

	private static void _0023_003Dzi9WzZPfNKuF9RqZPZjSrue1moxGV(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzB_0024y0GUDRjw6r5v7Rng_003D_003D(_0023_003DziDLVpbY_003D: true);
	}

	private int _0023_003DznGtUd4B6Wfp8z__tmYb3_0024Raz5pOZ()
	{
		return 1447513948;
	}

	private void _0023_003Dz0LZ3a2KNB2rgSf490RJHmy0_003D(int _0023_003DziDLVpbY_003D)
	{
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dzyk2fsPo_003D[_0023_003DziDLVpbY_003D]._0023_003Dz5lslr6cY84EhmY4zXHchiRWu3kQNhqjmGcu8SDdt4PC3hOVR_dhU_0024Xh6CjBfnPFf6PSrQ7YCFTCw());
	}

	private bool _0023_003Dzl5d5naiggXQxbE_0024To77xnk4_003D(Type _0023_003DziDLVpbY_003D, _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003Dz5rQzobg_003D, out int _0023_003DzAvn2b38_003D)
	{
		_0023_003DzAvn2b38_003D = 0;
		_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D _0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2 = (_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D)_0023_003Dz5rQzobg_003D._0023_003DzpKaM9DJ9LSi0XInJkPIbPujKUbSQ();
		if (_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DzabUOCE0NIf0_0024ueqjA0946qu_00246SbMH3py0xa3ro4LUTfS(_0023_003DziDLVpbY_003D).IsGenericParameter)
		{
			if (_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2 != null && !_0023_003Dq0aa58W10obKnKDKIHo_WWsBVfNjm69F_FqjF7QGr8_A_003D2._0023_003DzAz_WIX_00247vm_0024ecHH6YBQNNdg_003D())
			{
				return false;
			}
			return true;
		}
		Type type = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003Dz5rQzobg_003D._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p(), _0023_003Dz5rQzobg_003D: false);
		if (!_0023_003Dq7E7xcWsqfqUr1uy0UPwNX7dwNsi6D7KnqdwNEzfRE5g_003D._0023_003DzSnv4FpnslnCLHbc2_0024uZjlNTg7M2A(_0023_003DziDLVpbY_003D, type, out _0023_003DzAvn2b38_003D))
		{
			return false;
		}
		return true;
	}

	private static void _0023_003Dzr04AhMkN2HrCTrOjlzkf2HamevaX(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzPdTWlMPHPkLHbDli9YvX_pdNomy6(_0023_003DziDLVpbY_003D: true, _0023_003Dz5rQzobg_003D: false);
	}

	private static string _0023_003DzAWcPhgVgng7uZTM7bm7UobvPaQJpGckazA8wrdc_003D(string _0023_003DziDLVpbY_003D, string _0023_003Dz5rQzobg_003D)
	{
		string fullName = typeof(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D).Assembly.FullName;
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908067) + _0023_003DziDLVpbY_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908053) + _0023_003Dz5rQzobg_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908039) + Environment.NewLine + Environment.NewLine + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908792) + fullName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908775);
	}

	private void _0023_003DzvqLwvubv2Id3oqbIJDFL_KvV9rdFqVtTcKkVEDo_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DzpnBsbGvBvIQo6W6rrfRBrBxppTT_0024hu1nKg_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2, _0023_003DziDLVpbY_003D));
	}

	[_0023_003DqiuPtUBEOXz5ixdMRvtXgU5g8uaO43OmqQqHwsculF30_003D(2)]
	private bool _0023_003DzuxjAtrHQINmDpPn240chZv8_003D([_0023_003DqBfza9v7YChMLWqd8ZuVriGu71YnayR3p6drljdd0PmU_003D(1)] MethodBase _0023_003DziDLVpbY_003D, object _0023_003Dz5rQzobg_003D, ref object _0023_003DzAvn2b38_003D, [_0023_003DqBfza9v7YChMLWqd8ZuVriGu71YnayR3p6drljdd0PmU_003D(new byte[] { 1, 2 })] object[] _0023_003DzR58imxw_003D)
	{
		if (!_0023_003DziDLVpbY_003D.IsStatic && _0023_003Dz5rQzobg_003D != null && _0023_003DziDLVpbY_003D.Name.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909077), StringComparison.Ordinal) && _0023_003DziDLVpbY_003D is MethodInfo { ReturnType: var returnType } && returnType.IsByRef)
		{
			Type elementType = returnType.GetElementType();
			int num = _0023_003DzR58imxw_003D.Length;
			if (num >= 1 && _0023_003DzR58imxw_003D[0] is int)
			{
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = (int)_0023_003DzR58imxw_003D[i];
				}
				_0023_003DqiipmHPQffrHbQ6jZsIqrDfUnBE_HTxGlCsEsr88GTNQ_003D obj = new _0023_003DqiipmHPQffrHbQ6jZsIqrDfUnBE_HTxGlCsEsr88GTNQ_003D();
				obj._0023_003Dz11AJ4FZQEZNm8RTLRpvSQgWriMNtDnhK7Y989Yri4ep9((Array)_0023_003Dz5rQzobg_003D);
				obj._0023_003Dz_0024Q1qsMuxvVFAeZq8f3x5sqwQ2OF_7Q_0024Emg_003D_003D(array);
				obj._0023_003DzOwUeWsAv3XcZZAx1xnuuZLvugy_Y(elementType);
				_0023_003DzAvn2b38_003D = obj;
				return true;
			}
		}
		return false;
	}

	private static void _0023_003DztM3KKSZvlu_9yPwSB4IlQ21Uj79a8yrCBQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
	}

	private static void _0023_003DzajqCr0KiHgojzc4vinwetyI_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003Dz6HPSY_0024zpefu_0024sPp4tcYcOC6YvaQ_H1xKIg_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2) ? 1 : 0));
	}

	private void _0023_003DzmBzPgUk9Q3vqIKYOZAVqp0d_8pOa0et_0024JhW17JA_003D(int _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003Dzyk2fsPo_003D[_0023_003DziDLVpbY_003D]._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
	}

	private static void _0023_003DzmkEJTn4IVDY2WAw9tlMGkhq1NGQP9VlJURiQJPhoAN1h(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D(), type);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(type);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
	}

	private static void _0023_003DzFk2G1f_6rIvUpvGcFQneh85ggmRUxasSqcVPkvs7HwZK(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		FieldInfo fieldInfo = _0023_003DziDLVpbY_003D._0023_003DzsH6I9ZDv5gPH5Am4bCK2nNxE2uzwyQ3uDe_00241OaRt2yRO(num);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D obj = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 as _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D;
		object obj2 = ((_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 == null) ? _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() : _0023_003DziDLVpbY_003D._0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2)._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
		if (obj2 == null)
		{
			throw new NullReferenceException();
		}
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D(), fieldInfo.FieldType);
		fieldInfo.SetValue(obj2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
		if (_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 != null && obj2 != null && obj2.GetType().IsValueType)
		{
			_0023_003DziDLVpbY_003D._0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj2, null));
		}
	}

	private static Exception _0023_003DzAQaegUXL0B9STTaFrCM_0024tZ3iZQy1e_oflUuFLD8_003D(string _0023_003DziDLVpbY_003D, string _0023_003Dz5rQzobg_003D)
	{
		return new FieldAccessException(_0023_003DzAWcPhgVgng7uZTM7bm7UobvPaQJpGckazA8wrdc_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907958) + _0023_003DziDLVpbY_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909273) + _0023_003Dz5rQzobg_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907930)));
	}

	private static void _0023_003DzjPNsRUk2ojqHVwRhEK4cc5k_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		FieldInfo fieldInfo = _0023_003DziDLVpbY_003D._0023_003DzsH6I9ZDv5gPH5Am4bCK2nNxE2uzwyQ3uDe_00241OaRt2yRO(num);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D(), fieldInfo.FieldType);
		fieldInfo.SetValue(null, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
	}

	private static void _0023_003DzObr38oov3fOAF5I7PLtSrbzDRNZX(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		object obj = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		long num = _0023_003DziDLVpbY_003D._0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt();
		Array array = (Array)_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(int))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(int));
			((int[])array)[num] = (int)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType == typeof(uint))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(uint));
			((uint[])array)[num] = (uint)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003DziDLVpbY_003D._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(elementType, obj, num, array);
		}
		else
		{
			_0023_003DziDLVpbY_003D._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(typeof(int), obj, num, array);
		}
	}

	private void _0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(Type _0023_003DziDLVpbY_003D, object _0023_003Dz5rQzobg_003D, long _0023_003DzAvn2b38_003D, Array _0023_003DzR58imxw_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(_0023_003Dz5rQzobg_003D, _0023_003DziDLVpbY_003D);
		_0023_003DzR58imxw_003D.SetValue(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D(), _0023_003DzAvn2b38_003D);
	}

	private void _0023_003Dz97pidvc061He_0024DIu4r5pe6u1H3i1(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (!_0023_003DziDLVpbY_003D) ? ((ushort)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()) : checked((ushort)(uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), 
			13 => (!_0023_003DziDLVpbY_003D) ? ((ushort)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()) : checked((ushort)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()), 
			19 => (!_0023_003DziDLVpbY_003D) ? ((ushort)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())) : checked((ushort)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => (!_0023_003DziDLVpbY_003D) ? ((ushort)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()) : checked((ushort)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((ushort)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((ushort)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())) : ((!_0023_003DziDLVpbY_003D) ? ((ushort)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((ushort)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())), 
			20 => (UIntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((ushort)(ulong)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()) : checked((ushort)(ulong)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D())) : ((!_0023_003DziDLVpbY_003D) ? ((ushort)(uint)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()) : checked((ushort)(uint)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D())), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private static void _0023_003DzhtnWH1MSZxF4i72iFdX8cVnv3kT8v1Z2DF3iKvgUxo_0024X(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dz5rQzobg_003D);
	}

	private _0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D[] _0023_003DzLn8HaQtJXi7HnrfYAK73vmuth3fvBVBIuE6nf0DeydoE(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D[] array = new _0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D[_0023_003DziDLVpbY_003D._0023_003DzBLlGVMs_2v1_00240JsyU3F1qlk_003D()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003Dzi_0024EAmjSWSPNwmRxq_SmndQ_C47LnidL2fQ_003D_003D(_0023_003DziDLVpbY_003D);
		}
		return array;
	}

	private static void _0023_003DzGQ4O1wKgXyk3SASc1w1onsfurje26nYucmH5SWo_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		bool flag = false;
		if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() != 0, 
			13 => ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() != 0, 
			0 => ((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee() != IntPtr.Zero, 
			20 => ((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D() != UIntPtr.Zero, 
			19 => Convert.ToBoolean(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			7 => ((_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzP7k5Y6ukvcg_ixjUAKpLm2Y7IkNc3hTJEKeYFNObePLS() != null, 
			_ => _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() != null, 
		})
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private _0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D _0023_003Dz_0024ZZdcvqTQ08_qGC5PugOjps_003D(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D obj = new _0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D();
		obj._0023_003Dz2nzZAAEg8X54aKcb7UwBpnuat5A_Cz1WZ4Yzw_00240_003D(_0023_003DzLn8HaQtJXi7HnrfYAK73vmuth3fvBVBIuE6nf0DeydoE(_0023_003DziDLVpbY_003D));
		obj._0023_003DzltoJhG0fXZlAJQiFXYukveSK4Tr3(_0023_003DzLXWRRdvI_QfK6LpZ45IlR7OxehqFxHSb93F9_0024P0_003D(_0023_003DziDLVpbY_003D));
		obj._0023_003DzaOyIvj9Uzz_0024S_0024CozSlviwn0_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
		obj._0023_003Dzfyz5lNZlnjozo241CX5SQXevkgXkcKFDAVm7W8c_003D(_0023_003DziDLVpbY_003D._0023_003Dzde912cHpBbiEQCr8HB1DjQ0hCNmJS1u2_Avb9oE_003D());
		obj._0023_003Dz0P1Zd6jwcwR6kvAUatXn0jN7MuzHPE6thbzGZZ4_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
		obj._0023_003Dz7CYYMI_00243MGHvnKq_0024jmY_VcIFODy7(_0023_003DziDLVpbY_003D._0023_003DzOwJERBVAuTqjh71jJLc2f5rPKwjwHUqx8z35g6c_003D());
		return obj;
	}

	private static void _0023_003Dzuibc_Ifna0U3bwijB6_MjcLRw0rYvMqiBg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzu0a9M9zXrZOr09UDVft0TcHevaFuOoyqag_003D_003D(((_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzwyKpuA_mNwWyADXJn6Q3N8s_003D());
	}

	private static void _0023_003DzhriuXvk6OTYxyHyL5eIXX5CV_0024nV1vZ37Cg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DziDLVpbY_003D._0023_003DzTYpttnKnXlCifeH26HfbGmzO2lm6(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2));
	}

	private static void _0023_003DzkuUk1uiSqWpGlLC4SnTgtwWheX2IolGUqg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true);
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(type);
	}

	private void _0023_003Dz_B0XQPvPwkjMfmL0XL_0024_00249yw_003D()
	{
		if (m__0023_003DzTSeNR8Q_003D._0023_003DzEuJfM2g1v8Mcj9WVg4SiajPXq2cE())
		{
			Type type = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(m__0023_003DzTSeNR8Q_003D._0023_003Dzx5X59GHDhQCY67nsHADQ8HctXRx6EilYiQ_003D_003D(), _0023_003Dz5rQzobg_003D: false);
			if (type != null)
			{
				RuntimeHelpers.RunClassConstructor(type.TypeHandle);
			}
		}
	}

	private static void _0023_003DztFZ_XzNX5ojemalYDkihIYXDEUnR(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
	}

	private static void _0023_003DznWSc8aFL1oKKDrAnzZfdbL5RZBxwQWpnSw_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		Thread.MemoryBarrier();
	}

	private static void _0023_003DzqfgLU_fea9ZL67gRQJhT7iFJVKxe7egTRoatQsQ_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		object obj = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		long num = _0023_003DziDLVpbY_003D._0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt();
		Array array = (Array)_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(short))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(short));
			((short[])array)[num] = (short)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType == typeof(ushort))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(ushort));
			((ushort[])array)[num] = (ushort)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType == typeof(char))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(char));
			((char[])array)[num] = (char)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003DziDLVpbY_003D._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(elementType, obj, num, array);
		}
		else
		{
			_0023_003DziDLVpbY_003D._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(typeof(short), obj, num, array);
		}
	}

	private static void _0023_003Dz4y9fziuq9Q7e3L7BImhoShqif7EWq0d6Sg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D());
	}

	private static void _0023_003DzenLkeMckiNQ5N9KoMJWkpDiqaXeZbRMIKm4ik_s_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dz5rQzobg_003D);
	}

	private static void _0023_003DzywNSYuuAWxr_6426XKRUDGIAqmqAIIwppg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		FieldInfo fieldInfo = _0023_003DziDLVpbY_003D._0023_003DzsH6I9ZDv5gPH5Am4bCK2nNxE2uzwyQ3uDe_00241OaRt2yRO(num);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2)
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2);
		}
		object obj = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		if (obj == null)
		{
			throw new NullReferenceException();
		}
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(fieldInfo.GetValue(obj), fieldInfo.FieldType));
	}

	private static void _0023_003DzB2NAN4wLofHmU_00247aN8nDy3OXkQGsuUZ2Dg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzJAojZB2QIuH_jIxrACIzvilaDqHq(_0023_003DziDLVpbY_003D: true, _0023_003Dz5rQzobg_003D: false);
	}

	private void _0023_003Dzs8e6IcKEHH3pzHTeTkSowk0_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dz00AhOF3fCtaT9RBe7pDI_0024dDnP1r2xP_7uCOaiJsp1AY4(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2, _0023_003DziDLVpbY_003D));
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzrUb_0024eeiP_0024JYAU47F_iKJcFstj2o1nrMCAbIY1qGm4AWs(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
			_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D();
			obj._0023_003DzI9gf1jAlM5PPTe_0024AK_G6hL0Q8r0D(~num);
			return obj;
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			long num2 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D obj2 = new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D();
			obj2._0023_003Dzy6HyfSoNxN_JAsWz2P6G9bk_003D(~num2);
			return obj2;
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(~Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D()));
			}
			return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(~Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D()));
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzqkbVaKEiMvEPw6sA0GcU8aVeotjz(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
	}

	public static void _0023_003DzVnuRKQib1vy5KP3Rvd0DbOBPyj4Evpsm_0024w_003D_003D<T>(T[] _0023_003DziDLVpbY_003D, Comparison<T> _0023_003Dz5rQzobg_003D)
	{
		KeyValuePair<int, T>[] array = new KeyValuePair<int, T>[_0023_003DziDLVpbY_003D.Length];
		for (int i = 0; i < _0023_003DziDLVpbY_003D.Length; i++)
		{
			array[i] = new KeyValuePair<int, T>(i, _0023_003DziDLVpbY_003D[i]);
		}
		Array.Sort(array, _0023_003DziDLVpbY_003D, new _0023_003DzTSeNR8Q_003D<T>(_0023_003Dz5rQzobg_003D));
	}

	private void _0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(Type _0023_003DziDLVpbY_003D)
	{
		long index = _0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt();
		Array array = (Array)_0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(array.GetValue(index), _0023_003DziDLVpbY_003D));
	}

	private void _0023_003Dzu0a9M9zXrZOr09UDVft0TcHevaFuOoyqag_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(this.m__0023_003Dzt_m8zV0_003D[_0023_003DziDLVpbY_003D]._0023_003Dz5lslr6cY84EhmY4zXHchiRWu3kQNhqjmGcu8SDdt4PC3hOVR_dhU_0024Xh6CjBfnPFf6PSrQ7YCFTCw());
	}

	private static void _0023_003Dz3Y05bSqCbyfMtTrn3ZPqG1Ol6DDZ(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzs12LFbj_0024U7TMDTjuE_0024QMr5V4WvhQPpLitMz_O0kJxSlJ(_0023_003DziDLVpbY_003D: false);
	}

	private static _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzXpJ4YjM_OuoF7wsfWkRdLPw_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D)
	{
		if (!_0023_003DzAvn2b38_003D)
		{
			long num = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			long num2 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
			return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num / num2);
		}
		long num3 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		ulong num4 = (ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D((long)((ulong)num3 / num4));
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzJDmipPGbZDxjS5wNdonxwAY_003D()
	{
		return _0023_003DzE8QrneA_003D ?? _0023_003DzoMNiNRw_003D.Peek();
	}

	private static void _0023_003DzEG9ru65ZRovJABJZBgJIZc2RPQK5(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzZZIwdR7TQhtzyOKUBJPDlyxjF5gEFIonpplSp5o_003D(_0023_003DziDLVpbY_003D: true);
	}

	private void _0023_003DzwN3jKP8RF7Y_0024fuRAYM1m3AvyXJT_00245xdFKg_003D_003D()
	{
	}

	private void _0023_003DzY_Qho9G6NDOFx1ZRp_0024YDMpUtokq6aO_Vaw_003D_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (int)((!_0023_003DziDLVpbY_003D) ? ((ushort)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()) : checked((uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D())), 
			13 => (int)((!_0023_003DziDLVpbY_003D) ? ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() : checked((uint)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ())), 
			19 => (int)((!_0023_003DziDLVpbY_003D) ? Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()) : checked((uint)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()))), 
			8 => (int)((!_0023_003DziDLVpbY_003D) ? ((uint)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()) : checked((uint)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D())), 
			0 => (int)((IntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((uint)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())) : ((!_0023_003DziDLVpbY_003D) ? ((int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((int)checked((uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())))), 
			20 => (int)((UIntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((ulong)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()) : checked((uint)(ulong)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D())) : ((!_0023_003DziDLVpbY_003D) ? ((uint)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()) : ((uint)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()))), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzmWaS3k7fg9fLijZ1PD_0024zmcebsLUJ()
	{
		this.m__0023_003Dz8wjMonY_003D = _0023_003DzWWgGxds_003D;
		int key = _0023_003DziP9fFuA_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D();
		_0023_003DzWWgGxds_003D += 4u;
		_0023_003Dz61IPlm0_003D.TryGetValue(key, out var value);
		value._0023_003Dz5rQzobg_003D(this, _0023_003DztdLtEFyQYOKh66UbjMcpn_sgPRbCaHovUAQYe_0024o_003D(_0023_003DziP9fFuA_003D, value._0023_003DziDLVpbY_003D));
	}

	private static void _0023_003DzoxSePKFe4ZasTxbqMfgChpqBcJST(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D();
		obj._0023_003DzI9gf1jAlM5PPTe_0024AK_G6hL0Q8r0D(_0023_003DznPx5gMhR_0024wSvGh_pza5trRU_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2) ? 1 : 0);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private void _0023_003Dz_n5BZhw_IK4Rr1iI39agUSqxM0VPWNeUpoJ8wdXTYDmh(Stream _0023_003DziDLVpbY_003D, string _0023_003Dz5rQzobg_003D)
	{
		_0023_003DzcLVNAa8W3VqN1PrfdtyYkIx7DwC5(_0023_003DziDLVpbY_003D, 0L, _0023_003Dz5rQzobg_003D);
	}

	private static void _0023_003Dz3mL3KM0ovmoParf_Cqcu0_0024g_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => (long)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			8 => (long)checked((ulong)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003DzFcd5b1NerPBv8Ji62_RSmeXGISQf()
	{
		_0023_003DzfJFRO2o_003D = true;
	}

	private static void _0023_003DzYquLvIsYETUelqXjt6N0lmOlTqd3(object _0023_003DziDLVpbY_003D)
	{
		throw _0023_003DziDLVpbY_003D;
	}

	private static bool _0023_003DznPx5gMhR_0024wSvGh_pza5trRU_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		bool result = false;
		switch (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
		{
		case 1:
			result = ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 19) ? ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 7 || _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() != null) ? (((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() == ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()) : (((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() == 0)) : (((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D() == Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())));
			break;
		case 13:
			result = ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 19) ? ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 7 || _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() != null) ? (((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() == ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()) : (((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() == 0)) : (((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() == Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())));
			break;
		case 0:
			result = ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 7 && _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == null) ? (((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DziDLVpbY_003D)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee() == IntPtr.Zero) : ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 1) ? ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 13) ? (((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DziDLVpbY_003D)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee() == ((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003Dz5rQzobg_003D)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : (((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DziDLVpbY_003D)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee() == new IntPtr(((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()))) : (((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DziDLVpbY_003D)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee() == new IntPtr(((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()))));
			break;
		case 20:
			result = ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 7 && _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == null) ? (((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DziDLVpbY_003D)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D() == UIntPtr.Zero) : ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 1) ? ((_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 13) ? (((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DziDLVpbY_003D)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D() == ((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003Dz5rQzobg_003D)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()) : (((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DziDLVpbY_003D)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D() == new UIntPtr((ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003Dz5rQzobg_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()))) : (((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DziDLVpbY_003D)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D() == new UIntPtr((uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()))));
			break;
		case 7:
			result = _0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
			break;
		case 25:
			result = (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 7 || _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() != null) && ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyRdZjLZLQVmvToKIwRdaQqc_003D)_0023_003DziDLVpbY_003D)._0023_003DzHAnywLNcTsWPY7155LurFcQcmnn8() == ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyRdZjLZLQVmvToKIwRdaQqc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzHAnywLNcTsWPY7155LurFcQcmnn8();
			break;
		case 19:
		{
			_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D _0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D2 = (_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DziDLVpbY_003D;
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				result = Convert.ToInt64(_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D2._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()) == Convert.ToInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D());
			}
			else if (_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D2._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D() == null)
			{
				result = _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == null;
			}
			else if (_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() != null)
			{
				result = Convert.ToInt64(_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D2._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()) == Convert.ToInt64(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
			}
			break;
		}
		case 8:
		{
			double d = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			double num = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003Dz5rQzobg_003D)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D();
			result = !double.IsNaN(d) && !double.IsNaN(num) && d.Equals(num);
			break;
		}
		case 11:
		case 24:
		{
			_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D obj3 = (_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D)_0023_003DziDLVpbY_003D;
			_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D2 = (_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D)_0023_003Dz5rQzobg_003D;
			result = obj3._0023_003Dz8iYsggSu6g24k7KEwy__0024bV_0024loU2tRUJ_EER6_ThqlX14vYTR5A5vD16td2aLJ0Fo2jyPajTPw0wpbksAjw_003D_003D(_0023_003DqiipmHPQffrHbQ6jZsIqrDeGQ2lBnmRItTsrGSDB4J1g_003D2);
			break;
		}
		case 18:
		{
			_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2 = (_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D)_0023_003DziDLVpbY_003D;
			_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D3 = (_0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D)_0023_003Dz5rQzobg_003D;
			result = _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2._0023_003DzdUxw3_0024V0zjE7LCNS0d6jNIXKeWTEQSZ1_Q_003D_003D() == _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D3._0023_003DzdUxw3_0024V0zjE7LCNS0d6jNIXKeWTEQSZ1_Q_003D_003D() && _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D2._0023_003DzddbcHyilBA8MndTeiRwzcmFqKumQ() == _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D3._0023_003DzddbcHyilBA8MndTeiRwzcmFqKumQ();
			break;
		}
		case 23:
		{
			_0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D obj2 = (_0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D)_0023_003DziDLVpbY_003D;
			_0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D _0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D2 = (_0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D)_0023_003Dz5rQzobg_003D;
			result = obj2._0023_003DzNAQX8ra3l1_0024XGAa1nNj6HCKZAd1O1wd8Wyz3ozD5SlgH() == _0023_003DqCamkBM7Pyb2IDEnDiYrsc4_0024KzWQouYnKC_hTEAYDQ2A_003D2._0023_003DzNAQX8ra3l1_0024XGAa1nNj6HCKZAd1O1wd8Wyz3ozD5SlgH();
			break;
		}
		case 2:
		{
			_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D obj = (_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D)_0023_003DziDLVpbY_003D;
			result = _0023_003DznPx5gMhR_0024wSvGh_pza5trRU_003D(((_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzHZ5NKvAS4A9t8ypYPcqODs_XKjmA(), obj._0023_003DzHZ5NKvAS4A9t8ypYPcqODs_XKjmA());
			break;
		}
		default:
			result = _0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() == _0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
			break;
		}
		return result;
	}

	private static void _0023_003Dz8KDS4FCeG8RYTpKFJXbAgknzuY6PtV0JJVTLv2wogr_0024b(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(1);
	}

	private static void _0023_003DzPcEPLdK4994VyhtDqMXqh_0024_00242e72DZ6xmO_00249xCtk_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(_0023_003DzDNpeQO0_003D);
	}

	private static void _0023_003DzKiN7Dtg8GH13M90zYr3_0024J89DB272d7ulpFOCjFdXbulW(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
	}

	private static void _0023_003DzV1XDE18mH3R8HAzotUnZgaE_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D2 = (_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (double.IsNaN(_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D2._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()) || double.IsInfinity(_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D2._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()))
		{
			throw new OverflowException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908177));
		}
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D2);
	}

	private static void _0023_003Dz_0024ELTdXzXRDfjIZuVvQnLSIM_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzh_00242qvyQjZfTqLkqfhujxArQ_003D(typeof(short));
	}

	private static void _0023_003Dzu62BvHGyf6WyNPMrLWtDBNg_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003DzJDmipPGbZDxjS5wNdonxwAY_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz5lslr6cY84EhmY4zXHchiRWu3kQNhqjmGcu8SDdt4PC3hOVR_dhU_0024Xh6CjBfnPFf6PSrQ7YCFTCw());
	}

	private static void _0023_003DzLOgSGCTBCn7LXVmAw43jf0nmNER3yT0R8Q_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzJ_0024HvPm_Ti0SZUguFjk9lMjv31F9kzigDH8FeRyY_003D(null, num);
	}

	private static void _0023_003Dzb5WMAXT6Tms0x7gD5xCogExPn_0024vn(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (_0023_003Dzuswnmji79EY9HAT9xe48I8VcyGZsYBvYod3q0mI_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private static void _0023_003DzDl8s7f504vjxiFNoQpaKweo_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003Dz5rQzobg_003D);
	}

	private static void _0023_003DzDK9voMBOwBm_00246pyMRMGTdMR2wZTT(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		object obj = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		long num = _0023_003DziDLVpbY_003D._0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt();
		Array array = (Array)_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(sbyte))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(sbyte));
			((sbyte[])array)[num] = (sbyte)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType == typeof(byte))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(byte));
			((byte[])array)[num] = (byte)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType == typeof(bool))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(bool));
			((bool[])array)[num] = (bool)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D4._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003DziDLVpbY_003D._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(elementType, obj, num, array);
		}
		else
		{
			_0023_003DziDLVpbY_003D._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(typeof(sbyte), obj, num, array);
		}
	}

	private void _0023_003Dzz9Rp_00249b6lGMYj_jZQQ_003D_003D(Type _0023_003DziDLVpbY_003D)
	{
		object obj = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		long num = _0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt();
		Array array = (Array)_0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		_0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(_0023_003DziDLVpbY_003D, obj, num, array);
	}

	private static void _0023_003DzWkP_WFWbT1_0024uvdxzJ5K_YOg_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2 = (_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D;
		MethodBase methodBase = _0023_003DziDLVpbY_003D._0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
		Type declaringType = methodBase.DeclaringType;
		Type type = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType();
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
		_0023_003DqVq2G06qUQtchgF1EnbfnvW94BfgqBHFxi7iIWrl2lfE_003D obj = new _0023_003DqVq2G06qUQtchgF1EnbfnvW94BfgqBHFxi7iIWrl2lfE_003D();
		obj._0023_003DztXPjv8jDiWmFW3sXs84MniY_003D(methodBase2);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DzuIh3yneTRsQPaNb6hYtiEBjqYUsJXSYkC1OVG_Q_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				int num2 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				return new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(num << num2);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003DzuIh3yneTRsQPaNb6hYtiEBjqYUsJXSYkC1OVG_Q_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())));
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 13)
		{
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 1)
			{
				long num3 = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DziDLVpbY_003D)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
				int num4 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
				return new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(num3 << num4);
			}
			if (_0023_003Dz5rQzobg_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
			{
				return _0023_003DzuIh3yneTRsQPaNb6hYtiEBjqYUsJXSYkC1OVG_Q_003D(_0023_003DziDLVpbY_003D, new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003Dz5rQzobg_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())));
			}
		}
		if (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return _0023_003DzuIh3yneTRsQPaNb6hYtiEBjqYUsJXSYkC1OVG_Q_003D(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(Convert.ToInt64(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D);
			}
			return _0023_003DzuIh3yneTRsQPaNb6hYtiEBjqYUsJXSYkC1OVG_Q_003D(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(Convert.ToInt32(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D())), _0023_003Dz5rQzobg_003D);
		}
		throw new InvalidOperationException();
	}

	private static void _0023_003DzvlKuvw7JaHUd0IziVnC5F_s_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzZZIwdR7TQhtzyOKUBJPDlyxjF5gEFIonpplSp5o_003D(_0023_003DziDLVpbY_003D: false);
	}

	private _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] _0023_003DzasljNkP_tqhTXBKxNvjH5Picl6cgjZLys6va7fk_003D()
	{
		_0023_003DqEuqRbUDMza2VMSHT0tUFWr_E0A2fYfBboqmWskNkdMc_003D[] array = m__0023_003DzTSeNR8Q_003D._0023_003DzGLBml80_0024kUHqdVh6a7aAHtXyqGsxov4D8A_0024iLVitGyT3();
		int num = array.Length;
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[] array2 = new _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(array[i]._0023_003Dz4pTr_Y_0024H_0024O4S_0024eTRTmqu5P4_003D(), _0023_003Dz5rQzobg_003D: false));
		}
		return array2;
	}

	private static void _0023_003Dz6Dcl0v_0024_roY2MUDkpP7jqIYYbKWw(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (_0023_003DznPx5gMhR_0024wSvGh_pza5trRU_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private bool _0023_003Dzi5GunkUNtWcs1UYuXPMw_U_Sq5gw1Vkd3KGUX1k_003D()
	{
		if (_0023_003DzE8QrneA_003D == null)
		{
			return _0023_003DzoMNiNRw_003D.Count != 0;
		}
		return true;
	}

	private void _0023_003Dzk9G2xiUurtSg1qn7uA3dhHyRVACuGPtfng_003D_003D(MemberInfo _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DzYRKsYteRnSlUXNbsiimfrW1GD7a_pPG2CAzCK1A_003D() || m__0023_003DzTSeNR8Q_003D._0023_003DzE09YSzfEEE1P3W8FnELkPE7NS00dvHHw7ktnt4nfsPiH())
		{
			return;
		}
		bool flag = false;
		Assembly assembly = typeof(SecurityCriticalAttribute).Assembly;
		MemberInfo memberInfo = _0023_003DziDLVpbY_003D;
		while (memberInfo != null)
		{
			object[] customAttributes = memberInfo.GetCustomAttributes(inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				Type type = customAttributes[i].GetType();
				if (type.Assembly == assembly)
				{
					string fullName = type.FullName;
					if (_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908414).Equals(fullName, StringComparison.Ordinal))
					{
						flag = true;
						goto end_IL_009d;
					}
					if (_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908366).Equals(fullName, StringComparison.Ordinal))
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
			if (_0023_003DziDLVpbY_003D is MethodBase)
			{
				string text = _0023_003DzkQLjItqF_lIZYwJQbODeKCgUFOeXie_Nf8u4QtQ_003D((MethodBase)_0023_003DziDLVpbY_003D);
				throw _0023_003DzFiW2vL9FCL2PzF1dLaOPOe8xYBzQm2pB2wskbIqR8xo7(_0023_003DzAtENpYMCi0SVBdywzDDR6hQhtlnL(m__0023_003DzTSeNR8Q_003D), text);
			}
			if (_0023_003DziDLVpbY_003D is FieldInfo)
			{
				string text2 = _0023_003DziDLVpbY_003D.DeclaringType.FullName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290) + _0023_003DziDLVpbY_003D.Name;
				throw _0023_003DzAQaegUXL0B9STTaFrCM_0024tZ3iZQy1e_oflUuFLD8_003D(_0023_003DzAtENpYMCi0SVBdywzDDR6hQhtlnL(m__0023_003DzTSeNR8Q_003D), text2);
			}
			if (_0023_003DziDLVpbY_003D is Type)
			{
				string fullName2 = ((Type)_0023_003DziDLVpbY_003D).FullName;
				throw _0023_003DzkUNJcRRmj4K6rfgGEX_moeb6R5D_0024(_0023_003DzAtENpYMCi0SVBdywzDDR6hQhtlnL(m__0023_003DzTSeNR8Q_003D), fullName2);
			}
			throw new SecurityException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908298));
		}
	}

	private void _0023_003Dzn38u8aV98_00242qJOrydP7_0024VPOja_0024MLD4YmdNsUKes_003D()
	{
		_0023_003DzVnuRKQib1vy5KP3Rvd0DbOBPyj4Evpsm_0024w_003D_003D(_0023_003DzjbqS1qE_003D, (_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2, _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D3) => (_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK() == _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D3._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK()) ? _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D3._0023_003DzrRpn5KHjaIKRa2Vs_0024HZe4YswX1zq_0024V2Y6w_003D_003D().CompareTo(_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzrRpn5KHjaIKRa2Vs_0024HZe4YswX1zq_0024V2Y6w_003D_003D()) : _0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D2._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK().CompareTo(_0023_003Dq6BQK4POmdQSdOG1gXvn7D8GkPWDOpIx9oxZlQegJIGM_003D3._0023_003DzoXnLSGv_AP8G5dEEtE7M8liPBFAK()));
	}

	private void _0023_003DzZoHutE04P0sbCnLGpmJQ5GI_003D(bool _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DzcsKUV375wg9IEHdp4A_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D));
	}

	private static void _0023_003Dz73h0QSLdYGwOYLow7aDZ8NMYYEjYrOoxyw_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzsFXvHzaYgcDmOt8flQZ9JbA_003D(_0023_003DziDLVpbY_003D: false);
	}

	private static void _0023_003DzltjID8388h_00249sf5w7Lf3FLkmfjUi_mvfsgN6kf0_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		FieldInfo fieldInfo = _0023_003DziDLVpbY_003D._0023_003DzsH6I9ZDv5gPH5Am4bCK2nNxE2uzwyQ3uDe_00241OaRt2yRO(num);
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 as _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D;
		object obj = ((_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2 == null) ? _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D() : _0023_003DziDLVpbY_003D._0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(_0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2)._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003DqxDdJs6FlEwuzAP5rV8TAlmU5GYPVduAJhjOCOOYlMoM_003D(fieldInfo, obj, _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D2));
	}

	private static void _0023_003DzxmDxvuaZZoXccePtlB5QyOlLYsOs2rZ066uHrM_0024XeIAF(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (!_0023_003Dz6HPSY_0024zpefu_0024sPp4tcYcOC6YvaQ_H1xKIg_003D_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private static void _0023_003DzLJc0BY2Oawi1GPRYGnuJVCQ_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dzu0a9M9zXrZOr09UDVft0TcHevaFuOoyqag_003D_003D(3);
	}

	private static void _0023_003DzDVw8osix5fMBRA6TSG05OixJ9mNCXIa33w_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 = _0023_003DziDLVpbY_003D._0023_003DzLrd1XNI9dc0qU09uargDhdLHbDdl(num);
		object obj = ((_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003DzOl4znCSQJV_o3jzYnD1EuZw5Wuu52ADXGg_003D_003D() == 0) ? _0023_003DziDLVpbY_003D._0023_003DzmIyULriwSoml9r_uGJY4WsO0Np2POnFN1w_003D_003D(_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003Dz11WFGXccc_0024IogAle69T4JHhyY45p()) : (_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2._0023_003DzpKaM9DJ9LSi0XInJkPIbPujKUbSQ()._0023_003Dz5X9cdP7TrgrdPx0If8tVEEi6NdL5ax_00247XEJ4AW86KFqLMqebj0qzls9VtNXr9fHdJP1qqnSZhh4l10WlSBY8ef0_003D() switch
		{
			2 => _0023_003DziDLVpbY_003D._0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(num, _0023_003Dz5rQzobg_003D: true).TypeHandle, 
			0 => _0023_003DziDLVpbY_003D._0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(num).MethodHandle, 
			1 => _0023_003DziDLVpbY_003D._0023_003DzsH6I9ZDv5gPH5Am4bCK2nNxE2uzwyQ3uDe_00241OaRt2yRO(num).FieldHandle, 
			_ => throw new InvalidOperationException(), 
		}));
		_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D obj2 = new _0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D();
		obj2._0023_003Dzq88_O_cwFvCcGI6peg_0024JzLs_003D(obj);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj2);
	}

	private static void _0023_003DzmXNQtyq8_uKlNeY1wfjLCSHs6RZekBK6toBInbwl5swf(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz0LZ3a2KNB2rgSf490RJHmy0_003D(1);
	}

	private void _0023_003DzaPUI9Skbf6ceOvYGSq43RNlVyMt5MZLDd8Aq2Rg_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		MethodBase methodBase = _0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(num);
		Type declaringType = methodBase.DeclaringType;
		ParameterInfo[] parameters = methodBase.GetParameters();
		int num2 = parameters.Length;
		object[] array = new object[num2];
		Dictionary<int, _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D> dictionary = new Dictionary<int, _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D>();
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
			if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 is _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D value)
			{
				dictionary.Add(num3, value);
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DzpAydaFGOKCTooHKhC9XHa0CbjB1KGzylFh895YIdmdwq(value);
			}
			if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D() != null)
			{
				_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D())._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
			}
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, parameters[num3].ParameterType)._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2);
			array[num3] = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		object obj;
		try
		{
			obj = _0023_003Dzua402qH0PvFyh_SwU_t_0024Pt1hg0nvpQRf9w_003D_003D(methodBase, null, array, _0023_003DzR58imxw_003D: false);
		}
		catch (TargetInvocationException ex)
		{
			Exception ex2 = ex.InnerException ?? ex;
			_0023_003DzBobqTgiv7_0024qJTDQ7T1G4q1vlSWRN(ex2);
			return;
		}
		foreach (KeyValuePair<int, _0023_003DqxDdJs6FlEwuzAP5rV8TAlkwOL5c1C2cOUD0ZGqaXQZU_003D> item in dictionary)
		{
			_0023_003DzA2z9m8sQOb7_VQnkzduC34U_003D(item.Value, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(array[item.Key], null));
		}
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, declaringType));
	}

	private _0023_003DqEuqRbUDMza2VMSHT0tUFWr_E0A2fYfBboqmWskNkdMc_003D[] _0023_003DzLXWRRdvI_QfK6LpZ45IlR7OxehqFxHSb93F9_0024P0_003D(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DqEuqRbUDMza2VMSHT0tUFWr_E0A2fYfBboqmWskNkdMc_003D[] array = new _0023_003DqEuqRbUDMza2VMSHT0tUFWr_E0A2fYfBboqmWskNkdMc_003D[_0023_003DziDLVpbY_003D._0023_003DzBLlGVMs_2v1_00240JsyU3F1qlk_003D()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003DzD59TkudeASTUhHZlbVsu8mFxNFjf(_0023_003DziDLVpbY_003D);
		}
		return array;
	}

	private static object _0023_003DzrOasWdkNxP5xSmuoAMTQ_0024Z6JHx0pW87i66jlGoS4sPoe(MethodBase _0023_003DziDLVpbY_003D, object _0023_003Dz5rQzobg_003D, object[] _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		_0023_003DzshZYG54_003D _0023_003DzshZYG54_003D2 = new _0023_003DzshZYG54_003D(_0023_003DziDLVpbY_003D, _0023_003DzR58imxw_003D);
		_0023_003DzWYPqg2E_003D _0023_003DzWYPqg2E_003D2 = _0023_003DzTizJ17ML_00242gDpbz8RMs9BL4_003D(_0023_003DzshZYG54_003D2);
		if (_0023_003DzWYPqg2E_003D2 == null)
		{
			bool flag;
			lock (_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzAvn2b38_003D)
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzAvn2b38_003D.TryGetValue(_0023_003DziDLVpbY_003D, out var value);
				flag = value >= 50;
				if (!flag)
				{
					_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzAvn2b38_003D[_0023_003DziDLVpbY_003D] = value + 1;
				}
			}
			if (!flag && (_0023_003DzR58imxw_003D || _0023_003Dz5rQzobg_003D != null || _0023_003DziDLVpbY_003D.IsStatic || _0023_003DziDLVpbY_003D.IsConstructor) && !_0023_003DzstEuFBwD_0024cVisuRapmnIEdhjv2Amxc5ybBPAFde2I_0024CD(_0023_003DziDLVpbY_003D) && (_0023_003DziDLVpbY_003D.CallingConvention & CallingConventions.Any) != CallingConventions.VarArgs)
			{
				return _0023_003Dz0SAYSWlBoo6DiPJ2iw_003D_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
			}
			_0023_003DzWYPqg2E_003D2 = _0023_003Dz1EPfP0_0024ESDIVU_I2vaBay0TLpLYMqnuNoQ_003D_003D(_0023_003DzshZYG54_003D2);
			lock (_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzAvn2b38_003D)
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzAvn2b38_003D.Remove(_0023_003DziDLVpbY_003D);
			}
		}
		return _0023_003DzWYPqg2E_003D2(_0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
	}

	private void _0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003DziDLVpbY_003D));
	}

	private static void _0023_003DzWEdLnKl4PSSUwiv6CM_0024zUv7KgThMehD8_0024g_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz7mynNKsHIP_0024dgNXTtQ5_0024UurcBU_0LKlxAzR2E_A_003D();
	}

	private static void _0023_003Dz40sYtypX6bvk2ITmr4WpdakSgrw5j_v8BDtmnSw_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		throw new NotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908505));
	}

	private _0023_003DqEuqRbUDMza2VMSHT0tUFWr_E0A2fYfBboqmWskNkdMc_003D _0023_003DzD59TkudeASTUhHZlbVsu8mFxNFjf(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DqEuqRbUDMza2VMSHT0tUFWr_E0A2fYfBboqmWskNkdMc_003D obj = new _0023_003DqEuqRbUDMza2VMSHT0tUFWr_E0A2fYfBboqmWskNkdMc_003D();
		obj._0023_003DzvrZDyimrn1umy7_KmnO8RHIZFRw5h0oD7A_003D_003D(_0023_003DziDLVpbY_003D._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
		return obj;
	}

	private Stack<_0023_003Dz437_00244ak_003D> _0023_003DzmhNPwvYqeFIwGaYvUVC5r3pbe1W7()
	{
		Stack<_0023_003Dz437_00244ak_003D> stack = _0023_003DzO_0024iiQ4U_003D;
		if (stack == null)
		{
			stack = (_0023_003DzO_0024iiQ4U_003D = new Stack<_0023_003Dz437_00244ak_003D>());
			stack.Push(new _0023_003Dz437_00244ak_003D
			{
				_0023_003Dz5rQzobg_003D = _0023_003DziP9fFuA_003D,
				_0023_003DzAvn2b38_003D = _0023_003DziP9fFuA_003D._0023_003DzUXjbc9BY9W9m2seLWnn7jsJDEathvvwviQ_003D_003D(),
				_0023_003DzR58imxw_003D = _0023_003DzGcl_0024E9o_003D
			});
		}
		return stack;
	}

	private static void _0023_003DznHzb6PXrEz_zYYcRtA_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DziDLVpbY_003D._0023_003DziOyAZyrnhvMXTbVIv78SGaaMnLAOmEgk9A_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2));
	}

	private void _0023_003DzsFXvHzaYgcDmOt8flQZ9JbA_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		short num = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (!_0023_003DziDLVpbY_003D) ? ((short)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()) : checked((short)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), 
			13 => (!_0023_003DziDLVpbY_003D) ? ((short)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()) : checked((short)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()), 
			19 => (!_0023_003DziDLVpbY_003D) ? ((short)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())) : checked((short)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => (!_0023_003DziDLVpbY_003D) ? ((short)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()) : checked((short)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((short)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((short)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())) : ((!_0023_003DziDLVpbY_003D) ? ((short)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((short)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D obj = new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D();
		obj._0023_003DzI9gf1jAlM5PPTe_0024AK_G6hL0Q8r0D(num);
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	private static void _0023_003Dze3e48UT55GuFmYe61RJ7cgwWWedEO_5LmOfafbk_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		int num = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		FieldInfo fieldInfo = _0023_003DziDLVpbY_003D._0023_003DzsH6I9ZDv5gPH5Am4bCK2nNxE2uzwyQ3uDe_00241OaRt2yRO(num);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(fieldInfo.GetValue(null), fieldInfo.FieldType));
	}

	private static void _0023_003DzZZvDHq5c4Ecbhl_iANPCIPySDlwY6MJQMQ_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzIkM3CaSWupD4_0024gmIh5V76vLJzMAa(0);
	}

	private static void _0023_003Dz4sSb_002447BDbb6fqz5huUQKp8qZYRxoEzZJBGsleHtGcOH(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzG0sLb4KknAEWbZ0RU0a5_0024ocUErv3RTj5qyVxHC_E8Dng(_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D);
	}

	private static void _0023_003DzwXle8OA0jZf7dui1oEmvoAo_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		float num = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			8 => (float)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
			_ => throw new InvalidOperationException(), 
		};
		_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D();
		obj._0023_003Dzi486AbgApFOEBMsFwXnRpk84cKCB4HftcSQ6800_003D(num);
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
	}

	[DebuggerNonUserCode]
	private MethodBase _0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 = _0023_003DzLrd1XNI9dc0qU09uargDhdLHbDdl(_0023_003DziDLVpbY_003D);
		MethodBase result = _0023_003DzxFCw4O0oSzz4ae_0024c90eLINeyH_agUXkmxGBC2IA_003D(_0023_003DziDLVpbY_003D, _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2);
		_0023_003Dzk9G2xiUurtSg1qn7uA3dhHyRVACuGPtfng_003D_003D(result);
		return result;
	}

	private static void _0023_003DzC2L_2PbykaPBuWKaP3INz7cw6oL7mqSmTA_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzB_0024y0GUDRjw6r5v7Rng_003D_003D(_0023_003DziDLVpbY_003D: false);
	}

	private static void _0023_003DzLKxZANrFOB7hqYlyirh3OMGaxsZjF6VtDGqshSc_003D(ILGenerator _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		switch (_0023_003Dz5rQzobg_003D)
		{
		case -1:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_M1);
			return;
		case 0:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_0);
			return;
		case 1:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_1);
			return;
		case 2:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_2);
			return;
		case 3:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_3);
			return;
		case 4:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_4);
			return;
		case 5:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_5);
			return;
		case 6:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_6);
			return;
		case 7:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_7);
			return;
		case 8:
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_8);
			return;
		}
		if (_0023_003Dz5rQzobg_003D > -129 && _0023_003Dz5rQzobg_003D < 128)
		{
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4_S, (sbyte)_0023_003Dz5rQzobg_003D);
		}
		else
		{
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Ldc_I4, _0023_003Dz5rQzobg_003D);
		}
	}

	private object _0023_003Dzzo2beSOiRhkSPKWQjtSuTaysq4HG48olaRV1zc8CBAkO(object[] _0023_003DziDLVpbY_003D, Type[] _0023_003Dz5rQzobg_003D, Type[] _0023_003DzAvn2b38_003D, object[] _0023_003DzR58imxw_003D)
	{
		_0023_003Dz_B0XQPvPwkjMfmL0XL_0024_00249yw_003D();
		if (_0023_003DziDLVpbY_003D == null)
		{
			_0023_003DziDLVpbY_003D = global::_0023_003Dqg2XVMDwOcutFmLZPrQ_0024gP3UtIYnsaqJQUwZxoZJWQco_003D<object>._0023_003DziDLVpbY_003D;
		}
		this.m__0023_003DzkKfJheA_003D = _0023_003DzR58imxw_003D;
		_0023_003DzFmiij5k_003D = _0023_003Dz5rQzobg_003D;
		this.m__0023_003DzR58imxw_003D = _0023_003DzAvn2b38_003D;
		_0023_003Dzyk2fsPo_003D = _0023_003Dz6wFjKAvlSUkKqqhBc6gazJ5IGNhBnOFc5c3c_JA_003D(_0023_003DziDLVpbY_003D);
		this.m__0023_003Dzt_m8zV0_003D = _0023_003DzasljNkP_tqhTXBKxNvjH5Picl6cgjZLys6va7fk_003D();
		try
		{
			_0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D2 = new _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D(this.m__0023_003DzId5C3LA_003D);
			try
			{
				using (_0023_003DziP9fFuA_003D = new _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D(_0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D2))
				{
					_0023_003DzvXOLtKg_003D = (uint)_0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D2._0023_003DzraNgARjX4QSbGcrZYaUV_Kt5FJD_0024RmALGpou1doOgwLvbYwEh88yFgkavQ_0024_0024lIyzZM73DVaXA_e6k069AX2zF5I_003D();
					_0023_003DzfJFRO2o_003D = false;
					_0023_003DzxmoHVeQ_003D = null;
					this.m__0023_003Dz8wjMonY_003D = 0u;
					_0023_003DzWWgGxds_003D = 0u;
					_0023_003DzLjSHuyrc9krN4Y1HFYpc27g_003D();
					_0023_003DztqTBIbTo235VrTviboXsNvRcmLldAqEl8MFuUg5Jupve();
				}
			}
			finally
			{
				((IDisposable)_0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D2).Dispose();
			}
			Type type = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(m__0023_003DzTSeNR8Q_003D._0023_003DzrG0pCaZ8KJKmelGhBBl061cZv1tyMGFbpw_003D_003D(), _0023_003Dz5rQzobg_003D: false);
			if (type != _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D.m__0023_003DzbfrNXYE_003D && _0023_003Dzi5GunkUNtWcs1UYuXPMw_U_Sq5gw1Vkd3KGUX1k_003D())
			{
				return _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, type)._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D())._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
			}
			return null;
		}
		finally
		{
			for (int i = 0; i < m__0023_003DzTSeNR8Q_003D._0023_003Dz2ab977dO_V4bp_0024NWmafMNKyu2B0c().Length; i++)
			{
				_0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D _0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D2 = m__0023_003DzTSeNR8Q_003D._0023_003Dz2ab977dO_V4bp_0024NWmafMNKyu2B0c()[i];
				if (_0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D2._0023_003DzHxZONG5Od6vQ_crMT5iPpwf_0024Q_QeVh8xLg_003D_003D())
				{
					_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D _0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D2 = (_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D)_0023_003Dzyk2fsPo_003D[i];
					Type type2 = _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(_0023_003DqcjmfsaS6dKPuf2kSTqJKWVn0q9QFe_00242qTc7iOvvSnJU_003D2._0023_003DzOwLa1TRtX2zG2yT751wGPiNvTQKexziEvVO416VO0KpQ(), _0023_003Dz5rQzobg_003D: false);
					_0023_003DziDLVpbY_003D[i] = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(null, type2.GetElementType())._0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqUwzBjw0UTwLX7f6bfoiplJInezbgkLZ4SyguEuicqT8_003D2._0023_003DzHZ5NKvAS4A9t8ypYPcqODs_XKjmA())._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
				}
			}
			this.m__0023_003DzkKfJheA_003D = null;
			_0023_003Dzyk2fsPo_003D = null;
			this.m__0023_003Dzt_m8zV0_003D = null;
		}
	}

	private static void _0023_003DzU6X488kkrEx__bUHUXBK3M6hWtGyw0YnfbtOTiQ_003D(ILGenerator _0023_003DziDLVpbY_003D, Type _0023_003Dz5rQzobg_003D)
	{
		if (!(_0023_003Dz5rQzobg_003D == _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D))
		{
			_0023_003DziDLVpbY_003D.Emit(OpCodes.Castclass, _0023_003Dz5rQzobg_003D);
		}
	}

	private static void _0023_003DzL0ugPCGDi3vDh47IbrRTaZw_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzmBzPgUk9Q3vqIKYOZAVqp0d_8pOa0et_0024JhW17JA_003D(((_0023_003Dq81rtDNWruy80qDMPMzN3I_0024xdesNxP_00243fXFgUxQeE2W8_003D)_0023_003Dz5rQzobg_003D)._0023_003DzwyKpuA_mNwWyADXJn6Q3N8s_003D());
	}

	private Type _0023_003Dz8PYp8sGVM7J5MsdBzMAvw0_y_g5hbBsBLpvP32o_003D(int _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D)
	{
		Type type;
		lock (_0023_003DzHit7vU4_003D)
		{
			bool flag = true;
			if (flag && _0023_003DzHit7vU4_003D.TryGetValue(_0023_003DziDLVpbY_003D, out var value))
			{
				type = (Type)value;
			}
			else
			{
				_0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2 = _0023_003DzLrd1XNI9dc0qU09uargDhdLHbDdl(_0023_003DziDLVpbY_003D);
				type = _0023_003Dz_0024TKtyUGnVMLD0Yl8e_0024aYMyc3E77sLwj5LlRErJc_003D(_0023_003DziDLVpbY_003D, _0023_003DqiipmHPQffrHbQ6jZsIqrDdC_0024H8N0btq5zPH9iPYKE48_003D2, ref flag, _0023_003Dz5rQzobg_003D);
				if (flag)
				{
					_0023_003DzHit7vU4_003D.Add(_0023_003DziDLVpbY_003D, type);
				}
			}
		}
		if (_0023_003Dz5rQzobg_003D)
		{
			_0023_003Dzk9G2xiUurtSg1qn7uA3dhHyRVACuGPtfng_003D_003D(type);
		}
		return type;
	}

	private static void _0023_003Dzbc6r4LpQPdF_00243BrSiGv4RwsZAdr3JNN_0024cGKMhfeNwRdN(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(checked(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (ushort)(uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (ushort)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => (ushort)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			8 => (ushort)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((ushort)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((ushort)(uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzDkUw30QpMlbfTz6UWhINuuE3Tc7_iAgqTg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		MethodBase methodBase = ((_0023_003DqVq2G06qUQtchgF1EnbfnvW94BfgqBHFxi7iIWrl2lfE_003D)_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D())._0023_003DzeTV2NEMuHoIa9_2v_00248OAYNw_003D();
		_0023_003DziDLVpbY_003D._0023_003DzRV6qj2VK8lvFF9bhLcko27s_003D(methodBase, _0023_003Dz5rQzobg_003D: false);
	}

	private static _0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D _0023_003DzKsNYm96Lj47ScEelzMJ01rs_0024SUcn(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D obj = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (obj._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 13)
		{
			throw new InvalidOperationException();
		}
		long num = ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)obj)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ();
		int num2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D();
		if (num2 != 7 && num2 != 9)
		{
			throw new InvalidOperationException();
		}
		byte[] array = _0023_003DqEcE_dnDzdNcmr1ilrWUcQ52MvAN3ZHyGFRcpM7LnC4w_003D._0023_003Dzf0splXt0bRX707FLbXEfteTwqmJi(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
		if (_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() != 1)
		{
			throw new InvalidOperationException();
		}
		int num3 = ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D();
		_0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D obj2 = new _0023_003DqIYwamc_0024xa95DzIZnwgV16GHjUi0bl_wFjWc9pEpMqiY_003D();
		obj2._0023_003DzTTKyPQvNF_0024ywfG0OVce59m0_003D(num3);
		obj2._0023_003Dzk9kdfPkuUqVPDNq7kTp_0024RF7RWInt(array);
		obj2._0023_003DzkVGs3JXDckcdcEhH9mVu_0024w_HTq6e(num);
		return obj2;
	}

	private static void _0023_003DzoqvGZBtIsuIfytloKa5UgwJ1ZVm_0024UnRxxw_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzBobqTgiv7_0024qJTDQ7T1G4q1vlSWRN(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
	}

	private void _0023_003DzYoHr_kaBP_0024C0cQWQednER91YDBHg()
	{
		if (this.m__0023_003DziDLVpbY_003D.Count == 0)
		{
			if (this.m__0023_003DzWYPqg2E_003D)
			{
				_0023_003DzBobqTgiv7_0024qJTDQ7T1G4q1vlSWRN(_0023_003Dzl3DhHgI_003D);
			}
			return;
		}
		_0023_003DzmQTFaQA_003D _0023_003DzmQTFaQA_003D2 = this.m__0023_003DziDLVpbY_003D.Pop();
		if (_0023_003DzmQTFaQA_003D2._0023_003Dzrsahh8JhH1FOm_5VlQ5oZaE_003D() != null)
		{
			_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D obj = new _0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D();
			obj._0023_003Dzfsh7cMqdAFNS_00248RwnR8_1zXr2ps86Z24aphoSJytHiBZNZ9a7sN31tjwDTy9Bh9DbL0lataI5YTp0c4gcINa8Ms_003D(_0023_003DzmQTFaQA_003D2._0023_003Dzrsahh8JhH1FOm_5VlQ5oZaE_003D());
			_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(obj);
		}
		else
		{
			_0023_003DzLjSHuyrc9krN4Y1HFYpc27g_003D();
		}
		_0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(_0023_003DzmQTFaQA_003D2._0023_003DzKa4gcSzQnqPstmrk1_0024FE9i7M1ChN());
	}

	private static void _0023_003DzzIFd36KxOkksd_C4_0024JUxDybQaDEuT6Ib7Q_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2 = (_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003Dz5rQzobg_003D;
		MethodBase methodBase = _0023_003DziDLVpbY_003D._0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
		_0023_003DziDLVpbY_003D._0023_003DzRV6qj2VK8lvFF9bhLcko27s_003D(methodBase, _0023_003Dz5rQzobg_003D: false);
	}

	private static void _0023_003DzC1RG0OP2Z50e4BqYCo_WE6k5v0ioCT2QbkCqLtk_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => ((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (int)checked((uint)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()), 
			19 => (int)checked((uint)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => (int)checked((uint)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((int)checked((uint)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())) : ((int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003Dzjb1IgTEveIeEC3vQIlQu6tyrFAl_0024jxDeuOZu9UWrmvrR(_0023_003Dqxz2l2ec27m48r7iCFJ2Fx9odAoAV8mO3QEikJAzP7wo_003D _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DzYRKsYteRnSlUXNbsiimfrW1GD7a_pPG2CAzCK1A_003D() && !m__0023_003DzTSeNR8Q_003D._0023_003DzE09YSzfEEE1P3W8FnELkPE7NS00dvHHw7ktnt4nfsPiH() && _0023_003DziDLVpbY_003D._0023_003DzE09YSzfEEE1P3W8FnELkPE7NS00dvHHw7ktnt4nfsPiH() && !_0023_003DziDLVpbY_003D._0023_003DzMDgpR57RXiMLW7tdBmspNEFatyEt())
		{
			string text = _0023_003DzAtENpYMCi0SVBdywzDDR6hQhtlnL(_0023_003DziDLVpbY_003D);
			throw _0023_003DzFiW2vL9FCL2PzF1dLaOPOe8xYBzQm2pB2wskbIqR8xo7(_0023_003DzAtENpYMCi0SVBdywzDDR6hQhtlnL(m__0023_003DzTSeNR8Q_003D), text);
		}
	}

	private object _0023_003DzmIyULriwSoml9r_uGJY4WsO0Np2POnFN1w_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		switch (_0023_003DqwN1pp3xYYa9UUayAUmDw5pLGqHlOup7RDdya3kcSbX8_003D._0023_003DzMIF9ZfBAbMXRWTSvy6uRdXaSRopX(_0023_003DziDLVpbY_003D))
		{
		case 16777216:
		case 33554432:
		case 452984832:
			return this.m__0023_003DzshZYG54_003D.ModuleHandle.ResolveTypeHandle(_0023_003DziDLVpbY_003D);
		case 67108864:
			return this.m__0023_003DzshZYG54_003D.ModuleHandle.ResolveFieldHandle(_0023_003DziDLVpbY_003D);
		case 100663296:
		case 721420288:
			return this.m__0023_003DzshZYG54_003D.ModuleHandle.ResolveMethodHandle(_0023_003DziDLVpbY_003D);
		case 167772160:
			try
			{
				return this.m__0023_003DzshZYG54_003D.ModuleHandle.ResolveFieldHandle(_0023_003DziDLVpbY_003D);
			}
			catch
			{
				try
				{
					return this.m__0023_003DzshZYG54_003D.ModuleHandle.ResolveMethodHandle(_0023_003DziDLVpbY_003D);
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

	private static void _0023_003DzHrd5ARBeR3PXJt_UgQdW_0024bpygPX6(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzIkM3CaSWupD4_0024gmIh5V76vLJzMAa(3);
	}

	private object _0023_003DzFi4th1xnYhbT_0024NKYB49Fc6YljtjReZ6rjh3NuvNysiD3(Stream _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, object[] _0023_003DzAvn2b38_003D, Type[] _0023_003DzR58imxw_003D, Type[] _0023_003DzmQTFaQA_003D, object[] _0023_003DzWYPqg2E_003D)
	{
		this.m__0023_003DzEWLeis8_003D = _0023_003DziDLVpbY_003D;
		_0023_003DzcLVNAa8W3VqN1PrfdtyYkIx7DwC5(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, null);
		return _0023_003Dzzo2beSOiRhkSPKWQjtSuTaysq4HG48olaRV1zc8CBAkO(_0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D, _0023_003DzWYPqg2E_003D);
	}

	private void _0023_003Dz5qKhdgkaNPCdh71MH4BA2EhHZKb_(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (!_0023_003DziDLVpbY_003D) ? ((uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()) : checked((uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), 
			13 => (!_0023_003DziDLVpbY_003D) ? ((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ() : ((long)checked((ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ())), 
			19 => (long)((!_0023_003DziDLVpbY_003D) ? Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()) : Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => (long)((!_0023_003DziDLVpbY_003D) ? ((ulong)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()) : checked((ulong)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D())), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((long)checked((ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()))) : ((!_0023_003DziDLVpbY_003D) ? ((uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())), 
			20 => (long)((UIntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((ulong)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()) : ((ulong)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D())) : ((!_0023_003DziDLVpbY_003D) ? ((uint)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()) : ((uint)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()))), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private void _0023_003Dzn4biIlk8_0024QePVyQjAQYYX5s_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2 = (_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DziDLVpbY_003D;
		MethodBase methodBase = _0023_003Dz5klJqsiptGm9YKdXHrk8dAsl7JNCU_0024FEVw_003D_003D(_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D2._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D());
		if (_0023_003DzBJFJHwk_003D != null)
		{
			ParameterInfo[] parameters = methodBase.GetParameters();
			Type[] array = new Type[parameters.Length];
			int num = 0;
			ParameterInfo[] array2 = parameters;
			foreach (ParameterInfo parameterInfo in array2)
			{
				array[num++] = parameterInfo.ParameterType;
			}
			MethodInfo method = _0023_003DzBJFJHwk_003D.GetMethod(methodBase.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array, null);
			if (method != null)
			{
				methodBase = method;
			}
			_0023_003DzBJFJHwk_003D = null;
		}
		_0023_003DzRV6qj2VK8lvFF9bhLcko27s_003D(methodBase, _0023_003Dz5rQzobg_003D: true);
	}

	private static void _0023_003Dztt7PqGWRgxdj8ZI8ugnABoUmgR9PDf4TUFhDcSU_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzsFXvHzaYgcDmOt8flQZ9JbA_003D(_0023_003DziDLVpbY_003D: true);
	}

	private static void _0023_003DzaMmGzCfEtOEuOAf5il1LEMypDR3W9Tu_aMzGDQM_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz0LZ3a2KNB2rgSf490RJHmy0_003D(0);
	}

	private static void _0023_003Dzld0BdbQICPuFdff7vTKxz2kWMnr4_0024MQ2kSKjNDYNj1ic(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		object obj = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		long num = _0023_003DziDLVpbY_003D._0023_003DzV6bSD877zbj9qUx5Bahukd0yWYkt();
		Array array = (Array)_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D()._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(long))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(long));
			((long[])array)[num] = (long)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType == typeof(ulong))
		{
			_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3 = _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D._0023_003DzAh0xPa8xrkjhbQNscktTN9GSdTGxts7FjAbgriA_003D(obj, typeof(ulong));
			((ulong[])array)[num] = (ulong)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D3._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D();
		}
		else if (elementType.IsEnum)
		{
			_0023_003DziDLVpbY_003D._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(elementType, obj, num, array);
		}
		else
		{
			_0023_003DziDLVpbY_003D._0023_003DzBG3dNwCwdbjEjceZa2r0CNNFLATm(typeof(long), obj, num, array);
		}
	}

	private static void _0023_003DzDwjATMdYRoScyBEy_Ayp35xQSH7OeVpw3A_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzYoHr_kaBP_0024C0cQWQednER91YDBHg();
	}

	private void _0023_003DzB_0024y0GUDRjw6r5v7Rng_003D_003D(bool _0023_003DziDLVpbY_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (!_0023_003DziDLVpbY_003D) ? ((byte)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()) : checked((byte)(uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D()), 
			13 => (!_0023_003DziDLVpbY_003D) ? ((byte)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()) : checked((byte)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ()), 
			19 => (!_0023_003DziDLVpbY_003D) ? ((byte)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())) : checked((byte)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D())), 
			8 => (!_0023_003DziDLVpbY_003D) ? ((byte)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()) : checked((byte)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D()), 
			0 => (IntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((byte)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((byte)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())) : ((!_0023_003DziDLVpbY_003D) ? ((byte)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : checked((byte)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee())), 
			20 => (UIntPtr.Size != 4) ? ((!_0023_003DziDLVpbY_003D) ? ((byte)(ulong)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()) : checked((byte)(ulong)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D())) : ((!_0023_003DziDLVpbY_003D) ? ((byte)(uint)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D()) : checked((byte)(uint)((_0023_003DqVLE856NmzWhU_bIXHFUSoJCvrYu5AF1vrriB4qJVNEo_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzgJOG593aGSpHebIGWegFyKs_0024IufTVI4KFQ_003D_003D())), 
			_ => throw new InvalidOperationException(), 
		}));
	}

	private static void _0023_003Dz_tQNtU8fXyXAv2DS57m_EfZ44HfNgIfe_yzbzy81d9rY(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		_0023_003DziDLVpbY_003D._0023_003DzmbqFEfwwI9n6EkPK10ZwQM36n0wi(new _0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D(checked(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D() switch
		{
			1 => (short)(uint)((_0023_003Dqsmubij7ChYiT4WDyM7yBv_A3QUxf79sVi3X2JT1fxP8_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzXs2EfQw03B54Qhqhr5zRJ3Z092cYZdp_0A_003D_003D(), 
			13 => (short)(ulong)((_0023_003DqrA0ptSs_0024QWgFwZFHCgmtqmssL3JeElBya9CLuo_0024STDE_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzsQVx5C4XP0LGmjaN69FBwD4ndcqxDb4A_0024y_3Vegc7moJ(), 
			19 => (short)Convert.ToUInt64(((_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024oRaDSxP2IKexrx2DzcT9Dc_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzr4QYmZ0mLfiITGEJHMhC91c_003D()), 
			8 => (short)((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyb0UzWmOOf9310yb_0024TYWa6Y_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003Dzbt874PTP_0rbmZ_0024uc42BGDXEyQ5yxJNB9w_003D_003D(), 
			0 => (IntPtr.Size != 4) ? ((short)(ulong)(long)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()) : ((short)(uint)(int)((_0023_003DqG2j0vYyDwMuB3UfmWnsmaa51veIZ27KsQxyPI9OXY_00240_003D)_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2)._0023_003DzSAXUC0_y4Sk0nWYXk4qSh9gmw_ee()), 
			_ => throw new InvalidOperationException(), 
		})));
	}

	private static void _0023_003DzWFcUUzLfZiokMy37pmU1pDgRMf023uPPJV_0024sxrqSCPGQ(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2 = _0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D();
		if (_0023_003Dz8wovo1mlTaoN1g0g3IAMk1d7cQeEIOfYr3TuVio_003D(_0023_003DziDLVpbY_003D._0023_003Dz5xUe2Dy9XUTbqzKVYg_003D_003D(), _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D2))
		{
			uint num = ((_0023_003DqWVl3k9o_0024NafWYkhLm3BXULEgVCwfv8IcQAfGS6YbBtc_003D)_0023_003Dz5rQzobg_003D)._0023_003DzqEbYwBL30XGbvfzNf3edxFd_2wbtvIHP6A_003D_003D();
			_0023_003DziDLVpbY_003D._0023_003DzgU1iidhOrQl5W2VgDiQJ1IQ_003D(num);
		}
	}

	private void _0023_003DzF92XqHWM0mt_1xTngiTEH1HG1JGphapjovJeugQ_003D(_0023_003Dz437_00244ak_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003DziP9fFuA_003D = _0023_003DziDLVpbY_003D._0023_003Dz5rQzobg_003D;
		_0023_003DzGcl_0024E9o_003D = _0023_003DziDLVpbY_003D._0023_003DzR58imxw_003D;
	}

	private static bool _0023_003DzYRKsYteRnSlUXNbsiimfrW1GD7a_pPG2CAzCK1A_003D()
	{
		return false;
	}

	private static bool _0023_003DzstEuFBwD_0024cVisuRapmnIEdhjv2Amxc5ybBPAFde2I_0024CD(MethodBase _0023_003DziDLVpbY_003D)
	{
		ParameterInfo[] parameters = _0023_003DziDLVpbY_003D.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			if (parameters[i].ParameterType.IsByRef)
			{
				return true;
			}
		}
		return false;
	}

	private static void _0023_003DzSJud1Vl8rtV82P_0024GjH_0024laS2SLK1j(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz5qKhdgkaNPCdh71MH4BA2EhHZKb_(_0023_003DziDLVpbY_003D: false);
	}

	private static void _0023_003DzCUzhyPdi1g5Vux_ZTx8Spt4_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzUdSq5SxOaS_0024fEtfG6w_003D_003D(7);
	}

	private static void _0023_003Dzy_00245S2xDXClyd5x4_8VJCx_0024J3AXmE_0024jJ5Bg_003D_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003Dz_zeDwWgrLqWqj6ECFFPZ7JQ_003D(((_0023_003Dqw7szHSw6WLraHNWp8IxpCA_Nf2JPcWzDTGbT55gOrHU_003D)_0023_003Dz5rQzobg_003D)._0023_003DzgpS1K1MBEpvciTK82A_003D_003D());
	}

	private static void _0023_003DzeO74HApp_GQL8vpJZ3E3ot8UtDqt3tUi5pf1utA_003D(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003DziDLVpbY_003D, _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5rQzobg_003D)
	{
		_0023_003DziDLVpbY_003D._0023_003DzY_Qho9G6NDOFx1ZRp_0024YDMpUtokq6aO_Vaw_003D_003D(_0023_003DziDLVpbY_003D: false);
	}

	[Conditional("DEBUG")]
	private void _0023_003DzWZYaKXu5IeeudfRvJKGz40Q_0024AN8O(object _0023_003DziDLVpbY_003D)
	{
	}

	private static bool _0023_003Dz8a7SqHy53Zb1B_LJHMe3m40_003D(uint _0023_003DziDLVpbY_003D, uint _0023_003Dz5rQzobg_003D, uint _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D >= _0023_003Dz5rQzobg_003D)
		{
			return _0023_003DziDLVpbY_003D <= _0023_003Dz5rQzobg_003D + _0023_003DzAvn2b38_003D;
		}
		return false;
	}
}

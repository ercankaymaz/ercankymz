using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using devDept;
using devDept.Diagnostic;
using devDept.Eyeshot;

internal static class _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<MethodInfo, bool> _0023_003Dz7_WZ05dEvqdpEzItLA_003D_003D;

		internal bool _0023_003Dz6P8gi34iwz0bjhtLtC6kv5A_003D(MethodInfo _0023_003DzkKfJheA_003D)
		{
			return _0023_003DzkKfJheA_003D.GetCustomAttributes(typeof(AmbientValueAttribute), inherit: false).Length != 0;
		}
	}

	private sealed class _0023_003DzASH8VPAkWEc_0024rIgDdg_003D_003D
	{
		public int _0023_003Dz1nM6iEg_DwX4;

		internal bool _0023_003DzId9Rus0eE9a5lMA7jA_003D_003D(MethodInfo _0023_003DzkKfJheA_003D)
		{
			return _0023_003DzkKfJheA_003D.GetParameters().Length == _0023_003Dz1nM6iEg_DwX4;
		}
	}

	internal enum _0023_003DzkhmDvZM_003D : byte
	{
		None,
		Blink,
		Designer,
		VSExtension,
		Authentication
	}

	private static readonly bool _0023_003Dzu1ZiwNYXolXq = true;

	private static readonly bool _0023_003DzAFVCgxucKnEv = false;

	private static object _0023_003Dzt6Wj1dI_003D;

	private static MethodInfo _0023_003DzTqGw5iejs3rS;

	private static MethodInfo _0023_003Dz_00242P0_0024stprwB3;

	private static MethodInfo _0023_003Dz5UigGuVRjrAL;

	private static bool? _0023_003DzDfrg__bm6qa7 = null;

	private static MethodInfo _0023_003Dz3_wdZBr5iPYO;

	private static bool? _0023_003DzHJeVp8azP08QKlAL5w_003D_003D = null;

	internal static bool _0023_003DzZ4RB3Lo_003D()
	{
		return _0023_003Dzu1ZiwNYXolXq;
	}

	internal static bool _0023_003DzIbv67eg_003D()
	{
		return _0023_003DzAFVCgxucKnEv;
	}

	private static MethodInfo _0023_003DzUKtL_V1SpksY(int _0023_003Dz1nM6iEg_DwX4)
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { _0023_003Dz1nM6iEg_DwX4 };
		return (MethodInfo)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "W;Z_qq\"ab_", _0023_003DzAvn2b38_003D);
	}

	internal static double[] _0023_003Dz8wQHGmwdU7v6()
	{
		return (double[])_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "3;rjVq\"abf", null);
	}

	internal static bool _0023_003DzGvwLaHyYAeYU(bool _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D, out bool _0023_003DzXIeyF7xwEI7t)
	{
		object[] array = new object[2] { _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D, _0023_003DzXIeyF7xwEI7t };
		_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
		Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
		try
		{
			return (bool)_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DziDLVpbY_003D, "rVc`qq\"abc", array);
		}
		finally
		{
			_0023_003DzXIeyF7xwEI7t = (bool)array[1];
		}
	}

	internal static bool[] _0023_003Dz5iI0kEzvBIvT()
	{
		return (bool[])_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), ">lF[%q\"abY", null);
	}

	internal static void _0023_003DzyY8Z8s7b_0024iLr(byte _0023_003DzQ8YZULhVjvRB, object _0023_003Dzb7SPTpc_003D, bool _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[3] { _0023_003DzQ8YZULhVjvRB, _0023_003Dzb7SPTpc_003D, _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "h#76Pq\"ab^", _0023_003DzAvn2b38_003D);
	}

	internal static void _0023_003DzyY8Z8s7b_0024iLr(bool _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "i;NZTq\"ab[", _0023_003DzAvn2b38_003D);
	}

	internal static void _0023_003DzIAQgbGwrH0Tf(_0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { _0023_003DzkhmDvZM_003D };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "?iC!(q\"abP", _0023_003DzAvn2b38_003D);
	}

	internal static void _0023_003DzCBXaK_002496NUpX(byte _0023_003DzHBMcsnabCilx, object _0023_003Dzb7SPTpc_003D)
	{
		if (!_0023_003DzCBXaK_002496NUpX(_0023_003DzHBMcsnabCilx))
		{
			NotAvailableException ex = new NotAvailableException();
			if ((bool)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "dJa(Eq\"abl", null))
			{
				Logger.Instance.Error(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666188), ex.Message, _0023_003Dzb7SPTpc_003D.GetType().Name, devDept.LicenseManager.ProductEdition), null, Array.Empty<object>());
			}
			throw ex;
		}
	}

	private static bool _0023_003DzCBXaK_002496NUpX(byte _0023_003DzHBMcsnabCilx)
	{
		if (devDept.LicenseManager.ProductEdition == licenseType.Pro && !Logger.Instance.stack.IsEmpty)
		{
			return true;
		}
		licenseType licenseType2 = (licenseType)_0023_003DzHBMcsnabCilx;
		if (licenseType2 != licenseType.None && (int)devDept.LicenseManager.ProductEdition > 1 && (int)devDept.LicenseManager.ProductEdition < (int)licenseType2)
		{
			return false;
		}
		return true;
	}

	internal static bool _0023_003DzwAfFvoy42C6h()
	{
		return _0023_003DzCBXaK_002496NUpX(3);
	}

	internal static bool _0023_003Dzl7IGqOacee9Y()
	{
		return _0023_003DzCBXaK_002496NUpX(4);
	}
}

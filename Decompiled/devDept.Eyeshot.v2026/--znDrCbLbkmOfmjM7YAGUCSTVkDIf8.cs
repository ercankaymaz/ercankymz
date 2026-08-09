using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

internal static class _0023_003DznDrCbLbkmOfmjM7YAGUCSTVkDIf8
{
	internal static _0023_003DzErN3qAnXEgfhBMq3zg_003D_003D _0023_003DzE35Rc7j6x7zc(string _0023_003DzLn_N5AY_003D, out bool _0023_003DzVsfGJKJPF4WZg9zSLw_003D_003D)
	{
		object[] array = new object[2] { _0023_003DzLn_N5AY_003D, _0023_003DzVsfGJKJPF4WZg9zSLw_003D_003D };
		_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
		Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
		try
		{
			return (_0023_003DzErN3qAnXEgfhBMq3zg_003D_003D)_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DziDLVpbY_003D, "L].5Pq\"acS", array);
		}
		finally
		{
			_0023_003DzVsfGJKJPF4WZg9zSLw_003D_003D = (bool)array[1];
		}
	}

	internal static string _0023_003DzGk_IP20_003D(string _0023_003Dzg5oC_Hs_003D, string _0023_003DzGGUd1aw_003D, string _0023_003Dz4hRmMs4_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[3] { _0023_003Dzg5oC_Hs_003D, _0023_003DzGGUd1aw_003D, _0023_003Dz4hRmMs4_003D };
		return (string)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "4T59Zq\"acM", _0023_003DzAvn2b38_003D);
	}

	internal static void _0023_003DzJ70BiKY_003D(string _0023_003Dz8cXTCxg7nkw8wAnhLg_003D_003D, string _0023_003Dzg5oC_Hs_003D, string _0023_003DzGGUd1aw_003D, string _0023_003Dz4hRmMs4_003D)
	{
		using Aes aes = Aes.Create();
		aes.Key = Encoding.UTF8.GetBytes(_0023_003DzGGUd1aw_003D);
		aes.IV = Encoding.UTF8.GetBytes(_0023_003Dz4hRmMs4_003D);
		ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			try
			{
				StreamWriter streamWriter = new StreamWriter(cryptoStream);
				try
				{
					streamWriter.Write(_0023_003Dz8cXTCxg7nkw8wAnhLg_003D_003D);
				}
				finally
				{
					((IDisposable)streamWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)cryptoStream).Dispose();
			}
			_0023_003Dz_aiWmhxMnXuNnGauTQ_003D_003D._0023_003DzQyR_E4w_003D(Convert.ToBase64String(memoryStream.ToArray()), _0023_003Dzg5oC_Hs_003D);
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	private static bool _0023_003DzdwQVnP7V7HPQ(_0023_003DzErN3qAnXEgfhBMq3zg_003D_003D _0023_003DzELu0Pss_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { _0023_003DzELu0Pss_003D };
		return (bool)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "1B%4Pq\"acK", _0023_003DzAvn2b38_003D);
	}

	private static string _0023_003DzFCEfrUu_UHH3(_0023_003DzErN3qAnXEgfhBMq3zg_003D_003D _0023_003DzELu0Pss_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { _0023_003DzELu0Pss_003D };
		return (string)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "qYgEnq\"acP", _0023_003DzAvn2b38_003D);
	}
}

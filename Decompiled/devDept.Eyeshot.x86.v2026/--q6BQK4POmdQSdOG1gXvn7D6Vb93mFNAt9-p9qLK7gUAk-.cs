using System;
using System.IO;

internal static class _0023_003Dq6BQK4POmdQSdOG1gXvn7D6Vb93mFNAt9_0024p9qLK7gUAk_003D
{
	private static readonly uint[] _0023_003Dzq80RbjQ_003D = new uint[5] { 52200625u, 614125u, 7225u, 85u, 1u };

	public static byte[] _0023_003DzprwMdmBa0BaHEW4z1w_003D_003D(string _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new Exception();
		}
		MemoryStream memoryStream = new MemoryStream(_0023_003Dzq80RbjQ_003D.Length * 4 / 5);
		try
		{
			int num = 0;
			uint num2 = 0u;
			foreach (char c in _0023_003Dzq80RbjQ_003D)
			{
				if (c == 'z' && num == 0)
				{
					_0023_003Dz_f9geF0BBg_GPPLpLa7k8Rg_003D(memoryStream, num2, 0);
					continue;
				}
				if (c < '!' || c > 'u')
				{
					throw new Exception();
				}
				num2 = checked(num2 + (uint)(_0023_003Dq6BQK4POmdQSdOG1gXvn7D6Vb93mFNAt9_0024p9qLK7gUAk_003D._0023_003Dzq80RbjQ_003D[num] * (c - 33)));
				num++;
				if (num == 5)
				{
					_0023_003Dz_f9geF0BBg_GPPLpLa7k8Rg_003D(memoryStream, num2, 0);
					num = 0;
					num2 = 0u;
				}
			}
			if (num == 1)
			{
				throw new Exception();
			}
			if (num > 1)
			{
				for (int j = num; j < 5; j++)
				{
					num2 = checked(num2 + 84 * _0023_003Dq6BQK4POmdQSdOG1gXvn7D6Vb93mFNAt9_0024p9qLK7gUAk_003D._0023_003Dzq80RbjQ_003D[j]);
				}
				_0023_003Dz_f9geF0BBg_GPPLpLa7k8Rg_003D(memoryStream, num2, 5 - num);
			}
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	private static void _0023_003Dz_f9geF0BBg_GPPLpLa7k8Rg_003D(Stream _0023_003Dzq80RbjQ_003D, uint _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		_0023_003Dzq80RbjQ_003D.WriteByte((byte)(_0023_003DzZzVr6_0024U_003D >> 24));
		if (_0023_003Dz7hRN5Rg_003D == 3)
		{
			return;
		}
		_0023_003Dzq80RbjQ_003D.WriteByte((byte)(_0023_003DzZzVr6_0024U_003D >> 16));
		if (_0023_003Dz7hRN5Rg_003D != 2)
		{
			_0023_003Dzq80RbjQ_003D.WriteByte((byte)(_0023_003DzZzVr6_0024U_003D >> 8));
			if (_0023_003Dz7hRN5Rg_003D != 1)
			{
				_0023_003Dzq80RbjQ_003D.WriteByte((byte)_0023_003DzZzVr6_0024U_003D);
			}
		}
	}
}

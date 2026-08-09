using System;
using System.IO;

internal static class _0023_003DqIYwamc_0024xa95DzIZnwgV16Lyh8iyjmi9784OD6dak2K8_003D
{
	private static readonly uint[] _0023_003DzjYYAPCA_003D = new uint[5] { 52200625u, 614125u, 7225u, 85u, 1u };

	public static byte[] _0023_003Dz6dmlLrJD68iF9tnasOknGLgoRxGdEKVd799S12E_003D(string _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new Exception();
		}
		MemoryStream memoryStream = new MemoryStream(_0023_003DzjYYAPCA_003D.Length * 4 / 5);
		try
		{
			int num = 0;
			uint num2 = 0u;
			foreach (char c in _0023_003DzjYYAPCA_003D)
			{
				if (c == 'z' && num == 0)
				{
					_0023_003DzPsHm_FuC9KPW8HI1CEiZFWs_003D(memoryStream, num2, 0);
					continue;
				}
				if (c < '!' || c > 'u')
				{
					throw new Exception();
				}
				num2 = checked(num2 + (uint)(_0023_003DqIYwamc_0024xa95DzIZnwgV16Lyh8iyjmi9784OD6dak2K8_003D._0023_003DzjYYAPCA_003D[num] * (c - 33)));
				num++;
				if (num == 5)
				{
					_0023_003DzPsHm_FuC9KPW8HI1CEiZFWs_003D(memoryStream, num2, 0);
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
					num2 = checked(num2 + 84 * _0023_003DqIYwamc_0024xa95DzIZnwgV16Lyh8iyjmi9784OD6dak2K8_003D._0023_003DzjYYAPCA_003D[j]);
				}
				_0023_003DzPsHm_FuC9KPW8HI1CEiZFWs_003D(memoryStream, num2, 5 - num);
			}
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	private static void _0023_003DzPsHm_FuC9KPW8HI1CEiZFWs_003D(Stream _0023_003DzjYYAPCA_003D, uint _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		_0023_003DzjYYAPCA_003D.WriteByte((byte)(_0023_003DzVC9FBdo_003D >> 24));
		if (_0023_003DzwBouG0w_003D == 3)
		{
			return;
		}
		_0023_003DzjYYAPCA_003D.WriteByte((byte)(_0023_003DzVC9FBdo_003D >> 16));
		if (_0023_003DzwBouG0w_003D != 2)
		{
			_0023_003DzjYYAPCA_003D.WriteByte((byte)(_0023_003DzVC9FBdo_003D >> 8));
			if (_0023_003DzwBouG0w_003D != 1)
			{
				_0023_003DzjYYAPCA_003D.WriteByte((byte)_0023_003DzVC9FBdo_003D);
			}
		}
	}
}

using System;
using System.Drawing;
using System.IO;
using devDept.Geometry;

internal sealed class _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D
{
	public static Image _0023_003DzHqA41XsvbPrvw10xf4xdAeg_003D(string _0023_003Dzi_0024GqBs8_003D)
	{
		if (Utility.IsUnsupportedFormat(_0023_003Dzi_0024GqBs8_003D))
		{
			return null;
		}
		Bitmap bitmap = new Bitmap(_0023_003Dzi_0024GqBs8_003D);
		try
		{
			return new Bitmap(bitmap);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
	}

	public static byte[] _0023_003DzaVgi1iC1WyuS(Image _0023_003DzWMzhDlA_003D)
	{
		if (_0023_003DzWMzhDlA_003D != null)
		{
			return (byte[])new ImageConverter().ConvertTo(_0023_003DzWMzhDlA_003D, typeof(byte[]));
		}
		return null;
	}

	public static Bitmap _0023_003Dzgx309QbPrd02(byte[] _0023_003DzbONi0CI_003D)
	{
		if (_0023_003DzbONi0CI_003D == null)
		{
			return null;
		}
		return new Bitmap(new MemoryStream(_0023_003DzbONi0CI_003D));
	}
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace devDept.Geometry;

public class LockBitmap
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Bitmap _0023_003Dzy78_0024Z10_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IntPtr _0023_003DzeO15QW4d3izR = IntPtr.Zero;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BitmapData _0023_003DzV0dC6To_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzRE2tM90URMYZxvNl2Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzTQSgdWFsrI_dCVWbfw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzRAH3IbiWW3MyKWPbqQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzwR3Bph0knP45pTU5Cw_003D_003D;

	public byte[] Pixels
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRE2tM90URMYZxvNl2Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzRE2tM90URMYZxvNl2Q_003D_003D = value;
		}
	}

	public int Depth
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTQSgdWFsrI_dCVWbfw_003D_003D;
		}
	}

	public int Width
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRAH3IbiWW3MyKWPbqQ_003D_003D;
		}
	}

	public int Height
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzwR3Bph0knP45pTU5Cw_003D_003D;
		}
	}

	public LockBitmap(Bitmap source)
	{
		_0023_003Dzy78_0024Z10_003D = source;
	}

	private void _0023_003DzkqwpbpQJxotX(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzTQSgdWFsrI_dCVWbfw_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dz6hi5XBwx6UEG(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzRAH3IbiWW3MyKWPbqQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dz5PfPifm15qTy(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzwR3Bph0knP45pTU5Cw_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	public void LockBits()
	{
		try
		{
			_0023_003Dz6hi5XBwx6UEG(_0023_003Dzy78_0024Z10_003D.Width);
			_0023_003Dz5PfPifm15qTy(_0023_003Dzy78_0024Z10_003D.Height);
			int num = Width * Height;
			Rectangle rect = new Rectangle(0, 0, Width, Height);
			_0023_003DzkqwpbpQJxotX(Image.GetPixelFormatSize(_0023_003Dzy78_0024Z10_003D.PixelFormat));
			if (Depth != 8 && Depth != 24 && Depth != 32)
			{
				throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601549));
			}
			_0023_003DzV0dC6To_003D = _0023_003Dzy78_0024Z10_003D.LockBits(rect, ImageLockMode.ReadWrite, _0023_003Dzy78_0024Z10_003D.PixelFormat);
			int num2 = Depth / 8;
			Pixels = new byte[num * num2];
			_0023_003DzeO15QW4d3izR = _0023_003DzV0dC6To_003D.Scan0;
			Marshal.Copy(_0023_003DzeO15QW4d3izR, Pixels, 0, Pixels.Length);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public void UnlockBits()
	{
		try
		{
			Marshal.Copy(Pixels, 0, _0023_003DzeO15QW4d3izR, Pixels.Length);
			_0023_003Dzy78_0024Z10_003D.UnlockBits(_0023_003DzV0dC6To_003D);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public Color GetPixel(int x, int y)
	{
		Color result = Color.Empty;
		int num = Depth / 8;
		int num2 = (y * Width + x) * num;
		if (num2 > Pixels.Length - num)
		{
			throw new IndexOutOfRangeException();
		}
		switch (Depth)
		{
		case 32:
		{
			byte blue = Pixels[num2];
			byte green = Pixels[num2 + 1];
			byte red = Pixels[num2 + 2];
			result = Color.FromArgb(Pixels[num2 + 3], red, green, blue);
			break;
		}
		case 24:
		{
			byte blue = Pixels[num2];
			byte green = Pixels[num2 + 1];
			byte red = Pixels[num2 + 2];
			result = Color.FromArgb(red, green, blue);
			break;
		}
		case 8:
		{
			byte b = Pixels[num2];
			result = Color.FromArgb(b, b, b);
			break;
		}
		}
		return result;
	}

	public void SetPixel(int x, int y, Color color)
	{
		int num = Depth / 8;
		int num2 = (y * Width + x) * num;
		switch (Depth)
		{
		case 32:
			Pixels[num2] = color.B;
			Pixels[num2 + 1] = color.G;
			Pixels[num2 + 2] = color.R;
			Pixels[num2 + 3] = color.A;
			break;
		case 24:
			Pixels[num2] = color.B;
			Pixels[num2 + 1] = color.G;
			Pixels[num2 + 2] = color.R;
			break;
		case 8:
			Pixels[num2] = color.B;
			break;
		}
	}
}

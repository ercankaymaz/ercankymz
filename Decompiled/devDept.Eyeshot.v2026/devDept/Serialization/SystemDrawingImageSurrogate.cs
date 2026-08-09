using System;
using System.Drawing;
using System.IO;

namespace devDept.Serialization;

internal class SystemDrawingImageSurrogate
{
	public byte[] Data;

	public SystemDrawingImageSurrogate(byte[] data)
	{
		Data = data;
	}

	public static implicit operator Image(SystemDrawingImageSurrogate surrogate)
	{
		if (surrogate == null || surrogate.Data == null)
		{
			return null;
		}
		if (_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzZ4RB3Lo_003D())
		{
			return new Bitmap(new MemoryStream(surrogate.Data));
		}
		throw new PlatformNotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672605));
	}

	public static implicit operator SystemDrawingImageSurrogate(Image source)
	{
		if (source == null)
		{
			return null;
		}
		if (_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzZ4RB3Lo_003D())
		{
			return new SystemDrawingImageSurrogate((byte[])new ImageConverter().ConvertTo(source, typeof(byte[])));
		}
		throw new PlatformNotSupportedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672605));
	}
}

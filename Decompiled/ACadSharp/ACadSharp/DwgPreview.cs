using System;
using System.IO;
using CSUtilities.IO;

namespace ACadSharp;

public class DwgPreview
{
	public enum PreviewType
	{
		Unknown = 0,
		Bmp = 2,
		Wmf = 3,
		Png = 6
	}

	public PreviewType Code { get; }

	public byte[] RawHeader { get; }

	public byte[] RawImage { get; }

	public DwgPreview()
	{
		Code = PreviewType.Unknown;
		RawHeader = new byte[0];
		RawImage = new byte[0];
	}

	public DwgPreview(PreviewType code, byte[] rawHeader, byte[] rawImage)
	{
		Code = code;
		RawHeader = rawHeader;
		RawImage = rawImage;
	}

	public void Save(string path)
	{
		switch (Code)
		{
		case PreviewType.Bmp:
		case PreviewType.Wmf:
		case PreviewType.Png:
		{
			bool flag = false;
			using StreamIO streamIO = new StreamIO(path, FileMode.Create, FileAccess.ReadWrite);
			if (flag)
			{
				streamIO.WriteBytes(RawHeader);
			}
			streamIO.WriteBytes(RawImage);
			break;
		}
		default:
			throw new NotSupportedException($"Preview with code {Code} not supported.");
		}
	}
}

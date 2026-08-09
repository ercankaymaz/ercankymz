using System.IO;
using PdfSharp.SharpZipLib.Zip.Compression;
using PdfSharp.SharpZipLib.Zip.Compression.Streams;

namespace PdfSharp.Pdf.Filters;

public class FlateDecode : Filter
{
	public override byte[] Encode(byte[] data)
	{
		return Encode(data, PdfFlateEncodeMode.Default);
	}

	public byte[] Encode(byte[] data, PdfFlateEncodeMode mode)
	{
		MemoryStream memoryStream = new MemoryStream();
		int level = -1;
		switch (mode)
		{
		case PdfFlateEncodeMode.BestCompression:
			level = 9;
			break;
		case PdfFlateEncodeMode.BestSpeed:
			level = 1;
			break;
		}
		DeflaterOutputStream deflaterOutputStream = new DeflaterOutputStream(memoryStream, new Deflater(level, noZlibHeaderOrFooter: false));
		deflaterOutputStream.Write(data, 0, data.Length);
		deflaterOutputStream.Finish();
		memoryStream.Capacity = (int)memoryStream.Length;
		return memoryStream.GetBuffer();
	}

	public override byte[] Decode(byte[] data, FilterParms parms)
	{
		MemoryStream baseInputStream = new MemoryStream(data);
		MemoryStream memoryStream = new MemoryStream();
		InflaterInputStream inflaterInputStream = new InflaterInputStream(baseInputStream, new Inflater(noHeader: false));
		byte[] array = new byte[32768];
		int num;
		do
		{
			num = inflaterInputStream.Read(array, 0, array.Length);
			if (num > 0)
			{
				memoryStream.Write(array, 0, num);
			}
		}
		while (num > 0);
		inflaterInputStream.Close();
		memoryStream.Flush();
		if (memoryStream.Length >= 0)
		{
			memoryStream.Capacity = (int)memoryStream.Length;
			return memoryStream.GetBuffer();
		}
		return null;
	}
}

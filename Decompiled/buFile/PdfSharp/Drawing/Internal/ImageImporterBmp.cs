using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal;

internal class ImageImporterBmp : ImageImporterRoot, IImageImporter
{
	public ImportedImage ImportImage(StreamReaderHelper stream, PdfDocument document)
	{
		try
		{
			stream.CurrentOffset = 0;
			if (TestBitmapFileHeader(stream, out var offset))
			{
				ImagePrivateDataBitmap data = new ImagePrivateDataBitmap(stream.Data, stream.Length);
				ImportedImage importedImage = new ImportedImageBitmap(this, data, document);
				if (TestBitmapInfoHeader(stream, importedImage, offset))
				{
					return importedImage;
				}
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	private bool TestBitmapFileHeader(StreamReaderHelper stream, out int offset)
	{
		offset = 0;
		if (stream.GetWord(0, bigEndian: true) == 16973)
		{
			int dWord = (int)stream.GetDWord(2, bigEndian: false);
			if (dWord < stream.Length)
			{
				return false;
			}
			offset = (int)stream.GetDWord(10, bigEndian: false);
			stream.CurrentOffset += 14;
			return true;
		}
		return false;
	}

	private bool TestBitmapInfoHeader(StreamReaderHelper stream, ImportedImage ii, int offset)
	{
		int dWord = (int)stream.GetDWord(0, bigEndian: false);
		if (dWord == 40 || dWord == 108 || dWord == 124)
		{
			uint dWord2 = stream.GetDWord(4, bigEndian: false);
			int dWord3 = (int)stream.GetDWord(8, bigEndian: false);
			int word = stream.GetWord(12, bigEndian: false);
			int word2 = stream.GetWord(14, bigEndian: false);
			int dWord4 = (int)stream.GetDWord(16, bigEndian: false);
			int dWord5 = (int)stream.GetDWord(20, bigEndian: false);
			int dWord6 = (int)stream.GetDWord(24, bigEndian: false);
			int dWord7 = (int)stream.GetDWord(28, bigEndian: false);
			uint dWord8 = stream.GetDWord(32, bigEndian: false);
			uint dWord9 = stream.GetDWord(36, bigEndian: false);
			if (dWord5 != 0 && dWord5 + offset > stream.Length)
			{
				return false;
			}
			ImagePrivateDataBitmap imagePrivateDataBitmap = (ImagePrivateDataBitmap)ii.Data;
			if (dWord4 == 0 || dWord4 == 3)
			{
				((ImagePrivateDataBitmap)ii.Data).Offset = offset;
				((ImagePrivateDataBitmap)ii.Data).ColorPaletteOffset = stream.CurrentOffset + dWord;
				ii.Information.Width = dWord2;
				ii.Information.Height = (uint)Math.Abs(dWord3);
				ii.Information.HorizontalDPM = dWord6;
				ii.Information.VerticalDPM = dWord7;
				imagePrivateDataBitmap.FlippedImage = dWord3 < 0;
				if (word == 1 && word2 == 24)
				{
					ii.Information.ImageFormat = ImageInformation.ImageFormats.RGB24;
					return true;
				}
				if (word == 1 && word2 == 32)
				{
					ii.Information.ImageFormat = ((dWord4 == 0) ? ImageInformation.ImageFormats.RGB24 : ImageInformation.ImageFormats.ARGB32);
					return true;
				}
				if (word == 1 && word2 == 8)
				{
					ii.Information.ImageFormat = ImageInformation.ImageFormats.Palette8;
					ii.Information.ColorsUsed = dWord8;
					return true;
				}
				if (word == 1 && word2 == 4)
				{
					ii.Information.ImageFormat = ImageInformation.ImageFormats.Palette4;
					ii.Information.ColorsUsed = dWord8;
					return true;
				}
				if (word == 1 && word2 == 1)
				{
					ii.Information.ImageFormat = ImageInformation.ImageFormats.Palette1;
					ii.Information.ColorsUsed = dWord8;
					return true;
				}
			}
		}
		return false;
	}

	public ImageData PrepareImage(ImagePrivateData data)
	{
		throw new NotImplementedException();
	}
}

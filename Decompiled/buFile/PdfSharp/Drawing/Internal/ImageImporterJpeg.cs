using System;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal;

internal class ImageImporterJpeg : ImageImporterRoot, IImageImporter
{
	public ImportedImage ImportImage(StreamReaderHelper stream, PdfDocument document)
	{
		try
		{
			stream.CurrentOffset = 0;
			if (TestFileHeader(stream))
			{
				stream.CurrentOffset += 2;
				ImagePrivateDataDct data = new ImagePrivateDataDct(stream.Data, stream.Length);
				ImportedImage importedImage = new ImportedImageJpeg(this, data, document);
				if (TestJfifHeader(stream, importedImage))
				{
					bool flag = false;
					bool flag2 = false;
					while (MoveToNextHeader(stream))
					{
						if (TestColorFormatHeader(stream, importedImage))
						{
							flag = true;
						}
						else if (TestInfoHeader(stream, importedImage))
						{
							flag2 = true;
						}
					}
					if (flag && flag2)
					{
						return importedImage;
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	private bool TestFileHeader(StreamReaderHelper stream)
	{
		return stream.GetWord(0, bigEndian: true) == 65496;
	}

	private bool TestJfifHeader(StreamReaderHelper stream, ImportedImage ii)
	{
		if (stream.GetWord(0, bigEndian: true) == 65504 && stream.GetDWord(4, bigEndian: true) == 1246120262)
		{
			int word = stream.GetWord(2, bigEndian: true);
			if (word >= 16)
			{
				int word2 = stream.GetWord(9, bigEndian: true);
				int num = stream.GetByte(11);
				int word3 = stream.GetWord(12, bigEndian: true);
				int word4 = stream.GetWord(14, bigEndian: true);
				switch (num)
				{
				case 0:
					ii.Information.HorizontalAspectRatio = word3;
					ii.Information.VerticalAspectRatio = word4;
					break;
				case 1:
					ii.Information.HorizontalDPI = word3;
					ii.Information.VerticalDPI = word4;
					break;
				case 2:
					ii.Information.HorizontalDPM = word3 * 100;
					ii.Information.VerticalDPM = word4 * 100;
					break;
				}
				return true;
			}
		}
		return false;
	}

	private bool TestColorFormatHeader(StreamReaderHelper stream, ImportedImage ii)
	{
		if (stream.GetWord(0, bigEndian: true) == 65498)
		{
			int num = stream.GetByte(4);
			if (num < 1 || num > 4 || num == 2)
			{
				return false;
			}
			int word = stream.GetWord(2, bigEndian: true);
			if (word != 6 + 2 * num)
			{
				return false;
			}
			ii.Information.ImageFormat = num switch
			{
				1 => ImageInformation.ImageFormats.JPEGGRAY, 
				3 => ImageInformation.ImageFormats.JPEG, 
				_ => ImageInformation.ImageFormats.JPEGRGBW, 
			};
			return true;
		}
		return false;
	}

	private bool TestInfoHeader(StreamReaderHelper stream, ImportedImage ii)
	{
		int word = stream.GetWord(0, bigEndian: true);
		if ((word >= 65472 && word <= 65475) || (word >= 65481 && word <= 65483))
		{
			int word2 = stream.GetWord(5, bigEndian: true);
			int word3 = stream.GetWord(7, bigEndian: true);
			ii.Information.Width = (uint)word3;
			ii.Information.Height = (uint)word2;
			return true;
		}
		return false;
	}

	private bool MoveToNextHeader(StreamReaderHelper stream)
	{
		int word = stream.GetWord(2, bigEndian: true);
		int num = stream.GetByte(0);
		int num2 = stream.GetByte(1);
		if (num == 255)
		{
			if (num2 == 217)
			{
				return false;
			}
			if (num2 == 1 || (num2 >= 208 && num2 <= 215))
			{
				stream.CurrentOffset += 2;
				return true;
			}
			stream.CurrentOffset += 2 + word;
			return true;
		}
		return false;
	}

	public ImageData PrepareImage(ImagePrivateData data)
	{
		throw new NotImplementedException();
	}
}

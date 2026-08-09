using System;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Drawing.Internal;

internal class ImagePrivateDataBitmap : ImagePrivateData
{
	private readonly byte[] _data;

	private readonly int _length;

	internal bool FlippedImage;

	internal int Offset;

	internal int ColorPaletteOffset;

	public byte[] Data => _data;

	public int Length => _length;

	public ImagePrivateDataBitmap(byte[] data, int length)
	{
		_data = data;
		_length = length;
	}

	internal void CopyBitmap(ImageDataBitmap dest)
	{
		switch (base.Image.Information.ImageFormat)
		{
		case ImageInformation.ImageFormats.ARGB32:
			CopyTrueColorMemoryBitmap(3, 8, hasAlpha: true, dest);
			break;
		case ImageInformation.ImageFormats.RGB24:
			CopyTrueColorMemoryBitmap(4, 8, hasAlpha: false, dest);
			break;
		case ImageInformation.ImageFormats.Palette8:
			CopyIndexedMemoryBitmap(8, dest);
			break;
		case ImageInformation.ImageFormats.Palette4:
			CopyIndexedMemoryBitmap(4, dest);
			break;
		case ImageInformation.ImageFormats.Palette1:
			CopyIndexedMemoryBitmap(1, dest);
			break;
		default:
			throw new NotImplementedException();
		}
	}

	private void CopyTrueColorMemoryBitmap(int components, int bits, bool hasAlpha, ImageDataBitmap dest)
	{
		int width = (int)base.Image.Information.Width;
		int height = (int)base.Image.Information.Height;
		int num = components;
		if (components == 4)
		{
			num = 3;
		}
		byte[] array = new byte[components * width * height];
		bool flag = false;
		bool flag2 = false;
		byte[] array2 = (hasAlpha ? new byte[width * height] : null);
		MonochromeMask monochromeMask = (hasAlpha ? new MonochromeMask(width, height) : null);
		int offset = Offset;
		int num2 = 0;
		if (num == 3)
		{
			for (int i = 0; i < height; i++)
			{
				int num3 = 3 * (height - 1 - i) * width;
				int num4 = 0;
				if (hasAlpha)
				{
					monochromeMask.StartLine(i);
					num4 = (height - 1 - i) * width;
				}
				for (int j = 0; j < width; j++)
				{
					array[num3] = Data[offset + num2 + 2];
					array[num3 + 1] = Data[offset + num2 + 1];
					array[num3 + 2] = Data[offset + num2];
					if (hasAlpha)
					{
						monochromeMask.AddPel(Data[offset + num2 + 3]);
						array2[num4] = Data[offset + num2 + 3];
						if ((!flag || !flag2) && Data[offset + num2 + 3] != byte.MaxValue)
						{
							flag = true;
							if (Data[offset + num2 + 3] != 0)
							{
								flag2 = true;
							}
						}
						num4++;
					}
					num2 += (hasAlpha ? 4 : components);
					num3 += 3;
				}
				num2 = 4 * ((num2 + 3) / 4);
			}
		}
		else if (components == 1)
		{
			throw new NotImplementedException("Image format not supported (grayscales).");
		}
		dest.Data = array;
		dest.Length = array.Length;
		if (array2 != null)
		{
			dest.AlphaMask = array2;
			dest.AlphaMaskLength = array2.Length;
		}
		if (monochromeMask != null)
		{
			dest.BitmapMask = monochromeMask.MaskData;
			dest.BitmapMaskLength = monochromeMask.MaskData.Length;
		}
	}

	private void CopyIndexedMemoryBitmap(int bits, ImageDataBitmap dest)
	{
		int num = -1;
		int num2 = -1;
		bool segmentedColorMask = false;
		int colorPaletteOffset = ((ImagePrivateDataBitmap)base.Image.Data).ColorPaletteOffset;
		int offset = ((ImagePrivateDataBitmap)base.Image.Data).Offset;
		uint colorsUsed = base.Image.Information.ColorsUsed;
		int width = (int)base.Image.Information.Width;
		int height = (int)base.Image.Information.Height;
		MonochromeMask monochromeMask = new MonochromeMask(width, height);
		bool flag = bits == 8 && (colorsUsed == 256 || colorsUsed == 0);
		int isBitonal = 0;
		byte[] array = new byte[3 * colorsUsed];
		for (int i = 0; i < colorsUsed; i++)
		{
			array[3 * i] = Data[colorPaletteOffset + 4 * i + 2];
			array[3 * i + 1] = Data[colorPaletteOffset + 4 * i + 1];
			array[3 * i + 2] = Data[colorPaletteOffset + 4 * i];
			if (flag)
			{
				flag = array[3 * i] == array[3 * i + 1] && array[3 * i] == array[3 * i + 2];
			}
			if (Data[colorPaletteOffset + 4 * i + 3] < 128)
			{
				if (num == -1)
				{
					num = i;
				}
				if (num2 == -1 || num2 == i - 1)
				{
					num2 = i;
				}
				if (num2 != i)
				{
					segmentedColorMask = true;
				}
			}
		}
		if (bits == 1)
		{
			if (colorsUsed == 0)
			{
				isBitonal = 1;
			}
			if (colorsUsed == 2)
			{
				if (array[0] == 0 && array[1] == 0 && array[2] == 0 && array[3] == byte.MaxValue && array[4] == byte.MaxValue && array[5] == byte.MaxValue)
				{
					isBitonal = 1;
				}
				if (array[5] == 0 && array[4] == 0 && array[3] == 0 && array[2] == byte.MaxValue && array[1] == byte.MaxValue && array[0] == byte.MaxValue)
				{
					isBitonal = -1;
				}
			}
		}
		bool flag2 = false;
		byte[] array2 = new byte[(width * bits + 7) / 8 * height];
		byte[] array3 = null;
		int k = 0;
		if (bits == 1 && dest._document.Options.EnableCcittCompressionForBilevelImages)
		{
			byte[] imageData = new byte[array2.Length];
			int num3 = PdfImage.DoFaxEncodingGroup4(ref imageData, Data, (uint)offset, (uint)width, (uint)height);
			if (num3 > 0)
			{
				if (num3 == 0)
				{
					num3 = int.MaxValue;
				}
				Array.Resize(ref imageData, num3);
				array3 = imageData;
				k = -1;
			}
		}
		int num4 = 0;
		if (bits == 8 || bits == 4 || bits == 1)
		{
			int num5 = (width * bits + 7) / 8;
			for (int j = 0; j < height; j++)
			{
				monochromeMask.StartLine(j);
				int num6 = (height - 1 - j) * ((width * bits + 7) / 8);
				for (int l = 0; l < num5; l++)
				{
					if (flag)
					{
						array2[num6] = array[3 * Data[offset + num4]];
					}
					else
					{
						array2[num6] = Data[offset + num4];
					}
					if (num != -1)
					{
						int num7 = Data[offset + num4];
						switch (bits)
						{
						case 8:
							monochromeMask.AddPel(num7 >= num && num7 <= num2);
							break;
						case 4:
						{
							int num9 = (num7 & 0xF0) / 16;
							int num10 = num7 & 0xF;
							monochromeMask.AddPel(num9 >= num && num9 <= num2);
							monochromeMask.AddPel(num10 >= num && num10 <= num2);
							break;
						}
						case 1:
						{
							for (int m = 1; m <= 8; m++)
							{
								int num8 = (num7 & 0x80) / 128;
								monochromeMask.AddPel(num8 >= num && num8 <= num2);
								num7 *= 2;
							}
							break;
						}
						}
					}
					num4++;
					num6++;
				}
				num4 = 4 * ((num4 + 3) / 4);
			}
			dest.Data = array2;
			dest.Length = array2.Length;
			if (array3 != null)
			{
				dest.DataFax = array3;
				dest.LengthFax = array3.Length;
			}
			dest.IsGray = flag;
			dest.K = k;
			dest.IsBitonal = isBitonal;
			dest.PaletteData = array;
			dest.PaletteDataLength = array.Length;
			dest.SegmentedColorMask = segmentedColorMask;
			if (monochromeMask != null && num != -1)
			{
				dest.BitmapMask = monochromeMask.MaskData;
				dest.BitmapMaskLength = monochromeMask.MaskData.Length;
			}
			return;
		}
		throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #3");
	}
}

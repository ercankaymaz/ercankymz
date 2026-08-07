// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Internal.ImagePrivateDataBitmap
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using System;

#nullable disable
namespace PdfSharp.Drawing.Internal;

internal class ImagePrivateDataBitmap : ImagePrivateData
{
  private readonly byte[] _data;
  private readonly int _length;
  internal bool FlippedImage;
  internal int Offset;
  internal int ColorPaletteOffset;

  public ImagePrivateDataBitmap(byte[] data, int length)
  {
    this._data = data;
    this._length = length;
  }

  public byte[] Data => this._data;

  public int Length => this._length;

  internal void CopyBitmap(ImageDataBitmap dest)
  {
    switch (this.Image.Information.ImageFormat)
    {
      case ImageInformation.ImageFormats.Palette1:
        this.CopyIndexedMemoryBitmap(1, dest);
        break;
      case ImageInformation.ImageFormats.Palette4:
        this.CopyIndexedMemoryBitmap(4, dest);
        break;
      case ImageInformation.ImageFormats.Palette8:
        this.CopyIndexedMemoryBitmap(8, dest);
        break;
      case ImageInformation.ImageFormats.RGB24:
        this.CopyTrueColorMemoryBitmap(4, 8, false, dest);
        break;
      case ImageInformation.ImageFormats.ARGB32:
        this.CopyTrueColorMemoryBitmap(3, 8, true, dest);
        break;
      default:
        throw new NotImplementedException();
    }
  }

  private void CopyTrueColorMemoryBitmap(
    int components,
    int bits,
    bool hasAlpha,
    ImageDataBitmap dest)
  {
    int width = (int) this.Image.Information.Width;
    int height = (int) this.Image.Information.Height;
    int num1 = components;
    if (components == 4)
      num1 = 3;
    byte[] numArray1 = new byte[components * width * height];
    bool flag1 = false;
    bool flag2 = false;
    byte[] numArray2 = hasAlpha ? new byte[width * height] : (byte[]) null;
    MonochromeMask monochromeMask = hasAlpha ? new MonochromeMask(width, height) : (MonochromeMask) null;
    int offset = this.Offset;
    int num2 = 0;
    if (num1 == 3)
    {
      for (int newCurrentLine = 0; newCurrentLine < height; ++newCurrentLine)
      {
        int index1 = 3 * (height - 1 - newCurrentLine) * width;
        int index2 = 0;
        if (hasAlpha)
        {
          monochromeMask.StartLine(newCurrentLine);
          index2 = (height - 1 - newCurrentLine) * width;
        }
        for (int index3 = 0; index3 < width; ++index3)
        {
          numArray1[index1] = this.Data[offset + num2 + 2];
          numArray1[index1 + 1] = this.Data[offset + num2 + 1];
          numArray1[index1 + 2] = this.Data[offset + num2];
          if (hasAlpha)
          {
            monochromeMask.AddPel((int) this.Data[offset + num2 + 3]);
            numArray2[index2] = this.Data[offset + num2 + 3];
            if ((!flag1 ? 1 : (!flag2 ? 1 : 0)) != 0 && this.Data[offset + num2 + 3] != byte.MaxValue)
            {
              flag1 = true;
              if (this.Data[offset + num2 + 3] > (byte) 0)
                flag2 = true;
            }
            ++index2;
          }
          num2 += hasAlpha ? 4 : components;
          index1 += 3;
        }
        num2 = 4 * ((num2 + 3) / 4);
      }
    }
    else if (components == 1)
      throw new NotImplementedException("Image format not supported (grayscales).");
    dest.Data = numArray1;
    dest.Length = numArray1.Length;
    if (numArray2 != null)
    {
      dest.AlphaMask = numArray2;
      dest.AlphaMaskLength = numArray2.Length;
    }
    if (monochromeMask == null)
      return;
    dest.BitmapMask = monochromeMask.MaskData;
    dest.BitmapMaskLength = monochromeMask.MaskData.Length;
  }

  private void CopyIndexedMemoryBitmap(int bits, ImageDataBitmap dest)
  {
    int num1 = -1;
    int num2 = -1;
    bool flag1 = false;
    int colorPaletteOffset = ((ImagePrivateDataBitmap) this.Image.Data).ColorPaletteOffset;
    int offset = ((ImagePrivateDataBitmap) this.Image.Data).Offset;
    uint colorsUsed = this.Image.Information.ColorsUsed;
    int width = (int) this.Image.Information.Width;
    int height = (int) this.Image.Information.Height;
    MonochromeMask monochromeMask = new MonochromeMask(width, height);
    bool flag2 = bits == 8 && (colorsUsed == 256U /*0x0100*/ || colorsUsed == 0U);
    int num3 = 0;
    byte[] numArray1 = new byte[3 * (int) colorsUsed];
    for (int index = 0; (long) index < (long) colorsUsed; ++index)
    {
      numArray1[3 * index] = this.Data[colorPaletteOffset + 4 * index + 2];
      numArray1[3 * index + 1] = this.Data[colorPaletteOffset + 4 * index + 1];
      numArray1[3 * index + 2] = this.Data[colorPaletteOffset + 4 * index];
      if (flag2)
        flag2 = (int) numArray1[3 * index] == (int) numArray1[3 * index + 1] && (int) numArray1[3 * index] == (int) numArray1[3 * index + 2];
      if (this.Data[colorPaletteOffset + 4 * index + 3] < (byte) 128 /*0x80*/)
      {
        if (num1 == -1)
          num1 = index;
        if ((num2 == -1 ? 1 : (num2 == index - 1 ? 1 : 0)) != 0)
          num2 = index;
        if (num2 != index)
          flag1 = true;
      }
    }
    if (bits == 1)
    {
      if (colorsUsed == 0U)
        num3 = 1;
      if (colorsUsed == 2U)
      {
        if ((numArray1[0] != (byte) 0 || numArray1[1] != (byte) 0 || numArray1[2] != (byte) 0 || numArray1[3] != byte.MaxValue || numArray1[4] != byte.MaxValue ? 0 : (numArray1[5] == byte.MaxValue ? 1 : 0)) != 0)
          num3 = 1;
        if ((numArray1[5] != (byte) 0 || numArray1[4] != (byte) 0 || numArray1[3] != (byte) 0 || numArray1[2] != byte.MaxValue || numArray1[1] != byte.MaxValue ? 0 : (numArray1[0] == byte.MaxValue ? 1 : 0)) != 0)
          num3 = -1;
      }
    }
    byte[] numArray2 = new byte[(width * bits + 7) / 8 * height];
    byte[] numArray3 = (byte[]) null;
    int num4 = 0;
    if ((bits != 1 ? 0 : (dest._document.Options.EnableCcittCompressionForBilevelImages ? 1 : 0)) != 0)
    {
      byte[] numArray4 = new byte[numArray2.Length];
      int newSize = PdfImage.DoFaxEncodingGroup4(ref numArray4, this.Data, (uint) offset, (uint) width, (uint) height);
      if (newSize > 0)
      {
        if (newSize == 0)
          newSize = int.MaxValue;
        Array.Resize<byte>(ref numArray4, newSize);
        numArray3 = numArray4;
        num4 = -1;
      }
    }
    int num5 = 0;
    if ((bits == 8 || bits == 4 ? 1 : (bits == 1 ? 1 : 0)) == 0)
      throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #3");
    int num6 = (width * bits + 7) / 8;
    for (int newCurrentLine = 0; newCurrentLine < height; ++newCurrentLine)
    {
      monochromeMask.StartLine(newCurrentLine);
      int index1 = (height - 1 - newCurrentLine) * ((width * bits + 7) / 8);
      for (int index2 = 0; index2 < num6; ++index2)
      {
        numArray2[index1] = !flag2 ? this.Data[offset + num5] : numArray1[3 * (int) this.Data[offset + num5]];
        if (num1 != -1)
        {
          int num7 = (int) this.Data[offset + num5];
          switch (bits)
          {
            case 1:
              for (int index3 = 1; index3 <= 8; ++index3)
              {
                int num8 = (num7 & 128 /*0x80*/) / 128 /*0x80*/;
                monochromeMask.AddPel(num8 >= num1 && num8 <= num2);
                num7 *= 2;
              }
              break;
            case 4:
              int num9 = (num7 & 240 /*0xF0*/) / 16 /*0x10*/;
              int num10 = num7 & 15;
              monochromeMask.AddPel(num9 >= num1 && num9 <= num2);
              monochromeMask.AddPel(num10 >= num1 && num10 <= num2);
              break;
            case 8:
              monochromeMask.AddPel(num7 >= num1 && num7 <= num2);
              break;
          }
        }
        ++num5;
        ++index1;
      }
      num5 = 4 * ((num5 + 3) / 4);
    }
    dest.Data = numArray2;
    dest.Length = numArray2.Length;
    if (numArray3 != null)
    {
      dest.DataFax = numArray3;
      dest.LengthFax = numArray3.Length;
    }
    dest.IsGray = flag2;
    dest.K = num4;
    dest.IsBitonal = num3;
    dest.PaletteData = numArray1;
    dest.PaletteDataLength = numArray1.Length;
    dest.SegmentedColorMask = flag1;
    if ((monochromeMask == null ? 0 : (num1 != -1 ? 1 : 0)) == 0)
      return;
    dest.BitmapMask = monochromeMask.MaskData;
    dest.BitmapMaskLength = monochromeMask.MaskData.Length;
  }
}

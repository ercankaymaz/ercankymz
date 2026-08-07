// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Internal.ImageImporterBmp
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf;
using System;

#nullable disable
namespace PdfSharp.Drawing.Internal;

internal class ImageImporterBmp : ImageImporterRoot, IImageImporter
{
  public ImportedImage ImportImage(StreamReaderHelper stream, PdfDocument document)
  {
    ImportedImage importedImage;
    try
    {
      stream.CurrentOffset = 0;
      int offset;
      if (this.TestBitmapFileHeader(stream, out offset))
      {
        ImportedImage ii = (ImportedImage) new ImportedImageBitmap((IImageImporter) this, new ImagePrivateDataBitmap(stream.Data, stream.Length), document);
        if (this.TestBitmapInfoHeader(stream, ii, offset))
        {
          importedImage = ii;
          goto label_6;
        }
      }
    }
    catch (Exception ex)
    {
    }
    importedImage = (ImportedImage) null;
label_6:
    return importedImage;
  }

  private bool TestBitmapFileHeader(StreamReaderHelper stream, out int offset)
  {
    offset = 0;
    bool flag;
    if (stream.GetWord(0, true) == (ushort) 16973)
    {
      if ((int) stream.GetDWord(2, false) < stream.Length)
      {
        flag = false;
      }
      else
      {
        offset = (int) stream.GetDWord(10, false);
        stream.CurrentOffset += 14;
        flag = true;
      }
    }
    else
      flag = false;
    return flag;
  }

  private bool TestBitmapInfoHeader(StreamReaderHelper stream, ImportedImage ii, int offset)
  {
    int dword1 = (int) stream.GetDWord(0, false);
    int num;
    switch (dword1)
    {
      case 40:
      case 108:
        num = 1;
        break;
      default:
        num = dword1 == 124 ? 1 : 0;
        break;
    }
    bool flag;
    if (num != 0)
    {
      uint dword2 = stream.GetDWord(4, false);
      int dword3 = (int) stream.GetDWord(8, false);
      int word1 = (int) stream.GetWord(12, false);
      int word2 = (int) stream.GetWord(14, false);
      int dword4 = (int) stream.GetDWord(16 /*0x10*/, false);
      int dword5 = (int) stream.GetDWord(20, false);
      int dword6 = (int) stream.GetDWord(24, false);
      int dword7 = (int) stream.GetDWord(28, false);
      uint dword8 = stream.GetDWord(32 /*0x20*/, false);
      int dword9 = (int) stream.GetDWord(36, false);
      if ((dword5 == 0 ? 0 : (dword5 + offset > stream.Length ? 1 : 0)) != 0)
      {
        flag = false;
        goto label_18;
      }
      ImagePrivateDataBitmap data = (ImagePrivateDataBitmap) ii.Data;
      if ((dword4 == 0 ? 1 : (dword4 == 3 ? 1 : 0)) != 0)
      {
        ((ImagePrivateDataBitmap) ii.Data).Offset = offset;
        ((ImagePrivateDataBitmap) ii.Data).ColorPaletteOffset = stream.CurrentOffset + dword1;
        ii.Information.Width = dword2;
        ii.Information.Height = (uint) Math.Abs(dword3);
        ii.Information.HorizontalDPM = (Decimal) dword6;
        ii.Information.VerticalDPM = (Decimal) dword7;
        data.FlippedImage = dword3 < 0;
        if ((word1 != 1 ? 0 : (word2 == 24 ? 1 : 0)) != 0)
        {
          ii.Information.ImageFormat = ImageInformation.ImageFormats.RGB24;
          flag = true;
          goto label_18;
        }
        if ((word1 != 1 ? 0 : (word2 == 32 /*0x20*/ ? 1 : 0)) != 0)
        {
          ii.Information.ImageFormat = dword4 == 0 ? ImageInformation.ImageFormats.RGB24 : ImageInformation.ImageFormats.ARGB32;
          flag = true;
          goto label_18;
        }
        if ((word1 != 1 ? 0 : (word2 == 8 ? 1 : 0)) != 0)
        {
          ii.Information.ImageFormat = ImageInformation.ImageFormats.Palette8;
          ii.Information.ColorsUsed = dword8;
          flag = true;
          goto label_18;
        }
        if ((word1 != 1 ? 0 : (word2 == 4 ? 1 : 0)) != 0)
        {
          ii.Information.ImageFormat = ImageInformation.ImageFormats.Palette4;
          ii.Information.ColorsUsed = dword8;
          flag = true;
          goto label_18;
        }
        if ((word1 != 1 ? 0 : (word2 == 1 ? 1 : 0)) != 0)
        {
          ii.Information.ImageFormat = ImageInformation.ImageFormats.Palette1;
          ii.Information.ColorsUsed = dword8;
          flag = true;
          goto label_18;
        }
      }
    }
    flag = false;
label_18:
    return flag;
  }

  public ImageData PrepareImage(ImagePrivateData data) => throw new NotImplementedException();
}

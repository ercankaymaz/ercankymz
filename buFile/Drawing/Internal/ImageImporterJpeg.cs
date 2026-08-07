// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.Internal.ImageImporterJpeg
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf;
using System;

#nullable disable
namespace PdfSharp.Drawing.Internal;

internal class ImageImporterJpeg : ImageImporterRoot, IImageImporter
{
  public ImportedImage ImportImage(StreamReaderHelper stream, PdfDocument document)
  {
    ImportedImage importedImage;
    try
    {
      stream.CurrentOffset = 0;
      if (this.TestFileHeader(stream))
      {
        stream.CurrentOffset += 2;
        ImportedImage ii = (ImportedImage) new ImportedImageJpeg((IImageImporter) this, new ImagePrivateDataDct(stream.Data, stream.Length), document);
        if (this.TestJfifHeader(stream, ii))
        {
          bool flag1 = false;
          bool flag2 = false;
          while (this.MoveToNextHeader(stream))
          {
            if (this.TestColorFormatHeader(stream, ii))
              flag1 = true;
            else if (this.TestInfoHeader(stream, ii))
              flag2 = true;
          }
          if (flag1 & flag2)
          {
            importedImage = ii;
            goto label_13;
          }
        }
      }
    }
    catch (Exception ex)
    {
    }
    importedImage = (ImportedImage) null;
label_13:
    return importedImage;
  }

  private bool TestFileHeader(StreamReaderHelper stream)
  {
    return stream.GetWord(0, true) == (ushort) 65496;
  }

  private bool TestJfifHeader(StreamReaderHelper stream, ImportedImage ii)
  {
    bool flag;
    if (stream.GetWord(0, true) == (ushort) 65504 && stream.GetDWord(4, true) == 1246120262U && stream.GetWord(2, true) >= (ushort) 16 /*0x10*/)
    {
      int word1 = (int) stream.GetWord(9, true);
      int num = (int) stream.GetByte(11);
      int word2 = (int) stream.GetWord(12, true);
      int word3 = (int) stream.GetWord(14, true);
      switch (num)
      {
        case 0:
          ii.Information.HorizontalAspectRatio = (Decimal) word2;
          ii.Information.VerticalAspectRatio = (Decimal) word3;
          break;
        case 1:
          ii.Information.HorizontalDPI = (Decimal) word2;
          ii.Information.VerticalDPI = (Decimal) word3;
          break;
        case 2:
          ii.Information.HorizontalDPM = (Decimal) (word2 * 100);
          ii.Information.VerticalDPM = (Decimal) (word3 * 100);
          break;
      }
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  private bool TestColorFormatHeader(StreamReaderHelper stream, ImportedImage ii)
  {
    bool flag;
    if (stream.GetWord(0, true) == (ushort) 65498)
    {
      int num1 = (int) stream.GetByte(4);
      int num2;
      switch (num1)
      {
        case 1:
        case 2:
        case 3:
        case 4:
          num2 = num1 == 2 ? 1 : 0;
          break;
        default:
          num2 = 1;
          break;
      }
      if (num2 != 0)
        flag = false;
      else if ((int) stream.GetWord(2, true) != 6 + 2 * num1)
      {
        flag = false;
      }
      else
      {
        ImageInformation information = ii.Information;
        int num3;
        switch (num1)
        {
          case 1:
            num3 = 1;
            break;
          case 3:
            num3 = 0;
            break;
          default:
            num3 = 2;
            break;
        }
        information.ImageFormat = (ImageInformation.ImageFormats) num3;
        flag = true;
      }
    }
    else
      flag = false;
    return flag;
  }

  private bool TestInfoHeader(StreamReaderHelper stream, ImportedImage ii)
  {
    int word1 = (int) stream.GetWord(0, true);
    bool flag;
    if ((word1 < 65472 || word1 > 65475 ? (word1 < 65481 ? 0 : (word1 <= 65483 ? 1 : 0)) : 1) != 0)
    {
      int word2 = (int) stream.GetWord(5, true);
      int word3 = (int) stream.GetWord(7, true);
      ii.Information.Width = (uint) word3;
      ii.Information.Height = (uint) word2;
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  private bool MoveToNextHeader(StreamReaderHelper stream)
  {
    int word = (int) stream.GetWord(2, true);
    int num1 = (int) stream.GetByte(0);
    int num2 = (int) stream.GetByte(1);
    bool nextHeader;
    if (num1 == (int) byte.MaxValue)
    {
      if (num2 == 217)
        nextHeader = false;
      else if ((num2 == 1 ? 1 : (num2 < 208 /*0xD0*/ ? 0 : (num2 <= 215 ? 1 : 0))) != 0)
      {
        stream.CurrentOffset += 2;
        nextHeader = true;
      }
      else
      {
        stream.CurrentOffset += 2 + word;
        nextHeader = true;
      }
    }
    else
      nextHeader = false;
    return nextHeader;
  }

  public ImageData PrepareImage(ImagePrivateData data) => throw new NotImplementedException();
}

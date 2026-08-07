// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfImage
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Drawing.Internal;
using PdfSharp.Pdf.Filters;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfImage : PdfXObject
{
  private readonly XImage _image;
  internal static readonly uint[] WhiteTerminatingCodes = new uint[128 /*0x80*/]
  {
    53U,
    8U,
    7U,
    6U,
    7U,
    4U,
    8U,
    4U,
    11U,
    4U,
    12U,
    4U,
    14U,
    4U,
    15U,
    4U,
    19U,
    5U,
    20U,
    5U,
    7U,
    5U,
    8U,
    5U,
    8U,
    6U,
    3U,
    6U,
    52U,
    6U,
    53U,
    6U,
    42U,
    6U,
    43U,
    6U,
    39U,
    7U,
    12U,
    7U,
    8U,
    7U,
    23U,
    7U,
    3U,
    7U,
    4U,
    7U,
    40U,
    7U,
    43U,
    7U,
    19U,
    7U,
    36U,
    7U,
    24U,
    7U,
    2U,
    8U,
    3U,
    8U,
    26U,
    8U,
    27U,
    8U,
    18U,
    8U,
    19U,
    8U,
    20U,
    8U,
    21U,
    8U,
    22U,
    8U,
    23U,
    8U,
    40U,
    8U,
    41U,
    8U,
    42U,
    8U,
    43U,
    8U,
    44U,
    8U,
    45U,
    8U,
    4U,
    8U,
    5U,
    8U,
    10U,
    8U,
    11U,
    8U,
    82U,
    8U,
    83U,
    8U,
    84U,
    8U,
    85U,
    8U,
    36U,
    8U,
    37U,
    8U,
    88U,
    8U,
    89U,
    8U,
    90U,
    8U,
    91U,
    8U,
    74U,
    8U,
    75U,
    8U,
    50U,
    8U,
    51U,
    8U,
    52U,
    8U
  };
  internal static readonly uint[] BlackTerminatingCodes = new uint[128 /*0x80*/]
  {
    55U,
    10U,
    2U,
    3U,
    3U,
    2U,
    2U,
    2U,
    3U,
    3U,
    3U,
    4U,
    2U,
    4U,
    3U,
    5U,
    5U,
    6U,
    4U,
    6U,
    4U,
    7U,
    5U,
    7U,
    7U,
    7U,
    4U,
    8U,
    7U,
    8U,
    24U,
    9U,
    23U,
    10U,
    24U,
    10U,
    8U,
    10U,
    103U,
    11U,
    104U,
    11U,
    108U,
    11U,
    55U,
    11U,
    40U,
    11U,
    23U,
    11U,
    24U,
    11U,
    202U,
    12U,
    203U,
    12U,
    204U,
    12U,
    205U,
    12U,
    104U,
    12U,
    105U,
    12U,
    106U,
    12U,
    107U,
    12U,
    210U,
    12U,
    211U,
    12U,
    212U,
    12U,
    213U,
    12U,
    214U,
    12U,
    215U,
    12U,
    108U,
    12U,
    109U,
    12U,
    218U,
    12U,
    219U,
    12U,
    84U,
    12U,
    85U,
    12U,
    86U,
    12U,
    87U,
    12U,
    100U,
    12U,
    101U,
    12U,
    82U,
    12U,
    83U,
    12U,
    36U,
    12U,
    55U,
    12U,
    56U,
    12U,
    39U,
    12U,
    40U,
    12U,
    88U,
    12U,
    89U,
    12U,
    43U,
    12U,
    44U,
    12U,
    90U,
    12U,
    102U,
    12U,
    103U,
    12U
  };
  internal static readonly uint[] WhiteMakeUpCodes = new uint[82]
  {
    27U,
    5U,
    18U,
    5U,
    23U,
    6U,
    55U,
    7U,
    54U,
    8U,
    55U,
    8U,
    100U,
    8U,
    101U,
    8U,
    104U,
    8U,
    103U,
    8U,
    204U,
    9U,
    205U,
    9U,
    210U,
    9U,
    211U,
    9U,
    212U,
    9U,
    213U,
    9U,
    214U,
    9U,
    215U,
    9U,
    216U,
    9U,
    217U,
    9U,
    218U,
    9U,
    219U,
    9U,
    152U,
    9U,
    153U,
    9U,
    154U,
    9U,
    24U,
    6U,
    155U,
    9U,
    8U,
    11U,
    12U,
    11U,
    13U,
    11U,
    18U,
    12U,
    19U,
    12U,
    20U,
    12U,
    21U,
    12U,
    22U,
    12U,
    23U,
    12U,
    28U,
    12U,
    29U,
    12U,
    30U,
    12U,
    31U /*0x1F*/,
    12U,
    1U,
    12U
  };
  internal static readonly uint[] BlackMakeUpCodes = new uint[82]
  {
    15U,
    10U,
    200U,
    12U,
    201U,
    12U,
    91U,
    12U,
    51U,
    12U,
    52U,
    12U,
    53U,
    12U,
    108U,
    13U,
    109U,
    13U,
    74U,
    13U,
    75U,
    13U,
    76U,
    13U,
    77U,
    13U,
    114U,
    13U,
    115U,
    13U,
    116U,
    13U,
    117U,
    13U,
    118U,
    13U,
    119U,
    13U,
    82U,
    13U,
    83U,
    13U,
    84U,
    13U,
    85U,
    13U,
    90U,
    13U,
    91U,
    13U,
    100U,
    13U,
    101U,
    13U,
    8U,
    11U,
    12U,
    11U,
    13U,
    11U,
    18U,
    12U,
    19U,
    12U,
    20U,
    12U,
    21U,
    12U,
    22U,
    12U,
    23U,
    12U,
    28U,
    12U,
    29U,
    12U,
    30U,
    12U,
    31U /*0x1F*/,
    12U,
    1U,
    12U
  };
  internal static readonly uint[] HorizontalCodes = new uint[2]
  {
    1U,
    3U
  };
  internal static readonly uint[] PassCodes = new uint[2]
  {
    1U,
    4U
  };
  internal static readonly uint[] VerticalCodes = new uint[14]
  {
    3U,
    7U,
    3U,
    6U,
    3U,
    3U,
    1U,
    1U,
    2U,
    3U,
    2U,
    6U,
    2U,
    7U
  };
  private static readonly uint[] _zeroRuns = new uint[256 /*0x0100*/]
  {
    8U,
    7U,
    6U,
    6U,
    5U,
    5U,
    5U,
    5U,
    4U,
    4U,
    4U,
    4U,
    4U,
    4U,
    4U,
    4U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U
  };
  private static readonly uint[] _oneRuns = new uint[256 /*0x0100*/]
  {
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    0U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    1U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    2U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    3U,
    4U,
    4U,
    4U,
    4U,
    4U,
    4U,
    4U,
    4U,
    5U,
    5U,
    5U,
    5U,
    6U,
    6U,
    7U,
    8U
  };

  public PdfImage(PdfDocument document, XImage image)
    : base(document)
  {
    this.Elements.SetName("/Type", "/XObject");
    this.Elements.SetName("/Subtype", "/Image");
    this._image = image;
    switch (this._image.Format.Guid.ToString("B").ToUpper())
    {
      case "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}":
        this.InitializeJpeg();
        break;
      case "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}":
      case "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}":
      case "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}":
      case "{B96B3CB5-0728-11D3-9D7B-0000F81EF32E}":
        this.InitializeNonJpeg();
        break;
      case "{84570158-DBF0-4C6B-8368-62D6A3CA76E0}":
        Debug.Assert(false, "XPdfForm not expected here.");
        break;
      default:
        Debug.Assert(false, "Unexpected image type.");
        break;
    }
  }

  public XImage Image => this._image;

  public override string ToString() => "Image";

  private void InitializeJpeg()
  {
    MemoryStream memoryStream = (MemoryStream) null;
    bool flag1 = false;
    byte[] numArray1 = (byte[]) null;
    int count1 = 0;
    if (this._image._importedImage != null)
    {
      ImageDataDct imageData = (ImageDataDct) this._image._importedImage.ImageData;
      numArray1 = imageData.Data;
      count1 = imageData.Length;
    }
    if (this._image._importedImage == null)
    {
      if (!this._image._path.StartsWith("*"))
      {
        using (FileStream fileStream = File.OpenRead(this._image._path))
        {
          byte[] buffer = new byte[8192 /*0x2000*/];
          memoryStream = new MemoryStream((int) fileStream.Length);
          flag1 = true;
          int count2;
          do
          {
            count2 = fileStream.Read(buffer, 0, buffer.Length);
            memoryStream.Write(buffer, 0, count2);
          }
          while (count2 > 0);
        }
      }
      else
      {
        memoryStream = new MemoryStream();
        flag1 = true;
        if ((this._image._stream == null ? 0 : (this._image._stream.CanSeek ? 1 : 0)) != 0)
        {
          System.IO.Stream stream = this._image._stream;
          stream.Seek(0L, SeekOrigin.Begin);
          byte[] buffer = new byte[32768 /*0x8000*/];
          int count3;
          while ((count3 = stream.Read(buffer, 0, buffer.Length)) > 0)
            memoryStream.Write(buffer, 0, count3);
        }
        else
          this._image._gdiImage.Save((System.IO.Stream) memoryStream, ImageFormat.Jpeg);
      }
      if ((int) memoryStream.Length == 0)
        Debug.Assert(false, "Internal error? JPEG image, but file not found!");
    }
    if (numArray1 == null)
    {
      count1 = (int) memoryStream.Length;
      numArray1 = new byte[count1];
      memoryStream.Seek(0L, SeekOrigin.Begin);
      memoryStream.Read(numArray1, 0, count1);
      if (flag1)
        memoryStream.Dispose();
    }
    bool flag2 = this._document.Options.UseFlateDecoderForJpegImages == PdfUseFlateDecoderForJpegImages.Automatic;
    bool flag3 = this._document.Options.UseFlateDecoderForJpegImages == PdfUseFlateDecoderForJpegImages.Always;
    FlateDecode flateDecode = new FlateDecode();
    byte[] numArray2 = flag3 | flag2 ? flateDecode.Encode(numArray1, this._document.Options.FlateEncodeMode) : (byte[]) null;
    if ((flag3 ? 1 : (!flag2 ? 0 : (numArray2.Length < numArray1.Length ? 1 : 0))) != 0)
    {
      this.Stream = new PdfDictionary.PdfStream(numArray2, (PdfDictionary) this);
      this.Elements["/Length"] = (PdfItem) new PdfInteger(numArray2.Length);
      this.Elements["/Filter"] = (PdfItem) new PdfArray(this._document)
      {
        Elements = {
          (PdfItem) new PdfName("/FlateDecode"),
          (PdfItem) new PdfName("/DCTDecode")
        }
      };
    }
    else
    {
      this.Stream = new PdfDictionary.PdfStream(numArray1, (PdfDictionary) this);
      this.Elements["/Length"] = (PdfItem) new PdfInteger(count1);
      this.Elements["/Filter"] = (PdfItem) new PdfName("/DCTDecode");
    }
    if (this._image.Interpolate)
      this.Elements["/Interpolate"] = (PdfItem) PdfBoolean.True;
    this.Elements["/Width"] = (PdfItem) new PdfInteger(this._image.PixelWidth);
    this.Elements["/Height"] = (PdfItem) new PdfInteger(this._image.PixelHeight);
    this.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(8);
    if (this._image._importedImage != null)
    {
      if ((this._image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGCMYK ? 1 : (this._image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGRGBW ? 1 : 0)) != 0)
      {
        this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceCMYK");
        if (this._image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGRGBW)
          this.Elements["/Decode"] = (PdfItem) new PdfLiteral("[1 0 1 0 1 0 1 0]");
      }
      else if (this._image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGGRAY)
        this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceGray");
      else
        this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceRGB");
    }
    if (this._image._importedImage != null)
      return;
    if ((this._image._gdiImage.Flags & 288) != 0)
    {
      this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceCMYK");
      if ((this._image._gdiImage.Flags & 256 /*0x0100*/) == 0)
        return;
      this.Elements["/Decode"] = (PdfItem) new PdfLiteral("[1 0 1 0 1 0 1 0]");
    }
    else if ((this._image._gdiImage.Flags & 64 /*0x40*/) != 0)
      this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceGray");
    else
      this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceRGB");
  }

  private void InitializeNonJpeg()
  {
    if (this._image._importedImage != null)
    {
      switch (this._image._importedImage.Information.ImageFormat)
      {
        case ImageInformation.ImageFormats.Palette1:
          this.CreateIndexedMemoryBitmap(1);
          break;
        case ImageInformation.ImageFormats.Palette4:
          this.CreateIndexedMemoryBitmap(4);
          break;
        case ImageInformation.ImageFormats.Palette8:
          this.CreateIndexedMemoryBitmap(8);
          break;
        case ImageInformation.ImageFormats.RGB24:
          this.CreateTrueColorMemoryBitmap(3, 8, false);
          break;
        default:
          throw new NotImplementedException("Image format not supported.");
      }
    }
    else
    {
      switch (this._image._gdiImage.PixelFormat)
      {
        case PixelFormat.Format24bppRgb:
          this.ReadTrueColorMemoryBitmap(3, 8, false);
          break;
        case PixelFormat.Format32bppRgb:
          this.ReadTrueColorMemoryBitmap(4, 8, false);
          break;
        case PixelFormat.Format1bppIndexed:
          this.ReadIndexedMemoryBitmap(1);
          break;
        case PixelFormat.Format4bppIndexed:
          this.ReadIndexedMemoryBitmap(4);
          break;
        case PixelFormat.Format8bppIndexed:
          this.ReadIndexedMemoryBitmap(8);
          break;
        case PixelFormat.Format32bppPArgb:
        case PixelFormat.Format32bppArgb:
          this.ReadTrueColorMemoryBitmap(3, 8, true);
          break;
        default:
          throw new NotImplementedException("Image format not supported.");
      }
    }
  }

  private void CreateIndexedMemoryBitmap(int bits)
  {
    ImageDataBitmap imageData = (ImageDataBitmap) this._image._importedImage.ImageData;
    ImageInformation information = this._image._importedImage.Information;
    int version = this.Owner.Version;
    FlateDecode flateDecode = new FlateDecode();
    byte[] numArray1 = flateDecode.Encode(imageData.Data, this._document.Options.FlateEncodeMode);
    byte[] numArray2 = imageData.DataFax != null ? flateDecode.Encode(imageData.DataFax, this._document.Options.FlateEncodeMode) : (byte[]) null;
    bool flag = false;
    if ((imageData.DataFax == null ? 0 : (imageData.LengthFax < numArray1.Length ? 1 : (numArray2.Length < numArray1.Length ? 1 : 0))) != 0)
    {
      flag = true;
      if (imageData.LengthFax < numArray1.Length)
      {
        this.Stream = new PdfDictionary.PdfStream(imageData.DataFax, (PdfDictionary) this);
        this.Elements["/Length"] = (PdfItem) new PdfInteger(imageData.LengthFax);
        this.Elements["/Filter"] = (PdfItem) new PdfName("/CCITTFaxDecode");
        PdfDictionary pdfDictionary = new PdfDictionary();
        if (imageData.K != 0)
          pdfDictionary.Elements.Add("/K", (PdfItem) new PdfInteger(imageData.K));
        if (imageData.IsBitonal < 0)
          pdfDictionary.Elements.Add("/BlackIs1", (PdfItem) new PdfBoolean(true));
        pdfDictionary.Elements.Add("/EndOfBlock", (PdfItem) new PdfBoolean(false));
        pdfDictionary.Elements.Add("/Columns", (PdfItem) new PdfInteger((int) information.Width));
        pdfDictionary.Elements.Add("/Rows", (PdfItem) new PdfInteger((int) information.Height));
        this.Elements["/DecodeParms"] = (PdfItem) pdfDictionary;
      }
      else
      {
        this.Stream = new PdfDictionary.PdfStream(numArray2, (PdfDictionary) this);
        this.Elements["/Length"] = (PdfItem) new PdfInteger(numArray2.Length);
        this.Elements["/Filter"] = (PdfItem) new PdfArray(this._document)
        {
          Elements = {
            (PdfItem) new PdfName("/FlateDecode"),
            (PdfItem) new PdfName("/CCITTFaxDecode")
          }
        };
        PdfArray pdfArray = new PdfArray(this._document);
        PdfDictionary pdfDictionary1 = new PdfDictionary();
        PdfDictionary pdfDictionary2 = new PdfDictionary();
        if (imageData.K != 0)
          pdfDictionary2.Elements.Add("/K", (PdfItem) new PdfInteger(imageData.K));
        if (imageData.IsBitonal < 0)
          pdfDictionary2.Elements.Add("/BlackIs1", (PdfItem) new PdfBoolean(true));
        pdfDictionary2.Elements.Add("/EndOfBlock", (PdfItem) new PdfBoolean(false));
        pdfDictionary2.Elements.Add("/Columns", (PdfItem) new PdfInteger((int) information.Width));
        pdfDictionary2.Elements.Add("/Rows", (PdfItem) new PdfInteger((int) information.Height));
        pdfArray.Elements.Add((PdfItem) pdfDictionary1);
        pdfArray.Elements.Add((PdfItem) pdfDictionary2);
        this.Elements["/DecodeParms"] = (PdfItem) pdfArray;
      }
    }
    else
    {
      this.Stream = new PdfDictionary.PdfStream(numArray1, (PdfDictionary) this);
      this.Elements["/Length"] = (PdfItem) new PdfInteger(numArray1.Length);
      this.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
    }
    this.Elements["/Width"] = (PdfItem) new PdfInteger((int) information.Width);
    this.Elements["/Height"] = (PdfItem) new PdfInteger((int) information.Height);
    this.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(bits);
    if ((!flag || imageData.IsBitonal != 0 ? (flag || imageData.IsBitonal > 0 ? 0 : (!imageData.IsGray ? 1 : 0)) : 1) != 0)
    {
      PdfDictionary pdfDictionary = new PdfDictionary(this._document);
      byte[] numArray3 = imageData.PaletteDataLength >= 48 /*0x30*/ ? flateDecode.Encode(imageData.PaletteData, this._document.Options.FlateEncodeMode) : (byte[]) null;
      if ((numArray3 == null ? 0 : (numArray3.Length + 20 < imageData.PaletteDataLength ? 1 : 0)) != 0)
      {
        pdfDictionary.CreateStream(numArray3);
        pdfDictionary.Elements["/Length"] = (PdfItem) new PdfInteger(numArray3.Length);
        pdfDictionary.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
      }
      else
      {
        pdfDictionary.CreateStream(imageData.PaletteData);
        pdfDictionary.Elements["/Length"] = (PdfItem) new PdfInteger(imageData.PaletteDataLength);
      }
      this.Owner._irefTable.Add((PdfObject) pdfDictionary);
      this.Elements["/ColorSpace"] = (PdfItem) new PdfArray(this._document)
      {
        Elements = {
          (PdfItem) new PdfName("/Indexed"),
          (PdfItem) new PdfName("/DeviceRGB"),
          (PdfItem) new PdfInteger((int) information.ColorsUsed - 1),
          (PdfItem) pdfDictionary.Reference
        }
      };
    }
    else
      this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceGray");
    if (!this._image.Interpolate)
      return;
    this.Elements["/Interpolate"] = (PdfItem) PdfBoolean.True;
  }

  private void CreateTrueColorMemoryBitmap(int components, int bits, bool hasAlpha)
  {
    int version = this.Owner.Version;
    FlateDecode flateDecode = new FlateDecode();
    ImageDataBitmap imageData = (ImageDataBitmap) this._image._importedImage.ImageData;
    ImageInformation information = this._image._importedImage.Information;
    bool flag1 = imageData.AlphaMaskLength > 0 || imageData.BitmapMaskLength > 0;
    bool flag2 = imageData.AlphaMaskLength > 0;
    if (flag1)
    {
      byte[] numArray = flateDecode.Encode(imageData.BitmapMask, this._document.Options.FlateEncodeMode);
      PdfDictionary owner = new PdfDictionary(this._document);
      owner.Elements.SetName("/Type", "/XObject");
      owner.Elements.SetName("/Subtype", "/Image");
      this.Owner._irefTable.Add((PdfObject) owner);
      owner.Stream = new PdfDictionary.PdfStream(numArray, owner);
      owner.Elements["/Length"] = (PdfItem) new PdfInteger(numArray.Length);
      owner.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
      owner.Elements["/Width"] = (PdfItem) new PdfInteger((int) information.Width);
      owner.Elements["/Height"] = (PdfItem) new PdfInteger((int) information.Height);
      owner.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(1);
      owner.Elements["/ImageMask"] = (PdfItem) new PdfBoolean(true);
      this.Elements["/Mask"] = (PdfItem) owner.Reference;
    }
    if ((!(flag1 & flag2) ? 0 : (version >= 14 ? 1 : 0)) != 0)
    {
      byte[] numArray = flateDecode.Encode(imageData.AlphaMask, this._document.Options.FlateEncodeMode);
      PdfDictionary owner = new PdfDictionary(this._document);
      owner.Elements.SetName("/Type", "/XObject");
      owner.Elements.SetName("/Subtype", "/Image");
      this.Owner._irefTable.Add((PdfObject) owner);
      owner.Stream = new PdfDictionary.PdfStream(numArray, owner);
      owner.Elements["/Length"] = (PdfItem) new PdfInteger(numArray.Length);
      owner.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
      owner.Elements["/Width"] = (PdfItem) new PdfInteger((int) information.Width);
      owner.Elements["/Height"] = (PdfItem) new PdfInteger((int) information.Height);
      owner.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(8);
      owner.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceGray");
      this.Elements["/SMask"] = (PdfItem) owner.Reference;
    }
    byte[] numArray1 = flateDecode.Encode(imageData.Data, this._document.Options.FlateEncodeMode);
    this.Stream = new PdfDictionary.PdfStream(numArray1, (PdfDictionary) this);
    this.Elements["/Length"] = (PdfItem) new PdfInteger(numArray1.Length);
    this.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
    this.Elements["/Width"] = (PdfItem) new PdfInteger((int) information.Width);
    this.Elements["/Height"] = (PdfItem) new PdfInteger((int) information.Height);
    this.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(8);
    this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceRGB");
    if (!this._image.Interpolate)
      return;
    this.Elements["/Interpolate"] = (PdfItem) PdfBoolean.True;
  }

  private static int ReadWord(byte[] ab, int offset)
  {
    return (int) ab[offset] + 256 /*0x0100*/ * (int) ab[offset + 1];
  }

  private static int ReadDWord(byte[] ab, int offset)
  {
    return PdfImage.ReadWord(ab, offset) + 65536 /*0x010000*/ * PdfImage.ReadWord(ab, offset + 2);
  }

  private void ReadTrueColorMemoryBitmap(int components, int bits, bool hasAlpha)
  {
    int version = this.Owner.Version;
    MemoryStream memoryStream = new MemoryStream();
    this._image._gdiImage.Save((System.IO.Stream) memoryStream, ImageFormat.Bmp);
    int length = (int) memoryStream.Length;
    Debug.Assert(length > 0, "Bitmap image encoding failed.");
    if (length <= 0)
      return;
    byte[] buffer = memoryStream.GetBuffer();
    int pixelHeight = this._image.PixelHeight;
    int pixelWidth = this._image.PixelWidth;
    if ((PdfImage.ReadWord(buffer, 0) != 19778 || PdfImage.ReadDWord(buffer, 2) != length || PdfImage.ReadDWord(buffer, 14) != 40 || PdfImage.ReadDWord(buffer, 18) != pixelWidth ? 1 : (PdfImage.ReadDWord(buffer, 22) != pixelHeight ? 1 : 0)) != 0)
      throw new NotImplementedException("ReadTrueColorMemoryBitmap: unsupported format");
    if ((PdfImage.ReadWord(buffer, 26) != 1 || !hasAlpha && PdfImage.ReadWord(buffer, 28) != components * bits || hasAlpha && PdfImage.ReadWord(buffer, 28) != (components + 1) * bits ? 1 : (PdfImage.ReadDWord(buffer, 30) != 0 ? 1 : 0)) != 0)
      throw new NotImplementedException("ReadTrueColorMemoryBitmap: unsupported format #2");
    int num1 = PdfImage.ReadDWord(buffer, 10);
    int num2 = components;
    if (components == 4)
      num2 = 3;
    byte[] data1 = new byte[components * pixelWidth * pixelHeight];
    bool flag1 = false;
    bool flag2 = false;
    byte[] data2 = hasAlpha ? new byte[pixelWidth * pixelHeight] : (byte[]) null;
    MonochromeMask monochromeMask = hasAlpha ? new MonochromeMask(pixelWidth, pixelHeight) : (MonochromeMask) null;
    int num3 = 0;
    if (num2 == 3)
    {
      for (int newCurrentLine = 0; newCurrentLine < pixelHeight; ++newCurrentLine)
      {
        int index1 = 3 * (pixelHeight - 1 - newCurrentLine) * pixelWidth;
        int index2 = 0;
        if (hasAlpha)
        {
          monochromeMask.StartLine(newCurrentLine);
          index2 = (pixelHeight - 1 - newCurrentLine) * pixelWidth;
        }
        for (int index3 = 0; index3 < pixelWidth; ++index3)
        {
          data1[index1] = buffer[num1 + num3 + 2];
          data1[index1 + 1] = buffer[num1 + num3 + 1];
          data1[index1 + 2] = buffer[num1 + num3];
          if (hasAlpha)
          {
            monochromeMask.AddPel((int) buffer[num1 + num3 + 3]);
            data2[index2] = buffer[num1 + num3 + 3];
            if ((!flag1 ? 1 : (!flag2 ? 1 : 0)) != 0 && buffer[num1 + num3 + 3] != byte.MaxValue)
            {
              flag1 = true;
              if (buffer[num1 + num3 + 3] > (byte) 0)
                flag2 = true;
            }
            ++index2;
          }
          num3 += hasAlpha ? 4 : components;
          index1 += 3;
        }
        num3 = 4 * ((num3 + 3) / 4);
      }
    }
    else if (components == 1)
      throw new NotImplementedException("Image format not supported (grayscales).");
    FlateDecode flateDecode = new FlateDecode();
    if (flag1)
    {
      byte[] numArray = flateDecode.Encode(monochromeMask.MaskData, this._document.Options.FlateEncodeMode);
      PdfDictionary owner = new PdfDictionary(this._document);
      owner.Elements.SetName("/Type", "/XObject");
      owner.Elements.SetName("/Subtype", "/Image");
      this.Owner._irefTable.Add((PdfObject) owner);
      owner.Stream = new PdfDictionary.PdfStream(numArray, owner);
      owner.Elements["/Length"] = (PdfItem) new PdfInteger(numArray.Length);
      owner.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
      owner.Elements["/Width"] = (PdfItem) new PdfInteger(pixelWidth);
      owner.Elements["/Height"] = (PdfItem) new PdfInteger(pixelHeight);
      owner.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(1);
      owner.Elements["/ImageMask"] = (PdfItem) new PdfBoolean(true);
      this.Elements["/Mask"] = (PdfItem) owner.Reference;
    }
    if ((!(flag1 & flag2) ? 0 : (version >= 14 ? 1 : 0)) != 0)
    {
      byte[] numArray = flateDecode.Encode(data2, this._document.Options.FlateEncodeMode);
      PdfDictionary owner = new PdfDictionary(this._document);
      owner.Elements.SetName("/Type", "/XObject");
      owner.Elements.SetName("/Subtype", "/Image");
      this.Owner._irefTable.Add((PdfObject) owner);
      owner.Stream = new PdfDictionary.PdfStream(numArray, owner);
      owner.Elements["/Length"] = (PdfItem) new PdfInteger(numArray.Length);
      owner.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
      owner.Elements["/Width"] = (PdfItem) new PdfInteger(pixelWidth);
      owner.Elements["/Height"] = (PdfItem) new PdfInteger(pixelHeight);
      owner.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(8);
      owner.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceGray");
      this.Elements["/SMask"] = (PdfItem) owner.Reference;
    }
    byte[] numArray1 = flateDecode.Encode(data1, this._document.Options.FlateEncodeMode);
    this.Stream = new PdfDictionary.PdfStream(numArray1, (PdfDictionary) this);
    this.Elements["/Length"] = (PdfItem) new PdfInteger(numArray1.Length);
    this.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
    this.Elements["/Width"] = (PdfItem) new PdfInteger(pixelWidth);
    this.Elements["/Height"] = (PdfItem) new PdfInteger(pixelHeight);
    this.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(8);
    this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceRGB");
    if (!this._image.Interpolate)
      return;
    this.Elements["/Interpolate"] = (PdfItem) PdfBoolean.True;
  }

  private void ReadIndexedMemoryBitmap(int bits)
  {
    int version = this.Owner.Version;
    int num1 = -1;
    int num2 = -1;
    bool flag1 = false;
    MemoryStream memoryStream = new MemoryStream();
    this._image._gdiImage.Save((System.IO.Stream) memoryStream, ImageFormat.Bmp);
    int length = (int) memoryStream.Length;
    Debug.Assert(length > 0, "Bitmap image encoding failed.");
    if (length <= 0)
      return;
    byte[] numArray1 = new byte[length];
    memoryStream.Seek(0L, SeekOrigin.Begin);
    memoryStream.Read(numArray1, 0, length);
    memoryStream.Close();
    int pixelHeight = this._image.PixelHeight;
    int pixelWidth = this._image.PixelWidth;
    if ((PdfImage.ReadWord(numArray1, 0) != 19778 || PdfImage.ReadDWord(numArray1, 2) != length || PdfImage.ReadDWord(numArray1, 14) != 40 || PdfImage.ReadDWord(numArray1, 18) != pixelWidth ? 1 : (PdfImage.ReadDWord(numArray1, 22) != pixelHeight ? 1 : 0)) != 0)
      throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format");
    int num3 = PdfImage.ReadWord(numArray1, 28);
    if (num3 != bits && (num3 == 1 || num3 == 4 ? 1 : (num3 == 8 ? 1 : 0)) != 0)
      bits = num3;
    int bytesFileOffset = (PdfImage.ReadWord(numArray1, 26) != 1 || PdfImage.ReadWord(numArray1, 28) != bits ? 1 : (PdfImage.ReadDWord(numArray1, 30) != 0 ? 1 : 0)) == 0 ? PdfImage.ReadDWord(numArray1, 10) : throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #2");
    int num4 = PdfImage.ReadDWord(numArray1, 46);
    if ((bytesFileOffset - 54) / 4 != num4)
      throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #3");
    MonochromeMask monochromeMask = new MonochromeMask(pixelWidth, pixelHeight);
    bool flag2 = bits == 8 && (num4 == 256 /*0x0100*/ || num4 == 0);
    int num5 = 0;
    byte[] data1 = new byte[3 * num4];
    for (int index = 0; index < num4; ++index)
    {
      data1[3 * index] = numArray1[54 + 4 * index + 2];
      data1[3 * index + 1] = numArray1[54 + 4 * index + 1];
      data1[3 * index + 2] = numArray1[54 + 4 * index];
      if (flag2)
        flag2 = (int) data1[3 * index] == (int) data1[3 * index + 1] && (int) data1[3 * index] == (int) data1[3 * index + 2];
      if (numArray1[54 + 4 * index + 3] < (byte) 128 /*0x80*/)
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
      if (num4 == 0)
        num5 = 1;
      if (num4 == 2)
      {
        if ((data1[0] != (byte) 0 || data1[1] != (byte) 0 || data1[2] != (byte) 0 || data1[3] != byte.MaxValue || data1[4] != byte.MaxValue ? 0 : (data1[5] == byte.MaxValue ? 1 : 0)) != 0)
          num5 = 1;
        if ((data1[5] != (byte) 0 || data1[4] != (byte) 0 || data1[3] != (byte) 0 || data1[2] != byte.MaxValue || data1[1] != byte.MaxValue ? 0 : (data1[0] == byte.MaxValue ? 1 : 0)) != 0)
          num5 = -1;
      }
    }
    bool flag3 = false;
    byte[] data2 = new byte[(pixelWidth * bits + 7) / 8 * pixelHeight];
    byte[] data3 = (byte[]) null;
    int num6 = 0;
    if (bits == 1)
    {
      byte[] numArray2 = new byte[data2.Length];
      int newSize = PdfImage.DoFaxEncodingGroup4(ref numArray2, numArray1, (uint) bytesFileOffset, (uint) pixelWidth, (uint) pixelHeight);
      if (flag3 = newSize > 0)
      {
        if (newSize == 0)
          newSize = int.MaxValue;
        Array.Resize<byte>(ref numArray2, newSize);
        data3 = numArray2;
        num6 = -1;
      }
    }
    int num7 = 0;
    if ((bits == 8 || bits == 4 ? 1 : (bits == 1 ? 1 : 0)) == 0)
      throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #3");
    int num8 = (pixelWidth * bits + 7) / 8;
    for (int newCurrentLine = 0; newCurrentLine < pixelHeight; ++newCurrentLine)
    {
      monochromeMask.StartLine(newCurrentLine);
      int index1 = (pixelHeight - 1 - newCurrentLine) * ((pixelWidth * bits + 7) / 8);
      for (int index2 = 0; index2 < num8; ++index2)
      {
        data2[index1] = !flag2 ? numArray1[bytesFileOffset + num7] : data1[3 * (int) numArray1[bytesFileOffset + num7]];
        if (num1 != -1)
        {
          int num9 = (int) numArray1[bytesFileOffset + num7];
          switch (bits)
          {
            case 1:
              for (int index3 = 1; index3 <= 8; ++index3)
              {
                int num10 = (num9 & 128 /*0x80*/) / 128 /*0x80*/;
                monochromeMask.AddPel(num10 >= num1 && num10 <= num2);
                num9 *= 2;
              }
              break;
            case 4:
              int num11 = (num9 & 240 /*0xF0*/) / 16 /*0x10*/;
              int num12 = num9 & 15;
              monochromeMask.AddPel(num11 >= num1 && num11 <= num2);
              monochromeMask.AddPel(num12 >= num1 && num12 <= num2);
              break;
            case 8:
              monochromeMask.AddPel(num9 >= num1 && num9 <= num2);
              break;
          }
        }
        ++num7;
        ++index1;
      }
      num7 = 4 * ((num7 + 3) / 4);
    }
    FlateDecode flateDecode = new FlateDecode();
    if ((num1 == -1 ? 0 : (num2 != -1 ? 1 : 0)) != 0)
    {
      if ((flag1 || version < 13 ? 0 : (!flag2 ? 1 : 0)) != 0)
      {
        this.Elements["/Mask"] = (PdfItem) new PdfArray(this._document)
        {
          Elements = {
            (PdfItem) new PdfInteger(num1),
            (PdfItem) new PdfInteger(num2)
          }
        };
      }
      else
      {
        byte[] numArray3 = flateDecode.Encode(monochromeMask.MaskData, this._document.Options.FlateEncodeMode);
        PdfDictionary owner = new PdfDictionary(this._document);
        owner.Elements.SetName("/Type", "/XObject");
        owner.Elements.SetName("/Subtype", "/Image");
        this.Owner._irefTable.Add((PdfObject) owner);
        owner.Stream = new PdfDictionary.PdfStream(numArray3, owner);
        owner.Elements["/Length"] = (PdfItem) new PdfInteger(numArray3.Length);
        owner.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
        owner.Elements["/Width"] = (PdfItem) new PdfInteger(pixelWidth);
        owner.Elements["/Height"] = (PdfItem) new PdfInteger(pixelHeight);
        owner.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(1);
        owner.Elements["/ImageMask"] = (PdfItem) new PdfBoolean(true);
        this.Elements["/Mask"] = (PdfItem) owner.Reference;
      }
    }
    byte[] numArray4 = flateDecode.Encode(data2, this._document.Options.FlateEncodeMode);
    byte[] numArray5 = flag3 ? flateDecode.Encode(data3, this._document.Options.FlateEncodeMode) : (byte[]) null;
    bool flag4 = false;
    if ((!flag3 ? 0 : (data3.Length < numArray4.Length ? 1 : (numArray5.Length < numArray4.Length ? 1 : 0))) != 0)
    {
      flag4 = true;
      if (data3.Length < numArray4.Length)
      {
        this.Stream = new PdfDictionary.PdfStream(data3, (PdfDictionary) this);
        this.Elements["/Length"] = (PdfItem) new PdfInteger(data3.Length);
        this.Elements["/Filter"] = (PdfItem) new PdfName("/CCITTFaxDecode");
        PdfDictionary pdfDictionary = new PdfDictionary();
        if (num6 != 0)
          pdfDictionary.Elements.Add("/K", (PdfItem) new PdfInteger(num6));
        if (num5 < 0)
          pdfDictionary.Elements.Add("/BlackIs1", (PdfItem) new PdfBoolean(true));
        pdfDictionary.Elements.Add("/EndOfBlock", (PdfItem) new PdfBoolean(false));
        pdfDictionary.Elements.Add("/Columns", (PdfItem) new PdfInteger(pixelWidth));
        pdfDictionary.Elements.Add("/Rows", (PdfItem) new PdfInteger(pixelHeight));
        this.Elements["/DecodeParms"] = (PdfItem) pdfDictionary;
      }
      else
      {
        this.Stream = new PdfDictionary.PdfStream(numArray5, (PdfDictionary) this);
        this.Elements["/Length"] = (PdfItem) new PdfInteger(numArray5.Length);
        this.Elements["/Filter"] = (PdfItem) new PdfArray(this._document)
        {
          Elements = {
            (PdfItem) new PdfName("/FlateDecode"),
            (PdfItem) new PdfName("/CCITTFaxDecode")
          }
        };
        PdfArray pdfArray = new PdfArray(this._document);
        PdfDictionary pdfDictionary1 = new PdfDictionary();
        PdfDictionary pdfDictionary2 = new PdfDictionary();
        if (num6 != 0)
          pdfDictionary2.Elements.Add("/K", (PdfItem) new PdfInteger(num6));
        if (num5 < 0)
          pdfDictionary2.Elements.Add("/BlackIs1", (PdfItem) new PdfBoolean(true));
        pdfDictionary2.Elements.Add("/EndOfBlock", (PdfItem) new PdfBoolean(false));
        pdfDictionary2.Elements.Add("/Columns", (PdfItem) new PdfInteger(pixelWidth));
        pdfDictionary2.Elements.Add("/Rows", (PdfItem) new PdfInteger(pixelHeight));
        pdfArray.Elements.Add((PdfItem) pdfDictionary1);
        pdfArray.Elements.Add((PdfItem) pdfDictionary2);
        this.Elements["/DecodeParms"] = (PdfItem) pdfArray;
      }
    }
    else
    {
      this.Stream = new PdfDictionary.PdfStream(numArray4, (PdfDictionary) this);
      this.Elements["/Length"] = (PdfItem) new PdfInteger(numArray4.Length);
      this.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
    }
    this.Elements["/Width"] = (PdfItem) new PdfInteger(pixelWidth);
    this.Elements["/Height"] = (PdfItem) new PdfInteger(pixelHeight);
    this.Elements["/BitsPerComponent"] = (PdfItem) new PdfInteger(bits);
    if ((!flag4 || num5 != 0 ? (flag4 || num5 > 0 ? 0 : (!flag2 ? 1 : 0)) : 1) != 0)
    {
      PdfDictionary pdfDictionary = new PdfDictionary(this._document);
      byte[] numArray6 = data1.Length >= 48 /*0x30*/ ? flateDecode.Encode(data1, this._document.Options.FlateEncodeMode) : (byte[]) null;
      if ((numArray6 == null ? 0 : (numArray6.Length + 20 < data1.Length ? 1 : 0)) != 0)
      {
        pdfDictionary.CreateStream(numArray6);
        pdfDictionary.Elements["/Length"] = (PdfItem) new PdfInteger(numArray6.Length);
        pdfDictionary.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
      }
      else
      {
        pdfDictionary.CreateStream(data1);
        pdfDictionary.Elements["/Length"] = (PdfItem) new PdfInteger(data1.Length);
      }
      this.Owner._irefTable.Add((PdfObject) pdfDictionary);
      this.Elements["/ColorSpace"] = (PdfItem) new PdfArray(this._document)
      {
        Elements = {
          (PdfItem) new PdfName("/Indexed"),
          (PdfItem) new PdfName("/DeviceRGB"),
          (PdfItem) new PdfInteger(num4 - 1),
          (PdfItem) pdfDictionary.Reference
        }
      };
    }
    else
      this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceGray");
    if (!this._image.Interpolate)
      return;
    this.Elements["/Interpolate"] = (PdfItem) PdfBoolean.True;
  }

  private static uint CountOneBits(BitReader reader, uint bitsLeft)
  {
    uint num1 = 0;
    uint oneRun;
    while (true)
    {
      uint bits;
      int index = (int) reader.PeekByte(out bits);
      oneRun = PdfImage._oneRuns[index];
      if (oneRun >= bits)
      {
        num1 += bits;
        if (num1 < bitsLeft)
          reader.NextByte();
        else
          goto label_7;
      }
      else
        break;
    }
    if (oneRun > 0U)
      reader.SkipBits(oneRun);
    uint num2 = num1 + oneRun;
    uint num3 = num2 >= bitsLeft ? bitsLeft : num2;
    goto label_8;
label_7:
    num3 = bitsLeft;
label_8:
    return num3;
  }

  private static uint CountZeroBits(BitReader reader, uint bitsLeft)
  {
    uint num1 = 0;
    uint zeroRun;
    while (true)
    {
      uint bits;
      int index = (int) reader.PeekByte(out bits);
      zeroRun = PdfImage._zeroRuns[index];
      if (zeroRun >= bits)
      {
        num1 += bits;
        if (num1 < bitsLeft)
          reader.NextByte();
        else
          goto label_7;
      }
      else
        break;
    }
    if (zeroRun > 0U)
      reader.SkipBits(zeroRun);
    uint num2 = num1 + zeroRun;
    uint num3 = num2 >= bitsLeft ? bitsLeft : num2;
    goto label_8;
label_7:
    num3 = bitsLeft;
label_8:
    return num3;
  }

  private static uint FindDifference(BitReader reader, uint bitStart, uint bitEnd, bool searchOne)
  {
    reader.SetPosition(bitStart);
    return bitStart + (searchOne ? PdfImage.CountOneBits(reader, bitEnd - bitStart) : PdfImage.CountZeroBits(reader, bitEnd - bitStart));
  }

  private static uint FindDifferenceWithCheck(
    BitReader reader,
    uint bitStart,
    uint bitEnd,
    bool searchOne)
  {
    return bitStart < bitEnd ? PdfImage.FindDifference(reader, bitStart, bitEnd, searchOne) : bitEnd;
  }

  private static void FaxEncode2DRow(
    BitWriter writer,
    uint bytesFileOffset,
    byte[] imageBits,
    uint currentRow,
    uint referenceRow,
    uint width,
    uint height,
    uint bytesPerLineBmp)
  {
    uint bytesFileOffset1 = bytesFileOffset + (height - 1U - currentRow) * bytesPerLineBmp;
    BitReader reader1 = new BitReader(imageBits, bytesFileOffset1, width);
    BitReader reader2;
    if (referenceRow != uint.MaxValue)
    {
      uint bytesFileOffset2 = bytesFileOffset + (height - 1U - referenceRow) * bytesPerLineBmp;
      reader2 = new BitReader(imageBits, bytesFileOffset2, width);
    }
    else
    {
      byte[] imageBits1 = new byte[(int) bytesPerLineBmp];
      for (int index = 0; (long) index < (long) bytesPerLineBmp; ++index)
        imageBits1[index] = byte.MaxValue;
      reader2 = new BitReader(imageBits1, 0U, width);
    }
    uint num1 = 0;
    uint difference1 = !reader1.GetBit(0U) ? 0U : PdfImage.FindDifference(reader1, 0U, width, true);
    uint num2 = !reader2.GetBit(0U) ? 0U : PdfImage.FindDifference(reader2, 0U, width, true);
    while (true)
    {
      uint differenceWithCheck1 = PdfImage.FindDifferenceWithCheck(reader2, num2, width, reader2.GetBit(num2));
      if (differenceWithCheck1 < difference1)
      {
        writer.WriteTableLine(PdfImage.PassCodes, 0U);
        num1 = differenceWithCheck1;
      }
      else
        goto label_10;
label_8:
      if (num1 < width)
      {
        bool bit = reader1.GetBit(num1);
        difference1 = PdfImage.FindDifference(reader1, num1, width, bit);
        uint difference2 = PdfImage.FindDifference(reader2, num1, width, !bit);
        num2 = PdfImage.FindDifferenceWithCheck(reader2, difference2, width, bit);
        continue;
      }
      break;
label_10:
      int num3 = (int) num2 - (int) difference1;
      if ((-3 > num3 ? 1 : (num3 > 3 ? 1 : 0)) != 0)
      {
        uint differenceWithCheck2 = PdfImage.FindDifferenceWithCheck(reader1, difference1, width, reader1.GetBit(difference1));
        writer.WriteTableLine(PdfImage.HorizontalCodes, 0U);
        if (((int) num1 + (int) difference1 == 0 ? 1 : (reader1.GetBit(num1) ? 1 : 0)) != 0)
        {
          PdfImage.WriteSample(writer, difference1 - num1, true);
          PdfImage.WriteSample(writer, differenceWithCheck2 - difference1, false);
        }
        else
        {
          PdfImage.WriteSample(writer, difference1 - num1, false);
          PdfImage.WriteSample(writer, differenceWithCheck2 - difference1, true);
        }
        num1 = differenceWithCheck2;
        goto label_8;
      }
      writer.WriteTableLine(PdfImage.VerticalCodes, (uint) (num3 + 3));
      num1 = difference1;
      goto label_8;
    }
  }

  private static int DoFaxEncoding(
    ref byte[] imageData,
    byte[] imageBits,
    uint bytesFileOffset,
    uint width,
    uint height)
  {
    try
    {
      uint num1 = (width + 31U /*0x1F*/) / 32U /*0x20*/ * 4U;
      BitWriter writer = new BitWriter(ref imageData);
      for (uint index = 0; index < height; ++index)
      {
        uint bytesFileOffset1 = bytesFileOffset + (height - 1U - index) * num1;
        BitReader reader = new BitReader(imageBits, bytesFileOffset1, width);
        uint num2 = 0;
        while (num2 < width)
        {
          uint count1 = PdfImage.CountOneBits(reader, width - num2);
          PdfImage.WriteSample(writer, count1, true);
          num2 += count1;
          if (num2 < width)
          {
            uint count2 = PdfImage.CountZeroBits(reader, width - num2);
            PdfImage.WriteSample(writer, count2, false);
            num2 += count2;
          }
        }
      }
      writer.FlushBuffer();
      return writer.BytesWritten();
    }
    catch (Exception ex)
    {
      return 0;
    }
  }

  internal static int DoFaxEncodingGroup4(
    ref byte[] imageData,
    byte[] imageBits,
    uint bytesFileOffset,
    uint width,
    uint height)
  {
    try
    {
      uint bytesPerLineBmp = (width + 31U /*0x1F*/) / 32U /*0x20*/ * 4U;
      BitWriter writer = new BitWriter(ref imageData);
      for (uint currentRow = 0; currentRow < height; ++currentRow)
        PdfImage.FaxEncode2DRow(writer, bytesFileOffset, imageBits, currentRow, currentRow != 0U ? currentRow - 1U : uint.MaxValue, width, height, bytesPerLineBmp);
      writer.FlushBuffer();
      return writer.BytesWritten();
    }
    catch (Exception ex)
    {
      ex.GetType();
      return 0;
    }
  }

  private static void WriteSample(BitWriter writer, uint count, bool white)
  {
    uint[] table1 = white ? PdfImage.WhiteTerminatingCodes : PdfImage.BlackTerminatingCodes;
    uint[] table2 = white ? PdfImage.WhiteMakeUpCodes : PdfImage.BlackMakeUpCodes;
    for (; count >= 2624U; count -= 2560U /*0x0A00*/)
      writer.WriteTableLine(table2, 39U);
    if (count > 63U /*0x3F*/)
    {
      uint line = count / 64U /*0x40*/ - 1U;
      writer.WriteTableLine(table2, line);
      count -= (uint) (((int) line + 1) * 64 /*0x40*/);
    }
    writer.WriteTableLine(table1, count);
  }

  public new sealed class Keys : PdfXObject.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string Subtype = "/Subtype";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string Width = "/Width";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string Height = "/Height";
    [KeyInfo(KeyType.NameOrArray | KeyType.Required)]
    public const string ColorSpace = "/ColorSpace";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string BitsPerComponent = "/BitsPerComponent";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Intent = "/Intent";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string ImageMask = "/ImageMask";
    [KeyInfo(KeyType.StreamOrArray | KeyType.Optional)]
    public const string Mask = "/Mask";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Decode = "/Decode";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string Interpolate = "/Interpolate";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Alternates = "/Alternates";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string SMask = "/SMask";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string SMaskInData = "/SMaskInData";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Name = "/Name";
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string StructParent = "/StructParent";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string ID = "/ID";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string OPI = "/OPI";
    [KeyInfo(KeyType.Stream | KeyType.Optional)]
    public const string Metadata = "/Metadata";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string OC = "/OC";
  }
}

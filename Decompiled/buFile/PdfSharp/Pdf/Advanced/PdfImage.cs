#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Internal;
using PdfSharp.Pdf.Filters;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfImage : PdfXObject
{
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

	private readonly XImage _image;

	internal static readonly uint[] WhiteTerminatingCodes = new uint[128]
	{
		53u, 8u, 7u, 6u, 7u, 4u, 8u, 4u, 11u, 4u,
		12u, 4u, 14u, 4u, 15u, 4u, 19u, 5u, 20u, 5u,
		7u, 5u, 8u, 5u, 8u, 6u, 3u, 6u, 52u, 6u,
		53u, 6u, 42u, 6u, 43u, 6u, 39u, 7u, 12u, 7u,
		8u, 7u, 23u, 7u, 3u, 7u, 4u, 7u, 40u, 7u,
		43u, 7u, 19u, 7u, 36u, 7u, 24u, 7u, 2u, 8u,
		3u, 8u, 26u, 8u, 27u, 8u, 18u, 8u, 19u, 8u,
		20u, 8u, 21u, 8u, 22u, 8u, 23u, 8u, 40u, 8u,
		41u, 8u, 42u, 8u, 43u, 8u, 44u, 8u, 45u, 8u,
		4u, 8u, 5u, 8u, 10u, 8u, 11u, 8u, 82u, 8u,
		83u, 8u, 84u, 8u, 85u, 8u, 36u, 8u, 37u, 8u,
		88u, 8u, 89u, 8u, 90u, 8u, 91u, 8u, 74u, 8u,
		75u, 8u, 50u, 8u, 51u, 8u, 52u, 8u
	};

	internal static readonly uint[] BlackTerminatingCodes = new uint[128]
	{
		55u, 10u, 2u, 3u, 3u, 2u, 2u, 2u, 3u, 3u,
		3u, 4u, 2u, 4u, 3u, 5u, 5u, 6u, 4u, 6u,
		4u, 7u, 5u, 7u, 7u, 7u, 4u, 8u, 7u, 8u,
		24u, 9u, 23u, 10u, 24u, 10u, 8u, 10u, 103u, 11u,
		104u, 11u, 108u, 11u, 55u, 11u, 40u, 11u, 23u, 11u,
		24u, 11u, 202u, 12u, 203u, 12u, 204u, 12u, 205u, 12u,
		104u, 12u, 105u, 12u, 106u, 12u, 107u, 12u, 210u, 12u,
		211u, 12u, 212u, 12u, 213u, 12u, 214u, 12u, 215u, 12u,
		108u, 12u, 109u, 12u, 218u, 12u, 219u, 12u, 84u, 12u,
		85u, 12u, 86u, 12u, 87u, 12u, 100u, 12u, 101u, 12u,
		82u, 12u, 83u, 12u, 36u, 12u, 55u, 12u, 56u, 12u,
		39u, 12u, 40u, 12u, 88u, 12u, 89u, 12u, 43u, 12u,
		44u, 12u, 90u, 12u, 102u, 12u, 103u, 12u
	};

	internal static readonly uint[] WhiteMakeUpCodes = new uint[82]
	{
		27u, 5u, 18u, 5u, 23u, 6u, 55u, 7u, 54u, 8u,
		55u, 8u, 100u, 8u, 101u, 8u, 104u, 8u, 103u, 8u,
		204u, 9u, 205u, 9u, 210u, 9u, 211u, 9u, 212u, 9u,
		213u, 9u, 214u, 9u, 215u, 9u, 216u, 9u, 217u, 9u,
		218u, 9u, 219u, 9u, 152u, 9u, 153u, 9u, 154u, 9u,
		24u, 6u, 155u, 9u, 8u, 11u, 12u, 11u, 13u, 11u,
		18u, 12u, 19u, 12u, 20u, 12u, 21u, 12u, 22u, 12u,
		23u, 12u, 28u, 12u, 29u, 12u, 30u, 12u, 31u, 12u,
		1u, 12u
	};

	internal static readonly uint[] BlackMakeUpCodes = new uint[82]
	{
		15u, 10u, 200u, 12u, 201u, 12u, 91u, 12u, 51u, 12u,
		52u, 12u, 53u, 12u, 108u, 13u, 109u, 13u, 74u, 13u,
		75u, 13u, 76u, 13u, 77u, 13u, 114u, 13u, 115u, 13u,
		116u, 13u, 117u, 13u, 118u, 13u, 119u, 13u, 82u, 13u,
		83u, 13u, 84u, 13u, 85u, 13u, 90u, 13u, 91u, 13u,
		100u, 13u, 101u, 13u, 8u, 11u, 12u, 11u, 13u, 11u,
		18u, 12u, 19u, 12u, 20u, 12u, 21u, 12u, 22u, 12u,
		23u, 12u, 28u, 12u, 29u, 12u, 30u, 12u, 31u, 12u,
		1u, 12u
	};

	internal static readonly uint[] HorizontalCodes = new uint[2] { 1u, 3u };

	internal static readonly uint[] PassCodes = new uint[2] { 1u, 4u };

	internal static readonly uint[] VerticalCodes = new uint[14]
	{
		3u, 7u, 3u, 6u, 3u, 3u, 1u, 1u, 2u, 3u,
		2u, 6u, 2u, 7u
	};

	private static readonly uint[] _zeroRuns = new uint[256]
	{
		8u, 7u, 6u, 6u, 5u, 5u, 5u, 5u, 4u, 4u,
		4u, 4u, 4u, 4u, 4u, 4u, 3u, 3u, 3u, 3u,
		3u, 3u, 3u, 3u, 3u, 3u, 3u, 3u, 3u, 3u,
		3u, 3u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u,
		2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u,
		2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u,
		2u, 2u, 2u, 2u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u
	};

	private static readonly uint[] _oneRuns = new uint[256]
	{
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u,
		0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u,
		1u, 1u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u,
		2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u,
		2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u, 2u,
		2u, 2u, 2u, 2u, 3u, 3u, 3u, 3u, 3u, 3u,
		3u, 3u, 3u, 3u, 3u, 3u, 3u, 3u, 3u, 3u,
		4u, 4u, 4u, 4u, 4u, 4u, 4u, 4u, 5u, 5u,
		5u, 5u, 6u, 6u, 7u, 8u
	};

	public XImage Image => _image;

	public PdfImage(PdfDocument document, XImage image)
		: base(document)
	{
		base.Elements.SetName("/Type", "/XObject");
		base.Elements.SetName("/Subtype", "/Image");
		_image = image;
		switch (_image.Format.Guid.ToString("B").ToUpper())
		{
		case "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}":
			InitializeJpeg();
			break;
		case "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}":
		case "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}":
		case "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}":
		case "{B96B3CB5-0728-11D3-9D7B-0000F81EF32E}":
			InitializeNonJpeg();
			break;
		case "{84570158-DBF0-4C6B-8368-62D6A3CA76E0}":
			Debug.Assert(condition: false, "XPdfForm not expected here.");
			break;
		default:
			Debug.Assert(condition: false, "Unexpected image type.");
			break;
		}
	}

	public override string ToString()
	{
		return "Image";
	}

	private void InitializeJpeg()
	{
		MemoryStream memoryStream = null;
		bool flag = false;
		byte[] array = null;
		int num = 0;
		if (_image._importedImage != null)
		{
			ImageDataDct imageDataDct = (ImageDataDct)_image._importedImage.ImageData;
			array = imageDataDct.Data;
			num = imageDataDct.Length;
		}
		if (_image._importedImage == null)
		{
			if (!_image._path.StartsWith("*"))
			{
				using FileStream fileStream = File.OpenRead(_image._path);
				byte[] array2 = new byte[8192];
				memoryStream = new MemoryStream((int)fileStream.Length);
				flag = true;
				int num2;
				do
				{
					num2 = fileStream.Read(array2, 0, array2.Length);
					memoryStream.Write(array2, 0, num2);
				}
				while (num2 > 0);
			}
			else
			{
				memoryStream = new MemoryStream();
				flag = true;
				if (_image._stream != null && _image._stream.CanSeek)
				{
					Stream stream = _image._stream;
					stream.Seek(0L, SeekOrigin.Begin);
					byte[] array3 = new byte[32768];
					int count;
					while ((count = stream.Read(array3, 0, array3.Length)) > 0)
					{
						memoryStream.Write(array3, 0, count);
					}
				}
				else
				{
					_image._gdiImage.Save(memoryStream, ImageFormat.Jpeg);
				}
			}
			if ((int)memoryStream.Length == 0)
			{
				Debug.Assert(condition: false, "Internal error? JPEG image, but file not found!");
			}
		}
		if (array == null)
		{
			num = (int)memoryStream.Length;
			array = new byte[num];
			memoryStream.Seek(0L, SeekOrigin.Begin);
			memoryStream.Read(array, 0, num);
			if (flag)
			{
				memoryStream.Dispose();
			}
		}
		bool flag2 = _document.Options.UseFlateDecoderForJpegImages == PdfUseFlateDecoderForJpegImages.Automatic;
		bool flag3 = _document.Options.UseFlateDecoderForJpegImages == PdfUseFlateDecoderForJpegImages.Always;
		FlateDecode flateDecode = new FlateDecode();
		byte[] array4 = ((flag3 || flag2) ? flateDecode.Encode(array, _document.Options.FlateEncodeMode) : null);
		if (flag3 || (flag2 && array4.Length < array.Length))
		{
			base.Stream = new PdfStream(array4, this);
			base.Elements["/Length"] = new PdfInteger(array4.Length);
			PdfArray pdfArray = new PdfArray(_document);
			pdfArray.Elements.Add(new PdfName("/FlateDecode"));
			pdfArray.Elements.Add(new PdfName("/DCTDecode"));
			base.Elements["/Filter"] = pdfArray;
		}
		else
		{
			base.Stream = new PdfStream(array, this);
			base.Elements["/Length"] = new PdfInteger(num);
			base.Elements["/Filter"] = new PdfName("/DCTDecode");
		}
		if (_image.Interpolate)
		{
			base.Elements["/Interpolate"] = PdfBoolean.True;
		}
		base.Elements["/Width"] = new PdfInteger(_image.PixelWidth);
		base.Elements["/Height"] = new PdfInteger(_image.PixelHeight);
		base.Elements["/BitsPerComponent"] = new PdfInteger(8);
		if (_image._importedImage != null)
		{
			if (_image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGCMYK || _image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGRGBW)
			{
				base.Elements["/ColorSpace"] = new PdfName("/DeviceCMYK");
				if (_image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGRGBW)
				{
					base.Elements["/Decode"] = new PdfLiteral("[1 0 1 0 1 0 1 0]");
				}
			}
			else if (_image._importedImage.Information.ImageFormat == ImageInformation.ImageFormats.JPEGGRAY)
			{
				base.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
			}
			else
			{
				base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
			}
		}
		if (_image._importedImage != null)
		{
			return;
		}
		if ((_image._gdiImage.Flags & 0x120) != 0)
		{
			base.Elements["/ColorSpace"] = new PdfName("/DeviceCMYK");
			if ((_image._gdiImage.Flags & 0x100) != 0)
			{
				base.Elements["/Decode"] = new PdfLiteral("[1 0 1 0 1 0 1 0]");
			}
		}
		else if ((_image._gdiImage.Flags & 0x40) != 0)
		{
			base.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
		}
		else
		{
			base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
		}
	}

	private void InitializeNonJpeg()
	{
		if (_image._importedImage != null)
		{
			switch (_image._importedImage.Information.ImageFormat)
			{
			case ImageInformation.ImageFormats.RGB24:
				CreateTrueColorMemoryBitmap(3, 8, hasAlpha: false);
				break;
			case ImageInformation.ImageFormats.Palette8:
				CreateIndexedMemoryBitmap(8);
				break;
			case ImageInformation.ImageFormats.Palette4:
				CreateIndexedMemoryBitmap(4);
				break;
			case ImageInformation.ImageFormats.Palette1:
				CreateIndexedMemoryBitmap(1);
				break;
			default:
				throw new NotImplementedException("Image format not supported.");
			}
			return;
		}
		switch (_image._gdiImage.PixelFormat)
		{
		case PixelFormat.Format24bppRgb:
			ReadTrueColorMemoryBitmap(3, 8, hasAlpha: false);
			break;
		case PixelFormat.Format32bppRgb:
			ReadTrueColorMemoryBitmap(4, 8, hasAlpha: false);
			break;
		case PixelFormat.Format32bppPArgb:
		case PixelFormat.Format32bppArgb:
			ReadTrueColorMemoryBitmap(3, 8, hasAlpha: true);
			break;
		case PixelFormat.Format8bppIndexed:
			ReadIndexedMemoryBitmap(8);
			break;
		case PixelFormat.Format4bppIndexed:
			ReadIndexedMemoryBitmap(4);
			break;
		case PixelFormat.Format1bppIndexed:
			ReadIndexedMemoryBitmap(1);
			break;
		default:
			throw new NotImplementedException("Image format not supported.");
		}
	}

	private void CreateIndexedMemoryBitmap(int bits)
	{
		ImageDataBitmap imageDataBitmap = (ImageDataBitmap)_image._importedImage.ImageData;
		ImageInformation information = _image._importedImage.Information;
		int version = Owner.Version;
		int num = -1;
		int num2 = -1;
		bool segmentedColorMask = imageDataBitmap.SegmentedColorMask;
		FlateDecode flateDecode = new FlateDecode();
		if (num != -1 && num2 != -1)
		{
			if (!segmentedColorMask && version >= 13 && !imageDataBitmap.IsGray)
			{
				PdfArray pdfArray = new PdfArray(_document);
				pdfArray.Elements.Add(new PdfInteger(num));
				pdfArray.Elements.Add(new PdfInteger(num2));
				base.Elements["/Mask"] = pdfArray;
			}
			else
			{
				byte[] array = flateDecode.Encode(imageDataBitmap.BitmapMask, _document.Options.FlateEncodeMode);
				PdfDictionary pdfDictionary = new PdfDictionary(_document);
				pdfDictionary.Elements.SetName("/Type", "/XObject");
				pdfDictionary.Elements.SetName("/Subtype", "/Image");
				Owner._irefTable.Add(pdfDictionary);
				pdfDictionary.Stream = new PdfStream(array, pdfDictionary);
				pdfDictionary.Elements["/Length"] = new PdfInteger(array.Length);
				pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
				pdfDictionary.Elements["/Width"] = new PdfInteger((int)information.Width);
				pdfDictionary.Elements["/Height"] = new PdfInteger((int)information.Height);
				pdfDictionary.Elements["/BitsPerComponent"] = new PdfInteger(1);
				pdfDictionary.Elements["/ImageMask"] = new PdfBoolean(value: true);
				base.Elements["/Mask"] = pdfDictionary.Reference;
			}
		}
		byte[] array2 = flateDecode.Encode(imageDataBitmap.Data, _document.Options.FlateEncodeMode);
		byte[] array3 = ((imageDataBitmap.DataFax != null) ? flateDecode.Encode(imageDataBitmap.DataFax, _document.Options.FlateEncodeMode) : null);
		bool flag = false;
		if (imageDataBitmap.DataFax != null && (imageDataBitmap.LengthFax < array2.Length || array3.Length < array2.Length))
		{
			flag = true;
			if (imageDataBitmap.LengthFax < array2.Length)
			{
				base.Stream = new PdfStream(imageDataBitmap.DataFax, this);
				base.Elements["/Length"] = new PdfInteger(imageDataBitmap.LengthFax);
				base.Elements["/Filter"] = new PdfName("/CCITTFaxDecode");
				PdfDictionary pdfDictionary2 = new PdfDictionary();
				if (imageDataBitmap.K != 0)
				{
					pdfDictionary2.Elements.Add("/K", new PdfInteger(imageDataBitmap.K));
				}
				if (imageDataBitmap.IsBitonal < 0)
				{
					pdfDictionary2.Elements.Add("/BlackIs1", new PdfBoolean(value: true));
				}
				pdfDictionary2.Elements.Add("/EndOfBlock", new PdfBoolean(value: false));
				pdfDictionary2.Elements.Add("/Columns", new PdfInteger((int)information.Width));
				pdfDictionary2.Elements.Add("/Rows", new PdfInteger((int)information.Height));
				base.Elements["/DecodeParms"] = pdfDictionary2;
			}
			else
			{
				base.Stream = new PdfStream(array3, this);
				base.Elements["/Length"] = new PdfInteger(array3.Length);
				PdfArray pdfArray2 = new PdfArray(_document);
				pdfArray2.Elements.Add(new PdfName("/FlateDecode"));
				pdfArray2.Elements.Add(new PdfName("/CCITTFaxDecode"));
				base.Elements["/Filter"] = pdfArray2;
				PdfArray pdfArray3 = new PdfArray(_document);
				PdfDictionary value = new PdfDictionary();
				PdfDictionary pdfDictionary3 = new PdfDictionary();
				if (imageDataBitmap.K != 0)
				{
					pdfDictionary3.Elements.Add("/K", new PdfInteger(imageDataBitmap.K));
				}
				if (imageDataBitmap.IsBitonal < 0)
				{
					pdfDictionary3.Elements.Add("/BlackIs1", new PdfBoolean(value: true));
				}
				pdfDictionary3.Elements.Add("/EndOfBlock", new PdfBoolean(value: false));
				pdfDictionary3.Elements.Add("/Columns", new PdfInteger((int)information.Width));
				pdfDictionary3.Elements.Add("/Rows", new PdfInteger((int)information.Height));
				pdfArray3.Elements.Add(value);
				pdfArray3.Elements.Add(pdfDictionary3);
				base.Elements["/DecodeParms"] = pdfArray3;
			}
		}
		else
		{
			base.Stream = new PdfStream(array2, this);
			base.Elements["/Length"] = new PdfInteger(array2.Length);
			base.Elements["/Filter"] = new PdfName("/FlateDecode");
		}
		base.Elements["/Width"] = new PdfInteger((int)information.Width);
		base.Elements["/Height"] = new PdfInteger((int)information.Height);
		base.Elements["/BitsPerComponent"] = new PdfInteger(bits);
		if ((flag && imageDataBitmap.IsBitonal == 0) || (!flag && imageDataBitmap.IsBitonal <= 0 && !imageDataBitmap.IsGray))
		{
			PdfDictionary pdfDictionary4 = null;
			pdfDictionary4 = new PdfDictionary(_document);
			byte[] array4 = ((imageDataBitmap.PaletteDataLength >= 48) ? flateDecode.Encode(imageDataBitmap.PaletteData, _document.Options.FlateEncodeMode) : null);
			if (array4 != null && array4.Length + 20 < imageDataBitmap.PaletteDataLength)
			{
				pdfDictionary4.CreateStream(array4);
				pdfDictionary4.Elements["/Length"] = new PdfInteger(array4.Length);
				pdfDictionary4.Elements["/Filter"] = new PdfName("/FlateDecode");
			}
			else
			{
				pdfDictionary4.CreateStream(imageDataBitmap.PaletteData);
				pdfDictionary4.Elements["/Length"] = new PdfInteger(imageDataBitmap.PaletteDataLength);
			}
			Owner._irefTable.Add(pdfDictionary4);
			PdfArray pdfArray4 = new PdfArray(_document);
			pdfArray4.Elements.Add(new PdfName("/Indexed"));
			pdfArray4.Elements.Add(new PdfName("/DeviceRGB"));
			pdfArray4.Elements.Add(new PdfInteger((int)(information.ColorsUsed - 1)));
			pdfArray4.Elements.Add(pdfDictionary4.Reference);
			base.Elements["/ColorSpace"] = pdfArray4;
		}
		else
		{
			base.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
		}
		if (_image.Interpolate)
		{
			base.Elements["/Interpolate"] = PdfBoolean.True;
		}
	}

	private void CreateTrueColorMemoryBitmap(int components, int bits, bool hasAlpha)
	{
		int version = Owner.Version;
		FlateDecode flateDecode = new FlateDecode();
		ImageDataBitmap imageDataBitmap = (ImageDataBitmap)_image._importedImage.ImageData;
		ImageInformation information = _image._importedImage.Information;
		bool flag = imageDataBitmap.AlphaMaskLength > 0 || imageDataBitmap.BitmapMaskLength > 0;
		bool flag2 = imageDataBitmap.AlphaMaskLength > 0;
		if (flag)
		{
			byte[] array = flateDecode.Encode(imageDataBitmap.BitmapMask, _document.Options.FlateEncodeMode);
			PdfDictionary pdfDictionary = new PdfDictionary(_document);
			pdfDictionary.Elements.SetName("/Type", "/XObject");
			pdfDictionary.Elements.SetName("/Subtype", "/Image");
			Owner._irefTable.Add(pdfDictionary);
			pdfDictionary.Stream = new PdfStream(array, pdfDictionary);
			pdfDictionary.Elements["/Length"] = new PdfInteger(array.Length);
			pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
			pdfDictionary.Elements["/Width"] = new PdfInteger((int)information.Width);
			pdfDictionary.Elements["/Height"] = new PdfInteger((int)information.Height);
			pdfDictionary.Elements["/BitsPerComponent"] = new PdfInteger(1);
			pdfDictionary.Elements["/ImageMask"] = new PdfBoolean(value: true);
			base.Elements["/Mask"] = pdfDictionary.Reference;
		}
		if (flag && flag2 && version >= 14)
		{
			byte[] array2 = flateDecode.Encode(imageDataBitmap.AlphaMask, _document.Options.FlateEncodeMode);
			PdfDictionary pdfDictionary2 = new PdfDictionary(_document);
			pdfDictionary2.Elements.SetName("/Type", "/XObject");
			pdfDictionary2.Elements.SetName("/Subtype", "/Image");
			Owner._irefTable.Add(pdfDictionary2);
			pdfDictionary2.Stream = new PdfStream(array2, pdfDictionary2);
			pdfDictionary2.Elements["/Length"] = new PdfInteger(array2.Length);
			pdfDictionary2.Elements["/Filter"] = new PdfName("/FlateDecode");
			pdfDictionary2.Elements["/Width"] = new PdfInteger((int)information.Width);
			pdfDictionary2.Elements["/Height"] = new PdfInteger((int)information.Height);
			pdfDictionary2.Elements["/BitsPerComponent"] = new PdfInteger(8);
			pdfDictionary2.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
			base.Elements["/SMask"] = pdfDictionary2.Reference;
		}
		byte[] array3 = flateDecode.Encode(imageDataBitmap.Data, _document.Options.FlateEncodeMode);
		base.Stream = new PdfStream(array3, this);
		base.Elements["/Length"] = new PdfInteger(array3.Length);
		base.Elements["/Filter"] = new PdfName("/FlateDecode");
		base.Elements["/Width"] = new PdfInteger((int)information.Width);
		base.Elements["/Height"] = new PdfInteger((int)information.Height);
		base.Elements["/BitsPerComponent"] = new PdfInteger(8);
		base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
		if (_image.Interpolate)
		{
			base.Elements["/Interpolate"] = PdfBoolean.True;
		}
	}

	private static int ReadWord(byte[] ab, int offset)
	{
		return ab[offset] + 256 * ab[offset + 1];
	}

	private static int ReadDWord(byte[] ab, int offset)
	{
		return ReadWord(ab, offset) + 65536 * ReadWord(ab, offset + 2);
	}

	private void ReadTrueColorMemoryBitmap(int components, int bits, bool hasAlpha)
	{
		int version = Owner.Version;
		MemoryStream memoryStream = new MemoryStream();
		_image._gdiImage.Save(memoryStream, ImageFormat.Bmp);
		int num = (int)memoryStream.Length;
		Debug.Assert(num > 0, "Bitmap image encoding failed.");
		if (num <= 0)
		{
			return;
		}
		byte[] buffer = memoryStream.GetBuffer();
		int pixelHeight = _image.PixelHeight;
		int pixelWidth = _image.PixelWidth;
		if (ReadWord(buffer, 0) != 19778 || ReadDWord(buffer, 2) != num || ReadDWord(buffer, 14) != 40 || ReadDWord(buffer, 18) != pixelWidth || ReadDWord(buffer, 22) != pixelHeight)
		{
			throw new NotImplementedException("ReadTrueColorMemoryBitmap: unsupported format");
		}
		if (ReadWord(buffer, 26) != 1 || (!hasAlpha && ReadWord(buffer, 28) != components * bits) || (hasAlpha && ReadWord(buffer, 28) != (components + 1) * bits) || ReadDWord(buffer, 30) != 0)
		{
			throw new NotImplementedException("ReadTrueColorMemoryBitmap: unsupported format #2");
		}
		int num2 = ReadDWord(buffer, 10);
		int num3 = components;
		if (components == 4)
		{
			num3 = 3;
		}
		byte[] array = new byte[components * pixelWidth * pixelHeight];
		bool flag = false;
		bool flag2 = false;
		byte[] array2 = (hasAlpha ? new byte[pixelWidth * pixelHeight] : null);
		MonochromeMask monochromeMask = (hasAlpha ? new MonochromeMask(pixelWidth, pixelHeight) : null);
		int num4 = 0;
		if (num3 == 3)
		{
			for (int i = 0; i < pixelHeight; i++)
			{
				int num5 = 3 * (pixelHeight - 1 - i) * pixelWidth;
				int num6 = 0;
				if (hasAlpha)
				{
					monochromeMask.StartLine(i);
					num6 = (pixelHeight - 1 - i) * pixelWidth;
				}
				for (int j = 0; j < pixelWidth; j++)
				{
					array[num5] = buffer[num2 + num4 + 2];
					array[num5 + 1] = buffer[num2 + num4 + 1];
					array[num5 + 2] = buffer[num2 + num4];
					if (hasAlpha)
					{
						monochromeMask.AddPel(buffer[num2 + num4 + 3]);
						array2[num6] = buffer[num2 + num4 + 3];
						if ((!flag || !flag2) && buffer[num2 + num4 + 3] != byte.MaxValue)
						{
							flag = true;
							if (buffer[num2 + num4 + 3] != 0)
							{
								flag2 = true;
							}
						}
						num6++;
					}
					num4 += (hasAlpha ? 4 : components);
					num5 += 3;
				}
				num4 = 4 * ((num4 + 3) / 4);
			}
		}
		else if (components == 1)
		{
			throw new NotImplementedException("Image format not supported (grayscales).");
		}
		FlateDecode flateDecode = new FlateDecode();
		if (flag)
		{
			byte[] array3 = flateDecode.Encode(monochromeMask.MaskData, _document.Options.FlateEncodeMode);
			PdfDictionary pdfDictionary = new PdfDictionary(_document);
			pdfDictionary.Elements.SetName("/Type", "/XObject");
			pdfDictionary.Elements.SetName("/Subtype", "/Image");
			Owner._irefTable.Add(pdfDictionary);
			pdfDictionary.Stream = new PdfStream(array3, pdfDictionary);
			pdfDictionary.Elements["/Length"] = new PdfInteger(array3.Length);
			pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
			pdfDictionary.Elements["/Width"] = new PdfInteger(pixelWidth);
			pdfDictionary.Elements["/Height"] = new PdfInteger(pixelHeight);
			pdfDictionary.Elements["/BitsPerComponent"] = new PdfInteger(1);
			pdfDictionary.Elements["/ImageMask"] = new PdfBoolean(value: true);
			base.Elements["/Mask"] = pdfDictionary.Reference;
		}
		if (flag && flag2 && version >= 14)
		{
			byte[] array4 = flateDecode.Encode(array2, _document.Options.FlateEncodeMode);
			PdfDictionary pdfDictionary2 = new PdfDictionary(_document);
			pdfDictionary2.Elements.SetName("/Type", "/XObject");
			pdfDictionary2.Elements.SetName("/Subtype", "/Image");
			Owner._irefTable.Add(pdfDictionary2);
			pdfDictionary2.Stream = new PdfStream(array4, pdfDictionary2);
			pdfDictionary2.Elements["/Length"] = new PdfInteger(array4.Length);
			pdfDictionary2.Elements["/Filter"] = new PdfName("/FlateDecode");
			pdfDictionary2.Elements["/Width"] = new PdfInteger(pixelWidth);
			pdfDictionary2.Elements["/Height"] = new PdfInteger(pixelHeight);
			pdfDictionary2.Elements["/BitsPerComponent"] = new PdfInteger(8);
			pdfDictionary2.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
			base.Elements["/SMask"] = pdfDictionary2.Reference;
		}
		byte[] array5 = flateDecode.Encode(array, _document.Options.FlateEncodeMode);
		base.Stream = new PdfStream(array5, this);
		base.Elements["/Length"] = new PdfInteger(array5.Length);
		base.Elements["/Filter"] = new PdfName("/FlateDecode");
		base.Elements["/Width"] = new PdfInteger(pixelWidth);
		base.Elements["/Height"] = new PdfInteger(pixelHeight);
		base.Elements["/BitsPerComponent"] = new PdfInteger(8);
		base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
		if (_image.Interpolate)
		{
			base.Elements["/Interpolate"] = PdfBoolean.True;
		}
	}

	private void ReadIndexedMemoryBitmap(int bits)
	{
		int version = Owner.Version;
		int num = -1;
		int num2 = -1;
		bool flag = false;
		MemoryStream memoryStream = new MemoryStream();
		_image._gdiImage.Save(memoryStream, ImageFormat.Bmp);
		int num3 = (int)memoryStream.Length;
		Debug.Assert(num3 > 0, "Bitmap image encoding failed.");
		if (num3 <= 0)
		{
			return;
		}
		byte[] array = new byte[num3];
		memoryStream.Seek(0L, SeekOrigin.Begin);
		memoryStream.Read(array, 0, num3);
		memoryStream.Close();
		int pixelHeight = _image.PixelHeight;
		int pixelWidth = _image.PixelWidth;
		if (ReadWord(array, 0) != 19778 || ReadDWord(array, 2) != num3 || ReadDWord(array, 14) != 40 || ReadDWord(array, 18) != pixelWidth || ReadDWord(array, 22) != pixelHeight)
		{
			throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format");
		}
		int num4 = ReadWord(array, 28);
		if (num4 != bits && (num4 == 1 || num4 == 4 || num4 == 8))
		{
			bits = num4;
		}
		if (ReadWord(array, 26) != 1 || ReadWord(array, 28) != bits || ReadDWord(array, 30) != 0)
		{
			throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #2");
		}
		int num5 = ReadDWord(array, 10);
		int num6 = ReadDWord(array, 46);
		if ((num5 - 54) / 4 != num6)
		{
			throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #3");
		}
		MonochromeMask monochromeMask = new MonochromeMask(pixelWidth, pixelHeight);
		bool flag2 = bits == 8 && (num6 == 256 || num6 == 0);
		int num7 = 0;
		byte[] array2 = new byte[3 * num6];
		for (int i = 0; i < num6; i++)
		{
			array2[3 * i] = array[54 + 4 * i + 2];
			array2[3 * i + 1] = array[54 + 4 * i + 1];
			array2[3 * i + 2] = array[54 + 4 * i];
			if (flag2)
			{
				flag2 = array2[3 * i] == array2[3 * i + 1] && array2[3 * i] == array2[3 * i + 2];
			}
			if (array[54 + 4 * i + 3] < 128)
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
					flag = true;
				}
			}
		}
		if (bits == 1)
		{
			if (num6 == 0)
			{
				num7 = 1;
			}
			if (num6 == 2)
			{
				if (array2[0] == 0 && array2[1] == 0 && array2[2] == 0 && array2[3] == byte.MaxValue && array2[4] == byte.MaxValue && array2[5] == byte.MaxValue)
				{
					num7 = 1;
				}
				if (array2[5] == 0 && array2[4] == 0 && array2[3] == 0 && array2[2] == byte.MaxValue && array2[1] == byte.MaxValue && array2[0] == byte.MaxValue)
				{
					num7 = -1;
				}
			}
		}
		bool flag3 = false;
		byte[] array3 = new byte[(pixelWidth * bits + 7) / 8 * pixelHeight];
		byte[] array4 = null;
		int num8 = 0;
		if (bits == 1)
		{
			byte[] imageData = new byte[array3.Length];
			int num9 = DoFaxEncodingGroup4(ref imageData, array, (uint)num5, (uint)pixelWidth, (uint)pixelHeight);
			flag3 = num9 > 0;
			if (flag3)
			{
				if (num9 == 0)
				{
					num9 = int.MaxValue;
				}
				Array.Resize(ref imageData, num9);
				array4 = imageData;
				num8 = -1;
			}
		}
		int num10 = 0;
		if (bits == 8 || bits == 4 || bits == 1)
		{
			int num11 = (pixelWidth * bits + 7) / 8;
			for (int j = 0; j < pixelHeight; j++)
			{
				monochromeMask.StartLine(j);
				int num12 = (pixelHeight - 1 - j) * ((pixelWidth * bits + 7) / 8);
				for (int k = 0; k < num11; k++)
				{
					if (flag2)
					{
						array3[num12] = array2[3 * array[num5 + num10]];
					}
					else
					{
						array3[num12] = array[num5 + num10];
					}
					if (num != -1)
					{
						int num13 = array[num5 + num10];
						switch (bits)
						{
						case 8:
							monochromeMask.AddPel(num13 >= num && num13 <= num2);
							break;
						case 4:
						{
							int num15 = (num13 & 0xF0) / 16;
							int num16 = num13 & 0xF;
							monochromeMask.AddPel(num15 >= num && num15 <= num2);
							monochromeMask.AddPel(num16 >= num && num16 <= num2);
							break;
						}
						case 1:
						{
							for (int l = 1; l <= 8; l++)
							{
								int num14 = (num13 & 0x80) / 128;
								monochromeMask.AddPel(num14 >= num && num14 <= num2);
								num13 *= 2;
							}
							break;
						}
						}
					}
					num10++;
					num12++;
				}
				num10 = 4 * ((num10 + 3) / 4);
			}
			FlateDecode flateDecode = new FlateDecode();
			if (num != -1 && num2 != -1)
			{
				if (!flag && version >= 13 && !flag2)
				{
					PdfArray pdfArray = new PdfArray(_document);
					pdfArray.Elements.Add(new PdfInteger(num));
					pdfArray.Elements.Add(new PdfInteger(num2));
					base.Elements["/Mask"] = pdfArray;
				}
				else
				{
					byte[] array5 = flateDecode.Encode(monochromeMask.MaskData, _document.Options.FlateEncodeMode);
					PdfDictionary pdfDictionary = new PdfDictionary(_document);
					pdfDictionary.Elements.SetName("/Type", "/XObject");
					pdfDictionary.Elements.SetName("/Subtype", "/Image");
					Owner._irefTable.Add(pdfDictionary);
					pdfDictionary.Stream = new PdfStream(array5, pdfDictionary);
					pdfDictionary.Elements["/Length"] = new PdfInteger(array5.Length);
					pdfDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
					pdfDictionary.Elements["/Width"] = new PdfInteger(pixelWidth);
					pdfDictionary.Elements["/Height"] = new PdfInteger(pixelHeight);
					pdfDictionary.Elements["/BitsPerComponent"] = new PdfInteger(1);
					pdfDictionary.Elements["/ImageMask"] = new PdfBoolean(value: true);
					base.Elements["/Mask"] = pdfDictionary.Reference;
				}
			}
			byte[] array6 = flateDecode.Encode(array3, _document.Options.FlateEncodeMode);
			byte[] array7 = (flag3 ? flateDecode.Encode(array4, _document.Options.FlateEncodeMode) : null);
			bool flag4 = false;
			if (flag3 && (array4.Length < array6.Length || array7.Length < array6.Length))
			{
				flag4 = true;
				if (array4.Length < array6.Length)
				{
					base.Stream = new PdfStream(array4, this);
					base.Elements["/Length"] = new PdfInteger(array4.Length);
					base.Elements["/Filter"] = new PdfName("/CCITTFaxDecode");
					PdfDictionary pdfDictionary2 = new PdfDictionary();
					if (num8 != 0)
					{
						pdfDictionary2.Elements.Add("/K", new PdfInteger(num8));
					}
					if (num7 < 0)
					{
						pdfDictionary2.Elements.Add("/BlackIs1", new PdfBoolean(value: true));
					}
					pdfDictionary2.Elements.Add("/EndOfBlock", new PdfBoolean(value: false));
					pdfDictionary2.Elements.Add("/Columns", new PdfInteger(pixelWidth));
					pdfDictionary2.Elements.Add("/Rows", new PdfInteger(pixelHeight));
					base.Elements["/DecodeParms"] = pdfDictionary2;
				}
				else
				{
					base.Stream = new PdfStream(array7, this);
					base.Elements["/Length"] = new PdfInteger(array7.Length);
					PdfArray pdfArray2 = new PdfArray(_document);
					pdfArray2.Elements.Add(new PdfName("/FlateDecode"));
					pdfArray2.Elements.Add(new PdfName("/CCITTFaxDecode"));
					base.Elements["/Filter"] = pdfArray2;
					PdfArray pdfArray3 = new PdfArray(_document);
					PdfDictionary value = new PdfDictionary();
					PdfDictionary pdfDictionary3 = new PdfDictionary();
					if (num8 != 0)
					{
						pdfDictionary3.Elements.Add("/K", new PdfInteger(num8));
					}
					if (num7 < 0)
					{
						pdfDictionary3.Elements.Add("/BlackIs1", new PdfBoolean(value: true));
					}
					pdfDictionary3.Elements.Add("/EndOfBlock", new PdfBoolean(value: false));
					pdfDictionary3.Elements.Add("/Columns", new PdfInteger(pixelWidth));
					pdfDictionary3.Elements.Add("/Rows", new PdfInteger(pixelHeight));
					pdfArray3.Elements.Add(value);
					pdfArray3.Elements.Add(pdfDictionary3);
					base.Elements["/DecodeParms"] = pdfArray3;
				}
			}
			else
			{
				base.Stream = new PdfStream(array6, this);
				base.Elements["/Length"] = new PdfInteger(array6.Length);
				base.Elements["/Filter"] = new PdfName("/FlateDecode");
			}
			base.Elements["/Width"] = new PdfInteger(pixelWidth);
			base.Elements["/Height"] = new PdfInteger(pixelHeight);
			base.Elements["/BitsPerComponent"] = new PdfInteger(bits);
			if ((flag4 && num7 == 0) || (!flag4 && num7 <= 0 && !flag2))
			{
				PdfDictionary pdfDictionary4 = null;
				pdfDictionary4 = new PdfDictionary(_document);
				byte[] array8 = ((array2.Length >= 48) ? flateDecode.Encode(array2, _document.Options.FlateEncodeMode) : null);
				if (array8 != null && array8.Length + 20 < array2.Length)
				{
					pdfDictionary4.CreateStream(array8);
					pdfDictionary4.Elements["/Length"] = new PdfInteger(array8.Length);
					pdfDictionary4.Elements["/Filter"] = new PdfName("/FlateDecode");
				}
				else
				{
					pdfDictionary4.CreateStream(array2);
					pdfDictionary4.Elements["/Length"] = new PdfInteger(array2.Length);
				}
				Owner._irefTable.Add(pdfDictionary4);
				PdfArray pdfArray4 = new PdfArray(_document);
				pdfArray4.Elements.Add(new PdfName("/Indexed"));
				pdfArray4.Elements.Add(new PdfName("/DeviceRGB"));
				pdfArray4.Elements.Add(new PdfInteger(num6 - 1));
				pdfArray4.Elements.Add(pdfDictionary4.Reference);
				base.Elements["/ColorSpace"] = pdfArray4;
			}
			else
			{
				base.Elements["/ColorSpace"] = new PdfName("/DeviceGray");
			}
			if (_image.Interpolate)
			{
				base.Elements["/Interpolate"] = PdfBoolean.True;
			}
			return;
		}
		throw new NotImplementedException("ReadIndexedMemoryBitmap: unsupported format #3");
	}

	private static uint CountOneBits(BitReader reader, uint bitsLeft)
	{
		uint num = 0u;
		while (true)
		{
			uint bits;
			int num2 = reader.PeekByte(out bits);
			uint num3 = _oneRuns[num2];
			if (num3 < bits)
			{
				if (num3 != 0)
				{
					reader.SkipBits(num3);
				}
				num += num3;
				return (num >= bitsLeft) ? bitsLeft : num;
			}
			num += bits;
			if (num >= bitsLeft)
			{
				break;
			}
			reader.NextByte();
		}
		return bitsLeft;
	}

	private static uint CountZeroBits(BitReader reader, uint bitsLeft)
	{
		uint num = 0u;
		while (true)
		{
			uint bits;
			int num2 = reader.PeekByte(out bits);
			uint num3 = _zeroRuns[num2];
			if (num3 < bits)
			{
				if (num3 != 0)
				{
					reader.SkipBits(num3);
				}
				num += num3;
				return (num >= bitsLeft) ? bitsLeft : num;
			}
			num += bits;
			if (num >= bitsLeft)
			{
				break;
			}
			reader.NextByte();
		}
		return bitsLeft;
	}

	private static uint FindDifference(BitReader reader, uint bitStart, uint bitEnd, bool searchOne)
	{
		reader.SetPosition(bitStart);
		return bitStart + (searchOne ? CountOneBits(reader, bitEnd - bitStart) : CountZeroBits(reader, bitEnd - bitStart));
	}

	private static uint FindDifferenceWithCheck(BitReader reader, uint bitStart, uint bitEnd, bool searchOne)
	{
		return (bitStart < bitEnd) ? FindDifference(reader, bitStart, bitEnd, searchOne) : bitEnd;
	}

	private static void FaxEncode2DRow(BitWriter writer, uint bytesFileOffset, byte[] imageBits, uint currentRow, uint referenceRow, uint width, uint height, uint bytesPerLineBmp)
	{
		uint bytesFileOffset2 = bytesFileOffset + (height - 1 - currentRow) * bytesPerLineBmp;
		BitReader bitReader = new BitReader(imageBits, bytesFileOffset2, width);
		BitReader bitReader2;
		if (referenceRow != uint.MaxValue)
		{
			uint bytesFileOffset3 = bytesFileOffset + (height - 1 - referenceRow) * bytesPerLineBmp;
			bitReader2 = new BitReader(imageBits, bytesFileOffset3, width);
		}
		else
		{
			byte[] array = new byte[bytesPerLineBmp];
			for (int i = 0; i < bytesPerLineBmp; i++)
			{
				array[i] = byte.MaxValue;
			}
			bitReader2 = new BitReader(array, 0u, width);
		}
		uint num = 0u;
		uint num2 = (bitReader.GetBit(0u) ? FindDifference(bitReader, 0u, width, searchOne: true) : 0u);
		uint num3 = (bitReader2.GetBit(0u) ? FindDifference(bitReader2, 0u, width, searchOne: true) : 0u);
		while (true)
		{
			uint num4 = FindDifferenceWithCheck(bitReader2, num3, width, bitReader2.GetBit(num3));
			if (num4 >= num2)
			{
				int num5 = (int)(num3 - num2);
				if (-3 > num5 || num5 > 3)
				{
					uint num6 = FindDifferenceWithCheck(bitReader, num2, width, bitReader.GetBit(num2));
					writer.WriteTableLine(HorizontalCodes, 0u);
					if (num + num2 == 0 || bitReader.GetBit(num))
					{
						WriteSample(writer, num2 - num, white: true);
						WriteSample(writer, num6 - num2, white: false);
					}
					else
					{
						WriteSample(writer, num2 - num, white: false);
						WriteSample(writer, num6 - num2, white: true);
					}
					num = num6;
				}
				else
				{
					writer.WriteTableLine(VerticalCodes, (uint)(num5 + 3));
					num = num2;
				}
			}
			else
			{
				writer.WriteTableLine(PassCodes, 0u);
				num = num4;
			}
			if (num >= width)
			{
				break;
			}
			bool bit = bitReader.GetBit(num);
			num2 = FindDifference(bitReader, num, width, bit);
			num3 = FindDifference(bitReader2, num, width, !bit);
			num3 = FindDifferenceWithCheck(bitReader2, num3, width, bit);
		}
	}

	private static int DoFaxEncoding(ref byte[] imageData, byte[] imageBits, uint bytesFileOffset, uint width, uint height)
	{
		try
		{
			uint num = (width + 31) / 32 * 4;
			BitWriter bitWriter = new BitWriter(ref imageData);
			for (uint num2 = 0u; num2 < height; num2++)
			{
				uint bytesFileOffset2 = bytesFileOffset + (height - 1 - num2) * num;
				BitReader reader = new BitReader(imageBits, bytesFileOffset2, width);
				uint num3 = 0u;
				while (num3 < width)
				{
					uint num4 = CountOneBits(reader, width - num3);
					WriteSample(bitWriter, num4, white: true);
					num3 += num4;
					if (num3 < width)
					{
						uint num5 = CountZeroBits(reader, width - num3);
						WriteSample(bitWriter, num5, white: false);
						num3 += num5;
					}
				}
			}
			bitWriter.FlushBuffer();
			return bitWriter.BytesWritten();
		}
		catch (Exception)
		{
			return 0;
		}
	}

	internal static int DoFaxEncodingGroup4(ref byte[] imageData, byte[] imageBits, uint bytesFileOffset, uint width, uint height)
	{
		try
		{
			uint bytesPerLineBmp = (width + 31) / 32 * 4;
			BitWriter bitWriter = new BitWriter(ref imageData);
			for (uint num = 0u; num < height; num++)
			{
				FaxEncode2DRow(bitWriter, bytesFileOffset, imageBits, num, (num != 0) ? (num - 1) : uint.MaxValue, width, height, bytesPerLineBmp);
			}
			bitWriter.FlushBuffer();
			return bitWriter.BytesWritten();
		}
		catch (Exception ex)
		{
			ex.GetType();
			return 0;
		}
	}

	private static void WriteSample(BitWriter writer, uint count, bool white)
	{
		uint[] table = (white ? WhiteTerminatingCodes : BlackTerminatingCodes);
		uint[] table2 = (white ? WhiteMakeUpCodes : BlackMakeUpCodes);
		while (count >= 2624)
		{
			writer.WriteTableLine(table2, 39u);
			count -= 2560;
		}
		if (count > 63)
		{
			uint num = count / 64 - 1;
			writer.WriteTableLine(table2, num);
			count -= (num + 1) * 64;
		}
		writer.WriteTableLine(table, count);
	}
}

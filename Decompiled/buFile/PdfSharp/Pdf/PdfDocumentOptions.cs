namespace PdfSharp.Pdf;

public sealed class PdfDocumentOptions
{
	private PdfColorMode _colorMode = PdfColorMode.Rgb;

	private bool _compressContentStreams = false;

	private bool _noCompression;

	private PdfFlateEncodeMode _flateEncodeMode = PdfFlateEncodeMode.Default;

	private bool _enableCcittCompressionForBilevelImages = false;

	private PdfUseFlateDecoderForJpegImages _useFlateDecoderForJpegImages = PdfUseFlateDecoderForJpegImages.Never;

	public PdfColorMode ColorMode
	{
		get
		{
			return _colorMode;
		}
		set
		{
			_colorMode = value;
		}
	}

	public bool CompressContentStreams
	{
		get
		{
			return _compressContentStreams;
		}
		set
		{
			_compressContentStreams = value;
		}
	}

	public bool NoCompression
	{
		get
		{
			return _noCompression;
		}
		set
		{
			_noCompression = value;
		}
	}

	public PdfFlateEncodeMode FlateEncodeMode
	{
		get
		{
			return _flateEncodeMode;
		}
		set
		{
			_flateEncodeMode = value;
		}
	}

	public bool EnableCcittCompressionForBilevelImages
	{
		get
		{
			return _enableCcittCompressionForBilevelImages;
		}
		set
		{
			_enableCcittCompressionForBilevelImages = value;
		}
	}

	public PdfUseFlateDecoderForJpegImages UseFlateDecoderForJpegImages
	{
		get
		{
			return _useFlateDecoderForJpegImages;
		}
		set
		{
			_useFlateDecoderForJpegImages = value;
		}
	}

	internal PdfDocumentOptions(PdfDocument document)
	{
	}
}

using PdfSharp.Pdf;

namespace PdfSharp.Drawing.Internal;

internal class ImageDataBitmap : ImageData
{
	private byte[] _data;

	private int _length;

	private byte[] _dataFax;

	private int _lengthFax;

	private byte[] _alphaMask;

	private int _alphaMaskLength;

	private byte[] _bitmapMask;

	private int _bitmapMaskLength;

	private byte[] _paletteData;

	private int _paletteDataLength;

	public bool SegmentedColorMask;

	public int IsBitonal;

	public int K;

	public bool IsGray;

	internal readonly PdfDocument _document;

	public byte[] Data
	{
		get
		{
			return _data;
		}
		internal set
		{
			_data = value;
		}
	}

	public int Length
	{
		get
		{
			return _length;
		}
		internal set
		{
			_length = value;
		}
	}

	public byte[] DataFax
	{
		get
		{
			return _dataFax;
		}
		internal set
		{
			_dataFax = value;
		}
	}

	public int LengthFax
	{
		get
		{
			return _lengthFax;
		}
		internal set
		{
			_lengthFax = value;
		}
	}

	public byte[] AlphaMask
	{
		get
		{
			return _alphaMask;
		}
		internal set
		{
			_alphaMask = value;
		}
	}

	public int AlphaMaskLength
	{
		get
		{
			return _alphaMaskLength;
		}
		internal set
		{
			_alphaMaskLength = value;
		}
	}

	public byte[] BitmapMask
	{
		get
		{
			return _bitmapMask;
		}
		internal set
		{
			_bitmapMask = value;
		}
	}

	public int BitmapMaskLength
	{
		get
		{
			return _bitmapMaskLength;
		}
		internal set
		{
			_bitmapMaskLength = value;
		}
	}

	public byte[] PaletteData
	{
		get
		{
			return _paletteData;
		}
		set
		{
			_paletteData = value;
		}
	}

	public int PaletteDataLength
	{
		get
		{
			return _paletteDataLength;
		}
		set
		{
			_paletteDataLength = value;
		}
	}

	private ImageDataBitmap()
	{
	}

	internal ImageDataBitmap(PdfDocument document)
	{
		_document = document;
	}
}

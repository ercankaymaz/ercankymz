using System;
using Zen.Barcode.Properties;

namespace Zen.Barcode;

public static class BarcodeDrawFactory
{
	private static Code39BarcodeDraw _code39WithoutChecksum;

	private static Code39BarcodeDraw _code39WithChecksum;

	private static Code93BarcodeDraw _code93WithChecksum;

	private static Code128BarcodeDraw _code128WithChecksum;

	private static Code11BarcodeDraw _code11WithoutChecksum;

	private static Code11BarcodeDraw _code11WithChecksum;

	private static CodeEan13BarcodeDraw _codeEan13WithChecksum;

	private static CodeEan8BarcodeDraw _codeEan8WithChecksum;

	private static Code25BarcodeDraw _code25StandardWithoutChecksum;

	private static Code25BarcodeDraw _code25StandardWithChecksum;

	private static Code25BarcodeDraw _code25InterleavedWithoutChecksum;

	private static Code25BarcodeDraw _code25InterleavedWithChecksum;

	private static CodePdf417BarcodeDraw _codePdf417;

	private static CodeQrBarcodeDraw _codeQr;

	public static Code39BarcodeDraw Code39WithoutChecksum
	{
		get
		{
			if (_code39WithoutChecksum == null)
			{
				_code39WithoutChecksum = new Code39BarcodeDraw(Code39GlyphFactory.Instance);
			}
			return _code39WithoutChecksum;
		}
	}

	public static Code39BarcodeDraw Code39WithChecksum
	{
		get
		{
			if (_code39WithChecksum == null)
			{
				_code39WithChecksum = new Code39BarcodeDraw(Code39Checksum.Instance);
			}
			return _code39WithChecksum;
		}
	}

	public static Code93BarcodeDraw Code93WithChecksum
	{
		get
		{
			if (_code93WithChecksum == null)
			{
				_code93WithChecksum = new Code93BarcodeDraw(Code93Checksum.Instance);
			}
			return _code93WithChecksum;
		}
	}

	public static Code128BarcodeDraw Code128WithChecksum
	{
		get
		{
			if (_code128WithChecksum == null)
			{
				_code128WithChecksum = new Code128BarcodeDraw(Code128Checksum.Instance);
			}
			return _code128WithChecksum;
		}
	}

	public static Code11BarcodeDraw Code11WithoutChecksum
	{
		get
		{
			if (_code11WithoutChecksum == null)
			{
				_code11WithoutChecksum = new Code11BarcodeDraw(Code11GlyphFactory.Instance);
			}
			return _code11WithoutChecksum;
		}
	}

	public static Code11BarcodeDraw Code11WithChecksum
	{
		get
		{
			if (_code11WithChecksum == null)
			{
				_code11WithChecksum = new Code11BarcodeDraw(Code11Checksum.Instance);
			}
			return _code11WithChecksum;
		}
	}

	public static CodeEan13BarcodeDraw CodeEan13WithChecksum
	{
		get
		{
			if (_codeEan13WithChecksum == null)
			{
				_codeEan13WithChecksum = new CodeEan13BarcodeDraw(CodeEan13Checksum.Instance);
			}
			return _codeEan13WithChecksum;
		}
	}

	public static CodeEan8BarcodeDraw CodeEan8WithChecksum
	{
		get
		{
			if (_codeEan8WithChecksum == null)
			{
				_codeEan8WithChecksum = new CodeEan8BarcodeDraw(CodeEan8Checksum.Instance);
			}
			return _codeEan8WithChecksum;
		}
	}

	public static Code25BarcodeDraw Code25StandardWithoutChecksum
	{
		get
		{
			if (_code25StandardWithoutChecksum == null)
			{
				_code25StandardWithoutChecksum = new Code25BarcodeDraw(Code25GlyphFactory.StandardInstance);
			}
			return _code25StandardWithoutChecksum;
		}
	}

	public static Code25BarcodeDraw Code25StandardWithChecksum
	{
		get
		{
			if (_code25StandardWithChecksum == null)
			{
				_code25StandardWithChecksum = new Code25BarcodeDraw(Code25Checksum.StandardInstance);
			}
			return _code25StandardWithChecksum;
		}
	}

	public static Code25BarcodeDraw Code25InterleavedWithoutChecksum
	{
		get
		{
			if (_code25InterleavedWithoutChecksum == null)
			{
				_code25InterleavedWithoutChecksum = new Code25BarcodeDraw(Code25GlyphFactory.InterleavedInstance);
			}
			return _code25InterleavedWithoutChecksum;
		}
	}

	public static Code25BarcodeDraw Code25InterleavedWithChecksum
	{
		get
		{
			if (_code25InterleavedWithChecksum == null)
			{
				_code25InterleavedWithChecksum = new Code25BarcodeDraw(Code25Checksum.InterleavedInstance);
			}
			return _code25InterleavedWithChecksum;
		}
	}

	public static CodePdf417BarcodeDraw CodePdf417
	{
		get
		{
			if (_codePdf417 == null)
			{
				_codePdf417 = new CodePdf417BarcodeDraw();
			}
			return _codePdf417;
		}
	}

	public static CodeQrBarcodeDraw CodeQr
	{
		get
		{
			if (_codeQr == null)
			{
				_codeQr = new CodeQrBarcodeDraw();
			}
			return _codeQr;
		}
	}

	public static BarcodeDraw GetSymbology(BarcodeSymbology symbology)
	{
		return symbology switch
		{
			BarcodeSymbology.Code39NC => Code39WithoutChecksum, 
			BarcodeSymbology.Code39C => Code39WithChecksum, 
			BarcodeSymbology.Code93 => Code93WithChecksum, 
			BarcodeSymbology.Code128 => Code128WithChecksum, 
			BarcodeSymbology.Code11NC => Code11WithoutChecksum, 
			BarcodeSymbology.Code11C => Code11WithChecksum, 
			BarcodeSymbology.CodeEan13 => CodeEan13WithChecksum, 
			BarcodeSymbology.CodeEan8 => CodeEan8WithChecksum, 
			BarcodeSymbology.Code25StandardNC => Code25StandardWithoutChecksum, 
			BarcodeSymbology.Code25StandardC => Code25StandardWithChecksum, 
			BarcodeSymbology.Code25InterleavedNC => Code25InterleavedWithoutChecksum, 
			BarcodeSymbology.Code25InterleavedC => Code25InterleavedWithChecksum, 
			BarcodeSymbology.CodePdf417 => CodePdf417, 
			BarcodeSymbology.CodeQr => CodeQr, 
			_ => throw new ArgumentException(Resources.BarcodeSymbologyInvalid, "symbology"), 
		};
	}
}

namespace PdfSharp.Pdf;

public class PdfCustomValue : PdfDictionary
{
	public PdfCustomValueCompressionMode CompressionMode;

	public byte[] Value
	{
		get
		{
			return base.Stream.Value;
		}
		set
		{
			base.Stream.Value = value;
		}
	}

	public PdfCustomValue()
	{
		CreateStream(new byte[0]);
	}

	public PdfCustomValue(byte[] bytes)
	{
		CreateStream(bytes);
	}

	internal PdfCustomValue(PdfDocument document)
		: base(document)
	{
		CreateStream(new byte[0]);
	}

	internal PdfCustomValue(PdfDictionary dict)
		: base(dict)
	{
	}
}

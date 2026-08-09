using System;

namespace PdfSharp.Pdf.Advanced;

internal class PdfPageInheritableObjects : PdfDictionary
{
	private PdfRectangle _mediaBox;

	private PdfRectangle _cropBox;

	private int _rotate;

	public PdfRectangle MediaBox
	{
		get
		{
			return _mediaBox;
		}
		set
		{
			_mediaBox = value;
		}
	}

	public PdfRectangle CropBox
	{
		get
		{
			return _cropBox;
		}
		set
		{
			_cropBox = value;
		}
	}

	public int Rotate
	{
		get
		{
			return _rotate;
		}
		set
		{
			if (value % 90 != 0)
			{
				throw new ArgumentException("The value must be a multiple of 90.", "value");
			}
			_rotate = value;
		}
	}
}

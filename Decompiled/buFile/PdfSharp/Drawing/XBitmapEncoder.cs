using System.IO;

namespace PdfSharp.Drawing;

public abstract class XBitmapEncoder
{
	private XBitmapSource _source;

	public XBitmapSource Source
	{
		get
		{
			return _source;
		}
		set
		{
			_source = value;
		}
	}

	internal XBitmapEncoder()
	{
	}

	public static XBitmapEncoder GetPngEncoder()
	{
		return new XPngBitmapEncoder();
	}

	public abstract void Save(Stream stream);
}

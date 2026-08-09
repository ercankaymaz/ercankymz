using System;

namespace PdfSharp.Drawing;

public class XStringFormat
{
	private XStringAlignment _alignment;

	private XLineAlignment _lineAlignment;

	public XStringAlignment Alignment
	{
		get
		{
			return _alignment;
		}
		set
		{
			_alignment = value;
		}
	}

	public XLineAlignment LineAlignment
	{
		get
		{
			return _lineAlignment;
		}
		set
		{
			_lineAlignment = value;
		}
	}

	[Obsolete("Use XStringFormats.Default. (Note plural in class name.)")]
	public static XStringFormat Default => XStringFormats.Default;

	[Obsolete("Use XStringFormats.Default. (Note plural in class name.)")]
	public static XStringFormat TopLeft => XStringFormats.TopLeft;

	[Obsolete("Use XStringFormats.Center. (Note plural in class name.)")]
	public static XStringFormat Center => XStringFormats.Center;

	[Obsolete("Use XStringFormats.TopCenter. (Note plural in class name.)")]
	public static XStringFormat TopCenter => XStringFormats.TopCenter;

	[Obsolete("Use XStringFormats.BottomCenter. (Note plural in class name.)")]
	public static XStringFormat BottomCenter => XStringFormats.BottomCenter;
}

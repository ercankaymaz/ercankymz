namespace PdfSharp.Drawing;

public static class XStringFormats
{
	public static XStringFormat Default => BaseLineLeft;

	public static XStringFormat BaseLineLeft
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Near;
			xStringFormat.LineAlignment = XLineAlignment.BaseLine;
			return xStringFormat;
		}
	}

	public static XStringFormat TopLeft
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Near;
			xStringFormat.LineAlignment = XLineAlignment.Near;
			return xStringFormat;
		}
	}

	public static XStringFormat CenterLeft
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Near;
			xStringFormat.LineAlignment = XLineAlignment.Center;
			return xStringFormat;
		}
	}

	public static XStringFormat BottomLeft
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Near;
			xStringFormat.LineAlignment = XLineAlignment.Far;
			return xStringFormat;
		}
	}

	public static XStringFormat BaseLineCenter
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Center;
			xStringFormat.LineAlignment = XLineAlignment.BaseLine;
			return xStringFormat;
		}
	}

	public static XStringFormat TopCenter
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Center;
			xStringFormat.LineAlignment = XLineAlignment.Near;
			return xStringFormat;
		}
	}

	public static XStringFormat Center
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Center;
			xStringFormat.LineAlignment = XLineAlignment.Center;
			return xStringFormat;
		}
	}

	public static XStringFormat BottomCenter
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Center;
			xStringFormat.LineAlignment = XLineAlignment.Far;
			return xStringFormat;
		}
	}

	public static XStringFormat BaseLineRight
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Far;
			xStringFormat.LineAlignment = XLineAlignment.BaseLine;
			return xStringFormat;
		}
	}

	public static XStringFormat TopRight
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Far;
			xStringFormat.LineAlignment = XLineAlignment.Near;
			return xStringFormat;
		}
	}

	public static XStringFormat CenterRight
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Far;
			xStringFormat.LineAlignment = XLineAlignment.Center;
			return xStringFormat;
		}
	}

	public static XStringFormat BottomRight
	{
		get
		{
			XStringFormat xStringFormat = new XStringFormat();
			xStringFormat.Alignment = XStringAlignment.Far;
			xStringFormat.LineAlignment = XLineAlignment.Far;
			return xStringFormat;
		}
	}
}

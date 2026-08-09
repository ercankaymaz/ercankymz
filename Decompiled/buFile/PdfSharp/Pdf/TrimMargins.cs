using System.Diagnostics;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf;

[DebuggerDisplay("(Left={left.Millimeter}mm, Right={right.Millimeter}mm, Top={top.Millimeter}mm, Bottom={bottom.Millimeter}mm)")]
public sealed class TrimMargins
{
	private XUnit _left;

	private XUnit _right;

	private XUnit _top;

	private XUnit _bottom;

	public XUnit All
	{
		set
		{
			_left = value;
			_right = value;
			_top = value;
			_bottom = value;
		}
	}

	public XUnit Left
	{
		get
		{
			return _left;
		}
		set
		{
			_left = value;
		}
	}

	public XUnit Right
	{
		get
		{
			return _right;
		}
		set
		{
			_right = value;
		}
	}

	public XUnit Top
	{
		get
		{
			return _top;
		}
		set
		{
			_top = value;
		}
	}

	public XUnit Bottom
	{
		get
		{
			return _bottom;
		}
		set
		{
			_bottom = value;
		}
	}

	public bool AreSet => _left.Value != 0.0 || _right.Value != 0.0 || _top.Value != 0.0 || _bottom.Value != 0.0;
}

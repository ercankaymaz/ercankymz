using System;

namespace PdfSharp.Drawing;

public sealed class XImageFormat
{
	private readonly Guid _guid;

	private static readonly XImageFormat _png = new XImageFormat(new Guid("{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}"));

	private static readonly XImageFormat _gif = new XImageFormat(new Guid("{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}"));

	private static readonly XImageFormat _jpeg = new XImageFormat(new Guid("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}"));

	private static readonly XImageFormat _tiff = new XImageFormat(new Guid("{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}"));

	private static readonly XImageFormat _icon = new XImageFormat(new Guid("{B96B3CB5-0728-11D3-9D7B-0000F81EF32E}"));

	private static readonly XImageFormat _pdf = new XImageFormat(new Guid("{84570158-DBF0-4C6B-8368-62D6A3CA76E0}"));

	internal Guid Guid => _guid;

	public static XImageFormat Png => _png;

	public static XImageFormat Gif => _gif;

	public static XImageFormat Jpeg => _jpeg;

	public static XImageFormat Tiff => _tiff;

	public static XImageFormat Pdf => _pdf;

	public static XImageFormat Icon => _icon;

	private XImageFormat(Guid guid)
	{
		_guid = guid;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is XImageFormat xImageFormat))
		{
			return false;
		}
		return _guid == xImageFormat._guid;
	}

	public override int GetHashCode()
	{
		return _guid.GetHashCode();
	}
}

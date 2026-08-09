using System;
using PdfSharp.Drawing;

namespace PdfSharp.Internal;

internal static class Calc
{
	public const double Deg2Rad = Math.PI / 180.0;

	public static XSize PageSizeToSize(PageSize value)
	{
		return value switch
		{
			PageSize.A0 => new XSize(2380.0, 3368.0), 
			PageSize.A1 => new XSize(1684.0, 2380.0), 
			PageSize.A2 => new XSize(1190.0, 1684.0), 
			PageSize.A3 => new XSize(842.0, 1190.0), 
			PageSize.A4 => new XSize(595.0, 842.0), 
			PageSize.A5 => new XSize(420.0, 595.0), 
			PageSize.B4 => new XSize(729.0, 1032.0), 
			PageSize.B5 => new XSize(516.0, 729.0), 
			PageSize.Letter => new XSize(612.0, 792.0), 
			PageSize.Legal => new XSize(612.0, 1008.0), 
			PageSize.Tabloid => new XSize(792.0, 1224.0), 
			PageSize.Ledger => new XSize(1224.0, 792.0), 
			PageSize.Statement => new XSize(396.0, 612.0), 
			PageSize.Executive => new XSize(540.0, 720.0), 
			PageSize.Folio => new XSize(612.0, 936.0), 
			PageSize.Quarto => new XSize(610.0, 780.0), 
			PageSize.Size10x14 => new XSize(720.0, 1008.0), 
			_ => throw new ArgumentException("Invalid PageSize."), 
		};
	}
}

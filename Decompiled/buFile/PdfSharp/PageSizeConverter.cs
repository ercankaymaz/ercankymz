using System;
using PdfSharp.Drawing;

namespace PdfSharp;

public static class PageSizeConverter
{
	public static XSize ToSize(PageSize value)
	{
		return value switch
		{
			PageSize.A0 => new XSize(2384.0, 3370.0), 
			PageSize.A1 => new XSize(1684.0, 2384.0), 
			PageSize.A2 => new XSize(1191.0, 1684.0), 
			PageSize.A3 => new XSize(842.0, 1191.0), 
			PageSize.A4 => new XSize(595.0, 842.0), 
			PageSize.A5 => new XSize(420.0, 595.0), 
			PageSize.RA0 => new XSize(2438.0, 3458.0), 
			PageSize.RA1 => new XSize(1729.0, 2438.0), 
			PageSize.RA2 => new XSize(1219.0, 1729.0), 
			PageSize.RA3 => new XSize(865.0, 1219.0), 
			PageSize.RA4 => new XSize(609.0, 865.0), 
			PageSize.RA5 => new XSize(433.0, 609.0), 
			PageSize.B0 => new XSize(2835.0, 4008.0), 
			PageSize.B1 => new XSize(2004.0, 2835.0), 
			PageSize.B2 => new XSize(1417.0, 2004.0), 
			PageSize.B3 => new XSize(1001.0, 1417.0), 
			PageSize.B4 => new XSize(709.0, 1001.0), 
			PageSize.B5 => new XSize(499.0, 709.0), 
			PageSize.Quarto => new XSize(576.0, 720.0), 
			PageSize.Foolscap => new XSize(576.0, 936.0), 
			PageSize.Executive => new XSize(540.0, 720.0), 
			PageSize.GovernmentLetter => new XSize(576.0, 756.0), 
			PageSize.Letter => new XSize(612.0, 792.0), 
			PageSize.Legal => new XSize(612.0, 1008.0), 
			PageSize.Ledger => new XSize(1224.0, 792.0), 
			PageSize.Tabloid => new XSize(792.0, 1224.0), 
			PageSize.Post => new XSize(1126.0, 1386.0), 
			PageSize.Crown => new XSize(1440.0, 1080.0), 
			PageSize.LargePost => new XSize(1188.0, 1512.0), 
			PageSize.Demy => new XSize(1260.0, 1584.0), 
			PageSize.Medium => new XSize(1296.0, 1656.0), 
			PageSize.Royal => new XSize(1440.0, 1800.0), 
			PageSize.Elephant => new XSize(1565.0, 2016.0), 
			PageSize.DoubleDemy => new XSize(1692.0, 2520.0), 
			PageSize.QuadDemy => new XSize(2520.0, 3240.0), 
			PageSize.STMT => new XSize(396.0, 612.0), 
			PageSize.Folio => new XSize(612.0, 936.0), 
			PageSize.Statement => new XSize(396.0, 612.0), 
			PageSize.Size10x14 => new XSize(720.0, 1008.0), 
			_ => throw new ArgumentException("Invalid PageSize.", "value"), 
		};
	}
}

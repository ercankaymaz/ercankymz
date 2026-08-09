#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using PdfSharp.Internal;

namespace PdfSharp.Drawing;

internal sealed class XPngBitmapEncoder : XBitmapEncoder
{
	internal XPngBitmapEncoder()
	{
	}

	public override void Save(Stream stream)
	{
		if (base.Source == null)
		{
			throw new InvalidOperationException("No image source.");
		}
		if (base.Source.AssociatedGraphics != null)
		{
			base.Source.DisassociateWithGraphics();
			Debug.Assert(base.Source.AssociatedGraphics == null);
		}
		try
		{
			Lock.EnterGdiPlus();
			base.Source._gdiImage.Save(stream, ImageFormat.Png);
		}
		finally
		{
			Lock.ExitGdiPlus();
		}
	}
}

using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Deactivation_When
{
	kExplicit = 0,
	kClosed = 1,
	kNotVisible = 2
}

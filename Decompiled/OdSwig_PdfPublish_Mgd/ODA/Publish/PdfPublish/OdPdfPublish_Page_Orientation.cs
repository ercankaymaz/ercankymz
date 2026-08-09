using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Page_Orientation
{
	kPortrait = 0,
	kLandscape = 1,
	kLastOrientation = 2
}

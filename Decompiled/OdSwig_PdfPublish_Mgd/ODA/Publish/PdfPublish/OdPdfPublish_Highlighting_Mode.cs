using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Highlighting_Mode
{
	kNone = 0,
	kInvert = 1,
	kOutline = 2,
	kPush = 3
}

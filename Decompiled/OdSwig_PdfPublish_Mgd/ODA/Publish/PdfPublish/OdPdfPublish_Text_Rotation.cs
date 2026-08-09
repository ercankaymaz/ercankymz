using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Text_Rotation
{
	kNone = 0,
	kCounterClockwise90Degrees = 1,
	kCounterClockwise180Degrees = 2,
	kCounterClockwise270Degrees = 3
}

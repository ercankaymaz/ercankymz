using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Label_Position
{
	kLabelOnly = 0,
	kIconOnly = 1,
	kTop = 2,
	kBottom = 3,
	kLeft = 4,
	kRight = 5,
	kOnTop = 6
}

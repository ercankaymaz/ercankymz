using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Activation_When
{
	kExplicit = 0,
	kOpened = 1,
	kVisible = 2
}

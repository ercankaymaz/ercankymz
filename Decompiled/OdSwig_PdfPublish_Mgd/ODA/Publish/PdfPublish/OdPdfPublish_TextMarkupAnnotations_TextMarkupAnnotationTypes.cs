using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_TextMarkupAnnotations_TextMarkupAnnotationTypes
{
	kHighlight = 0,
	kUnderline = 1,
	kSquiggly = 2,
	kStrikeOut = 3
}

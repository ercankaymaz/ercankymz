using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_MarkupAnnotations_MarkupAnnotationReviewStates
{
	kNone = 0,
	kAccepted = 1,
	kRejected = 2,
	kCancelled = 3,
	kCompleted = 4
}

using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_StampAnnotations_StampAnnotationTypes
{
	kApproved = 0,
	kExperimental = 1,
	kNotApproved = 2,
	kAsIs = 3,
	kExpired = 4,
	kNotForPublicRelease = 5,
	kConfidential = 6,
	kFinal = 7,
	kSold = 8,
	kDepartmental = 9,
	kForComment = 0xA,
	kTopSecret = 0xB,
	kDraft = 0xC,
	kForPublicRelease = 0xD
}

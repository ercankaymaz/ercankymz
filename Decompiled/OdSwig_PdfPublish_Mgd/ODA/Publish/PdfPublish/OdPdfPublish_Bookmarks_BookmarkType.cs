using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Bookmarks_BookmarkType
{
	kXYZ = 0,
	kFit = 1,
	kFitH = 2,
	kFitV = 3,
	kFitR = 4,
	kFitB = 5,
	kFitBH = 6,
	kFitBV = 7
}

using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_StickyNotes_StickyNoteTypes
{
	kComment = 0,
	kKey = 1,
	kNote = 2,
	kHelp = 3,
	kNewParagraph = 4,
	kParagraph = 5,
	kInsert = 6,
	kCheck = 7,
	kCheckmark = 8,
	kCircle = 9,
	kCross = 0xA,
	kCrossHairs = 0xB,
	kRightArrow = 0xC,
	kRightPointer = 0xD,
	kStar = 0xE,
	kUpArrow = 0xF,
	kUpLeftArrow = 0x10
}

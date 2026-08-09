using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Action_Type
{
	kCursorEnter = 0,
	kCursorExit = 1,
	kButtonPressed = 2,
	kButtonReleased = 3,
	kInputFocus = 4,
	kLoseFocus = 5,
	kPageOpened = 6,
	kPageClosed = 7,
	kPageVisible = 8,
	kPageInvisible = 9
}

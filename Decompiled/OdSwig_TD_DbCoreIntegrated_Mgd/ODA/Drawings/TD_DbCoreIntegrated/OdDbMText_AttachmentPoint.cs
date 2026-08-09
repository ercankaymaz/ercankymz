using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMText_AttachmentPoint
{
	kTopLeft = 1,
	kTopCenter = 2,
	kTopRight = 3,
	kMiddleLeft = 4,
	kMiddleCenter = 5,
	kMiddleRight = 6,
	kBottomLeft = 7,
	kBottomCenter = 8,
	kBottomRight = 9,
	kBaseLeft = 0xA,
	kBaseCenter = 0xB,
	kBaseRight = 0xC,
	kBaseAlign = 0xD,
	kBottomAlign = 0xE,
	kMiddleAlign = 0xF,
	kTopAlign = 0x10,
	kBaseFit = 0x11,
	kBottomFit = 0x12,
	kMiddleFit = 0x13,
	kTopFit = 0x14,
	kBaseMid = 0x15,
	kBottomMid = 0x16,
	kMiddleMid = 0x17,
	kTopMid = 0x18
}

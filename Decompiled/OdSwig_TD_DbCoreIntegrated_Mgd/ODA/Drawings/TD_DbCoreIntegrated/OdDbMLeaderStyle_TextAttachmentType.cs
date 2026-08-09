using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMLeaderStyle_TextAttachmentType
{
	kAttachmentTopOfTop = 0,
	kAttachmentMiddleOfTop = 1,
	kAttachmentMiddle = 2,
	kAttachmentMiddleOfBottom = 3,
	kAttachmentBottomOfBottom = 4,
	kAttachmentBottomLine = 5,
	kAttachmentBottomOfTopLine = 6,
	kAttachmentBottomOfTop = 7,
	kAttachmentAllLine = 8,
	kAttachmentCenter = 9,
	kAttachmentLinedCenter = 0xA
}

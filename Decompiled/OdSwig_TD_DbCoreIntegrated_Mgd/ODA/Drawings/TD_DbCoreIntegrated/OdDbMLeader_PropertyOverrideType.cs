using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMLeader_PropertyOverrideType
{
	kLeaderLineType = 0,
	kLeaderLineColor = 1,
	kLeaderLineTypeId = 2,
	kLeaderLineWeight = 3,
	kEnableLanding = 4,
	kLandingGap = 5,
	kEnableDogleg = 6,
	kDoglegLength = 7,
	kArrowSymbolId = 8,
	kArrowSize = 9,
	kContentType = 0xA,
	kTextStyleId = 0xB,
	kTextLeftAttachmentType = 0xC,
	kTextAngleType = 0xD,
	kTextAlignmentType = 0xE,
	kTextColor = 0xF,
	kTextHeight = 0x10,
	kEnableFrameText = 0x11,
	kDefaultMText = 0x12,
	kBlockId = 0x13,
	kBlockColor = 0x14,
	kBlockScale = 0x15,
	kBlockRotation = 0x16,
	kBlockConnectionType = 0x17,
	kScale = 0x18,
	kTextRightAttachmentType = 0x19,
	kTextSwitchAlignmentType = 0x1A,
	kTextAttachmentDirection = 0x1B,
	kTextTopAttachmentType = 0x1C,
	kTextBottomAttachmentType = 0x1D,
	kExtendLeaderToText = 0x1E,
	kSize = 0x1F
}

using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMLeader_gsMarkType
{
	kNone = 0,
	kArrowMark = 1,
	kLeaderLineMark = 0x1389,
	kDoglegMark = 0x2711,
	kMTextMark = 0x3A99,
	kMTextUnderLineMark = 0x3A9A,
	kToleranceMark = 0x3A9B,
	kBlockMark = 0x3A9C,
	kBlockAttribute = 0x3A9D
}

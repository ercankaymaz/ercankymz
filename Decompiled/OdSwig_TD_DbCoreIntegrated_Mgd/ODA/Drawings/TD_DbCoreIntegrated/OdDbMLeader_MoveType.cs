using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMLeader_MoveType
{
	kMoveAllPoints = 0,
	kMoveAllExceptArrowHeaderPoints = 1,
	kMoveContentAndDoglegPoints = 2
}

using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbGraphNode_Flags
{
	kNone = 0,
	kVisited = 1,
	kOutsideRefed = 2,
	kSelected = 4,
	kInList = 8,
	kListAll = 0xE,
	kFirstLevel = 0x10,
	kUnresTree = 0x20,
	kAll = 0x2F
}

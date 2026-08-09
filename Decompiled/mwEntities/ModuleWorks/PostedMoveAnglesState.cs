using System;

namespace ModuleWorks;

[Serializable]
public enum PostedMoveAnglesState
{
	AnglesDetermined,
	Rot1AngleUndetermined,
	Rot2AngleUndetermined,
	KeepThis
}

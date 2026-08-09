using System;

namespace ModuleWorks;

[Serializable]
public enum ToolPathMoveCollisionState
{
	NotChecked,
	CollisionFree,
	CollisionLeft
}

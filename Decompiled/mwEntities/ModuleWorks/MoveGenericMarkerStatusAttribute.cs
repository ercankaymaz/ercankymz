using System;

namespace ModuleWorks;

[Serializable]
public enum MoveGenericMarkerStatusAttribute
{
	UNCHANGED = 1,
	MODIFIED,
	REMOVED,
	MW_GENERATED
}

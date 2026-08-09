using System;

namespace buClass;

[Serializable]
public enum SewingDrawCommand
{
	None,
	LineJump,
	LineStitched,
	ArcStitched
}

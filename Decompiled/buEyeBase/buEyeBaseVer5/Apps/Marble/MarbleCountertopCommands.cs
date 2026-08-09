using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public enum MarbleCountertopCommands
{
	None,
	SinkShapeChanged,
	BuiltInShapeChanged,
	SocketShapeChanged,
	DataChanged,
	FirstRun,
	MainShapeChanged,
	MainSizeChanged,
	OutsideEdgeChanged,
	InsideShapeChanged,
	InsideSizeChanged
}

using System;

namespace ModuleWorks;

[Serializable]
[Flags]
public enum PostWriterOutputCoordinateType
{
	AbsoluteWithoutTLC = 0,
	AbsoluteWithTLC = 1,
	Relative = 2
}

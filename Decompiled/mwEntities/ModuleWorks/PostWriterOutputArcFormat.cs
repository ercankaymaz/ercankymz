using System;

namespace ModuleWorks;

[Serializable]
[Flags]
public enum PostWriterOutputArcFormat
{
	LinearInterpolation = 0,
	CenterFormat = 1,
	RadiusFormat = 2
}

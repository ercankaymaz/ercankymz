using System;

namespace devDept.Eyeshot.Control.MultiTouch.Manipulation;

[Flags]
public enum ProcessorManipulations
{
	NONE = 0,
	TRANSLATE_X = 1,
	TRANSLATE_Y = 2,
	SCALE = 4,
	ROTATE = 8,
	ALL = 0xF
}

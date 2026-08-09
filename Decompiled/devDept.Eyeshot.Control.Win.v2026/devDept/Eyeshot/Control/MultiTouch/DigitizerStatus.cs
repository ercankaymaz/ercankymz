using System;

namespace devDept.Eyeshot.Control.MultiTouch;

[Flags]
public enum DigitizerStatus : byte
{
	IntegratedTouch = 1,
	ExternalTouch = 2,
	IntegratedPan = 4,
	ExternalPan = 8,
	MultiInput = 0x40,
	StackReady = 0x80
}

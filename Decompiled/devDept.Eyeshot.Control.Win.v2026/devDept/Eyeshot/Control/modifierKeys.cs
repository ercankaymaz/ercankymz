using System;
using System.ComponentModel;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(EnumDescriptionConverter))]
public enum modifierKeys
{
	[Description("None")]
	None = 0,
	[Description("Shift")]
	Shift = 65536,
	[Description("Alt")]
	Alt = 262144,
	[Description("Ctrl")]
	Ctrl = 131072,
	[Description("Ctrl + Alt")]
	CtrlAlt = 393216,
	[Description("Ctrl + Shift")]
	CtrlShift = 196608,
	[Description("Shift + Alt")]
	ShiftAlt = 327680,
	[Description("Ctrl + Shift + Alt")]
	CtrlShiftAlt = 458752
}

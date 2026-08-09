using System;
using System.ComponentModel;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(EnumDescriptionConverter))]
public enum mouseButtonsZPR
{
	[Description("None")]
	None = 0,
	[Description("Left")]
	Left = 1048576,
	[Description("Right")]
	Right = 2097152,
	[Description("Middle")]
	Middle = 4194304,
	[Description("XButton1")]
	XButton1 = 8388608,
	[Description("XButton2")]
	XButton2 = 16777216,
	[Description("Left + Right")]
	LeftRight = 3145728,
	[Description("Left + Middle")]
	LeftMiddle = 5242880,
	[Description("Middle + Right")]
	MiddleRight = 6291456,
	[Description("Left + Middle + Right")]
	LeftMiddleRight = 7340032
}

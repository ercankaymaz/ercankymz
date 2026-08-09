using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(LabelStyleConverter))]
public enum LabelStyle
{
	NormalControl,
	BoldControl,
	ItalicControl,
	TitleControl,
	NormalPanel,
	BoldPanel,
	ItalicPanel,
	TitlePanel,
	GroupBoxCaption,
	ToolTip,
	SuperTip,
	KeyTip,
	Custom1,
	Custom2,
	Custom3
}

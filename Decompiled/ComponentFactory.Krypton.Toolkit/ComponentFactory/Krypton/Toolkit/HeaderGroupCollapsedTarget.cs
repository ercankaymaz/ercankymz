using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(HeaderGroupCollapsedTargetConverter))]
public enum HeaderGroupCollapsedTarget
{
	CollapsedToPrimary,
	CollapsedToSecondary,
	CollapsedToBoth
}

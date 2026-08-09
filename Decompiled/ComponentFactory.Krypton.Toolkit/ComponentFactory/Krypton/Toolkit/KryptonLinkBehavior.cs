using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(KryptonLinkBehaviorConverter))]
public enum KryptonLinkBehavior
{
	AlwaysUnderline,
	HoverUnderline,
	NeverUnderline
}

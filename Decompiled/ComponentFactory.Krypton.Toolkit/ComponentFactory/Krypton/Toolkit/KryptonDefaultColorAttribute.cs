using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public sealed class KryptonDefaultColorAttribute : DefaultValueAttribute
{
	public KryptonDefaultColorAttribute()
		: base(Color.Empty)
	{
	}
}

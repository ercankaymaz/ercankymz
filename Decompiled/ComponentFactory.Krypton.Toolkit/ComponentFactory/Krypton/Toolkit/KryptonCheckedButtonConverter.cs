using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCheckedButtonConverter : ReferenceConverter
{
	public KryptonCheckedButtonConverter()
		: base(typeof(KryptonCheckButton))
	{
	}

	protected override bool IsValueAllowed(ITypeDescriptorContext context, object value)
	{
		if (context.Instance is KryptonCheckSet kryptonCheckSet)
		{
			return kryptonCheckSet.CheckButtons.Contains(value as KryptonCheckButton);
		}
		return false;
	}
}

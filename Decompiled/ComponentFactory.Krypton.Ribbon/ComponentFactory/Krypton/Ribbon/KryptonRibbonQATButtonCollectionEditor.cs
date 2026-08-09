using System;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonQATButtonCollectionEditor : CollectionEditor
{
	public KryptonRibbonQATButtonCollectionEditor()
		: base(typeof(KryptonRibbonQATButtonCollection))
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[1] { typeof(KryptonRibbonQATButton) };
	}

	protected override object SetItems(object editValue, object[] value)
	{
		KryptonRibbon kryptonRibbon = (KryptonRibbon)base.Context.Instance;
		kryptonRibbon?.SuspendLayout();
		object result = base.SetItems(editValue, value);
		kryptonRibbon?.ResumeLayout(performLayout: true);
		return result;
	}
}

using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCheckSetActionList : DesignerActionList
{
	private KryptonCheckSet _set;

	public KryptonCheckSetActionList(KryptonCheckSetDesigner owner)
		: base(owner.Component)
	{
		_set = owner.Component as KryptonCheckSet;
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection result = new DesignerActionItemCollection();
		if (_set != null)
		{
		}
		return result;
	}
}

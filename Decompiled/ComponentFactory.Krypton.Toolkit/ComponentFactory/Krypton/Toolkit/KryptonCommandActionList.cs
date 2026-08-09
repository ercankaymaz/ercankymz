using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCommandActionList : DesignerActionList
{
	private KryptonCommand _command;

	public KryptonCommandActionList(KryptonCommandDesigner owner)
		: base(owner.Component)
	{
		_command = owner.Component as KryptonCommand;
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection result = new DesignerActionItemCollection();
		if (_command != null)
		{
		}
		return result;
	}
}

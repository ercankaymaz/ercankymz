using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonManagerActionList : DesignerActionList
{
	private KryptonManager _manager;

	private IComponentChangeService _service;

	public PaletteModeManager GlobalPaletteMode
	{
		get
		{
			return _manager.GlobalPaletteMode;
		}
		set
		{
			if (_manager.GlobalPaletteMode != value)
			{
				_service.OnComponentChanged(_manager, null, _manager.GlobalPaletteMode, value);
				_manager.GlobalPaletteMode = value;
			}
		}
	}

	public KryptonManagerActionList(KryptonManagerDesigner owner)
		: base(owner.Component)
	{
		_manager = owner.Component as KryptonManager;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_manager != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("GlobalPaletteMode", "Global Palette", "Visuals", "Global palette setting"));
		}
		return designerActionItemCollection;
	}
}

using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonContextMenuActionList : DesignerActionList
{
	private KryptonContextMenu _contextMenu;

	private IComponentChangeService _service;

	public PaletteMode PaletteMode
	{
		get
		{
			return _contextMenu.PaletteMode;
		}
		set
		{
			if (_contextMenu.PaletteMode != value)
			{
				_service.OnComponentChanged(_contextMenu, null, _contextMenu.PaletteMode, value);
				_contextMenu.PaletteMode = value;
			}
		}
	}

	public KryptonContextMenuActionList(KryptonContextMenuDesigner owner)
		: base(owner.Component)
	{
		_contextMenu = owner.Component as KryptonContextMenu;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_contextMenu != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

using System.ComponentModel.Design;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonActionList : DesignerActionList
{
	private KryptonRibbon _ribbon;

	private IComponentChangeService _service;

	public bool InDesignHelperMode
	{
		get
		{
			return _ribbon.InDesignHelperMode;
		}
		set
		{
			_ribbon.InDesignHelperMode = value;
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _ribbon.PaletteMode;
		}
		set
		{
			if (_ribbon.PaletteMode != value)
			{
				_service.OnComponentChanged(_ribbon, null, _ribbon.PaletteMode, value);
				_ribbon.PaletteMode = value;
			}
		}
	}

	public KryptonRibbonActionList(KryptonRibbonDesigner owner)
		: base(owner.Component)
	{
		_ribbon = (KryptonRibbon)owner.Component;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_ribbon != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Design"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("InDesignHelperMode", "Design Helpers", "Design", "Show design time helpers for creating items."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

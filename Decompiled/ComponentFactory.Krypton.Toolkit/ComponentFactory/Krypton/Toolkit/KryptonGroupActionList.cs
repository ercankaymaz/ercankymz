using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonGroupActionList : DesignerActionList
{
	private KryptonGroup _group;

	private IComponentChangeService _service;

	public PaletteBackStyle GroupBackStyle
	{
		get
		{
			return _group.GroupBackStyle;
		}
		set
		{
			if (_group.GroupBackStyle != value)
			{
				_service.OnComponentChanged(_group, null, _group.GroupBackStyle, value);
				_group.GroupBackStyle = value;
			}
		}
	}

	public PaletteBorderStyle GroupBorderStyle
	{
		get
		{
			return _group.GroupBorderStyle;
		}
		set
		{
			if (_group.GroupBorderStyle != value)
			{
				_service.OnComponentChanged(_group, null, _group.GroupBorderStyle, value);
				_group.GroupBorderStyle = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _group.PaletteMode;
		}
		set
		{
			if (_group.PaletteMode != value)
			{
				_service.OnComponentChanged(_group, null, _group.PaletteMode, value);
				_group.PaletteMode = value;
			}
		}
	}

	public KryptonGroupActionList(KryptonGroupDesigner owner)
		: base(owner.Component)
	{
		_group = owner.Component as KryptonGroup;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_group != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("GroupBackStyle", "Back style", "Appearance", "Background style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("GroupBorderStyle", "Border style", "Appearance", "Border style"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

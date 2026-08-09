using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonPanelActionList : DesignerActionList
{
	private KryptonPanel _panel;

	private IComponentChangeService _service;

	public PaletteBackStyle PanelBackStyle
	{
		get
		{
			return _panel.PanelBackStyle;
		}
		set
		{
			if (_panel.PanelBackStyle != value)
			{
				_service.OnComponentChanged(_panel, null, _panel.PanelBackStyle, value);
				_panel.PanelBackStyle = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _panel.PaletteMode;
		}
		set
		{
			if (_panel.PaletteMode != value)
			{
				_service.OnComponentChanged(_panel, null, _panel.PaletteMode, value);
				_panel.PaletteMode = value;
			}
		}
	}

	public KryptonPanelActionList(KryptonPanelDesigner owner)
		: base(owner.Component)
	{
		_panel = owner.Component as KryptonPanel;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_panel != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PanelBackStyle", "Back style", "Appearance", "Background style"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

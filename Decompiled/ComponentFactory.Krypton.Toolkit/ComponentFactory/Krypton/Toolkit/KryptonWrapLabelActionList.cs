using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonWrapLabelActionList : DesignerActionList
{
	private KryptonWrapLabel _wrapLabel;

	private IComponentChangeService _service;

	public LabelStyle LabelStyle
	{
		get
		{
			return _wrapLabel.LabelStyle;
		}
		set
		{
			if (_wrapLabel.LabelStyle != value)
			{
				_service.OnComponentChanged(_wrapLabel, null, _wrapLabel.LabelStyle, value);
				_wrapLabel.LabelStyle = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _wrapLabel.PaletteMode;
		}
		set
		{
			if (_wrapLabel.PaletteMode != value)
			{
				_service.OnComponentChanged(_wrapLabel, null, _wrapLabel.PaletteMode, value);
				_wrapLabel.PaletteMode = value;
			}
		}
	}

	public KryptonWrapLabelActionList(KryptonWrapLabelDesigner owner)
		: base(owner.Component)
	{
		_wrapLabel = owner.Component as KryptonWrapLabel;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_wrapLabel != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("LabelStyle", "Style", "Appearance", "Label style"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

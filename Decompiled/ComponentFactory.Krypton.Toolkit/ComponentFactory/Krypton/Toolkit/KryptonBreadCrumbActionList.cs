using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonBreadCrumbActionList : DesignerActionList
{
	private KryptonBreadCrumb _breadCrumb;

	private IComponentChangeService _service;

	public PaletteBackStyle ControlBackStyle
	{
		get
		{
			return _breadCrumb.ControlBackStyle;
		}
		set
		{
			if (_breadCrumb.ControlBackStyle != value)
			{
				_service.OnComponentChanged(_breadCrumb, null, _breadCrumb.ControlBackStyle, value);
				_breadCrumb.ControlBackStyle = value;
			}
		}
	}

	public PaletteBorderStyle ControlBorderStyle
	{
		get
		{
			return _breadCrumb.ControlBorderStyle;
		}
		set
		{
			if (_breadCrumb.ControlBorderStyle != value)
			{
				_service.OnComponentChanged(_breadCrumb, null, _breadCrumb.ControlBorderStyle, value);
				_breadCrumb.ControlBorderStyle = value;
			}
		}
	}

	public ButtonStyle CrumbButtonStyle
	{
		get
		{
			return _breadCrumb.CrumbButtonStyle;
		}
		set
		{
			if (_breadCrumb.CrumbButtonStyle != value)
			{
				_service.OnComponentChanged(_breadCrumb, null, _breadCrumb.CrumbButtonStyle, value);
				_breadCrumb.CrumbButtonStyle = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _breadCrumb.PaletteMode;
		}
		set
		{
			if (_breadCrumb.PaletteMode != value)
			{
				_service.OnComponentChanged(_breadCrumb, null, _breadCrumb.PaletteMode, value);
				_breadCrumb.PaletteMode = value;
			}
		}
	}

	public KryptonBreadCrumbActionList(KryptonBreadCrumbDesigner owner)
		: base(owner.Component)
	{
		_breadCrumb = owner.Component as KryptonBreadCrumb;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_breadCrumb != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ControlBackStyle", "Back Style", "Appearance", "Background drawing style."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ControlBorderStyle", "Border Style", "Appearance", "Border drawing style."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("CrumbButtonStyle", "Crumb Style", "Appearance", "Crumb drawing style."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

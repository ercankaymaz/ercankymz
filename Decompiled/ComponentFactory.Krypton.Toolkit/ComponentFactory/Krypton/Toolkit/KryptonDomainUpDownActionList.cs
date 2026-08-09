using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonDomainUpDownActionList : DesignerActionList
{
	private KryptonDomainUpDown _domainUpDown;

	private IComponentChangeService _service;

	public PaletteMode PaletteMode
	{
		get
		{
			return _domainUpDown.PaletteMode;
		}
		set
		{
			if (_domainUpDown.PaletteMode != value)
			{
				_service.OnComponentChanged(_domainUpDown, null, _domainUpDown.PaletteMode, value);
				_domainUpDown.PaletteMode = value;
			}
		}
	}

	public InputControlStyle InputControlStyle
	{
		get
		{
			return _domainUpDown.InputControlStyle;
		}
		set
		{
			if (_domainUpDown.InputControlStyle != value)
			{
				_service.OnComponentChanged(_domainUpDown, null, _domainUpDown.InputControlStyle, value);
				_domainUpDown.InputControlStyle = value;
			}
		}
	}

	public KryptonDomainUpDownActionList(KryptonDomainUpDownDesigner owner)
		: base(owner.Component)
	{
		_domainUpDown = owner.Component as KryptonDomainUpDown;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_domainUpDown != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("InputControlStyle", "Style", "Appearance", "DomainUpDown display style."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

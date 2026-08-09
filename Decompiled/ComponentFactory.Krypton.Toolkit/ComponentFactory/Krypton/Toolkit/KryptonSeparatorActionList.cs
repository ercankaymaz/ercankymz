using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonSeparatorActionList : DesignerActionList
{
	private KryptonSeparator _separator;

	private IComponentChangeService _service;

	public SeparatorStyle SeparatorStyle
	{
		get
		{
			return _separator.SeparatorStyle;
		}
		set
		{
			if (_separator.SeparatorStyle != value)
			{
				_service.OnComponentChanged(_separator, null, _separator.SeparatorStyle, value);
				_separator.SeparatorStyle = value;
			}
		}
	}

	public Orientation Orientation
	{
		get
		{
			return _separator.Orientation;
		}
		set
		{
			if (_separator.Orientation != value)
			{
				_service.OnComponentChanged(_separator, null, _separator.Orientation, value);
				_separator.Orientation = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _separator.PaletteMode;
		}
		set
		{
			if (_separator.PaletteMode != value)
			{
				_service.OnComponentChanged(_separator, null, _separator.PaletteMode, value);
				_separator.PaletteMode = value;
			}
		}
	}

	public KryptonSeparatorActionList(KryptonSeparatorDesigner owner)
		: base(owner.Component)
	{
		_separator = owner.Component as KryptonSeparator;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_separator != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("SeparatorStyle", "Style", "Appearance", "Separator style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Visual orientation"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

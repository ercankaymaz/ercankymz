using System.ComponentModel.Design;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonHeaderActionList : DesignerActionList
{
	private KryptonHeader _header;

	private IComponentChangeService _service;

	public HeaderStyle HeaderStyle
	{
		get
		{
			return _header.HeaderStyle;
		}
		set
		{
			if (_header.HeaderStyle != value)
			{
				_service.OnComponentChanged(_header, null, _header.HeaderStyle, value);
				_header.HeaderStyle = value;
			}
		}
	}

	public VisualOrientation Orientation
	{
		get
		{
			return _header.Orientation;
		}
		set
		{
			if (_header.Orientation != value)
			{
				_service.OnComponentChanged(_header, null, _header.Orientation, value);
				_header.Orientation = value;
			}
		}
	}

	public string Heading
	{
		get
		{
			return _header.Values.Heading;
		}
		set
		{
			if (_header.Values.Heading != value)
			{
				_service.OnComponentChanged(_header, null, _header.Values.Heading, value);
				_header.Values.Heading = value;
			}
		}
	}

	public string Description
	{
		get
		{
			return _header.Values.Description;
		}
		set
		{
			if (_header.Values.Description != value)
			{
				_service.OnComponentChanged(_header, null, _header.Values.Description, value);
				_header.Values.Description = value;
			}
		}
	}

	public Image Image
	{
		get
		{
			return _header.Values.Image;
		}
		set
		{
			if (_header.Values.Image != value)
			{
				_service.OnComponentChanged(_header, null, _header.Values.Image, value);
				_header.Values.Image = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _header.PaletteMode;
		}
		set
		{
			if (_header.PaletteMode != value)
			{
				_service.OnComponentChanged(_header, null, _header.PaletteMode, value);
				_header.PaletteMode = value;
			}
		}
	}

	public KryptonHeaderActionList(KryptonHeaderDesigner owner)
		: base(owner.Component)
	{
		_header = owner.Component as KryptonHeader;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_header != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("HeaderStyle", "Style", "Appearance", "Header style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Header orientation"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Values"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Heading", "Heading", "Values", "Heading text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Description", "Description", "Values", "Header description text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Image", "Image", "Values", "Heading image"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

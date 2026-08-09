using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonGroupBoxActionList : DesignerActionList
{
	private KryptonGroupBox _groupBox;

	private IComponentChangeService _service;

	public PaletteBackStyle GroupBackStyle
	{
		get
		{
			return _groupBox.GroupBackStyle;
		}
		set
		{
			if (_groupBox.GroupBackStyle != value)
			{
				_service.OnComponentChanged(_groupBox, null, _groupBox.GroupBackStyle, value);
				_groupBox.GroupBackStyle = value;
			}
		}
	}

	public PaletteBorderStyle GroupBorderStyle
	{
		get
		{
			return _groupBox.GroupBorderStyle;
		}
		set
		{
			if (_groupBox.GroupBorderStyle != value)
			{
				_service.OnComponentChanged(_groupBox, null, _groupBox.GroupBorderStyle, value);
				_groupBox.GroupBorderStyle = value;
			}
		}
	}

	public LabelStyle CaptionStyle
	{
		get
		{
			return _groupBox.CaptionStyle;
		}
		set
		{
			if (_groupBox.CaptionStyle != value)
			{
				_service.OnComponentChanged(_groupBox, null, _groupBox.CaptionStyle, value);
				_groupBox.CaptionStyle = value;
			}
		}
	}

	public VisualOrientation CaptionEdge
	{
		get
		{
			return _groupBox.CaptionEdge;
		}
		set
		{
			if (_groupBox.CaptionEdge != value)
			{
				_service.OnComponentChanged(_groupBox, null, _groupBox.CaptionEdge, value);
				_groupBox.CaptionEdge = value;
			}
		}
	}

	public double CaptionOverlap
	{
		get
		{
			return _groupBox.CaptionOverlap;
		}
		set
		{
			if (_groupBox.CaptionOverlap != value)
			{
				_service.OnComponentChanged(_groupBox, null, _groupBox.CaptionOverlap, value);
				_groupBox.CaptionOverlap = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _groupBox.PaletteMode;
		}
		set
		{
			if (_groupBox.PaletteMode != value)
			{
				_service.OnComponentChanged(_groupBox, null, _groupBox.PaletteMode, value);
				_groupBox.PaletteMode = value;
			}
		}
	}

	public KryptonGroupBoxActionList(KryptonGroupBoxDesigner owner)
		: base(owner.Component)
	{
		_groupBox = owner.Component as KryptonGroupBox;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_groupBox != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("GroupBackStyle", "Back style", "Appearance", "Background style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("GroupBorderStyle", "Border style", "Appearance", "Border style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("CaptionStyle", "Caption style", "Appearance", "Caption style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("CaptionEdge", "Caption edge", "Appearance", "Caption edge"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("CaptionOverlap", "Caption overlap", "Appearance", "Caption overlap"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

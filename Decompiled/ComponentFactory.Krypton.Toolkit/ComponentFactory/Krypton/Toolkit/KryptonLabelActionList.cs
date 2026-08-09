using System.ComponentModel.Design;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonLabelActionList : DesignerActionList
{
	private KryptonLabel _label;

	private IComponentChangeService _service;

	public LabelStyle LabelStyle
	{
		get
		{
			return _label.LabelStyle;
		}
		set
		{
			if (_label.LabelStyle != value)
			{
				_service.OnComponentChanged(_label, null, _label.LabelStyle, value);
				_label.LabelStyle = value;
			}
		}
	}

	public VisualOrientation Orientation
	{
		get
		{
			return _label.Orientation;
		}
		set
		{
			if (_label.Orientation != value)
			{
				_service.OnComponentChanged(_label, null, _label.Orientation, value);
				_label.Orientation = value;
			}
		}
	}

	public string Text
	{
		get
		{
			return _label.Values.Text;
		}
		set
		{
			if (_label.Values.Text != value)
			{
				_service.OnComponentChanged(_label, null, _label.Values.Text, value);
				_label.Values.Text = value;
			}
		}
	}

	public string ExtraText
	{
		get
		{
			return _label.Values.ExtraText;
		}
		set
		{
			if (_label.Values.ExtraText != value)
			{
				_service.OnComponentChanged(_label, null, _label.Values.ExtraText, value);
				_label.Values.ExtraText = value;
			}
		}
	}

	public Image Image
	{
		get
		{
			return _label.Values.Image;
		}
		set
		{
			if (_label.Values.Image != value)
			{
				_service.OnComponentChanged(_label, null, _label.Values.Image, value);
				_label.Values.Image = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _label.PaletteMode;
		}
		set
		{
			if (_label.PaletteMode != value)
			{
				_service.OnComponentChanged(_label, null, _label.PaletteMode, value);
				_label.PaletteMode = value;
			}
		}
	}

	public KryptonLabelActionList(KryptonLabelDesigner owner)
		: base(owner.Component)
	{
		_label = owner.Component as KryptonLabel;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_label != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("LabelStyle", "Style", "Appearance", "Label style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Visual orientation"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Values"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Text", "Text", "Values", "Label text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ExtraText", "ExtraText", "Values", "Label extra text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Image", "Image", "Values", "Label image"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

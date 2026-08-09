using System.ComponentModel.Design;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonButtonActionList : DesignerActionList
{
	private KryptonButton _button;

	private IComponentChangeService _service;

	public ButtonStyle ButtonStyle
	{
		get
		{
			return _button.ButtonStyle;
		}
		set
		{
			if (_button.ButtonStyle != value)
			{
				_service.OnComponentChanged(_button, null, _button.ButtonStyle, value);
				_button.ButtonStyle = value;
			}
		}
	}

	public VisualOrientation Orientation
	{
		get
		{
			return _button.Orientation;
		}
		set
		{
			if (_button.Orientation != value)
			{
				_service.OnComponentChanged(_button, null, _button.Orientation, value);
				_button.Orientation = value;
			}
		}
	}

	public string Text
	{
		get
		{
			return _button.Values.Text;
		}
		set
		{
			if (_button.Values.Text != value)
			{
				_service.OnComponentChanged(_button, null, _button.Values.Text, value);
				_button.Values.Text = value;
			}
		}
	}

	public string ExtraText
	{
		get
		{
			return _button.Values.ExtraText;
		}
		set
		{
			if (_button.Values.ExtraText != value)
			{
				_service.OnComponentChanged(_button, null, _button.Values.ExtraText, value);
				_button.Values.ExtraText = value;
			}
		}
	}

	public Image Image
	{
		get
		{
			return _button.Values.Image;
		}
		set
		{
			if (_button.Values.Image != value)
			{
				_service.OnComponentChanged(_button, null, _button.Values.Image, value);
				_button.Values.Image = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _button.PaletteMode;
		}
		set
		{
			if (_button.PaletteMode != value)
			{
				_service.OnComponentChanged(_button, null, _button.PaletteMode, value);
				_button.PaletteMode = value;
			}
		}
	}

	public KryptonButtonActionList(KryptonButtonDesigner owner)
		: base(owner.Component)
	{
		_button = owner.Component as KryptonButton;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_button != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ButtonStyle", "Style", "Appearance", "Button style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Button orientation"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Values"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Text", "Text", "Values", "Button text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ExtraText", "ExtraText", "Values", "Button extra text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Image", "Image", "Values", "Button image"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

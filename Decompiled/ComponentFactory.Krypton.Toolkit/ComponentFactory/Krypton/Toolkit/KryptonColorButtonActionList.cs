using System.ComponentModel.Design;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonColorButtonActionList : DesignerActionList
{
	private KryptonColorButton _colorButton;

	private IComponentChangeService _service;

	public ButtonStyle ButtonStyle
	{
		get
		{
			return _colorButton.ButtonStyle;
		}
		set
		{
			if (_colorButton.ButtonStyle != value)
			{
				_service.OnComponentChanged(_colorButton, null, _colorButton.ButtonStyle, value);
				_colorButton.ButtonStyle = value;
			}
		}
	}

	public VisualOrientation ButtonOrientation
	{
		get
		{
			return _colorButton.ButtonOrientation;
		}
		set
		{
			if (_colorButton.ButtonOrientation != value)
			{
				_service.OnComponentChanged(_colorButton, null, _colorButton.ButtonOrientation, value);
				_colorButton.ButtonOrientation = value;
			}
		}
	}

	public VisualOrientation DropDownPosition
	{
		get
		{
			return _colorButton.DropDownPosition;
		}
		set
		{
			if (_colorButton.DropDownPosition != value)
			{
				_service.OnComponentChanged(_colorButton, null, _colorButton.DropDownPosition, value);
				_colorButton.DropDownPosition = value;
			}
		}
	}

	public VisualOrientation DropDownOrientation
	{
		get
		{
			return _colorButton.DropDownOrientation;
		}
		set
		{
			if (_colorButton.DropDownOrientation != value)
			{
				_service.OnComponentChanged(_colorButton, null, _colorButton.DropDownOrientation, value);
				_colorButton.DropDownOrientation = value;
			}
		}
	}

	public bool Splitter
	{
		get
		{
			return _colorButton.Splitter;
		}
		set
		{
			if (_colorButton.Splitter != value)
			{
				_service.OnComponentChanged(_colorButton, null, _colorButton.Splitter, value);
				_colorButton.Splitter = value;
			}
		}
	}

	public string Text
	{
		get
		{
			return _colorButton.Values.Text;
		}
		set
		{
			if (_colorButton.Values.Text != value)
			{
				_service.OnComponentChanged(_colorButton, null, _colorButton.Values.Text, value);
				_colorButton.Values.Text = value;
			}
		}
	}

	public string ExtraText
	{
		get
		{
			return _colorButton.Values.ExtraText;
		}
		set
		{
			if (_colorButton.Values.ExtraText != value)
			{
				_service.OnComponentChanged(_colorButton, null, _colorButton.Values.ExtraText, value);
				_colorButton.Values.ExtraText = value;
			}
		}
	}

	public Image Image
	{
		get
		{
			return _colorButton.Values.Image;
		}
		set
		{
			if (_colorButton.Values.Image != value)
			{
				_service.OnComponentChanged(_colorButton, null, _colorButton.Values.Image, value);
				_colorButton.Values.Image = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _colorButton.PaletteMode;
		}
		set
		{
			if (_colorButton.PaletteMode != value)
			{
				_service.OnComponentChanged(_colorButton, null, _colorButton.PaletteMode, value);
				_colorButton.PaletteMode = value;
			}
		}
	}

	public KryptonColorButtonActionList(KryptonColorButtonDesigner owner)
		: base(owner.Component)
	{
		_colorButton = owner.Component as KryptonColorButton;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_colorButton != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Splitter", "Splitter", "Appearance", "Splitter of DropDown"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ButtonStyle", "ButtonStyle", "Appearance", "Button style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ButtonOrientation", "ButtonOrientation", "Appearance", "Button orientation"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("DropDownPosition", "DropDownPosition", "Appearance", "DropDown position"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("DropDownOrientation", "DropDownOrientation", "Appearance", "DropDown orientation"));
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

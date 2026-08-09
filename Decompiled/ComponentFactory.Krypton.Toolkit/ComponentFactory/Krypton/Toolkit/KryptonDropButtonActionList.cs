using System.ComponentModel.Design;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonDropButtonActionList : DesignerActionList
{
	private KryptonDropButton _dropButton;

	private IComponentChangeService _service;

	public ButtonStyle ButtonStyle
	{
		get
		{
			return _dropButton.ButtonStyle;
		}
		set
		{
			if (_dropButton.ButtonStyle != value)
			{
				_service.OnComponentChanged(_dropButton, null, _dropButton.ButtonStyle, value);
				_dropButton.ButtonStyle = value;
			}
		}
	}

	public VisualOrientation ButtonOrientation
	{
		get
		{
			return _dropButton.ButtonOrientation;
		}
		set
		{
			if (_dropButton.ButtonOrientation != value)
			{
				_service.OnComponentChanged(_dropButton, null, _dropButton.ButtonOrientation, value);
				_dropButton.ButtonOrientation = value;
			}
		}
	}

	public VisualOrientation DropDownPosition
	{
		get
		{
			return _dropButton.DropDownPosition;
		}
		set
		{
			if (_dropButton.DropDownPosition != value)
			{
				_service.OnComponentChanged(_dropButton, null, _dropButton.DropDownPosition, value);
				_dropButton.DropDownPosition = value;
			}
		}
	}

	public VisualOrientation DropDownOrientation
	{
		get
		{
			return _dropButton.DropDownOrientation;
		}
		set
		{
			if (_dropButton.DropDownOrientation != value)
			{
				_service.OnComponentChanged(_dropButton, null, _dropButton.DropDownOrientation, value);
				_dropButton.DropDownOrientation = value;
			}
		}
	}

	public bool Splitter
	{
		get
		{
			return _dropButton.Splitter;
		}
		set
		{
			if (_dropButton.Splitter != value)
			{
				_service.OnComponentChanged(_dropButton, null, _dropButton.Splitter, value);
				_dropButton.Splitter = value;
			}
		}
	}

	public string Text
	{
		get
		{
			return _dropButton.Values.Text;
		}
		set
		{
			if (_dropButton.Values.Text != value)
			{
				_service.OnComponentChanged(_dropButton, null, _dropButton.Values.Text, value);
				_dropButton.Values.Text = value;
			}
		}
	}

	public string ExtraText
	{
		get
		{
			return _dropButton.Values.ExtraText;
		}
		set
		{
			if (_dropButton.Values.ExtraText != value)
			{
				_service.OnComponentChanged(_dropButton, null, _dropButton.Values.ExtraText, value);
				_dropButton.Values.ExtraText = value;
			}
		}
	}

	public Image Image
	{
		get
		{
			return _dropButton.Values.Image;
		}
		set
		{
			if (_dropButton.Values.Image != value)
			{
				_service.OnComponentChanged(_dropButton, null, _dropButton.Values.Image, value);
				_dropButton.Values.Image = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _dropButton.PaletteMode;
		}
		set
		{
			if (_dropButton.PaletteMode != value)
			{
				_service.OnComponentChanged(_dropButton, null, _dropButton.PaletteMode, value);
				_dropButton.PaletteMode = value;
			}
		}
	}

	public KryptonDropButtonActionList(KryptonDropButtonDesigner owner)
		: base(owner.Component)
	{
		_dropButton = owner.Component as KryptonDropButton;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_dropButton != null)
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

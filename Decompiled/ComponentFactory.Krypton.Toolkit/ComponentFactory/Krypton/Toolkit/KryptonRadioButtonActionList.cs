using System.ComponentModel.Design;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonRadioButtonActionList : DesignerActionList
{
	private KryptonRadioButton _radioButton;

	private IComponentChangeService _service;

	public bool Checked
	{
		get
		{
			return _radioButton.Checked;
		}
		set
		{
			if (_radioButton.Checked != value)
			{
				_service.OnComponentChanged(_radioButton, null, _radioButton.Checked, value);
				_radioButton.Checked = value;
			}
		}
	}

	public bool AutoCheck
	{
		get
		{
			return _radioButton.AutoCheck;
		}
		set
		{
			if (_radioButton.AutoCheck != value)
			{
				_service.OnComponentChanged(_radioButton, null, _radioButton.AutoCheck, value);
				_radioButton.AutoCheck = value;
			}
		}
	}

	public LabelStyle LabelStyle
	{
		get
		{
			return _radioButton.LabelStyle;
		}
		set
		{
			if (_radioButton.LabelStyle != value)
			{
				_service.OnComponentChanged(_radioButton, null, _radioButton.LabelStyle, value);
				_radioButton.LabelStyle = value;
			}
		}
	}

	public VisualOrientation Orientation
	{
		get
		{
			return _radioButton.Orientation;
		}
		set
		{
			if (_radioButton.Orientation != value)
			{
				_service.OnComponentChanged(_radioButton, null, _radioButton.Orientation, value);
				_radioButton.Orientation = value;
			}
		}
	}

	public string Text
	{
		get
		{
			return _radioButton.Values.Text;
		}
		set
		{
			if (_radioButton.Values.Text != value)
			{
				_service.OnComponentChanged(_radioButton, null, _radioButton.Values.Text, value);
				_radioButton.Values.Text = value;
			}
		}
	}

	public string ExtraText
	{
		get
		{
			return _radioButton.Values.ExtraText;
		}
		set
		{
			if (_radioButton.Values.ExtraText != value)
			{
				_service.OnComponentChanged(_radioButton, null, _radioButton.Values.ExtraText, value);
				_radioButton.Values.ExtraText = value;
			}
		}
	}

	public Image Image
	{
		get
		{
			return _radioButton.Values.Image;
		}
		set
		{
			if (_radioButton.Values.Image != value)
			{
				_service.OnComponentChanged(_radioButton, null, _radioButton.Values.Image, value);
				_radioButton.Values.Image = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _radioButton.PaletteMode;
		}
		set
		{
			if (_radioButton.PaletteMode != value)
			{
				_service.OnComponentChanged(_radioButton, null, _radioButton.PaletteMode, value);
				_radioButton.PaletteMode = value;
			}
		}
	}

	public KryptonRadioButtonActionList(KryptonRadioButtonDesigner owner)
		: base(owner.Component)
	{
		_radioButton = owner.Component as KryptonRadioButton;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_radioButton != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Operation"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Checked", "Checked", "Operation", "Checked state"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("AutoCheck", "AutoCheck", "Operation", "AutoCheck of other instances."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("LabelStyle", "Style", "Appearance", "Label style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Visual orientation"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Values"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Text", "Text", "Values", "Radio button text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ExtraText", "ExtraText", "Values", "Radio button extra text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Image", "Image", "Values", "Radio button image"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

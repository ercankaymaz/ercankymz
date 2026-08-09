using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCheckBoxActionList : DesignerActionList
{
	private KryptonCheckBox _checkBox;

	private IComponentChangeService _service;

	public bool Checked
	{
		get
		{
			return _checkBox.Checked;
		}
		set
		{
			if (_checkBox.Checked != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.Checked, value);
				_checkBox.Checked = value;
			}
		}
	}

	public CheckState CheckState
	{
		get
		{
			return _checkBox.CheckState;
		}
		set
		{
			if (_checkBox.CheckState != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.CheckState, value);
				_checkBox.CheckState = value;
			}
		}
	}

	public bool ThreeState
	{
		get
		{
			return _checkBox.ThreeState;
		}
		set
		{
			if (_checkBox.ThreeState != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.ThreeState, value);
				_checkBox.ThreeState = value;
			}
		}
	}

	public bool AutoCheck
	{
		get
		{
			return _checkBox.AutoCheck;
		}
		set
		{
			if (_checkBox.AutoCheck != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.AutoCheck, value);
				_checkBox.AutoCheck = value;
			}
		}
	}

	public LabelStyle LabelStyle
	{
		get
		{
			return _checkBox.LabelStyle;
		}
		set
		{
			if (_checkBox.LabelStyle != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.LabelStyle, value);
				_checkBox.LabelStyle = value;
			}
		}
	}

	public VisualOrientation Orientation
	{
		get
		{
			return _checkBox.Orientation;
		}
		set
		{
			if (_checkBox.Orientation != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.Orientation, value);
				_checkBox.Orientation = value;
			}
		}
	}

	public string Text
	{
		get
		{
			return _checkBox.Values.Text;
		}
		set
		{
			if (_checkBox.Values.Text != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.Values.Text, value);
				_checkBox.Values.Text = value;
			}
		}
	}

	public string ExtraText
	{
		get
		{
			return _checkBox.Values.ExtraText;
		}
		set
		{
			if (_checkBox.Values.ExtraText != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.Values.ExtraText, value);
				_checkBox.Values.ExtraText = value;
			}
		}
	}

	public Image Image
	{
		get
		{
			return _checkBox.Values.Image;
		}
		set
		{
			if (_checkBox.Values.Image != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.Values.Image, value);
				_checkBox.Values.Image = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _checkBox.PaletteMode;
		}
		set
		{
			if (_checkBox.PaletteMode != value)
			{
				_service.OnComponentChanged(_checkBox, null, _checkBox.PaletteMode, value);
				_checkBox.PaletteMode = value;
			}
		}
	}

	public KryptonCheckBoxActionList(KryptonCheckBoxDesigner owner)
		: base(owner.Component)
	{
		_checkBox = owner.Component as KryptonCheckBox;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_checkBox != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Operation"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Checked", "Checked", "Operation", "Checked state"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("AutoCheck", "AutoCheck", "Operation", "AutoCheck of other instances."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ThreeState", "ThreeState", "Operation", "ThreeState setting"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("LabelStyle", "Style", "Appearance", "Label style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Visual orientation"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Values"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Text", "Text", "Values", "Checkbox text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ExtraText", "ExtraText", "Values", "Checkbox extra text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Image", "Image", "Values", "Checkbox image"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

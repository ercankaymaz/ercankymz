using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonDateTimePickerActionList : DesignerActionList
{
	private KryptonDateTimePicker _dateTimePicker;

	private IComponentChangeService _service;

	public DateTimePickerFormat Format
	{
		get
		{
			return _dateTimePicker.Format;
		}
		set
		{
			if (_dateTimePicker.Format != value)
			{
				_service.OnComponentChanged(_dateTimePicker, null, _dateTimePicker.Format, value);
				_dateTimePicker.Format = value;
			}
		}
	}

	public bool ShowUpDown
	{
		get
		{
			return _dateTimePicker.ShowUpDown;
		}
		set
		{
			if (_dateTimePicker.ShowUpDown != value)
			{
				_service.OnComponentChanged(_dateTimePicker, null, _dateTimePicker.ShowUpDown, value);
				_dateTimePicker.ShowUpDown = value;
			}
		}
	}

	public bool ShowCheckBox
	{
		get
		{
			return _dateTimePicker.ShowCheckBox;
		}
		set
		{
			if (_dateTimePicker.ShowCheckBox != value)
			{
				_service.OnComponentChanged(_dateTimePicker, null, _dateTimePicker.ShowCheckBox, value);
				_dateTimePicker.ShowCheckBox = value;
			}
		}
	}

	public bool Checked
	{
		get
		{
			return _dateTimePicker.Checked;
		}
		set
		{
			if (_dateTimePicker.Checked != value)
			{
				_service.OnComponentChanged(_dateTimePicker, null, _dateTimePicker.Checked, value);
				_dateTimePicker.Checked = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _dateTimePicker.PaletteMode;
		}
		set
		{
			if (_dateTimePicker.PaletteMode != value)
			{
				_service.OnComponentChanged(_dateTimePicker, null, _dateTimePicker.PaletteMode, value);
				_dateTimePicker.PaletteMode = value;
			}
		}
	}

	public KryptonDateTimePickerActionList(KryptonDateTimePickerDesigner owner)
		: base(owner.Component)
	{
		_dateTimePicker = owner.Component as KryptonDateTimePicker;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_dateTimePicker != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Format", "Format", "Appearance", "Decide what to display in the edit portion of the control"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowUpDown", "ShowUpDown", "Appearance", "Display up and down buttons for modifying dates and times"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowCheckBox", "ShowCheckBox", "Appearance", "Display a check box allowing the user to set the value is null"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Checked", "Checked", "Appearance", "Is the current value null"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

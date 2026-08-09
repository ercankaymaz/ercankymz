using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonComboBoxActionList : DesignerActionList
{
	private KryptonComboBox _comboBox;

	private IComponentChangeService _service;

	public PaletteMode PaletteMode
	{
		get
		{
			return _comboBox.PaletteMode;
		}
		set
		{
			if (_comboBox.PaletteMode != value)
			{
				_service.OnComponentChanged(_comboBox, null, _comboBox.PaletteMode, value);
				_comboBox.PaletteMode = value;
			}
		}
	}

	public InputControlStyle InputControlStyle
	{
		get
		{
			return _comboBox.InputControlStyle;
		}
		set
		{
			if (_comboBox.InputControlStyle != value)
			{
				_service.OnComponentChanged(_comboBox, null, _comboBox.InputControlStyle, value);
				_comboBox.InputControlStyle = value;
			}
		}
	}

	public KryptonComboBoxActionList(KryptonComboBoxDesigner owner)
		: base(owner.Component)
	{
		_comboBox = owner.Component as KryptonComboBox;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_comboBox != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("InputControlStyle", "Style", "Appearance", "ComboBox display style."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

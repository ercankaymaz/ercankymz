using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonMaskedTextBoxActionList : DesignerActionList
{
	private KryptonMaskedTextBox _maskedTextBox;

	private IComponentChangeService _service;

	public PaletteMode PaletteMode
	{
		get
		{
			return _maskedTextBox.PaletteMode;
		}
		set
		{
			if (_maskedTextBox.PaletteMode != value)
			{
				_service.OnComponentChanged(_maskedTextBox, null, _maskedTextBox.PaletteMode, value);
				_maskedTextBox.PaletteMode = value;
			}
		}
	}

	public InputControlStyle InputControlStyle
	{
		get
		{
			return _maskedTextBox.InputControlStyle;
		}
		set
		{
			if (_maskedTextBox.InputControlStyle != value)
			{
				_service.OnComponentChanged(_maskedTextBox, null, _maskedTextBox.InputControlStyle, value);
				_maskedTextBox.InputControlStyle = value;
			}
		}
	}

	public string Mask
	{
		get
		{
			return _maskedTextBox.Mask;
		}
		set
		{
			if (_maskedTextBox.Mask != value)
			{
				_service.OnComponentChanged(_maskedTextBox, null, _maskedTextBox.Mask, value);
				_maskedTextBox.Mask = value;
			}
		}
	}

	public KryptonMaskedTextBoxActionList(KryptonMaskedTextBoxDesigner owner)
		: base(owner.Component)
	{
		_maskedTextBox = owner.Component as KryptonMaskedTextBox;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_maskedTextBox != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("InputControlStyle", "Style", "Appearance", "TextBox display style."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("MaskedTextBox"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Mask", "Mask", "MaskedTextBox", "Input mask."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

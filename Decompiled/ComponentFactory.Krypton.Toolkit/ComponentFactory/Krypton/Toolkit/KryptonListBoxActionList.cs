using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonListBoxActionList : DesignerActionList
{
	private KryptonListBox _listBox;

	private IComponentChangeService _service;

	public ButtonStyle ItemStyle
	{
		get
		{
			return _listBox.ItemStyle;
		}
		set
		{
			if (_listBox.ItemStyle != value)
			{
				_service.OnComponentChanged(_listBox, null, _listBox.ItemStyle, value);
				_listBox.ItemStyle = value;
			}
		}
	}

	public PaletteBackStyle BackStyle
	{
		get
		{
			return _listBox.BackStyle;
		}
		set
		{
			if (_listBox.BackStyle != value)
			{
				_service.OnComponentChanged(_listBox, null, _listBox.BackStyle, value);
				_listBox.BackStyle = value;
			}
		}
	}

	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _listBox.BorderStyle;
		}
		set
		{
			if (_listBox.BorderStyle != value)
			{
				_service.OnComponentChanged(_listBox, null, _listBox.BorderStyle, value);
				_listBox.BorderStyle = value;
			}
		}
	}

	public SelectionMode SelectionMode
	{
		get
		{
			return _listBox.SelectionMode;
		}
		set
		{
			if (_listBox.SelectionMode != value)
			{
				_service.OnComponentChanged(_listBox, null, _listBox.SelectionMode, value);
				_listBox.SelectionMode = value;
			}
		}
	}

	public bool Sorted
	{
		get
		{
			return _listBox.Sorted;
		}
		set
		{
			if (_listBox.Sorted != value)
			{
				_service.OnComponentChanged(_listBox, null, _listBox.Sorted, value);
				_listBox.Sorted = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _listBox.PaletteMode;
		}
		set
		{
			if (_listBox.PaletteMode != value)
			{
				_service.OnComponentChanged(_listBox, null, _listBox.PaletteMode, value);
				_listBox.PaletteMode = value;
			}
		}
	}

	public KryptonListBoxActionList(KryptonListBoxDesigner owner)
		: base(owner.Component)
	{
		_listBox = owner.Component as KryptonListBox;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_listBox != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("BackStyle", "Back Style", "Appearance", "Style used to draw background."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("BorderStyle", "Border Style", "Appearance", "Style used to draw the border."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ItemStyle", "Item Style", "Appearance", "How to display list items."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Behavior"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("SelectionMode", "Selection Mode", "Behavior", "Determines the selection mode."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Sorted", "Sorted", "Behavior", "Should items be sorted according to string."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

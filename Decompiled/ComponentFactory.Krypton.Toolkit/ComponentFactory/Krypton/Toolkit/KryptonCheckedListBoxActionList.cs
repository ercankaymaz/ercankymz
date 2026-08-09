using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCheckedListBoxActionList : DesignerActionList
{
	private KryptonCheckedListBox _checkedListBox;

	private IComponentChangeService _service;

	public ButtonStyle ItemStyle
	{
		get
		{
			return _checkedListBox.ItemStyle;
		}
		set
		{
			if (_checkedListBox.ItemStyle != value)
			{
				_service.OnComponentChanged(_checkedListBox, null, _checkedListBox.ItemStyle, value);
				_checkedListBox.ItemStyle = value;
			}
		}
	}

	public PaletteBackStyle BackStyle
	{
		get
		{
			return _checkedListBox.BackStyle;
		}
		set
		{
			if (_checkedListBox.BackStyle != value)
			{
				_service.OnComponentChanged(_checkedListBox, null, _checkedListBox.BackStyle, value);
				_checkedListBox.BackStyle = value;
			}
		}
	}

	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _checkedListBox.BorderStyle;
		}
		set
		{
			if (_checkedListBox.BorderStyle != value)
			{
				_service.OnComponentChanged(_checkedListBox, null, _checkedListBox.BorderStyle, value);
				_checkedListBox.BorderStyle = value;
			}
		}
	}

	public CheckedSelectionMode SelectionMode
	{
		get
		{
			return _checkedListBox.SelectionMode;
		}
		set
		{
			if (_checkedListBox.SelectionMode != value)
			{
				_service.OnComponentChanged(_checkedListBox, null, _checkedListBox.SelectionMode, value);
				_checkedListBox.SelectionMode = value;
			}
		}
	}

	public bool Sorted
	{
		get
		{
			return _checkedListBox.Sorted;
		}
		set
		{
			if (_checkedListBox.Sorted != value)
			{
				_service.OnComponentChanged(_checkedListBox, null, _checkedListBox.Sorted, value);
				_checkedListBox.Sorted = value;
			}
		}
	}

	public bool CheckOnClick
	{
		get
		{
			return _checkedListBox.CheckOnClick;
		}
		set
		{
			if (_checkedListBox.CheckOnClick != value)
			{
				_service.OnComponentChanged(_checkedListBox, null, _checkedListBox.CheckOnClick, value);
				_checkedListBox.CheckOnClick = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _checkedListBox.PaletteMode;
		}
		set
		{
			if (_checkedListBox.PaletteMode != value)
			{
				_service.OnComponentChanged(_checkedListBox, null, _checkedListBox.PaletteMode, value);
				_checkedListBox.PaletteMode = value;
			}
		}
	}

	public KryptonCheckedListBoxActionList(KryptonCheckedListBoxDesigner owner)
		: base(owner.Component)
	{
		_checkedListBox = owner.Component as KryptonCheckedListBox;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_checkedListBox != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("BackStyle", "Back Style", "Appearance", "Style used to draw background."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("BorderStyle", "Border Style", "Appearance", "Style used to draw the border."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ItemStyle", "Item Style", "Appearance", "How to display list items."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Behavior"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("SelectionMode", "Selection Mode", "Behavior", "Determines the selection mode."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Sorted", "Sorted", "Behavior", "Should items be sorted according to string."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("CheckOnClick", "CheckOnClick", "Behavior", "Should clicking an item toggle its checked state."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

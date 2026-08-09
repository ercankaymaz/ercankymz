using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonTreeViewActionList : DesignerActionList
{
	private KryptonTreeView _treeView;

	private IComponentChangeService _service;

	public ButtonStyle ItemStyle
	{
		get
		{
			return _treeView.ItemStyle;
		}
		set
		{
			if (_treeView.ItemStyle != value)
			{
				_service.OnComponentChanged(_treeView, null, _treeView.ItemStyle, value);
				_treeView.ItemStyle = value;
			}
		}
	}

	public PaletteBackStyle BackStyle
	{
		get
		{
			return _treeView.BackStyle;
		}
		set
		{
			if (_treeView.BackStyle != value)
			{
				_service.OnComponentChanged(_treeView, null, _treeView.BackStyle, value);
				_treeView.BackStyle = value;
			}
		}
	}

	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _treeView.BorderStyle;
		}
		set
		{
			if (_treeView.BorderStyle != value)
			{
				_service.OnComponentChanged(_treeView, null, _treeView.BorderStyle, value);
				_treeView.BorderStyle = value;
			}
		}
	}

	public bool Sorted
	{
		get
		{
			return _treeView.Sorted;
		}
		set
		{
			if (_treeView.Sorted != value)
			{
				_service.OnComponentChanged(_treeView, null, _treeView.Sorted, value);
				_treeView.Sorted = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _treeView.PaletteMode;
		}
		set
		{
			if (_treeView.PaletteMode != value)
			{
				_service.OnComponentChanged(_treeView, null, _treeView.PaletteMode, value);
				_treeView.PaletteMode = value;
			}
		}
	}

	public KryptonTreeViewActionList(KryptonTreeViewDesigner owner)
		: base(owner.Component)
	{
		_treeView = owner.Component as KryptonTreeView;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_treeView != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("BackStyle", "Back Style", "Appearance", "Style used to draw background."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("BorderStyle", "Border Style", "Appearance", "Style used to draw the border."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ItemStyle", "Item Style", "Appearance", "How to display tree items."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Behavior"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Sorted", "Sorted", "Behavior", "Should items be sorted according to string."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}

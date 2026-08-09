using System;
using System.Collections.Generic;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer.Converters;

public class ToolBarCollectionEditor : EyeshotCollectionEditorArray<ToolBar>
{
	public ToolBarCollectionEditor(Type type)
		: base(type)
	{
	}

	protected override object SetItems(object editValue, object[] value)
	{
		object obj = base.SetItems(editValue, value);
		viewport.ToolBars = (ToolBar[])obj;
		UpdateGraphics();
		return obj;
	}

	protected override void SelectionIndexChanged(object sender, EventArgs e)
	{
		base.SelectionIndexChanged(sender, e);
		List<ToolBar> itemsList = GetItemsList();
		if (viewport.ToolBars.Length != itemsList.Count)
		{
			viewport.ToolBars = itemsList.ToArray();
			UpdateGraphics();
		}
	}
}

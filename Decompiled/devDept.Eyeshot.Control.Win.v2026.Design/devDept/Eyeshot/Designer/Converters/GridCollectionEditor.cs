using System;
using System.Collections.Generic;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer.Converters;

public class GridCollectionEditor : EyeshotCollectionEditorArray<Grid>
{
	public GridCollectionEditor(Type type)
		: base(type)
	{
	}

	protected override object SetItems(object editValue, object[] value)
	{
		object obj = base.SetItems(editValue, value);
		viewport.Grids = (Grid[])obj;
		UpdateGraphics();
		return obj;
	}

	protected override void SelectionIndexChanged(object sender, EventArgs e)
	{
		base.SelectionIndexChanged(sender, e);
		List<Grid> itemsList = GetItemsList();
		if (viewport.Grids.Length != itemsList.Count)
		{
			viewport.Grids = itemsList.ToArray();
			UpdateGraphics();
		}
	}
}

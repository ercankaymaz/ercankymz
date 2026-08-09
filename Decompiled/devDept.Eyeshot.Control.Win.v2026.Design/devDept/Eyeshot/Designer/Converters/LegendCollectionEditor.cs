using System;
using System.Collections.Generic;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer.Converters;

public class LegendCollectionEditor : EyeshotCollectionEditorArray<Legend>
{
	public LegendCollectionEditor(Type type)
		: base(type)
	{
	}

	protected override object SetItems(object editValue, object[] value)
	{
		object obj = base.SetItems(editValue, value);
		viewport.Legends = (Legend[])obj;
		UpdateGraphics();
		return obj;
	}

	protected override void SelectionIndexChanged(object sender, EventArgs e)
	{
		base.SelectionIndexChanged(sender, e);
		List<Legend> itemsList = GetItemsList();
		if (viewport.Legends.Length != itemsList.Count)
		{
			viewport.Legends = itemsList.ToArray();
			UpdateGraphics();
		}
	}
}

using System;
using System.Collections.Generic;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer.Converters;

public class OriginSymbolCollectionEditor : EyeshotCollectionEditorArray<OriginSymbol>
{
	public OriginSymbolCollectionEditor(Type type)
		: base(type)
	{
	}

	protected override object SetItems(object editValue, object[] value)
	{
		object obj = base.SetItems(editValue, value);
		viewport.OriginSymbols = (OriginSymbol[])obj;
		UpdateGraphics();
		return obj;
	}

	protected override void SelectionIndexChanged(object sender, EventArgs e)
	{
		base.SelectionIndexChanged(sender, e);
		List<OriginSymbol> itemsList = GetItemsList();
		if (viewport.OriginSymbols.Length != itemsList.Count)
		{
			viewport.OriginSymbols = itemsList.ToArray();
			viewport.CompileUserInterfaceElements();
			UpdateGraphics();
		}
	}
}

using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public interface ISelectableItem
{
	bool Selected { get; set; }

	bool Selectable { get; set; }

	[Obsolete("use GetSelection(parents) instead.")]
	bool IsSelected(Stack<BlockReference> parents = null);

	bool GetSelection(Stack<BlockReference> parents = null);

	bool IsAnyInstanceSelected();

	void ClearSelectionForAllInstances();
}

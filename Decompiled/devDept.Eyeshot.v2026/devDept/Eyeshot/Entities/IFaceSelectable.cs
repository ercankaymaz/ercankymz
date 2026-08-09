using System.Collections.Generic;

namespace devDept.Eyeshot.Entities;

public interface IFaceSelectable
{
	selectionFilterType SelectionMode { get; set; }

	bool IsAnyFaceSelected();

	bool GetFaceSelection(int faceIndex, Stack<BlockReference> parents = null);

	bool GetFaceSelection(int shellIndex, int faceIndex, Stack<BlockReference> parents = null);

	void SetFaceSelection(int faceIndex, bool status, Stack<BlockReference> parents = null);

	void SetFaceSelection(int shellIndex, int faceIndex, bool status, Stack<BlockReference> parents = null);

	void ClearFacesSelection(Stack<BlockReference> parents = null);

	void ClearFacesSelectionForAllInstances();
}

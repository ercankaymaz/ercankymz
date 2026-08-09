namespace devDept.Eyeshot.Entities;

internal interface ISelectableSubItems
{
	selectionFilterType SelectionMode { get; set; }

	void ResetSelectionMode();
}

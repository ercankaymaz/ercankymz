namespace devDept.Eyeshot;

public interface ISelectable
{
	void ClearSelection();

	void SelectAll();

	void InvertSelection();

	void DeleteSelected();

	void CopySelection();

	void CutSelection();
}

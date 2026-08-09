namespace SourceGrid;

public interface IRows
{
	bool IsRowVisible(int row);

	void HideRow(int row);

	void ShowRow(int row);

	void ShowRow(int row, bool isVisible);
}

using System.Drawing;
using System.Windows.Forms;

namespace SourceGrid.Cells.Models;

public interface IRichTextBox : IModel
{
	void SetSelectionFont(CellContext cellContext, Font font);

	Font GetSelectionFont(CellContext cellContext);

	void SetSelectionColor(CellContext cellContext, Color color);

	Color GetSelectionColor(CellContext cellContext);

	void SetSelectionCharOffset(CellContext cellContext, int charOffset);

	int GetSelectionCharOffset(CellContext cellContext);

	void SetSelectionAlignment(CellContext cellContext, HorizontalAlignment horAlignment);

	HorizontalAlignment GetSelectionAlignment(CellContext cellContext);
}

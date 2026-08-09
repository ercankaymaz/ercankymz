using System.Drawing;

namespace SourceGrid.Cells.Models;

public interface IImage : IModel
{
	System.Drawing.Image GetImage(CellContext cellContext);
}

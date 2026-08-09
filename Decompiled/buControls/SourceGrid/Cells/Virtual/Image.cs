using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;

namespace SourceGrid.Cells.Virtual;

public class Image : CellVirtual
{
	public Image()
	{
		base.Model.AddModel(ValueImage.Default);
		base.Editor = ImagePicker.Default;
	}
}

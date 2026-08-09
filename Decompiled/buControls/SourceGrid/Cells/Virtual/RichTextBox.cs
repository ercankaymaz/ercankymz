using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells.Virtual;

public class RichTextBox : CellVirtual
{
	public RichTextBox()
	{
		View = SourceGrid.Cells.Views.RichTextBox.Default;
		base.Model.AddModel(new SourceGrid.Cells.Models.RichTextBox());
		AddController(SourceGrid.Cells.Controllers.RichTextBox.Default);
		base.Editor = new SourceGrid.Cells.Editors.RichTextBox();
	}
}

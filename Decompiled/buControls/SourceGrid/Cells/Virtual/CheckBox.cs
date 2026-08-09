using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells.Virtual;

public class CheckBox : CellVirtual
{
	public CheckBox()
	{
		View = SourceGrid.Cells.Views.CheckBox.Default;
		AddController(SourceGrid.Cells.Controllers.CheckBox.Default);
		AddController(MouseInvalidate.Default);
		base.Editor = new EditorBase(typeof(bool));
		base.Editor.EditableMode = EditableMode.None;
		base.Model.AddModel(new SourceGrid.Cells.Models.CheckBox());
	}
}

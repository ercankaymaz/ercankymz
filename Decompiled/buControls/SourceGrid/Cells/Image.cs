using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;

namespace SourceGrid.Cells;

public class Image : Cell
{
	public Image()
		: this(null)
	{
	}

	public Image(object value)
		: base(value)
	{
		base.Model.RemoveModel(base.Model.FindModel(typeof(SourceGrid.Cells.Models.Image)));
		base.Model.AddModel(ValueImage.Default);
		base.Editor = ImagePicker.Default;
	}
}

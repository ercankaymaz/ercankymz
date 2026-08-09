using System;
using System.Windows.Forms;

namespace SourceGrid.Cells;

[Obsolete("I will soon remove this class. If you need to add a user control to the grid I suggest to manually add or remove it using the Grid.LinkedControls collection.")]
public class CellControl : Cell
{
	private Control control;

	private LinkedControlScrollMode scrollMode = LinkedControlScrollMode.BasedOnPosition;

	private bool useCellBorder = true;

	public Control Control => control;

	public CellControl(Control control)
		: base(null)
	{
		this.control = control;
	}

	public CellControl(Control control, LinkedControlScrollMode scrollMode, bool useCellBorder)
		: this(control)
	{
		this.control = control;
		this.scrollMode = scrollMode;
		this.useCellBorder = useCellBorder;
	}

	public override void BindToGrid(Grid p_grid, Position p_Position)
	{
		base.BindToGrid(p_grid, p_Position);
		LinkedControlValue linkedControlValue = new LinkedControlValue(control, base.Range.Start);
		linkedControlValue.ScrollMode = scrollMode;
		linkedControlValue.UseCellBorder = useCellBorder;
		base.Grid.LinkedControls.Add(linkedControlValue);
		base.Grid.ArrangeLinkedControls();
	}

	public override void UnBindToGrid()
	{
		if (base.Grid.LinkedControls.GetByControl(control) != null)
		{
			base.Grid.LinkedControls.Remove(base.Grid.LinkedControls.GetByControl(control));
		}
		base.UnBindToGrid();
	}
}

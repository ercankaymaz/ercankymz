using System;
using System.Windows.Forms;

namespace SourceGrid.Cells.Controllers;

public class MouseCursor : ControllerBase
{
	public static readonly MouseCursor Default = new MouseCursor(Cursors.Default, applyOnMouseEnter: true);

	public static readonly MouseCursor Hand = new MouseCursor(Cursors.Hand, applyOnMouseEnter: true);

	private bool applyOnMouseEnter = false;

	private Cursor cursor = null;

	public Cursor Cursor
	{
		get
		{
			return cursor;
		}
		set
		{
			cursor = value;
		}
	}

	public MouseCursor(Cursor cursor, bool applyOnMouseEnter)
	{
		this.applyOnMouseEnter = applyOnMouseEnter;
		this.cursor = cursor;
	}

	public override void OnMouseEnter(CellContext sender, EventArgs e)
	{
		base.OnMouseEnter(sender, e);
		if (applyOnMouseEnter)
		{
			ApplyCursor(sender, e);
		}
	}

	public override void OnMouseLeave(CellContext sender, EventArgs e)
	{
		base.OnMouseLeave(sender, e);
		if (applyOnMouseEnter)
		{
			ResetCursor(sender, e);
		}
	}

	public virtual void ApplyCursor(CellContext sender, EventArgs e)
	{
		if (Cursor != null)
		{
			sender.Grid.Cursor = Cursor;
		}
	}

	public virtual void ResetCursor(CellContext sender, EventArgs e)
	{
		if (Cursor != null && sender.Grid.Cursor == Cursor)
		{
			sender.Grid.Cursor = null;
		}
	}
}

using System;
using System.Drawing;
using System.Windows.Forms;
using DevAge.Windows.Forms;
using ns27;

namespace SourceGrid.Cells.Models;

public class RichTextBox : IModel, IRichTextBox
{
	public void InsertString(CellContext cellContext, string s)
	{
		Class76.smethod_739(this, cellContext).SelectedText = s;
	}

	public void SetSelectionEffect(CellContext cellContext, EffectType effect)
	{
		ValueChangeEventArgs e = new ValueChangeEventArgs(null, effect);
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanging(cellContext, e);
		}
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
		}
	}

	public void SetSelectionFont(CellContext cellContext, Font font)
	{
		ValueChangeEventArgs e = new ValueChangeEventArgs(null, font);
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanging(cellContext, e);
		}
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
		}
	}

	public Font GetSelectionFont(CellContext cellContext)
	{
		return Class76.smethod_739(this, cellContext).SelectionFont;
	}

	public void SetSelectionColor(CellContext cellContext, Color color)
	{
		ValueChangeEventArgs e = new ValueChangeEventArgs(null, color);
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanging(cellContext, e);
		}
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
		}
	}

	public Color GetSelectionColor(CellContext cellContext)
	{
		return Class76.smethod_739(this, cellContext).SelectionColor;
	}

	public int GetSelectionCharOffset(CellContext cellContext)
	{
		return Class76.smethod_739(this, cellContext).SelectionCharOffset;
	}

	public void SetSelectionCharOffset(CellContext cellContext, int charoffset)
	{
		ValueChangeEventArgs e = new ValueChangeEventArgs(null, charoffset);
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanging(cellContext, e);
		}
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
		}
	}

	public void SetSelectionAlignment(CellContext cellContext, HorizontalAlignment horAlignment)
	{
		ValueChangeEventArgs e = new ValueChangeEventArgs(null, horAlignment);
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanging(cellContext, e);
		}
		if (cellContext.Grid != null)
		{
			cellContext.Grid.Controller.OnValueChanged(cellContext, EventArgs.Empty);
		}
	}

	public HorizontalAlignment GetSelectionAlignment(CellContext cellContext)
	{
		return Class76.smethod_739(this, cellContext).SelectionAlignment;
	}
}

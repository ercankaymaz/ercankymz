using System;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;

namespace SourceGrid.Cells.Views;

[Serializable]
public class Button : Cell
{
	public new static readonly Button Default;

	public new IButton Background
	{
		get
		{
			return (IButton)base.Background;
		}
		set
		{
			base.Background = value;
		}
	}

	static Button()
	{
		Default = new Button();
	}

	public Button()
	{
		Background = new ButtonThemed();
	}

	public Button(Button p_Source)
		: base(p_Source)
	{
		Background = (IButton)p_Source.Background.Clone();
	}

	public override object Clone()
	{
		return new Button(this);
	}

	protected override void PrepareView(CellContext context)
	{
		base.PrepareView(context);
		if (!context.CellRange.Contains(context.Grid.MouseDownPosition))
		{
			if (!context.CellRange.Contains(context.Grid.MouseCellPosition))
			{
				if (!context.CellRange.Contains(context.Grid.Selection.ActivePosition))
				{
					Background.Style = ButtonStyle.Normal;
				}
				else
				{
					Background.Style = ButtonStyle.Focus;
				}
			}
			else
			{
				Background.Style = ButtonStyle.Hot;
			}
		}
		else
		{
			Background.Style = ButtonStyle.Pressed;
		}
	}
}

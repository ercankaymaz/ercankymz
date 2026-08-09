using System;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;

namespace SourceGrid.Cells.Views;

[Serializable]
public class Header : Cell
{
	public new static RectangleBorder DefaultBorder;

	public new static readonly Header Default;

	public new IHeader Background
	{
		get
		{
			return (IHeader)base.Background;
		}
		set
		{
			base.Background = value;
		}
	}

	static Header()
	{
		DefaultBorder = RectangleBorder.NoBorder;
		Default = new Header();
	}

	public Header()
	{
		Background = new HeaderThemed();
		base.Border = DefaultBorder;
	}

	public Header(Header p_Source)
		: base(p_Source)
	{
		Background = (IHeader)p_Source.Background.Clone();
	}

	public override object Clone()
	{
		return new Header(this);
	}

	protected override void PrepareView(CellContext context)
	{
		base.PrepareView(context);
		if (!context.CellRange.Contains(context.Grid.MouseDownPosition))
		{
			if (!context.CellRange.Contains(context.Grid.MouseCellPosition))
			{
				Background.Style = ControlDrawStyle.Normal;
			}
			else
			{
				Background.Style = ControlDrawStyle.Hot;
			}
		}
		else
		{
			Background.Style = ControlDrawStyle.Pressed;
		}
	}
}

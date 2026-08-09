using System;
using DevAge.Drawing.VisualElements;

namespace SourceGrid.Cells.Views;

[Serializable]
public class RowHeader : Header
{
	public new static readonly RowHeader Default;

	public new IRowHeader Background
	{
		get
		{
			return (IRowHeader)base.Background;
		}
		set
		{
			base.Background = value;
		}
	}

	static RowHeader()
	{
		Default = new RowHeader();
	}

	public RowHeader()
	{
		Background = new RowHeaderThemed();
	}

	public RowHeader(RowHeader p_Source)
		: base(p_Source)
	{
	}

	public override object Clone()
	{
		return new RowHeader(this);
	}

	protected override void PrepareView(CellContext context)
	{
		base.PrepareView(context);
	}
}

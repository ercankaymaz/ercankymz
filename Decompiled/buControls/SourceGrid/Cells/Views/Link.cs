using System;
using System.Drawing;
using System.Windows.Forms;

namespace SourceGrid.Cells.Views;

[Serializable]
public class Link : Cell
{
	public new static readonly Link Default;

	static Link()
	{
		Default = new Link();
	}

	public Link()
	{
		base.Font = new Font(Control.DefaultFont, FontStyle.Underline);
		base.ForeColor = Color.Blue;
	}

	public Link(Link p_Source)
		: base(p_Source)
	{
	}

	public override object Clone()
	{
		return new Link(this);
	}
}

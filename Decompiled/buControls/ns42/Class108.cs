using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns27;

namespace ns42;

[ToolboxItem(false)]
internal sealed class Class108 : ComboBox
{
	protected int int_0;

	protected int int_1;

	private Color color_0;

	public Class108()
	{
		base.DrawMode = DrawMode.OwnerDrawFixed;
		base.DropDownStyle = ComboBoxStyle.DropDownList;
		int_0 = 2;
		int_1 = 5;
		BeginUpdate();
		Class76.smethod_183(this);
		EndUpdate();
	}

	void ComboBox.OnDrawItem(DrawItemEventArgs e)
	{
		base.OnDrawItem(e);
		if ((e.State & DrawItemState.ComboBoxEdit) != DrawItemState.ComboBoxEdit)
		{
			e.DrawBackground();
		}
		Graphics graphics = e.Graphics;
		if (base.Items.Count > 141)
		{
			for (int num = base.Items.Count - 1; num >= 141; num--)
			{
				base.Items.RemoveAt(num);
			}
		}
		if (e.Index != -1)
		{
			color_0 = Color.FromName((string)base.Items[e.Index]);
			graphics.FillRectangle(new SolidBrush(color_0), e.Bounds.X + int_0, e.Bounds.Y + int_0, e.Bounds.Width / int_1 - 2 * int_0, e.Bounds.Height - 2 * int_0);
			graphics.DrawRectangle(Pens.Black, e.Bounds.X + int_0, e.Bounds.Y + int_0, e.Bounds.Width / int_1 - 2 * int_0, e.Bounds.Height - 2 * int_0);
			graphics.DrawString(color_0.Name, e.Font, new SolidBrush(ForeColor), e.Bounds.Width / int_1 + 5 * int_0, e.Bounds.Y);
		}
	}
}

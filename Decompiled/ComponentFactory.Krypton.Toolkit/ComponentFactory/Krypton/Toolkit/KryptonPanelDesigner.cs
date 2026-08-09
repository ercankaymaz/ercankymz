using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonPanelDesigner : ScrollableControlDesigner
{
	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonPanelActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonPanelDesigner()
	{
		base.AutoResizeHandles = true;
	}

	protected override void OnPaintAdornments(PaintEventArgs pe)
	{
		base.OnPaintAdornments(pe);
		DrawBorder(pe.Graphics);
	}

	private void DrawBorder(Graphics graphics)
	{
		using Pen pen = new Pen(SystemColors.ControlDarkDark);
		pen.DashStyle = DashStyle.Dash;
		Rectangle clientRectangle = Control.ClientRectangle;
		clientRectangle.Width--;
		clientRectangle.Height--;
		graphics.DrawRectangle(pen, clientRectangle);
	}
}

using System.Drawing;
using System.Windows.Forms;

namespace buMutliTextbox;

public class VisualMarker
{
	public readonly Rectangle rectangle;

	public virtual Cursor Cursor => Cursors.Hand;

	public VisualMarker(Rectangle rectangle)
	{
		this.rectangle = rectangle;
	}

	public virtual void Draw(Graphics gr, Pen pen)
	{
	}
}

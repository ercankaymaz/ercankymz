using System.Drawing;

namespace buMutliTextbox;

public class ReadOnlyStyle : Style
{
	public ReadOnlyStyle()
	{
		IsExportable = false;
	}

	public override void Draw(Graphics gr, Point position, Range range)
	{
	}
}

using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class LibraryItemText : LibraryItem
{
	public double Height = 0.0;

	public string Text = "";

	public Font TextFont = new Font("Arial", 16f);

	public Pnt3D PointCenter = new Pnt3D();

	public ContentAlignment Alignment = ContentAlignment.BottomLeft;

	public LibraryItemText()
	{
	}

	public LibraryItemText(LibraryItemText data)
	{
		PointCenter = new Pnt3D(data.PointCenter);
		Height = data.Height;
		Text = data.Text;
		Alignment = data.Alignment;
		TextFont = data.TextFont;
		Plane = new WorkPlane(data.Plane);
	}

	public LibraryItemText(Pnt3D centerpoint, double height, string text, Font font, ContentAlignment alignment, WorkPlane plane)
	{
		PointCenter = new Pnt3D(centerpoint);
		Height = height;
		Text = text;
		Alignment = alignment;
		TextFont = font;
		Plane = new WorkPlane(plane);
	}

	public override string ToString()
	{
		return "Text :  [X:" + PointCenter.X.ToString("f3") + " Y:" + PointCenter.Y.ToString("f3") + " Z:" + PointCenter.Z.ToString("f3") + "] , Text: " + Text.ToString() + " , H: " + Height;
	}
}

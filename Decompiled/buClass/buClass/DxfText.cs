using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class DxfText : buSerilization
{
	public string Text = "";

	public double Height = 10.0;

	public Pnt3D StartPoint = new Pnt3D();

	public double Rotation = 0.0;

	public string Layer = "";

	public Color Color = Color.Black;

	public DxfText()
	{
	}

	public DxfText(DxfText data)
	{
		Color = data.Color;
		Height = data.Height;
		Layer = data.Layer;
		Rotation = data.Rotation;
		StartPoint = new Pnt3D(data.StartPoint);
		Text = data.Text;
	}
}
